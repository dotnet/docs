using Microsoft.Extensions.Configuration;

namespace CustomProvider.Example;

/// <summary>
/// Loads configuration key/values from a YAML stream into a provider.
/// </summary>
public class YamlStreamConfigurationProvider : StreamConfigurationProvider
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="source">The <see cref="YamlStreamConfigurationSource"/>.</param>
    public YamlStreamConfigurationProvider(YamlStreamConfigurationSource source) : base(source) { }

    /// <summary>
    /// Loads Yaml configuration key/values from a stream into a provider.
    /// </summary>
    /// <param name="stream">The YAML <see cref="Stream"/> to load configuration data from.</param>
    public override void Load(Stream stream) => Data = YamlConfigurationFileParser.Parse(stream);
}
