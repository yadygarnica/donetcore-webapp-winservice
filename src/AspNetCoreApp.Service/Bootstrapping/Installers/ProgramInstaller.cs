using System;
using System.Diagnostics;

namespace AspNetCoreApp.Service.Bootstrapping.Installers
{
    /// <summary>
    /// Installer for the program.
    /// </summary>
    public class ProgramInstaller
    {
        public static void Install()
        {
            AssemblyHelper assemblyHelper = new AssemblyHelper();

            string pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            string serviceName = assemblyHelper.Title;
            
            string createService = $"/C sc create {serviceName} binPath=\"{pathToExe}\"";
            bool created = StartProcess(createService);

            bool started = false;

            if (created)
            {
                string startService = $"/C sc start {serviceName}";
                started = StartProcess(startService);
            }

            if (!created || !started)
            {
                Console.WriteLine($"Error installing the service: Service created: {created}. Service started: {started}.");
                Console.WriteLine("Press any key to continue.");
                Console.Read();
            }
            else
            {
                Console.WriteLine("Service installed successfuly.");
                Console.WriteLine("Press any key to continue.");
                Console.Read();
            }
        }

        public static void Uninstall()
        {
            AssemblyHelper assemblyHelper = new AssemblyHelper();
           
            string serviceName = assemblyHelper.Title;

            string stopService = $"/C sc stop {serviceName}";
            bool stoped = StartProcess(stopService);

            bool deleted = false;

            if (stoped)
            {
                string deleteService = $"/C sc delete {serviceName}";
                deleted = StartProcess(deleteService);
            }

            if (!stoped || !deleted)
            {
                Console.WriteLine($"Error uninstalling the service: Service stop: {stoped}. Service deleted: {deleted}.");
                Console.WriteLine("Press any key to continue.");
                Console.Read();
            }
            else
            {
                Console.WriteLine("Service uninstalled successfuly.");
                Console.WriteLine("Press any key to continue.");
                Console.Read();
            }
        }
        
        private static bool StartProcess(string arg)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Verb = "runas";
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = arg;
            process.StartInfo = startInfo;

            return process.Start();
        }
    }
}
