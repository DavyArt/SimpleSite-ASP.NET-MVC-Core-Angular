using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Project.API.Services.Interfaces;
using Project.DataBase.Models;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IDbContextService _context;

        public CompanyController(IDbContextService context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Company> GetCompany()
        {
            return _context.Company.Select();
        }

        [HttpPost]
        public IActionResult PostCompany(Company employee)
        {
            if (ModelState.IsValid)
            {
                _context.Company.Add(employee);

                return Ok(employee);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult PutCompany(Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Company.Update(company);

                return Ok(company);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{companyId}")]
        public IActionResult DeleteCompany(int companyId)
        {
            if (ModelState.IsValid)
            {
                _context.Company.Delete(companyId);

                return Ok(companyId);
            }

            return BadRequest(ModelState);
        }
    }
}
