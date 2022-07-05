using System;
using System.Collections.Generic;
using System.Text;

namespace EStockMarket.Model
{
    public class CompanyStockRequest
    {
        public string CompanyId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
