using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;


using System.Data.Entity;
using Shared.Entities;
using MongoDB.Driver;
using MongoDB.Bson;



namespace ServiceLayer
{
    class Program
    {
        public static IBLEmployees blHandler;
        public static IBLEmployees blHandler2;
        

        
        static void Main(string[] args)
        {

            SetupDependencies();
            SetupService();

            /*
            PartTimeEmployee pte = new PartTimeEmployee();
            pte.Id = 1350548;
            pte.Name = "Nachomax";
            pte.StartDate = new DateTime(1993,11,4);
            pte.HourlyRate = 6.5;

            blHandler.AddEmployee(pte);
            */

            /*
            FullTimeEmployee fte = new FullTimeEmployee();
            fte.Id = 13588;
            fte.Name = "robertiño";
            fte.StartDate = new DateTime(2017, 04, 08);
            fte.Salary = 15890;
            
            blHandler.AddEmployee(fte);
            */

            /*
            int id1 = 18999;
            blHandler.DeleteEmployee(id1);
            */

            /*
            FullTimeEmployee fte = new FullTimeEmployee();
            fte.Id = 1;
            fte.Name = "STARK UPDATEADO OTRA VEZ";
            fte.StartDate = new DateTime(1994, 11, 04);
            fte.Salary = 589475;

            blHandler.UpdateEmployee(fte);
            */

            /*
            PartTimeEmployee pte = new PartTimeEmployee();
            pte.Id = 1350;
            pte.Name = "mil tre cincuenta";
            pte.StartDate = new DateTime(1985, 11, 12);
            pte.HourlyRate = 1450;

            blHandler.UpdateEmployee(pte);
            */


            /*
            List<Employee> lista = new List<Employee>();
            lista = blHandler.GetAllEmployees();
            */

            /*
            Console.WriteLine("antes de la funcion");
            
            int id2 = 1;
            FullTimeEmployee f =   (FullTimeEmployee)blHandler.GetEmployee(id2);

            Console.WriteLine("despues de la funcion");
            Console.WriteLine(f.Id);
            Console.WriteLine(f.Name);
            Console.WriteLine(f.Salary);
            */

            /*
            int id2 = 18999;
            PartTimeEmployee f = (PartTimeEmployee)blHandler.GetEmployee(id2);

            Console.WriteLine("despues de la funcion");
            Console.WriteLine(f.Id);
            Console.WriteLine(f.Name);
            Console.WriteLine(f.HourlyRate);
            */


            Console.WriteLine("mierda");
            Console.ReadKey();

        }

        private static void SetupDependencies()
        {
                blHandler2 = new BLEmployees(new DataAccessLayer.DALEmployeesMongo());
                blHandler  = new BLEmployees(new DataAccessLayer.DALEmployeesEF());  
        }

        private static void SetupService()
        {

            ServiceHost host = new ServiceHost(typeof(ServiceEmployees),
                new Uri("http://localhost:8834/tsi1/"));
            try
            {
                
                host.Open();
                Console.WriteLine("El servicio esta listo");
                Console.WriteLine();
 
                // Si quiero cerrar el host descomentar esto
                //Console.ReadKey();
                //host.Close();
                
            }
            catch (CommunicationException exc)
            {
                Console.WriteLine("Hubo un problema de conexion " + exc.Message);
                //Console.Read();
            }

            Console.WriteLine("sali");

            //NOTA --- PARA HACER UN CLIENTE DE ESTE SERVICIO ES ASI : 
            /*
                class Test
                {
                    static void Main()
                    {
                        ServiceEmployeesClient client = new ServiceEmployeesClient();

                        // Use la variable 'client' para llamar a operaciones en el servicio.

                        // Cierre siempre el cliente.
                        client.Close();
                    }
                }
            */

        }
    }
}
