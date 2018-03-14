---
title: "Operators (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "operators [C#]"
  - "C# language, operators"
  - "operators [C#], about operators"
ms.assetid: 214e7b83-1a41-4f7c-9867-64e9c0bab39f
caps.latest.revision: 42
author: "BillWagner"
ms.author: "wiwagn"
---
# Operators (C# Programming Guide)
In C#, an *operator* is a program element that is applied to one or more *operands* in an expression or statement. Operators that take one operand, such as the increment operator (`++`) or `new`, are referred to as *unary* operators. Operators that take two operands, such as arithmetic operators (`+`,`-`,`*`,`/`), are referred to as *binary* operators. One operator, the conditional operator (`?:`), takes three operands and is the sole ternary operator in C#.  
  
 The following C# statement contains a single unary operator and a single operand. The increment operator, `++`, modifies the value of the operand `y`.  
  
 [!code-csharp[csProgGuideStatements#5](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/operators_1.cs)]  
  
 The following C# statement contains two binary operators, each with two operands. The assignment operator, `=`, has the integer variable `y` and the expression `2 + 3` as operands. The expression `2 + 3` itself consists of the addition operator and two operands, `2` and `3`.  
  
 [!code-csharp[csProgGuideStatements#6](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/operators_2.cs)]  
  
## Operators, Evaluation, and Operator Precedence  
 An operand can be a valid expression that is composed of any length of code, and it can comprise any number of sub expressions. In an expression that contains multiple operators, the order in which the operators are applied is determined by *operator precedence*, *associativity*, and parentheses.  
  
 Each operator has a defined precedence. In an expression that contains multiple operators that have different precedence levels, the precedence of the operators determines the order in which the operators are evaluated. For example, the following statement assigns 3 to `n1`.  
  
 `n1 = 11 - 2 * 4;`  
  
 The multiplication is executed first because multiplication takes precedence over subtraction.  
  
 The following table separates the operators into categories based on the type of operation they perform. The categories are listed in order of precedence.  
  
 **Primary Operators**  
  
|Expression|Description|  
|----------------|-----------------|  
|x[.](../../../csharp/language-reference/operators/member-access-operator.md)y<br /><br /> x?.y|Member access<br /><br /> Conditional member access|  
|f[(x)](../../../csharp/language-reference/operators/invocation-operator.md)|Method and delegate invocation|  
|a[&#91;x&#93;](../../../csharp/language-reference/operators/index-operator.md)<br /><br /> a?[x]|Array and indexer access<br /><br /> Conditional array and indexer access|  
|x[++](../../../csharp/language-reference/operators/increment-operator.md)|Post-increment|  
|x[--](../../../csharp/language-reference/operators/decrement-operator.md)|Post-decrement|  
|[new](../../../csharp/language-reference/keywords/new-operator.md) T(...)|Object and delegate creation|  
|`new` T(...){...}|Object creation with initializer. See [Object and Collection Initializers](../../../csharp/programming-guide/classes-and-structs/object-and-collection-initializers.md).|  
|`new` {...}|Anonymous object initializer. See [Anonymous Types](../../../csharp/programming-guide/classes-and-structs/anonymous-types.md).|  
|`new` T[...]|Array creation. See [Arrays](../../../csharp/programming-guide/arrays/index.md).|  
|[typeof](../../../csharp/language-reference/keywords/typeof.md)(T)|Obtain System.Type object for T|  
|[checked](../../../csharp/language-reference/keywords/checked.md)(x)|Evaluate expression in checked context|  
|[unchecked](../../../csharp/language-reference/keywords/unchecked.md)(x)|Evaluate expression in unchecked context|  
|[default](../../../csharp/language-reference/keywords/default.md) (T)|Obtain default value of type T|  
|[delegate](../../../csharp/language-reference/keywords/delegate.md) {}|Anonymous function (anonymous method)|  
  
 **Unary Operators**  
  
|Expression|Description|  
|----------------|-----------------|  
|[+](../../../csharp/language-reference/operators/addition-operator.md)x|Identity|  
|[-](../../../csharp/language-reference/operators/subtraction-operator.md)x|Negation|  
|[\!](../../../csharp/language-reference/operators/logical-negation-operator.md)x|Logical negation|  
|[~](../../../csharp/language-reference/operators/bitwise-complement-operator.md)x|Bitwise negation|  
|[++](../../../csharp/language-reference/operators/increment-operator.md)x|Pre-increment|  
|[--](../../../csharp/language-reference/operators/decrement-operator.md)x|Pre-decrement|  
|[(T)](../../../csharp/language-reference/operators/invocation-operator.md)x|Explicitly convert x to type T|  
  
 **Multiplicative Operators**  
  
|Expression|Description|  
|----------------|-----------------|  
|[*](../../../csharp/language-reference/operators/multiplication-operator.md)|Multiplication|  
|[/](../../../csharp/language-reference/operators/division-operator.md)|Division|  
|[%](../../../csharp/language-reference/operators/modulus-operator.md)|Remainder|  
  
 **Additive Operators**  
  
|Expression|Description|  
|----------------|-----------------|  
|x [+](../../../csharp/language-reference/operators/addition-operator.md) y|Addition, string concatenation, delegate combination|  
|x [-](../../../csharp/language-reference/operators/subtraction-operator.md) y|Subtraction, delegate removal|  
  
 **Shift Operators**  
  
|Expression|Description|  
|----------------|-----------------|  
|x [<\<](../../../csharp/language-reference/operators/left-shift-operator.md) y|Shift left|  
|x [>>](../../../csharp/language-reference/operators/right-shift-operator.md) y|Shift right|  
  
 **Relational and Type Operators**  
  
|Expression|Description|  
|----------------|-----------------|  
|x [\<](../../../csharp/language-reference/operators/less-than-operator.md) y|Less than|  
|x [>](../../../csharp/language-reference/operators/greater-than-operator.md) y|Greater than|  
|x [\<=](../../../csharp/language-reference/operators/less-than-equal-operator.md) y|Less than or equal|  
|x [>=](../../../csharp/language-reference/operators/greater-than-equal-operator.md) y|Greater than or equal|  
|x [is](../../../csharp/language-reference/keywords/is.md) T|Return true if x is a T, false otherwise|  
|x [as](../../../csharp/language-reference/keywords/as.md) T|Return x typed as T, or null if x is not a T|  
  
 **Equality Operators**  
  
|Expression|Description|  
|----------------|-----------------|  
|x [==](../../../csharp/language-reference/operators/equality-comparison-operator.md) y|Equal|  
|x [!=](../../../csharp/language-reference/operators/not-equal-operator.md) y|Not equal|  
  
 **Logical, Conditional, and Null Operators**  
  
|Category|Expression|Description|  
|--------------|----------------|-----------------|  
|Logical AND|x [&](../../../csharp/language-reference/operators/and-operator.md) y|Integer bitwise AND, Boolean logical AND|  
|Logical XOR|x [^](../../../csharp/language-reference/operators/xor-operator.md) y|Integer bitwise XOR, boolean logical XOR|  
|Logical OR|x [&#124;](../../../csharp/language-reference/operators/or-operator.md) y|Integer bitwise OR, boolean logical OR|  
|Conditional AND|x [&&](../../../csharp/language-reference/operators/conditional-and-operator.md) y|Evaluates y only if x is true|  
|Conditional OR|x [&#124;&#124;](../../../csharp/language-reference/operators/conditional-or-operator.md) y|Evaluates y only if x is false|  
|Null coalescing|x [??](../../../csharp/language-reference/operators/null-conditional-operator.md) y|Evaluates to y if x is null, to x otherwise|  
|Conditional|x [?](../../../csharp/language-reference/operators/conditional-operator.md) y : z|Evaluates to y if x is true, z if x is false|  
  
 **Assignment and Anonymous Operators**  
  
|Expression|Description|  
|----------------|-----------------|  
|[=](../../../csharp/language-reference/operators/assignment-operator.md)|Assignment|  
|x op= y|Compound assignment. Supports these operators: [+=](../../../csharp/language-reference/operators/addition-assignment-operator.md), [-=](../../../csharp/language-reference/operators/subtraction-assignment-operator.md), [*=](../../../csharp/language-reference/operators/multiplication-assignment-operator.md), [/=](../../../csharp/language-reference/operators/division-assignment-operator.md), [%=](../../../csharp/language-reference/operators/modulus-assignment-operator.md), [&=](../../../csharp/language-reference/operators/and-assignment-operator.md), [&#124;=](../../../csharp/language-reference/operators/or-assignment-operator.md), [!=](../../../csharp/language-reference/operators/not-equal-operator.md), [<\<=](../../../csharp/language-reference/operators/left-shift-assignment-operator.md), [>>=](../../../csharp/language-reference/operators/right-shift-assignment-operator.md)|  
|(T x) [=>](../../../csharp/language-reference/operators/lambda-operator.md) y|Anonymous function (lambda expression)|  
  
## Associativity  
 When two or more operators that have the same precedence are present in an expression, they are evaluated based on associativity. Left-associative operators are evaluated in order from left to right. For example, `x * y / z` is evaluated as `(x * y) / z`. Right-associative operators are evaluated in order from right to left. For example, the assignment operator is right associative. If it were not, the following code would result in an error.  
  
```csharp  
int a, b, c;  
c = 1;  
// The following two lines are equivalent.  
a = b = c;  
a = (b = c);  
  
// The following line, which forces left associativity, causes an error.  
//(a = b) = c;  
```  
  
 As another example the ternary operator ([?:](../../../csharp/language-reference/operators/conditional-operator.md)) is right associative. Most binary operators are left associative.  
  
 Whether the operators in an expression are left associative or right associative, the operands of each expression are evaluated first, from left to right. The following examples illustrate the order of evaluation of operators and operands.  
  
|Statement|Order of evaluation|  
|---------------|-------------------------|  
|`a = b`|a, b, =|  
|`a = b + c`|a, b, c, +, =|  
|`a = b + c * d`|a, b, c, d, *, +, =|  
|`a = b * c + d`|a, b, c, *, d, +, =|  
|`a = b - c + d`|a, b, c, -, d, +, =|  
|`a += b -= c`|a, b, c, -=, +=|  
  
## Adding Parentheses  
 You can change the order imposed by operator precedence and associativity by using parentheses. For example, `2 + 3 * 2` ordinarily evaluates to 8, because multiplicative operators take precedence over additive operators. However, if you write the expression as `(2 + 3) * 2`, the addition is evaluated before the multiplication, and the result is 10. The following examples illustrate the order of evaluation in parenthesized expressions. As in previous examples, the operands are evaluated before the operator is applied.  
  
|Statement|Order of evaluation|  
|---------------|-------------------------|  
|`a = (b + c) * d`|a, b, c, +, d, *, =|  
|`a = b - (c + d)`|a, b, c, d, +, -, =|  
|`a = (b + c) * (d - e)`|a, b, c, +, d, e, -, *, =|  
  
## Operator Overloading  
 You can change the behavior of operators for custom classes and structs. This process is referred to as *operator overloading*. For more information, see [Overloadable Operators](../../../csharp/programming-guide/statements-expressions-operators/overloadable-operators.md).  
  
## Related Sections  
 For more information, see [Operator Keywords](../../../csharp/language-reference/keywords/operator-keywords.md) and [C# Operators](../../../csharp/language-reference/operators/index.md).  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Statements, Expressions, and Operators](../../../csharp/programming-guide/statements-expressions-operators/index.md)
