using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
