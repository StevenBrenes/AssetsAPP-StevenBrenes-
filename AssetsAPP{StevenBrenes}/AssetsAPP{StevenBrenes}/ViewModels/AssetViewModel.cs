using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AssetsAPP_StevenBrenes_.Models;
using Xamarin.Forms;

namespace AssetsAPP_StevenBrenes_.ViewModels
{
    public class AssetViewModel : BaseViewModel

        
{

        private string name;
        private string area;
        private int cost;
        


        public Asset MyAsset { get; set; }
        

        public string Name 
        {
            get { return name; }
            set
            {
if (name == value)
                {
                    return;
                }
name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Area
        {
            get { return area; }
            set
            {
                if (area == value)
                {
                    return;
                }
                area = value;
                OnPropertyChanged(nameof(Area));
            }
        }

        public int Cost
        {
            
            get { return cost; }
            set
            {
                if (cost == value)
                {
                    return;
                }
                cost = value;
                OnPropertyChanged(nameof(Cost));
            }
        }

        public Command AddNewAssetCommand { get; }

        public AssetViewModel()
        {
            MyAsset = new Asset();
            AddNewAssetCommand = new Command(async() => await
            AddAsset(Name, Area, Cost));
        }

        public async Task<bool> AddAsset(string pName,
            string pArea,
            int pCost)
        {

            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MyAsset.Name = pName;
                MyAsset.Area = pArea;
                MyAsset.Cost = pCost;

                bool R = await MyAsset.AddNewAsset();

                return R;


            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                IsBusy = false;
            }

        }


        public async Task<ObservableCollection<Asset>> GetQList()
        {
            if (IsBusy)
            {
                return null;
            }
            else
            {
                IsBusy = true;

                try
                {
                    ObservableCollection<Asset> list = new ObservableCollection<Asset>();

                    list = await MyAsset.GetAssetsList();

                    if (list == null)
                    {
                        return null;
                    }
                    else
                    {
                        return list;
                    }

                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }

        
    }
}
