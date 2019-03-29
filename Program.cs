using System;
using System.Collections.Generic;
using System.Linq;

namespace StockPurchaseDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Hello World!");

           Dictionary<string, string> stocks = new Dictionary<string, string>();
           stocks.Add("AMZN", "Amazon");
           stocks.Add("TSLA", "Tesla");
           stocks.Add("SHOP", "Shopify");
           stocks.Add("FB", "Facebook");
           stocks.Add("SPOT", "Spotify");
           stocks.Add("TWLO", "Twilio");
           stocks.Add("IPOA", "Social Capital Hedosophia");
           stocks.Add("MJ", "ETFMG Alternative Harvest");
            
           // Creating a list of ValueTypes that represent stock purchases
           // The properties are ticker, shares and price. 
           List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();
           purchases.Add((ticker: "AMZN", shares: 1, price: 1778.44));
           purchases.Add((ticker: "TSLA", shares: 1, price: 277.60));
           purchases.Add((ticker: "SHOP", shares: 1, price: 207.25));
           purchases.Add((ticker: "FB", shares: 1, price: 165.73));
           purchases.Add((ticker: "SPOT", shares: 1, price: 138.87));
           purchases.Add((ticker: "TWLO", shares: 2, price: 128.95));
           purchases.Add((ticker: "IPOA", shares: 1, price: 10.19));
           purchases.Add((ticker: "MJ", shares: 2, price: 36.36));
           purchases.Add((ticker: "SHOP", shares: 2, price: 175.90));
           purchases.Add((ticker: "SHOP", shares: 2, price: 175.90));

           Dictionary<string, double> TotalHoldings = new Dictionary<string, double>();

            var CombinedData = stocks.Join(purchases, 
            s => s.Key,
            p => p.ticker,
            (s, p) => new {CompName = s.Value, CompOwn = p.shares, CompPrice = p.price }
            );
            
            foreach (var equity in CombinedData) {
                if (TotalHoldings.ContainsKey(equity.CompName)) {
                    TotalHoldings[equity.CompName] = TotalHoldings[equity.CompName] + (equity.CompOwn * equity.CompPrice);
                } else {
                    TotalHoldings.Add(equity.CompName, (equity.CompOwn * equity.CompPrice));                   
                }
            Console.WriteLine($"Man I'm glad I purchased {equity.CompName} on the dip");
            Console.ReadKey();
            }
        }
    }
}
