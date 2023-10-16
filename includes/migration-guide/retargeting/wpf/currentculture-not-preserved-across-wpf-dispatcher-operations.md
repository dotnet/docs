### CurrentCulture is not preserved across WPF Dispatcher operations

#### Details

Beginning in the .NET Framework 4.6, changes to <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=fullName> or <xref:System.Globalization.CultureInfo.CurrentUICulture?displayProperty=fullName> made within a <xref:System.Windows.Threading.Dispatcher?displayProperty=fullName> will be lost at the end of that dispatcher operation. Similarly, changes to <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=fullName> or <xref:System.Globalization.CultureInfo.CurrentUICulture?displayProperty=fullName> made outside of a Dispatcher operation may not be reflected when that operation executes.Practically speaking, this means that <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=fullName> and <xref:System.Globalization.CultureInfo.CurrentUICulture?displayProperty=fullName> changes may not flow between WPF UI callbacks and other code in a WPF application.This is due to a change in <xref:System.Threading.ExecutionContext?displayProperty=fullName> that causes <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=fullName> and <xref:System.Globalization.CultureInfo.CurrentUICulture?displayProperty=fullName> to be stored in the execution context beginning with apps targeting the .NET Framework 4.6. WPF dispatcher operations store the execution context used to begin the operation and restore the previous context when the operation is completed. Because <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=fullName> and <xref:System.Globalization.CultureInfo.CurrentUICulture?displayProperty=fullName> are now part of that context, changes to them within a dispatcher operation are not persisted outside of the operation.

#### Suggestion

Apps affected by this change may work around it by storing the desired <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=fullName> or <xref:System.Globalization.CultureInfo.CurrentUICulture?displayProperty=fullName> in a field and checking in all Dispatcher operation bodies (including UI event callback handlers) that the correct <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=fullName> and <xref:System.Globalization.CultureInfo.CurrentUICulture?displayProperty=fullName> are set. Alternatively, because the ExecutionContext change underlying this WPF change only affects apps targeting the .NET Framework 4.6 or newer, this break can be avoided by targeting the .NET Framework 4.5.2.Apps that target .NET Framework 4.6 or later can also work around this by setting the following compatibility switch:

```csharp
AppContext.SetSwitch(=Switch.System.Globalization.NoAsyncCurrentCulture=, true);
```

This issue has been fixed by WPF in .NET Framework 4.6.2. It has also been fixed in .NET Frameworks 4.6, 4.6.1 through [KB 3139549](https://support.microsoft.com/kb/3139549). Applications targeting .NET Framework 4.6 or later will automatically get the right behavior in WPF applications - <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=fullName>/<xref:System.Globalization.CultureInfo.CurrentUICulture?displayProperty=fullName>) would be preserved across Dispatcher operations.

| Name    | Value       |
|:--------|:------------|
| Scope   | Minor       |
| Version | 4.6         |
| Type    | Retargeting |
