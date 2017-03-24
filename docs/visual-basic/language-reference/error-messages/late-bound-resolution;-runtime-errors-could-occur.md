---
title: "Late bound resolution; runtime errors could occur | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "vbc42017"
  - "BC42017"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC42017"
ms.assetid: 45f552c8-57c6-44c0-97d3-e510119b257a
caps.latest.revision: 12
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Late bound resolution; runtime errors could occur
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

An object is assigned to a variable declared to be of the [Object Data Type](../../../visual-basic/language-reference/data-types/object-data-type.md).  
  
 When you declare a variable as `Object`, the compiler must perform *late binding*, which causes extra operations at run time. It also exposes your application to potential run-time errors. For example, if you assign a <xref:System.Windows.Forms.Form> to the `Object` variable and then try to access the <xref:System.Xml.XmlDocument.NameTable%2A?displayProperty=fullName> property, the runtime throws a <xref:System.MemberAccessException> because the <xref:System.Windows.Forms.Form> class does not expose a `NameTable` property.  
  
 If you declare the variable to be of a specific type, the compiler can perform *early binding* at compile time. This results in improved performance, controlled access to the members of the specific type, and better readability of your code.  
  
 By default, this message is a warning. For information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visual-studio/ide/configuring-warnings-in-visual-basic).  
  
 **Error ID:** BC42017  
  
### To correct this error  
  
-   If possible, declare the variable to be of a specific type.  
  
## See Also  
 [Early and Late Binding](../../../visual-basic/programming-guide/language-features/early-late-binding/early-and-late-binding.md)   
 [Object Variable Declaration](../../../visual-basic/programming-guide/language-features/variables/object-variable-declaration.md)