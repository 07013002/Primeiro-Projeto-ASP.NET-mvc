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
    public class ArquivoController : Controller
    {
        private readonly Contexto _context;

        public ArquivoController(Contexto context)
        {
            _context = context;
        }/*
        public IActionResult Index()
        {
            var arquivos = _context.Arquivos.ToList();
            return View(arquivos);
        }*/

        [HttpPost]
        public IActionResult UploadArquivo(IList<IFormFile> arquivos)
        {
            IFormFile imagemCarregada = arquivos.FirstOrDefault();

            if (imagemCarregada != null)
            {
                MemoryStream ms = new MemoryStream();
                imagemCarregada.OpenReadStream().CopyTo(ms);

                ArquivoModel arqui = new ArquivoModel()
                {
                    Descricao = imagemCarregada.FileName,
                    Dados = ms.ToArray(),
                    ContentType = imagemCarregada.ContentType
                };

                _context.ArquivoModel.Add(arqui);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Visualizar(int id)
        {
            var arquivosBanco = _context.ArquivoModel.FirstOrDefault(a => a.Id == id);

            return File(arquivosBanco.Dados, arquivosBanco.ContentType);
        }

        // GET: Arquivo
        public async Task<IActionResult> Index()
        {
              return _context.ArquivoModel != null ? 
                          View(await _context.ArquivoModel.ToListAsync()) :
                          Problem("Entity set 'Contexto.ArquivoModel'  is null.");
        }

        // GET: Arquivo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ArquivoModel == null)
            {
                return NotFound();
            }

            var arquivoModel = await _context.ArquivoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arquivoModel == null)
            {
                return NotFound();
            }

            return View(arquivoModel);
        }

        // GET: Arquivo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Arquivo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Dados,ContentType")] ArquivoModel arquivoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arquivoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arquivoModel);
        }

        // GET: Arquivo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ArquivoModel == null)
            {
                return NotFound();
            }

            var arquivoModel = await _context.ArquivoModel.FindAsync(id);
            if (arquivoModel == null)
            {
                return NotFound();
            }
            return View(arquivoModel);
        }

        // POST: Arquivo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Dados,ContentType")] ArquivoModel arquivoModel)
        {
            if (id != arquivoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arquivoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArquivoModelExists(arquivoModel.Id))
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
            return View(arquivoModel);
        }

        // GET: Arquivo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ArquivoModel == null)
            {
                return NotFound();
            }

            var arquivoModel = await _context.ArquivoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arquivoModel == null)
            {
                return NotFound();
            }

            return View(arquivoModel);
        }

        // POST: Arquivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ArquivoModel == null)
            {
                return Problem("Entity set 'Contexto.ArquivoModel'  is null.");
            }
            var arquivoModel = await _context.ArquivoModel.FindAsync(id);
            if (arquivoModel != null)
            {
                _context.ArquivoModel.Remove(arquivoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArquivoModelExists(int id)
        {
          return (_context.ArquivoModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
