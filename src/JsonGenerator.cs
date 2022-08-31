using System.CommandLine;
using System.Text.Json;

namespace CrescendoMiddleware
{
    internal class JsonGenerator
    {
        public static string OutCrescendoJson(params Command[] commands)
        {
            return JsonSerializer.Serialize(new
            {
                Commands = commands
            });
        }

        public static Command OutCommand(CommandMapping mapping)
        {
            var parameters = new List<ParameterInfo>();
            foreach(var arg in mapping.Command.Options)
            {
                parameters.Add(new ParameterInfo
                {
                    Name = arg.Name,
                    OriginalName = "--" + arg.Name,
                    Type = arg.ValueType.Name
                });
            }

            return new Command
            {
                Noun = mapping.Cmdlet.Split("-").Last(),
                Verb = mapping.Cmdlet.Split("-").First(),
                OriginalName = RootCommand.ExecutableName,
                Parameters = parameters.ToArray()
            };
        }
    }
}
