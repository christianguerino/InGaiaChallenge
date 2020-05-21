using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Serialization.Json;
using WinFormsConsumoWepApi.Models;

namespace WinFormsConsumoWepApi.WebApiClient
{
    public class MusicApi
    {
        public Models.TemperatureAndMusicList GetInformationByCity(string city)
        {
            Models.TemperatureAndMusicList info = null;

            try
            {
                //var client = new RestClient($"http://localhost:50879/api/Music/city/{city}");
                //var client = new RestClient($"http://localhost/ingaiawebapi/api/Music/city/{city}");
                var client = new RestClient($"https://ingaiachallenge.azurewebsites.net/api/Music/city/{city}");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Authorization", Constants.ConstValues.SECURITY_KEY);
                IRestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    info = SimpleJson.DeserializeObject<Models.TemperatureAndMusicList>(response.Content);
                }
                else
                {
                    if (response != null && response.Content.Length > 0)
                    {
                        ErrorApiMessage err = SimpleJson.DeserializeObject<Models.ErrorApiMessage>(response.Content);
                        if (err != null && err.message.Length > 0) throw new Exception(err.message);
                    }
                    else
                    {
                        throw new Exception(response.ErrorException.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return info;
        }

        public Models.TemperatureStatistics GetStatisticsByCity(string city)
        {
            Models.TemperatureStatistics info = null;

            try
            {
                //var client = new RestClient($"http://localhost:50879/api/Statistics/city/{city}");
                //var client = new RestClient($"http://localhost/ingaiawebapi/api/Statistics/city/{city}");
                var client = new RestClient($"https://ingaiachallenge.azurewebsites.net/api/Statistics/city/{city}");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Authorization", Constants.ConstValues.SECURITY_KEY);
                IRestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    info = SimpleJson.DeserializeObject<Models.TemperatureStatistics>(response.Content);
                }
                else
                {
                    if (response != null && response.Content.Length > 0)
                    {
                        ErrorApiMessage err = SimpleJson.DeserializeObject<Models.ErrorApiMessage>(response.Content);
                        if (err != null && err.message.Length > 0) throw new Exception(err.message);
                    }
                    else
                    {
                        throw new Exception(response.ErrorException.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return info;
        }

    }
}
