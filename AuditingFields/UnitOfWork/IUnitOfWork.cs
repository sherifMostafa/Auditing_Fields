namespace AuditingFields.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
