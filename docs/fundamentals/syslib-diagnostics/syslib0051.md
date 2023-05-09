---
title: SYSLIB0051 warning - Legacy serialization support APIs are obsolete
description: Learn about the obsoletion of APIs that support formatter-based serialization that generates compile-time warning SYSLIB0051.
ms.date: 05/05/2023
---
# SYSLIB0051: Legacy serialization support APIs are obsolete

The following kinds of APIs are obsolete, starting in .NET 8. Calling them in code generates warning `SYSLIB0051` at compile time.

- All public or protected serialization constructors that follow the pattern `.ctor(SerializationInfo, StreamingContext)`. An example of such a constructor is <xref:System.Exception.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)>.
- All implicit implementations of the <xref:System.Runtime.Serialization.ISerializable.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> method, for example, <xref:System.Exception.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>.
- All implicit implementations of the <xref:System.Runtime.Serialization.IObjectReference.GetRealObject(System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> method, for example, <xref:System.Reflection.ParameterInfo.GetRealObject(System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>.

For a complete list of affected APIs, see [Obsolete APIs - SYSLIB0051](../../core/compatibility/core-libraries/8.0/obsolete-apis-with-custom-diagnostics.md#syslib0051).

## Workaround

If you've declared a type that subclasses a .NET type that's attributed with `[Serializable]` and you're getting `SYSLIB0051` warnings, follow the [guidance for custom exception types for SYSLIB0050](syslib0050.md#custom-exception).

> [!TIP]
> If your `[Serializable]` custom type doesn't subclass a .NET type, you won't see `SYSLIB0051` warnings. However, we recommend against annotating your type in this manner, as modern serialization libraries like `System.Text.Json` don't require them. Consider removing the `[Serializable]` attribute and the `ISerializable` interface. Instead, rely on your serialization library to access objects of the type through its public properties rather than its private fields.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0051

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0051
```

To suppress all the `SYSLIB0051` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0051</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).

## See also

- [SYSLIB0050: Formatter-based serialization is obsolete](syslib0050.md)
