---
title: C# Expressions - A tour of the C# language
description: expressions, operands, and operators are building blocks of the C# language
keywords: .NET, csharp, expression, operator, operand
author: BillWagner
ms.author: wiwagn
ms.date: 11/06/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 20d5eb10-7381-47b9-ad90-f1cc895aa27e
---

# Expressions

*Expressions* are constructed from *operands* and *operators*. The operators of an expression indicate which operations to apply to the operands. Examples of operators include `+`, `-`, `*`, `/`, and `new`. Examples of operands include literals, fields, local variables, and expressions.

When an expression contains multiple operators, the *precedence* of the operators controls the order in which the individual operators are evaluated. For example, the expression `x + y * z` is evaluated as `x + (y * z)` because the `*` operator has higher precedence than the `+` operator.

When an operand occurs between two operators with the same precedence, the *associativity* of the operators controls the order in which the operations are performed:

*	Except for the assignment operators, all binary operators are *left-associative*, meaning that operations are performed from left to right. For example, `x + y + z` is evaluated as `(x + y) + z`.
*	The assignment operators and the conditional operator (`?:`) are *right-associative*, meaning that operations are performed from right to left. For example, `x = y = z` is evaluated as `x = (y = z)`.

Precedence and associativity can be controlled using parentheses. For example, `x + y * z` first multiplies `y` by `z` and then adds the result to `x`, but `(x + y) * z` first adds `x` and `y` and then multiplies the result by `z`.

Most operators can be *overloaded*. Operator overloading permits user-defined operator implementations to be specified for operations where one or both of the operands are of a user-defined class or struct type.

The following summarizes C#’s operators, listing the operator categories in order of precedence from highest to lowest. Operators in the same category have equal precedence. Under each category is a list of expressions in that category along with the description of that expression type.

* Primary
    - `x.m`: Member access
	- `x(...)`: Method and delegate invocation
	- `x[...]`: Array and indexer access
	- `x++`: Post-increment
	- `x--`: Post-decrement
	- `new T(...)`:	Object and delegate creation
	- `new T(...){...}`: Object creation with initializer
	- `new {...}`:  Anonymous object initializer
	- `new T[...]`: Array creation
	- `typeof(T)`: Obtain <xref:System.Type> object for `T`
	- `checked(x)`: Evaluate expression in checked context
	- `unchecked(x)`: Evaluate expression in unchecked context
	- `default(T)`: Obtain default value of type `T`
	- `delegate {...}`: Anonymous function (anonymous method)
* Unary
    - `+x`: Identity
	- `-x`: Negation
	- `!x`: Logical negation
	- `~x`: Bitwise negation
	- `++x`: Pre-increment
	- `--x`: Pre-decrement
	- `(T)x`: Explicitly convert `x` to type `T`
	- `await x`: Asynchronously wait for `x` to complete
* Multiplicative
    - `x * y`: Multiplication
	- `x / y`: Division
	- `x % y`: Remainder
* Additive
    - `x + y`: Addition, string concatenation, delegate combination
	- `x – y`: Subtraction, delegate removal
* Shift
    - `x << y`: Shift left
	- `x >> y`: Shift right
* Relational and type testing
    - `x < y`: Less than
	- `x > y`: Greater than
	- `x <= y`: Less than or equal
	- `x >= y`: Greater than or equal
	- `x is T`: Return `true` if `x` is a `T`, `false` otherwise
	- `x as T`: Return `x` typed as `T`, or `null` if `x` is not a `T`
* Equality
    - `x == y`: Equal
	- `x != y`: Not equal
* Logical AND
    - `x & y`: Integer bitwise AND, boolean logical AND
* Logical XOR
    - `x ^ y`: Integer bitwise XOR, boolean logical XOR
* Logical OR
    - `x | y`: Integer bitwise OR, boolean logical OR
* Conditional AND
    - `x && y`: Evaluates `y` only if `x` is not `false`
* Conditional OR
    - `x || y`: Evaluates `y` only if `x` is not `true`
* Null coalescing
    - `x ?? y`: Evaluates to `y` if `x` is null, to `x` otherwise
* Conditional
    - `x ? y : z`: Evaluates `y` if `x` is `true`, `z` if `x` is `false`
* Assignment or anonymous function
    - `x = y`: Assignment
	- `x op= y`: Compound assignment; supported operators are
        - `*=`   `/=`   `%=`   `+=`   `-=`   `<<=`   `>>=`   `&=`  `^=`  `|=`
	- `(T x) => y`: Anonymous function (lambda expression)

>[!div class="step-by-step"]
[Previous](types-and-variables.md)
[Next](statements.md)
