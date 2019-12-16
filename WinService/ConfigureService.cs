using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace WinService
{
    internal static class ConfigureService
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<MyService>(service =>
              {
                  service.ConstructUsing(s => new MyService());
                  service.WhenStarted(s => s.Start());
                  service.WhenStopped(s => s.Stop());
              });
                //Setup account that windows service use to run
                configure.RunAsLocalSystem();
                configure.SetServiceName("My own windows service");
                configure.SetDisplayName("My own windows service");
                configure.SetDescription("Its a Top shelf standalone c# programmed service");
            });
        }
    }
}
