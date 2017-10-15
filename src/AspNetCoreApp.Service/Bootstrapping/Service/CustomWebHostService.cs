using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetCoreApp.Service.Bootstrapping.Service
{
    internal class CustomWebHostService : WebHostService
    {
        private ILogger _logger;

        public CustomWebHostService(IWebHost host) : base(host)
        {
            this._logger = host.Services.GetRequiredService<ILogger<CustomWebHostService>>();
            AssemblyHelper assemblyHelper = new AssemblyHelper();
            base.ServiceName = assemblyHelper.Title;

        }

        protected override void OnStarting(string[] args)
        {
            this._logger.LogDebug("OnStarting method called.");
            base.OnStarting(args);
        }

        protected override void OnStarted()
        {
            this._logger.LogDebug("OnStarted method called.");
            base.OnStarted();
        }

        protected override void OnStopping()
        {
            this._logger.LogDebug("OnStopping method called.");
            base.OnStopping();
        }
    }
}
