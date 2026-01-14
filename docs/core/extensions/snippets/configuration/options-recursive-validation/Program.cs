using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RecursiveValidation.Example;

// <ProgramWithoutAttribute>
HostApplicationBuilder builderWithout = Host.CreateApplicationBuilder(args);

builderWithout.Services
    .AddOptions<ApplicationOptionsWithoutAttribute>()
    .Bind(builderWithout.Configuration.GetSection(
        ApplicationOptionsWithoutAttribute.ConfigurationSectionName))
    .ValidateDataAnnotations()
    .ValidateOnStart();

IHost hostWithout = builderWithout.Build();

try
{
    var optionsWithout = hostWithout.Services
        .GetRequiredService<IOptions<ApplicationOptionsWithoutAttribute>>().Value;
    
    Console.WriteLine("Without [ValidateObjectMembers] and [ValidateEnumeratedItems]:");
    Console.WriteLine($"  Application: {optionsWithout.ApplicationName}");
    Console.WriteLine($"  Database Connection: {optionsWithout.Database.ConnectionString}");
    Console.WriteLine($"  Servers Count: {optionsWithout.Servers.Count}");
    Console.WriteLine("  Validation succeeded (but nested objects were not validated!)");
}
catch (OptionsValidationException ex)
{
    Console.WriteLine("Without attributes - Validation failed:");
    foreach (var failure in ex.Failures)
    {
        Console.WriteLine($"  - {failure}");
    }
}
// </ProgramWithoutAttribute>

Console.WriteLine();

// <ProgramWithAttribute>
HostApplicationBuilder builderWith = Host.CreateApplicationBuilder(args);

builderWith.Services
    .AddOptions<ApplicationOptionsWithAttribute>()
    .Bind(builderWith.Configuration.GetSection(
        ApplicationOptionsWithAttribute.ConfigurationSectionName))
    .ValidateDataAnnotations()
    .ValidateOnStart();

IHost hostWith = builderWith.Build();

try
{
    var optionsWith = hostWith.Services
        .GetRequiredService<IOptions<ApplicationOptionsWithAttribute>>().Value;
    
    Console.WriteLine("With [ValidateObjectMembers] and [ValidateEnumeratedItems]:");
    Console.WriteLine($"  Application: {optionsWith.ApplicationName}");
    Console.WriteLine($"  Database Connection: {optionsWith.Database.ConnectionString}");
    Console.WriteLine($"  Servers Count: {optionsWith.Servers.Count}");
    Console.WriteLine("  Validation succeeded (nested objects were validated!)");
}
catch (OptionsValidationException ex)
{
    Console.WriteLine("With attributes - Validation failed:");
    foreach (var failure in ex.Failures)
    {
        Console.WriteLine($"  - {failure}");
    }
}
// </ProgramWithAttribute>
