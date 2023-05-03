using Biblioteca.Models;
using Biblioteca.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Controllers
{
    public class usuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public usuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            

            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = _usuarioRepositorio.Adicionar(usuario);

                    TempData["MenssagemSucesso"] = "Usuário cadastrado com Sucesso";
                    return RedirectToAction("Index", "Login");
                }

                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MenssagemErro"] = $"Ops, não conseguimos cadastrar seu usuario. detalhe erro: {erro.Message}";
                return RedirectToAction("index");
            }
        }

        
    }
}
