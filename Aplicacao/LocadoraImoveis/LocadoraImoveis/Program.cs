using APIServices;
using LocadoraImoveisModels.Models.DataBase;
using LocadoraImoveisModels.Models.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
{
  x.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});






builder.Services.AddDbContext<LocacaoimoveisContext>(x =>
{
  x.UseMySql("server=localhost;port=3306;database=locacaoimoveis;uid=admin;password=@Esperto12;", new MySqlServerVersion(new Version(8, 2, 0)));
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  options.TokenValidationParameters = new TokenValidationParameters()
  {
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateIssuerSigningKey = true,
    ValidateLifetime = false,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwt.SECURITY_KEY))
  }
  );

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
