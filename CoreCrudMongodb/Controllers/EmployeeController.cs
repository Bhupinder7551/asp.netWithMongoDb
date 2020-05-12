using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrudMongodb.Data.Interfaces.Services;
using CoreCrudMongodb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreCrudMongodb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public IActionResult Index()
        {
            var employees = employeeService.GetAllEmp();
            return View(employees);
        }
        // GET: Customer/Create
        public ActionResult Create()
        {
            var employee = new Employee();
            return View("form", employee);
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("form", employee);
                }

                employeeService.Update(employee);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("form", employee);
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(string id)
        {
            var employee = employeeService.GetById(id);
            return View("form", employee);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                employeeService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}