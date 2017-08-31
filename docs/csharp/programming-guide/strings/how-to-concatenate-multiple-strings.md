---
title: "How to: Concatenate Multiple Strings (C# Programming Guide) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "joining strings [C#]"
  - "concatenating strings [C#]"
  - "strings [C#], concatenation"
ms.assetid: 8e16736f-4096-4f3f-be0f-9d4c3ff63520
caps.latest.revision: 21
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Concatenate Multiple Strings (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

*Concatenation* is the process of appending one string to the end of another string. When you concatenate string literals or string constants by using the `+` operator, the compiler creates a single string. No run time concatenation occurs. However, string variables can be concatenated only at run time. In this case, you should understand the performance implications of the various approaches.  
  
## Example  
 The following example shows how to split a long string literal into smaller strings in order to improve readability in the source code. These parts will be concatenated into a single string at compile time. There is no run time performance cost regardless of the number of strings involved.  
  
 [!code-csharp[csProgGuideStrings#30](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStrings/CS/Strings.cs#30)]  
  
## Example  
 To concatenate string variables, you can use the `+` or `+=` operators, or the <xref:System.String.Concat%2A?displayProperty=fullName>, <xref:System.String.Format%2A?displayProperty=fullName> or <xref:System.Text.StringBuilder.Append%2A?displayProperty=fullName> methods. The `+` operator is easy to use and makes for intuitive code. Even if you use several + operators in one statement, the string content is copied only once. But if you repeat this operation multiple times, for example in a loop, it might cause efficiency problems. For example, note the following code:  
  
 [!code-csharp[csProgGuideStrings#23](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStrings/CS/Strings.cs#23)]  
  
> [!NOTE]
>  In string concatenation operations, the C# compiler treats a null string the same as an empty string, but it does not convert the value of the original null string.  
  
 If you are not concatenating large numbers of strings (for example, in a loop), the performance cost of this code is probably not significant. The same is true for the <xref:System.String.Concat%2A?displayProperty=fullName> and <xref:System.String.Format%2A?displayProperty=fullName> methods.  
  
 However, when performance is important, you should always use the <xref:System.Text.StringBuilder> class to concatenate strings. The following code uses the <xref:System.Text.StringBuilder.Append%2A> method of the <xref:System.Text.StringBuilder> class to concatenate strings without the chaining effect of the `+` operator.  
  
 [!code-csharp[csProgGuideStrings#22](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStrings/CS/Strings.cs#22)]  
  
## See Also  
 <xref:System.String>   
 <xref:System.Text.StringBuilder>   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Strings](../../../csharp/programming-guide/strings/index.md)