using Crypto_Currency_in_Vying.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.Storage;

namespace Crypto_Currency_in_Vying.Services
{
    public sealed class SettingsService : ISettingsService
    {
        private readonly IPropertySet SettingsStorage = ApplicationData.Current.LocalSettings.Values;

        public void SetValue<T>(string key, T value)
        {
            if (!SettingsStorage.ContainsKey(key)) SettingsStorage.Add(key, value);
            else SettingsStorage[key] = value;
        }

        public T GetValue<T>(string key)
        {
            if (SettingsStorage.TryGetValue(key, out object value)) return (T)value;
            return default;
        }
    }
}
