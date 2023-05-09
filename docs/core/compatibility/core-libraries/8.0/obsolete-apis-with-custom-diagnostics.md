---
title: "Breaking change: .NET 8 obsoletions with custom IDs"
titleSuffix: ""
description: Learn about the .NET 8 breaking change in core .NET libraries where some APIs have been marked as obsolete with a custom diagnostic ID.
ms.date: 05/05/2023
---
# API obsoletions with non-default diagnostic IDs (.NET 8)

Some APIs have been marked as obsolete, starting in .NET 8. This breaking change is specific to APIs that have been marked as obsolete *with a custom diagnostic ID*. Suppressing the default obsoletion diagnostic ID, which is [CS0618](../../../../csharp/language-reference/compiler-messages/cs0618.md) for the C# compiler, does not suppress the warnings that the compiler generates when these APIs are used.

## Change description

In previous .NET versions, these APIs can be used without any build warning. In .NET 8 and later versions, use of these APIs produces a compile-time warning or error with a custom diagnostic ID. The use of custom diagnostic IDs allows you to suppress the obsoletion warnings individually instead of blanket-suppressing all obsoletion warnings.

The following table lists the custom diagnostic IDs and their corresponding warning messages for obsoleted APIs.

| Diagnostic ID | Description | Severity |
| - | - |
| [SYSLIB0048](../../../../fundamentals/syslib-diagnostics/syslib0048.md) | <xref:System.Security.Cryptography.RSA.EncryptValue(System.Byte[])?displayProperty=nameWithType> and <xref:System.Security.Cryptography.RSA.DecryptValue(System.Byte[])?displayProperty=nameWithType> are obsolete. Use <xref:System.Security.Cryptography.RSA.Encrypt%2A?displayProperty=nameWithType> and <xref:System.Security.Cryptography.RSA.Decrypt%2A?displayProperty=nameWithType> instead. | Warning |
| [SYSLIB0050](../../../../fundamentals/syslib-diagnostics/syslib0050.md) | Formatter-based serialization is obsolete and should not be used. | Warning |
| [SYSLIB0051](../../../../fundamentals/syslib-diagnostics/syslib0051.md) | APIs that support obsolete formatter-based serialization are obsolete. They should not be called or extended by application code. | Warning |

## Version introduced

.NET 8

## Type of breaking change

These obsoletions can affect [source compatibility](../../categories.md#source-compatibility).

## Recommended action

- Follow the specific guidance provided for the each diagnostic ID using the URL link provided on the warning.

- Warnings or errors for these obsoletions can't be suppressed using the standard diagnostic ID for obsolete types or members; use the custom `SYSLIBxxxx` diagnostic ID value instead.

## Affected APIs

### SYSLIB0048

- <xref:System.Security.Cryptography.RSA.EncryptValue(System.Byte[])?displayProperty=fullName>
- <xref:System.Security.Cryptography.RSA.DecryptValue(System.Byte[])?displayProperty=fullName>
- <xref:System.Security.Cryptography.RSACryptoServiceProvider.EncryptValue(System.Byte[])?displayProperty=fullName>
- <xref:System.Security.Cryptography.RSACryptoServiceProvider.DecryptValue(System.Byte[])?displayProperty=fullName>

### SYSLIB0050

- <xref:System.Runtime.Serialization.FormatterConverter?displayProperty=fullName>
- <xref:System.Runtime.Serialization.FormatterServices?displayProperty=fullName>
- <xref:System.Runtime.Serialization.IFormatterConverter?displayProperty=fullName>
- <xref:System.Runtime.Serialization.IObjectReference?displayProperty=fullName>
- <xref:System.Runtime.Serialization.ISafeSerializationData?displayProperty=fullName>
- <xref:System.Runtime.Serialization.ISerializationSurrogate?displayProperty=fullName>
- <xref:System.Runtime.Serialization.ISurrogateSelector?displayProperty=fullName>
- <xref:System.Runtime.Serialization.ObjectIDGenerator?displayProperty=fullName>
- <xref:System.Runtime.Serialization.ObjectManager?displayProperty=fullName>
- <xref:System.Runtime.Serialization.SafeSerializationEventArgs?displayProperty=fullName>
- <xref:System.Runtime.Serialization.SerializationObjectManager?displayProperty=fullName>
- <xref:System.Runtime.Serialization.StreamingContextStates?displayProperty=fullName>
- <xref:System.Runtime.Serialization.SurrogateSelector?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Formatters.FormatterAssemblyStyle?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Formatters.FormatterTypeStyle?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Formatters.IFieldInfo?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Formatters.TypeFilterLevel?displayProperty=fullName>
- <xref:System.Type.IsSerializable?displayProperty=fullName>
- <xref:System.Reflection.FieldAttributes.NotSerialized?displayProperty=fullName>
- <xref:System.Reflection.FieldInfo.IsNotSerialized?displayProperty=fullName>
- <xref:System.Reflection.TypeAttributes.Serializable?displayProperty=fullName>
- <xref:System.Runtime.Serialization.ISerializable.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>
- <xref:System.Runtime.Serialization.SerializationInfo.%23ctor(System.Type,System.Runtime.Serialization.IFormatterConverter,System.Boolean)>
- <xref:System.Runtime.Serialization.SerializationInfo.%23ctor(System.Type,System.Runtime.Serialization.IFormatterConverter)>
- <xref:System.Runtime.Serialization.StreamingContext.%23ctor(System.Runtime.Serialization.StreamingContextStates,System.Object)>
- <xref:System.Runtime.Serialization.StreamingContext.%23ctor(System.Runtime.Serialization.StreamingContextStates)>

### SYSLIB0051

- All public or protected serialization constructors that follow the pattern `.ctor(SerializationInfo, StreamingContext)`. An example of such a constructor is <xref:System.Exception.%23ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)>.
- All implicit implementations of the <xref:System.Runtime.Serialization.IObjectReference.GetRealObject(System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> method, for example, <xref:System.Reflection.ParameterInfo.GetRealObject(System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>.
- All implicit implementations of the <xref:System.Runtime.Serialization.ISerializable.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=nameWithType> method, for example, <xref:System.Exception.GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)?displayProperty=fullName>.

For a complete list of affected APIs, see [SYSLIB0051: Legacy serialization support APIs are obsolete](../../../../fundamentals/syslib-diagnostics/syslib0051.md).

## See also

- [API obsoletions with non-default diagnostic IDs (.NET 7)](../7.0/obsolete-apis-with-custom-diagnostics.md)
- [API obsoletions with non-default diagnostic IDs (.NET 6)](../6.0/obsolete-apis-with-custom-diagnostics.md)
- [API obsoletions with non-default diagnostic IDs (.NET 5)](../5.0/obsolete-apis-with-custom-diagnostics.md)
- [Obsolete features in .NET 5+](../../../../fundamentals/syslib-diagnostics/obsoletions-overview.md)
