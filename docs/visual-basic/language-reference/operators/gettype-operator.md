---
description: "Learn more about: GetType Operator (Visual Basic)"
title: "GetType Operator"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.GetType"
helpviewer_keywords: 
  - "GetType operator [Visual Basic]"
  - "GetType keyword [Visual Basic]"
ms.assetid: 4f733297-2503-4607-850c-15eba65fff90
---
# GetType Operator (Visual Basic)

Returns a <xref:System.Type> object for the specified type. The <xref:System.Type> object provides information about the type such as its properties, methods, and events.  
  
## Syntax  
  
```vb  
GetType(typename)  
```  
  
## Parameters  
  
|Parameter|Description|  
|---|---|  
|`typename`|The name of the type for which you desire information.|  
  
## Remarks  

 The `GetType` operator returns the <xref:System.Type> object for the specified `typename`. You can pass the name of any defined type in `typename`. This includes the following:  
  
- Any Visual Basic data type, such as `Boolean` or `Date`.  
  
- Any .NET Framework class, structure, module, or interface, such as <xref:System.ArgumentException?displayProperty=nameWithType> or <xref:System.Double?displayProperty=nameWithType>.  
  
- Any class, structure, module, or interface defined by your application.  
  
- Any array defined by your application.  
  
- Any delegate defined by your application.  
  
- Any enumeration defined by Visual Basic, the .NET Framework, or your application.  
  
 If you want to get the type object of an object variable, use the <xref:System.Object.GetType%2A?displayProperty=nameWithType> method.  
  
 The `GetType` operator can be useful in the following circumstance:  
  
- You must access the metadata for a type at run time. The <xref:System.Type> object supplies metadata such as type members and deployment information. You need this, for example, to reflect over an assembly. For more information, see also <xref:System.Reflection?displayProperty=nameWithType>.  
  
## Example  

 The following examples show the `GetType` operator in use.  
  
 [!code-vb[VbVbalrOperators#26](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#26)]  
  
## See also

- [Operator Precedence in Visual Basic](operator-precedence.md)
- [Operators Listed by Functionality](operators-listed-by-functionality.md)
- [Operators and Expressions](../../programming-guide/language-features/operators-and-expressions/index.md)
- <xref:System.Object.GetType%2A?displayProperty=nameWithType>
- <xref:System.Type.GetType%2A?displayProperty=nameWithType>
