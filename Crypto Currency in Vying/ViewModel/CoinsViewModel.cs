using Crypto_Currency_in_Vying.Models;
using Crypto_Currency_in_Vying.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Currency_in_Vying
{
    public class CoinsViewModel : ObservableRecipient
    {

        private readonly ISettingsService SettingsService;
        public CoinsViewModel(ISettingsService settingsService)
        {
            Task.Run(() => this.LoadPostsAsync()).Wait();
            LoadCoinsAsyncRelayCommand = new AsyncRelayCommand(LoadPostsAsync);
            SettingsService = settingsService;
            selectedId = settingsService.GetValue<string>(nameof(SelectedId)) ?? Ids[0];
        }
        public IAsyncRelayCommand LoadCoinsAsyncRelayCommand { get; }

        public ObservableCollection<Coin> Coins = new ObservableCollection<Coin>();

        private List<Coin> coinsToEvaluate = new List<Coin>();

        public IReadOnlyList<string> Ids = new[]
        {
            "bitcoin",
            "ethereum"
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

        private async Task LoadPostsAsync()
        {
            Coins.Clear();
            foreach(string id in Ids) 
            { 
                var response = await CoinsService.LoadCoinsAsync(id);
                Coins.Add(response);
            }
        }

    }
}
