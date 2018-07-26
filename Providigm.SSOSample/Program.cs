using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Providigm.Sso;

namespace Providigm.SSOSample
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var ssoClient = new SsoClient();
            var tokenResponse = await ssoClient.RequestTokenAsync("goodsam11", "5473d95926b2d0e00730786a");
            Console.WriteLine(tokenResponse.TokenResponseVersion);
            Console.WriteLine(tokenResponse.StatusCode);
            Console.WriteLine(tokenResponse.RequestStatusFlag);
            Console.WriteLine(tokenResponse.Token);
            Console.WriteLine(tokenResponse.TokenDurationInSeconds);

            await ssoClient.AbaqisLoginAsync(tokenResponse.Token, "http://www.yahoo.com");
        }
    }
}
