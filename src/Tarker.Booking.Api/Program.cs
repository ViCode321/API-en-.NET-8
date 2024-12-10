using Azure.Identity;
using Tarker.Booking.Api;
using Tarker.Booking.Application;
using Tarker.Booking.Common;
using Tarker.Booking.External;
using Tarker.Booking.Persistence;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var keyVaultUrl = builder.Configuration["KeyValutUrl"] ?? string.Empty;

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "local")
{
    string tenantId = Environment.GetEnvironmentVariable("tenantId") ?? string.Empty;
    string clientId = Environment.GetEnvironmentVariable("clientId") ?? string.Empty;
    string clientSecret = Environment.GetEnvironmentVariable("clientSecret") ?? string.Empty;

    var tokenCredentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), tokenCredentials);
}
else
{
    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), new DefaultAzureCredential());
}

/* REFERENCIAS DE INYECCIONES DE DEPENDENCIAS */
builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

//SI NO PUEDESA CREAR TU CADENA DE CONECCIÓN EN AZURE NI LAS VARIABLES DE CORREO
//CREA LAS VARIABLES EN SU APPSETINGS.JSON PARA USAR DE MANERA LOCAL TU BD Y SERVICIO DE CORREO

/*var SQLConnectionString = builder.Configuration["SQLConnectionString"];
var SenderEmail = builder.Configuration["SenderEmail"];
var SenderPassword = builder.Configuration["SenderPassword"];*/

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options => {
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
