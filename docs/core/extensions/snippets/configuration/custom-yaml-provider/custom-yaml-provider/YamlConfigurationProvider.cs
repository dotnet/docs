using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace CustomProvider.Example;

/// <summary>
/// A YAML file based <see cref="FileConfigurationProvider"/>.
/// </summary>
public class YamlConfigurationProvider : FileConfigurationProvider
{
    /// <summary>
    /// Initializes a new instance with the specified source.
    /// </summary>
    /// <param name="source">The source settings.</param>
    public YamlConfigurationProvider(YamlConfigurationSource source) : base(source) { }

    /// <summary>
    /// Loads the YAML data from a stream.
    /// </summary>
    /// <param name="stream">The stream to read.</param>
    public override void Load(Stream stream)
    {
        try
        {
            Data = YamlConfigurationFileParser.Parse(stream);
        }
        catch (Exception ex)
        {
            throw new FormatException("Unable to parse YAML.", ex);
        }
    }
}
