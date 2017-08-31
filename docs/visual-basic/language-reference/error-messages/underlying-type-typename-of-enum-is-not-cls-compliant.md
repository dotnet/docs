---
title: "Underlying type &lt;typename&gt; of Enum is not CLS-compliant | Microsoft Docs"
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
  - "vbc40032"
  - "bc40032"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC40032"
ms.assetid: 32bf1949-fd73-456c-a323-bf1ffe1320ed
caps.latest.revision: 8
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Underlying type &lt;typename&gt; of Enum is not CLS-compliant
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

The data type specified for this enumeration is not part of the [Language Independence and Language-Independent Components](../Topic/Language%20Independence%20and%20Language-Independent%20Components.md) (CLS). This is not an error within your component, because the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] and [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] support this data type. However, another component written in strictly CLS-compliant code might not support this data type. Such a component might not be able to interact successfully with your component.  
  
 The following [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] data types are not CLS-compliant:  
  
-   [SByte Data Type](../../../visual-basic/language-reference/data-types/sbyte-data-type.md)  
  
-   [UInteger Data Type](../../../visual-basic/language-reference/data-types/uinteger-data-type.md)  
  
-   [ULong Data Type](../../../visual-basic/language-reference/data-types/ulong-data-type.md)  
  
-   [UShort Data Type](../../../visual-basic/language-reference/data-types/ushort-data-type.md)  
  
 By default, this message is a warning. For more information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visual-studio/ide/configuring-warnings-in-visual-basic).  
  
 **Error ID:** BC40032  
  
### To correct this error  
  
-   If your component interfaces only with other [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] components, or does not interface with any other components, you do not need to change anything.  
  
-   If you are interfacing with a component not written for the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)], you might be able to determine, either through reflection or from documentation, whether it supports this data type. If it does, you do not need to change anything.  
  
-   If you are interfacing with a component that does not support this data type, you must replace it with the closest CLS-compliant type. For example, in place of `UInteger` you might be able to use `Integer` if you do not need the value range above 2,147,483,647. If you do need the extended range, you can replace `UInteger` with `Long`.  
  
-   If you are interfacing with Automation or COM objects, keep in mind that some types have different data widths than in the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)]. For example, `uint` is often 16 bits in other environments. If you are passing a 16-bit argument to such a component, declare it as `UShort` instead of `UInteger` in your managed [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] code.  
  
## See Also  
 [Reflection](../Topic/Reflection%20\(C%23%20and%20Visual%20Basic\).md)   
 [Reflection](../Topic/Reflection%20in%20the%20.NET%20Framework.md)   
 [\<PAVE OVER> Writing CLS-Compliant Code](http://msdn.microsoft.com/en-us/4c705105-69a2-4e5e-b24e-0633bc32c7f3)