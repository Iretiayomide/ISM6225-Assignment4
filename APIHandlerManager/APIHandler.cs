using ISM6225_Assignment4.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ISM6225_Assignment4.APIHandlerManager
{
    public class APIHandler
    {
        

        static string BASE_URL = "https://anrmaps.vermont.gov/arcgis/rest/services/Open_Data/OPENDATA_ANR_TOURISM_SP_NOCACHE_v2/MapServer/163";
        static string API_KEY = "ssc24WIqELuiGDWTHrzOHPQfJT6XGvatpN06NddJ"; 

        HttpClient httpClient;

        
        public APIHandler()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


        public FishingAreas GetFishingAreas()
        {
            string API_PATH = BASE_URL + "/query?where=1%3D1&outFields=id,WaterBody,Town,County,Owner,Manager,AccessType,BoatSize,RampType,UniversalAccess&outSR=4326&f=json";
            string fishingData = "";

            FishingAreas fishingAreas = new FishingAreas();

            httpClient.BaseAddress = new Uri(API_PATH);


            try
            {
                HttpResponseMessage response = httpClient.GetAsync(API_PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    fishingData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!fishingData.Equals(""))
                {

                    JObject jObject = JObject.Parse(fishingData);

                    fishingAreas.data = JsonConvert.DeserializeObject<List<FishingArea>>(jObject["features"].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return fishingAreas;
        }
        public void addFishingArea(FishingArea fishingArea)
        {



        }
    }
}
