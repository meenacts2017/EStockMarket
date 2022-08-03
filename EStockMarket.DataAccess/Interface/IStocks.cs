using EStockMarket.DataAccess.Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EStockMarket.DataAccess.Interface
{
   public interface IStocks
    {
        Task AddStockAsync(Stocks stocks);  
        Task<List<Stocks>> GetStockByCompanyIdAsync(string id);
        Task<List<Stocks>> GetStocksByIdAndDate(string id, DateTime startDate, DateTime endDate);
        Task DeleteStockAsync(string companyId);
    }
}
