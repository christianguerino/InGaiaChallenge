using ApiRest.Enumerators;
using ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;
using WebApi.OutputCache.V2;

namespace ApiRest.Controllers
{
    public class MusicController : ApiController
    {
        // GET api/music
        //public void Get()
        //{
        //    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "É obrigatório informar a cidade. Verifique a documentação."));
        //}

        // GET api/music/city/{cityname}
        /// <summary>
        /// Endpoint que retorna a Lista de Músicas baseando-se em uma cidade
        /// </summary>
        /// <param name="cityname"></param>
        /// <returns></returns>
        [Route("api/music/city/{cityname}")]
        [CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)]
        public TemperatureAndMusicList Get([FromUri] string cityname)
        {
            string key = (Request.Headers.Contains("Authorization") ? Request.Headers.GetValues("Authorization").FirstOrDefault() : string.Empty);
            if (!key.Equals(Constants.ConstValues.SECURITY_KEY))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Chave inválida."));
            }

            TemperatureAndMusicList info = null;
            Enumerators.MusicCategory categ = Enumerators.MusicCategory.Nenhuma;
            double temp = 0;

            #region validacao

            if (cityname.Length <= 2)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "É obrigatório informar a cidade ou a cidade tem menos de 3 letras. Verifique a documentação."));
            }

            #endregion

            #region obtem a temperatura

            try
            {
                temp = new WebApiClient.OpenWeatherMap().GetTemperatureInCelsiusByCity(cityname);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message));
            }

            #endregion

            #region obtem a categoria de musicas correta

            if (temp > 25.0)
            {
                categ = Enumerators.MusicCategory.Pop;
            }
            else if (temp >= 10.0 && temp <= 25.0)
            {
                categ = Enumerators.MusicCategory.Rock;
            }
            else
            {
                categ = Enumerators.MusicCategory.Classica;
            }

            #endregion

            #region obtem a lista de musicas

            //TODO: IMPLEMENTAR SPOTIFY AQUI
            
            //try
            //{
            //    string strcode = new Utils.SqlServer().GetSpotifyCode();

            //    if (strcode.Length <= 0)
            //    {
            //        new Utils.WebRequest().SpotifyAuth();
            //        strcode = new Utils.SqlServer().GetSpotifyCode();
            //    }


                
            //}
            //catch (Exception ex)
            //{
            //    //throw ex;
            //}
            

            IList<Music> lst = new List<Music>();
            lst.Add(new Music { MusicName = $"Musica {categ.ToString()} 1" });
            lst.Add(new Music { MusicName = $"Musica {categ.ToString()} 2" });
            lst.Add(new Music { MusicName = $"Musica {categ.ToString()} 3" });
            lst.Add(new Music { MusicName = $"Musica {categ.ToString()} 4" });

            #endregion

            info = new TemperatureAndMusicList()
            {
                CityName = cityname,
                MusicList = lst,
                MusicCategory = categ.ToString(),
                Temperature = temp,
            };

            new Utils.SqlServer().SaveLogCity(info);

            return info;
        }
    }
}
