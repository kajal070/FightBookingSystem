using FlightBookingSystemFolder.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using FlightBookingSystemFolder.Repository;
using AutoMapper;
using FlightBookingSystemFolder.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped<IRepositoryWrapper,RepositoryWrapper>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<flightContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FlightConnection"));
}
);
builder.Services.AddScoped<ITokenHandler, FlightBookingSystemFolder.Repository.TokenHandler>();
builder.Services.AddAutoMapper(typeof(AutomapperProfiles).Assembly);
builder.Services.AddTransient(typeof(IRepositoryBase<>),typeof(RepositoryBase<>));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(Options =>
Options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey= true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience=builder.Configuration["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
    )
});
builder.Services.AddCors();//(options =>
/*{
    options.AddPolicy("EnableCORS", builder => 
    { 
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod(); 
    });
});*/


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder=>builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
