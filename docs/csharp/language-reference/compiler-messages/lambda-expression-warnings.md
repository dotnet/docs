---
title: Lambda expression warnings
description: Ths article helps you diagnose and correct compiler errors and warnings for lambda expression declarations and usage.
f1_keywords:
  - "CS9098" # ERR_ImplicitlyTypedDefaultParameter: Implicitly typed lambda parameter '{0}' cannot have a default value.
  - "CS9099" # WRN_OptionalParamValueMismatch: The default parameter value does not match in the target delegate type.
  - "CS9100" # WRN_ParamsArrayInLambdaOnly: Parameter has params modifier in lambda but not in target delegate type.
helpviewer_keywords:
  - "CS9098"
  - "CS9099"
  - "CS9100"
ms.date: 05/04/2023
---
# Errors and warnings when declaring and using lambda expressions and anonymous functions

There are several errors related to declaring and using lambda expressions:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's be design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS9098**](#lambda-expression-parameter-declarations) - *Implicitly type lambda parameter '...' cannot have a default value.*

In addition, there are several warnings related to declaring and using lambda expressions:

- [**CS9099**](#lambda-expression-delegate-type) - *The default parameter value does not match in the target delegate type.*
- [**CS9100**](#lambda-expression-delegate-type) - *Parameter has params modifier in lambda but not in target delegate type.*

## Lambda expression parameter declarations

These errors indicate a problem with a parameter declaration:

- **CS9098** - *Implicitly type lambda parameter '...' cannot have a default value.*

Starting with C# 12, lambda expressions can include default values on parameters. However, those parameter declarations must have a type:

```csharp
var l = (x = 7) => x; // Error: CS9098
```

To fix this, either remove the default value, or declare an explicit type for the parameter:

```csharp
var l = (int x = 7) => x;
Func<int, int> l2 = x => x;
```

## Lambda expression delegate type

- [**CS9099**](#lambda-expression-delegate-type) - Warning: *The default parameter value does not match in the target delegate type.*

When you declare a default value or add the `params` modifier with a lambda expression parameter, the delegate type isn't one of the `Func` or `Action` types. Rather, it's a custom type that includes the default parameter value or `params` modifier. The following code generates warnings because you've assigned a lambda expression that has a default parameter to an `Action` type:

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
