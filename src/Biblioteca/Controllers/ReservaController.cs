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

        public IActionResult ConfirmarReserva2(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var livro = _db.Livros.Find(id);

            if (livro == null)
            {
                return NotFound();
            }

            ReservaModel r1 = new();

            r1.Data = DateTime.Today;
            r1.LivroId = livro.Id;
            r1.Livro = livro;
            r1.Devolvido = false;

            _db.Reservas.Add(r1);
            _db.SaveChanges();

            return RedirectToAction("Index", "Livro");


        }


    }
}
