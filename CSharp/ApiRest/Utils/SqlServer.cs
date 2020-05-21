using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.Remoting.Messaging;

namespace ApiRest.Utils
{
    public class SqlServer
    {
        #region propriedades publicas

        public string Error { get; set; }

        #endregion

        #region propriedades privadas

        private string ConnString { get; set; }
        private int TimeOut { get; set; }

        #endregion

        #region construtor(es)

        public SqlServer()
        {
            this.Error = string.Empty;
            this.ConnString = Utils.Conversion.ToString(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        }

        public SqlServer(string connstr)
        {
            this.Error = string.Empty;
            this.ConnString = connstr;
        }

        public SqlServer(string connstr, int timout)
        {
            this.Error = string.Empty;
            this.ConnString = connstr;
            this.TimeOut = timout;
        }

        #endregion

        public bool SaveSpotifyCode(string code)
        {
            bool ret = false;
            this.Error = string.Empty;

            try
            {
                string strcmd = @"  IF EXISTS (SELECT USERNAME FROM SPOTIFY WHERE USERNAME=@_username)
                                    BEGIN
                                        UPDATE  SPOTIFY SET CODE    = @_code
                                                          , DTACESS = GETDATE()
                                        WHERE USERNAME=@_username
                                    END
                                    ELSE
                                    BEGIN
                                        INSERT INTO SPOTIFY (USERNAME, CODE, DTACESS)
                                        VALUES (@_username, @_code, GETDATE())
                                    END
                                ";

                using (SqlConnection sqlcon = new SqlConnection(this.ConnString))
                {
                    sqlcon.Open();
                    if (sqlcon.State == ConnectionState.Open)
                    {
                        using (SqlCommand sqlcmd = new SqlCommand(strcmd, sqlcon))
                        {
                            sqlcmd.Parameters.AddWithValue("_username", Constants.ConstValues.SPOTIFY_USERNAME);
                            sqlcmd.Parameters.AddWithValue("_code", code);
                            sqlcmd.ExecuteNonQuery();
                        }
                    }
                    sqlcon.Close();
                }

                ret = true;
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;
            }

            return ret;
        }

        public string GetSpotifyCode()
        {
            string ret = string.Empty;
            this.Error = string.Empty;

            try
            {
                string strcmd = @"  SELECT CODE FROM SPOTIFY WITH(NOLOCK) WHERE USERNAME=@_username ";

                using (SqlConnection sqlcon = new SqlConnection(this.ConnString))
                {
                    sqlcon.Open();
                    if (sqlcon.State == ConnectionState.Open)
                    {
                        using (SqlCommand sqlcmd = new SqlCommand(strcmd, sqlcon))
                        {
                            sqlcmd.Parameters.AddWithValue("_username", Constants.ConstValues.SPOTIFY_USERNAME);

                            SqlDataReader reader = sqlcmd.ExecuteReader();
                            while (reader.Read())
                            {
                                ret = Utils.Conversion.ToString(reader["CODE"]);
                            }
                            reader.Close();
                        }
                    }
                    sqlcon.Close();
                }
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;
            }

            return ret;
        }

        public bool SaveLogCity(Models.TemperatureAndMusicList info)
        {
            bool ret = false;
            this.Error = string.Empty;

            try
            {
                string strcmd = @"  INSERT INTO LOGCITY (DTREAD, CITY, TEMP)
                                    VALUES (GETDATE(), @_city, @_temp )
                                ";

                using (SqlConnection sqlcon = new SqlConnection(this.ConnString))
                {
                    sqlcon.Open();
                    if (sqlcon.State == ConnectionState.Open)
                    {
                        using (SqlCommand sqlcmd = new SqlCommand(strcmd, sqlcon))
                        {
                            sqlcmd.Parameters.AddWithValue("_city", info.CityName.ToUpper().Trim());
                            sqlcmd.Parameters.AddWithValue("_temp", info.Temperature);
                            sqlcmd.ExecuteNonQuery();
                        }
                    }
                    sqlcon.Close();
                }

                ret = true;
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;
            }

            return ret;
        }

        public Models.TemperatureStatistics GetStatisticsByCity(string city)
        {
            Models.TemperatureStatistics info = null;
            this.Error = string.Empty;

            try
            {
                string strcmd = @"  SELECT  CAST(MIN(DTREAD) as DATE) as FIRSTDATE
                                           ,CAST(MAX(DTREAD) as DATE) as LASTDATE
                                           ,MIN(TEMP) MINTEMP
                                           ,MAX(TEMP) MAXTEMP   
                                           ,AVG(TEMP) AVGTEMP
                                           ,COUNT(ID) TOTAL
                                    FROM LOGCITY WITH(NOLOCK) 
                                    WHERE CITY=@_city ";

                using (SqlConnection sqlcon = new SqlConnection(this.ConnString))
                {
                    sqlcon.Open();
                    if (sqlcon.State == ConnectionState.Open)
                    {
                        using (SqlCommand sqlcmd = new SqlCommand(strcmd, sqlcon))
                        {
                            sqlcmd.Parameters.AddWithValue("_city", city.Trim().ToUpper());

                            SqlDataReader reader = sqlcmd.ExecuteReader();

                            while (reader.Read())
                            {
                                info = new Models.TemperatureStatistics()
                                {
                                    CityName = city.ToUpper().Trim(),
                                    AvgTemp = Conversion.ToDouble(reader["AVGTEMP"]),
                                    MaxTemp = Conversion.ToDouble(reader["MAXTEMP"]),
                                    MinTemp = Conversion.ToDouble(reader["MINTEMP"]),
                                    FirstDate = Conversion.ToDate(reader["FIRSTDATE"]),
                                    LastDate = Conversion.ToDate(reader["LASTDATE"]),
                                    Total = Conversion.ToDouble(reader["TOTAL"]),
                                };
                            }
                            reader.Close();
                        }
                    }
                    sqlcon.Close();
                }
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;
            }

            return info;
        }

    }
}