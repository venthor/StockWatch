using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockWatch.Models.Stocks;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Helpers;
using System.Drawing;

using Point = DotNet.Highcharts.Options.Point;


namespace StockWatch.Controllers
{

    
    public class StockController : BaseController
    {
        //
        // GET: /Stock/

        [HttpGet]
        public ActionResult Index()
        {
            var stockResponse = this.ModelService.GetAllStocks();
            var stocks = stockResponse.Result;

            var model = new ListViewModel()
            {
                Stocks = stocks
            };
            return View(model);
        }

        
        public ActionResult ViewPrice(int id)
        {
            var stockResponse = this.ModelService.GetStock(id);
            var stocks = stockResponse.Result;
            var model = new EditViewModel()
            {
                Stock = stocks
            };
         int priceCount = stocks.Prices.Count();
         string [] dates = new string[priceCount];
         object[] prices = new object[priceCount];
            int count =0;
         foreach (Models.PriceModel price in stocks.Prices)
         {
               dates[count] = price.HistoryDate.ToString();
               prices[count] = price.Price;
               count++;
         }

         DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart")
            .InitChart(new DotNet.Highcharts.Options.Chart
                {
                    DefaultSeriesType = ChartTypes.Line,
                    MarginRight = 130,
                    MarginBottom = 25,
                    ClassName = "chart"
                })
            .SetTitle(new Title
                {
                    Text = "Stock Market Performance",
                    X = -20
                })
            .SetXAxis(new DotNet.Highcharts.Options.XAxis
                {
                    Categories = dates
                })
            .SetYAxis(new DotNet.Highcharts.Options.YAxis
                {
                    Title = new XAxisTitle { Text = "Price in US Dollars" },
                    PlotLines = new[]
                       {
                      new XAxisPlotLines
                       {
                            Value = 0,
                            Width = 1,
                            Color = ColorTranslator.FromHtml("#808080")
                        }
                 }
                })
             .SetSeries(new[]
                {
                    new Series { Name = "Prices", Data = new DotNet.Highcharts.Helpers.Data(prices) 
                }
                        
               });
         return View(chart);
           // return View("ViewPrice", model);
         //return View(GetChart());
        }

        private Highcharts GetChart()
        {
            object[] BerlinData = new object[] { -0.9, 0.6, 3.5, 8.4, 13.5, 17.0, 18.6, 17.9, 14.3, 9.0, 3.9, 1.0 };
            string[] Categories = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            object[] LondonData = new object[] { 3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8 };
            object[] NewYorkData = new object[] { -0.2, 0.8, 5.7, 11.3, 17.0, 22.0, 24.8, 24.1, 20.1, 14.1, 8.6, 2.5 };
            object[] TokioData = new object[] { 7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6 };


            Highcharts chart = new Highcharts("chart")
             .InitChart(new Chart
             {
                 DefaultSeriesType = ChartTypes.Line,
                 MarginRight = 130,
                 MarginBottom = 25,
                 ClassName = "chart"
             })
             .SetTitle(new Title
             {
                 Text = "Monthly Average Temperature",
                 X = -20
             })
             .SetSubtitle(new Subtitle
             {
                 Text = "Source: WorldClimate.com",
                 X = -20
             })
            
             .SetXAxis(new XAxis { Categories = Categories })
             .SetYAxis(new YAxis
             {
                 Title = new XAxisTitle { Text = "Temperature (°C)" },
                 PlotLines = new[]
                                          {
                                              new XAxisPlotLines
                                              {
                                                  Value = 0,
                                                  Width = 1,
                                                  Color = ColorTranslator.FromHtml("#808080")
                                              }
                                          }
             })
             .SetTooltip(new Tooltip
             {
                 Formatter = @"function() {
                                        return '<b>'+ this.series.name +'</b><br/>'+
                                    this.x +': '+ this.y +'°C';
                                }"
             })
             .SetLegend(new Legend
             {
                 Layout = Layouts.Vertical,
                 Align = HorizontalAligns.Right,
                 VerticalAlign = VerticalAligns.Top,
                 X = -10,
                 Y = 100,
                 BorderWidth = 0
             })
             .SetSeries(new[]
                           {
                               new Series { Name = "Tokyo", Data = new DotNet.Highcharts.Helpers.Data(TokioData) },
                               new Series { Name = "New York", Data = new DotNet.Highcharts.Helpers.Data(NewYorkData) },
                               new Series { Name = "Berlin", Data = new DotNet.Highcharts.Helpers.Data(BerlinData) },
                               new Series { Name = "London", Data = new DotNet.Highcharts.Helpers.Data(LondonData) }
                           }
             );

            return chart;
        }

    }
}
