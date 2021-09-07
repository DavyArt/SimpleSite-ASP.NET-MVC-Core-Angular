using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Project.DataBase.Models;
using Project.API.Services.Interfaces;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDbContextService _context;

        public EmployeeController(IDbContextService context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<EmployeeDTO> GetEmployee()
        {
            return _context.Employee.Select().Select(item => new EmployeeDTO()
            {
                Id = item.Id,
                CompanyId = item.CompanyId,
                Company = _context.Company.GetByCompanyId(item.CompanyId),
                Position = item.Position,
                F = item.F,
                I = item.I,
                O = item.O,
                EmploymentDate = item.EmploymentDate
            });
        }

        [HttpPost]
        public IActionResult PostEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employee.Add(employee);

                return Ok(employee);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult PutEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employee.Update(employee);

                return Ok(employee);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{employeeId}")]
        public IActionResult DeleteEmployee(int employeeId)
        {
            if (ModelState.IsValid)
            {
                _context.Employee.Delete(employeeId);

                return Ok(employeeId);
            }

            return BadRequest(ModelState);
        }
    }
}