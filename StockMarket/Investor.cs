using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> Portfolio;



        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public int Count => Portfolio.Count;


        public Investor(string fullName, string emailAdress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAdress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();



        }
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest > stock.PricePerShare)
            {
                Portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
               
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            var nameMissing = Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            if (nameMissing == null)
            {
                return $"{companyName} does not exist.";

            }
            else if (sellPrice < nameMissing.PricePerShare)
            {
                return $"Cannot sell {companyName}.";

            }
            Portfolio.Remove(nameMissing);
            MoneyToInvest -= sellPrice;
            return $"{companyName} was sold.";

        }

        public Stock FindStock(string companyName)
        {
            var found = Portfolio.FirstOrDefault(x => x.CompanyName == companyName);

            if (found != null)
            {
                return found;
            }
            else
            {
                return null;
            }

        }
        public Stock FindBiggestCompany()
        {
            
            if (Portfolio.Count == 0)
            {
                return null;
            }
            decimal maxMarket = 0;
            Stock stockMAx = null;

            foreach (var item in Portfolio)
            {
                if (item.MarketCapitalization > maxMarket)
                {
                    maxMarket = item.MarketCapitalization;
                    stockMAx = item;
                }

            }
            return stockMAx;



        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var item in Portfolio)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}


