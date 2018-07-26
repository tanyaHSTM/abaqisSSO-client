using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Providigm.Sso;

namespace YourWebGateway.Controllers
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

        public async Task<ActionResult> LoginToAbaqis()
        {
            var ssoClient = new SsoClient();
            var tokenResponse = await ssoClient.RequestTokenAsync("goodsam11", "5473d95926b2d0e00730786a");
            var response = await ssoClient.AbaqisLoginPostAsync(tokenResponse.Token, "http://www.yahoo.com");

            var cookieToSet = response.Headers.GetValues("Set-Cookie").FirstOrDefault();
            if (cookieToSet != null)
            {
                var cookies = cookieToSet.Split(';');
                foreach (var cookie in cookies)
                {
                    var cookiePair = cookie.Split('=');
                    Response.Cookies.Add(new HttpCookie(cookiePair[0], cookiePair.Length == 2 ? cookiePair[1] : string.Empty));

                }
            }

            return new RedirectResult(response.Headers.Location.ToString());
        }
    }
}