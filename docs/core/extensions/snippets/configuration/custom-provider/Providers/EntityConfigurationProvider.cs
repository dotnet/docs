using System;
using System.Collections.Generic;
using System.Linq;
using CustomProvider.Example.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CustomProvider.Example.Providers
{
    public class EntityConfigurationProvider : ConfigurationProvider
    {
        readonly Action<DbContextOptionsBuilder> _optionsAction;

        public EntityConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction) =>
            _optionsAction = optionsAction ?? throw new ArgumentNullException(nameof(optionsAction));

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<EntityConfigurationContext>();

            _optionsAction(builder);

            using var dbContext = new EntityConfigurationContext(builder.Options);
            dbContext.Database.EnsureCreated();

            Data = !dbContext.Settings.Any()
                ? CreateAndSaveDefaultValues(dbContext)
                : dbContext.Settings.ToDictionary(c => c.Id, c => c.Value);
        }

        static IDictionary<string, string> CreateAndSaveDefaultValues(
            EntityConfigurationContext context)
        {
            // Quotes (c) 2005 Universal Pictures: Serenity
            // https://www.uphe.com/movies/serenity
            var settings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["quote1"] = "I aim to misbehave.",
                ["quote2"] = "I swallowed a bug.",
                ["quote3"] = "You can't stop the signal, Mal."
            };

            context.Settings.AddRange(
                settings.Select(kvp => new Settings(kvp.Key, kvp.Value))
                        .ToArray());

            context.SaveChanges();

            return settings;
        }
    }
}
