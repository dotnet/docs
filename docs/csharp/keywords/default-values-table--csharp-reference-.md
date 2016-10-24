---
title: "Default Values Table (C# Reference)"
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
  - "constructors [C#], return values"
  - "keywords [C#], new"
  - "default constructor [C#]"
  - "defaults [C#]"
  - "value types [C#], initializing"
  - "variables [C#], value types"
  - "constructors [C#], default constructor"
  - "types [C#], default constructor return values"
ms.assetid: 4af2c1df-9e3a-48c1-83ac-b192986fc5bc
caps.latest.revision: 12
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Default Values Table (C# Reference)
The following table shows the default values of value types returned by the default constructors. Default constructors are invoked by using the `new` operator, as follows:  
  
```  
int myInt = new int();  
```  
  
 The preceding statement has the same effect as the following statement:  
  
```  
int myInt = 0;  
```  
  
 Remember that using uninitialized variables in C# is not allowed.  
  
|Value type|Default value|  
|----------------|-------------------|  
|[bool](../keywords/bool--csharp-reference-.md)|`false`|  
|[byte](../keywords/byte--csharp-reference-.md)|0|  
|[char](../keywords/char--csharp-reference-.md)|'\0'|  
|[decimal](../keywords/decimal--csharp-reference-.md)|0.0M|  
|[double](../keywords/double--csharp-reference-.md)|0.0D|  
|[enum](../keywords/enum--csharp-reference-.md)|The value produced by the expression (E)0, where E is the enum identifier.|  
|[float](../keywords/float--csharp-reference-.md)|0.0F|  
|[int](../keywords/int--csharp-reference-.md)|0|  
|[long](../keywords/long--csharp-reference-.md)|0L|  
|[sbyte](../keywords/sbyte--csharp-reference-.md)|0|  
|[short](../keywords/short--csharp-reference-.md)|0|  
|[struct](../keywords/struct--csharp-reference-.md)|The value produced by setting all value-type fields to their default values and all reference-type fields to `null`.|  
|[uint](../keywords/uint--csharp-reference-.md)|0|  
|[ulong](../keywords/ulong--csharp-reference-.md)|0|  
|[ushort](../keywords/ushort--csharp-reference-.md)|0|  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Value Types Table](../keywords/value-types-table--csharp-reference-.md)   
 [Value Types](../keywords/value-types--csharp-reference-.md)   
 [Built-In Types Table](../keywords/built-in-types-table--csharp-reference-.md)   
 [Reference Tables for Types](../keywords/reference-tables-for-types--csharp-reference-.md)