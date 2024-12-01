﻿using EmployeeAdminProtal.Data;
using EmployeeAdminProtal.Models;
using EmployeeAdminProtal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminProtal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployess()
        {
            var allEmployess = dbContext.Employees.ToList();
            return Ok(allEmployess);
        }


        //Select specific id using Get
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployessById(Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        //Add Employee
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
            };


            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);
        }




        //update 
        [HttpPut]
        [Route("{id:guid}")]

        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            dbContext.SaveChanges();

            return Ok(employee);
        }



        //Delete
        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if(employee == null)
            { 
                return NotFound();
            }

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();

            return Ok();
        }




    }
}
