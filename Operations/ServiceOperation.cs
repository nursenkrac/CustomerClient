using CustomerClient.Models;
using CustomerClient.Models.ViewModels.Outputs;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerClient.Operations
{
    public class ServiceOperation
    {
        public SaveCustomerOutputModel Create(SaveCustomer input)
        {
            SaveCustomerOutputModel ou = new SaveCustomerOutputModel();
            try
            {
                General g = new General();
                var client = new RestClient(g.url + "/api/User/Create");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                string json = JsonConvert.SerializeObject(input);              
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", json);
                IRestResponse response = client.Execute(request);
                ou = JsonConvert.DeserializeObject<SaveCustomerOutputModel>(response.Content.ToString());
            }
            catch (Exception ex)
            {
                ou.data.Status = false;
                ou.message = "Sistemde bir hata oluştu";

                throw;
            }


            return ou;
        }
        public GetByIdOutputModel GetById(GetCustomer input)
        {
            GetByIdOutputModel ou = new GetByIdOutputModel();
            try
            {
                General g = new General();
                var client = new RestClient(g.url + "/api/User/UserGetById");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                string json = JsonConvert.SerializeObject(input.CustomerById);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", json);
                IRestResponse response = client.Execute(request);
                ou = JsonConvert.DeserializeObject<GetByIdOutputModel>(response.Content.ToString());
            }
            catch (Exception ex)
            {
                ou.message = "Sistemde bir hata oluştu";
                ou.isSuccess = false;

                throw;
            }


            return ou;
        }
    }
}
