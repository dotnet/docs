---
title: "if-else (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "if_CSharpKeyword"
  - "else"
  - "else_CSharpKeyword"
  - "if"
helpviewer_keywords: 
  - "else keyword [C#]"
  - "if keyword [C#]"
ms.assetid: d9a1d562-8cf5-4bd4-9ba7-8ad970cd25b2
caps.latest.revision: 32
author: "BillWagner"
ms.author: "wiwagn"
---
# if-else (C# Reference)
An `if` statement identifies which statement to run based on the value of a `Boolean` expression. In the following example, the `Boolean` variable `result` is set to `true` and then checked in the `if` statement. The output is `The condition is true`.  
  
 [!code-csharp[csrefKeywordsSelection#1](../../../csharp/language-reference/keywords/codesnippet/CSharp/if-else_1.cs)]  
  
 You can run the examples in this topic by placing them in the `Main` method of a console app.  
  
 An `if` statement in C# can take two forms, as the following example shows.  
  
```csharp  
// if-else statement  
if (condition)  
{  
    then-statement;  
}  
else  
{  
    else-statement;  
}  
// Next statement in the program.  
  
// if statement without an else  
if (condition)  
{  
    then-statement;  
}  
// Next statement in the program.  
```  
  
 In an `if-else` statement, if `condition` evaluates to true, the `then-statement` runs. If `condition` is false, the `else-statement` runs. Because `condition` can’t be simultaneously true and false, the `then-statement` and the `else-statement` of an `if-else` statement can never both run. After the `then-statement` or the `else-statement` runs, control is transferred to the next statement after the `if` statement.  
  
 In an `if` statement that doesn’t include an `else` statement, if `condition` is true, the `then-statement` runs. If `condition` is false, control is transferred to the next statement after the `if` statement.  
  
 Both the `then-statement` and the `else-statement` can consist of a single statement or multiple statements that are enclosed in braces (`{}`). For a single statement, the braces are optional but recommended.  
  
 The statement or statements in the `then-statement` and the `else-statement` can be of any kind, including another `if` statement nested inside the original `if` statement. In nested `if` statements, each `else` clause belongs to the last `if` that doesn’t have a corresponding `else`. In the following example, `Result1` appears if both `m > 10` and `n > 20` evaluate to true. If `m > 10` is true but `n > 20` is false, `Result2` appears.  
  
 [!code-csharp[csrefKeywordsSelection#2](../../../csharp/language-reference/keywords/codesnippet/CSharp/if-else_2.cs)]  
  
 If, instead, you want `Result2` to appear when `(m > 10)` is false, you can specify that association by using braces to establish the start and end of the nested `if` statement, as the following example shows.  
  
 [!code-csharp[csrefKeywordsSelection#3](../../../csharp/language-reference/keywords/codesnippet/CSharp/if-else_3.cs)]  
  
 `Result2` appears if the condition `(m > 10)` evaluates to false.  
  
## Example  
 In the following example, you enter a character from the keyboard, and the program uses a nested `if` statement to determine whether the input character is an alphabetic character. If the input character is an alphabetic character, the program checks whether the input character is lowercase or uppercase. A message appears for each case.  
  
 [!code-csharp[csrefKeywordsSelection#4](../../../csharp/language-reference/keywords/codesnippet/CSharp/if-else_4.cs)]  
  
## Example  
 You also can nest an `if` statement inside an else block, as the following partial code shows. The example nests `if` statements inside two else blocks and one then block. The comments specify which conditions are true or false in each block.  
  
 [!code-csharp[csrefKeywordsSelection#5](../../../csharp/language-reference/keywords/codesnippet/CSharp/if-else_5.cs)]  
  
## Example  
 The following example determines whether an input character is a lowercase letter, an uppercase letter, or a number. If all three conditions are false, the character isn’t an alphanumeric character. The example displays a message for each case.  
  
 [!code-csharp[csrefKeywordsSelection#6](../../../csharp/language-reference/keywords/codesnippet/CSharp/if-else_6.cs)]  
  
 Just as a statement in the else block or the then block can be any valid statement, you can use any valid Boolean expression for the condition. You can use logical operators such as [&&](../../../csharp/language-reference/operators/conditional-and-operator.md), [&](../../../csharp/language-reference/operators/and-operator.md), [&#124;&#124;](../../../csharp/language-reference/operators/conditional-or-operator.md), [&#124;](../../../csharp/language-reference/operators/or-operator.md) and [!](../../../csharp/language-reference/operators/logical-negation-operator.md) to make compound conditions. The following code shows examples.  
  
```csharp  
// NOT  
bool result = true;  
if (!result)  
{  
    Console.WriteLine("The condition is true (result is false).");  
}  
else  
{  
    Console.WriteLine("The condition is false (result is true).");  
}  
  
// Short-circuit AND  
int m = 9;  
int n = 7;  
int p = 5;  
if (m >= n && m >= p)  
{  
    Console.WriteLine("Nothing is larger than m.");  
}  
  
// AND and NOT  
if (m >= n && !(p > m))  
{  
    Console.WriteLine("Nothing is larger than m.");  
}  
  
// Short-circuit OR  
if (m > n || m > p)  
{  
    Console.WriteLine("m isn't the smallest.");  
}  
  
// NOT and OR  
m = 4;  
if (!(m >= n || m >= p))  
{  
    Console.WriteLine("Now m is the smallest.");  
}  
// Output:  
// The condition is false (result is true).  
// Nothing is larger than m.  
// Nothing is larger than m.  
// m isn't the smallest.  
// Now m is the smallest.  
```  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [?: Operator](../../../csharp/language-reference/operators/conditional-operator.md)  
 [if-else Statement (C++)](/cpp/cpp/if-else-statement-cpp)  
 [switch](../../../csharp/language-reference/keywords/switch.md)
