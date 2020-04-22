using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ISM6225_Assignment4.APIHandlerManager;
using ISM6225_Assignment4.Models;
using ISM6225_Assignment4.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ISM6225_Assignment4.Controllers
{
    public class FishingAreasController : Controller
    {

        private readonly ApplicationDbContext _context;

        public FishingAreasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            APIHandler webHandler = new APIHandler();
            FishingAreas fishingAreas = webHandler.GetFishingAreas();

            if (id != null)
            {
                FishingArea selectedFishingArea = fishingAreas.getFishingArea((int) id);
                fishingAreas.data = new List<FishingArea> { selectedFishingArea };
                return View(fishingAreas);
            }
            return View(fishingAreas);
        }
        
        public List<Waterbody> GetChart(string state)

    {

       public IActionResult Chart(string waterbody)

    {

      //The Chart action calls the GetChart method that returns all the waterbodies in a county/town.

      ViewBag.dbSuccessChart = 0;

      List<Waterbody> waterbodies = new List<Waterbody>();

      if (waterbody != null)

      {

        waterbodies = GetChart(waterbody);

      }

      FishingAreasWaterbodies fishingareaswaterbodies = getFishingAreasWaterbodiesModel(waterbodies);

      return View(FishingAreasWaterbodies);

    }  

      // string to specify information to be retrieved from the API

      string FishingAreas_API_PATH = BASE_URL  + town + "/batch?types=chart&range=1y";

      // initialize objects needed to gather data

      string charts = "";

      List<Waterbody> Waterbodies = new List<Waterbody>();

      httpClient.BaseAddress = new Uri(FishingAreas_API_PATH);


      // connect to the API and obtain the response

      HttpResponseMessage response = httpClient.GetAsync(FishingAreas_API_PATH).GetAwaiter().GetResult();

      if (response.IsSuccessStatusCode)

      {

        charts = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

      }


        if (!charts.Equals(""))

      {

        ChartRoot root = JsonConvert.DeserializeObject<ChartRoot>(charts,

          new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        Waterbodies = root.chart.ToList();

      }

    }
      
      public IActionResult Refresh(string tableToDel)

    {

      ClearTables(tableToDel);

      Dictionary<string, int> tableCount = new Dictionary<string, int>();

      tableCount.Add("FishingAreas", dbContext.FishingAreas.Count());

      tableCount.Add("Charts", dbContext.Waterbodies.Count());

      return View(tableCount);

    }

     
        
    }
}
