using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Peachpie.AspNetCore.Web;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Configuration; 

namespace peachserver
{
    class Magento {
        static void Main() {
            try {
                var root = "";
                var configuredDir = ConfigurationManager.AppSettings["webserverDir"];
                if (configuredDir.Contains(":")) //absolute, e.g. C: in path
                {
                    root = configuredDir;
                }
                else //relative
                {
                    root = Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()) +
                    "/" + configuredDir;
                }
  
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseWebRoot(root)
                    //content root with static files
                    .UseContentRoot(root) 
                    .UseUrls("http://*:" + ConfigurationManager.AppSettings["port"] + "/")
                    //initialization routine, see below
                    .UseStartup<Startup>() 
                    .Build();
                host.Run();
            } catch (Pchp.Core.ScriptDiedException ex) {
                Console.WriteLine(ex.ToString());
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            } 
        }
    }
    
    class Startup {
        public void Configure(IApplicationBuilder app) {
            Pchp.Core.Context.DefaultErrorHandler = new Pchp.Core.CustomErrorHandler(); // disables debug asserts
    
            // enable session:
            //app.UseSession();

            app.UsePhp( new PhpRequestOptions() {ScriptAssembliesName = new[] {"magento"}}); // installs handler for *.php files and forwards them to website.dll
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}