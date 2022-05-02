using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AssetsAPP_StevenBrenes_.ViewModels;

namespace AssetsAPP_StevenBrenes_.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssetRegisterPage : ContentPage
{

        AssetViewModel viewModel;

    public AssetRegisterPage()
    {
        InitializeComponent();
            BindingContext = viewModel = new AssetViewModel();
    }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            int parsedcost;

            parsedcost = int.Parse(TxtCost.Text);


            bool R = await viewModel.AddAsset(TxtName.Text.Trim(),
                TxtArea.Text.Trim(),
                parsedcost);

            if (R)
            {
                await DisplayAlert("Agregado", "El activo se ha registrado con exito.", "Aceptar");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "El activo no ha podido registrarse con exito.", "Aceptar");
            }

        }
    }
}