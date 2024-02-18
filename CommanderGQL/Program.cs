using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server.Ui.Voyager;
using CommanderGQL.GraphQL.Platforms;
using CommanderGQL.GraphQL.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CommandConStr")));

builder.Services
.AddGraphQLServer()
.AddQueryType<Query>()
.AddType<PlatformType>()
.AddType<CommandType>()
.AddFiltering()
.AddSorting()
.ModifyRequestOptions(opt => opt.IncludeExceptionDetails = builder.Environment.IsDevelopment());

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
