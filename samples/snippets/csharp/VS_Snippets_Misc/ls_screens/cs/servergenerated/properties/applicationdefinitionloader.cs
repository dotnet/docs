using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Reflection;
using Microsoft.LightSwitch.Model;

[Export(typeof(IApplicationDefinitionLoaderService))]
public class ApplicationDefinitionLoader : IApplicationDefinitionLoaderService
{
    private const string AppDefinition = @"bin\ApplicationDefinition.lsml";
    public IEnumerable<Stream> LoadModelFragments()
    {
        List<Stream> definitionStreams = new List<Stream>();
        definitionStreams.Add(File.OpenRead(AppDefinition));
        return definitionStreams;
    }
}
