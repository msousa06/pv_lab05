using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab05.Models;

namespace lab05.Controllers
{
    public class CarroesController : Controller
    {
        private readonly TopCarContext _context;

        public CarroesController(TopCarContext context)
        {
            _context = context;
        }

        // GET: Carroes
        public async Task<IActionResult> Index(String id)
        {
            var carros = from m in _context.Carros
                          select m;

            if (!String.IsNullOrEmpty(id))
            {
                carros = carros.Where(s => s.Modelo == id);
            }
            return View(await carros.ToListAsync());

        }

        // GET: Carroes/Details/5
        [ActionName("Detalhes")]public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros
                .Include(c => c.Marca)
                .SingleOrDefaultAsync(m => m.CarroId == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View("Details",carro);
        }

        // GET: Carroes/Create
        [ActionName("Criar")]public IActionResult Create()
        {
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "MarcaId", "MarcaId");
            return View("Create");
        }

        // POST: Carroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Criar")]
        public async Task<IActionResult> Create([Bind("CarroId,Modelo,NumeroDePassageiros,NumeroDePortas,EmissoesCO2,TipoCaixa,MarcaId")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "MarcaId", "MarcaId", carro.MarcaId);
            return View("Create",carro);
        }

        // GET: Carroes/Edit/5
        [ActionName("Editar")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros.SingleOrDefaultAsync(m => m.CarroId == id);
            if (carro == null)
            {
                return NotFound();
            }
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "MarcaId", "MarcaId", carro.MarcaId);
            return View("Edit",carro);
        }

        // POST: Carroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ActionName("Editar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarroId,Modelo,NumeroDePassageiros,NumeroDePortas,EmissoesCO2,TipoCaixa,MarcaId")] Carro carro)
        {
            if (id != carro.CarroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carro.CarroId))
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
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "MarcaId", "MarcaId", carro.MarcaId);
            return View("Edit",carro);
        }

        // GET: Carroes/Delete/5
        [ActionName("Apagar")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carros
                .Include(c => c.Marca)
                .SingleOrDefaultAsync(m => m.CarroId == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View("Delete",carro);
        }

        // POST: Carroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carro = await _context.Carros.SingleOrDefaultAsync(m => m.CarroId == id);
            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(int id)
        {
            return _context.Carros.Any(e => e.CarroId == id);
        }
    }
}
