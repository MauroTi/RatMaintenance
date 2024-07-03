using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RatMaintenance.Data;
using RatMaintenance.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RatMaintenance.Controllers
{
    public class RATController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RATController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var rats = _context.RATs
                .Include(r => r.User)
                .Include(r => r.Equipment)
                .ToList();
            return View(rats);
        }

        public IActionResult Create()
        {
            ViewData["Users"] = new SelectList(_context.Users, "UserId", "Name");
            ViewData["Equipments"] = new SelectList(_context.Equipments, "EquipmentId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RAT rat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Users"] = new SelectList(_context.Users, "UserId", "Name", rat.UserId);
            ViewData["Equipments"] = new SelectList(_context.Equipments, "EquipmentId", "Name", rat.EquipmentId);
            return View(rat);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rat = _context.RATs.Find(id);
            if (rat == null)
            {
                return NotFound();
            }
            ViewData["Users"] = new SelectList(_context.Users, "UserId", "Name", rat.UserId);
            ViewData["Equipments"] = new SelectList(_context.Equipments, "EquipmentId", "Name", rat.EquipmentId);
            return View(rat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RAT rat)
        {
            if (id != rat.RATId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(rat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Users"] = new SelectList(_context.Users, "UserId", "Name", rat.UserId);
            ViewData["Equipments"] = new SelectList(_context.Equipments, "EquipmentId", "Name", rat.EquipmentId);
            return View(rat);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rat = _context.RATs
                .Include(r => r.User)
                .Include(r => r.Equipment)
                .FirstOrDefault(m => m.RATId == id);
            if (rat == null)
            {
                return NotFound();
            }

            return View(rat);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rat = _context.RATs.Find(id);
            _context.RATs.Remove(rat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rat = _context.RATs
                .Include(r => r.User)
                .Include(r => r.Equipment)
                .FirstOrDefault(m => m.RATId == id);
            if (rat == null)
            {
                return NotFound();
            }

            return View(rat);
        }
    }
}
