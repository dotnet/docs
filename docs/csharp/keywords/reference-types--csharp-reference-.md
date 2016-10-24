---
title: "Reference Types (C# Reference)"
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
  - "cs.referencetypes"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "reference types [C#]"
  - "C# language, reference types"
  - "types [C#], reference types"
ms.assetid: 801cf030-6e2d-4a0d-9daf-1431b0c31f47
caps.latest.revision: 15
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
# Reference Types (C# Reference)
There are two kinds of types in C#: reference types and value types. Variables of reference types store references to their data (objects), while variables of value types directly contain their data. With reference types, two variables can reference the same object; therefore, operations on one variable can affect the object referenced by the other variable. With value types, each variable has its own copy of the data, and it is not possible for operations on one variable to affect the other (except in the case of ref and out parameter variables, see [ref](../keywords/ref--csharp-reference-.md) and [out parameter modifier](../keywords/out-parameter-modifier--csharp-reference-.md)).  
  
 The following keywords are used to declare reference types:  
  
-   [class](../keywords/class--csharp-reference-.md)  
  
-   [interface](../keywords/interface--csharp-reference-.md)  
  
-   [delegate](../keywords/delegate--csharp-reference-.md)  
  
 C# also provides the following built-in reference types:  
  
-   [dynamic](../keywords/dynamic--csharp-reference-.md)  
  
-   [object](../keywords/object--csharp-reference-.md)  
  
-   [string](../keywords/string--csharp-reference-.md)  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Types](../keywords/types--csharp-reference-.md)   
 [Value Types](../keywords/value-types--csharp-reference-.md)