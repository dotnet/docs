---
title: "Optional parameters must specify a default value | Microsoft Docs"
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
  - "vbc30812"
  - "bc30812"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30812"
ms.assetid: 5091a250-be66-413b-98a3-2a9974c4d600
caps.latest.revision: 10
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Optional parameters must specify a default value
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Optional parameters must provide default values that can be used if no parameter is supplied by a calling procedure.  
  
 **Error ID:** BC30812  
  
### To correct this error  
  
-   Specify default values for optional parameters; for example:  
  
    ```  
    Sub Proc1(ByVal X As Integer,   
          Optional ByVal Y As String = "Default Value")  
       MsgBox("Default argument is: " & Y)  
    End Sub  
    ```  
  
## See Also  
 [Optional](../../../visual-basic/language-reference/modifiers/optional.md)