using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
/*
 * @author Derek Shaheen
 * @date 11/3/19
 * @description Allows the trade processor to take input from a file on the web
 * 
*/
//Request  407 - "As a trader I want to be able to able to read trades from the companies new web 
//service provider so I can enter trades from different apps."
namespace SingleResponsibilityPrinciple
{
    class URLTradeDataProvider : ITradeDataProvider
    {
        public URLTradeDataProvider(Stream stream)
        {
            this.stream = stream;
        }

        public IEnumerable<string> GetTradeData()
        {
            var url = "http://faculty.css.edu/tgibbons/trades4.txt";
            var tradeData = new List<string>();
            var client = new WebClient();
            using (var stream = client.OpenRead(url))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }
            return tradeData;
        }

        private readonly Stream stream;
    }
}
