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
    public class ClientesController : Controller
    {
        private readonly MyDbContext client;

        public ClientesController(MyDbContext context)
        {
            client = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await client.Clientes.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await client.Clientes
                .FirstOrDefaultAsync(m => m.ClientesId == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

   
        public IActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientesId,Nombre,Apellidos,Destino,MetodoDePago,NumeroDeCuenta,confimarVuelo")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                client.Add(clientes);
                await client.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientes);
        }

  
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await client.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }
            return View(clientes);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientesId,Nombre,Apellidos,Destino,MetodoDePago,NumeroDeCuenta,confimarVuelo")] Clientes clientes)
        {
            if (id != clientes.ClientesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    client.Update(clientes);
                    await client.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(clientes.ClientesId))
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
            return View(clientes);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await client.Clientes
                .FirstOrDefaultAsync(m => m.ClientesId == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientes = await client.Clientes.FindAsync(id);
            client.Clientes.Remove(clientes);
            await client.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesExists(int id)
        {
            return client.Clientes.Any(e => e.ClientesId == id);
        }
    }
}
