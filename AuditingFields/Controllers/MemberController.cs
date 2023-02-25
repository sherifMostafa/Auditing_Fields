using AuditingFields.Dtos;
using AuditingFields.Models;
using AuditingFields.Repository;
using AuditingFields.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuditingFields.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMemberRepository _memberRepository; 
        private IMapper _mapper; 
        private IUnitOfWork _unitOfWork;
        public MemberController(IMapper mapper , IMemberRepository memberRepository , IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memberRepository = memberRepository;   
            _unitOfWork = unitOfWork;
        }
        // GET: api/<MemberController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MemberController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MemberController>
        [HttpPost]
        public void Post([FromBody] MemberDto obj)
        {
            var member = _mapper.Map<MemberDto, Member>(obj);
            member.Id = new Guid();

            _memberRepository.AddMember(member);
            _unitOfWork.CompleteAsync();
        }

        // PUT api/<MemberController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MemberController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
