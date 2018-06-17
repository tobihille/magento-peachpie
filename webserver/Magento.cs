using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Peachpie.Web;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Configuration; 

namespace peachserver
{
    class Magento {
        static void Main() {
            try {
                var root = Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()) + 
                    "/" + 
                    ConfigurationManager.AppSettings["webserverDir"] + 
                    "/website";
  
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseWebRoot(root)
                    //content root with static files
                    .UseContentRoot(root) 
                    .UseUrls("http://*:5004/")
                    //initialization routine, see below
                    .UseStartup<Startup>() 
                    .Build();
            
                host.Run();
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

            app.UsePhp( new PhpRequestOptions() { ScriptAssembliesName = new[] { "magento" } } ); // installs handler for *.php files and forwards them to our website.dll

            //app.UseDefaultFiles();
            //app.UseStaticFiles();
        }
    }
}