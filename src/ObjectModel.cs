using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrescendoMiddleware
{
    public class Command
    {
        public string Verb { get; set;  }
        public string Noun { get; set; }
        public string OriginalName { get; set; }
        public string[] OriginalCommandElements { get; set; }
        public string[] Platform { get; set; }
        public string OriginalText { get; set; }
        public ParameterInfo[] Parameters { get; set; }
    }

    public class ParameterInfo
    {
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string Type { get; set; }
    }

    internal class CommandMapping
    {
        public string Cmdlet { get; set; }
        public System.CommandLine.Command Command { get; set; }
    }
}
