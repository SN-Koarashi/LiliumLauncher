using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace XCoreNET.Tasks
{
    class launcherTask
    {
        public class LauncherProfilesModel
        {
            public Dictionary<string, LauncherProfilesModelChild> profiles { get; set; }
        }
        public class LauncherProfilesModelChild
        {
            public string created { get; set; }
            public string icon { get; set; }
            public string lastUsed { get; set; }
            public string lastVersionId { get; set; }
            public string name { get; set; }
            public string type { get; set; }
        }
        public async Task downloadResource(string url, string filepath)
        {
            try
            {
                WebClient client = new WebClient();
                var bytes = await client.DownloadDataTaskAsync(new Uri(url));
                File.WriteAllBytes(filepath, bytes);

                client.Dispose();
            }
            catch (Exception exx)
            {
                Console.WriteLine(exx.Message);
            }
        }

        public async Task<JObject> getJavaRuntime()
        {
            var client = new HttpClient();
            var body = await client.GetStringAsync("https://launchermeta.mojang.com/v1/products/java-runtime/2ec0cc96c44e5a76b9c8b7c39df7210883d12871/all.json");

            Console.WriteLine($"getJavaRuntime: {body}");
            return JsonConvert.DeserializeObject<JObject>(body);
        }
        public async Task<JObject> getJavaDownloadObject(string url)
        {
            var client = new HttpClient();
            var body = await client.GetStringAsync(url);

            Console.WriteLine($"getJavaDownloadObject: {body}");
            return JsonConvert.DeserializeObject<JObject>(body);
        }

        public async Task<JObject> getAllVersion()
        {
            var client = new HttpClient();
            var body = await client.GetStringAsync("https://launchermeta.mojang.com/mc/game/version_manifest_v2.json");

            //Console.WriteLine($"getAllVersion: {body}");
            Console.WriteLine($"getAllVersion");
            return JsonConvert.DeserializeObject<JObject>(body);
        }
        public async Task<JObject> createIndexes(string url)
        {
            var client = new HttpClient();
            var body = await client.GetStringAsync(url);

            Console.WriteLine($"createIndexes: {body}");
            return JsonConvert.DeserializeObject<JObject>(body);
        }
    }
}
