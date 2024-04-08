using CebuCityFamilyAPI.Context;
using CebuCityFamilyAPI.Repositories;
using CebuCityFamilyAPI.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Add header documentation in swagger 
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Cebu City Barangay API",
        Description = "Barangay API for Cebu City",
        Contact = new OpenApiContact
        {
            Name = "Group 8-WelovesirAmbrad",
            Url = new Uri("https://github.com/CITUCCS/csit327-project-group-8-welovesirambrad")
        },
    }); ;
    // Feed generated xml api docs to swagger
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    // Transcient
    services.AddTransient<DapperContext>();
    // Services
    services.AddScoped<IBarangayService, BarangayService>();
    services.AddScoped<IFamilyMembersService, FamilyMembersService>();
    services.AddScoped<IDetailsService, DetailsService>();
    services.AddScoped<IFamilyService, FamilyService>();
    services.AddScoped<IRegistrationService, RegistrationService>();
    // Repository
    services.AddScoped<IBarangayRepository, BarangayRepository>();
    services.AddScoped<IDetailsRepository, DetailsRepository>();
    services.AddScoped<IFamilyRepository, FamilyRepository>();
    services.AddScoped<IFamilyMembersRepository, FamilyMembersRepository>();
}
