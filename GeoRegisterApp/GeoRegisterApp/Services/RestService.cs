using GeoRegisterApp.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeoRegisterApp.Services
{
    public class RestService
    {
        readonly HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<SendObjectResult> PostSendObjectResultAsync(string uri, string time, string userid, string longitude, string latitude)
        {
            SendObjectBody objectBody = new SendObjectBody { dateTime = time, userId = userid, longitude = longitude, latitude = latitude};
            SendObjectResult objectResult = new SendObjectResult();
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

        public async Task<ArrivalDeparture> PostArrivalDepartureAsync(string uri, ArrivalDeparture arrivalDepartureobj)
        {
            ArrivalDeparture objectBody = arrivalDepartureobj;
            //{ PAKEISTI GAUTO REZULTATO DUOMENIS }
            try
            {
                var postcontent = JsonConvert.SerializeObject(objectBody);
                HttpResponseMessage response = await _client.PostAsync(uri, new StringContent(postcontent));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var objectResult = JsonConvert.DeserializeObject<SendObjectResult>(content);
                    objectBody.userName = objectResult.userName;
                    objectBody.userSurname = objectResult.userSurname;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return objectBody;
        }

        public bool ResultIsOk(string result)
        {
            return result == "0";
        }

    }
}
