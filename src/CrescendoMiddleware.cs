using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.Linq;

namespace CrescendoMiddleware;
public static class CommandLineBuilderExtensions
{
    public static void AddCrescendoMiddleware(this CommandLineBuilder commandLineBuilder, Action<CrescendoMiddlwareOptions> configure)
    {
        var options = new CrescendoMiddlwareOptions();
        configure(options);

        commandLineBuilder.AddMiddleware(async (context, next) =>
        {
            if (context.ParseResult.Tokens.Any(m => m.Value.Equals("--crescendo", StringComparison.OrdinalIgnoreCase)))
            {
                var json = JsonGenerator.OutCrescendoJson(options.Mappings.Select(m => JsonGenerator.OutCommand(m)).ToArray());
                File.WriteAllText($"{RootCommand.ExecutableName}.crescendo.json", json);
            }
            else
            {
                await next(context);
            }
        });
    }
}

public class CrescendoMiddlwareOptions
{
    internal List<CommandMapping> Mappings = new();

    public CrescendoMiddlwareOptions AddCmdletMapping(string cmdlet, System.CommandLine.Command command)
    {
        Mappings.Add(new CommandMapping
        {
            Command = command,
            Cmdlet = cmdlet
        });

        return this;
    }
}
