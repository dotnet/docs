﻿using System;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleLibrary.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyLibraryService(
          this IServiceCollection services,
          Action<LibraryOptions> configureOptions)
        {
            services.Configure(configureOptions);

            // Register lib services here...
            // services.AddScoped<ILibraryService, DefaultLibraryService>();

            return services;
        }
    }
}
