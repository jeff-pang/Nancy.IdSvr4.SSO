using Serilog;
using SSOServer.Core;
using System;
using System.IO;

namespace SSOServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = AppContext.BaseDirectory;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Logger(lc =>
                    lc.Filter.ByExcluding(evt => evt.Level == Serilog.Events.LogEventLevel.Debug)
                   .WriteTo.LiterateConsole()
                   .WriteTo.RollingFile(Path.Combine(path, "logs", "{Date}.log")))
                .WriteTo.Logger(lc => lc.Filter.ByIncludingOnly(evt => evt.Level == Serilog.Events.LogEventLevel.Debug)
                   .WriteTo.RollingFile(Path.Combine(path, "logs", "{Date}-details.log")))
                .CreateLogger();

            AppMain app = new AppMain();
            app.Start();
        }
    }
}