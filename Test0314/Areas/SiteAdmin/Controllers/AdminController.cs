using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test0314.Areas.SiteAdmin.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: SiteAdmin/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}