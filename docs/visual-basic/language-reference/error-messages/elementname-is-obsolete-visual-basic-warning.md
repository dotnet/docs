---
title: "&#39;&lt;elementname&gt;&#39; is obsolete (Visual Basic Warning)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc40008"
  - "bc40008"
helpviewer_keywords: 
  - "BC40008"
ms.assetid: 729e3eb5-76ac-4c55-9fdd-78350e0de55e
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
---
# &#39;&lt;elementname&gt;&#39; is obsolete (Visual Basic Warning)
A statement attempts to access a programming element which has been marked with the <xref:System.ObsoleteAttribute> attribute and the directive to treat it as a warning.  
  
 You can mark any programming element as being no longer in use by applying <xref:System.ObsoleteAttribute> to it. If you do this, you can set the attribute's <xref:System.ObsoleteAttribute.IsError%2A> property to either `True` or `False`. If you set it to `True`, the compiler treats an attempt to use the element as an error. If you set it to `False`, or let it default to `False`, the compiler issues a warning if there is an attempt to use the element.  
  
 By default, this message is a warning, because the <xref:System.ObsoleteAttribute.IsError%2A> property of <xref:System.ObsoleteAttribute> is `False`. For more information about hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).  
  
 **Error ID:** BC40008  
  
## To correct this error  
  
-   Ensure that the source-code reference is spelling the element name correctly.  
  
## See Also  
 [Attributes overview](../../../visual-basic/programming-guide/concepts/attributes/index.md)
