---
title: "How to: Load Assemblies into the Reflection-Only Context"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "reflection, reflection-only loader context"
  - "assemblies [.NET Framework], loading for reflection"
  - "attributes [.NET Framework], retrieving"
  - "assemblies [.NET Framework], reflection-only loader context"
  - "reflection-only loader context"
ms.assetid: 9818b660-52f5-423d-a9af-e75163aa7068
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Load Assemblies into the Reflection-Only Context
The reflection-only load context allows you to examine assemblies compiled for other platforms or for other versions of the .NET Framework. Code loaded into this context can only be examined; it cannot be executed. This means that objects cannot be created, because constructors cannot be executed. Because the code cannot be executed, dependencies are not automatically loaded. If you need to examine them, you must load them yourself.  
  
### To load an assembly into the reflection-only load context  
  
1.  Use the <xref:System.Reflection.Assembly.ReflectionOnlyLoad%28System.String%29> method overload to load the assembly given its display name, or the <xref:System.Reflection.Assembly.ReflectionOnlyLoadFrom%2A> method to load the assembly given its path. If the assembly is a binary image, use the <xref:System.Reflection.Assembly.ReflectionOnlyLoad%28System.Byte%5B%5D%29> method overload.  
  
    > [!NOTE]
    >  You cannot use the reflection-only context to load a version of mscorlib.dll from a version of the .NET Framework other than the version in the execution context.  
  
2.  If the assembly has dependencies, the <xref:System.Reflection.Assembly.ReflectionOnlyLoad%2A> method does not load them. If you need to examine them, you must load them yourself,.  
  
3.  Determine whether an assembly is loaded into the reflection-only context by using the assembly's <xref:System.Reflection.Assembly.ReflectionOnly%2A> property.  
  
4.  If attributes have been applied to the assembly or to types in the assembly, examine those attributes by using the <xref:System.Reflection.CustomAttributeData> class to ensure that no attempt is made to execute code in the reflection-only context. Use the appropriate overload of the <xref:System.Reflection.CustomAttributeData.GetCustomAttributes%2A?displayProperty=nameWithType> method to obtain <xref:System.Reflection.CustomAttributeData> objects representing the attributes applied to an assembly, member, module, or parameter.  
  
    > [!NOTE]
    >  Attributes applied to the assembly or to its contents might be defined in the assembly, or they might be defined in another assembly loaded into the reflection-only context. There is no way to tell in advance where the attributes are defined.  
  
## Example  
 The following code example shows how to examine the attributes applied to an assembly loaded into the reflection-only context.  
  
 The code example defines a custom attribute with two constructors and one property. The attribute is applied to the assembly, to a type declared in the assembly, to a method of the type, and to a parameter of the method. When executed, the assembly loads itself into the reflection-only context and displays information about the custom attributes that were applied to it and to the types and members it contains.  
  
> [!NOTE]
>  To simplify the code example, the assembly loads and examines itself. Normally, you would not expect to find the same assembly loaded into both the execution context and the reflection-only context.  
  
 [!code-cpp[CustomAttributeData#1](../../../samples/snippets/cpp/VS_Snippets_CLR/CustomAttributeData/CPP/source.cpp#1)]
 [!code-csharp[CustomAttributeData#1](../../../samples/snippets/csharp/VS_Snippets_CLR/CustomAttributeData/CS/source.cs#1)]
 [!code-vb[CustomAttributeData#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CustomAttributeData/VB/source.vb#1)]  
  
## See Also  
 <xref:System.Reflection.Assembly.ReflectionOnlyLoad%2A>  
 <xref:System.Reflection.Assembly.ReflectionOnly%2A>  
 <xref:System.Reflection.CustomAttributeData>
