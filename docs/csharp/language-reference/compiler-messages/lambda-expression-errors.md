---
title: Lambda expression warnings
description: This article helps you diagnose and correct compiler errors and warnings for lambda expression declarations and usage.
f1_keywords:
  - "CS0748"
  - "CS0835"
  - "CS1621"
  - "CS1628"
  - "CS1632"
  - "CS1673"
  - "CS1686"
  - "CS1706"
  - "CS8030"
  - "CS8175"
  - "CS8916"
  - "CS8971"
  - "CS8975"
  - "CS9098" # ERR_ImplicitlyTypedDefaultParameter: Implicitly typed lambda parameter '{0}' cannot have a default value.
  - "CS9099" # WRN_OptionalParamValueMismatch: The default parameter value does not match in the target delegate type.
  - "CS9100" # WRN_ParamsArrayInLambdaOnly: Parameter has params modifier in lambda but not in target delegate type.
helpviewer_keywords:
  - "CS0748"
  - "CS0835"
  - "CS1621"
  - "CS1628"
  - "CS1632"
  - "CS1673"
  - "CS1686"
  - "CS1706"
  - "CS8030"
  - "CS8175"
  - "CS8916"
  - "CS8971"
  - "CS8975"
  - "CS9098"
  - "CS9099"
  - "CS9100"
ms.date: 05/04/2023
---
# Errors and warnings when using lambda expressions and anonymous functions

There are several *errors* related to declaring and using lambda expressions:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0748**](#lambda-expression-parameters-and-returns): *Inconsistent lambda parameter usage; parameter types must be all explicit or all implicit.*
- [**CS1621**](#syntax-limitations-in-lambda-expressions): *The yield statement cannot be used inside an anonymous method or lambda expression.*
- [**CS1628**](#syntax-limitations-in-lambda-expressions): *Cannot use `in` `ref` or `out` parameter inside an anonymous method, lambda expression, or query expression.*
- [**CS1632**](#syntax-limitations-in-lambda-expressions): *Control cannot leave the body of an anonymous method or lambda expression.*
- [**CS1673**](#syntax-limitations-in-lambda-expressions): *Anonymous methods, lambda expressions, and query expressions inside structs cannot access instance members of 'this'.*
- [**CS1686**](#syntax-limitations-in-lambda-expressions): *Local variable or its members cannot have their address taken and be used inside an anonymous method or lambda expression.*
- [**CS1706**](#syntax-limitations-in-lambda-expressions): *Expression cannot contain anonymous methods or lambda expressions.*
- [**CS8030**](#syntax-limitations-in-lambda-expressions): *Anonymous function converted to a void returning delegate cannot return a value.*
- [**CS8175**](#syntax-limitations-in-lambda-expressions): *Cannot use ref local inside an anonymous method, lambda expression, or query expression.*
- [**CS8916**](#lambda-expression-parameters-and-returns): *Attributes on lambda expressions require a parenthesized parameter list.*
- [**CS8971**](#syntax-limitations-in-lambda-expressions): *InterpolatedStringHandlerArgument has no effect when applied to lambda parameters and will be ignored at the call site.*
- [**CS8975**](#lambda-expression-parameters-and-returns): *The contextual keyword `var` cannot be used as an explicit lambda return type.*
- [**CS9098**](#lambda-expression-parameters-and-returns): *Implicitly typed lambda parameter '...' cannot have a default value.*

In addition, there are several *warnings* related to declaring and using lambda expressions:

- [**CS8971**](#syntax-limitations-in-lambda-expressions): *InterpolatedStringHandlerArgument has no effect when applied to lambda parameters and will be ignored at the call site.*
- [**CS9099**](#lambda-expression-delegate-type): *The default parameter value does not match in the target delegate type.*
- [**CS9100**](#lambda-expression-delegate-type): *Parameter has params modifier in lambda but not in target delegate type.*

## Syntax limitations in lambda expressions

Some C# syntax is prohibited in lambda expressions and anonymous methods. Using invalid constructs in a lambda expression causes the following errors:

- **CS1621**: *The `yield` statement cannot be used inside an anonymous method or lambda expression.*
- **CS1628**: *Cannot use `in`, `ref`, or `out` parameter inside an anonymous method, lambda expression, or query expression.*
- **CS1632**: *Control cannot leave the body of an anonymous method or lambda expression.*
- **CS1673**: *Anonymous methods, lambda expressions, and query expressions inside structs cannot access instance members of `this`.*
- **CS1686**: *Local variable or its members cannot have their address taken and be used inside an anonymous method or lambda expression.*
- **CS8175**: *Cannot use ref local inside an anonymous method, lambda expression, or query expression.*

All the following constructs are disallowed in lambda expressions:

- `yield` statements (`yield return` or `yield break`)
- Calling a method that has an `in`, `ref`, or `out` parameter
- `ref` local variables
- `break`, `goto`, and `continue` statements
- `this` access when `this` is a `struct` type
- Anonymous methods or lambda expressions inside another expression, such as an Attribute constructor.

You can't use any of these constructs in a lambda expression or an anonymous method. Many are allowed in a [local function](../../programming-guide/classes-and-structs/local-functions.md).

In addition, interpolated string handler types are ignored when applied to a lambda parameter. If you use one, you see the following warning:

- **CS8971**:  *InterpolatedStringHandlerArgument has no effect when applied to lambda parameters and will be ignored at the call site.*

## Lambda expression parameters and returns

These errors indicate a problem with a parameter declaration:

- **CS0748**:  *Inconsistent lambda parameter usage; parameter types must be all explicit or all implicit.*
- **CS9098**:  *Implicitly typed lambda parameter '...' cannot have a default value.*
- **CS8030**:  *Anonymous function converted to a void returning delegate cannot return a value.*
- **CS8916**:  *Attributes on lambda expressions require a parenthesized parameter list.*
- **CS8975**:  *The contextual keyword 'var' cannot be used as an explicit lambda return type.*

Lambda expression parameters must follow these rules:

- When a lambda expression has multiple parameters, either all parameters must be explicitly typed or all parameters must be implicitly typed.
- All lambda parameters with a default value must be explicitly typed.
- If attributes are applied to any parameters, the parameter list must be enclosed in parentheses.

Return types of lambda expression must follow these rules:

- A lambda expression that returns any value can't be converted to a `void` returning delegate, such as `Action`.
- The return type is either inferred, or an explicit type. A return type declared using the keyword `var` isn't allowed.

## Lambda expression delegate type

- [**CS9099**](#lambda-expression-delegate-type): Warning: *The default parameter value does not match in the target delegate type.*

When you declare a default value or add the `params` modifier with a lambda expression parameter, the delegate type isn't one of the `Func` or `Action` types. Rather, it's a custom type that includes the default parameter value or `params` modifier. The following code generates warnings because it assigns a lambda expression that has a default parameter to an `Action` type:

```csharp
Action<int> a1 = (int i = 2) => { };
Action<string[]> a3 = (params string[] s) => { };
```

To fix the error, either remove the default parameter or use an implicitly typed variable for the delegate type:

```csharp
Action<int> a1 = (int i) => { };
var a2 = (int i = 2) => { };
Action<string[]> a3 = (string[] s) => { };
var a4 = (params string[] s) => { };
```
