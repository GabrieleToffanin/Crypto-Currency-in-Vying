using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Currency_in_Vying.Models
{
    public sealed class GroupInfoCollection<T>
    {
        public object Key { get; set; }
        public List<T> Items = new List<T>();

        public void Add(T item)
        {
            Items.Add(item);
        }
    }
}
