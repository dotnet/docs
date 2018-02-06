---
title: "Expression has the type &#39;&lt;typename&gt;&#39; which is a restricted type and cannot be used to access members inherited from &#39;Object&#39; or &#39;ValueType&#39;"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc31393"
  - "vbc31393"
helpviewer_keywords: 
  - "BC31393"
ms.assetid: 2963cf3f-c527-4aa7-b67c-ee80b6d23186
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
---
# Expression has the type &#39;&lt;typename&gt;&#39; which is a restricted type and cannot be used to access members inherited from &#39;Object&#39; or &#39;ValueType&#39;
An expression evaluates to a type that cannot be boxed by the common language runtime (CLR) but accesses a member that requires boxing.  
  
 *Boxing* refers to the processing necessary to convert a type to `Object` or, on occasion, to <xref:System.ValueType>. The common language runtime cannot box certain structure types, for example <xref:System.ArgIterator>, <xref:System.RuntimeArgumentHandle>, and <xref:System.TypedReference>.  
  
 This expression attempts to use the restricted type to call a method inherited from <xref:System.Object> or <xref:System.ValueType>, such as <xref:System.Object.GetHashCode%2A> or <xref:System.Object.ToString%2A>. To access this method, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] has attempted an implicit boxing conversion that causes this error.  
  
 **Error ID:** BC31393  
  
## To correct this error  
  
1.  Locate the expression that evaluates to the cited type.  
  
2.  Locate the part of your statement that attempts to call the method inherited from <xref:System.Object> or <xref:System.ValueType>.  
  
3.  Rewrite the statement to avoid the method call.  
  
## See Also  
 [Implicit and Explicit Conversions](../../../visual-basic/programming-guide/language-features/data-types/implicit-and-explicit-conversions.md)
