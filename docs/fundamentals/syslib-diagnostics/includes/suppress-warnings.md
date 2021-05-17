## Suppress warnings

You can suppress warnings through a `#pragma` directive or a `<NoWarn>` project setting. As long as the `SYSLIBXXXX` diagnostic doesn't surface as an error, you can suppress the warning in code or in your project file.

To suppress the warnings in code:

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0001

// Code that uses obsolete API.
//...

// Re-enable the warning.
#pragma warning restore SYSLIB0001
```

To suppress the warnings in a project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   <!-- NoWarn below suppresses SYSLIB0001 project-wide -->
   <NoWarn>$(NoWarn);SYSLIB0001</NoWarn>
   <!-- To suppress multiple warnings, you can use multiple NoWarn elements -->
   <NoWarn>$(NoWarn);SYSLIB0002</NoWarn>
   <NoWarn>$(NoWarn);SYSLIB0003</NoWarn>
   <!-- Alternatively, you can suppress multiple warnings by using a semicolon-delimited list -->
   <NoWarn>$(NoWarn);SYSLIB0001;SYSLIB0002;SYSLIB0003</NoWarn>
  </PropertyGroup>
</Project>
```
