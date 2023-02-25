namespace AuditingFields.Models
{
    public sealed class Member : AggregateRoot, IAuditableEntity
    {

        public Member(Guid id,string name,string email ) : base(id)
        {
            this.Name = name;
            this.Email = email;
        }

        public Member()
        {

        }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
    }
}
