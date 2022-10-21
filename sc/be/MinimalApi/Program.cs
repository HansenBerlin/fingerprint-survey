using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MinimalApi;
using MySql.Data.MySqlClient;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<HttpController>();
builder.Services.AddScoped<GetConnection>(sp => 
    async () => {
        string connectionString = sp.GetService<IConfiguration>()["DevenvConnectionString"];
        var connection = new MySqlConnection(connectionString);
        await connection.OpenAsync();
        return connection;
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.MapGet("/users", async (GetConnection connectionGetter) =>
{
    using var con = await connectionGetter();
    return con.GetAll<UserModel>().ToList();
});



app.MapGet("/usersadvanced", async (HttpController httpController) =>
{
    var users = await httpController.Get();
    List<AdvancedUserModel> adUsers = new();
    for (int i = 2; i < users.Length; i++)
    {
        await Task.Delay(250);
        var adUser = await httpController.Get(users[i]);
        adUsers.Add(adUser);
    }

    return adUsers;
});

app.MapPost("/users", async (GetConnection connectionGetter, UserModel user) =>
{
    using var con = await connectionGetter();
    var id = con.Insert(user);
    return Results.Created($"/todos/{id}", user);
});

app.Run();

[Table("serviceuser")]
public record UserModel(int Id, string UiD, string CommunicationType, string IntensityReal, string IntensityWish, string Control);



public delegate Task<IDbConnection> GetConnection();
