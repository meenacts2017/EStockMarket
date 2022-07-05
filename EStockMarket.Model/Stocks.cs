using System;
using System.Collections.Generic;
using System.Text;

namespace EStockMarket.Model
{
    public class Stocks
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public decimal StockPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
