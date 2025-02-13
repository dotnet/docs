---
title: Errors and warnings related to `params` arrays
description: This article helps you diagnose and correct compiler errors and warnings when you use the `params` modifier on method parameters.
f1_keywords:
  - "CS0225"
  - "CS0231"
  - "CS0466"
  - "CS0674"
  - "CS0758"
  - "CS1104"
  - "CS1611"
  - "CS1670"
  - "CS1751"
  - "CS9218"
  - "CS9223"
  - "CS9224"
  - "CS9225"
  - "CS9227"
  - "CS9228"
  - "CS9272"
helpviewer_keywords:
  - "CS0225"
  - "CS0231"
  - "CS0466"
  - "CS0674"
  - "CS0758"
  - "CS1104"
  - "CS1611"
  - "CS1670"
  - "CS1751"
  - "CS9218"
  - "CS9223"
  - "CS9224"
  - "CS9225"
  - "CS9227"
  - "CS9228"
  - "CS9272"
ms.date: 02/13/2025
---
# Errors and warnings related to the `params` modifier on method parameters

There are a few *errors* related to the `lock` statement and thread synchronization:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0225**](#parameter-and-argument-type-rules): *The params parameter must be a single-dimensional array or have a valid collection type*
- [**CS0231**](#method-declaration-rules): *A params parameter must be the last parameter in a formal parameter list.*
- [**CS0466**](#other-params-errors): *'method1' should not have a params parameter since 'method2' does not*
- [**CS0674**](#other-params-errors): *Do not use `System.ParamArrayAttribute` or `System.ParamArrayAttribute`/`System.Runtime.CompilerServices.ParamCollectionAttribute`. Use the `params` keyword instead.*
- [**CS0758**](#other-params-errors): *Both partial method declarations must use a `params` parameter or neither may use a `params` parameter*
- [**CS1104**](#method-declaration-rules): *A parameter array cannot be used with `this` modifier on an extension method.*
- [**CS1611**](#method-declaration-rules): *The params parameter cannot be declared as in `ref` or `out`*
- [**CS1670**](#method-declaration-rules): *`params` is not valid in this context*
- [**CS1751**](#method-declaration-rules): *Cannot specify a default value for a parameter array.*
- [**CS9218**](#parameter-and-argument-type-rules): *The type arguments for method cannot be inferred from the usage because an argument with dynamic type is used and the method has a non-array params collection parameter. Try specifying the type arguments explicitly.*
- [**CS9223**](#other-params-errors): *Creation of params collection results in an infinite chain of invocation of constructor.*
- [**CS9224**](#other-params-errors): *Method cannot be less visible than the member with params collection.*
- [**CS9225**](#other-params-errors): *Constructor leaves required member uninitialized.*
- [**CS9227**](#parameter-and-argument-type-rules): *Type does not contain a definition for a suitable instance `Add` method.*
- [**CS9228**](#parameter-and-argument-type-rules): *Non-array params collection type must have an applicable constructor that can be called with no arguments.*
- [**CS9272**](#other-params-errors): *Implicitly typed lambda parameter cannot have the 'params' modifier.*

## Method declaration rules

The following errors indicate using a `params` modifier on a parameter when the `params` modifier isn't allowed in that context:

- **CS0231**: *A params parameter must be the last parameter in a formal parameter list.*
- **CS1104**: *A parameter array cannot be used with `this` modifier on an extension method.*
- **CS1611**: *The params parameter cannot be declared as in `ref` or `out`*
- **CS1670**: *`params` is not valid in this context*
- **CS1751**: *Cannot specify a default value for a parameter array.*

The compiler enforces the following rules on your use of the `params` modifier on a method parameter:

- The `params` modifier is allowed only on the last parameter in a formal parameter list. This includes any parameters with a default value.
- You can't include a default argument for the parameter when the `params` modifier is used.
- The `params` modifier can't be applied to reference parameter. A reference parameter is one with the `in`, `ref readonly`, `ref` or `out` modifier.
- The `params` modifier can't be combined with the `this` modifier on an extension method.
- The `params` modifier can't be used on an overloaded operator.

In versions before C# 12, the `params` modifier can't be used on the parameter of an anonymous method or lambda expression.

## Parameter and argument type rules

The following errors indicate that the type of the parameter used with `params` is invalid:

- **CS9218**: *The type arguments for method cannot be inferred from the usage because an argument with dynamic type is used and the method has a non-array params collection parameter. Try specifying the type arguments explicitly.*
- **CS0225**: *The params parameter must be a single-dimensional array or have a valid collection type*
- **CS9227**: *Type does not contain a definition for a suitable instance `Add` method.*
- **CS9228**: *Non-array params collection type must have an applicable constructor that can be called with no arguments.*

In versions before C# 13, the `params` modifier is allowed on single-dimensional arrays only. No other types were valid.

Starting with C# 13 any valid collection type can be used. However, some restrictions remain. The collection type must follow the same rules as the target of a [collection expression](../operators/collection-expressions.md#conversions).

## Other params errors

The following errors indicate other issues with using the `params` modifier:

- **CS0466**: *'method1' should not have a params parameter since 'method2' does not*
- **CS0674**: *Do not use `System.ParamArrayAttribute` or `System.Runtime.CompilerServices.ParamCollectionAttribute`. Use the `params` keyword instead.*
- **CS0758**: *Both partial method declarations must use a `params` parameter or neither may use a `params` parameter*
- **CS9223**: *Creation of params collection results in an infinite chain of invocation of constructor.*
- **CS9224**: *Method cannot be less visible than the member with params collection.*
- **CS9225**: *Constructor leaves required member uninitialized.*
- **CS9272**: *Implicitly typed lambda parameter cannot have the 'params' modifier.*

A method that implements an interface must include the `params` modifier if and only if the interface member has the `params` modifier. Similarly, either both declarations of a `partial` method must include the `params` modifier, or none can include the `params` modifier.

You must use the `params` modifier. You can't apply the equivalent attributes, either <xref:System.ParamArrayAttribute?displayProperty=nameWithType> or <xref:System.Runtime.CompilerServices.ParamCollectionAttribute?displayProperty=nameWithType>.

The compiler generates one of the final three errors in the preceding list when the code generated to create the collection type is invalid:

- The compiler emits **CS9223** when the code emitted to create the collection also contains a params collection of the same type. Typically, the `Add` method takes a `params` collection of the same type.
- The compiler emits **CS9224** when the `Create` method for the collection type is less accessible than the method that takes the `params` parameter of the collection type.
- The compiler emits **CS9225** when the collection type has a required member and the parameterless constructor doesn't initialize that member and have the <xref:System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute?displayProperty=nameWithType> on the parameterless constructor.
- The compiler emits **CS9272** when you've used the `params` modifier without type information on a lambda expression. You must specify the types for all lambda expression parameters to use the `params` modifier.

## See also

- [Extension Methods](../../programming-guide/classes-and-structs/extension-methods.md)
- [Partial Classes and Methods](../../programming-guide/classes-and-structs/partial-classes-and-methods.md)
- [Collection expressions](../operators/collection-expressions.md)
- [params](../keywords/method-parameters.md#params-modifier)
