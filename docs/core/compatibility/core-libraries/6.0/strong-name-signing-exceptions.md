---
title: "Breaking change: Strong-name APIs throw PlatformNotSupportedException"
description: Learn about the .NET 6 breaking change in core .NET libraries where an exception is thrown in StrongNameKeyPair constructors and AssemblyName.KeyPair.
ms.date: 05/31/2022
ms.topic: concept-article
---
# Strong-name APIs throw PlatformNotSupportedException

A few [APIs](#affected-apis) that aren't supported in .NET/.NET Core but didn't do anything when accessed have been changed to now throw a <xref:System.PlatformNotSupportedException> at run time. Previously, using these APIs would eventually result in a run-time exception further along; the exception is now thrown when the type is instantiated or first accessed.

## Previous behavior

In previous versions, calling <xref:System.Reflection.AssemblyName.KeyPair?displayProperty=nameWithType> or <xref:System.Reflection.StrongNameKeyPair.%23ctor(System.Byte[])> was a no-op. Calling <xref:System.Reflection.StrongNameKeyPair.%23ctor(System.IO.FileStream)> read the stream but otherwise did nothing.

## New behavior

Starting in .NET 6, each of the three affected APIs throws a <xref:System.PlatformNotSupportedException> at run time.

## Version introduced

.NET 6

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

Previously, an application that called the API compiled and ran, but as soon as the instance was used in any code path, it threw a run-time exception. To make it more explicit that this scenario is unsupported, the exception-throwing logic was moved into the instance constructor. In case no instances are created, the exception is also thrown in public entry points that return this type, that is, <xref:System.Reflection.AssemblyName.KeyPair?displayProperty=nameWithType>.

## Recommended action

Strong-name signing is not supported in .NET/.NET Core, and there is no workaround.

> [!NOTE]
> .NET Core/5+ never checks signatures in its runtime. However, if you're targeting cross-platform libraries (for example, a basic auth package that targets .NET Standard 2.0, so it runs on .NET Framework too), then strong-naming is a good idea for cross-runtime compatibility. .NET Framework continues to enforce strong naming if the calling app is strong-named. You can strong-name assemblies in all versions of .NET using the [Sn.exe](../../../../framework/tools/sn-exe-strong-name-tool.md) tool. For more information, see [Strong name signing](https://github.com/dotnet/runtime/blob/main/docs/project/strong-name-signing.md).

## Affected APIs

- <xref:System.Reflection.StrongNameKeyPair.%23ctor(System.IO.FileStream)>
- <xref:System.Reflection.StrongNameKeyPair.%23ctor(System.Byte[])>
- <xref:System.Reflection.AssemblyName.KeyPair?displayProperty=fullName>

## See also

- [How to: Sign an assembly with a strong name](../../../../standard/assembly/sign-strong-name.md)
