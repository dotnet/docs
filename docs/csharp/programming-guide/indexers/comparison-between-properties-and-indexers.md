---
title: "Comparison Between Properties and Indexers (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "properties [C#], vs. indexers"
  - "indexers [C#], vs. properties"
ms.assetid: 3358a89f-44a0-4a4d-bf8c-07237a90af39
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
---
# Comparison Between Properties and Indexers (C# Programming Guide)
Indexers are like properties. Except for the differences shown in the following table, all the rules that are defined for property accessors apply to indexer accessors also.  
  
|Property|Indexer|  
|--------------|-------------|  
|Allows methods to be called as if they were public data members.|Allows elements of an internal collection of an object to be accessed by using array notation on the object itself.|  
|Accessed through a simple name.|Accessed through an index.|  
|Can be a static or an instance member.|Must be an instance member.|  
|A [get](../../../csharp/language-reference/keywords/get.md) accessor of a property has no parameters.|A `get` accessor of an indexer has the same formal parameter list as the indexer.|  
|A [set](../../../csharp/language-reference/keywords/set.md) accessor of a property contains the implicit `value` parameter.|A `set` accessor of an indexer has the same formal parameter list as the indexer, and also to the [value](../../../csharp/language-reference/keywords/value.md) parameter.|  
|Supports shortened syntax with [Auto-Implemented Properties](../../../csharp/programming-guide/classes-and-structs/auto-implemented-properties.md).|Does not support shortened syntax.|  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Indexers](../../../csharp/programming-guide/indexers/index.md)  
 [Properties](../../../csharp/programming-guide/classes-and-structs/properties.md)
