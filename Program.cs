using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);
var bindAzureAdSettings = new SwaggerAzureAdSettings();
builder.Configuration.Bind("SwaggerAzureAd", bindAzureAdSettings);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

SwaggerConfig.SwaggerConfigurations(builder.Services, builder.Configuration, bindAzureAdSettings);

var app = builder.Build();

SwaggerConfig.SwaggerUIConfiguration(app, builder.Configuration);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
