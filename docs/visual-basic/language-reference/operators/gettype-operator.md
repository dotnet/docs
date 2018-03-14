---
title: "GetType Operator (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.GetType"
helpviewer_keywords: 
  - "GetType operator [Visual Basic]"
  - "GetType keyword [Visual Basic]"
ms.assetid: 4f733297-2503-4607-850c-15eba65fff90
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# GetType Operator (Visual Basic)
Returns a <xref:System.Type> object for the specified type. The <xref:System.Type> object provides information about the type such as its properties, methods, and events.  
  
## Syntax  
  
```  
GetType(typename)  
```  
  
#### Parameters  
  
|Parameter|Description|  
|---|---|  
|`typename`|The name of the type for which you desire information.|  
  
## Remarks  
 The `GetType` operator returns the <xref:System.Type> object for the specified `typename`. You can pass the name of any defined type in `typename`. This includes the following:  
  
-   Any Visual Basic data type, such as `Boolean` or `Date`.  
  
-   Any .NET Framework class, structure, module, or interface, such as <xref:System.ArgumentException?displayProperty=nameWithType> or <xref:System.Double?displayProperty=nameWithType>.  
  
-   Any class, structure, module, or interface defined by your application.  
  
-   Any array defined by your application.  
  
-   Any delegate defined by your application.  
  
-   Any enumeration defined by Visual Basic, the .NET Framework, or your application.  
  
 If you want to get the type object of an object variable, use the <xref:System.Type.GetType%2A?displayProperty=nameWithType> method.  
  
 The `GetType` operator can be useful in the following circumstances:  
  
-   You must access the metadata for a type at run time. The <xref:System.Type> object supplies metadata such as type members and deployment information. You need this, for example, to reflect over an assembly. For more information, see <xref:System.Reflection?displayProperty=nameWithType>.  
  
-   You want to compare two object references to see if they refer to instances of the same type. If they do, `GetType` returns references to the same <xref:System.Type> object.  
  
## Example  
 The following examples show the `GetType` operator in use.  
  
 [!code-vb[VbVbalrOperators#26](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/gettype-operator_1.vb)]  
  
## See Also  
 [Operator Precedence in Visual Basic](../../../visual-basic/language-reference/operators/operator-precedence.md)  
 [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md)  
 [Operators and Expressions](../../../visual-basic/programming-guide/language-features/operators-and-expressions/index.md)
