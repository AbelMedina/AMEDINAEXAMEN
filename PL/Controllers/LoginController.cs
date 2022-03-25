using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PL.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Login(ML.Usuario usuario)
        //{
        //    ML.Usuario ValidarUsuario = new ML.Usuario();
        //    if (ModelState.IsValid)
        //    {
        //        ML.Result result = BL.Usuario.Login(usuario);
        //        if (result.Correct)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            return PartialView("Modal");
        //        }
        //    }
        //    return View(ValidarUsuario);
        //}

        //[HttpPost]
        //public ActionResult Login(ML.Usuario usuario) 
        //{
        //    ML.Usuario ValidarUsuario = new ML.Usuario();
        //    if (ModelState.IsValid)
        //    {
        //        LoginService.LoginClient servicioLogin = new LoginService.LoginClient();
        //        var result = servicioLogin.DoLogin(usuario);
        //        if (result.Correct)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            return PartialView("Modal");
        //        }
        //    }
        //    return View(ValidarUsuario);
        //}

        [HttpPost]
        public ActionResult Login(ML.Usuario usuario)
        {
            string UrlAPI = ConfigurationManager.AppSettings["WebAPI"].ToString();
            ML.Usuario ValidarUsuario = new ML.Usuario();
            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(UrlAPI);
                    var postTask = client.PostAsJsonAsync<ML.Usuario>("api/Login", usuario);
                    postTask.Wait();
                    var resultPost = postTask.Result;
                    if (resultPost.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Mensaje = "Credenciales incorrectas :" + resultPost.StatusCode;
                        return PartialView("Modal");
                    }
                }
            }
            return View(ValidarUsuario);
        }
    }
}