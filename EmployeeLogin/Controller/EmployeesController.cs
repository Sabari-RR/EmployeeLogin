using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeLogin.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLogin.Controller
{
    [Route("Employees")]
    public class EmployeesController : ControllerBase
    {

        private readonly EmployeeDbContext _dbContext;
        private MovementRecord e = new MovementRecord();

       public EmployeesController(EmployeeDbContext dbContext)
       {
            _dbContext = dbContext;
       }
       [HttpPost]
       [Route("{EmployeeId}/Login")]
       public async Task Login(int EmployeeId)
       {
            String dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            e.Employeeid = EmployeeId;
            e.Date_Time = dt;
            e.LoginStatus = "Login";
            _dbContext.Add(e);
            await _dbContext.SaveChangesAsync();
            
       }

        [HttpPost]
        [Route("{EmployeeId}/Logout")]
        public async Task Logout(int EmployeeId)
        {
            String dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            e.Employeeid = EmployeeId;
            e.Date_Time = dt;
            e.LoginStatus = "Logout";
            _dbContext.Add(e);
            await _dbContext.SaveChangesAsync();
        }

       [HttpGet]
       [Route("{EmployeeId}/Summary")]
       public IEnumerable<MovementRecord> Summary(int EmployeeId)
       {
            IEnumerable<MovementRecord> Employee = _dbContext.movementRecords.Where(x => x.Employeeid == EmployeeId);
            if(Employee != null)
            {
                return Employee;
            }
            return null; 
       }
    }
}