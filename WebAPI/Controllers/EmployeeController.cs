using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogicLayer;

namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        private static IBLEmployees blHandler;
        // GET: api/Employee
        public List<Shared.Entities.Employee> Get()
        {
            blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
            return blHandler.GetAllEmployees();
        }

        // GET: api/Employee/5
        public Shared.Entities.Employee Get(int id)
        {
            blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
            return blHandler.GetEmployee(id);
        }

        // POST: api/Employee
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Employee/5
        public void Put(Shared.Entities.Employee emp)
        {
            blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
            blHandler.UpdateEmployee(emp);
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
            blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
            blHandler.DeleteEmployee(id);
        }
    }
}
