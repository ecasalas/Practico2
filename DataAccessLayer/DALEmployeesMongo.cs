using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;


namespace DataAccessLayer
{
    public class DALEmployeesMongo : IDALEmployees

        
    {
        //Inserta bien
        public void AddEmployee(Employee emp)
        {
            try
            {
                string con = ConexionMongo();
                MongoClient cliente = new MongoClient(con);
                IMongoDatabase db = cliente.GetDatabase("practico");
                IMongoCollection<Empleados> col = db.GetCollection<Empleados>("Empleados");

 
                if (emp is FullTimeEmployee)
                {
                    col.InsertOne(new Empleados { EMP_ID = emp.Id, NAME = emp.Name, START_DATE = emp.StartDate, SALARY = AddSalary((FullTimeEmployee)emp), RATE = null, TYPE_EMP = 1 });
                }
                else
                {
                    col.InsertOne(new Empleados { EMP_ID = emp.Id, NAME = emp.Name, START_DATE = emp.StartDate, SALARY = null, RATE = AddRate((PartTimeEmployee)emp), TYPE_EMP = 2 });

                }
            }
            catch
            {
                Console.WriteLine("Problema al agregar el empleado de id: " + emp.Id + " y nombre " + emp.Name + " a la base de datos Mongodb");
            }

        }

        //Elimina bien - buen chico
        public void DeleteEmployee(int id)
        {
            string con = ConexionMongo();
            MongoClient cliente = new MongoClient(con);
            IMongoDatabase db = cliente.GetDatabase("practico");
            IMongoCollection<Empleados> col = db.GetCollection<Empleados>("Empleados");

            try
            {
                 var existe = Builders<Empleados>.Filter.Eq("EMP_ID", BsonNull.Value).ToString();

                Console.WriteLine(existe);

                if (existe!= ""){
                    //hago filtro diciendo, traeme el documento con el id que me pasan EMP_ID es un campo de ese documento en mongo
                    var filtro = Builders<Empleados>.Filter.Eq("EMP_ID", id);

                    // var elminar =  col.DeleteManyAsync(filtro); este es para elminiar todos los wque cumplan con la condicion del filtro, pero al ser unica la id,usamos deleteone , creo....
                    var elminar = col.FindOneAndDelete(filtro);

                    Console.WriteLine("El empleadodo con id: " + id + " fue eliminado de la base de datos MongoDB");
                }else
                {
                    Console.WriteLine("El empleado de id: " + id + "no se encuentra en la base de datos MongoDB");
                }
            }catch
            {
                Console.WriteLine("Problemas al eliminar empleado de id: " + id + " de la base de datos MongoDB");
            }

        }

        //Updatea bien, no se contemplo el cambio de un empleado de FullTime a PartTime
        public void UpdateEmployee(Employee emp)
        {

            string con = ConexionMongo();
            MongoClient cliente = new MongoClient(con);
            IMongoDatabase db = cliente.GetDatabase("practico");
            IMongoCollection<Empleados> col = db.GetCollection<Empleados>("Empleados");

            try
            {
                var filtro = Builders<Empleados>.Filter.Eq("EMP_ID", emp.Id);
               

                if (emp is FullTimeEmployee)
                {
                    Console.WriteLine("hasta aca llegue otra vez");
                    int salario = AddSalary((FullTimeEmployee)emp);
                    Console.WriteLine(salario);

                    var update = Builders<Empleados>.Update.Set("NAME", emp.Name).Set("START_DATE", emp.StartDate).Set("SALARY",AddSalary((FullTimeEmployee)emp));
                    var res = col.UpdateOne(filtro, update);
                    


                }
                else
                {
                    var update = Builders<Empleados>.Update.Set("NAME", emp.Name).Set("START_DATE", emp.StartDate).Set("RATE", AddRate((PartTimeEmployee)emp));
                    var resultado = col.UpdateOne(filtro, update);
                }
                //como soy una pija todavia no se como hacer lo de ver si es fullemployee o parttime
            }catch
            {
                Console.WriteLine("Problemas al modificar empleado de id: " + emp.Id + " en la base de datos MongoDB");
            }

            //throw new NotImplementedException();
        }
        
        //Devuelve bien wiii
        public List<Employee> GetAllEmployees()

        {
            try
            {
                string con = ConexionMongo();
                MongoClient cliente = new MongoClient(con);
                IMongoDatabase db = cliente.GetDatabase("practico");
                IMongoCollection<Empleados> col = db.GetCollection<Empleados>("Empleados");

                //Lista a retornar
                List<Employee> empleados = new List<Employee>();

                //opcion 2 probar -- funciona
                //var documentos = col.Find(Builders<Empleados>.Filter.Empty).ToListAsync();

                //opciones 3 - funciona y es la mas linda creo yo
                var list = col.Find(_ => true).ToList();

                FullTimeEmployee fte = new FullTimeEmployee();
                PartTimeEmployee pte = new PartTimeEmployee();

                foreach(var lista in list)
                {

                    if(lista.TYPE_EMP == 1)
                    {
                        fte.Id = lista.EMP_ID;
                        fte.Name = lista.NAME;
                        fte.StartDate = lista.START_DATE;
                        fte.Salary = (int)lista.SALARY;
                        empleados.Add(fte);
                    }
                    else
                    {
                        pte.Id = lista.EMP_ID;
                        pte.Name = lista.NAME;
                        pte.StartDate = lista.START_DATE;
                        pte.HourlyRate = (double)lista.RATE;
                        empleados.Add(pte);

                    }
                    
                }
                return empleados;

                
            }
            catch
            {
                Console.WriteLine("Problema al listar todos los empleados de la base de datos MongoDB");
                return null;
            }

        }

        //Despues de lucharla, devuelve bien
        public Employee GetEmployee(int id)
        {

            string con = ConexionMongo();
            MongoClient cliente = new MongoClient(con);
            IMongoDatabase db = cliente.GetDatabase("practico");
            IMongoCollection<Empleados> col = db.GetCollection<Empleados>("Empleados");

            try
            {
                FullTimeEmployee fte = new FullTimeEmployee();
                PartTimeEmployee pte = new PartTimeEmployee();

                Console.WriteLine("LLEGUE A LA FUNCION");

                //Filtro para ver si el empleado de id que me pasan es FULL o PART
                //Si devuelve null es PART TIME , si devuelve algo es FULL TIME
                /*
                var filtro = Builders<Empleados>.Filter.And(


                    Builders<Empleados>.Filter.Eq("EMP_ID", id),
                    Builders<Empleados>.Filter.Eq("TYPE_EMP",1)
                    );
                    */
                var filtrowea = Builders<Empleados>.Filter.Eq("EMP_ID", id);

                

                if (filtrowea != null)
                {

                    var f = Builders<Empleados>.Filter.Eq("EMP_ID", id);
                    var n = col.Find(f).ToList();

                    int type = 0;

                    foreach (var lista in n)
                    {
                         type = lista.TYPE_EMP;
                    }


                        Console.WriteLine("Pase el filtro");

                    //PART TIME EMPLOYEE
                    if (type == 2)

                    {
                            

                            Console.WriteLine("entre al if");

                            foreach (var lista in n)
                            {

                            Console.WriteLine("ENTRE AL FOREACH");
                                pte.Id = lista.EMP_ID;
                                pte.Name = lista.NAME;
                                pte.StartDate = lista.START_DATE;
                                pte.HourlyRate = (double)lista.RATE;

                            Console.WriteLine(lista.NAME);

                            }

                            return pte;
                    }

                    //FULL TIME EMPLOYEE
                    else
                    {
                        /*
                        var f = Builders<Empleados>.Filter.Eq("EMP_ID", id);
                        var n = col.Find(f).ToList();
                        */
                        Console.WriteLine("entre al else");

                        foreach (var lista in n)
                        {
                            fte.Id = lista.EMP_ID;
                            fte.Name = lista.NAME;
                            fte.StartDate = lista.START_DATE;
                            fte.Salary = (int)lista.SALARY;

                        }

                        return fte;
                    }

                }
                else
                {
                    Console.WriteLine("No se pudo encontrar empleado de id: " + id + " en la base de datos MongoDB");
                    return null;
                }
            }
            catch
            {
                Console.WriteLine("No se pudo encontrar empleado de id: " + id + " en la base de datos MongoDB");
                return null;
                    
            }

    }


        //------------FUNCIONES Y CLASES ADICIONALES A LA LETRA Y REQUERIMIENTOS DEL PRACTICO-------------


        //Para ser mas prolijo solamente te devuelve el string con la direccion de la bd mongo
        public string ConexionMongo() { 
    
        string con = "mongodb://127.0.0.1:27017";
        return con;

        //throw new NotImplementedException();
    }

        //Agrega el salary
        public int AddSalary(FullTimeEmployee fte)
        {

            return fte.Salary;

        }

        //Agrega el rate
        public double AddRate(PartTimeEmployee pte)
        {
            return pte.HourlyRate;
        }

        //clase JSON de empleados
        public class Empleados
        {
            public ObjectId _id { get; set; }
            public int EMP_ID { get; set; }
            public string NAME { get; set; }
            public DateTime START_DATE { get; set; }
            public  int? SALARY { get; set; }
            public double? RATE { get; set; }
            public int TYPE_EMP { get; set; }
        }


    }
}

