using System;
using System.Collections.Generic;
using ApiRest.Models;
using RestSharp;

namespace ApiRest.WebApiClient
{
    public class OpenWeatherMap
    {
        private const string KEY = "0e84a5ae53e40318b75e49fb60bd554a";
        private const string CELSIUS = "metric";

        public double GetTemperatureInCelsiusByCity(string city)
        {
            double temp = 0.0;

            try
            {
                var client = new RestClient($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={KEY}&units={CELSIUS}");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    Models.OpenWeatherMapObjResp obj = SimpleJson.DeserializeObject<Models.OpenWeatherMapObjResp>(response.Content);
                    if (obj != null && obj.main != null && obj.main.temp != null)
                    {
                        temp = Utils.Conversion.ToDouble(obj.main.temp); //já substitui por 0.0 se eventualmente temp = null
                    }
                    else
                    {
                        throw new Exception(response.ErrorException.Message);
                    }
                }
                else
                {
                    #region tratamento de possiveis erros quando != 200

                    if (response != null && response.Content.Length > 0)
                    {
                        Models.WeatherErrorMessages err = SimpleJson.DeserializeObject<Models.WeatherErrorMessages>(response.Content);
                        throw new Exception(err.message + "(" + err.cod + ")");
                    }
                    else
                    {
                        throw new Exception(response.ErrorException.Message);
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return temp;
        }
    }
}