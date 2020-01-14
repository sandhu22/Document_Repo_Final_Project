using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Document_Repo_Final_Project.Models;
using Microsoft.AspNetCore.Authorization;

namespace Document_Repo_Final_Project.Controllers
{
    [Authorize(Roles="repo_admin")]
    public class DocumentLogsController : Controller
    {
        private readonly Document_Repo_DataContext _context;

        public DocumentLogsController(Document_Repo_DataContext context)
        {
            _context = context;
        }

        // GET: DocumentLogs
        public async Task<IActionResult> Index()
        {
            var document_Repo_DataContext = _context.DocumentLog.Include(d => d.Document).Include(d => d.Document.Publisher);
            return View(await document_Repo_DataContext.ToListAsync());
        }

        // GET: DocumentLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentLog = await _context.DocumentLog
                .Include(d => d.Document)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentLog == null)
            {
                return NotFound();
            }

            return View(documentLog);
        }

        // GET: DocumentLogs/Create
        public IActionResult Create()
        {
            ViewData["DocumentId"] = new SelectList(_context.Document, "Id", "Id");
            return View();
        }

        // POST: DocumentLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DocumentId,Time,Operation")] DocumentLog documentLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocumentId"] = new SelectList(_context.Document, "Id", "Id", documentLog.DocumentId);
            return View(documentLog);
        }

        // GET: DocumentLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentLog = await _context.DocumentLog.FindAsync(id);
            if (documentLog == null)
            {
                return NotFound();
            }
            ViewData["DocumentId"] = new SelectList(_context.Document, "Id", "Id", documentLog.DocumentId);
            return View(documentLog);
        }

        // POST: DocumentLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DocumentId,Time,Operation")] DocumentLog documentLog)
        {
            if (id != documentLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentLogExists(documentLog.Id))
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
            ViewData["DocumentId"] = new SelectList(_context.Document, "Id", "Id", documentLog.DocumentId);
            return View(documentLog);
        }

        // GET: DocumentLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentLog = await _context.DocumentLog
                .Include(d => d.Document)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentLog == null)
            {
                return NotFound();
            }

            return View(documentLog);
        }

        // POST: DocumentLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documentLog = await _context.DocumentLog.FindAsync(id);
            _context.DocumentLog.Remove(documentLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentLogExists(int id)
        {
            return _context.DocumentLog.Any(e => e.Id == id);
        }
    }
}
