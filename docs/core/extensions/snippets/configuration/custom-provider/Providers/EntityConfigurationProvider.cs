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

            Data = dbContext.Settings.Any()
                ? dbContext.Settings.ToDictionary(c => c.Id, c => c.Value)
                : CreateAndSaveDefaultValues(dbContext);
        }

        static IDictionary<string, string> CreateAndSaveDefaultValues(
            EntityConfigurationContext context)
        {
            var settings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["EndpointId"] = "b3da3c4c-9c4e-4411-bc4d-609e2dcc5c67",
                ["DisplayLabel"] = "Widgets Incorporated, LLC.",
                ["WidgetRoute"] = "api/widgets"
            };

            context.Settings.AddRange(
                settings.Select(kvp => new Settings(kvp.Key, kvp.Value))
                        .ToArray());

            context.SaveChanges();

            return settings;
        }
    }
}
