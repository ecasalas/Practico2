using DataAccessLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLEmployees : IBLEmployees
    {
        private IDALEmployees _dal;

        public BLEmployees(IDALEmployees dal)
        {
            _dal = dal;
        }

        public void AddEmployee(Employee emp)
        {

            _dal.AddEmployee(emp);
            //throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            _dal.DeleteEmployee(id);
           
        }

        public void UpdateEmployee(Employee emp)
        {
            _dal.UpdateEmployee(emp);
           
        }

        public List<Employee> GetAllEmployees()
        {
            Console.WriteLine("Entre a Listar Empleados de Busines");
            List<Employee> lemp = _dal.GetAllEmployees();
            
            return lemp;
            
        }

        public Employee GetEmployee(int id)
        {
            Console.WriteLine("Entre  a Businees ");
            Employee emp = _dal.GetEmployee(id);
            Console.WriteLine(emp.Name);
            return emp;
           
        }

        public double CalcPartTimeEmployeeSalary(int idEmployee, int hours)
        {
            double rate;
            try
            {
                Console.WriteLine("Empleado :"+idEmployee);
                Console.WriteLine("Horas : " +hours);
                var emp = (Shared.Entities.PartTimeEmployee)_dal.GetEmployee(idEmployee);
                
                Console.WriteLine(emp.Name);
                Console.WriteLine("RATE: "+emp.HourlyRate);
                rate = hours * emp.HourlyRate;
                
               // rate = hours * emp.HourlyRate;
                return rate;
            }
            catch
            {
                throw new InvalidCastException();
            }

        }

    }
}
