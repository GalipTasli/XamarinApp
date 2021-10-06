using ConsumeRestfulProject.Models;
using Newtonsoft.Json;
using Org.Apache.Http.Protocol;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeRestfulProject.Services
{
    public class CarRestService
    {
        HttpClient client;
        public CarRestService()
        {

            client = new HttpClient();
        }


        public async Task<string> addCar(CAR car)
        {
            string result = "";


            var uri = new Uri(Constants.BaseCarAddress);
            try
            {
                var json = JsonConvert.SerializeObject(car);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(uri, content);
                HttpStatusCode code = response.StatusCode;
                if (code == HttpStatusCode.OK)
                    result = await response.Content.ReadAsStringAsync();


            }
            catch (Exception ex)
            {
                return null;

            }


            return result;


        }


        public async Task<List<CAR>> getCars()
        {
            List<CAR> cars = new List<CAR>();
            var uri = new Uri(Constants.BaseCarAddress);
            try
            {
                var response = await client.GetAsync(uri);
                HttpStatusCode code = response.StatusCode;
                if (code == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    cars = JsonConvert.DeserializeObject<List<CAR>>(content);
                }
            }
            catch (Exception ex)
            {
                return cars;
            }
            return cars;
        }
       

        public async Task<string> deleteCar(int id)
        {
            string result = "";
            var uri = new Uri(Constants.BaseCarAddress + "/" + id.ToString());
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                HttpStatusCode code = response.StatusCode;
                if (code == HttpStatusCode.OK)
                    result = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return null;

            }
            return result;
        }
    }
}
