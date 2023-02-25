namespace AuditingFields.Models
{
    public class AggregateRoot
    {

        public Guid Id { get; set; }


        public AggregateRoot(Guid id)
        {
            this.Id = id;
        }

        public AggregateRoot()
        {

        }
    }
}
