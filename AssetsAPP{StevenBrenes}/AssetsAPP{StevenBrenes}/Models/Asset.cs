using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace AssetsAPP_StevenBrenes_.Models
{
    public class Asset
{
        public RestRequest request { get; set; }

        const string mimetype = "application/json";
        const string contentype = "Content-Type";

      
        public int IdAsset { get; set; }
        public string Name { get; set; } //= null!;
        public string Area { get; set; } //= null!;
        public int Cost { get; set; }
        
        public async Task<ObservableCollection<Asset>> GetAssetsList()
        {
            try
            {
                string routeSufix = string.Format("Assets");
                string FinalApiRoute = CnnToAPI.ProductionRoute + routeSufix;

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(contentype, mimetype);
                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var QList = JsonConvert.DeserializeObject<ObservableCollection<Asset>>(response.Content);
                if (statusCode == HttpStatusCode.OK)
                {
                    return QList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
        }

        public async Task<bool> AddNewAsset()
        {
            bool R = false;

            try
            {
                
                string FinalApiRoute = CnnToAPI.ProductionRoute + "Assets";

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Post);

                               
                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);
                request.AddHeader(contentype, mimetype);

                string SerializedClass = JsonConvert.SerializeObject(this);

                request.AddBody(SerializedClass, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    R = true;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                throw;
            }

            return R;
        }
    }
}
