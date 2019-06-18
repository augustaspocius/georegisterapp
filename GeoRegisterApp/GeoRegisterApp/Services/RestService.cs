using GeoRegisterApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GeoRegisterApp.Services
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<SendObjectBody> GetSendObjectBodyAsync(string uri)
        {
            SendObjectBody objectBody = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    objectBody = JsonConvert.DeserializeObject<SendObjectBody>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return objectBody;
        }

        public async Task<SendObjectResult> PostSendObjectResultAsync(string uri, string time, string userid, string longitude, string latitude)
        {
            SendObjectBody objectBody = new SendObjectBody { dateTime = time, userId = userid, longitude = longitude, latitude = latitude};
            SendObjectResult objectResult = new SendObjectResult { };
            try
            {
                var postcontent = JsonConvert.SerializeObject(objectBody);
                HttpResponseMessage response = await _client.PostAsync(uri,new StringContent(postcontent));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    objectResult = JsonConvert.DeserializeObject<SendObjectResult>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return objectResult;
        }
    }
}
