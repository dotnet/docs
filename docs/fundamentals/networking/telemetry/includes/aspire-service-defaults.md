The Aspire Service Defaults project provides an easy way to configure OTel for ASP.NET projects, *even if not using the rest of .NET Aspire* such as the AppHost for orchestration. The Service Defaults project is available as a project template via Visual Studio or `dotnet new`. It configures OTel and sets up the OTLP exporter. You can then use the [OTel environment variables](https://github.com/open-telemetry/opentelemetry-dotnet/tree/c94c422e31b2a5181a97b2dcf4bdc984f37ac1ff/src/OpenTelemetry.Exporter.OpenTelemetryProtocol#exporter-configuration) to configure the OTLP endpoint to send telemetry to, and provide the resource properties for the application.

The steps to use *ServiceDefaults* outside .NET Aspire are:

1. Add the *ServiceDefaults* project to the solution using Add New Project in Visual Studio, or use `dotnet new`:

    ```dotnetcli
    dotnet new aspire-servicedefaults --output ServiceDefaults
    ```

1. Reference the *ServiceDefaults* project from your ASP.NET application. In Visual Studio, select **Add** > **Project Reference** and select the **ServiceDefaults** project"
1. Call the OpenTelemetry setup function `ConfigureOpenTelemetry()` as part of your application builder initialization.

    ``` csharp
    var builder = WebApplication.CreateBuilder(args)
    builder.ConfigureOpenTelemetry(); // Extension method from ServiceDefaults.
    var app = builder.Build();
    app.MapGet("/", () => "Hello World!");
    app.Run();
    ```

For a full walkthrough, see [Example: Use OpenTelemetry with OTLP and the standalone Aspire Dashboard](../../../../core/diagnostics/observability-otlp-example.md).
