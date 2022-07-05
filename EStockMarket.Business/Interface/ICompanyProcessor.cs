using EStockMarket.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EStockMarket.Business.Interface
{
    public interface ICompanyProcessor
    {
        Task AddCompanyAsync(Company company);
        Task<Company> GetCompanyByIdAsync(string id);
        Task<List<Company>> GetAllCompanyAsync();
        Task DeleteCompanyAsync(string id);
    }
}
