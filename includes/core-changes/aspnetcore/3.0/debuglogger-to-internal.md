### DebugLogger class made internal

`DebugLogger` has effectively been removed. It was previously `public`. Now it's `internal` to match other logger implementations such as `ConsoleLogger`.

#### Version introduced

3.0

#### Old behavior

`DebugLogger` was `public`.

#### New behavior

`DebugLogger` is `internal`.

#### Reason for change

Consistency and reduction of API surface.

#### Recommended action

Use the [AddDebug](/dotnet/api/microsoft.extensions.logging.debugloggerfactoryextensions.adddebug?view=aspnetcore-3.0) `ILoggingBuilder` extension method to enable debug logging. [DebugLoggerProvider](/dotnet/api/microsoft.extensions.logging.debug.debugloggerprovider?view=aspnetcore-3.0) is also still `public` in the event the service needs to be registered manually.

#### Category

ASP.NET Core

#### Affected APIs

[DebugLogger](/dotnet/api/microsoft.extensions.logging.debug.debuglogger?view=aspnetcore-2.2)
