using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DemoConfiguration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(o => //这个主要是对Krestl或者其它主机信息进行配置， 所有配置都会传递给AppConfiguraiton
                {
                    o.AddEnvironmentVariables();
                    o.AddJsonFile("", true);
                    o.AddCommandLine(args);
                    o.AddInMemoryCollection();
                    //o.AddConfiguration();
                    //o.AddIniFile();
                    //o.AddIniStream();
                    //o.AddJsonStream();
                    //o.AddKeyPerFile();
                    //o.AddUserSecrets();
                    
                    
                })
                .ConfigureAppConfiguration((c,o) => //对应用程序进行配置
                {
                    
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
