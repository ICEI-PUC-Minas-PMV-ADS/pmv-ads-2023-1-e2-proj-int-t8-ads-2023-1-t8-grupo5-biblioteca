﻿using Biblioteca.Data;
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
    }
}
