using CadastroVeiculos.Models;

var veiculo = new Veiculo
{
    Placa = "ABC1D23",
    Marca = "Volvo",
    Modelo = "FH 540",
    Cor = "Branco",
    Ano = 2022,
    Porte = "Grande",
    TipoCarga = "Granel",
    Chassis = "9BWZZZ377VT004251"
};

Console.WriteLine($"Placa: {veiculo.Placa} | Marca: {veiculo.Marca} | Modelo: {veiculo.Modelo} | Cor: {veiculo.Cor} | Ano: {veiculo.Ano} | Porte: {veiculo.Porte} | Tipo de carga: {veiculo.TipoCarga} | Chassi: {veiculo.Chassis}");


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
