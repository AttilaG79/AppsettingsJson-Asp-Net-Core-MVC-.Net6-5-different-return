using AppsettingsJson.Servicves;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
// 1 step configure 
builder.Services.Configure<DataModelService>(builder.Configuration.GetSection(DataModelService.AdminInfo));

builder.Services.AddControllersWithViews();
// 2 step add Options
builder.Services.AddOptions(); //Options pattern

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
