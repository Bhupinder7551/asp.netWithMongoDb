using CoreCrudMongodb.Data.Interfaces.Repositories;
using CoreCrudMongodb.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrudMongodb.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository

    {
        private readonly DbContextEmp dbContextEmp;

        public EmployeeRepository(DbContextEmp dbContextEmp)
        {
            this.dbContextEmp = dbContextEmp;
        }
        public IEnumerable<Employee> GetAllEmp()
        {
            return dbContextEmp.Employees.Find(x => true).ToList();
        }

        public void Delete(string id)
        {
            dbContextEmp.Employees.DeleteOne(Builders<Employee>.Filter.Eq(x => x.Id, id));
        }



        public Employee GetById(string id)
        {
            return dbContextEmp.Employees.Find(x => x.Id == id).FirstOrDefault();
        }

        public void Update(Employee employee)
        {
            if (employee.Id != null)
            {
                var filter = Builders<Employee>.Filter.Eq(x => x.Id, employee.Id);
                var update = Builders<Employee>.Update
                     .Set(x => x.Country, employee.Country)
                       .Set(x => x.Name, employee.Name);
                dbContextEmp.Employees.UpdateOne(filter, update);
            }
            else
            {
                dbContextEmp.Employees.InsertOne(employee);
            }
        }
    }
}
