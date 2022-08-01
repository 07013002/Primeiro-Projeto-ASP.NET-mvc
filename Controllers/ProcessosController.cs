using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcessoSeleticov2.Models;

namespace ProcessoSeleticov2.Controllers
{
    public class ProcessosController : Controller
    {
        private readonly Contexto _context;

        public ProcessosController(Contexto context)
        {
            _context = context;
        }

        // GET: ProcessoModels
        public async Task<IActionResult> Index()
        {
              return _context.Processo != null ? 
                          View(await _context.Processo.ToListAsync()) :
                          Problem("Entity set 'Contexto.Processo'  is null.");
        }

        // GET: ProcessoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Processo == null)
            {
                return NotFound();
            }

            var processoModel = await _context.Processo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processoModel == null)
            {
                return NotFound();
            }

            return View(processoModel);
        }

        // GET: ProcessoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProcessoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeProcesso")] ProcessosModel processoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(processoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(processoModel);
        }

        // GET: ProcessoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Processo == null)
            {
                return NotFound();
            }

            var processoModel = await _context.Processo.FindAsync(id);
            if (processoModel == null)
            {
                return NotFound();
            }
            return View(processoModel);
        }

        // POST: ProcessoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeProcesso")] ProcessosModel processoModel)
        {
            if (id != processoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessoModelExists(processoModel.Id))
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
            return View(processoModel);
        }

        // GET: ProcessoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Processo == null)
            {
                return NotFound();
            }

            var processoModel = await _context.Processo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processoModel == null)
            {
                return NotFound();
            }

            return View(processoModel);
        }

        // POST: ProcessoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Processo == null)
            {
                return Problem("Entity set 'Contexto.Processo'  is null.");
            }
            var processoModel = await _context.Processo.FindAsync(id);
            if (processoModel != null)
            {
                _context.Processo.Remove(processoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessoModelExists(int id)
        {
          return (_context.Processo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
