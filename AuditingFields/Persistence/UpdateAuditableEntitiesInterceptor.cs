using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AuditingFields.Persistence
{
    public class UpdateAuditableEntitiesInterceptor : SaveChangesInterceptor
    {
      public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            DbContext? dbContext = eventData.Context;
            if(dbContext is null)
            {
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }

            IEnumerable<EntityEntry<IAuditableEntity>> entries = dbContext.ChangeTracker.Entries<IAuditableEntity>();
            foreach(EntityEntry<IAuditableEntity> entry in entries)
            {
                if(entry.State == EntityState.Added)
                    entry.Property(p => p.CreatedOnUtc).CurrentValue = DateTime.UtcNow;
                if (entry.State == EntityState.Modified)    
                    entry.Property(p => p.ModifiedOnUtc).CurrentValue = DateTime.UtcNow;
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);

        }

    }
}
