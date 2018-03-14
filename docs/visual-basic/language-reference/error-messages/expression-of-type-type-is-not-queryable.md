---
title: "Expression of type &lt;type&gt; is not queryable"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc36593"
  - "vbc36593"
helpviewer_keywords: 
  - "BC36593"
ms.assetid: 6f1f5860-bf97-4885-9ebb-bc87d028095c
caps.latest.revision: 5
author: dotnet-bot
ms.author: dotnetcontent
---
# Expression of type &lt;type&gt; is not queryable
Expression of type \<type> is not queryable. Make sure you are not missing an assembly reference and/or namespace import for the LINQ provider.  
  
 Queryable types are defined in the <xref:System.Linq>, <xref:System.Data.Linq>, and <xref:System.Xml.Linq> namespaces. You must import one or more of these namespaces to perform LINQ queries.  
  
 The <xref:System.Linq> namespace enables you to query objects such as collections and arrays by using LINQ.  
  
 The <xref:System.Data.Linq> namespace enables you to query ADO.NET Datasets and SQL Server databases by using LINQ.  
  
 The <xref:System.Xml.Linq> namespace enables you to query XML by using LINQ and to use XML features in Visual Basic.  
  
 **Error ID:** BC36593  
  
## To correct this error  
  
1.  Add an `Import` statement for the <xref:System.Linq>, <xref:System.Data.Linq>, or <xref:System.Xml.Linq> namespace to your code file. You can also import namespaces for your project by using the **References** page of the Project Designer (**My Project**).  
  
2.  Ensure that the type that you have identified as the source of your query is a queryable type. That is, a type that implements <xref:System.Collections.Generic.IEnumerable%601> or <xref:System.Linq.IQueryable%601>.  
  
## See Also  
 <xref:System.Linq>  
 <xref:System.Data.Linq>  
 <xref:System.Xml.Linq>  
 [Introduction to LINQ in Visual Basic](../../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md)  
 [LINQ](../../../visual-basic/programming-guide/language-features/linq/index.md)  
 [XML](../../../visual-basic/programming-guide/language-features/xml/index.md)  
 [References and the Imports Statement](../../../visual-basic/programming-guide/program-structure/references-and-the-imports-statement.md)  
 [Imports Statement (.NET Namespace and Type)](../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md)  
 [References Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/references-page-project-designer-visual-basic)
