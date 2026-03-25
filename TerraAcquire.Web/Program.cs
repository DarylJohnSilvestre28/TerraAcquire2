using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using TerraAcquire.EntityFramework;
using TerraAcquire.Contracts.ModelHouses;
using TerraAcquire.Services;
using TerraAcquire.Services.ModelHouses;
using TerraAcquire.Contracts.Trippings;
using AutoMapper; // ✅ Add this

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:5132");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 0, 29))
    )
);

builder.Services.AddRazorPages();

// Existing services
builder.Services.AddScoped<IModelHouseService, ModelHouseService>();

// ✅ Add TrippingService
builder.Services.AddScoped<ITrippingService, TrippingService>();

// ✅ Add AutoMapper (register all profiles in the assembly)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".glb"] = "model/gltf-binary";

app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});

app.UseRouting();
app.MapRazorPages();
app.Run();