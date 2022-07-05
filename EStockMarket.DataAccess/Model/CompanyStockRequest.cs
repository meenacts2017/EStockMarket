using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStockMarket.DataAccess.Model
{
    public class CompanyStockRequest
    {
        public ObjectId CompanyId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
