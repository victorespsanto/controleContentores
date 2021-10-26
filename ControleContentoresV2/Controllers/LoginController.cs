using ControleContentoresV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleContentoresV2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (Session["Erro"] != null)
                ViewBag.Erro = Session["Erro"].ToString();
            return View();
        }

        [HttpPost]
        public void ChecarLogin()
        {

            var usuario = new usuario();
            usuario.chaveUsuario = Request["chaveUsuario"];
            usuario.senhaUsuario = Request["Password"];

            if (usuario.Login())
            {
                Session["Autorizado"] = "OK";
                Session["Nome"] = usuario.IdentificarNome();
                Session["PerfilUsuario"] = usuario.IdentificarPerfil();
                Session.Remove("Erro");
                Response.Redirect("../telaInicial");
            }
            else
            {
                Session["Erro"] = "Senha ou usuários inválidos";
                Response.Redirect("/Login");
            }
        }

    }
}