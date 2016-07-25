---
title: CompilerServices.TypeProviderConfig Class (F#)
description: CompilerServices.TypeProviderConfig Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 56dc12e1-f9bf-4af1-9d5a-8e415994cf31 
---

# CompilerServices.TypeProviderConfig Class (F#)

Provides additional customization options for a type provider implementation. If the class that implements [`ITypeProvider`](https://msdn.microsoft.com/library/2c2b0571-843d-4a7d-95d4-0a7510ed5e2f) has a constructor that accepts `TypeProviderConfig`, it will be constructed with an instance of `TypeProviderConfig`.

**Namespace/Module Path**: Microsoft.FSharp.Core.CompilerServices

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type [TypeProviderConfig](https://msdn.microsoft.com/library/1cda7b9a-3d07-475d-9315-d65e1c97eb44) =
class
new TypeProviderConfig : string * string * string [] * string -> TypeProviderConfig
member this.ReferencedAssemblies : string []
member this.ResolutionFolder : string
member this.RuntimeAssembly : string
member this.TemporaryFolder : string
end
```

## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/a58edc91-0eae-49b8-9331-81115832f7af)|Creates a new instance of **TypeProviderConfig**.|

## Instance Members


|Member|Description|
|------|-----------|
|IsInvalidationSupported : [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)|Indicates whether the type provider host responds to invalidation events for type provider instances.|
|IsHostedExecution : [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)|Indicates whether the type provider instance is used in an environment which executes provided code such as F# Interactive.|
|[ReferencedAssemblies](https://msdn.microsoft.com/library/24600287-d40a-4b38-a5e8-d903214dcef9) : [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a) []|Gets the set of referenced assemblies for the provider.|
|[ResolutionFolder](https://msdn.microsoft.com/library/3424c496-b38d-49cd-b4a4-869193f2baf6) : [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)|Gets the full path to use to resolve relative paths in any file name arguments given to the provider.|
|[RuntimeAssembly](https://msdn.microsoft.com/library/3ff43026-7d3a-4b8b-942b-f38e9bd5dfe1) : [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)|Gets the full path to actual referenced assembly that caused this type provider to load and instantiate.|
|[TemporaryFolder](https://msdn.microsoft.com/library/af72b3d0-9888-4d14-adce-e75ce35bf29c) : [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)|Gets the full path to use for temporary files for this instance of the provider.|
|SystemRuntimeAssemblyVersion : **System.Version**|Version of the referenced system runtime assembly.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Microsoft.FSharp.Core.CompilerServices Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core.CompilerServices-Namespace-%5BFSharp%5D.md)