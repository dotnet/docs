---
title: "switch (C# Reference) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "switch_CSharpKeyword"
  - "switch"
  - "case"
  - "case_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "switch statement [C#]"
  - "switch keyword [C#]"
  - "case statement [C#]"
  - "default keyword [C#]"
ms.assetid: 44bae8b8-8841-4d85-826b-8a94277daecb
caps.latest.revision: 47
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# switch (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The `switch` statement is a control statement that selects a *switch section* to execute from a list of candidates.  
  
 A `switch` statement includes one or more switch sections. Each switch section contains one or more *case labels* followed by one or more statements. The following example shows a simple `switch` statement that has three switch sections. Each switch section has one case label, such as `case 1`, and two statements.  
  
 [!code-csharp[csrefKeywordsSelection#7](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsSelection/CS/csrefKeywordsSelection.cs#7)]  
  
## Remarks  
 Each case label specifies a constant value. The switch statement transfers control to the switch section whose case label matches the value of the *switch expression* (`caseSwitch` in the example). If no case label contains a matching value, control is transferred to the `default` section, if there is one. If there is no `default` section, no action is taken and control is transferred outside the `switch` statement. In the previous example, the statements in the first switch section are executed because `case 1` matches the value of `caseSwitch`.  
  
 A `switch` statement can include any number of switch sections, and each section can have one or more case labels (as shown in the string case labels example below). However, no two case labels may contain the same constant value.  
  
 Execution of the statement list in the selected switch section begins with the first statement and proceeds through the statement list, typically until a jump statement, such as a `break`, `goto case`, `return`, or `throw`, is reached. At that point, control is transferred outside the `switch` statement or to another case label.  
  
 Unlike C++, C# does not allow execution to continue from one switch section to the next. The following code causes an error.  
  
```csharp  
switch (caseSwitch)  
{  
    // The following switch section causes an error.  
    case 1:  
        Console.WriteLine("Case 1...");  
        // Add a break or other jump statement here.  
    case 2:  
        Console.WriteLine("... and/or Case 2");  
        break;  
}  
```  
  
 C# requires the end of switch sections, including the final one, to be unreachable.  That is, unlike some other languages, your code may not fall through into the next switch section.  Although this requirement is usually met by using a `break` statement, the following case is also valid, because it ensures that the end of the statement list cannot be reached.  
  
```csharp  
case 4:  
    while (true)  
        Console.WriteLine("Endless looping. . . .");  
```  
  
## Example  
 The following example illustrates the requirements and capabilities of a `switch` statement.  
  
 [!code-csharp[csrefKeywordsSelection#9](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsSelection/CS/csrefKeywordsSelection.cs#9)]  
  
## Example  
 In the final example, the string variable, `str`, and string case labels control the flow of execution.  
  
 [!code-csharp[csrefKeywordsSelection#8](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsSelection/CS/csrefKeywordsSelection.cs#8)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [switch Statement (C++)](/visual-cpp/cpp/switch-statement-cpp)   
 [if-else](../../../csharp/language-reference/keywords/if-else.md)