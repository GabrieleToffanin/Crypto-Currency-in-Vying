using System;
using System.Collections.Generic;
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

// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=234238

namespace Crypto_Currency_in_Vying.View
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class DashBoard : Page
    {
        public DashBoard()
        {
            this.InitializeComponent();
            contentFrame.Navigate(typeof(MainPage));
        }

        private void nvSample_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            FrameNavigationOptions navOptions = new FrameNavigationOptions();
            navOptions.TransitionInfoOverride = args.RecommendedNavigationTransitionInfo;
            Type pageType;
            if (args.InvokedItemContainer == MainPage)
            {
                pageType = typeof(MainPage);
            }
            else pageType = null;

            contentFrame.NavigateToType(pageType, null, navOptions);

        }
    }
}
