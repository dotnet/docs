### WinRT stream adapters no long call FlushAsync automatically on close

#### Details

In Windows Store apps, Windows Runtime stream adapters no longer call the FlushAsync method from the Dispose method.

#### Suggestion

This change should be transparent. Developers can restore the previous behavior by writing code like this:

```csharp
using (var stream = GetWindowsRuntimeStream() as Stream)
{
// do something
await stream.FlushAsync();
}

```

| Name    | Value       |
|:--------|:------------|
| Scope   |Transparent|
|Version|4.5.1|
|Type|Runtime|

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
