using BusinessLogicLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ServiceEmployees : IServiceEmployees
    {
        private static IBLEmployees blHandler;
        

        public ServiceEmployees()
        {
            blHandler = Program.blHandler;
        }

        public void AddEmployee(Employee emp)
        {
            try
            {
                blHandler.AddEmployee(emp);
            }
            catch
            {
                throw new Exception("Problemas al insertar empleado");
            }
            //throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                blHandler.DeleteEmployee(id);
            }
            catch
            {
                throw new Exception("Problemas al eliminar  empleado de id: "+id);
            }
            //throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee emp)
        {
            try
            {
                blHandler.UpdateEmployee(emp);
            }
            catch
            {
                throw new Exception("Problemas al updatear empleado de id: "+emp.Id);
            }
            //throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                Console.WriteLine("Entre listar empleado Service");
               return blHandler.GetAllEmployees();
            }
            catch
            {
                return null;
                throw new Exception("Problemas al desplegar todos los empleados");
             
            }
            
            //throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            try
            {
                 return blHandler.GetEmployee(id);
            }
            catch
            {
                throw new Exception("Problemas al traer empleado");

            }
            
            //throw new NotImplementedException();
        }

        public double CalcPartTimeEmployeeSalary(int idEmployee, int hours)
        {
            try
            {
                return blHandler.CalcPartTimeEmployeeSalary(idEmployee, hours);
            }
            catch
            {
                throw new Exception("Problemas calculando salario del empleado de id: " + idEmployee);
            }
            //throw new NotImplementedException();
        }
    }
}
