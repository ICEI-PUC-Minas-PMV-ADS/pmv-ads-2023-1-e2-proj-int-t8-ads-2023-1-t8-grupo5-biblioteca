using Biblioteca.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;

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
            IEnumerable<LivroModel> objList = _db.Livros;
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
            _db.Livros.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
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


        //DELETE
        public IActionResult Delete(int id)
        {

            return View();
        }

    }
}
