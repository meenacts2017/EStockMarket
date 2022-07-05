using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStockMarket.DataAccess.Model
{
    public class Company
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CEO { get; set; }
        public decimal TurnOver { get; set; }
        public string WebSite { get; set; }
        public string StockExchange { get; set; }

    }
}
