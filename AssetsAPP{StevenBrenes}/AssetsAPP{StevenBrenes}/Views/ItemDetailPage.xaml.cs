using AssetsAPP_StevenBrenes_.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AssetsAPP_StevenBrenes_.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}