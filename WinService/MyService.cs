using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WinService
{
    class MyService
    {
        public void Start()
        {
            string path = @"C:\IDG";
            MonitorDirectory(path);
            //Console.ReadKey();
        }
        public void Stop()
        {

        }
        private static void MonitorDirectory(string path)
        {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
            fileSystemWatcher.Path = path;

            fileSystemWatcher.Created += FileSystemWatcher_Created;
            fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;
            fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
            fileSystemWatcher.EnableRaisingEvents = true;
        }
        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            //Console.WriteLine("File created: {0}", e.FullPath);
            File.WriteAllText(@"C:\" + "Text" + string.Format("{0:yyyy_MM_dd_HHmm}", DateTime.Now) + ".txt", "File Created: "+ e.Name.ToString());
        }

        private static void FileSystemWatcher_Renamed(object sender, FileSystemEventArgs e)
        {
            //Console.WriteLine("File renamed: {0}", e.Name);
            File.WriteAllText(@"C:\" + "Text" + string.Format("{0:yyyy_MM_dd_HHmm}", DateTime.Now) + ".txt", e.Name.ToString());
        }

        private static void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            //Console.WriteLine("File deleted: {0}", e.Name);
            File.WriteAllText(@"C:\" + "Text" + string.Format("{0:yyyy_MM_dd_HHmm}", DateTime.Now) + ".txt", e.Name.ToString());
        }
    }
}
