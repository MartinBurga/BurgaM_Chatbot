using BurgaM_Chatbot.Interfaces;
using BurgaM_Chatbot.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();
//El singleTON sirve para que todas las dependencias que vayamos a utilizar solo tengamos que inyectarlas una vez.

builder.Services.AddSingleton<IchatbotServices, geminiRepository>();

//Lo que dice esta ultima linea es que a todos los que usen IchatbotServices se utilice el geminiRepository. Si queremos cambiar de IA solo se redirecciona a otro repositorio

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
