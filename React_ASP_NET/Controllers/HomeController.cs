using React_ASP_NET.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI;

namespace React_ASP_NET.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeContext db = new EmployeeContext();


        private IEmployeeRepository _employeeRepository;

        public HomeController()
        {
            _employeeRepository = new EmployeeRepository(new EmployeeContext());
        }
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        [HttpGet]
        public ActionResult Getemployees()
        {
            IEnumerable<Employee> e = _employeeRepository.GetAll();
            return Json(e, JsonRequestBehavior.AllowGet);
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
            _employeeRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}