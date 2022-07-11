﻿using EStockMarket.Business.Interface;
using EStockMarket.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStockMarket.Controllers
{
    [Route("/api/v1.0/market/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStocksProcessor _stockProcessor;

        public StockController(IStocksProcessor stocksProcessor)
        {
            _stockProcessor = stocksProcessor;
        }

        [HttpPost("add/{companycode}")]
        public async Task<IActionResult> Post([FromBody] Stocks value, string companycode)
        {
            value.CompanyId = companycode;
            await _stockProcessor.AddStockAsync(value);
            return Ok();
        }

        [HttpGet("get/{companycode}/{startdate}/{enddate}")]
        public async Task<IActionResult> GetStocks(string companycode, DateTime startDate, DateTime endDate)
        {
            var stockList = await _stockProcessor.GetStocksByIdAndDate(companycode, startDate, endDate);
            if (stockList is null)
            {
                return NotFound();
            }
            
            return Ok(stockList);
        }
        [HttpGet("getAvg/{companycode}/{startdate}/{enddate}")]
        public async Task<IActionResult> GetStocksAug(string companycode, DateTime startDate, DateTime endDate)
        {
            var stockList = await _stockProcessor.GetStocksByIdAndDate(companycode, startDate, endDate); 
            if (stockList is null)
            {
                return NotFound();
            }
            var stockAvg = new StockAvg()
            {
                Max = stockList.Max(x => x.StockPrice).ToString(),
                Min = stockList.Min(x => x.StockPrice).ToString(),
                Avg = stockList.Average(x => x.StockPrice).ToString()
            };
            return Ok(stockAvg);
        }
        [HttpGet("get/{companyId}")]
        public async Task<IActionResult> GetStocksByCompanyId(string companyId)
        {
            var stockList = await _stockProcessor.GetStockByCompanyIdAsync(companyId);
            if (stockList is null)
            {
                return NotFound();
            }

            return Ok(stockList);
        }
    }
}
