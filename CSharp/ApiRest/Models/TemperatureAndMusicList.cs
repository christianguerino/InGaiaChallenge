using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ApiRest.Models
{
    public class TemperatureAndMusicList
    {
        #region construtor(es)
        
        public TemperatureAndMusicList()
        {
            this.CityName = string.Empty;
            this.Temperature = 0.0;
            this.MusicCategory = string.Empty;
        }

        #endregion

        #region propriedades publicas

        public string CityName { get; set; }
        public double Temperature { get; set; }
        public string MusicCategory { get; set; }
        public IList<Music> MusicList { get; set; }
        
        #endregion
    }
}
