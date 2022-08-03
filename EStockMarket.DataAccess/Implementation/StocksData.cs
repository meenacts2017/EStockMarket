using EStockMarket.DataAccess.Interface;
using EStockMarket.DataAccess.Model;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Stocks = EStockMarket.DataAccess.Model.Stocks;

namespace EStockMarket.DataAccess.Implementation
{
    public class StocksData : IStocks
    {
        private readonly IMongoCollection<Stocks> _stocksCollection;
        public StocksData(
        IOptions<DatabaseSettings> stocksCollectionSettings)
        {
            var mongoClient = new MongoClient(
                stocksCollectionSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                stocksCollectionSettings.Value.DatabaseName);

            _stocksCollection = mongoDatabase.GetCollection<Stocks>("Stocks");
        }

        public async Task AddStockAsync(Model.Stocks stocks)
        {
            await _stocksCollection.InsertOneAsync(stocks);
        }

        public async Task<List<Model.Stocks>> GetStockByCompanyIdAsync(string id)
        {
            return await _stocksCollection.Find(x => x.CompanyId == id).ToListAsync();
          
        }
        public async Task<List<Model.Stocks>> GetStocksByIdAndDate(string id, DateTime startDate, DateTime endDate)
        {
            DateTime startDateFilter = DateTime.Parse(startDate.ToString(), CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            DateTime endDateFilter = DateTime.Parse(endDate.ToString(), CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);

            return await _stocksCollection.Find(x => x.CompanyId == id &&  x.StartDate >= startDateFilter
            && x.EndDate <= endDateFilter).ToListAsync();
        }

        public async Task DeleteStockAsync(string companyId)
        {
            await _stocksCollection.DeleteManyAsync(x => x.CompanyId == companyId);
        }
    }
}
