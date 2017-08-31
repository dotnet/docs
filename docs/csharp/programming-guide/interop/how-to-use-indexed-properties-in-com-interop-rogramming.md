---
title: "How to: Use Indexed Properties in COM Interop Programming (C# Programming Guide) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "indexed properties [C#]"
  - "Office programming [C#], indexed properties"
  - "properties [C#], indexed"
ms.assetid: 756bfc1e-7c28-4d4d-b114-ac9288c73882
caps.latest.revision: 20
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Use Indexed Properties in COM Interop Programming (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

*Indexed properties* improve the way in which COM properties that have parameters are consumed in C# programming. Indexed properties work together with other features introduced in Visual C# 2010, such as [named and optional arguments](../../../csharp/programming-guide/classes-and-structs/named-and-optional-arguments.md), a new type ([dynamic](../../../csharp/language-reference/keywords/dynamic.md)), and [embedded type information](http://msdn.microsoft.com/library/b28ec92c-1867-4847-95c0-61adfe095e21), to enhance Microsoft Office programming.  
  
 In earlier versions of C#, methods are accessible as properties only if the `get` method has no parameters and the `set` method has one and only one value parameter. However, not all COM properties meet those restrictions. For example, the Excel [Range](http://go.microsoft.com/fwlink/?LinkId=166053) property has a `get` accessor that requires a parameter for the name of the range. In the past, because you could not access the `Range` property directly, you had to use the `get_Range` method instead, as shown in the following example.  
  
 [!code-csharp[csProgGuideIndexedProperties#1](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguideindexedproperties/cs/program.cs#1)]  
  
 Indexed properties enable you to write the following instead:  
  
 [!code-csharp[csProgGuideIndexedProperties#2](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguideindexedproperties/cs/program.cs#2)]  
  
> [!NOTE]
>  The previous example also uses the [optional arguments](../../../csharp/programming-guide/classes-and-structs/named-and-optional-arguments.md) feature, introduced in Visual C# 2010, which enables you to omit `Type.Missing`.  
  
 Similarly, to set the value of the `Value` property of a [Range](http://go.microsoft.com/fwlink/?LinkId=179211) object in Visual C# 2008 and earlier, two arguments are required. One supplies an argument for an optional parameter that specifies the type of the range value. The other supplies the value for the `Value` property. Before Visual C# 2010, C# allowed only one argument. Therefore, instead of using a regular set method, you had to either use the `set_Value` method or a different property, [Value2](http://go.microsoft.com/fwlink/?LinkId=166050). The following examples illustrate these techniques. Both set the value of the A1 cell to `Name`.  
  
 [!code-csharp[csProgGuideIndexedProperties#3](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguideindexedproperties/cs/program.cs#3)]  
  
 Indexed properties enable you to write the following code instead.  
  
 [!code-csharp[csProgGuideIndexedProperties#4](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguideindexedproperties/cs/program.cs#4)]  
  
 You cannot create indexed properties of your own. The feature only supports consumption of existing indexed properties.  
  
## Example  
 The following code shows a complete example. For more information about how to set up a project that accesses the Office API, see [How to: Access Office Interop Objects by Using Visual C# Features](../../../csharp/programming-guide/interop/how-to-access-office-onterop-objects.md).  
  
 [!code-csharp[csProgGuideIndexedProperties#5](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguideindexedproperties/cs/program.cs#5)]  
  
## See Also  
 [Named and Optional Arguments](../../../csharp/programming-guide/classes-and-structs/named-and-optional-arguments.md)   
 [dynamic](../../../csharp/language-reference/keywords/dynamic.md)   
 [Using Type dynamic](../../../csharp/programming-guide/types/using-type-dynamic.md)   
 [How to: Use Named and Optional Arguments in Office Programming](../../../csharp/programming-guide/classes-and-structs/how-to-use-named-and-optional-arguments-in-office-programming.md)   
 [How to: Access Office Interop Objects by Using Visual C# Features](../../../csharp/programming-guide/interop/how-to-access-office-onterop-objects.md)   
 [Walkthrough: Office Programming](../../../csharp/programming-guide/interop/walkthrough-office-programming.md)