using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockWatch.Data;
using StockWatch.Data.Entities;

namespace StockWatch.TestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new Repository(true);
            //repository.AddStock(new Stock()
            //{
            //     Symbol = "FLWS",
            //     Name="1-800 FLOWERS.COM Inc.",
            //      Sector = "Consumer Services",
            //     Industry = "Other Specialty Stores",
            //     SummaryLink = "http://www.nasdaq.com/symbol/flws"
            //});
 
            //repository.AddStock(new Stock()
            //{
            //    Symbol = "FCTY",
            //    Name = "1st Century Bancshares Inc",
            //    Sector = "Finance",
            //    Industry = "Major Banks",
            //    SummaryLink = "http://www.nasdaq.com/symbol/fcty"
            //});

            var stocks = repository.GetStocks();
            stocks.ForEach(s => Console.WriteLine("StockID: {0}", s.StockId));
            Console.WriteLine("Number of Stocks: {0}", stocks.Count);
            Console.WriteLine("Press Enter to Continue");
            Console.Read();

        }
    }
}
