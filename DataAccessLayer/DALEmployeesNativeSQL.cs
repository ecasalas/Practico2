using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALEmployeesNativeSQL : IDALEmployees
    {
        public void AddEmployee(Employee emp)
        {
            if(emp is Shared.Entities.PartTimeEmployee)
            {
                AddPartTimeEmployee((Shared.Entities.PartTimeEmployee)emp);
            }
            else
            {
                AddFullTimeEmployee((Shared.Entities.FullTimeEmployee)emp);
            }
        }

        public void DeleteEmployee(int id)
        {
            var db = new Model.Practico1TSIEntities();
            string sql = "DELETE FROM EmployeeTPH WHERE ID = " + id;
            db.Database.ExecuteSqlCommand(sql);
        }

        public void UpdateEmployee(Employee emp)
        {
            if (emp is Shared.Entities.PartTimeEmployee)
            {
                UpdatePartTimeEmployee((Shared.Entities.PartTimeEmployee)emp);
            }
            else
            {
                UpdateFullTimeEmployee((Shared.Entities.FullTimeEmployee)emp);
            }
        }

        public List<Employee> GetAllEmployees()
        {
            var db = new Model.Practico1TSIEntities();

            List<Employee> retorno = new List<Employee>();
            string sqlP = "SELECT * FROM EmployeeTPH WHERE TYPE = 1";
            string sqlF = "SELECT * FROM EmployeeTPH WHERE TYPE = 2";

            var empP = db.Database.SqlQuery<PartTimeEmployee>(sqlP).ToList();
            var empF = db.Database.SqlQuery<Shared.Entities.FullTimeEmployee>(sqlF).ToList();

            retorno.Union(empP);
            retorno.Union(empF);

            return retorno;

        }

        public Employee GetEmployee(int id)
        {

            throw new NotImplementedException();
           

        }

        public void AddPartTimeEmployee(Shared.Entities.PartTimeEmployee emp)
        {
            var db = new Model.Practico1TSIEntities();
            String sql = "INSERT INTO EmployeesTPH VALUES(" +
                        emp.Id + ",'" + emp.Name + "','" + emp.StartDate + "'," + null + "," + emp.HourlyRate + ")";
            db.Database.ExecuteSqlCommand(sql);
                        
        }
        public void AddFullTimeEmployee(Shared.Entities.FullTimeEmployee emp)
        {
            var db = new Model.Practico1TSIEntities();
            String sql = "INSERT INTO EmployeesTPH VALUES(" +
                        emp.Id + ",'" + emp.Name + "','" + emp.StartDate + "'," + emp.Salary + "," + null + ",1)";
            db.Database.ExecuteSqlCommand(sql);
        }
        public void UpdatePartTimeEmployee(Shared.Entities.PartTimeEmployee emp)
        {
            var db = new Model.Practico1TSIEntities();
            string sql = "UPDATE EmployeeTPH SET " +
                         "  NAME = '" + emp.Name + "'" +
                         ", START_DATE = '" + emp.StartDate + "'" +
                         ", SALARY = null " +
                         ", RATE = " + emp.HourlyRate +
                         ", TYPE = 1 " +
                         " WHERE ID = " + emp.Id;
            db.Database.ExecuteSqlCommand(sql);
        }
        public void UpdateFullTimeEmployee(Shared.Entities.FullTimeEmployee emp)
        {
            var db = new Model.Practico1TSIEntities();
            string sql = "UPDATE EmployeeTPH SET " +
                         "  NAME = '" + emp.Name + "'" +
                         ", START_DATE = '" + emp.StartDate + "'" +
                         ", SALARY = " +emp.Salary+
                         ", RATE = null " +
                         ", TYPE = 2 " +
                         " WHERE ID = " + emp.Id;
            db.Database.ExecuteSqlCommand(sql);
        }
    }
}
