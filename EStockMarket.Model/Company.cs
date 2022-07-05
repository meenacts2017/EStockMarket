using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EStockMarket.Model
{
    public class Company
    {
        public string Id { get; set; }
        [Required]
        [StringLength(10, ErrorMessage ="Company code cannot exceed 10 character")]
        public string Code { get; set; }
        [Required]
        [StringLength(50, ErrorMessage ="Name cannot exceed 50 character")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "CEO cannot exceed 50 character")]
        public string CEO { get; set; }
        [Required]
        [Range(100000000, double.MaxValue, ErrorMessage = "TurnOver should be greaterthan or equal 10 crore")]
        public decimal TurnOver { get; set; }
        [Required]
        public string WebSite { get; set; }
        [Required]
        public string StockExchange { get; set; }
    }
}
