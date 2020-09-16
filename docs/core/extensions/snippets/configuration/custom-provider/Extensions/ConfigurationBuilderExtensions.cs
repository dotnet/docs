using System;
using CustomProvider.Example.Providers;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddEntityConfiguration(
            this IConfigurationBuilder builder,
            Action<DbContextOptionsBuilder> optionsAction) =>
            builder.Add(new EntityConfigurationSource(optionsAction));
    }
}
