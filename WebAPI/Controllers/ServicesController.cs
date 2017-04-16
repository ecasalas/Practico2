using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ServicesController : ApiController
    {
        public static IBLEmployees blHandler;
        // GET: api/Services
        public List<EmployeePOCO> Get()
        {
            blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
            List<Shared.Entities.Employee> emp = blHandler.GetAllEmployees();
            List<EmployeePOCO> listaRet = new List<EmployeePOCO>();
            
            foreach(var a in emp)
            {
                if (a is Shared.Entities.FullTimeEmployee)
                {
                    var aux = (Shared.Entities.FullTimeEmployee)a;
                    EmployeePOCO retorno = new EmployeePOCO();
                    retorno.Id = a.Id;
                    retorno.Name = aux.Name;
                    retorno.Salary = aux.Salary;
                    retorno.StartDate = aux.StartDate;
                    retorno.Type = 1;
                    listaRet.Add(retorno);
                }
                else
                {
                    var aux = (Shared.Entities.PartTimeEmployee)a;
                    EmployeePOCO retorno = new EmployeePOCO();
                    retorno.Id = aux.Id;
                    retorno.Name = aux.Name;
                    retorno.HoulyRate = aux.HourlyRate;
                    retorno.StartDate = aux.StartDate;
                    retorno.Type = 2;
                    listaRet.Add(retorno);
                }

            }
            return listaRet;
        }

        // GET: api/Services/5
        public EmployeePOCO Get(int id)
        {
            blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
            var emp = blHandler.GetEmployee(id);
            var retorno = new EmployeePOCO();
            if (emp is Shared.Entities.FullTimeEmployee)
            {
                var aux = (Shared.Entities.FullTimeEmployee)emp;
                retorno.Id = aux.Id;
                retorno.Name = aux.Name;
                retorno.Salary = aux.Salary;
                retorno.StartDate = aux.StartDate;
                retorno.Type = 1;
            }
            else
            {
                var aux = (Shared.Entities.PartTimeEmployee)emp;
                retorno.Id = aux.Id;
                retorno.Name = aux.Name;
                retorno.HoulyRate = aux.HourlyRate;
                retorno.StartDate = aux.StartDate;
                retorno.Type = 2;
            }
            return retorno;
        }

        // POST: api/Services
        public void Post(EmployeePOCO emp)
        {
            blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());

            if (emp.Type == 1)
            {
                var aux = new Shared.Entities.FullTimeEmployee();
                aux.Id = emp.Id;
                aux.Name = emp.Name;
                aux.Salary = emp.Salary;
                aux.StartDate = emp.StartDate;
               
                blHandler.AddEmployee(aux);

            }
            else
            {
                var aux = new Shared.Entities.PartTimeEmployee();
                aux.Id = emp.Id;
                aux.Name = emp.Name;
                aux.HourlyRate = emp.HoulyRate;
                aux.StartDate = emp.StartDate;
                
                blHandler.AddEmployee(aux);

            }
        }
        // PUT: api/Services/5
        public void Put(EmployeePOCO emp)
        {
            
            blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
            if(emp.Type == 1)
            {
                var aux = new Shared.Entities.FullTimeEmployee();
                aux.Id = emp.Id;
                aux.Name = emp.Name;
                aux.Salary = emp.Salary;
                aux.StartDate = emp.StartDate;

                blHandler.UpdateEmployee(aux);

            }
            else
            {
                var aux = new Shared.Entities.PartTimeEmployee();
                aux.Id = emp.Id;
                aux.Name = emp.Name;
                aux.HourlyRate = emp.HoulyRate;
                aux.StartDate = emp.StartDate;

                blHandler.UpdateEmployee(aux);

            }
           
        }

        // DELETE: api/Services/5
        public void Delete(int id)
        {
            blHandler = new BLEmployees(new DataAccessLayer.DALEmployeesEF());
            blHandler.DeleteEmployee(id);
        }
    }
}
public class EmployeePOCO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public System.DateTime StartDate { get; set; }
    public double HoulyRate { get; set; }
    public int Salary { get; set; }
    public int Type { get; set; }
}