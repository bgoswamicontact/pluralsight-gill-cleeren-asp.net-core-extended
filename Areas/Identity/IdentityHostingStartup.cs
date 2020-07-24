using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(BethenysPieShop.Areas.Identity.IdentityHostingStartup))]
namespace BethenysPieShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            
         });
        }
    }
}