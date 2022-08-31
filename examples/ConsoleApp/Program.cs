using CrescendoMiddleware;
using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var delayOption = new Option<int>("--delay");
        var messageOption = new Option<string>("--message");

        var rootCommand = new RootCommand("Middleware example");
        rootCommand.Add(delayOption);
        rootCommand.Add(messageOption);

        rootCommand.SetHandler((delayOptionValue, messageOptionValue) =>
        {
            DoRootCommand(delayOptionValue, messageOptionValue);
        },
            delayOption, messageOption);

        var commandLineBuilder = new CommandLineBuilder(rootCommand);

        commandLineBuilder.AddCrescendoMiddleware(opts =>
        {
            opts.AddCmdletMapping("Get-Message", rootCommand);
        });

        commandLineBuilder.UseDefaults();
        var parser = commandLineBuilder.Build();
        await parser.InvokeAsync(args);
    }

    public static void DoRootCommand(int delay, string message)
    {
        Console.WriteLine($"--delay = {delay}");
        Console.WriteLine($"--message = {message}");
    }
}