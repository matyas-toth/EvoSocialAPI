using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.DependencyInjection;

namespace EvoSocialAPI
{


    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificIP",
                    builder =>
                    {
                        builder.WithOrigins("redacted")
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            // Other ConfigureServices configuration...
        }
    }
}
