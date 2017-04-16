using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BusinessLogicLayer;
using DataAccessLayer;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ServiceController : ApiController   
    {
        public static IBLEmployees blHandler;

        // GET: api/Service
        public List<Shared.Entities.Employee> GetAllEmployee()
        {

            blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
            return blHandler.GetAllEmployees();
        }

        // GET: api/Service/5
        public Shared.Entities.Employee GetEmployee(int id)
        {
            blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
            return blHandler.GetEmployee(id);
        }

        // POST: api/Service
        [HttpPost]
        public void AddEmployee(Shared.Entities.Employee emp)
        {
            blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
            blHandler.AddEmployee(emp);
        }

        // PUT: api/Service/5
        public void UpdateEmployee(Shared.Entities.Employee emp)
        {
            blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
            blHandler.UpdateEmployee(emp);
        }

        // DELETE: api/Service/5
        public void DeleteEmployee(int id)
        {
            blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
            blHandler.DeleteEmployee(id);
        }
    }
}
