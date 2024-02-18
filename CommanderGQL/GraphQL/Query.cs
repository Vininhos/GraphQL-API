using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL;

public class Query
{
    [UseDbContext(typeof(AppDbContext))]
    public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
    {
        var value = context.Platforms;
        return value;
    }

    [UseDbContext(typeof(AppDbContext))]
    public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
    {
        var value = context.Commands;
        return value;
    }
}