---
title: "How to: Load Assemblies into an Application Domain"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "application domains, loading assemblies"
  - "loading assemblies"
ms.assetid: 1432aa2d-bd83-4346-bf3b-a1b7920e2aa9
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Load Assemblies into an Application Domain
There are several ways to load an assembly into an application domain. The recommended way is to use the `static` (`Shared` in Visual Basic) <xref:System.Reflection.Assembly.Load%2A> method of the <xref:System.Reflection.Assembly?displayProperty=nameWithType> class. Other ways assemblies can be loaded include:  
  
-   The <xref:System.Reflection.Assembly.LoadFrom%2A> method of the <xref:System.Reflection.Assembly> class loads an assembly given its file location. Loading assemblies with this method uses a different load context.  
  
-   The <xref:System.Reflection.Assembly.ReflectionOnlyLoad%2A> and <xref:System.Reflection.Assembly.ReflectionOnlyLoadFrom%2A> methods load an assembly into the reflection-only context. Assemblies loaded into this context can be examined but not executed, allowing the examination of assemblies that target other platforms. See [How to: Load Assemblies into the Reflection-Only Context](../../../docs/framework/reflection-and-codedom/how-to-load-assemblies-into-the-reflection-only-context.md).  
  
> [!NOTE]
>  The reflection-only context is new in the .NET Framework version 2.0.  
  
-   Methods such as <xref:System.AppDomain.CreateInstance%2A> and <xref:System.AppDomain.CreateInstanceAndUnwrap%2A> of the <xref:System.AppDomain> class can load assemblies into an application domain.  
  
-   The <xref:System.Type.GetType%2A> method of the <xref:System.Type> class can load assemblies.  
  
-   The <xref:System.AppDomain.Load%2A> method of the <xref:System.AppDomain?displayProperty=nameWithType> class can load assemblies, but is primarily used for COM interoperability. It should not be used to load assemblies into an application domain other than the application domain from which it is called.  
  
> [!NOTE]
>  Starting with the .NET Framework version 2.0, the runtime will not load an assembly that was compiled with a version of the .NET Framework that has a higher version number than the currently loaded runtime. This applies to the combination of the major and minor components of the version number.  
  
 You can specify the way the just-in-time (JIT) compiled code from loaded assemblies is shared between application domains. For more information, see [Application Domains and Assemblies](http://msdn.microsoft.com/library/433b04ae-4ba8-4849-9dbd-79194f240346).  
  
## Example  
 The following code loads an assembly named "example.exe" or "example.dll" into the current application domain, gets a type named `Example` from the assembly, gets a parameterless method named `MethodA` for that type, and executes the method. For a complete discussion on obtaining information from a loaded assembly, see [Dynamically Loading and Using Types](../../../docs/framework/reflection-and-codedom/dynamically-loading-and-using-types.md).  
  
 [!code-cpp[System.AppDomain.Load#2](../../../samples/snippets/cpp/VS_Snippets_CLR_System/system.appdomain.load/cpp/source2.cpp#2)]
 [!code-csharp[System.AppDomain.Load#2](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.appdomain.load/cs/source2.cs#2)]
 [!code-vb[System.AppDomain.Load#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.appdomain.load/vb/source2.vb#2)]  
  
## See Also  
 <xref:System.Reflection.Assembly.ReflectionOnlyLoad%2A>  
 [Programming with Application Domains](application-domains.md#programming-with-application-domains)  
 [Reflection](../../../docs/framework/reflection-and-codedom/reflection.md)  
 [Using Application Domains](../../../docs/framework/app-domains/use.md)  
 [How to: Load Assemblies into the Reflection-Only Context](../../../docs/framework/reflection-and-codedom/how-to-load-assemblies-into-the-reflection-only-context.md)  
 [Application Domains and Assemblies](http://msdn.microsoft.com/library/433b04ae-4ba8-4849-9dbd-79194f240346)
