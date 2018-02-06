---
title: "Viewing Type Information"
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
  - "types, viewing type information"
  - "Type object"
  - "viewing type information"
  - "reflection, viewing type information"
ms.assetid: 7e7303a9-4064-4738-b4e7-b75974ed70d2
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Viewing Type Information
The <xref:System.Type?displayProperty=nameWithType> class is central to reflection. The common language runtime creates the **Type** for a loaded type when reflection requests it. You can use a **Type** object's methods, fields, properties, and nested classes to find out everything about that type.  
  
 Use <xref:System.Reflection.Assembly.GetType%2A?displayProperty=nameWithType> or <xref:System.Reflection.Assembly.GetTypes%2A?displayProperty=nameWithType> to obtain **Type** objects from assemblies that have not been loaded, passing in the name of the type or types you want. Use <xref:System.Type.GetType%2A?displayProperty=nameWithType> to get the **Type** objects from an assembly that is already loaded. Use <xref:System.Reflection.Module.GetType%2A?displayProperty=nameWithType> and <xref:System.Reflection.Module.GetTypes%2A?displayProperty=nameWithType> to obtain module **Type** objects.  
  
> [!NOTE]
>  If you want to examine and manipulate generic types and methods, please see the additional information provided in [Reflection and Generic Types](../../../docs/framework/reflection-and-codedom/reflection-and-generic-types.md) and [How to: Examine and Instantiate Generic Types with Reflection](../../../docs/framework/reflection-and-codedom/how-to-examine-and-instantiate-generic-types-with-reflection.md).  
  
 The following example shows the syntax necessary to get the <xref:System.Reflection.Assembly> object and module for an assembly.  
  
 [!code-cpp[Conceptual.Types.ViewInfo#6](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.types.viewinfo/cpp/source5.cpp#6)]
 [!code-csharp[Conceptual.Types.ViewInfo#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.types.viewinfo/cs/source5.cs#6)]
 [!code-vb[Conceptual.Types.ViewInfo#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.types.viewinfo/vb/source5.vb#6)]  
  
 The following example demonstrates getting **Type** objects from a loaded assembly.  
  
 [!code-cpp[Conceptual.Types.ViewInfo#7](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.types.viewinfo/cpp/source5.cpp#7)]
 [!code-csharp[Conceptual.Types.ViewInfo#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.types.viewinfo/cs/source5.cs#7)]
 [!code-vb[Conceptual.Types.ViewInfo#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.types.viewinfo/vb/source5.vb#7)]  
  
 Once you obtain a **Type**, there are many ways you can discover information about the members of that type. For example, you can find out about all the type's members by calling the <xref:System.Type.GetMembers%2A?displayProperty=nameWithType> method, which obtains an array of <xref:System.Reflection.MemberInfo> objects describing each of the members of the current type.  
  
 You can also use methods on the **Type** class to retrieve information about one or more constructors, methods, events, fields, or properties that you specify by name. For example, <xref:System.Type.GetConstructor%2A?displayProperty=nameWithType> encapsulates a specific constructor of the current class.  
  
 If you have a **Type**, you can use the <xref:System.Type.Module%2A?displayProperty=nameWithType> property to obtain an object that encapsulates the module containing that type. Use the <xref:System.Reflection.Module.Assembly%2A?displayProperty=nameWithType> property to locate an object that encapsulates the assembly containing the module. You can obtain the assembly that encapsulates the type directly by using the <xref:System.Type.Assembly%2A?displayProperty=nameWithType> property.  
  
## System.Type and ConstructorInfo  
 The following example shows how to list the constructors for a class, in this case, the <xref:System.String> class.  
  
 [!code-cpp[Conceptual.Types.ViewInfo#1](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.types.viewinfo/cpp/source1.cpp#1)]
 [!code-csharp[Conceptual.Types.ViewInfo#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.types.viewinfo/cs/source1.cs#1)]
 [!code-vb[Conceptual.Types.ViewInfo#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.types.viewinfo/vb/source1.vb#1)]  
  
## MemberInfo, MethodInfo, FieldInfo, and PropertyInfo  
 Obtain information about the type's methods, properties, events, and fields using <xref:System.Reflection.MemberInfo>, <xref:System.Reflection.MethodInfo>, <xref:System.Reflection.FieldInfo>, or <xref:System.Reflection.PropertyInfo> objects.  
  
 The following example uses **MemberInfo** to list the number of members in the **System.IO.File** class and uses the <xref:System.Type.IsPublic%2A> property to determine the visibility of the class.  
  
 [!code-cpp[Conceptual.Types.ViewInfo#2](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.types.viewinfo/cpp/source2.cpp#2)]
 [!code-csharp[Conceptual.Types.ViewInfo#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.types.viewinfo/cs/source2.cs#2)]
 [!code-vb[Conceptual.Types.ViewInfo#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.types.viewinfo/vb/source2.vb#2)]  
  
 The following example investigates the type of the specified member. It performs reflection on a member of the **MemberInfo** class, and lists its type.  
  
 [!code-cpp[Conceptual.Types.ViewInfo#3](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.types.viewinfo/cpp/source3.cpp#3)]
 [!code-csharp[Conceptual.Types.ViewInfo#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.types.viewinfo/cs/source3.cs#3)]
 [!code-vb[Conceptual.Types.ViewInfo#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.types.viewinfo/vb/source3.vb#3)]  
  
 The following example uses all the Reflection **\*Info** classes along with <xref:System.Reflection.BindingFlags> to list all the members (constructors, fields, properties, events, and methods) of the specified class, dividing the members into static and instance categories.  
  
 [!code-cpp[Conceptual.Types.ViewInfo#4](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.types.viewinfo/cpp/source4.cpp#4)]
 [!code-csharp[Conceptual.Types.ViewInfo#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.types.viewinfo/cs/source4.cs#4)]
 [!code-vb[Conceptual.Types.ViewInfo#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.types.viewinfo/vb/source4.vb#4)]  
  
## See Also  
 <xref:System.Reflection.BindingFlags>  
 <xref:System.Reflection.Assembly.GetType%2A?displayProperty=nameWithType>  
 <xref:System.Reflection.Assembly.GetTypes%2A?displayProperty=nameWithType>  
 <xref:System.Type.GetType%2A?displayProperty=nameWithType>  
 <xref:System.Type.GetMembers%2A?displayProperty=nameWithType>  
 <xref:System.Type.GetFields%2A?displayProperty=nameWithType>  
 <xref:System.Reflection.Module.GetType%2A?displayProperty=nameWithType>  
 <xref:System.Reflection.Module.GetTypes%2A?displayProperty=nameWithType>  
 <xref:System.Reflection.MemberInfo>  
 <xref:System.Reflection.ConstructorInfo>  
 <xref:System.Reflection.MethodInfo>  
 <xref:System.Reflection.FieldInfo>  
 <xref:System.Reflection.EventInfo>  
 <xref:System.Reflection.ParameterInfo>  
 [Reflection and Generic Types](../../../docs/framework/reflection-and-codedom/reflection-and-generic-types.md)
