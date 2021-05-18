using Crypto_Currency_in_Vying.Models;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x410

namespace Crypto_Currency_in_Vying
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = Ioc.Default.GetRequiredService<CoinsViewModel>();
            
        }

        public CoinsViewModel ViewModel => (CoinsViewModel)DataContext;

        private void CoinsDataGrid_Sorting(object sender, DataGridColumnEventArgs e)
        {
            if (e.Column.Tag.ToString() == "Value")
            {
                //Use the Tag property to pass the bound column name for the sorting implementation
                if (e.Column.Tag.ToString() == "Value")
                {
                    //Implement sort on the column "Range" using LINQ
                    if (e.Column.SortDirection == null || e.Column.SortDirection == DataGridSortDirection.Descending)
                    {
                        CoinsDataGrid.ItemsSource = new ObservableCollection<Coin>(from item in ViewModel.Coins
                                                                                   orderby item.Value ascending
                                                                                   select item);
                        e.Column.SortDirection = DataGridSortDirection.Ascending;
                    }
                    else
                    {
                        CoinsDataGrid.ItemsSource = new ObservableCollection<Coin>(from item in ViewModel.Coins
                                                                                   orderby item.Value descending
                                                                                   select item);
                        e.Column.SortDirection = DataGridSortDirection.Descending;
                    }
                }
                // add code to handle sorting by other columns as required

                // Remove sorting indicators from other columns
                foreach (var dgColumn in CoinsDataGrid.Columns)
                {
                    if (dgColumn.Tag.ToString() != e.Column.Tag.ToString())
                    {
                        dgColumn.SortDirection = null;
                    }
                }
            }
        }
    }
}
