using System;
using System.IO;
using AxLink.Service;
using FlutterApp.Server.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace FlutterApp.Server.Host;

public class Startup
{
    public IConfiguration Configuration { get; }
    
    private readonly ILoggerFactory _loggerFactory;
    
    
    public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
    {
        Configuration = configuration;
        _loggerFactory = loggerFactory;
    }
    

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        Type typeOfContent = typeof(Startup);
        services.AddDbContext<PostgreSqlContext>(
            opt => opt.UseNpgsql(
                Configuration.GetConnectionString("PostgreSqlConnection"),
                b => b.MigrationsAssembly(typeOfContent.Assembly.GetName().Name)
            )
        );

        var firebaseConfig = Configuration.GetSection("Firebase").Get<Configs.Firebase>();

        var firebaseService = new FirebaseService
        (
            _loggerFactory.CreateLogger<FirebaseService>(),
            Directory.GetCurrentDirectory() + firebaseConfig?.AdminConfigPath
        );

        services.AddScoped<IDatabaseContainer, DatabaseContainer>();

        services.AddControllers();
        services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "FlutterApp.Host", Version = "v1"}); });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FlutterApp.Host v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}