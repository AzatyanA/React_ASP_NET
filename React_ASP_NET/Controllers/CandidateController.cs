using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI;
using React_ASP_NET.Models;

namespace React_ASP_NET.Controllers
{
    public class CandidateController : Controller
    {
       
        private CandidateContext dba = new CandidateContext();
       
        private ICandidateRepository _candidateRepository;

        public CandidateController()
        {
            _candidateRepository = new CandidateRepository(new CandidateContext());
        }
        public CandidateController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        [HttpGet]
        public ActionResult Getcandidates()
        {
            IEnumerable<Candidate> cands = _candidateRepository.GetAll();
            return Json(cands, JsonRequestBehavior.AllowGet);
        }

       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            _candidateRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}