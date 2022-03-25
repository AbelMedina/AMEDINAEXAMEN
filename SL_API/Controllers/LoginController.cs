using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_API.Controllers
{
    [RoutePrefix("api")]
    public class LoginController : ApiController
    {
        [Route("Login")]
        [HttpPost]
        public IHttpActionResult Login(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.Login(usuario);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}
