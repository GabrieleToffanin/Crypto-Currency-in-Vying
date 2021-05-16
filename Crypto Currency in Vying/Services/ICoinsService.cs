using Crypto_Currency_in_Vying.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Currency_in_Vying.Services
{
    public interface ICoinsService
    {
        [Get("/api/v3/coins/{id}")]
        Task<Coin> LoadCoinsAsync(string id);
    }
}
