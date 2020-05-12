using CoreCrudMongodb.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrudMongodb.Data
{
    public class DbContext
    {
        private IMongoDatabase db;

        public DbContext()
        {
            db = new MongoClient("mongodb://localhost:27017").GetDatabase("Sdb");
        }

        public void Seed()
        {
            var customers = this.Customers.Find(x => true).ToList();
            if( customers.Count() == 0)
            {
                var newCustomers = new List<Customer>();

               

                newCustomers.Add(new Customer()
                {
                 
                    City = "El Passo",
                    Country = "United States",                
                    Email = "john@outlook.com",
                    Name = "John",
               
                    Street = "Memphis Ave"
                });

             
                this.Customers.InsertMany(newCustomers);

            }
        }

        public IMongoCollection<Customer> Customers        {
            get
            {
                return db.GetCollection<Customer>("customers");
            }
        }
    }
}
