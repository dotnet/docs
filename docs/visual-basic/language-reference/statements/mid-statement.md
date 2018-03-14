---
title: "Mid Statement"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.MidB"
  - "vb.Mid"
helpviewer_keywords: 
  - "substrings [Visual Basic], Mid statement"
  - "strings [Visual Basic], substrings"
  - "Mid statement [Visual Basic]"
  - "strings [Visual Basic], replacing"
ms.assetid: 2b82d7a8-9646-4cb0-bec5-80abc98297bf
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
---
# Mid Statement
Replaces a specified number of characters in a `String` variable with characters from another string.  
  
## Syntax  
  
```  
Mid( _  
   ByRef Target As String, _  
   ByVal Start As Integer, _  
   Optional ByVal Length As Integer _  
) = StringExpression  
```  
  
## Parts  
 `Target`  
 Required. Name of the `String` variable to modify.  
  
 `Start`  
 Required. `Integer` expression. Character position in `Target` where the replacement of text begins. `Start` uses a one-based index.  
  
 `Length`  
 Optional. `Integer` expression. Number of characters to replace. If omitted, all of `String` is used.  
  
 `StringExpression`  
 Required. `String` expression that replaces part of `Target`.  
  
## Exceptions  
  
|Exception type|Condition|  
|--------------------|---------------|  
|<xref:System.ArgumentException>|`Start` <= 0 or `Length` < 0.|  
  
## Remarks  
 The number of characters replaced is always less than or equal to the number of characters in `Target`.  
  
 Visual Basic has a <xref:Microsoft.VisualBasic.Strings.Mid%2A> function and a `Mid` statement. These elements both operate on a specified number of characters in a string, but the `Mid` function returns the characters while the `Mid` statement replaces the characters. For more information, see <xref:Microsoft.VisualBasic.Strings.Mid%2A>.  
  
> [!NOTE]
>  The `MidB` statement of earlier versions of Visual Basic replaces a substring in bytes, rather than characters. It is used primarily for converting strings in double-byte character set (DBCS) applications. All Visual Basic strings are in Unicode, and `MidB` is no longer supported.  
  
## Example  
 This example uses the `Mid` statement to replace a specified number of characters in a string variable with characters from another string.  
  
 [!code-vb[VbVbalrStrings#5](../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/mid-statement_1.vb)]  
  
## Requirements  
 **Namespace:** [Microsoft.VisualBasic](../../../visual-basic/language-reference/runtime-library-members.md)  
  
 **Module:** `Strings`  
  
 **Assembly:** [!INCLUDE[vbprvbruntime](~/includes/vbprvbruntime-md.md)]  
  
## See Also  
 <xref:Microsoft.VisualBasic.Strings.Mid%2A>  
 [Strings](../../../visual-basic/programming-guide/language-features/strings/index.md)  
 [Introduction to Strings in Visual Basic](../../../visual-basic/programming-guide/language-features/strings/introduction-to-strings.md)
