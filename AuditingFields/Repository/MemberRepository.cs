using AuditingFields.Models;
using AuditingFields.Persistence;

namespace AuditingFields.Repository
{
    public class MemeberRepository : IMemberRepository
    {
        private readonly ApplicationDbContext _context;
        public MemeberRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddMember(Member member)
        {
            _context.Members.Add(member);
        }

        public Task<IEnumerable<Member>> getAllMembers()
        {
            throw new NotImplementedException();
        }

        public Task<Member> getMember(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveMember(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
