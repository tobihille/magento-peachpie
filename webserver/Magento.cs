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
            var root = Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()) + "/website";
        
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseWebRoot(root).UseContentRoot(root) // content root with wp static files
                .UseUrls("http://*:5004/")
                .UseStartup<Startup>() // initialization routine, see below
                .Build();
        
            host.Run();
        }
    }
    
    class Startup {
        public void Configure(IApplicationBuilder app) {
            Pchp.Core.Context.DefaultErrorHandler = new Pchp.Core.CustomErrorHandler(); // disables debug asserts
    
            // enable session:
            app.UseSession();

            app.UsePhp(); // installs handler for *.php files and forwards them to our website.dll

            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}