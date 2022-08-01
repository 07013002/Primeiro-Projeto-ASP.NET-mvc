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
    public class DocumentosController : Controller
    {
        private readonly Contexto _context;

        public DocumentosController(Contexto context)
        {
            _context = context;
        }

        // GET: Documentos
        public async Task<IActionResult> Index()
        {
              return _context.Documento != null ? 
                          View(await _context.Documento.ToListAsync()) :
                          Problem("Entity set 'Contexto.Documento'  is null.");
        }

        // GET: Documentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Documento == null)
            {
                return NotFound();
            }

            var documentosModel = await _context.Documento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentosModel == null)
            {
                return NotFound();
            }

            return View(documentosModel);
        }

        // GET: Documentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Documentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Titulo,Processo,Categoria")] DocumentosModel documentosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(documentosModel);
        }

        // GET: Documentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Documento == null)
            {
                return NotFound();
            }

            var documentosModel = await _context.Documento.FindAsync(id);
            if (documentosModel == null)
            {
                return NotFound();
            }
            return View(documentosModel);
        }

        // POST: Documentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Titulo,Processo,Categoria")] DocumentosModel documentosModel)
        {
            if (id != documentosModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentosModelExists(documentosModel.Id))
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
            return View(documentosModel);
        }

        // GET: Documentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Documento == null)
            {
                return NotFound();
            }

            var documentosModel = await _context.Documento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentosModel == null)
            {
                return NotFound();
            }

            return View(documentosModel);
        }

        // POST: Documentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Documento == null)
            {
                return Problem("Entity set 'Contexto.Documento'  is null.");
            }
            var documentosModel = await _context.Documento.FindAsync(id);
            if (documentosModel != null)
            {
                _context.Documento.Remove(documentosModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentosModelExists(int id)
        {
          return (_context.Documento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
