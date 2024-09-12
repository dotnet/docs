---
title: Fix errors that involve overload resolution
description: Compiler errors and warnings that indicate a problem in your code related to overload resolution. Learn causes and fixes for these errors.
f1_keywords:
  - "CS0034"
  - "CS0035"
  - "CS0111"
  - "CS0121"
  - "CS0457"
  - "CS0663"
  - "CS1007"
  - "CS1019"
  - "CS1020"
  - "CS1062"
  - "CS1064"
  - "CS1501"
  - "CS1534"
  - "CS1535"
  - "CS1928"
  - "CS1929"
  - "CS3006"
  - "CS8315"
  - "CS9261"
  - "CS9262"
helpviewer_keywords:
  - "CS0034"
  - "CS0035"
  - "CS0111"
  - "CS0121"
  - "CS0457"
  - "CS0663"
  - "CS1007"
  - "CS1019"
  - "CS1020"
  - "CS1501"
  - "CS1534"
  - "CS1535"
  - "CS1928"
  - "CS1929"
  - "CS3006"
  - "CS8315"
  - "CS9261"
  - "CS9262"
ms.date: 09/10/2024
---
# Resolve errors and warnings that affect overload resolution.

This article covers the following compiler errors:

- [**CS0034**](#ambiguous-overloads) - *Operator is ambiguous on operands of type '`type1`' and '`type2`'*
- [**CS0035**](#ambiguous-overloads) - *Operator is ambiguous on an operand of type 'type'*
- [**CS0111**](#duplicate-overloads-defined) - *Type already defines a member called 'name' with the same parameter types*
- [**CS0121**](#ambiguous-overloads) - *The call is ambiguous between the following methods or properties*
- [**CS0457**](#ambiguous-overloads) - *Ambiguous user defined conversions when converting from 'type1' to 'type2'*
- [**CS0663**](#incorrect-overload-definition) - *Cannot define overloaded methods that differ only on `ref` and `out`.*
- [**CS1007**](#duplicate-overloads-defined) - *Property accessor already defined*
- [**CS1019**](#incorrect-overload-definition) - *Overloadable unary operator expected*
- [**CS1020**](#incorrect-overload-definition) - *Overloadable binary operator expected*
- [**CS1501**](#no-overload-found) - *No overload for method 'method' takes 'number' arguments*
- [**CS1534**](#incorrect-overload-definition) - *Overloaded binary operator 'operator' takes two parameters*
- [**CS1535**](#incorrect-overload-definition) - *Overloaded unary operator 'operator' takes one parameter*
- [**CS1928**](#no-overload-found) - *'Type' does not contain a definition for 'method' and the best extension method overload 'method' has some invalid arguments.*
- [**CS1929**](#no-overload-found) - *'TypeA' does not contain a definition for 'method' and the best extension method overload 'TypeB.method' requires a receiver of type 'TypeC'*
- [**CS8315**](#ambiguous-overloads) - *Operator is ambiguous on operands*
- [**CS9261**](#overload-resolution-priority) - *Cannot use '`OverloadResolutionPriorityAttribute`' on an overriding member.*
- [**CS9262**](#overload-resolution-priority) - *Cannot use '`OverloadResolutionPriorityAttribute`' on this member.*

In addition, the following compiler warning:

- [**CS3006**](#incorrect-overload-definition) - *Overloaded method 'method' differing only in `ref` or `out`, or in array rank, is not CLS-compliant*

## Incorrect overload definition

- **CS0663** - *Cannot define overloaded methods that differ only on `ref` and `out`.*
- **CS1019** - *Overloadable unary operator expected*
- **CS1020** - *Overloadable binary operator expected*
- **CS1534** - *Overloaded binary operator 'operator' takes two parameters*
- **CS1535** - *Overloaded unary operator 'operator' takes one parameter*

In addition, the following compiler warning:

- **CS3006** - *Overloaded method 'method' differing only in `ref` or `out`, or in array rank, is not CLS-compliant*

When you create overloaded operators in your class, the signature must match the number of parameters required for that operator. You have the wrong number of parameters in the operator definition.

In addition, overload operators must use the defined operator name. The only exception is when you create a [conversion operator](../operators/user-defined-conversion-operators.md), where the operator name matches the return type of the conversion.

## Duplicate overloads defined

- **CS0111** - *Type already defines a member called 'name' with the same parameter types*
- **CS1007** - *Property accessor already defined*

These errors indicate that you created overloads that aren't different. Common reasons include:

- The matching parameter types have an identity conversion. For example `M(dynamic)` and `M(object)`, or `M2(string)` and `M2(string?)`.
- The matching parameter types differ only in reference modifier. For example, `M(ref int)` and `M(out int)`.
- You've included both an `init` and a `set` accessor for a property.

## No overload found

- **CS1501** - *No overload for method 'method' takes 'number' arguments*
- **CS1928** - *'Type' does not contain a definition for 'method' and the best extension method overload 'method' has some invalid arguments.*
- **CS1929** - *'TypeA' does not contain a definition for 'method' and the best extension method overload 'TypeB.method' requires a receiver of type 'TypeC'*

Your code calls a method where the name exists, but some arguments are incorrect, or you've used the wrong number of arguments. If you're trying to call an extension method, the containing class might be in a namespace that's not imported.

> [!NOTE]
> Error `CS1928` isn't used by the latest compilers. Newer compilers use `CS1929` exclusively.

## Ambiguous overloads

- **CS0034** - *Operator is ambiguous on operands of type '`type1`' and '`type2`'*
- **CS0035** - *Operator is ambiguous on an operand of type 'type'*
- **CS0121** - *The call is ambiguous between the following methods or properties*
- **CS0457** - *Ambiguous user defined conversions when converting from 'type1' to 'type2'*
- **CS8315** - *Operator is ambiguous on operands*

These errors indicate there isn't one better overload than others. There are several possible causes for these errors:

- Different arguments are better for each parameter. One might be an exact match and the other requires a conversion:

  ```csharp
    void M(int a, double b) {    }
    void M(double a, int b) {}
    
    M(1, 1); // ambiguous
  ```

- Multiple user defined conversion operators are candidates. Conversion operators can be declared in the source type, its base types, the destination type, or its base types. If a conversion operator was defined in more than one, the compiler can't pick.
- Multiple conversion operators could perform a compatible conversion.
- One or more arguments uses `default` (not `default(T)`) and multiple types could be chosen.

In most of these cases, adding an explicit cast can specify which overload should be chosen.

## Overload resolution priority

- **CS9261** - *Cannot use '`OverloadResolutionPriorityAttribute`' on an overriding member.*
- **CS9262** - *Cannot use '`OverloadResolutionPriorityAttribute`' on this member.*

Your code violated the rules for using the <xref:System.Runtime.CompilerServices.OverloadResolutionPriorityAttribute> to favor one overload instead of another. You can't apply the `OverloadResolutionPriorityAttribute` to the following method types:

- Non-indexer properties
- Property, indexer, or event accessors
- Conversion operators
- Lambdas
- Local functions
- Finalizers
- Static constructors

In addition, you can't apply the `OverloadResolutionPriorityAttribute` to an `override` of a `virtual` or `abstract` member. The compiler uses the value from the base type declaration.
