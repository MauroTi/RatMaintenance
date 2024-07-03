using Microsoft.AspNetCore.Mvc;
using RatMaintenance.Data;
using RatMaintenance.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RatMaintenance.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var equipments = _context.Equipments.ToList();
            return View(equipments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipment);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = _context.Equipments.Find(id);
            if (equipment == null)
            {
                return NotFound();
            }
            return View(equipment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Equipment equipment)
        {
            if (id != equipment.EquipmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipment);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = _context.Equipments.Find(id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipment = _context.Equipments.Find(id);
            _context.Equipments.Remove(equipment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = _context.Equipments.FirstOrDefault(m => m.EquipmentId == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }
    }
}
