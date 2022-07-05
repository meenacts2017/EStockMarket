using EStockMarket.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EStockMarket.DataAccess.Interface
{
    public interface ICompany
    {
        Task AddCompanyAsync(Company company);        
        Task<Company> GetCompanyByIdAsync(string id);
        Task<List<Company>> GetAllCompanyAsync();
        Task DeleteCompanyAsync(string id);
    }
}
