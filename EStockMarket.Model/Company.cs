using System;
using System.Collections.Generic;
using System.Text;

namespace EStockMarket.Model
{
    public class Company
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CEO { get; set; }
        public decimal TurnOver { get; set; }
        public string WebSite { get; set; }
        public string StockExchange { get; set; }
    }
}
