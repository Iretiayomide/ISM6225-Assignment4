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

        

        // GET: FishingAreas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FishingAreas/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,WaterBody,Town,County,Owner,Manager,AccessType,BoatSize,RampType,UniversalAccess")] FishingArea fishingArea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fishingArea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fishingArea);
        }

        // GET: FishingAreas/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var FishingAreas = await _context.FishingAreas.FindAsync(id);
            if (FishingAreas == null)
            {
                return NotFound();
            }
            return View(FishingAreas);
        }

        // POST: FishingAreas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,WaterBody,Town,County,Owner,Manager,AccessType,BoatSize,RampType,UniversalAccess")] FishingArea fishingArea)
        {
            if (id != fishingArea.attributes.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fishingArea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishingAreaExists(fishingArea.attributes.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fishingArea);
        }

        // GET: FishingAreas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var FishingAreas = await _context.FishingAreas
                .FirstOrDefaultAsync(m => m.attributes.id == id);
            if (FishingAreas == null)
            {
                return NotFound();
            }

            return View(FishingAreas);
        }

        private bool FishingAreaExists(int id)
        {
            return _context.FishingAreas.Any(e => e.attributes.id == id);
        }
    }
}