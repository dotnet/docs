---
title: SYSLIB0011 warning
description: Learn about the obsoletions that generate compile-time warning SYSLIB0011.
ms.date: 10/20/2020
---
# SYSLIB0011: BinaryFormatter serialization is obsolete

Due to [security vulnerabilities](../../standard/serialization/binaryformatter-security-guide.md#binaryformatter-security-vulnerabilities) in <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter>, the following APIs are marked as obsolete, starting in .NET 5. Using them in code generates warning `SYSLIB0011` at compile time.

- <xref:System.Exception.SerializeObjectState?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Serialize%2A?displayProperty=nameWithType>
- <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize%2A?displayProperty=nameWithType>
- <xref:System.Runtime.Serialization.Formatter.Serialize(System.IO.Stream,System.Object)?displayProperty=nameWithType>
- <xref:System.Runtime.Serialization.Formatter.Deserialize(System.IO.Stream)?displayProperty=nameWithType>
- <xref:System.Runtime.Serialization.IFormatter.Serialize(System.IO.Stream,System.Object)?displayProperty=nameWithType>
- <xref:System.Runtime.Serialization.IFormatter.Deserialize(System.IO.Stream)?displayProperty=nameWithType>

## Workarounds

Consider using <xref:System.Text.Json.JsonSerializer> or <xref:System.Xml.Serialization.XmlSerializer> instead of <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter>.

For more information about recommended actions, see [Resolving BinaryFormatter obsoletion and disablement errors](../../standard/serialization/binaryformatter-security-guide.md).

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]

## See also

- [Resolving BinaryFormatter obsoletion and disablement errors](../../standard/serialization/binaryformatter-security-guide.md)
- [BinaryFormatter serialization methods are obsolete and prohibited in ASP.NET apps](../../core/compatibility/core-libraries/5.0/binaryformatter-serialization-obsolete.md)
