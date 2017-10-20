---
title: "=&gt; Operator (C# Reference)"
ms.date: 10/02/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "=>_CSharpKeyword"
helpviewer_keywords: 
  - "lambda operator [C#]"
  - "=> operator [C#]"
  - "lambda expressions [C#], => operator"
author: "BillWagner"
ms.author: "wiwagn"
---
# =&gt; Operator (C# Reference)

The `=>` operator can be used in two ways in C#:

- As the [lambda operator](#lamba-operator) in a [lambda expression](../../lambda-expressions.md), it separates the input variables from the lambda body.
 
- In an [expression body definition](#expression-body-definition), it separates a member name from the member implementation. 

## Lambda operator

The `=>` token is called the lambda operator. It is used in *lambda expressions* to separate the input variables on the left side from the lambda body on the right side. Lambda expressions are inline expressions similar to anonymous methods but more flexible; they are used extensively in LINQ queries that are expressed in method syntax. For more information, see [Lambda Expressions](../../../csharp/programming-guide/statements-expressions-operators/lambda-expressions.md).  
  
 The following example shows two ways to find and display the length of the shortest string in an array of strings. The first part of the example applies a lambda expression (`w => w.Length`) to each element of the `words` array and then uses the <xref:System.Linq.Enumerable.Min%2A> method to find the smallest length. For comparison, the second part of the example shows a longer solution that uses query syntax to do the same thing.  
  
```csharp  
string[] words = { "cherry", "apple", "blueberry" };  
  
// Use method syntax to apply a lambda expression to each element  
// of the words array.   
int shortestWordLength = words.Min(w => w.Length);  
Console.WriteLine(shortestWordLength);  
  
// Compare the following code that uses query syntax.  
// Get the lengths of each word in the words array.  
var query = from w in words  
            select w.Length;  
// Apply the Min method to execute the query and get the shortest length.  
int shortestWordLength2 = query.Min();  
Console.WriteLine(shortestWordLength2);  
  
// Output:   
// 5  
// 5  
```  
  
### Remarks  
 The `=>` operator has the same precedence as the assignment operator (`=`) and is right-associative.  
  
 You can specify the type of the input variable explicitly or let the compiler infer it; in either case, the variable is strongly typed at compile time. When you specify a type, you must enclose the type name and the variable name in parentheses, as the following example shows.  
  
```csharp  
int shortestWordLength = words.Min((string w) => w.Length);  
```  
  
### Example  
 The following example shows how to write a lambda expression for the overload of the standard query operator <xref:System.Linq.Enumerable.Where%2A?displayProperty=nameWithType> that takes two arguments. Because the lambda expression has more than one parameter, the parameters must be enclosed in parentheses. The second parameter, `index`, represents the index of the current element in the collection. The `Where` expression returns all the strings whose lengths are less than their index positions in the array.  
  
```csharp  
static void Main(string[] args)  
{  
    string[] digits = { "zero", "one", "two", "three", "four", "five",   
            "six", "seven", "eight", "nine" };  
  
    Console.WriteLine("Example that uses a lambda expression:");  
    var shortDigits = digits.Where((digit, index) => digit.Length < index);  
    foreach (var sD in shortDigits)  
    {  
        Console.WriteLine(sD);  
    }  
  
    // Output:  
    // Example that uses a lambda expression:  
    // five  
    // six  
    // seven  
    // eight  
    // nine  
}  
```  
## Expression body definition

An expression body definition provides a member's implementation in a highly condensed, readable form. It has the following general syntax:

```csharp
member => expression;
```
where *expression* is a valid expression. Note that *expression* can be a *statement expression* only if the member's return type is `void`, or if the member is a constructor or a finalizer.

Expression body definitions for methods and property get statements are supported starting with C# 6. Expression body definitions for constructors, finalizers, property set statements, and indexers are supported starting with C# 7.

The following is an expression body definition for a `Person.ToString` method:

```csharp
public override string ToString() => $"{fname} {lname}".Trim();
```

It is a shorthand version of the following method definition:

```csharp
public override string ToString()
{
   return $"{fname} {lname}".Trim();
}
```
For more detailed information on expression body definitions, see [Expression-bodied members](../../programming-guide/statements-expressions-operators/expression-bodied-members.md).

## See Also  
[C# Reference](../../../csharp/language-reference/index.md)   
[C# Programming Guide](../../../csharp/programming-guide/index.md)   
[Lambda Expressions](../../../csharp/programming-guide/statements-expressions-operators/lambda-expressions.md)   
[Expression-bodied members](../../programming-guide/statements-expressions-operators/expression-bodied-members.md).