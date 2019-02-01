using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeLogin.Models;
using EmployeeLogin.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLogin.Controller
{
    [Route("Employees")]
    public class EmployeesController : ControllerBase
    {

       private readonly EmployeeService _services;
       
       public EmployeesController(EmployeeService service)
       {
            _services = service;
       }
       [HttpPost]
       [Route("{EmployeeId}/Login")]
       public ActionResult<Employee> Login(int EmployeeId)
       {
            String dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); ;
            Employee e = new Employee();
            e.Employeeid = EmployeeId;
            e.Date_Time = dt;
            e.LoginStatus = "Login";
            var emp = _services.AddLoginStatus(e);
            return emp;
       }

        [HttpPost]
        [Route("{EmployeeId}/Logout")]
        public ActionResult<Employee> Logout(int EmployeeId)
        {
            String dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Employee e = new Employee();
            e.Employeeid = EmployeeId;
            e.Date_Time = dt;
            e.LoginStatus = "Logout";
            var emp = _services.AddLoginStatus(e);
            return emp;
        }

       [HttpGet]
       [Route("{EmployeeId}/Summary")]
       public ActionResult<List<Employee>> Summary(int EmployeeId)
       {
            var emp = _services.GetEmployees(EmployeeId);
            if(emp.Count==0)
            {
                return NotFound();
            }
            return emp;
       }
    }
}