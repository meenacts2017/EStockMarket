using AutoMapper;
using EStockMarket.Business.Interface;
using EStockMarket.DataAccess.Interface;
using EStockMarket.Model;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EStockMarket.Business.Implementation
{
    public class CompanyProcessor : ICompanyProcessor
    {
        private readonly ICompany _companyData;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyProcessor> _logger;
        private readonly IStocksProcessor _stocksProcessor;
        public CompanyProcessor(ICompany company, IMapper mapper, ILogger<CompanyProcessor> logger, IStocksProcessor stocksProcessor)
        {
            _companyData = company;
            _mapper = mapper;
            _logger = logger;
            _stocksProcessor = stocksProcessor;
        }
        public async Task AddCompanyAsync(Company company)
        {
            try
            {
                var result = _mapper.Map<DataAccess.Model.Company>(company);
                await _companyData.AddCompanyAsync(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

        }

        public async Task<List<Company>> GetAllCompanyAsync()
        {
            try
            {
                var companyList = await _companyData.GetAllCompanyAsync();
                var list = _mapper.Map<List<Company>>(companyList);
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<Company> GetCompanyByIdAsync(string id)
        {
            try
            {
                var company = await _companyData.GetCompanyByIdAsync(id);
                var mapperResult = _mapper.Map<Company>(company);
                return mapperResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        public async Task DeleteCompanyAsync(string id)
        {
            try
            {
                await _stocksProcessor.DeleteStockAsync(id);
                await _companyData.DeleteCompanyAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
