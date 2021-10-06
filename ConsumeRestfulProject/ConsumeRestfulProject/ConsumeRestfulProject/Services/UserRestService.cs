using ConsumeRestfulProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeRestfulProject.Services
{
    public class UserRestService
    {

        HttpClient client;
        public UserRestService()
        {
            client = new HttpClient();

        }


        public async Task<USER> getUserByUsernameAndPassword(string username, string password)
        {
            USER user = null;
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("username", username);
            queryString.Add("password", password);

            var uri = new Uri(Constants.BaseUserAddress + "?" + queryString.ToString());
            try
            {

                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<USER>(content);

                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return user;

        }


        public async Task<string> addUser(USER u)
        {
            string result = "";

            var uri = new Uri(Constants.BaseUserAddress);
            try   
            {
                var json = JsonConvert.SerializeObject(u);
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

    }
}
