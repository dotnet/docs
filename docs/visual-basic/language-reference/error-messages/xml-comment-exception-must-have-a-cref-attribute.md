---
title: "XML comment exception must have a &#39;cref&#39; attribute | Microsoft Docs"
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
  - "bc42319"
  - "vbc42319"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC42319"
ms.assetid: 62eeeba3-6811-48be-b1ef-c2e4feda3177
caps.latest.revision: 13
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# XML comment exception must have a &#39;cref&#39; attribute
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

The \<exception> tag provides a way to document the exceptions that may be thrown by a method. The required `cref` attribute designates the name of a member, which is checked by the documentation generator. If the member exists, it is translated to the canonical element name in the documentation file.  
  
 **Error ID:** BC42319  
  
### To correct this error  
  
-   Add the `cref` attribute to the exception as follows:  
  
    ```  
    '''<exception cref="member">description</exception>  
    ```  
  
## See Also  
 [\<exception>](../../../visual-basic/language-reference/xmldoc/exception.md)   
 [How to: Create XML Documentation](../../../visual-basic/programming-guide/program-structure/how-to-create-xml-documentation.md)   
 [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/recommended-xml-tags-for-documentation-comments.md)