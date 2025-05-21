---
title: "Breaking change: .NET 9 obsoletions with custom IDs"
titleSuffix: ""
description: Learn about the APIs that have been marked as obsolete in .NET 9 with a custom diagnostic ID.
ms.date: 11/06/2024
ms.topic: concept-article
---
# API obsoletions with non-default diagnostic IDs (.NET 9)

Some APIs have been marked as obsolete, starting in .NET 9. This breaking change is specific to APIs that have been marked as obsolete *with a custom diagnostic ID*. Suppressing the default obsoletion diagnostic ID, which is [CS0618](../../../../csharp/language-reference/compiler-messages/cs0618.md) for the C# compiler, does not suppress the warnings that the compiler generates when these APIs are used.

## Change description

In previous .NET versions, these APIs can be used without any build warning. In .NET 9 and later versions, use of these APIs produces a compile-time warning or error with a custom diagnostic ID. The use of custom diagnostic IDs allows you to suppress the obsoletion warnings individually instead of blanket-suppressing all obsoletion warnings.

The following table lists the custom diagnostic IDs and their corresponding warning messages for obsoleted APIs.

| Diagnostic ID | Description | Severity |
|---------------|-------------|----------|
| [SYSLIB0009](../../../../fundamentals/syslib-diagnostics/syslib0009.md) | <xref:System.Net.AuthenticationManager> is not supported. Methods will no-op or throw <xref:System.PlatformNotSupportedException>. | Warning |
| [SYSLIB0014](../../../../fundamentals/syslib-diagnostics/syslib0014.md) | <xref:System.Net.ServicePointManager> is fully obsolete. Settings on <xref:System.Net.ServicePointManager> don't affect <xref:System.Net.Security.SslStream> or <xref:System.Net.Http.HttpClient> (this behavior hasn't changed since .NET 6). | Warning |
| [SYSLIB0054](../../../../fundamentals/syslib-diagnostics/syslib0054.md) | <xref:System.Threading.Thread.VolatileRead%2A?displayProperty=nameWithType> and <xref:System.Threading.Thread.VolatileWrite%2A?displayProperty=nameWithType> are obsolete. Use <xref:System.Threading.Volatile.Read%2A?displayProperty=nameWithType> or <xref:System.Threading.Volatile.Write%2A?displayProperty=nameWithType> instead. | Warning |
| [SYSLIB0055](../../../../fundamentals/syslib-diagnostics/syslib0055.md) | `AdvSimd.ShiftRightLogicalRoundedNarrowingSaturate*` methods with signed parameters are obsolete. Use the unsigned overloads instead. | Warning |
| [SYSLIB0056](../../../../fundamentals/syslib-diagnostics/syslib0056.md) | `Assembly.LoadFrom` with a custom `AssemblyHashAlgorithm` is obsolete. Use overloads without an `AssemblyHashAlgorithm`. | Warning |
| [SYSLIB0057](../../../../fundamentals/syslib-diagnostics/syslib0057.md) | `X509Certificate2` and `X509Certificate` constructors for binary and file content are obsolete. | Warning |

## Version introduced

.NET 9

## Type of breaking change

These obsoletions can affect [source compatibility](../../categories.md#source-compatibility).

## Recommended action

- Follow the specific guidance provided for the each diagnostic ID using the URL link provided on the warning.

- Warnings or errors for these obsoletions can't be suppressed using the standard diagnostic ID for obsolete types or members; use the custom `SYSLIBxxxx` diagnostic ID value instead.

## Affected APIs

### SYSLIB0009

- <xref:System.Net.AuthenticationManager?displayProperty=fullName>

### SYSLIB0014

- <xref:System.Net.ServicePointManager?displayProperty=fullName>

### SYSLIB0054

- <xref:System.Threading.Thread.VolatileRead%2A?displayProperty=fullName>
- <xref:System.Threading.Thread.VolatileWrite%2A?displayProperty=fullName>

### SYSLIB0055

- <xref:System.Runtime.Intrinsics.Arm.AdvSimd.Arm64.ShiftRightLogicalRoundedNarrowingSaturateScalar(System.Runtime.Intrinsics.Vector64{System.Int64},System.Byte)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.AdvSimd.Arm64.ShiftRightLogicalRoundedNarrowingSaturateScalar(System.Runtime.Intrinsics.Vector64{System.Int16},System.Byte)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.AdvSimd.Arm64.ShiftRightLogicalRoundedNarrowingSaturateScalar(System.Runtime.Intrinsics.Vector64{System.Int32},System.Byte)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateLower(System.Runtime.Intrinsics.Vector128{System.Int16},System.Byte)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateLower(System.Runtime.Intrinsics.Vector128{System.Int64},System.Byte)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateLower(System.Runtime.Intrinsics.Vector128{System.Int32},System.Byte)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateUpper(System.Runtime.Intrinsics.Vector64{System.SByte},System.Runtime.Intrinsics.Vector128{System.Int16},System.Byte)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateUpper(System.Runtime.Intrinsics.Vector64{System.Int16},System.Runtime.Intrinsics.Vector128{System.Int32},System.Byte)?displayProperty=fullName>
- <xref:System.Runtime.Intrinsics.Arm.AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateUpper(System.Runtime.Intrinsics.Vector64{System.Int32},System.Runtime.Intrinsics.Vector128{System.Int64},System.Byte)?displayProperty=fullName>

### SYSLIB0056

- <xref:System.Reflection.Assembly.LoadFrom(System.String,System.Byte[],System.Configuration.Assemblies.AssemblyHashAlgorithm)>

### SYSLIB0057

- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor(System.Byte[])>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor(System.ReadOnlySpan{System.Byte})>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor(System.String)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor(System.Byte[],System.Security.SecureString)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor(System.Byte[],System.String)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor(System.String,System.Security.SecureString)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor(System.String,System.String)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor(System.Byte[],System.Security.SecureString,System.Security.Cryptography.X509Certificates.X509KeyStorageFlags)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor(System.Byte[],System.String,System.Security.Cryptography.X509Certificates.X509KeyStorageFlags)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor(System.ReadOnlySpan{System.Byte},System.ReadOnlySpan{System.Char},System.Security.Cryptography.X509Certificates.X509KeyStorageFlags)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor(System.String,System.ReadOnlySpan{System.Char},System.Security.Cryptography.X509Certificates.X509KeyStorageFlags)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor(System.String,System.Security.SecureString,System.Security.Cryptography.X509Certificates.X509KeyStorageFlags)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor(System.String,System.String,System.Security.Cryptography.X509Certificates.X509KeyStorageFlags)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.%23ctor(System.Byte[])>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.%23ctor(System.String)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.%23ctor(System.Byte[],System.Security.SecureString)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.%23ctor(System.Byte[],System.String)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.%23ctor(System.String,System.String,System.Security.Cryptography.X509Certificates.X509KeyStorageFlags)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.%23ctor(System.String,System.Security.SecureString)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.%23ctor(System.String,System.String)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.%23ctor(System.Byte[],System.Security.SecureString,System.Security.Cryptography.X509Certificates.X509KeyStorageFlags)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.%23ctor(System.Byte[],System.String,System.Security.Cryptography.X509Certificates.X509KeyStorageFlags)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.%23ctor(System.String,System.Security.SecureString,System.Security.Cryptography.X509Certificates.X509KeyStorageFlags)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.%23ctor(System.String,System.String,System.Security.Cryptography.X509Certificates.X509KeyStorageFlags)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2Collection.Import(System.Byte[])>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2Collection.Import(System.ReadOnlySpan{System.Byte})>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2Collection.Import(System.ReadOnlySpan{System.Byte})>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2Collection.Import(System.Byte[],System.String,System.Security.Cryptography.X509Certificates.X509KeyStorageFlags)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2Collection.Import(System.ReadOnlySpan{System.Byte},System.ReadOnlySpan{System.Char},System.Security.Cryptography.X509Certificates.X509KeyStorageFlags)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2Collection.Import(System.ReadOnlySpan{System.Byte},System.String,System.Security.Cryptography.X509Certificates.X509KeyStorageFlags)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2Collection.Import(System.String,System.ReadOnlySpan{System.Char},System.Security.Cryptography.X509Certificates.X509KeyStorageFlags)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2Collection.Import(System.String,System.String,System.Security.Cryptography.X509Certificates.X509KeyStorageFlags)>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.CreateFromSignedFile(System.String)>

## See also

- [API obsoletions with non-default diagnostic IDs (.NET 10)](../10.0/obsolete-apis.md)
- [API obsoletions with non-default diagnostic IDs (.NET 8)](../8.0/obsolete-apis-with-custom-diagnostics.md)
- [API obsoletions with non-default diagnostic IDs (.NET 7)](../7.0/obsolete-apis-with-custom-diagnostics.md)
- [API obsoletions with non-default diagnostic IDs (.NET 6)](../6.0/obsolete-apis-with-custom-diagnostics.md)
- [API obsoletions with non-default diagnostic IDs (.NET 5)](../5.0/obsolete-apis-with-custom-diagnostics.md)
- [Obsolete features in .NET 5+](../../../../fundamentals/syslib-diagnostics/obsoletions-overview.md)
