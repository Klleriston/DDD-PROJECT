using Application.Applcation;
using Application.Interface;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceService;
using Domain.Services;
using Infra.Config;
using Infra.Repository;
using Infra.Repository.Generics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication.Token;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ContextDb>
//    (o => o.UseNpgsql(builder.Configuration
//     .GetConnectionString("connection")));

builder.Services.AddDefaultIdentity<ApplicationUser>
    (o => o.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ContextDb>();

builder.Services.AddSingleton(
    typeof(IGenerics<>), 
    typeof(RepositoryGeneric<>));
builder.Services.AddSingleton<INews, RepositoryNews>();
builder.Services.AddSingleton<IUser, RepositoryUser>();

builder.Services.AddSingleton<IServiceNews, ServiceNews>();

builder.Services.AddSingleton<IUserApplication, ApplicationUser>();
builder.Services.AddSingleton<INewsApplication, ApplicationNews>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(option =>
       {
           option.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = false,
               ValidateAudience = false,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,

               ValidIssuer = "DDD.Securiry.Bearer",
               ValidAudience = "DDD.Securiry.Bearer",
               IssuerSigningKey = JWTSecurity.Create("Secret_Key-12345678")
           };

           option.Events = new JwtBearerEvents
           {
               OnAuthenticationFailed = context =>
               {
                   Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                   return Task.CompletedTask;
               },
               OnTokenValidated = context =>
               {
                   Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                   return Task.CompletedTask;
               }
           };
       });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
