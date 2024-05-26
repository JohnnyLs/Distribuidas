using SoapCore;
using SoapService.Models;
using SoapService.Services;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddSingleton(new MySQLDB(connectionString));
builder.Services.AddSingleton<CustomerServiceContract>(new CustomerService(connectionString));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSoapEndpoint<CustomerServiceContract>("/CustomerService.asmx",new SoapEncoderOptions());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
