using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsConsumoWepApi.Models
{
    public class TemperatureAndMusicList
    {
        #region construtor(es)
        
        public TemperatureAndMusicList()
        {
            this.cityName = string.Empty;
            this.temperature = 0.0;
            this.musicCategory = string.Empty;
        }

        #endregion

        #region propriedades publicas

        public string cityName { get; set; }
        public double temperature { get; set; }
        public string musicCategory { get; set; }
        public IList<Music> musicList { get; set; }
        
        #endregion
    }

    public class Music
    {
        public string musicName { get; set; }
    }

    public class ErrorApiMessage
    {
        public string message { get; set; }
    }
}
