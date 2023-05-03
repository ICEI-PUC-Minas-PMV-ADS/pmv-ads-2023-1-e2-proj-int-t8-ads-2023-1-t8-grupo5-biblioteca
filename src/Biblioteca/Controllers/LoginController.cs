using Biblioteca.Models;
using Biblioteca.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if(usuario != null)
                    {
                        if(usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha do usuário invalida, tente novamente!";
                    }

                    TempData["MensagemErro"] = $"Usuario e/ou invalida(s), tente novamente!";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MenssagemErro"] = $"Ops, não conseguimos realizar o Login! detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
