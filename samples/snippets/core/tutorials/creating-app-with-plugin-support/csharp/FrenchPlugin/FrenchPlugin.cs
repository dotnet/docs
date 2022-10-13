using Humanizer.Localisation.Formatters;
using PluginBase;
using System;
using System.Linq;
using System.Reflection;

namespace FrenchPlugin
{
    public class FrenchPlugin : ICommand
    {
        public string Name => "french";

        public string Description => "Uses satellite assembly to display french.";

        public int Execute()
        {
            DefaultFormatter formatter = new DefaultFormatter("fr");
            Console.WriteLine(formatter.DateHumanize_Now());
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.GetName().Name.StartsWith("Humanizer")))
            {
                Console.WriteLine($"{assembly.FullName} from {assembly.Location}");
            }

            return 0;
        }
    }
}
