using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using AutoMapper;
using JPW.Models;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.



builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// builder.Services.AddSwaggerGen(options => { options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme { Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")", In = ParameterLocation.Header, Name = "Authorization", Type = SecuritySchemeType.ApiKey }); options.OperationFilter<SecurityRequirementsOperationFilter>(); });

// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => { options.TokenValidationParameters = new TokenValidationParameters { ValidateIssuerSigningKey = true, IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)), ValidateIssuer = false, ValidateAudience = false }; });





builder.Services.AddDbContext<JPWContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("MyDBConnection")));

builder.Services.AddAutoMapper(typeof(JPWContext));


//builder.Services.AddTransient<IAdmin, AdminRepo>();
//builder.Services.AddTransient<AdminService, AdminService>();




var app = builder.Build();



// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())

{

    app.UseSwagger();

    app.UseSwaggerUI();

}

app.UseStaticFiles();

app.UseRouting();





//app.UseCors(MyAllowSpecificOrigins);



app.UseHttpsRedirection();

app.UseCors(builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
app.UseAuthentication();



app.UseAuthentication();

app.UseAuthorization();



app.MapControllers();



app.Run();