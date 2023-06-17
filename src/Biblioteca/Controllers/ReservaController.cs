using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;
using Biblioteca.Data;

namespace Biblioteca.Controllers
{
    public class ReservaController : Controller
    {

        private readonly BancoContext _db;

        public ReservaController(BancoContext db)
        {
            _db = db;
        }


        public IActionResult ConfirmarReserva(int? id)
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarReserva(LivroModel obj)
        {

            if (ModelState.IsValid)
            {
                
                //criar a reserva aqui
                
                //_db.Livros.Update(obj);
                //_db.SaveChanges();
                return RedirectToAction("Index", "Livro");
            }
            return View(obj);


        }


    }
}
