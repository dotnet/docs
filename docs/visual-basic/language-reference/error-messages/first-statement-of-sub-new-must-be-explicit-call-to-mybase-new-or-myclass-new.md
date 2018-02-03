---
title: "First statement of this &#39;Sub New&#39; must be an explicit call to &#39;MyBase.New&#39; or &#39;MyClass.New&#39; because the &#39;&lt;constructorname&gt;&#39; in the base class &#39;&lt;baseclassname&gt;&#39; of &#39;&lt;derivedclassname&gt;&#39; is marked obsolete: &#39;&lt;errormessage&gt;&#39;"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc30920"
  - "bc30920"
helpviewer_keywords: 
  - "BC30920"
ms.assetid: e47dc755-4294-4368-b813-2177b7677957
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# First statement of this &#39;Sub New&#39; must be an explicit call to &#39;MyBase.New&#39; or &#39;MyClass.New&#39; because the &#39;&lt;constructorname&gt;&#39; in the base class &#39;&lt;baseclassname&gt;&#39; of &#39;&lt;derivedclassname&gt;&#39; is marked obsolete: &#39;&lt;errormessage&gt;&#39;
A class constructor does not explicitly call a base class constructor, and the implicit base class constructor is marked with the <xref:System.ObsoleteAttribute> attribute and the directive to treat it as an error.  
  
 When a derived class constructor does not call a base class constructor, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] attempts to generate an implicit call to a parameterless base class constructor. If there is no accessible constructor in the base class that can be called without arguments, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] cannot generate an implicit call. In this case, the required constructor is marked with the <xref:System.ObsoleteAttribute> attribute, so [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] cannot call it.  
  
 You can mark any programming element as being no longer in use by applying <xref:System.ObsoleteAttribute> to it. If you do this, you can set the attribute's <xref:System.ObsoleteAttribute.IsError%2A> property to either `True` or `False`. If you set it to `True`, the compiler treats an attempt to use the element as an error. If you set it to `False`, or let it default to `False`, the compiler issues a warning if there is an attempt to use the element.  
  
 **Error ID:** BC30920  
  
## To correct this error  
  
1.  Examine the quoted error message and take appropriate action.  
  
2.  Include a call to `MyBase.New()` or `MyClass.New()` as the first statement of the `Sub New` in the derived class.  
  
## See Also  
 [Attributes overview](../../../visual-basic/programming-guide/concepts/attributes/index.md)
 
