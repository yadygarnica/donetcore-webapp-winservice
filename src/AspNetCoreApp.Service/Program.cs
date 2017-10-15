using System.Diagnostics;
using System.IO;
using System.Linq;
using AspNetCoreApp.Service.Bootstrapping;
using AspNetCoreApp.Service.Bootstrapping.Installers;
using AspNetCoreApp.Service.Bootstrapping.Service;
using Microsoft.AspNetCore.Hosting;

namespace AspNetCoreApp.Service
{
    public class Program
    {
        static string _consoleComand = "--console";
        static string _installComand = "--install";
        static string _uninstallComand = "--uninstall";
        public static void Main(string[] args)
        {
            if (args.Contains(_installComand))
            {
                ProgramInstaller.Install();
            }
            else if (args.Contains(_uninstallComand))
            {
                ProgramInstaller.Uninstall();
            }
            else
            {
                Start(args);
            }
        }

        private static void Start(string[] args)
        {
            bool isService = true;

            if (Debugger.IsAttached || args.Contains(_consoleComand))
            {
                isService = false;
            }

            var pathToContentRoot = Directory.GetCurrentDirectory();

            if (isService)
            {
                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                pathToContentRoot = Path.GetDirectoryName(pathToExe);
            }

            var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(pathToContentRoot)
            .UseIISIntegration()
            .UseStartup<Startup>()
            .Build();

            if (isService)
            {
                host.RunAsCustomService();
            }
            else
            {
                host.Run();
            }
        }
    }
}
