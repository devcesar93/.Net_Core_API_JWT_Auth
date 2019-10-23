using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contatos_NetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contatos_NetCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Acesso")]
    public class AcessoController : Controller
    {
        private readonly AcessoDBContext _context;

        //Injeção de dependência
        public AcessoController(AcessoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Acesso acesso)
        {
            string token = new TokenController(_context).CreateToken(acesso);

            if (token == "") ViewData["Token"] = "Login e/ou Senha inválidos!";
            else ViewData["Token"] = token;

            return View("LoginToken");
        }
    }
}