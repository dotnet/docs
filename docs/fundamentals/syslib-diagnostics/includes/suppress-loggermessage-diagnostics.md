## Suppress warnings

It's recommended that you use one of the workarounds when possible. However, if you can't change your code, you can suppress the warning through a `<NoWarn>` project setting. If the `SYSLIB1XXX` source generator diagnostic doesn't surface as an error, you can suppress the warning in your project file.

> [!NOTE]
> Starting in .NET 11, `#pragma warning disable` directives no longer suppress diagnostics emitted by the `LoggerMessage` source generator. Use `<NoWarn>` in your project file or `.editorconfig` instead. For more information, see [LoggerMessage source generator diagnostics can't be suppressed with `#pragma`](/dotnet/core/compatibility/extensions/11.0/loggermessage-pragma-suppression).

To suppress the warnings in code on .NET 10 and earlier (replace the diagnostic ID as necessary):

```csharp
// Disable the warning.
#pragma warning disable SYSLIB1006

// Code that generates compiler diagnostic.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB1006
```

To suppress the warnings in a project file (replace the diagnostic IDs as necessary):

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   <TargetFramework>net10.0</TargetFramework>
   <!-- NoWarn below suppresses SYSLIB1002 project-wide -->
   <NoWarn>$(NoWarn);SYSLIB1002</NoWarn>
   <!-- To suppress multiple warnings, you can use multiple NoWarn elements -->
   <NoWarn>$(NoWarn);SYSLIB1002</NoWarn>
   <NoWarn>$(NoWarn);SYSLIB1006</NoWarn>
   <!-- Alternatively, you can suppress multiple warnings by using a semicolon-delimited list -->
   <NoWarn>$(NoWarn);SYSLIB1002;SYSLIB1006;SYSLIB1007</NoWarn>
  </PropertyGroup>
</Project>
```
