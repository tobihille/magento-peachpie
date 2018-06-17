using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Peachpie.Web;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace peachserver
{
    class Magento {
        static void Main() {
            try {
                //var root = Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()) + "/website";
                var root = "C:/Users/tobih/Documents/webroot/hackathon_m1/website/";
            
                var host = new WebHostBuilder()
                    .UseKestrel()
                    //.UseWebRoot(root)
                    //content root with static files
                    //.UseContentRoot(root) 
                    .UseUrls("http://*:5004/")
                    //initialization routine, see below
                    .UseStartup<Startup>() 
                    .Build();
            
                host.Run();
            } catch (ex) {
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