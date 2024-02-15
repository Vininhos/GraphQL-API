using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server.Ui.Voyager;

var builder = WebApplication.CreateBuilder(args);

var _configuration = builder.Configuration;

builder.Services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer(_configuration.GetConnectionString("CommandConStr")));

if (builder.Environment.IsDevelopment())
  builder.Services.AddGraphQLServer().AddQueryType<Query>().ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);
else
  builder.Services.AddGraphQLServer().AddQueryType<Query>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
  endpoints.MapGraphQL();
});

app.UseGraphQLVoyager("/graphql-voyager", new VoyagerOptions()
{
  GraphQLEndPoint = "/graphql"
});

app.Run();
