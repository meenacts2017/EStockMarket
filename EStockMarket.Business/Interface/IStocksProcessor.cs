using EStockMarket.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Stocks = EStockMarket.Model.Stocks;

namespace EStockMarket.Business.Interface
{
   public interface IStocksProcessor
    {
        Task AddStockAsync(Stocks stocks);
        Task<List<Stocks>> GetStockByCompanyIdAsync(string id);
        Task<List<Stocks>> GetStocksByIdAndDate(string id, DateTime startDate, DateTime endDate);
        Task DeleteStockAsync(string companyId);
    }
}
