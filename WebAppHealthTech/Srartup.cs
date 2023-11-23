using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerUI;
using WebAppHealthTech.Connections;
using WebAppHealthTech.Repository;

namespace WebAppHealthTech
{
    public class Srartup
    {
        public class Startup
        {
            public IConfiguration Configuration { get; }

            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public void ConfigureServices(IServiceCollection services)
            {
                services.AddCors(options =>
                {
                    options.AddPolicy("AllowSpecificOrigin",
                        builder => builder.WithOrigins("http://localhost:3000")
                                          .AllowAnyHeader()
                                          .AllowAnyMethod()
                                          .AllowCredentials());
                });

                services.AddDbContext<SqlContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("SQLConnectionString"));
                });

                services.AddScoped<AgendaRepository>();
                services.AddScoped<HospitalRepository>();
                services.AddScoped<MedicoRepository>();
                services.AddScoped<PacienteRepository>();
                services.AddScoped<EspecialidadeRepository>();
                services.AddScoped<MedicoEspecRepository>();
                services.AddScoped<HospMedicoRepository>();

                services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                        options.SerializerSettings.Formatting = Formatting.Indented;
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        //options.SerializerSettings.ContractResolver = new IgnoreOccupationsContractResolver();
                    });

                // Configuração do Swagger
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HealthTech API", Version = "v1" });
                });
            }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
                }

                app.UseCors("AllowSpecificOrigin");
                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

                // Configuração do Swagger
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HealthTech API V1");
                    c.RoutePrefix = "swagger";
                    c.DocExpansion(DocExpansion.List);
                    c.EnableValidator(null);
                });
            }
        }
    }
}
