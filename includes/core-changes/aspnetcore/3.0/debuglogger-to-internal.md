### DebugLogger class made internal

Prior to ASP.NET Core 3.0, `DebugLogger`'s access modifier was `public`. In ASP.NET Core 3.0, the access modifier changed to `internal`.

#### Version introduced

3.0

#### Reason for change

The change is being made to:

* Enforce consistency with other logger implementations such as `ConsoleLogger`.
* Reduce the API surface.

#### Recommended action

Use the <xref:Microsoft.Extensions.Logging.DebugLoggerFactoryExtensions.AddDebug%2A> `ILoggingBuilder` extension method to enable debug logging. <xref:Microsoft.Extensions.Logging.Debug.DebugLoggerProvider> is also still `public` in the event the service needs to be registered manually.

#### Category

ASP.NET Core

#### Affected APIs

<xref:Microsoft.Extensions.Logging.Debug.DebugLogger?displayProperty=nameWithType>

<!--

#### Affected APIs

`T:Microsoft.Extensions.Logging.Debug.DebugLogger`

-->
