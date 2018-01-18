---
title: "is (C# Reference)"
keywords: is keyword (C#), is (C#)
ms.date: 02/17/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "is_CSharpKeyword"
  - "is"
helpviewer_keywords: 
  - "is keyword [C#]"
ms.assetid: bc62316a-d41f-4f90-8300-c6f4f0556e43
caps.latest.revision: 20
author: "BillWagner"
ms.author: "wiwagn"
---
# is (C# Reference) #

Checks if an object is compatible with a given type, or (starting with C# 7) tests an expression against a pattern.

## Testing for type compatibility ##

The `is` keyword evaluates type compatibility at runtime. It determines whether an object instance or the result of an expression can be converted to a specified type. It has the syntax

```csharp
   expr is type
```

where *expr* is an expression that evaluates to an instance of some type, and *type* is the name of the type to which the result of *expr* is to be converted. The `is` statement is `true` if *expr* is non-null and the object that results from evaluating the expression can be converted to *type*; otherwise, it returns `false`.

For example, the following code determines if `obj` can be cast to an instance of the `Person` type:

[!code-csharp[is#1](../../../../samples/snippets/csharp/language-reference/keywords/is/is1.cs#1)]

The `is` statement is true if:

- *expr* is an instance of the same type as *type*.

- *expr* is an instance of a type that derives from *type*. In other words, the result of *expr* can be upcast to an instance of *type*.

- *expr* has a compile-time type that is a base class of *type*, and *expr* has a runtime type that is *type* or is derived from *type*. The *compile-time type* of a variable is the variable's type as defined in its declaration. The *runtime type* of a variable is the type of the instance that is assigned to that variable.

- *expr* is an instance of a type that implements the *type* interface.

The following example shows that the `is` expression evaluates to `true` for each of these conversions.

[!code-csharp[is#3](../../../../samples/snippets/csharp/language-reference/keywords/is/is3.cs#3)]

The `is` keyword generates a compile-time warning if the expression is known to always be either `true` or `false`. It only considers reference conversions, boxing conversions, and unboxing conversions; it does not consider user-defined conversions or conversions defined by a type's [implicit](implicit.md) and [explicit](explicit.md) operators. The following example generates warnings because the result of the conversion is known at compile-time. Note that the `is` expression for conversions from `int` to `long` and `double` return false, since these conversions are handled by the [implicit](implicit.md) operator.

[!code-csharp[is#2](../../../../samples/snippets/csharp/language-reference/keywords/is/is2.cs#2)]

`expr` can be any expression that returns a value, with the exception of anonymous methods and lambda expressions. The following example uses  `is` to evaluate the return value of a method call.   
[!code-csharp[is#4](../../../../samples/snippets/csharp/language-reference/keywords/is/is4.cs#4)]

Starting with C# 7, you can use pattern matching with the [type pattern](#type) to write more concise code that uses the `is` statement.

## Pattern matching with `is` ##

Starting with C# 7, the `is` and [switch](../../../csharp/language-reference/keywords/switch.md) statements support pattern matching. The `is` keyword supports the following patterns:

- [Type pattern](#type),  which tests whether an expression can be converted to a specified type and, if it can be, casts it to a variable of that type.

- [Constant pattern](#constant), which tests whether an expression evaluates to a specified constant value.

- [var pattern](#var), a match that always succeeds and binds the value of an expression to a new local variable. 

### <a name="type" /> Type pattern </a>

When using the type pattern to perform pattern matching, `is` tests whether an expression can be converted to a specified type and, if it can be, casts it to a variable of that type. It is a straightforward extension of the `is` statement that enables concise type evaluation and conversion. The general form of the `is` type pattern is:

```csharp
   expr is type varname 
```

where *expr* is an expression that evaluates to an instance of some type, *type* is the name of the type to which the result of *expr* is to be converted, and *varname* is the object to which the result of *expr* is converted if the `is` test is `true`. 

The `is` expression is `true` if any of the following is true:

- *expr* is an instance of the same type as *type*.

- *expr* is an instance of a type that derives from *type*. In other words, the result of *expr* can be upcast to an instance of *type*.

- *expr* has a compile-time type that is a base class of *type*, and *expr* has a runtime type that is *type* or is derived from *type*. The *compile-time type* of a variable is the variable's type as defined in its declaration. The *runtime type* of a variable is the type of the instance that is assigned to that variable.

- *expr* is an instance of a type that implements the *type* interface.

If *exp* is `true` and `is` is used with an `if` statement, *varname* is assigned and has local scope within the `if` statement only.

The following example uses the `is` type pattern to provide the implementation of a type's <xref:System.IComparable.CompareTo(System.Object)?displayProperty=nameWithType> method.

[!code-csharp[is#5](../../../../samples/snippets/csharp/language-reference/keywords/is/is-type-pattern5.cs#5)]

Without pattern matching, this code might be written as follows. The use of type pattern matching produces more compact, readable code by eliminating the need to test whether the result of a conversion is a `null`.  

[!code-csharp[is#6](../../../../samples/snippets/csharp/language-reference/keywords/is/is-type-pattern6.cs#6)]

The `is` type pattern also produces more compact code when determining the type of a value type. The following example uses the `is` type pattern to determine whether an object is a `Person` or a `Dog` instance before displaying the value of an appropriate property. 

[!code-csharp[is#9](../../../../samples/snippets/csharp/language-reference/keywords/is/is-type-pattern9.cs#9)]

The equivalent code without pattern matching requires a separate assignment that includes an explicit cast.

[!code-csharp[is#10](../../../../samples/snippets/csharp/language-reference/keywords/is/is-type-pattern10.cs#10)]

### <a name="constant" /> Constant pattern ###

When performing pattern matching with the constant pattern, `is` tests whether an expression equals a specified constant. In C# 6 and earlier versions, the constant pattern is supported by the [switch](switch.md) statement. Starting with C# 7, it is supported by the `is` statement as well. Its syntax is:

```csharp
   expr is constant
```

where *expr* is the expression to evaluate, and *constant* is the value to test for. *constant* can be any of the following constant expressions: 

- A literal value.

- The name of a declared `const` variable.

- An enumeration constant.

The constant expression is evaluated as follows:

- If *expr* and *constant* are integral types, the C# equality operator determines whether the expression returns `true` (that is, whether `expr == constant`).

- Otherwise, the value of the expression is determined by a call to the static [Object.Equals(expr, constant)](xref:System.Object.Equals(System.Object,System.Object)) method.  

The following example combines the type and constant patterns to test whether an object is a `Dice` instance and, if it is, to determine whether the value of a dice roll is 6.

[!code-csharp[is#7](../../../../samples/snippets/csharp/language-reference/keywords/is/is-const-pattern7.cs#7)]
 
### <a name="var" /> var pattern </a>

A pattern match with the var pattern always succeeds. Its syntax is

```csharp 
   expr is var varname
```

where the value of *expr* is always assigned to a local variable named *varname*. *varname* is a static variable of the same type as *expr*. The following example uses the var pattern to assign an expression to a variable named `obj`. It then displays the value and the type of `obj`.

[!code-csharp[is#8](../../../../samples/snippets/csharp/language-reference/keywords/is/is-var-pattern8.cs#8)]

Note that if *expr* is `null`, the `is` expression still is true and assigns `null` to *varname*. 

# C# Language Specification
  
[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [typeof](../../../csharp/language-reference/keywords/typeof.md)  
 [as](../../../csharp/language-reference/keywords/as.md)  
 [Operator Keywords](../../../csharp/language-reference/keywords/operator-keywords.md)
