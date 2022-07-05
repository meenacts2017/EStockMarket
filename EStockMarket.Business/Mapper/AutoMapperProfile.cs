using AutoMapper;
using EStockMarket.DataAccess.Model;


namespace EStockMarket.Business.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Company, EStockMarket.Model.Company>().ReverseMap();
            CreateMap<Stocks, EStockMarket.Model.Stocks>().ReverseMap();
        }
    }
}
