using Interview.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Interview
{
    public static class Tools
    {
        public static List<MainApp> GetMainAppClass()
        {
          
            try
            {
                string json = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/data.json"));
                var app = new JavaScriptSerializer().Deserialize<MainApp[]>(json);
                List<MainApp> items = JsonConvert.DeserializeObject<List<MainApp>>(json);
                return items;
            }
            catch (Exception )
            {

                throw;
            }

        }



        public static  void UpdateFile(List<MainApp> mainApps)
        {
            try
            {
                string json = JsonConvert.SerializeObject(mainApps);
                File.WriteAllText(System.Web.HttpContext.Current.Server.MapPath("~/data.json"), json);
            }
            catch (Exception)
            {

                throw;
            }
           
        }


    }

}