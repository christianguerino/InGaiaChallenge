using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;

namespace ApiRest.Utils
{
    public class WebRequest
    {
        public void SpotifyAuth()
        {
            var uri = $"https://accounts.spotify.com/authorize?client_id={Constants.ConstValues.SPOTIFY_CLIENT_ID}&response_type=code&redirect_uri=https://ingaiachallenge.azurewebsites.net/api/Spotify/99?key={Constants.ConstValues.SECURITY_KEY}&scope=user-read-private%20user-read-email&state=34fFs29kd08";
            //var translationWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
            //var response = translationWebRequest.GetResponse();
            //System.IO.Stream stream = response.GetResponseStream();
            //Encoding encode = Encoding.GetEncoding("utf-8");
            //System.IO.StreamReader translatedStream = new System.IO.StreamReader(stream, encode);

            //var resp = translatedStream.ReadToEnd();
            //
            //           var strspotityuri = response.ResponseUri.AbsoluteUri;
            //         var translationWebRequest2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(strspotityuri);
            //       var response2 = translationWebRequest.GetResponse();

        }
    }
}