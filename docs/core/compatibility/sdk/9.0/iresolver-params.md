---
title: "Breaking change: ILVerify.IResolver takes AssemblyNameInfo parameters"
description: Learn about a breaking change in the .NET 9 SDK where ILVerify.IResolver takes AssemblyNameInfo parameters.
ms.date: 08/07/2024
---
# ILVerify.IResolver takes AssemblyNameInfo parameters

In the `ILVerify.IResolver` interface defined in the Microsoft.ILVerification package, the type of the first parameter of each method is now <xref:System.Reflection.Metadata.AssemblyNameInfo> rather than <xref:System.Reflection.AssemblyName>.

## Previous behavior

Previously, the type of the first parameter was <xref:System.Reflection.AssemblyName>:

```csharp
namespace ILVerify
{
    public interface IResolver
    {
        PEReader ResolveAssembly(AssemblyName assemblyName);
        PEReader ResolveModule(AssemblyName referencingAssembly, string fileName);
    }
}
```

## New behavior

Starting in .NET 9, the type of the first parameter is <xref:System.Reflection.Metadata.AssemblyNameInfo>:

```csharp
namespace ILVerify
{
    public interface IResolver
    {
        PEReader ResolveAssembly(AssemblyNameInfo assemblyName);
        PEReader ResolveModule(AssemblyNameInfo referencingAssembly, string fileName);
    }
}
```

## Version introduced

.NET 9 Preview 5

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility) and [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This change avoids a dependency on <xref:System.Reflection.AssemblyName.CultureName> and globalization (ICU).

## Recommended action

If your application references the [Microsoft.ILVerification package](https://www.nuget.org/packages/Microsoft.ILVerification) and defines a type that implements the `ILVerify.IResolver` interface, change the implementation to take <xref:System.Reflection.Metadata.AssemblyNameInfo> parameters.

## Affected APIs

- `ILVerify.IResolver.ResolveAssembly`
- `ILVerify.IResolver.ResolveModule`
