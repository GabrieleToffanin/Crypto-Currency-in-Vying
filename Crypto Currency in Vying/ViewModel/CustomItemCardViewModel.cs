using Crypto_Currency_in_Vying.Helpers;
using Crypto_Currency_in_Vying.Models;
using Crypto_Currency_in_Vying.Services;
using Microsoft.Toolkit.Collections;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Crypto_Currency_in_Vying.ViewModel
{
    public sealed class CustomItemCardViewModel : ObservableRecipient
    {

        #region GeneralWidget 
        private readonly ISettingsService Settings; 

        public CustomItemCardViewModel(ISettingsService settings)
        {
            Settings = settings;
        }

        private readonly ICoinsService CoinsService = Ioc.Default.GetRequiredService<ICoinsService>();
        public async Task LoadCardAsync()
        {
            myCoinCards.Clear();

            foreach(string id in ids) 
            { 
                var response = await CoinsService.LoadCoinsAsync(id);

                foreach (var item in response.CurrentPrice)
                {
                    if (item.Currency.Equals("EUR"))
                    myCoinCards.Add(new Coin(response.Name, item.market.Name, item.Currency, item.Value, item.Volume, response.Image.Large));
                }
            }
        }
        public ObservableCollection<Coin> myCoinCards { get; set; } = new ObservableCollection<Coin>();
        private Coin selectedCoin;
        public Coin SelectedCoin
        {
            get => selectedCoin;
            set => SetProperty(ref selectedCoin, value);
        }

        private IReadOnlyList<string> ids { get; } = new[]
        {
            "bitcoin",
            "ethereum",
            "ripple",
            "stellar"
        };
        #endregion
        #region Implementing Grouping

        private ObservableCollection<GroupInfoList> _coins = new ObservableCollection<GroupInfoList>();
        public ObservableCollection<GroupInfoList> Coins 
        {
            get => _coins;
            set => SetProperty(ref _coins, value);
        }

        public void Initialize()
        {
            GenerateGrouping();
        }

        private void GenerateGrouping()
        {
            var query = from coins in myCoinCards
                        group coins by coins.Market into g
                        orderby g.Key
                        select new { GroupName = g.Key, Items = g };
            foreach(var g in query)
            {
                GroupInfoList info = new GroupInfoList();
                info.Key = g.GroupName + "(" + g.Items.Count() + ")";

                foreach(var item in g.Items)
                {
                    info.Add(item);
                }
                Coins.Add(info);
            }
        }
        #endregion
    }
}
