---
title: "Ordinal is not valid"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbrID452"
ms.assetid: 7459562b-cd4f-4590-95e0-6126ae3589a5
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# Ordinal is not valid
Your call to a dynamic-link library (DLL) indicated to use a number instead of a procedure name, using the `#num` syntax. This error has the following possible causes:  
  
-   An attempt to convert the `#num` expression to an ordinal failed.  
  
-   The `#num` specified does not specify any function in the DLL.  
  
-   A type library has an invalid declaration resulting in internal use of an invalid ordinal number.  
  
## To correct this error  
  
1.  Make sure the expression represents a valid number, or call the procedure by name.  
  
2.  Make sure `#num` identifies a valid function in the DLL.  
  
3.  Isolate the procedure call causing the problem by commenting out the code. Write a `Declare` statement for the procedure, and report the problem to the type library vendor.  
  
## See Also  
 [Declare Statement](../../../visual-basic/language-reference/statements/declare-statement.md)
