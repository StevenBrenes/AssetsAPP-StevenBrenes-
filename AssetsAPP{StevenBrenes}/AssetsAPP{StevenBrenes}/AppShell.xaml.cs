using AssetsAPP_StevenBrenes_.ViewModels;
using AssetsAPP_StevenBrenes_.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AssetsAPP_StevenBrenes_
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
           // Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
