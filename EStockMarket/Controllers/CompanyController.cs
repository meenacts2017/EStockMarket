﻿using EStockMarket.Business.Interface;
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
    [Route("/api/v1.0/market/[controller]")]
    [ApiController]
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
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var companyList = await _companyProcessor.GetAllCompanyAsync();
            if (companyList is null)
            {
                return NotFound();
            }

            return Ok(companyList);
        }

        [HttpGet("info/{id}")]
        public async Task<IActionResult> GetCompany(string id)
        {
            var result = await _companyProcessor.GetCompanyByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _companyProcessor.DeleteCompanyAsync(id);
            return Ok();
        }
    }
}