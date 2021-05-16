using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Currency_in_Vying.Models
{
    public interface ISettingsService
    {
        void SetValue<T>(string key, T value);

        [Pure]
        T GetValue<T>(string key);
    }
}
