---
title: "Nullable type inference is not supported in this context | Microsoft Docs"
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
  - "vbc36629"
  - "bc36629"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC36629"
ms.assetid: 0a1e2dbc-d9a4-433d-9306-c5540782b81d
caps.latest.revision: 5
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Nullable type inference is not supported in this context
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Value types and structures can be declared nullable.  
  
```vb  
Dim a? As Integer  
Dim b As Integer?  
```  
  
 However, you cannot use the nullable declaration in combination with type inference. The following examples cause this error.  
  
```vb  
' Not valid.  
' Dim c? = 10  
' Dim d? = a  
```  
  
 **Error ID:** BC36629  
  
### To correct this error  
  
-   Use an `As` clause to declare the variable as nullable.  
  
## See Also  
 [Nullable Value Types](../../../visual-basic/programming-guide/language-features/data-types/nullable-value-types.md)   
 [Local Type Inference](../../../visual-basic/programming-guide/language-features/variables/local-type-inference.md)