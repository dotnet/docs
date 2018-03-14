---
title: "Best Practices for Assembly Loading"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "assemblies,binding"
  - "LoadFrom method"
  - "default load context"
  - "TypeLoadException class,causes"
  - "assembly loading errors"
  - "load contexts"
  - "assemblies,loading"
  - "LoadWithPartialName method"
  - "load-from context"
ms.assetid: 68d1c539-6a47-4614-ab59-4b071c9d4b4c
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Best Practices for Assembly Loading
This article discusses ways to avoid problems of type identity that can lead to <xref:System.InvalidCastException>, <xref:System.MissingMethodException>, and other errors. The article discusses the following recommendations:  
  
-   [Understand the advantages and disadvantages of load contexts](#load_contexts)  
  
-   [Avoid binding on partial assembly names](#avoid_partial_names)  
  
-   [Avoid loading an assembly into multiple contexts](#avoid_loading_into_multiple_contexts)  
  
-   [Avoid loading multiple versions of an assembly into the same context](#avoid_loading_multiple_versions)  
  
-   [Consider switching to the default load context](#switch_to_default)  
  
 The first recommendation, [understand the advantages and disadvantages of load contexts](#load_contexts), provides background information for the other recommendations, because they all depend on a knowledge of load contexts.  
  
<a name="load_contexts"></a>   
## Understand the Advantages and Disadvantages of Load Contexts  
 Within an application domain, assemblies can be loaded into one of three contexts, or they can be loaded without context:  
  
-   The default load context contains assemblies found by probing the global assembly cache, the host assembly store if the runtime is hosted (for example, in SQL Server), and the <xref:System.AppDomainSetup.ApplicationBase%2A> and <xref:System.AppDomainSetup.PrivateBinPath%2A> of the application domain. Most overloads of the <xref:System.Reflection.Assembly.Load%2A> method load assemblies into this context.  
  
-   The load-from context contains assemblies that are loaded from locations that are not searched by the loader. For example, add-ins might be installed in a directory that is not under the application path. <xref:System.Reflection.Assembly.LoadFrom%2A?displayProperty=nameWithType>, <xref:System.AppDomain.CreateInstanceFrom%2A?displayProperty=nameWithType>, and <xref:System.AppDomain.ExecuteAssembly%2A?displayProperty=nameWithType> are examples of methods that load by path.  
  
-   The reflection-only context contains assemblies loaded with the <xref:System.Reflection.Assembly.ReflectionOnlyLoad%2A> and <xref:System.Reflection.Assembly.ReflectionOnlyLoadFrom%2A> methods. Code in this context cannot be executed, so it is not discussed here. For more information, see [How to: Load Assemblies into the Reflection-Only Context](../../../docs/framework/reflection-and-codedom/how-to-load-assemblies-into-the-reflection-only-context.md).  
  
-   If you generated a transient dynamic assembly by using reflection emit, the assembly is not in any context. In addition, most assemblies that are loaded by using the <xref:System.Reflection.Assembly.LoadFile%2A> method are loaded without context, and assemblies that are loaded from byte arrays are loaded without context unless their identity (after policy is applied) establishes that they are in the global assembly cache.  
  
 The execution contexts have advantages and disadvantages, as discussed in the following sections.  
  
### Default Load Context  
 When assemblies are loaded into the default load context, their dependencies are loaded automatically. Dependencies that are loaded into the default load context are found automatically for assemblies in the default load context or the load-from context. Loading by assembly identity increases the stability of applications by ensuring that unknown versions of assemblies are not used (see the [Avoid Binding on Partial Assembly Names](#avoid_partial_names) section).  
  
 Using the default load context has the following disadvantages:  
  
-   Dependencies that are loaded into other contexts are not available.  
  
-   You cannot load assemblies from locations outside the probing path into the default load context.  
  
### Load-From Context  
 The load-from context lets you load an assembly from a path that is not under the application path, and therefore is not included in probing. It enables dependencies to be located and loaded from that path, because the path information is maintained by the context. In addition, assemblies in this context can use dependencies that are loaded into the default load context.  
  
 Loading assemblies by using the <xref:System.Reflection.Assembly.LoadFrom%2A?displayProperty=nameWithType> method, or one of the other methods that load by path, has the following disadvantages:  
  
-   If an assembly with the same identity is already loaded, <xref:System.Reflection.Assembly.LoadFrom%2A> returns the loaded assembly even if a different path was specified.  
  
-   If an assembly is loaded with <xref:System.Reflection.Assembly.LoadFrom%2A>, and later an assembly in the default load context tries to load the same assembly by display name, the load attempt fails. This can occur when an assembly is deserialized.  
  
-   If an assembly is loaded with <xref:System.Reflection.Assembly.LoadFrom%2A>, and the probing path includes an assembly with the same identity but in a different location, an <xref:System.InvalidCastException>, <xref:System.MissingMethodException>, or other unexpected behavior can occur.  
  
-   <xref:System.Reflection.Assembly.LoadFrom%2A> demands <xref:System.Security.Permissions.FileIOPermissionAccess.Read?displayProperty=nameWithType> and <xref:System.Security.Permissions.FileIOPermissionAccess.PathDiscovery?displayProperty=nameWithType>, or <xref:System.Net.WebPermission>, on the specified path.  
  
-   If a native image exists for the assembly, it is not used.  
  
-   The assembly cannot be loaded as domain-neutral.  
  
-   In the .NET Framework versions 1.0 and 1.1, policy is not applied.  
  
### No Context  
 Loading without context is the only option for transient assemblies that are generated with reflection emit. Loading without context is the only way to load multiple assemblies that have the same identity into one application domain. The cost of probing is avoided.  
  
 Assemblies that are loaded from byte arrays are loaded without context unless the identity of the assembly, which is established when policy is applied, matches the identity of an assembly in the global assembly cache; in that case, the assembly is loaded from the global assembly cache.  
  
 Loading assemblies without context has the following disadvantages:  
  
-   Other assemblies cannot bind to assemblies that are loaded without context, unless you handle the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event.  
  
-   Dependencies are not loaded automatically. You can preload them without context, preload them into the default load context, or load them by handling the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event.  
  
-   Loading multiple assemblies with the same identity without context can cause type identity problems similar to those caused by loading assemblies with the same identity into multiple contexts. See [Avoid Loading an Assembly into Multiple Contexts](#avoid_loading_into_multiple_contexts).  
  
-   If a native image exists for the assembly, it is not used.  
  
-   The assembly cannot be loaded as domain-neutral.  
  
-   In the .NET Framework versions 1.0 and 1.1, policy is not applied.  
  
<a name="avoid_partial_names"></a>   
## Avoid Binding on Partial Assembly Names  
 Partial name binding occurs when you specify only part of the assembly display name (<xref:System.Reflection.Assembly.FullName%2A>) when you load an assembly. For example, you might call the <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> method with only the simple name of the assembly, omitting the version, culture, and public key token. Or you might call the <xref:System.Reflection.Assembly.LoadWithPartialName%2A?displayProperty=nameWithType> method, which first calls the <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> method and, if that fails to locate the assembly, searches the global assembly cache and loads the latest available version of the assembly.  
  
 Partial name binding can cause many problems, including the following:  
  
-   The <xref:System.Reflection.Assembly.LoadWithPartialName%2A?displayProperty=nameWithType> method might load a different assembly with the same simple name. For example, two applications might install two completely different assemblies that both have the simple name `GraphicsLibrary` into the global assembly cache.  
  
-   The assembly that is actually loaded might not be backward-compatible. For example, not specifying the version might result in the loading of a much later version than the version your program was originally written to use. Changes in the later version might cause errors in your application.  
  
-   The assembly that is actually loaded might not be forward-compatible. For example, you might have built and tested your application with the latest version of an assembly, but partial binding might load a much earlier version that lacks features your application uses.  
  
-   Installing new applications can break existing applications. An application that uses the <xref:System.Reflection.Assembly.LoadWithPartialName%2A> method can be broken by installing a newer, incompatible version of a shared assembly.  
  
-   Unexpected dependency loading can occur. It you load two assemblies that share a dependency, loading them with partial binding might result in one assembly using a component that it was not built or tested with.  
  
 Because of the problems it can cause, the <xref:System.Reflection.Assembly.LoadWithPartialName%2A> method has been marked obsolete. We recommend that you use the <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> method instead, and specify full assembly display names. See [Understand the Advantages and Disadvantages of Load Contexts](#load_contexts) and [Consider Switching to the Default Load Context](#switch_to_default).  
  
 If you want to use the <xref:System.Reflection.Assembly.LoadWithPartialName%2A> method because it makes assembly loading easy, consider that having your application fail with an error message that identifies the missing assembly is likely to provide a better user experience than automatically using an unknown version of the assembly, which might cause unpredictable behavior and security holes.  
  
<a name="avoid_loading_into_multiple_contexts"></a>   
## Avoid Loading an Assembly into Multiple Contexts  
 Loading an assembly into multiple contexts can cause type identity problems. If the same type is loaded from the same assembly into two different contexts, it is as if two different types with the same name had been loaded. An <xref:System.InvalidCastException> is thrown if you try to cast one type to the other, with the confusing message that type `MyType` cannot be cast to type `MyType`.  
  
 For example, suppose that the `ICommunicate` interface is declared in an assembly named `Utility`, which is referenced by your program and also by other assemblies that your program loads. These other assemblies contain types that implement the `ICommunicate` interface, allowing your program to use them.  
  
 Now consider what happens when your program is run. Assemblies that are referenced by your program are loaded into the default load context. If you load a target assembly by its identity, using the <xref:System.Reflection.Assembly.Load%2A> method, it will be in the default load context, and so will its dependencies. Both your program and the target assembly will use the same `Utility` assembly.  
  
 However, suppose you load the target assembly by its file path, using the <xref:System.Reflection.Assembly.LoadFile%2A> method. The assembly is loaded without any context, so its dependencies are not automatically loaded. You might have a handler for the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event to supply the dependency, and it might load the `Utility` assembly with no context by using the <xref:System.Reflection.Assembly.LoadFile%2A> method. Now when you create an instance of a type that is contained in the target assembly and try to assign it to a variable of type `ICommunicate`, an <xref:System.InvalidCastException> is thrown because the runtime considers the `ICommunicate` interfaces in the two copies of the `Utility` assembly to be different types.  
  
 There are many other scenarios in which an assembly can be loaded into multiple contexts. The best approach is to avoid conflicts by relocating the target assembly in your application path and using the <xref:System.Reflection.Assembly.Load%2A> method with the full display name. The assembly is then loaded into the default load context, and both assemblies use the same `Utility` assembly.  
  
 If the target assembly must remain outside your application path, you can use the <xref:System.Reflection.Assembly.LoadFrom%2A> method to load it into the load-from context. If the target assembly was compiled with a reference to your application's `Utility` assembly, it will use the `Utility` assembly that your application has loaded into the default load context. Note that problems can occur if the target assembly has a dependency on a copy of the `Utility` assembly located outside your application path. If that assembly is loaded into the load-from context before your application loads the `Utility` assembly, your application's load will fail.  
  
 The [Consider Switching to the Default Load Context](#switch_to_default) section discusses alternatives to using file path loads such as <xref:System.Reflection.Assembly.LoadFile%2A> and <xref:System.Reflection.Assembly.LoadFrom%2A>.  
  
<a name="avoid_loading_multiple_versions"></a>   
## Avoid Loading Multiple Versions of an Assembly into the Same Context  
 Loading multiple versions of an assembly into one load context can cause type identity problems. If the same type is loaded from two versions of the same assembly, it is as if two different types with the same name had been loaded. An <xref:System.InvalidCastException> is thrown if you try to cast one type to the other, with the confusing message that type `MyType` cannot be cast to type `MyType`.  
  
 For example, your program might load one version of the `Utility` assembly directly, and later it might load another assembly that loads a different version of the `Utility` assembly. Or a coding error might cause two different code paths in your application to load different versions of an assembly.  
  
 In the default load context, this problem can occur when you use the <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> method and specify complete assembly display names that include different version numbers. For assemblies that are loaded without context, the problem can be caused by using the <xref:System.Reflection.Assembly.LoadFile%2A?displayProperty=nameWithType> method to load the same assembly from different paths. The runtime considers two assemblies that are loaded from different paths to be different assemblies, even if their identities are the same.  
  
 In addition to type identity problems, multiple versions of an assembly can cause a <xref:System.MissingMethodException> if a type that is loaded from one version of the assembly is passed to code that expects that type from a different version. For example, the code might expect a method that was added to the later version.  
  
 More subtle errors can occur if the behavior of the type changed between versions. For example, a method might throw an unexpected exception or return an unexpected value.  
  
 Carefully review your code to ensure that only one version of an assembly is loaded. You can use the <xref:System.AppDomain.GetAssemblies%2A?displayProperty=nameWithType> method to determine which assemblies are loaded at any given time.  
  
<a name="switch_to_default"></a>   
## Consider Switching to the Default Load Context  
 Examine your application's assembly loading and deployment patterns. Can you eliminate assemblies that are loaded from byte arrays? Can you move assemblies into the probing path? If assemblies are located in the global assembly cache or in the application domain's probing path (that is, its <xref:System.AppDomainSetup.ApplicationBase%2A> and <xref:System.AppDomainSetup.PrivateBinPath%2A>), you can load the assembly by its identity.  
  
 If it is not possible to put all your assemblies in the probing path, consider alternatives such as using the .NET Framework add-in model, placing assemblies into the global assembly cache, or creating application domains.  
  
### Consider Using the .NET Framework Add-In Model  
 If you are using the load-from context to implement add-ins, which typically are not installed in the application base, use the .NET Framework add-in model. This model provides isolation at the application domain or process level, without requiring you to manage application domains yourself. For information about the add-in model, see [Add-ins and Extensibility](../../../docs/framework/add-ins/index.md).  
  
### Consider Using the Global Assembly Cache  
 Place assemblies in the global assembly cache to get the benefit of a shared assembly path that is outside the application base, without losing the advantages of the default load context or taking on the disadvantages of the other contexts.  
  
### Consider Using Application Domains  
 If you determine that some of your assemblies cannot be deployed in the application's probing path, consider creating a new application domain for those assemblies. Use an <xref:System.AppDomainSetup> to create the new application domain, and use the <xref:System.AppDomainSetup.ApplicationBase%2A?displayProperty=nameWithType> property to specify the path that contains the assemblies you want to load. If you have multiple directories to probe, you can set the <xref:System.AppDomainSetup.ApplicationBase%2A> to a root directory and use the <xref:System.AppDomainSetup.PrivateBinPath%2A?displayProperty=nameWithType> property to identify the subdirectories to probe. Alternatively, you can create multiple application domains and set the <xref:System.AppDomainSetup.ApplicationBase%2A> of each application domain to the appropriate path for its assemblies.  
  
 Note that you can use the <xref:System.Reflection.Assembly.LoadFrom%2A?displayProperty=nameWithType> method to load these assemblies. Because they are now in the probing path, they will be loaded into the default load context instead of the load-from context. However, we recommend that you switch to the <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> method and supply full assembly display names to ensure that correct versions are always used.  
  
## See Also  
 <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType>  
 <xref:System.Reflection.Assembly.LoadFrom%2A?displayProperty=nameWithType>  
 <xref:System.Reflection.Assembly.LoadFile%2A?displayProperty=nameWithType>  
 <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType>  
 [Add-ins and Extensibility](../../../docs/framework/add-ins/index.md)
