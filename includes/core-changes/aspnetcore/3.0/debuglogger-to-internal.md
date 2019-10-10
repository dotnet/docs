### DebugLogger class made internal

`DebugLogger` has effectively been removed. Prior to ASP.NET Core 3.0, it was `public`. Starting with ASP.NET Core 3.0, it's `internal` to match other logger implementations such as `ConsoleLogger`.

#### Version introduced

3.0

#### Reason for change

Consistency and reduction of API surface.

#### Recommended action

Use the <xref:Microsoft.Extensions.Logging.DebugLoggerFactoryExtensions.AddDebug%2A> `ILoggingBuilder` extension method to enable debug logging. <xref:Microsoft.Extensions.Logging.Debug.DebugLoggerProvider> is also still `public` in the event the service needs to be registered manually.

#### Category

ASP.NET Core

#### Affected APIs

<xref:Microsoft.Extensions.Logging.Debug.DebugLogger?displayProperty=nameWithType>

<!--
### Affected APIs

`T:Microsoft.Extensions.Logging.Debug.DebugLogger`

-->
