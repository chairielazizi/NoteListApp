using Microsoft.AspNetCore.Mvc;
using NoteListApp.Data;
using NoteListApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteListApp.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NoteController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Note> noteList = _db.Note;
            return View(noteList);
        }

        //GET-create
        public IActionResult Create()
        { 
            return View();
        }

        //POST-create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Note notes)
        {
            // server side validation
            if (ModelState.IsValid)
            {
                _db.Note.Add(notes);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notes);
            
        }

        //GET-update
        public IActionResult Update(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var note = _db.Note.Find(id);
            if(note == null)
            {
                return NotFound();
            }
            return View(note);
        }

        //POST-update
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(Note notes)
        {
            // server side validation
            if (ModelState.IsValid)
            {
                _db.Note.Update(notes);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notes);

        }

        //GET-delete
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var note = _db.Note.Find(id);
            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }

        //POST-delete
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Deleted(int id)
        {
            var notes = _db.Note.Find(id);
            if(notes == null)
            {
                return NotFound();
            }
            _db.Note.Remove(notes);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}