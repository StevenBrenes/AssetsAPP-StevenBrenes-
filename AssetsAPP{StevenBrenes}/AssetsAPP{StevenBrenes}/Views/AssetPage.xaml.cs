using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AssetsAPP_StevenBrenes_.ViewModels;
using AssetsAPP_StevenBrenes_.Models;
using System.Collections;
using System.Collections.ObjectModel;

namespace AssetsAPP_StevenBrenes_.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssetPage : ContentPage
{
        AssetViewModel assetvm;
    public AssetPage()
    {
        InitializeComponent();

            BindingContext = assetvm = new AssetViewModel();
            LoadList();
    }
        private async void LoadList()
        {
            LstAssets.ItemsSource = (IEnumerable)await assetvm.GetQList();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AssetRegisterPage());
        }
    }
}