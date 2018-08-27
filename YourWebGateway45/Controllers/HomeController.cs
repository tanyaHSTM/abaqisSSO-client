using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Providigm.Sso;

namespace YourWebGateway45.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var ssoClient = new SsoClient();
            var tokenResponse = await ssoClient.RequestTokenAsync("goodsam11", "5473d95926b2d0e00730786a");

            return View(tokenResponse);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}