using EmployeeLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLogin.Services
{
    public class EmployeeService
    {
        private readonly List<Employee> _Employee; 
        //This changes in new branch
        public EmployeeService()
        {
            _Employee = new List<Employee>();
        }
            
        public Employee AddLoginStatus(Employee e)
        {
            _Employee.Add(e);
            return e;
        }

        public List<Employee> GetEmployees(int id)
        {
            List<Employee> le = new List<Employee>();
            foreach(var e in _Employee)
            {
                if(e.Employeeid == id)
                {
                    le.Add(e);
                }
            }
            return le;
        }
    }
}
