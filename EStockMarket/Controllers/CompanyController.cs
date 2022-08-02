using EStockMarket.Business.Interface;
using EStockMarket.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStockMarket.Controllers
{
    [ApiController]
    [Route("/api/v1.0/market/[controller]")]    
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyProcessor _companyProcessor;

        public CompanyController(ICompanyProcessor companyProcessor)
        {
            _companyProcessor = companyProcessor;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Post([FromBody] Company value)
        {
            await _companyProcessor.AddCompanyAsync(value);
            return Ok(1);
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var companyList = await _companyProcessor.GetAllCompanyAsync();
            if (companyList is null)
            {
                return NotFound();
            }

            return Ok(companyList);
        }

        [HttpGet]
        [Route("info/{companycode}")]
        public async Task<IActionResult> GetCompany(string companycode)
        {
            var result = await _companyProcessor.GetCompanyByIdAsync(companycode);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete]
        [Route("delete/{companycode}")]
        public async Task<IActionResult> Delete(string companycode)
        {
            await _companyProcessor.DeleteCompanyAsync(companycode);
            List<string> message = new List<string>()
            {
                "Company deleted successfully",
                "1"
            };
            return Ok(message);
        }
    }
}
