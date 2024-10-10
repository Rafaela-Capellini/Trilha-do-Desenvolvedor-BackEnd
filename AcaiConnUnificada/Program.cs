using AcaiConnUnificada.Data;
using AcaiConnUnificada.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/**** Configurando e registrando a conexão com o banco de dados ***/

// Obtendo a string de conexão que está no appsettings.json
string stringDeConexao = builder.Configuration.GetConnectionString("ConexaoSqlServer");

// Registrando a classe de conexão com o banco de dados
builder.Services.AddSingleton<IConexaoSql>(new ConexaoSql(stringDeConexao));
builder.Services.AddScoped<IProdutosDB, ProdutosDB>();
/******************************************************************/

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
