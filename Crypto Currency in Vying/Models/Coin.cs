using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Crypto_Currency_in_Vying.Models
{
    internal sealed class Coin
    {
        public Coin(string name,string market, string currency, double value, double volume, string image)
        {
            Name = name;
            Market = market;
            Volume = volume;
            Currency = currency;
            Value = value;
            Image = new Uri(image);
        }
        public string Name { get; set; }

        public string Currency { get; set; }

        public string Market { get; set; }

        public double Value { get; set; }

        public double Volume { get; set; }

        public Uri Image { get; set; }
    }
}
