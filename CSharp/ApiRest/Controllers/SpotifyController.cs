using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;

namespace ApiRest.Controllers
{
    public class SpotifyController : ApiController
    {
        /// <summary>
        /// Metodo para que a api do spotyfy devolva o token e na sequencia ele eh salvo em banco
        /// </summary>
        /// <param name="id"></param>
        /// <param name="key"></param>
        /// <param name="code"></param>
        public void Get(int id, [QueryString] string key, [QueryString] string code)
        {
            if (!key.Equals(Constants.ConstValues.SECURITY_KEY))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Chave inválida."));
            }
            
            if (id == 99) //valor configurado na plataforma o SPOTIFY
            {
                Utils.SqlServer sql = new Utils.SqlServer();
                if (!sql.SaveSpotifyCode(code))
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, sql.Error));
            }
            else
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Id Inválido."));
            }
        }
    }
}
