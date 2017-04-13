//using DataAccessLayer.Model;
using DataAccessLayer.Model;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//probando git
namespace DataAccessLayer
{
    public class DALEmployeesEF : IDALEmployees
    {
        public void AddEmployee(Employee emp)
        {
            if (emp is Shared.Entities.PartTimeEmployee)
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
            Model.Practico1TSIEntities db = new Practico1TSIEntities();
            var emp = db.EmployeesTPH.Find(id);
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

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
            Console.WriteLine("Entre a listar Empleados de DataAcces");
            //creo lista vacia de tipo shared para retornar
            List<Employee> empList = new List<Employee>();

            var db = new Practico1TSIEntities();
            List<Model.PartTimeEmployee> empQuery = db.EmployeesTPH.OfType<Model.PartTimeEmployee>().ToList();
            Console.WriteLine("Me conecte a la base");
            

            foreach (var emp in empQuery)
            {
                Console.WriteLine("Entre al Foreach");
                var objEmp = new Shared.Entities.PartTimeEmployee();
                objEmp.Id = emp.EmployeeID;
                objEmp.Name = emp.Name;
                objEmp.StartDate = emp.StartDate;
                objEmp.HourlyRate = emp.HourlyRate;
                empList.Add(objEmp);
            }

            var empQueryF = from empF in db.EmployeesTPH.OfType<Model.FullTimeEmployee>()
                            select empF;

            foreach (var empF in empQueryF)
            {
                var objEmp2 = new Shared.Entities.FullTimeEmployee();
                objEmp2.Id = empF.EmployeeID;
                objEmp2.Name = empF.Name;
                objEmp2.StartDate = empF.StartDate;
                objEmp2.Salary = empF.Salary;
                empList.Add(objEmp2);

            }
            return empList;
        }

        public Employee GetEmployee(int id)
        {
            Console.WriteLine("entre a la funcion EF");
            Model.Practico1TSIEntities db = new Model.Practico1TSIEntities();
            var empQuery = db.EmployeesTPH.Find(id);
            Console.WriteLine(empQuery.Name);         

           
            if (empQuery is Model.PartTimeEmployee)
            {
                Console.WriteLine("entre a PartTimeEmployee");
                return GetPartTimeEmployee(id);
            }
            else
            {
                return GetFullTimeEmployee(id);
            }


           
        }
        public void AddPartTimeEmployee(Shared.Entities.PartTimeEmployee emp)
        {
            var context = new Practico1TSIEntities();
            var t = new Model.PartTimeEmployee();

            t.Name = emp.Name;
            //t.EmployeeID = emp.Id;
            t.StartDate = emp.StartDate;
            t.HourlyRate = emp.HourlyRate;
            context.EmployeesTPH.Add(t);
            context.SaveChanges();
        }

        public void AddFullTimeEmployee(Shared.Entities.FullTimeEmployee emp)
        {
            var bd = new Model.Practico1TSIEntities();
            var t = new Model.FullTimeEmployee();


            t.Name = emp.Name;
            t.EmployeeID = emp.Id;
            t.StartDate = emp.StartDate;
            t.Salary = (Int16)emp.Salary;
            bd.EmployeesTPH.Add(t);
            bd.SaveChanges();
        }
        public void UpdatePartTimeEmployee(Shared.Entities.PartTimeEmployee emp)
        {
            var db = new Model.Practico1TSIEntities();
            var objEmp = db.EmployeesTPH.Find(emp.Id);

            Model.PartTimeEmployee empF = new Model.PartTimeEmployee();
            empF.EmployeeID = emp.Id;
            empF.Name = emp.Name;
            empF.StartDate = emp.StartDate;
            empF.HourlyRate = emp.HourlyRate;

            db.EmployeesTPH.Remove(objEmp);
            db.EmployeesTPH.Add(empF);
            db.SaveChanges();
        }
        public void UpdateFullTimeEmployee(Shared.Entities.FullTimeEmployee emp)
        {
            var db = new Model.Practico1TSIEntities();
            var objEmp = db.EmployeesTPH.Find(emp.Id);

            Model.FullTimeEmployee empF = new Model.FullTimeEmployee();
            empF.EmployeeID = emp.Id;
            empF.Name = emp.Name;
            empF.StartDate = emp.StartDate;
            empF.Salary = (short)emp.Salary;

            db.EmployeesTPH.Remove(objEmp);
            db.EmployeesTPH.Add(empF);
            db.SaveChanges();
        }
        public Shared.Entities.PartTimeEmployee GetPartTimeEmployee(int id)
        {
           var db = new Practico1TSIEntities();
            Model.PartTimeEmployee objEmp = db.EmployeesTPH.OfType<Model.PartTimeEmployee>().Where(e => e.EmployeeID==id).FirstOrDefault();
            Shared.Entities.PartTimeEmployee emp = new Shared.Entities.PartTimeEmployee();
            emp.Id = objEmp.EmployeeID;
            emp.Name = objEmp.Name;
            emp.StartDate = objEmp.StartDate;
            emp.HourlyRate = objEmp.HourlyRate;
            return emp;
            
        }
        public Shared.Entities.FullTimeEmployee GetFullTimeEmployee(int id)
        {
            var db = new Practico1TSIEntities();
            Model.FullTimeEmployee objEmp= db.EmployeesTPH.OfType<Model.FullTimeEmployee>().Where(e => e.EmployeeID == id).FirstOrDefault();
            
            var retorno = new Shared.Entities.FullTimeEmployee();
            retorno.Id = objEmp.EmployeeID;
            retorno.Name = objEmp.Name;
            retorno.StartDate = objEmp.StartDate;
            retorno.Salary = objEmp.Salary;
            return retorno;
            

        }
    }
}
