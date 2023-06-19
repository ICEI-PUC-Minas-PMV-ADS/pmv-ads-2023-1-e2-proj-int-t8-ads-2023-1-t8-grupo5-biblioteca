using Biblioteca.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    public class LivroController : Controller
    {

        private readonly BancoContext _db;

        public LivroController(BancoContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            //IEnumerable<LivroModel> objList = _db.Livros;

            var objList = _db.Livros
                .Include(Livro => Livro.Reservas);

            return View(objList);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LivroModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Livros.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET - UPDATE
        public IActionResult Update(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Livros.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


        // POST - UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(LivroModel obj)
        { 
                        
            if (ModelState.IsValid)
            {
                _db.Livros.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
            

        }


        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Livros.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


        // POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLivro(int? id)
        {

            var obj = _db.Livros.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Livros.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
