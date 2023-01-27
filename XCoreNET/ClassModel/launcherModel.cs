using System;

namespace XCoreNET.ClassModel
{
    class launcherModel
    {
        public class DownloadListModel
        {
            public string path { get; set; }
            public string sha1 { get; set; }
            public string className { get; set; }
            public int type { get; set; }
            public string name { get; set; }
            public int size { get; set; }

        }
        public class LibrariesModel
        {
            public string dir { get; set; }
            public string version { get; set; }
        }

        public class ConcurrentDownloadListModel
        {
            public string uid { get; set; }
            public string id { get; set; }
            public string url { get; set; }
            public string path { get; set; }
            public int size { get; set; }
            public int totSize { get; set; }
        }

        public class VersionListModel
        {
            public string version { get; set; }
            public string type { get; set; }
            public string url { get; set; }
            public bool isInstalled { get; set; }
            public DateTime datetime { get; set; }
        }
    }
}
