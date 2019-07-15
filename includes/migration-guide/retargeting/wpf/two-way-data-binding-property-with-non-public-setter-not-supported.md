### Two-way data-binding to a property with a non-public setter is not supported

|   |   |
|---|---|
|Details|Attempting to data bind to a property without a public setter has never been a supported scenario. Beginning in the .NET Framework 4.5.1, this scenario will throw an <xref:System.InvalidOperationException?displayProperty=name>. Note that this new exception will only be thrown for apps that specifically target the .NET Framework 4.5.1. If an app targets the .NET Framework 4.5, the call will be allowed. If the app does not target a particular .NET Framework version, the binding will be treated as one-way.|
|Suggestion|The app should be updated to either use one-way binding, or expose the property's setter publicly. Alternatively, targeting the .NET Framework 4.5 will cause the app to exhibit the old behavior.|
|Scope|Minor|
|Version|4.5.1|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.Windows.Data.BindingMode.TwoWay?displayProperty=nameWithType></li></ul>|
