using GeoRegisterApp.Models;
using GeoRegisterApp.Views;
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
        public BusyPopUp busyPopUp;

        public RestService()
        {
            _client = new HttpClient();
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

        public async Task<ArrivalDeparture> PostArrivalDepartureAsync(string uri, ArrivalDeparture arrivalDepartureobj)
        {
            ArrivalDeparture objectBody = arrivalDepartureobj;
            //{ PAKEISTI GAUTO REZULTATO DUOMENIS }
            SendObjectResult objectResult = new SendObjectResult { };
            try
            {
                var postcontent = JsonConvert.SerializeObject(objectBody);
                HttpResponseMessage response = await _client.PostAsync(uri, new StringContent(postcontent));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    objectResult = JsonConvert.DeserializeObject<SendObjectResult>(content);
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
            return result == "0" ? true : false;
        }

    }
}
