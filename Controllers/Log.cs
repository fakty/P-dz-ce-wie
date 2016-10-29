using System;
using System.IO;

namespace Pędzące_Żółwie.Controllers
{
    public class Log
    {
        private static Log _instance;
        private readonly string _path;

        private Log()
        {
            _path = Path.Combine(Directory.GetCurrentDirectory(), "log.txt");
        }

        public static Log Instance => _instance ?? (_instance = new Log());

        public void WriteLine(string line = null)
        {
            if (!File.Exists(_path))
            {
                File.Create(_path).Close();

            }
            TextWriter tw = File.AppendText(_path);
            if(line != null) tw.WriteLine(string.Format("{0:G}", DateTime.Now) + ": " + line);
            else tw.WriteLine();
            tw.Close();
        }
    }
}