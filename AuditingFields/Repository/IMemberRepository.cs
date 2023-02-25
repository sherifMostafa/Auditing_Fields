using AuditingFields.Models;

namespace AuditingFields.Repository
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> getAllMembers();
        Task<Member> getMember(Guid id);
        void AddMember(Member member);
        void RemoveMember(Member member);
    }
}
