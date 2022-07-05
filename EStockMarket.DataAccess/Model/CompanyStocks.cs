using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStockMarket.DataAccess.Model
{
    public class CompanyStocks
    {
        public ObjectId Id { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCeo { get; set; }
        public string Turnover { get; set; }
        public string Website { get; set; }
        public string StockExchange { get; set; }
        public List<Stocks> Stocks { get; set; }
    }
}
