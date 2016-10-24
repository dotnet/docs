---
title: "for (C# Reference)"
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
  - "for"
  - "for_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "for keyword [C#]"
ms.assetid: 34041a40-2c87-467a-9ffb-a0417d8f67a8
caps.latest.revision: 39
author: "BillWagner"
ms.author: "wiwagn"
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
# for (C# Reference)
By using a `for` loop, you can run a statement or a block of statements repeatedly until a specified expression evaluates to `false`. This kind of loop is useful for iterating over arrays and for other applications in which you know in advance how many times you want the loop to iterate.  
  
## Example  
 In the following example, the value of `i` is written to the console and incremented by 1 during each iteration of the loop.  
  
 [!code[csrefKeywordsIteration#2](../keywords/codesnippet/CSharp/for--csharp-reference-_1.cs)]  
  
 The `for` statement in the previous example performs the following actions.  
  
1.  First, the initial value of variable `i` is established. This step happens only once, regardless of how many times the loop repeats. You can think of this initialization as happening outside the looping process.  
  
2.  To evaluate the condition (`i <= 5`), the value of `i` is compared to 5.  
  
    -   If `i` is less than or equal to 5, the condition evaluates to `true`, and the following actions occur.  
  
        1.  The `Console.WriteLine` statement in the body of the loop displays the value of `i`.  
  
        2.  The value of `i` is incremented by 1.  
  
        3.  The loop returns to the start of step 2 to evaluate the condition again.  
  
    -   If `i` is greater than 5, the condition evaluates to `false`, and you exit the loop.  
  
 Note that, if the initial value of `i` is greater than 5, the body of the loop doesn't run even once.  
  
 Every `for` statement defines initializer, condition, and iterator sections. These sections usually determine how many times the loop iterates.  
  
```c#  
for (initializer; condition; iterator)  
    body  
```  
  
 The sections serve the following purposes.  
  
-   The initializer section sets the initial conditions. The statements in this section run only once, before you enter the loop. The section can contain only one of the following two options.  
  
    -   The declaration and initialization of a local loop variable, as the first example shows (`int i = 1`). The variable is local to the loop and can't be accessed from outside the loop.  
  
    -   Zero or more statement expressons from the following list, separated by commas.  
  
        -   [assignment](../operators/=-operator--csharp-reference-.md) statement  
  
        -   invocation of a method  
  
        -   prefix or postfix [increment](../operators/---operator--csharp-reference-.md) expression, such as `++i` or `i++`  
  
        -   prefix or postfix [decrement](../operators/---operator--csharp-reference-.md) expression, such as `--i` or `i--`  
  
        -   creation of an object by using [new](../keywords/new-operator--csharp-reference-.md)  
  
        -   [await](../keywords/await--csharp-reference-.md) expression  
  
-   The condition section contains a boolean expression that’s evaluated to determine whether the loop should exit or should run again.  
  
-   The iterator section defines what happens after each iteration of the body of the loop. The iterator section contains zero or more of the following statement expressions, separated by commas:  
  
    -   [assignment](../operators/=-operator--csharp-reference-.md) statement  
  
    -   invocation of a method  
  
    -   prefix or postfix [increment](../operators/---operator--csharp-reference-.md) expression, such as `++i` or `i++`  
  
    -   prefix or postfix [decrement](../operators/---operator--csharp-reference-.md) expression, such as `--i` or `i--`  
  
    -   creation of an object by using [new](../keywords/new-operator--csharp-reference-.md)  
  
    -   [await](../keywords/await--csharp-reference-.md) expression  
  
-   The body of the loop consists of a statement, an empty statement, or a block of statements, which you create by enclosing zero or more statements in braces.  
  
     You can break out of a `for` loop by using the [break](../keywords/break--csharp-reference-.md) keyword, or you can step to the next iteration by using the [continue](../keywords/continue--csharp-reference-.md) keyword. You also can exit any loop by using a [goto](../keywords/goto--csharp-reference-.md), [return](../keywords/return--csharp-reference-.md), or [throw](../keywords/throw--csharp-reference-.md) statement.  
  
 The first example in this topic shows the most typical kind of `for` loop, which makes the following choices for the sections.  
  
-   The initializer declares and initializes a local loop variable, `i`, that maintains a count of the iterations of the loop.  
  
-   The condition checks the value of the loop variable against a known final value, 5.  
  
-   The iterator section uses a postfix increment statement, `i++`, to tally each iteration of the loop.  
  
 The following example illustrates several less common choices: assigning a value to an external loop variable in the initializer section,  invoking the `Console.WriteLine` method in both the initializer and the iterator sections, and changing the values of two variables in the iterator section.  
  
 [!code[csrefKeywordsIteration#8](../keywords/codesnippet/CSharp/for--csharp-reference-_2.cs)]  
  
 All of the expressions that define a `for` statement are optional. For example, the following statement creates an infinite loop.  
  
 [!code[csrefKeywordsIteration#3](../keywords/codesnippet/CSharp/for--csharp-reference-_3.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [foreach, in](../keywords/foreach--in--csharp-reference-.md)   
 [for Statement (C++)](../Topic/for%20Statement%20\(C++\).md)   
 [Iteration Statements](../keywords/iteration-statements--csharp-reference-.md)