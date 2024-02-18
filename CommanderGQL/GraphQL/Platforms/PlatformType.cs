using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL.Platforms;

public class PlatformType : ObjectType<Platform>
{
    protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
    {
        descriptor.Description("Represents any kind of software or services that has a command line interface (CLI).");

        descriptor.Field(p => p.LicenseKey).Ignore();

        descriptor
        .Field(p => p.Commands)
        .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
        .UseDbContext<AppDbContext>()
        .Description("List of available commands for this platform.");
    }

    private class Resolvers
    {
        public IQueryable<Command> GetCommands([Parent] Platform platform, [ScopedService] AppDbContext context)
        {
            System.Console.WriteLine($"--> Platform ID: {platform.Id}");
            return context.Commands.Where(p => p.PlatformId == platform.Id);
        }
    }
}