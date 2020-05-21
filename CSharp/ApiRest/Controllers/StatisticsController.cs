using ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace ApiRest.Controllers
{
    public class StatisticsController : ApiController
    {
        [Route("api/statistics/city/{cityname}")]
        [CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)]
        public TemperatureStatistics Get([FromUri] string cityname)
        {
            TemperatureStatistics info = null;

            string key = (Request.Headers.Contains("Authorization") ? Request.Headers.GetValues("Authorization").FirstOrDefault() : string.Empty);
            if (!key.Equals(Constants.ConstValues.SECURITY_KEY))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Chave inválida."));
            }


            Utils.SqlServer sql = new Utils.SqlServer();
            info = sql.GetStatisticsByCity(cityname);

            if (sql.Error.Length > 0)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, sql.Error));
            
            if (info == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Sem estatísticas para esta cidade."));

            return info;
        }
    }
}
