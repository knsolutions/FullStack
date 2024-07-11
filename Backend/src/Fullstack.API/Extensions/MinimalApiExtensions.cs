using Fullstack.Application.Abstractions;
using Fullstack.Application.Posts.Commands;
using Fullstack.Infrastructure.Data;
using Fullstack.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fullstack.Api.Extensions;

public static class MinimalApiExtensions
{
    public static void RegisterServices (this WebApplicationBuilder builder)
    {
        /*
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
        */

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        /*
        builder.Services.AddDbContext<SocialDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        */

        builder.Services.AddDbContext<SocialDbContext>(options =>  
            options.UseInMemoryDatabase("InMemoryDb"));

        builder.Services.AddScoped<IPostRepository, PostRepository>();
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreatePost>());
    }

}
