---
description: "Learn more about: Mid Statement"
title: "Mid Statement"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.MidB"
  - "vb.Mid"
helpviewer_keywords: 
  - "substrings [Visual Basic], Mid statement"
  - "strings [Visual Basic], substrings"
  - "Mid statement [Visual Basic]"
  - "strings [Visual Basic], replacing"
ms.assetid: 2b82d7a8-9646-4cb0-bec5-80abc98297bf
---
# Mid Statement

Replaces a specified number of characters in a `String` variable with characters from another string.  
  
## Syntax  
  
```vb  
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
> The `MidB` statement of earlier versions of Visual Basic replaces a substring in bytes, rather than characters. It is used primarily for converting strings in double-byte character set (DBCS) applications. All Visual Basic strings are in Unicode, and `MidB` is no longer supported.  
  
## Example  

 This example uses the `Mid` statement to replace a specified number of characters in a string variable with characters from another string.  
  
 [!code-vb[VbVbalrStrings#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStrings/VB/Class1.vb#5)]  
  
## Requirements  

 **Namespace:** [Microsoft.VisualBasic](../runtime-library-members.md)  
  
 **Module:** `Strings`  
  
 **Assembly:** Visual Basic Runtime Library (in Microsoft.VisualBasic.dll)  
  
## See also

- <xref:Microsoft.VisualBasic.Strings.Mid%2A>
- [Strings](../../programming-guide/language-features/strings/index.md)
- [Introduction to Strings in Visual Basic](../../programming-guide/language-features/strings/introduction-to-strings.md)
