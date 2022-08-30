using Datalayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
/*
    first and formost, this project is my website first, then a pokemon-eque garage meet clone second
    the point of making a garagemeet clone is so that i have an excuse to reuse pokemon autochess
    but for my website, it should display all the work i have done. this is mostly going to go in the front end then?
*/

// used for cors
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options=>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    policy =>
    {
        policy.WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WebSiteDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyWebSiteDevBuild")));
builder.Services.AddScoped<DBInterface, DatabaseCalls>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
