using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrudMongodb.Models;

namespace CoreCrudMongodb.Data.Interfaces.Repositories
{
    public interface IEmployeeRepository

    {
        IEnumerable<Employee> GetAllEmp();
        Employee GetById(string id);
        void Update(Employee employee);
        void Delete(string id);

    }

}
