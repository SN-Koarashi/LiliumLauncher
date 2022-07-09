using Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XCoreNET.Tasks
{
    class authificationTask
    {
        public class XUIModel
        {
            public List<Dictionary<string, string>> xui { get; set; }
        }
        public async Task<Dictionary<string, object>> Code2Token(string code)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "client_id", gb.azureClientID },
                { "code", code },
                { "grant_type", "authorization_code" },
                { "redirect_uri", "http://localhost:5026" }
            };

            var data = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://login.live.com/oauth20_token.srf", data);
            var body = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Code2Token: {body}");
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(body);
        }

        public async Task<Dictionary<string, object>> refreshToken(string token)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "client_id", gb.azureClientID },
                { "refresh_token", token },
                { "grant_type", "refresh_token" },
                { "redirect_uri", "http://localhost:5026" }
            };

            var data = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://login.live.com/oauth20_token.srf", data);
            var body = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"refreshToken: {body}");
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(body);
        }
        public async Task<Dictionary<string, object>> getXBLToken(string access_token)
        {
            var client = new HttpClient();

            var tokenParams = new
            {
                RelyingParty = "http://auth.xboxlive.com",
                TokenType = "JWT",
                Properties = new
                {
                    AuthMethod = "RPS",
                    SiteName = "user.auth.xboxlive.com",
                    RpsTicket = $"d={access_token}"
                }
            };

            var postData = JsonConvert.SerializeObject(tokenParams);

            var content = new StringContent(postData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://user.auth.xboxlive.com/user/authenticate", content);
            var body = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"getXBLToken: {body}");
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(body);
        }

        public async Task<Dictionary<string, object>> getXSTSToken(string XBLToken)
        {
            var client = new HttpClient();

            var tokenParams = new
            {
                RelyingParty = "rp://api.minecraftservices.com/",
                TokenType = "JWT",
                Properties = new
                {
                    SandboxId = "RETAIL",
                    UserTokens = new string[] { XBLToken }
                }
            };

            var postData = JsonConvert.SerializeObject(tokenParams);

            var content = new StringContent(postData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://xsts.auth.xboxlive.com/xsts/authorize", content);
            var body = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"getXSTSToken: {body}");
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(body);
        }

        public async Task<Dictionary<string, object>> getMinecraftAuth(string XSTSToken, string UserHash)
        {
            var client = new HttpClient();

            var tokenParams = new
            {
                identityToken = $"XBL3.0 x={UserHash};{XSTSToken}"
            };

            var postData = JsonConvert.SerializeObject(tokenParams);

            var content = new StringContent(postData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://api.minecraftservices.com/authentication/login_with_xbox", content);
            var body = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"getMinecraftAuth: {body}");
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(body);
        }

        public async Task<Dictionary<string, object>> checkGameOwnership(string accessToken, string type)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"{type} {accessToken}");
            var body = await client.GetStringAsync("https://api.minecraftservices.com/entitlements/mcstore");

            Console.WriteLine($"checkGameOwnership: {body}");
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(body);
        }

        public async Task<Dictionary<string, object>> getMinecraftProfile(string accessToken, string type)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"{type} {accessToken}");
            var body = await client.GetStringAsync("https://api.minecraftservices.com/minecraft/profile");

            Console.WriteLine($"getMinecraftProfile: {body}");
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(body);
        }
    }
}
