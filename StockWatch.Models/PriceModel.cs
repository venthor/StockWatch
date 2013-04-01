using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace StockWatch.Models
{
    public class PriceModel : Entity
    {
       
        [Required]
        public int StockId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime HistoryDate { get; set; }

       
    }
}
