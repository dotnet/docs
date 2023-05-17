---
title: SYSLIB0011 warning
description: Learn about the obsoletions that generate compile-time warning SYSLIB0011.
ms.date: 05/08/2023
---
# SYSLIB0011: BinaryFormatter serialization is obsolete

Due to [security vulnerabilities](../../standard/serialization/binaryformatter-security-guide.md#binaryformatter-security-vulnerabilities) in <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter>, the following APIs were marked as obsolete in .NET 5. Using them in code generates warning or error `SYSLIB0011` at compile time.

- <xref:System.Exception.SerializeObjectState?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Serialize%2A?displayProperty=nameWithType>
- <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize%2A?displayProperty=nameWithType>
- <xref:System.Runtime.Serialization.Formatter.Serialize(System.IO.Stream,System.Object)?displayProperty=nameWithType>
- <xref:System.Runtime.Serialization.Formatter.Deserialize(System.IO.Stream)?displayProperty=nameWithType>
- <xref:System.Runtime.Serialization.IFormatter.Serialize(System.IO.Stream,System.Object)?displayProperty=nameWithType>
- <xref:System.Runtime.Serialization.IFormatter.Deserialize(System.IO.Stream)?displayProperty=nameWithType>

Starting in .NET 8, <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Serialize%2A?displayProperty=nameWithType> and <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize%2A?displayProperty=nameWithType> throw a <xref:System.NotSupportedException> at run time on most project types. In addition, the following APIs are marked obsolete *as error*:

- <xref:System.Runtime.Serialization.Formatter?displayProperty=fullName>
- <xref:System.Runtime.Serialization.IFormatter?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter?displayProperty=fullName>

## Workarounds

If you're using <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter>, you should migrate away from it due to its security and reliability flaws. For more information, see [Deserialization risks in use of BinaryFormatter and related types](../../standard/serialization/binaryformatter-security-guide.md) and [Preferred alternatives](../../standard/serialization/binaryformatter-security-guide.md#preferred-alternatives).

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning/error in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0011

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0011
```

To suppress all the `SYSLIB0011` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0011</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).

## See also

- [Resolving BinaryFormatter obsoletion and disablement errors](../../standard/serialization/binaryformatter-security-guide.md)
- [BinaryFormatter serialization methods are obsolete and prohibited in ASP.NET apps (.NET 5)](../../core/compatibility/serialization/5.0/binaryformatter-serialization-obsolete.md)
- [BinaryFormatter serialization APIs produce compiler errors (.NET 7)](../../core/compatibility/serialization/7.0/binaryformatter-apis-produce-errors.md)
- [BinaryFormatter disabled across most project types (.NET 8)](../../core/compatibility/serialization/8.0/binaryformatter-disabled.md)
