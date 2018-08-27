using System;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using Providigm.Sso;

namespace YourWebForm
{
    public partial class _Default : Page
    {

        public string Token;
        public string SessionEnd = "http://www.yahoo.com";

        protected async void Page_Load(object sender, EventArgs e)
        {
            var ssoClient = new SsoClient();
            var tokenResponse = await ssoClient.RequestTokenAsync("goodsam11", "5473d95926b2d0e00730786a");
            if (tokenResponse.StatusCode.ToString() == "Ok")
            {
                Token = tokenResponse.Token;
            }
            else
            {
                Message.InnerHtml += "</br>";
                Message.InnerHtml += tokenResponse.TokenResponseVersion + "</br>";
                Message.InnerHtml += tokenResponse.StatusCode.ToString() + "</br>";
                Message.InnerHtml += tokenResponse.RequestStatusFlag.ToString() + "</br>";
                Message.InnerHtml += tokenResponse.Token + "</br>";
                Message.InnerHtml += tokenResponse.TokenDurationInSeconds.ToString() + "</br>";
            }

        }
    }
}