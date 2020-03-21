using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AerolineaExpress.Models;

namespace AerolineaExpress.Controllers
{
    public class planificados1Controller : Controller
    {
        private readonly MyDbContext _context;

        public planificados1Controller(MyDbContext context)
        {
            _context = context;
        }

        // GET: planificados1
        public async Task<IActionResult> Index()
        {
            return View(await _context.planificados.ToListAsync());
        }

        // GET: planificados1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planificados = await _context.planificados
                .FirstOrDefaultAsync(m => m.VuelosId == id);
            if (planificados == null)
            {
                return NotFound();
            }

            return View(planificados);
        }

        // GET: planificados1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: planificados1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VuelosId,Destino,Hora_de_salida,Hora_de_llegada,Cantida_de_pasajeros")] planificados planificados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planificados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planificados);
        }

        // GET: planificados1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planificados = await _context.planificados.FindAsync(id);
            if (planificados == null)
            {
                return NotFound();
            }
            return View(planificados);
        }

        // POST: planificados1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VuelosId,Destino,Hora_de_salida,Hora_de_llegada,Cantida_de_pasajeros")] planificados planificados)
        {
            if (id != planificados.VuelosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planificados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!planificadosExists(planificados.VuelosId))
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
            return View(planificados);
        }

        // GET: planificados1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planificados = await _context.planificados
                .FirstOrDefaultAsync(m => m.VuelosId == id);
            if (planificados == null)
            {
                return NotFound();
            }

            return View(planificados);
        }

        // POST: planificados1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planificados = await _context.planificados.FindAsync(id);
            _context.planificados.Remove(planificados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool planificadosExists(int id)
        {
            return _context.planificados.Any(e => e.VuelosId == id);
        }
    }
}
