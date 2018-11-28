using System;
using System.Globalization;

namespace Providigm.Sso
{
    public class TokenResponse
    {
        public string TokenResponseVersion { get; set; }

        public StatusCode StatusCode { get; set; }

        public RequestStatusFlag RequestStatusFlag { get; set; }

        public string Token { get; set; }
        public int TokenDurationInSeconds { get; set; }

        public TokenResponse(string response)
        {
            var lines = response.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length < 3)
            {
                throw new Exception("Invalid response");
            }

            TokenResponseVersion = lines[0];
            StatusCode = DetermineStatusCode(lines[1]);
            RequestStatusFlag = DetermineRequestStatusFlag(lines[2]);

            if (lines.Length > 3)
            {
                Token = lines[3];
                TokenDurationInSeconds = int.Parse(lines[4]);
            }
        }

        private RequestStatusFlag DetermineRequestStatusFlag(string requestStatusFlagLine)
        {
            string hex = string.Empty;
            if (requestStatusFlagLine.StartsWith("0x", StringComparison.CurrentCultureIgnoreCase) ||
                requestStatusFlagLine.StartsWith("&H", StringComparison.CurrentCultureIgnoreCase)) 
            {
                // The error codes are returned with the error message appended
                // i.e. 0x07 - Invalid cse type
                // The following removes the hex prefix and the trailing string message so that we just parse "07"
                hex = requestStatusFlagLine.Substring(2,2);
            }

            if (!int.TryParse(hex, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out var value))
            {
                return RequestStatusFlag.Undefined;
            }

            // increment value so it points to the correct enum entry
            value++;

            return (RequestStatusFlag) value;
        }

        /// <summary>
        /// OK, ERROR, NO_AUTH, BAD_IP
        /// </summary>
        private StatusCode DetermineStatusCode(string statusLine)
        {
            switch (statusLine)
            {
                case "OK":
                    return StatusCode.Ok;

                case "ERROR":
                    return StatusCode.Error;

                case "NO_AUTH":
                    return StatusCode.NoAuth;

                case "BAD_IP":
                    return StatusCode.BadIp;

                default:
                    return StatusCode.Undefined;
            }
        }
    }
}
