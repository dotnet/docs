---
title: "Overloadable Operators (C# Programming Guide)"
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
  - "C# language, operator overloading"
  - "operator overloading [C#]"
ms.assetid: 390d9d01-79fc-40ab-9ed3-0bf448da1b6a
caps.latest.revision: 18
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
# Overloadable Operators (C# Programming Guide)
C# allows user-defined types to overload operators by defining static member functions using the [operator](../keywords/operator--csharp-reference-2.md) keyword. Not all operators can be overloaded, however, and others have restrictions, as listed in this table:  
  
|Operators|Overloadability|  
|---------------|---------------------|  
|[+](../operators/--operator--csharp-reference-.md), [-](../operators/--operator--csharp-reference-2.md), [!](../operators/!-operator--csharp-reference-.md), [~](../operators/~-operator--csharp-reference-.md), [++](../operators/---operator--csharp-reference-.md), [--](../operators/---operator--csharp-reference-.md), [true](../keywords/true--csharp-reference-.md), [false](../keywords/false--csharp-reference-.md)|These unary operators can be overloaded.|  
|[+](../operators/--operator--csharp-reference-.md), [-](../operators/--operator--csharp-reference-2.md), [*](../operators/--operator--csharp-reference-.md), [/](../operators/--operator--csharp-reference-1.md), [%](../operators/--operator--csharp-reference-.md), [&](../operators/--operator--csharp-reference-.md), [&#124;](../operators/--operator--csharp-reference-.md), [^](../operators/^-operator--csharp-reference-.md), [<\<](../operators/---operator--csharp-reference-.md), [>>](../operators/---operator--csharp-reference-.md)|These binary operators can be overloaded.|  
|[==](../operators/==-operator--csharp-reference-.md), [!=](../operators/!=-operator--csharp-reference-.md), [\<](../operators/--operator--csharp-reference-.md), [>](../operators/--operator--csharp-reference-.md), [\<=](../operators/-=-operator--csharp-reference-.md), [>=](../operators/-=-operator--csharp-reference-.md)|The comparison operators can be overloaded (but see the note that follows this table).|  
|[&&](../operators/---operator--csharp-reference-.md), [&#124;&#124;](../operators/---operator--csharp-reference-.md)|The conditional logical operators cannot be overloaded, but they are evaluated using `&` and `&#124;`, which can be overloaded.|  
|[&#91;&#93;](../operators/operator--csharp-reference-1.md)|The array indexing operator cannot be overloaded, but you can define indexers.|  
|[(T)x](../operators/---operator--csharp-reference-.md)|The cast operator cannot be overloaded, but you can define new conversion operators (see [explicit](../keywords/explicit--csharp-reference-.md) and [implicit](../keywords/implicit--csharp-reference-.md)).|  
|[+=](../operators/-=-operator--csharp-reference-.md), [-=](../operators/-=-operator--csharp-reference-2.md), [*=](../operators/-=-operator--csharp-reference-.md), [/=](../operators/-=-operator--csharp-reference-1.md), [%=](../operators/-=-operator--csharp-reference-.md), [&=](../operators/-=-operator--csharp-reference-.md), [&#124;=](../operators/-=-operator--csharp-reference-.md), [^=](../operators/^=-operator--csharp-reference-.md), [<\<=](../operators/--=-operator--csharp-reference-.md), [>>=](../operators/--=-operator--csharp-reference-.md)|Assignment operators cannot be overloaded, but `+=`, for example, is evaluated using `+`, which can be overloaded.|  
|[=](../operators/=-operator--csharp-reference-.md), [.](../operators/.-operator--csharp-reference-.md), [?:](../operators/---operator--csharp-reference-.md), [??](../operators/---operator--csharp-reference-.md), [->](../operators/---operator--csharp-reference-.md), [=>](../operators/=--operator--csharp-reference-.md), [f(x)](../operators/---operator--csharp-reference-.md), [as](../keywords/as--csharp-reference-.md), [checked](../keywords/checked--csharp-reference-.md), [unchecked](../keywords/unchecked--csharp-reference-.md), [default](../generics/default-keyword-in-generic-code--csharp-programming-guide-.md), [delegate](../statements-expressions-operators/anonymous-methods--csharp-programming-guide-.md), [is](../keywords/is--csharp-reference-.md), [new](../keywords/new--csharp-reference-.md), [sizeof](../keywords/sizeof--csharp-reference-.md), [typeof](../keywords/typeof--csharp-reference-.md)|These operators cannot be overloaded.|  
  
> [!NOTE]
>  The comparison operators, if overloaded, must be overloaded in pairs; that is, if `==` is overloaded, `!=` must also be overloaded. The reverse is also true, and similar for `<` and `>`, and for `<=` and `>=`.  
  
 To overload an operator on a custom class requires creating a method on the class with the correct signature. The method must be named "operator X" where X is the name or symbol of the operator being overloaded. Unary operators have one parameter, and binary operators have two parameters. In each case, one parameter must be the same type as the class or struct that declares the operator.  
  
```c#  
public static Complex operator +(Complex c1, Complex c2)  
    {  
        Return new Complex(c1.real + c2.real, c1.imaginary + c2.imaginary);  
    }  
  
```  
  
 It is common to have definitions that simply return immediately with the result of an expression.  There is a syntax shortcut using `=>` for these situations.  
  
```c#  
public static Complex operator +(Complex c1, Complex c2) =>  
        new Complex(c1.real + c2.real, c1.imaginary + c2.imaginary);  
  
    // Override ToString() to display a complex number   
    // in the traditional format:  
    public override string ToString() => $"{this.real} + {this.imaginary}";  
  
```  
  
 For more information, see [How to: Use Operator Overloading to Create a Complex Number Class](../statements-expressions-operators/c9b8d982-5112-413f-bae3-b42ae3248ddf.md).  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Statements, Expressions, and Operators](../statements-expressions-operators/statements--expressions--and-operators--csharp-programming-guide-.md)   
 [Operators](../statements-expressions-operators/operators--csharp-programming-guide-.md)   
 [C# Operators](../operators/csharp-operators.md)   
 [Why are overloaded operators always static in C#?](http://go.microsoft.com/fwlink/?LinkId=112383)