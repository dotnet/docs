using System.Reflection;
using System.Runtime.InteropServices;

var versionString = Assembly.GetEntryAssembly()?
                        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                        .InformationalVersion
                        .ToString();

Console.WriteLine($"dotnet-env v{versionString}");
Console.WriteLine(new string('-', 40));

Console.WriteLine();
Console.WriteLine("Runtime");
Console.WriteLine($"  .NET Version          {Environment.Version}");
Console.WriteLine($"  Framework             {RuntimeInformation.FrameworkDescription}");
Console.WriteLine($"  Runtime Identifier    {RuntimeInformation.RuntimeIdentifier}");

Console.WriteLine();
Console.WriteLine("System");
Console.WriteLine($"  OS                    {RuntimeInformation.OSDescription}");
Console.WriteLine($"  Architecture          {RuntimeInformation.OSArchitecture}");
Console.WriteLine($"  Machine Name          {Environment.MachineName}");
Console.WriteLine($"  Processor Count       {Environment.ProcessorCount}");

Console.WriteLine();
Console.WriteLine("Environment Variables");
string[] envVars = { "DOTNET_ROOT", "DOTNET_HOST_PATH",
                        "DOTNET_CLI_HOME", "DOTNET_NOLOGO",
                        "NUGET_PACKAGES", "DOTNET_ENVIRONMENT" };

foreach (string name in envVars)
{
    string? value = Environment.GetEnvironmentVariable(name);
    Console.WriteLine($"  {name,-24}{value ?? "(not set)"}");
}
