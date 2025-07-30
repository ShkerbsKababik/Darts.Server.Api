using Darts.Server.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Darts.Server.Api.Tests.Intergation;

public class DartsServerApiApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remove all DbContext-related registrations
            var descriptors = services.Where(
                d => d.ServiceType.Name.Contains("DbContext")).ToList();

            foreach (var descriptor in descriptors)
            {
                services.Remove(descriptor);
            }

            // Add in-memory database
            services.AddDbContext<DartsDbContext>(options =>
                options.UseInMemoryDatabase("TestDb"));
        });
    }
}
