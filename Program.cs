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
                .ConfigureHostConfiguration(o => //�����Ҫ�Ƕ�Krestl��������������Ϣ�������ã� �������ö��ᴫ�ݸ�AppConfiguraiton
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
                .ConfigureAppConfiguration((c,o) => //��Ӧ�ó����������
                {
                    
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
