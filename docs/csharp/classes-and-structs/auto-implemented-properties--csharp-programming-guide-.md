---
title: "Auto-Implemented Properties (C# Programming Guide)"
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
  - "auto-implemented properties [C#]"
  - "properties [C#], auto-implemented"
ms.assetid: aa55fa97-ccec-431f-b5e9-5ac789fd32b7
caps.latest.revision: 23
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Auto-Implemented Properties (C# Programming Guide)
In C# 3.0 and later, auto-implemented properties make property-declaration more concise when no additional logic is required in the property accessors. They also enable client code to create objects. When you declare a property as shown in the following example, the compiler creates a private, anonymous backing field that can only be accessed through the property's `get` and `set` accessors.  
  
## Example  
 The following example shows a simple class that has some auto-implemented properties:  
  
 [!code[csProgGuideLINQ#28](../arrays/codesnippet/CSharp/auto-implemented-properties--csharp-programming-guide-_1.cs)]  
  
 In C# 6 and later, you can initialize auto-implemented properties similarly to fields:  
  
```c#  
public string FirstName { get; set; } = "Jane";  
```  
  
 The class that is shown in the previous example is mutable. Client code can change the values in objects after they are created. In complex classes that contain significant behavior (methods) as well as data, it is often necessary to have public properties. However, for small classes or structs that just encapsulate a set of values (data) and have little or no behaviors, you should either make the objects immutable by declaring the set accessor as [private](../keywords/private--csharp-reference-.md) (immutable to consumers) or by declaring only a get accessor (immutable everywhere except the constructor).  For more information, see [How to: Implement a Lightweight Class with Auto-Implemented Properties](../classes-and-structs/1dc5a8ad-a4f7-4f32-8506-3fc6d8c8bfed.md).  
  
 Attributes are permitted on auto-implemented properties but obviously not on the backing fields since those are not accessible from your source code. If you must use an attribute on the backing field of a property, just create a regular property.  
  
## See Also  
 [Properties](../classes-and-structs/properties--csharp-programming-guide-.md)   
 [Modifiers](../keywords/modifiers--csharp-reference-.md)