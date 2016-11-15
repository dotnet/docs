---
title: "Type &#39;&lt;typename1&gt;&#39; cannot be marked CLS-compliant because its containing type &#39;&lt;typename2&gt;&#39; is not CLS-compliant | Microsoft Docs"
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
  - "vbc40030"
  - "bc40030"
helpviewer_keywords: 
  - "BC40030"
ms.assetid: f1cfcf04-2a99-46ef-ac87-34cc2099125c
caps.latest.revision: 15
author: "stevehoag"
ms.author: "shoag"
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
# Type &#39;&lt;typename1&gt;&#39; cannot be marked CLS-compliant because its containing type &#39;&lt;typename2&gt;&#39; is not CLS-compliant
A class or interface is marked as `<CLSCompliant(True)>` when it is nested in a type that is marked as `<CLSCompliant(False)>` or is not marked.  
  
 For a class or interface to be compliant with the [Language Independence and Language-Independent Components](../Topic/Language%20Independence%20and%20Language-Independent%20Components.md) (CLS), its entire containment hierarchy must be compliant. That means every type in which it is nested must be compliant.  
  
 When you apply the <xref:System.CLSCompliantAttribute> to a programming element, you set the attribute's `isCompliant` parameter to either `True` or `False` to indicate compliance or noncompliance. There is no default for this parameter, and you must supply a value.  
  
 If you do not apply the <xref:System.CLSCompliantAttribute> to an element, it is considered to be noncompliant.  
  
 By default, this message is a warning. For information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visual-studio/ide/configuring-warnings-in-visual-basic).  
  
 **Error ID:** BC40030  
  
### To correct this error  
  
-   If you require CLS compliance, define this type within a different containment hierarchy.  
  
-   If you require that this type remain within its current containment hierarchy, remove the <xref:System.CLSCompliantAttribute> from its definition or mark it as `<CLSCompliant(False)>`.  
  
## See Also  
 [\<PAVE OVER> Writing CLS-Compliant Code](http://msdn.microsoft.com/en-us/4c705105-69a2-4e5e-b24e-0633bc32c7f3)