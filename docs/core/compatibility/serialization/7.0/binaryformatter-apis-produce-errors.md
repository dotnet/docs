---
title: "Breaking change: BinaryFormatter serialization APIs produce compiler errors"
description: Learn about the .NET 7 breaking change in core .NET libraries where serialize and deserialize methods on BinaryFormatter, Formatter, and IFormatter are obsolete as errors.
ms.date: 08/08/2022
ms.topic: concept-article
---
# BinaryFormatter serialization APIs produce compiler errors

As part of the BinaryFormatter [long-term deprecation plan](https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md), we continue to cull `BinaryFormatter` functionality from our libraries and to wean developers off of the type. Starting in .NET 7, calls to the following APIs produce compile-time errors across all C# and Visual Basic project types:

- <xref:System.Exception.SerializeObjectState?displayProperty=fullName> event
- <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Serialize%2A?displayProperty=nameWithType> method
- <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize%2A?displayProperty=nameWithType> method
- <xref:System.Runtime.Serialization.Formatter.Serialize(System.IO.Stream,System.Object)?displayProperty=nameWithType> method
- <xref:System.Runtime.Serialization.Formatter.Deserialize(System.IO.Stream)?displayProperty=nameWithType> method
- <xref:System.Runtime.Serialization.IFormatter.Serialize(System.IO.Stream,System.Object)?displayProperty=nameWithType> method
- <xref:System.Runtime.Serialization.IFormatter.Deserialize(System.IO.Stream)?displayProperty=nameWithType> method

## Previous behavior

Since .NET 5, using the affected `Serialize` and `Deserialize` methods produced a compiler *warning* with ID `SYSLIB0011`. For more information, see [BinaryFormatter serialization methods are obsolete and prohibited in ASP.NET apps (.NET 5)](../5.0/binaryformatter-serialization-obsolete.md).

Using the <xref:System.Exception.SerializeObjectState?displayProperty=nameWithType> event did not produce an error.

## New behavior

Starting in .NET 7, using any of the [affected APIs](#affected-apis) in code produces a compiler *error* with the same ID, `SYSLIB0011`. Your project will be affected if it meets all of the following criteria:

- It's a C# or Visual Basic project.
- It targets `net7.0` or higher.
- It directly calls one of the [affected APIs](#affected-apis).
- It's not already suppressing the `SYSLIB0011` warning code.

## Version introduced

.NET 7

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

As part of the BinaryFormatter [long-term deprecation plan](https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md), we continue to cull `BinaryFormatter` functionality from our libraries and to wean developers off of the type.

## Recommended action

The best course of action is to migrate away from `BinaryFormatter` due to its security and reliability flaws. `BinaryFormatter` may be removed from .NET in a future release. The .NET libraries team has already taken a stance that recent types such as <xref:System.Half?displayProperty=fullName> and <xref:System.DateOnly?displayProperty=fullName> won't be compatible with `BinaryFormatter`.

If you must suppress the errors, you can do so by following the guidelines in the [original obsoletion article](../5.0/binaryformatter-serialization-obsolete.md#recommended-action). You can also disable the error project-wide by setting a project property that converts the error back to a warning (to match the .NET 5/6 behavior).

> [!WARNING]
> Setting this property might change host behavior. See [\<EnableUnsafeBinaryFormatterSerialization> property](#enableunsafebinaryformatterserialization-property).

```csharp
<PropertyGroup>
    ...
    <EnableUnsafeBinaryFormatterSerialization>true</EnableUnsafeBinaryFormatterSerialization>
</PropertyGroup>
```

> [!NOTE]
> If your project compiles with "warnings as errors" enabled, compilation will still fail. (This matches the behavior that shipped in the .NET 5 and .NET 6 SDKs.) If that's the case, you'll still need to suppress the `SYSLIB0011` warning in source or in your project file's `<NoWarn>` element.

### \<EnableUnsafeBinaryFormatterSerialization> property

The `<EnableUnsafeBinaryFormatterSerialization` property was introduced in .NET 5. With .NET 7, the behavior of this switch has changed to control *both compilation and host* run-time behavior. The meaning of this switch differs based on the project type, as described in the following table.

| Type of project | Property set to `true` | Property set to `false` | Property omitted |
| - | - | - | - |
| Library/shared component<sup>1</sup> | The affected APIs are obsolete as warning. Compilation will succeed unless you have "warnings as errors" enabled for your application or you've suppressed the `SYSLIB0011` warning code. | The affected APIs are obsolete as error, and calls from your code to those APIs will fail at compile time unless the error is suppressed. | (Same as for `false`.) |
| Blazor and MAUI apps<sup>2</sup> | Calls to `BinaryFormatter` will fail at run time. | Calls to `BinaryFormatter` will fail at run time. | Calls to `BinaryFormatter` will fail at run time. |
| ASP.NET app | The affected APIs are obsolete as warning. Compilation will succeed unless you have "warnings as errors" enabled for your application or you've suppressed the `SYSLIB0011` warning code. The runtime will *allow* calls to `BinaryFormatter`, regardless of whether the call originates from your code or from a dependency that you consume. | The affected APIs are obsolete as error, and calls from your code to those APIs will fail at compile time unless the error is suppressed. The runtime will *forbid* calls to `BinaryFormatter`, regardless of whether the call originates from your code or from a dependency that you consume. | (Same as for `false`.) |
| Desktop apps and all other app types | The affected APIs are obsolete as warning. Compilation will succeed unless you have "warnings as errors" enabled for your application or you've suppressed the `SYSLIB0011` warning code. The runtime will *allow* calls to `BinaryFormatter`, regardless of whether the call originates from your code or from a dependency that you consume. | The affected APIs are obsolete as error, and calls from your code to those APIs will fail at compile time unless the error is suppressed. The runtime will *forbid* calls to `BinaryFormatter`, regardless of whether the call originates from your code or from a dependency that you consume. | The affected APIs are obsolete as error, and calls from your code to those APIs will fail at compile time unless the error is suppressed. The runtime will *allow* calls to `BinaryFormatter`, regardless of whether the call originates from your code or from a dependency that you consume. |

<sup>1</sup>Runtime policy is controlled by the app host. Calls into `BinaryFormatter` might still fail at run time even if `<EnableUnsafeBinaryFormatterSerialization>` is set to `true` within your library's project file. Libraries can't override the app host's runtime policy.

<sup>2</sup>The Blazor and MAUI runtimes forbid calls to `BinaryFormatter`. Regardless of any value you set for `<EnableUnsafeBinaryFormatterSerialization>`, the calls will fail at run time. Don't call these APIs from Blazor or MAUI applications or from libraries intended to be consumed by Blazor or MAUI apps.

## Affected APIs

- <xref:System.Exception.SerializeObjectState?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Serialize%2A?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize%2A?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Formatter.Serialize(System.IO.Stream,System.Object)?displayProperty=fullName>
- <xref:System.Runtime.Serialization.Formatter.Deserialize(System.IO.Stream)?displayProperty=fullName>
- <xref:System.Runtime.Serialization.IFormatter.Serialize(System.IO.Stream,System.Object)?displayProperty=fullName>
- <xref:System.Runtime.Serialization.IFormatter.Deserialize(System.IO.Stream)?displayProperty=fullName>

## See also

- [dotnet/runtime issue 72132](https://github.com/dotnet/runtime/issues/72132)
- [BinaryFormatter serialization methods are obsolete (.NET 5)](../5.0/binaryformatter-serialization-obsolete.md)
- [SerializationFormat.Binary is obsolete (.NET 7)](../7.0/serializationformat-binary.md)
- [BinaryFormatter disabled across most project types (.NET 8)](../8.0/binaryformatter-disabled.md)
