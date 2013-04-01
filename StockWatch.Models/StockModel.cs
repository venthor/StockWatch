using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockWatch.Models
{
    public class StockModel : Entity
    {
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(9)]
        public string Symbol { get; set; }
        [Required, StringLength(25)]
        public string Sector { get; set; }
        [Required, StringLength(100)]
        public string Industry { get; set; }
        [Required, StringLength(75)]
        public string SummaryLink { get; set; }

        public IQueryable<PriceModel> Prices { get; set; }
    }
}
