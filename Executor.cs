using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Python
{
    public class Executor
    {
        private string python;
        private string app;
        private string args;
        public Executor(string Application_Path,string arguments, string Python_Location = @"C:\Users\Adarsh\AppData\Local\Programs\Python\Python36-32\python.exe")
        {
            python = Python_Location;
            app = Application_Path;
            args = arguments;
        }
        public string Execute()
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo(python);
                processStartInfo.UseShellExecute = false;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.Arguments = app + " " + args;
                Process theProcess = new Process();
                theProcess.StartInfo = processStartInfo;
                theProcess.Start();
                StreamReader s = theProcess.StandardOutput;
                string result = s.ReadLine();
                theProcess.WaitForExit();
                theProcess.Close();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.Message;
            }
        }
    }
}
