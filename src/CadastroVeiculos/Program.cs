using CadastroVeiculos.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Inicializa o singleton de conexão
var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new InvalidOperationException("String de conexão 'Default' não encontrada.");
ConexaoFactory.Inicializar(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Veiculos}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();