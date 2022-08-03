using AutoMapper;
using EStockMarket.Business.Interface;
using EStockMarket.DataAccess.Interface;
using EStockMarket.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EStockMarket.Business.Implementation
{
    public class StocksProcessor : IStocksProcessor
    {
        private readonly IStocks _stocksData;
        private readonly IMapper _mapper;
        private readonly ILogger<StocksProcessor> _logger;
        public StocksProcessor(IStocks stocks, IMapper mapper, ILogger<StocksProcessor> logger)
        {
            _stocksData = stocks;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddStockAsync(Stocks stocks)
        {
            try
            {
                stocks.StartDate = DateTime.Now;
                stocks.EndDate = DateTime.Now;
                var mapperResult = _mapper.Map<DataAccess.Model.Stocks>(stocks);
                await _stocksData.AddStockAsync(mapperResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<List<Stocks>> GetStockByCompanyIdAsync(string id)
        {
            try
            {
                var result = await _stocksData.GetStockByCompanyIdAsync(id);
                return _mapper.Map<List<Stocks>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            
        }

        public async Task<List<Stocks>> GetStocksByIdAndDate(string id, DateTime startDate, DateTime endDate)
        {
            try
            {
                //var result = await _stocksData.GetStocksByIdAndDate(id, startDate, endDate);
                //return _mapper.Map<List<Stocks>>(result);
                var stocks = await _stocksData.GetStockByCompanyIdAsync(id);
                var transformedResult = _mapper.Map<List<Stocks>>(stocks);
                return transformedResult.FindAll(x => x.StartDate.Date >= startDate.Date && x.EndDate.Date <= endDate.Date);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task DeleteStockAsync(string companyId)
        {
            try
            {
                await _stocksData.DeleteStockAsync(companyId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

    }
}
