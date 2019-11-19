using React_ASP_NET.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace React_ASP_NET.Controllers
{
    public class ApiEmployeeController : ApiController
    {
        private EmployeeContext db = new EmployeeContext();
        private IEmployeeRepository _employeeRepository;

        public ApiEmployeeController()
        {
            _employeeRepository = new EmployeeRepository(new EmployeeContext());
        }
        public ApiEmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: api/ApiEmployee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            IEnumerable<Employee> e = _employeeRepository.GetAll();
            return e;
        }   
    }
}
