using AuditingFields.Models;
using AutoMapper;

namespace AuditingFields.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MemberDto, Member>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.CreatedOnUtc , opt => opt.Ignore())
                .ForMember(v => v.ModifiedOnUtc , opt => opt.Ignore());
        }
    }
}
