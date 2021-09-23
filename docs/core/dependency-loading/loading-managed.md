---
title: Managed assembly loading algorithm - .NET Core
description: Description of the details of the managed assembly loading algorithm in .NET Core
ms.date: 08/09/2019
author: sdmaclea
---
# Managed assembly loading algorithm

Managed assemblies are located and loaded with an algorithm involving various stages.

All managed assemblies except satellite assemblies and `WinRT` assemblies use the same algorithm.

## When are managed assemblies loaded?

The most common mechanism to trigger a managed assembly load is a static assembly reference. These references are inserted by the compiler whenever code uses a type defined in another assembly. These assemblies are loaded (`load-by-name`) as needed by the runtime.

The direct use of specific APIs will also trigger loads:

|API  |Description  |`Active` <xref:System.Runtime.Loader.AssemblyLoadContext> |
|---------|---------|---------|
|<xref:System.Runtime.Loader.AssemblyLoadContext.LoadFromAssemblyName%2A?displayProperty=nameWithType>|`Load-by-name`|The [this](../../csharp/language-reference/keywords/this.md) instance.|
|<xref:System.Runtime.Loader.AssemblyLoadContext.LoadFromAssemblyPath%2A?displayProperty=nameWithType><p><xref:System.Runtime.Loader.AssemblyLoadContext.LoadFromNativeImagePath%2A?displayProperty=nameWithType>|Load from path.|The [this](../../csharp/language-reference/keywords/this.md) instance.|
<xref:System.Runtime.Loader.AssemblyLoadContext.LoadFromStream%2A?displayProperty=nameWithType>|Load from object.|The [this](../../csharp/language-reference/keywords/this.md) instance.|
|<xref:System.Reflection.Assembly.LoadFile%2A?displayProperty=nameWithType>|Load from path in a new <xref:System.Runtime.Loader.AssemblyLoadContext> instance|The new <xref:System.Runtime.Loader.AssemblyLoadContext> instance.|
<xref:System.Reflection.Assembly.LoadFrom%2A?displayProperty=nameWithType>|Load from path in the <xref:System.Runtime.Loader.AssemblyLoadContext.Default%2A?displayProperty=nameWithType> instance.<p>Adds a <xref:System.Runtime.Loader.AssemblyLoadContext.Resolving> handler to <xref:System.Runtime.Loader.AssemblyLoadContext.Default%2A?displayProperty=nameWithType>. The handler will load the assembly's dependencies from its directory.|The <xref:System.Runtime.Loader.AssemblyLoadContext.Default%2A?displayProperty=nameWithType> instance.|
|<xref:System.Reflection.Assembly.Load(System.Reflection.AssemblyName)?displayProperty=nameWithType><p><xref:System.Reflection.Assembly.Load(System.String)?displayProperty=nameWithType><p><xref:System.Reflection.Assembly.LoadWithPartialName%2A?displayProperty=nameWithType>|`Load-by-name`.|Inferred from caller.<p>Prefer <xref:System.Runtime.Loader.AssemblyLoadContext> methods.|
|<xref:System.Reflection.Assembly.Load(System.Byte[])?displayProperty=nameWithType><p><xref:System.Reflection.Assembly.Load(System.Byte[],System.Byte[])?displayProperty=nameWithType>|Load from object in a new <xref:System.Runtime.Loader.AssemblyLoadContext> instance.|The new <xref:System.Runtime.Loader.AssemblyLoadContext> instance.|
<xref:System.Type.GetType(System.String)?displayProperty=nameWithType><p><xref:System.Type.GetType(System.String,System.Boolean)?displayProperty=nameWithType><p><xref:System.Type.GetType(System.String,System.Boolean,System.Boolean)?displayProperty=nameWithType>|`Load-by-name`.|Inferred from caller.<p>Prefer <xref:System.Type.GetType%2A?displayProperty=nameWithType> methods with an `assemblyResolver` argument.|
<xref:System.Reflection.Assembly.GetType%2A?displayProperty=nameWithType>|If type `name` describes an assembly qualified generic type, trigger a `Load-by-name`.|Inferred from caller.<p>Prefer <xref:System.Type.GetType%2A?displayProperty=nameWithType> when using assembly qualified type names.|
<xref:System.Activator.CreateInstance(System.String,System.String)?displayProperty=nameWithType><p><xref:System.Activator.CreateInstance(System.String,System.String,System.Object[])?displayProperty=nameWithType><p><xref:System.Activator.CreateInstance(System.String,System.String,System.Boolean,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object[],System.Globalization.CultureInfo,System.Object[])?displayProperty=nameWithType>|`Load-by-name`.|Inferred from caller.<p>Prefer <xref:System.Activator.CreateInstance%2A?displayProperty=nameWithType> methods taking a <xref:System.Type> argument.|

## Algorithm

The following algorithm describes how the runtime loads a managed assembly.

1. Determine the `active` <xref:System.Runtime.Loader.AssemblyLoadContext>.

    - For a static assembly reference, the `active` <xref:System.Runtime.Loader.AssemblyLoadContext> is the instance that loaded the referring assembly.
    - Preferred APIs make the `active` <xref:System.Runtime.Loader.AssemblyLoadContext> explicit.
    - Other APIs infer the `active` <xref:System.Runtime.Loader.AssemblyLoadContext>. For these APIs, the <xref:System.Runtime.Loader.AssemblyLoadContext.CurrentContextualReflectionContext?displayProperty=nameWithType> property is used. If its value is `null`, then the inferred <xref:System.Runtime.Loader.AssemblyLoadContext> instance is used.
    - See table above.

2. For the `Load-by-name` methods, the `active` <xref:System.Runtime.Loader.AssemblyLoadContext> loads the assembly. In priority order by:
    - Checking its `cache-by-name`.

    - Calling the <xref:System.Runtime.Loader.AssemblyLoadContext.Load%2A?displayProperty=nameWithType> function.

    - Checking the <xref:System.Runtime.Loader.AssemblyLoadContext.Default%2A?displayProperty=nameWithType> instance's cache and running [managed assembly default probing](default-probing.md#managed-assembly-default-probing) logic.

      - If an assembly is newly loaded, a reference is added to the <xref:System.Runtime.Loader.AssemblyLoadContext.Default%2A?displayProperty=nameWithType> instance's `cache-by-name`.

    - Raising the <xref:System.Runtime.Loader.AssemblyLoadContext.Resolving?displayProperty=nameWithType> event for the active AssemblyLoadContext.

    - Raising the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event.

3. For the other types of loads, the `active` <xref:System.Runtime.Loader.AssemblyLoadContext> loads the assembly. In priority order by:
    - Checking its `cache-by-name`.

    - Loading from the specified path or raw assembly object.

      - If an assembly is newly loaded, a reference is added to `active` <xref:System.Runtime.Loader.AssemblyLoadContext> instance's `cache-by-name`.

4. In either case, if an assembly is newly loaded, then:
   - The <xref:System.AppDomain.AssemblyLoad?displayProperty=nameWithType> event is raised.
