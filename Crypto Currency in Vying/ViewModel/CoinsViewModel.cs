using Crypto_Currency_in_Vying.Models;
using Crypto_Currency_in_Vying.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Crypto_Currency_in_Vying
{
    public class CoinsViewModel : ObservableRecipient
    {

        private readonly ISettingsService SettingsService;
        public CoinsViewModel(ISettingsService settingsService)
        {   
            LoadCoinsAsyncRelayCommand = new AsyncRelayCommand(LoadPostsAsync);
            LoadCoinForPopulateDataGrid = new AsyncRelayCommand(LoadCoinAsync);
            SettingsService = settingsService;
            selectedId = settingsService.GetValue<string>(nameof(SelectedId)) ?? Ids[0];
            
        }
        public IAsyncRelayCommand LoadCoinsAsyncRelayCommand { get; }
        public IAsyncRelayCommand LoadCoinForPopulateDataGrid { get; }

        public ObservableCollection<Coin> Coins = new ObservableCollection<Coin>();

        public IReadOnlyList<string> Ids = new[]
        {
            "bitcoin",
            "ethereum",
            "ripple",
            "stellar"
        };

        private string selectedId;

        public string SelectedId
        {
            get => selectedId;
            set => SetProperty(ref selectedId, value);
        }

        private Coin selectedCoin;

        public Coin SelectedCoin 
        {
            get => selectedCoin;
            set => SetProperty(ref selectedCoin, value);
        }

        private readonly ICoinsService CoinsService = Ioc.Default.GetRequiredService<ICoinsService>();

        private async Task LoadCoinAsync()
        {
            Coins.Clear();

            var response = await CoinsService.LoadCoinsAsync(Ids[0]);

            foreach (var item in response.CurrentPrice)
            {
                if (item.Currency.Equals("EUR"))
                    Coins.Add(new Coin(response.Name, item.market.Name, item.Currency, item.Value, item.Volume, response.Image.Thumb));
            }
        }

        private async Task LoadPostsAsync()
        {
            Coins.Clear();
             
                var response = await CoinsService.LoadCoinsAsync(SelectedId);
                foreach(var item in response.CurrentPrice)
                {
                    if (item.Currency.Equals("EUR"))
                        Coins.Add(new Coin(response.Name,item.market.Name ,item.Currency, item.Value, item.Volume, response.Image.Thumb));
                }
            
        }

        

    }
}
