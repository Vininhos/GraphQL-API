using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var _configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(_configuration.GetConnectionString("CommandConStr")));
builder.Services.AddGraphQLServer().AddQueryType<Query>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();
