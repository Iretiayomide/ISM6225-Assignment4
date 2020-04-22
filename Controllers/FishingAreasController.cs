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

         public IActionResult Index(string? county)
        {
            APIHandler webHandler = new APIHandler();
            FishingAreas fishingAreas = webHandler.GetFishingAreas();

            if (string != null)
            {
                FishingArea selectedFishingArea = fishingAreas.getFishingArea((string) county);
                fishingAreas.data = new List<FishingArea> { selectedFishingArea };
                return View(fishingAreas);
            }

            return View(fishingAreas);

        }

        
    }
}
