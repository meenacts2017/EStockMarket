using EStockMarket.DataAccess.Interface;
using EStockMarket.DataAccess.Model;
using EStockMarket.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Company = EStockMarket.DataAccess.Model.Company;
using CompanyStockRequest = EStockMarket.DataAccess.Model.CompanyStockRequest;

namespace EStockMarket.DataAccess.Implementation
{
    public class CompanyData : ICompany
    {
        private readonly IMongoCollection<Company> _companyCollection;
        public CompanyData(
        IOptions<DatabaseSettings> companyCollectionSettings)
        {
            var mongoClient = new MongoClient(
                companyCollectionSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                companyCollectionSettings.Value.DatabaseName);

            _companyCollection = mongoDatabase.GetCollection<Company>("Company");
        }
        public async Task AddCompanyAsync(Model.Company company)
        {
            await _companyCollection.InsertOneAsync(company);
        }

        public async Task<List<Model.Company>> GetAllCompanyAsync()
        {
            return await _companyCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Model.Company> GetCompanyByIdAsync(string id)
        {
            return await _companyCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task DeleteCompanyAsync(string id)
        {
            await _companyCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
