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
