using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstREST.Controllers
{
    public class RoutesController : Controller
    {
        //
        // GET: /Routes/

        public ActionResult login()
        {
            return View();
        }

        //[Authorize]
        public ActionResult list_orders()
        {
            return View();
        }

        //[Authorize]
        public ActionResult order()
        {
            return View();
        }

    }
}
