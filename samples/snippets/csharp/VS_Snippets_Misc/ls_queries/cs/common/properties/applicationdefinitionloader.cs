using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Reflection;
using Microsoft.LightSwitch.Model;

[Export(typeof(IApplicationDefinitionLoaderService))]
public class ApplicationDefinitionLoader : IApplicationDefinitionLoaderService
{
    public IEnumerable<Stream> LoadModelFragments()
    {
        var executingAssembly = Assembly.GetExecutingAssembly();
        List<Stream> definitionStreams = new List<Stream>();
        foreach (var resourceName in executingAssembly.GetManifestResourceNames())
        {
            if (resourceName.EndsWith(".lsml", System.StringComparison.OrdinalIgnoreCase))
            {
                definitionStreams.Add(executingAssembly.GetManifestResourceStream(resourceName));
            }
        }
        return definitionStreams;
    }
}
