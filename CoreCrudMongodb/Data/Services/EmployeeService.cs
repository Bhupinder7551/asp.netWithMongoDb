using CoreCrudMongodb.Data.Interfaces.Repositories;
using CoreCrudMongodb.Data.Interfaces.Services;
using CoreCrudMongodb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrudMongodb.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public IEnumerable<Employee> GetAllEmp()
        {
            return employeeRepository.GetAllEmp();
        }

        public void Delete(string id)
        {
            employeeRepository.Delete(id);
        }


        public Employee GetById(string id)
        {
            return employeeRepository.GetById(id);
        }

        public void Update(Employee employee)
        {
            employeeRepository.Update(employee);
        }
    }
}
