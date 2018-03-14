---
title: "Accessing Custom Attributes"
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
  - "custom attributes, accessibility"
  - "attributes [.NET Framework], accessing"
  - "reflection, custom attributes"
ms.assetid: 1d8e3398-00d8-47d5-a084-214f9859d3d7
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Accessing Custom Attributes
After attributes have been associated with program elements, reflection can be used to query their existence and values. In the .NET Framework version 1.0 and 1.1, custom attributes are examined in the execution context. The .NET Framework version 2.0 provides a new load context, the reflection-only context, which can be used to examine code that cannot be loaded for execution.  
  
## The Reflection-Only Context  
 Code loaded into the reflection-only context cannot be executed. This means that instances of custom attributes cannot be created, because that would require executing their constructors. To load and examine custom attributes in the reflection-only context, use the <xref:System.Reflection.CustomAttributeData> class. You can obtain instances of this class by using the appropriate overload of the static <xref:System.Reflection.CustomAttributeData.GetCustomAttributes%2A?displayProperty=nameWithType> method. See [How to: Load Assemblies into the Reflection-Only Context](../../../docs/framework/reflection-and-codedom/how-to-load-assemblies-into-the-reflection-only-context.md).  
  
## The Execution Context  
 The main reflection methods to query attributes in the execution context are <xref:System.Reflection.MemberInfo.GetCustomAttributes%2A?displayProperty=nameWithType> and <xref:System.Attribute.GetCustomAttributes%2A?displayProperty=nameWithType>.  
  
 The accessibility of a custom attribute is checked with respect to the assembly in which it is attached. This is equivalent to checking whether a method on a type in the assembly in which the custom attribute is attached can call the constructor of the custom attribute.  
  
 Methods such as <xref:System.Reflection.Assembly.GetCustomAttributes%28System.Boolean%29?displayProperty=nameWithType> check the visibility and accessibility of the type argument. Only code in the assembly that contains the user-defined type can retrieve a custom attribute of that type using **GetCustomAttributes**.  
  
 The following C# example is a typical custom attribute design pattern. It illustrates the runtime custom attribute reflection model.  
  
```  
System.DLL  
public class DescriptionAttribute : Attribute  
{  
}  
  
System.Web.DLL  
internal class MyDescriptionAttribute : DescriptionAttribute  
{  
}  
  
public class LocalizationExtenderProvider  
{  
    [MyDescriptionAttribute(...)]  
    public CultureInfo GetLanguage(...)  
    {  
    }  
}  
```  
  
 If the runtime is attempting to retrieve the custom attributes for the public custom attribute type <xref:System.ComponentModel.DescriptionAttribute> attached to the **GetLanguage** method, it performs the following actions:  
  
1.  The runtime checks that the type argument **DescriptionAttribute** to **Type.GetCustomAttributes**(Type *type*) is public, and therefore is visible and accessible.  
  
2.  The runtime checks that the user-defined type **MyDescriptionAttribute** that is derived from **DescriptionAttribute** is visible and accessible within the **System.Web.DLL** assembly, where it is attached to the method **GetLanguage**().  
  
3.  The runtime checks that the constructor of **MyDescriptionAttribute** is visible and accessible within the **System.Web.DLL** assembly.  
  
4.  The runtime calls the constructor of **MyDescriptionAttribute** with the custom attribute parameters and returns the new object to the caller.  
  
 The custom attribute reflection model could leak instances of user-defined types outside the assembly in which the type is defined. This is no different from the members in the runtime system library that return instances of user-defined types, such as <xref:System.Type.GetMethods%2A?displayProperty=nameWithType> returning an array of **RuntimeMethodInfo** objects. To prevent a client from discovering information about a user-defined custom attribute type, define the type's members to be nonpublic.  
  
 The following example demonstrates the basic way of using reflection to get access to custom attributes.  
  
 [!code-cpp[CustomAttributeData#2](../../../samples/snippets/cpp/VS_Snippets_CLR/CustomAttributeData/CPP/source2.cpp#2)]
 [!code-csharp[CustomAttributeData#2](../../../samples/snippets/csharp/VS_Snippets_CLR/CustomAttributeData/CS/source2.cs#2)]
 [!code-vb[CustomAttributeData#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CustomAttributeData/VB/source2.vb#2)]  
  
## See Also  
 <xref:System.Reflection.MemberInfo.GetCustomAttributes%2A?displayProperty=nameWithType>  
 <xref:System.Attribute.GetCustomAttributes%2A?displayProperty=nameWithType>  
 [Viewing Type Information](../../../docs/framework/reflection-and-codedom/viewing-type-information.md)  
 [Security Considerations for Reflection](../../../docs/framework/reflection-and-codedom/security-considerations-for-reflection.md)
