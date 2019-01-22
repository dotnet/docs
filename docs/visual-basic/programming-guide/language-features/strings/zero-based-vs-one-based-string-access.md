---
title: "Zero-based vs. One-based String Access in Visual Basic"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "strings [Visual Basic], indexing"
ms.assetid: 0ed39f35-d68e-421d-ae14-460a5c0373b8
---
# Zero-based vs. One-based String Access in Visual Basic
This topic compares how Visual Basic and the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] provide access to the characters in a string. The [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] always provides zero-based access to the characters in a string, whereas Visual Basic provides zero-based and one-based access, depending on the function.  
  
## One-Based  
 For an example of a one-based Visual Basic function, consider the `Mid` function. It takes an argument that indicates the character position at which the substring will start, starting with position 1. The [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] <xref:System.String.Substring%2A?displayProperty=nameWithType> method takes an index of the character in the string at which the substring is to start, starting with position 0. Thus, if you have a string "ABCDE", the individual characters are numbered 1,2,3,4,5 for use with the `Mid` function, but 0,1,2,3,4 for use with the <xref:System.String.Substring%2A?displayProperty=nameWithType> method.  
  
## Zero-Based  
 For an example of a zero-based Visual Basic function, consider the `Split` function. It splits a string and returns an array containing the substrings. The [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] <xref:System.String.Split%2A?displayProperty=nameWithType> method also splits a string and returns an array containing the substrings. Because the `Split` function and <xref:System.String.Split%2A> method return [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] arrays, they must be zero-based.  
  
## See also
 <xref:Microsoft.VisualBasic.Strings.Mid%2A>  
 <xref:Microsoft.VisualBasic.Strings.Split%2A>  
 <xref:System.String.Substring%2A>  
 <xref:System.String.Split%2A>  
 [Introduction to Strings in Visual Basic](../../../../visual-basic/programming-guide/language-features/strings/introduction-to-strings.md)
