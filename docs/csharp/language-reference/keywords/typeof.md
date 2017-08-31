---
title: "typeof (C# Reference) | Microsoft Docs"
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
  - "typeof"
  - "typeof_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "typeof keyword [C#]"
ms.assetid: 0c08d880-515e-46bb-8cd2-48b8dd62c08d
caps.latest.revision: 21
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# typeof (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

Used to obtain the `System.Type` object for a type. A `typeof` expression takes the following form:  
  
```  
System.Type type = typeof(int);  
```  
  
## Remarks  
 To obtain the run-time type of an expression, you can use the .NET Framework method <xref:System.Object.GetType%2A>, as in the following example:  
  
```  
int i = 0;  
System.Type type = i.GetType();  
```  
  
 The `typeof` operator cannot be overloaded.  
  
 The `typeof` operator can also be used on open generic types. Types with more than one type parameter must have the appropriate number of commas in the specification. The following example shows how to determine whether the return type of a method is a generic <xref:System.Collections.Generic.IEnumerable%601>. Assume that method is an instance of a MethodInfo type:  
  
```  
string s = method.ReturnType.GetInterface  
    (typeof(System.Collections.Generic.IEnumerable<>).FullName);  
```  
  
## Example  
 [!code-csharp[csrefKeywordsOperator#12](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsOperator/CS/csrefKeywordsOperators.cs#12)]  
  
## Example  
 This sample uses the <xref:System.Object.GetType%2A> method to determine the type that is used to contain the result of a numeric calculation. This depends on the storage requirements of the resulting number.  
  
 [!code-csharp[csrefKeywordsOperator#13](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsOperator/CS/csrefKeywordsOperators.cs#13)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 <xref:System.Type?displayProperty=fullName>   
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [is](../../../csharp/language-reference/keywords/is.md)   
 [Operator Keywords](../../../csharp/language-reference/keywords/operator-keywords.md)