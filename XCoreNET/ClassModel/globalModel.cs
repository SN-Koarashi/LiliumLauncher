using System.Collections.Generic;

namespace XCoreNET.ClassModel
{
    class globalModel
    {
        public class startupParmsModel
        {
            public string main { get; set; }
            public string username { get; set; }
            public string uuid { get; set; }
            public string accessToken { get; set; }
            public string version { get; set; }
            public string assetIndex { get; set; }
            public string loggerIndex { get; set; }
            public string javaRuntime { get; set; }
            public string minecraftArguments { get; set; }
            public string appUID { get; set; }
        }

        public class AccountModel
        {
            public string username { get; set; }
            public string refreshToken { get; set; }
            public string accessToken { get; set; }
            public string lastUsed { get; set; }
            public long expiresAt { get; set; }
        }

        public class SessionModel
        {
            public Dictionary<string, object> launcher { get; set; }
            public Dictionary<string, object> minecraft { get; set; }
            public Dictionary<string, object> versionOptions { get; set; }
            public Dictionary<string, AccountModel> account { get; set; }
            public List<string> instance { get; set; }
            public string lastInstance { get; set; }
            public string refreshToken { get; set; }
            public string mainFolder { get; set; }
            public string lastVersionID { get; set; }
            public string windowSize { get; set; }
            public int runInterval { get; set; }
            public bool isConcurrent { get; set; }

        }
        public class ProgramModel
        {
            public bool noWevView { get; set; }
            public bool launcher { get; set; }
            public string mainURL { get; set; }
            public string launcherURL { get; set; }
        }
    }
}
