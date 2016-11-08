---
title: "How to: Call an Overloaded Procedure (Visual Basic) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "Visual Basic code, procedures"
  - "procedures, overloading"
  - "procedures, calling"
  - "procedures, multiple versions"
  - "procedure calls, overloaded"
ms.assetid: 3bb331fb-f6bc-406f-9ca0-9609b497014c
caps.latest.revision: 12
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# How to: Call an Overloaded Procedure (Visual Basic)
The advantage of overloading a procedure is in the flexibility of the call. The calling code can obtain the information it needs to pass to the procedure and then call a single procedure name, no matter what arguments it is passing.  
  
### To call a procedure that has more than one version defined  
  
1.  In the calling code, determine which data to pass to the procedure.  
  
2.  Write the procedure call in the normal way, presenting the data in the argument list. Be sure the arguments match the parameter list in one of the versions defined for the procedure.  
  
3.  You do not have to determine which version of the procedure to call. [!INCLUDE[vbprvb](../../../../csharp/programming-guide/concepts/linq/includes/vbprvb_md.md)] passes control to the version matching your argument list.  
  
     The following example calls the `post` procedure declared in [How to: Define Multiple Versions of a Procedure](../../../../visual-basic/language-reference/procedures/how-to-define-multiple-versions-of-a-procedure.md). It obtains the customer identification, determines whether it is a `String` or an `Integer`, and then in either case calls the same procedure.  
  
     [!code-vb[VbVbcnProcedures#56](../../../../visual-basic/language-reference/procedures/codesnippet/VisualBasic/how-to-call-an-overloaded-procedure_1.vb)]  
  
     [!code-vb[VbVbcnProcedures#57](../../../../visual-basic/language-reference/procedures/codesnippet/VisualBasic/how-to-call-an-overloaded-procedure_2.vb)]  
  
## See Also  
 [Procedures](../../../../visual-basic/language-reference/procedures/index.md)   
 [Procedure Parameters and Arguments](../../../../visual-basic/language-reference/procedures/procedure-parameters-and-arguments.md)   
 [Procedure Overloading](../../../../visual-basic/language-reference/procedures/procedure-overloading.md)   
 [Troubleshooting Procedures](../../../../visual-basic/language-reference/procedures/troubleshooting-procedures.md)   
 [How to: Define Multiple Versions of a Procedure](../../../../visual-basic/language-reference/procedures/how-to-define-multiple-versions-of-a-procedure.md)   
 [How to: Overload a Procedure that Takes Optional Parameters](../../../../visual-basic/language-reference/procedures/how-to-overload-a-procedure-that-takes-optional-parameters.md)   
 [How to: Overload a Procedure that Takes an Indefinite Number of Parameters](../../../../visual-basic/language-reference/procedures/how-to-overload-a-procedure-that-takes-an-indefinite-number-of-parameters.md)   
 [Considerations in Overloading Procedures](../../../../visual-basic/language-reference/procedures/considerations-in-overloading-procedures.md)   
 [Overload Resolution](../../../../visual-basic/language-reference/procedures/overload-resolution.md)   
 [Overloads](../../../../visual-basic/language-reference/modifiers/overloads.md)