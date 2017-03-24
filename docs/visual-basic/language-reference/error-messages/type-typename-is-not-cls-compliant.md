---
title: "Type &lt;typename&gt; is not CLS-compliant | Microsoft Docs"
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
  - "bc40041"
  - "vbc40041"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC40041"
ms.assetid: 634132c2-5646-44aa-98c6-f773e2e63882
caps.latest.revision: 7
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Type &lt;typename&gt; is not CLS-compliant
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

A variable, property, or function return is declared with a data type that is not CLS-compliant.  
  
 For an application to be compliant with the [Language Independence and Language-Independent Components](../Topic/Language%20Independence%20and%20Language-Independent%20Components.md) (CLS), it must use only CLS-compliant types.  
  
 The following [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] data types are not CLS-compliant:  
  
-   [SByte Data Type](../../../visual-basic/language-reference/data-types/sbyte-data-type.md)  
  
-   [UInteger Data Type](../../../visual-basic/language-reference/data-types/uinteger-data-type.md)  
  
-   [ULong Data Type](../../../visual-basic/language-reference/data-types/ulong-data-type.md)  
  
-   [UShort Data Type](../../../visual-basic/language-reference/data-types/ushort-data-type.md)  
  
 **Error ID:** BC40041  
  
### To correct this error  
  
-   If your application needs to be CLS-compliant, change the data type of this element to the closest CLS-compliant type. For example, in place of `UInteger` you might be able to use `Integer` if you do not need the value range above 2,147,483,647. If you do need the extended range, you can replace `UInteger` with `Long`.  
  
-   If your application does not need to be CLS-compliant, you do not need to change anything. You should be aware of its noncompliance, however.  
  
## See Also  
 [\<PAVE OVER> Writing CLS-Compliant Code](http://msdn.microsoft.com/en-us/4c705105-69a2-4e5e-b24e-0633bc32c7f3)