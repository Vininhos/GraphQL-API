using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var _configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(_configuration.GetConnectionString("CommandConStr")));
builder.Services.AddGraphQLServer().AddQueryType<Query>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
  endpoints.MapGraphQL();
});

app.Run();
