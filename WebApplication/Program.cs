using Application.Applcation;
using Application.Interface;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceService;
using Domain.Services;
using Infra.Config;
using Infra.Repository;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
