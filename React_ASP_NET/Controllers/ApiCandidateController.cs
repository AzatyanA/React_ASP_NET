using React_ASP_NET.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace React_ASP_NET.Controllers
{
    public class ApiCandidateController : ApiController
    {
        private CandidateContext db = new CandidateContext();
        private ICandidateRepository _candidateRepository;


        public ApiCandidateController()
        {
            _candidateRepository = new CandidateRepository(new CandidateContext());
        }
        public ApiCandidateController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }


        [HttpGet]
        public IEnumerable<Candidate> Get()
        {
            IEnumerable<Candidate> c = _candidateRepository.GetAll();
            return c;
        }
    }
}
