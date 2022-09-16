using Microsoft.Extensions.Configuration;

namespace CustomProvider.Example;


/// <summary>
/// Represents a YAML file as an <see cref="IConfigurationSource"/>.
/// </summary>
public class YamlStreamConfigurationSource : StreamConfigurationSource
{
    /// <summary>
    /// Builds the <see cref="YamlStreamConfigurationProvider"/> for this source.
    /// </summary>
    /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
    /// <returns>An <see cref="YamlStreamConfigurationProvider"/></returns>
    public override IConfigurationProvider Build(IConfigurationBuilder builder) =>
        new YamlStreamConfigurationProvider(this);
}
