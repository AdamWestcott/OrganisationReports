namespace CSharp.Net5.BlazorIntegrationDemo
{
    using Business.Repository.IRepository;
    using Business.Repository;
    using DataAccess.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Microsoft.Extensions.Hosting;
    using System;
    using Telerik.Reporting.Cache.File;
    using Telerik.Reporting.Services;
    using Telerik.WebReportDesigner.Services;
    using AutoMapper;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddRazorPages()
                .AddNewtonsoftJson();
            services.AddServerSideBlazor();
            

            // Configure dependencies for ReportsController.
            services.TryAddSingleton<IReportServiceConfiguration>(sp =>
                new ReportServiceConfiguration
                {
                    ReportingEngineConfiguration = sp.GetService<IConfiguration>(),
                    HostAppId = "Net5BlazorDemo",
                    Storage = new FileStorage(),
                    ReportSourceResolver = new CustomReportSourceResolver()
                });
            services.AddControllers().AddNewtonsoftJson();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(p =>
                {
                    p.AllowAnyOrigin();
                    p.AllowAnyMethod();
                    p.AllowAnyHeader();
                });
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ICarbonDbItemsRepository, CarbonDBItemsRepository>();
            services.AddScoped<IOrganisationRepository, OrganisationRepository>();
            services.AddScoped<IProjectsRepository, ProjectsRepository>();
            services.AddScoped<ISocialRepository, SocialRepository>();
            services.AddSingleton<CustomReportSourceResolver>();
            services.AddSingleton<StoredItems>();

            // Configure dependencies for ReportDesignerController.
            services.TryAddSingleton<IReportDesignerServiceConfiguration>(sp => new ReportDesignerServiceConfiguration
            {
                DefinitionStorage = new FileDefinitionStorage(
                    System.IO.Path.Combine(sp.GetService<IWebHostEnvironment>().ContentRootPath, "Reports")),
                SettingsStorage = new FileSettingsStorage(
                    System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Test")),
                ResourceStorage = new ResourceStorage(
                    System.IO.Path.Combine(sp.GetService<IWebHostEnvironment>().ContentRootPath, "Reports"))
            });

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite("Data Source = CarbonReductionExample.db");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

        }

        /// <summary>
        /// Loads a reporting configuration from a specific JSON-based configuration file.
        /// </summary>
        /// <param name="environment">The current web hosting environment used to obtain the content root path</param>
        /// <returns>IConfiguration instance used to initialize the Reporting engine</returns>
        static IConfiguration ResolveSpecificReportingConfiguration(IWebHostEnvironment environment)
        {
            // If a specific configuration needs to be passed to the reporting engine, add it through a new IConfiguration instance.
            var reportingConfigFileName = System.IO.Path.Combine(environment.ContentRootPath, "reportingAppSettings.json");
            return new ConfigurationBuilder()
                .AddJsonFile(reportingConfigFileName, true)
                .Build();
        }
    }
}
