using Crypto_Currency_in_Vying.Models;
using Crypto_Currency_in_Vying.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Crypto_Currency_in_Vying.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomItemCard : Page
    {
        public CustomItemCard()
        {
            this.InitializeComponent();
            this.DataContext = Ioc.Default.GetRequiredService<CustomItemCardViewModel>();
        }

        public CustomItemCardViewModel ViewModel => (CustomItemCardViewModel)DataContext;

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadCardAsync();
            ViewModel.Initialize();
        }
        private void myGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Coin current = myGridView.SelectedItem as Coin;

            Name.Text = $"{Name.Text} {current.Name}";
            Currency.Text = $"{Currency.Text} {current.Currency}";
            Value.Text = $"{Value.Text} {current.Value.ToString()}";
            Volume.Text = $"{Volume.Text} {current.Volume.ToString()}";
        }
    }
}


