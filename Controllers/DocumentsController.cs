using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Document_Repo_Final_Project.Models;

using Microsoft.AspNetCore.Identity;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Document_Repo_Final_Project.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly Document_Repo_DataContext _context;

        private SignInManager<IdentityUser> SignInManager;

        public DocumentsController(Document_Repo_DataContext context,

            SignInManager<IdentityUser> SignInManager
            )
        {

            this.SignInManager = SignInManager;
            _context = context;
        }

        // GET: Documents

        [Authorize(Roles = "repo_admin, publisher")]
        public async Task<IActionResult> Index()
        {
            var document_Repo_DataContext = _context.Document.Include(d => d.Publisher);

            if (User.IsInRole("publisher")) {

                var document_Repo_DataContextPub = _context.Document.
                    Include(d => d.Publisher)
                    .Where(d=>d.Publisher.Email.Equals(User.Identity.Name));
                return View(await document_Repo_DataContextPub.ToListAsync());

            }
            
            return View(await document_Repo_DataContext.ToListAsync());
        }

        // GET: Documents/Details/5
        [Authorize(Roles = "repo_admin, publisher")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Document
                .Include(d => d.Publisher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // GET: Documents/Create
        [Authorize(Roles = "publisher")]
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "publisher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DocumentName,File")] Document document)
        {
            if (ModelState.IsValid)
            {
                UploadDocument(document);

                document.Modified = DateTime.Now;

                var publisher = (from pub in _context.Publisher
                                 where User.Identity.Name.Equals(pub.Email)
                                 select pub).FirstOrDefault();

                document.PublisherId = publisher.Id;
               

                _context.Add(document);

               
                await _context.SaveChangesAsync();

                DocumentLog log = new DocumentLog();
                log.DocumentId = document.Id;
                log.Operation = Operation.CREATED;
                log.Time = DateTime.Now;
                _context.Add(log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PublisherId"] = new SelectList(_context.Set<Publisher>(), "Id", "Id", document.PublisherId);
            return View(document);
        }

        // GET: Documents/Edit/5
        [Authorize(Roles = "publisher")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Document.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            ViewData["PublisherId"] = new SelectList(_context.Set<Publisher>(), "Id", "Id", document.PublisherId);
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "publisher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DocumentName,DocumentUrl,File")] Document document)
        {
            if (id != document.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var publisher = (from pub in _context.Publisher
                                     where User.Identity.Name.Equals(pub.Email)
                                     select pub).FirstOrDefault();

                    document.PublisherId = publisher.Id;

                    document.Modified = DateTime.Now;
                    _context.Update(document);

                    DocumentLog log = new DocumentLog();
                    log.DocumentId = document.Id;
                    log.Operation = Operation.UPDATED;
                    log.Time = DateTime.Now;
                    _context.Add(log);
                    await _context.SaveChangesAsync();
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(document.Id))
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
            ViewData["PublisherId"] = new SelectList(_context.Set<Publisher>(), "Id", "Id", document.PublisherId);
            return View(document);
        }

        // GET: Documents/Delete/5

        [Authorize(Roles = "repo_admin, publisher")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Document
                .Include(d => d.Publisher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [Authorize(Roles = "repo_admin, publisher")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var document = await _context.Document.FindAsync(id);
            _context.Document.Remove(document);

            DocumentLog log = new DocumentLog();
            log.DocumentId = document.Id;
            log.Operation = Operation.DELETED;
            log.Time = DateTime.Now;
            _context.Add(log);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentExists(int id)
        {
            return _context.Document.Any(e => e.Id == id);
        }



        private void UploadDocument(Document Document)
        {

            if (Document.File != null)
            {
                Document.DocumentUrl = Document.File.FileName;

                var filePath = "./wwwroot/docs/" + Document.File.FileName;


                if (Document.File.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Document.File.CopyTo(stream);
                    }
                }
            }


        }

    }
}
