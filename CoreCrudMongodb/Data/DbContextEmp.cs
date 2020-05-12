using System;
using CoreCrudMongodb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CoreCrudMongodb.Data
{
    public class DbContextEmp
    {
        private IMongoDatabase db;

        public DbContextEmp()
        {
            db = new MongoClient("mongodb://localhost:27017").GetDatabase("Bdb");
        }

        public void SeedEmp()
        {
            var employees = this.Employees.Find(x => true).ToList();
            if (employees.Count() == 0)
            {
                var newEmployees = new List<Employee>();



                newEmployees.Add(new Employee()
                {

               
                    Country = "New Zealand",
                    Name = "Bhupinder Singh Sandhu",
                    
                });


                this.Employees.InsertMany(newEmployees);

            }
        }

        public IMongoCollection<Employee> Employees
        {
            get
            {
                return db.GetCollection<Employee>("employees");
            }
        }
    }
}
