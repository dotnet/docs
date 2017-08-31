---
title: "Properties (C# Programming Guide) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "cs.properties"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "properties [C#]"
  - "C# language, properties"
ms.assetid: e295a8a2-b357-4ee7-a12e-385a44146fa8
caps.latest.revision: 38
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# Properties (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

A property is a member that provides a flexible mechanism to read, write, or compute the value of a private field. Properties can be used as if they are public data members, but they are actually special methods called *accessors*. This enables data to be accessed easily and still helps promote the safety and flexibility of methods.  
  
 In this example, the `TimePeriod` class stores a time period. Internally the class stores the time in seconds, but a property named `Hours` enables a client to specify a time in hours. The accessors for the `Hours` property perform the conversion between hours and seconds.  
  
## Example  
 [!code-csharp[csProgGuideProperties#1](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideProperties/CS/Properties.cs#1)]  
  
## Expression Body Definitions  
 It is common to have properties that simply return immediately with the result of an expression.  There is a syntax shortcut for defining these properties using `=>`:  
  
```csharp  
public string Name => First + " " + Last;   
```  
  
 The property must be read only, and you do not use the `get` accessor keyword.  
  
## Properties Overview  
  
-   Properties enable a class to expose a public way of getting and setting values, while hiding implementation or verification code.  
  
-   A [get](../../../csharp/language-reference/keywords/get.md) property accessor is used to return the property value, and a [set](../../../csharp/language-reference/keywords/set.md) accessor is used to assign a new value. These accessors can have different access levels. For more information, see [Restricting Accessor Accessibility](../../../csharp/programming-guide/classes-and-structs/restricting-accessor-accessibility.md).  
  
-   The [value](../../../csharp/language-reference/keywords/value.md) keyword is used to define the value being assigned by the `set` accessor.  
  
-   Properties that do not implement a `set` accessor are read only.  
  
-   For simple properties that require no custom accessor code, consider the option of using auto-implemented properties. For more information, see [Auto-Implemented Properties](../../../csharp/programming-guide/classes-and-structs/auto-implemented-properties.md).  
  
## Related Sections  
  
-   [Using Properties](../../../csharp/programming-guide/classes-and-structs/using-properties.md)  
  
-   [Interface Properties](../../../csharp/programming-guide/classes-and-structs/interface-properties.md)  
  
-   [Comparison Between Properties and Indexers](../../../csharp/programming-guide/indexers/comparison-between-properties-and-indexers.md)  
  
-   [Restricting Accessor Accessibility](../../../csharp/programming-guide/classes-and-structs/restricting-accessor-accessibility.md)  
  
-   [Auto-Implemented Properties](../../../csharp/programming-guide/classes-and-structs/auto-implemented-properties.md)  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Using Properties](../../../csharp/programming-guide/classes-and-structs/using-properties.md)   
 [Indexers](../../../csharp/programming-guide/indexers/index.md)