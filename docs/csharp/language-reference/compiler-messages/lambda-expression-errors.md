---
title: Lambda expression warnings
description: This article helps you diagnose and correct compiler errors and warnings for lambda expression declarations and usage.
f1_keywords:
  - "CS0407" # ERR_BadRetType: '{1} {0}' has the wrong return type.
  - "CS0428" # ERR_MethGrpToNonDel: Cannot convert method group '{0}' to non-delegate type '{1}'. Did you intend to invoke the method?
  - "CS0467" # WRN_AmbigLookupMeth (not used in Roslyn): Ambiguity between method '{0}' and non-method '{1}'. Using method group.
  - "CS0748"
  - "CS0815" # ERR_ImplicitlyTypedVariableAssignedBadValue: Cannot assign {0} to an implicitly-typed variable.
  - "CS0828" # ERR_AnonymousTypePropertyAssignedBadValue: Cannot assign '{0}' to anonymous type property.
  - "CS0835"
  - "CS0837" # ERR_LambdaInIsAs: The first operand of an 'is' or 'as' operator may not be a lambda expression, anonymous method, or method group.
  - "CS1065" # ERR_DefaultValueNotAllowed: Default values are not valid in this context.
  - "CS1621"
  - "CS1628"
  - "CS1632"
  - "CS1643" # ERR_AnonymousReturnExpected: Not all code paths return a value in {0} of type '{1}'.
  - "CS1660" # ERR_AnonMethToNonDel: Cannot convert {0} to type '{1}' because it is not a delegate type.
  - "CS1661" # ERR_CantConvAnonMethParams: Cannot convert {0} to type '{1}' because the parameter types do not match the delegate parameter types.
  - "CS1662" # ERR_CantConvAnonMethReturns: Cannot convert {0} to intended delegate type because some of the return types in the block are not implicitly convertible to the delegate return type.
  - "CS1673"
  - "CS1676" # ERR_BadParamRef: Parameter {0} must be declared with the '{1}' keyword.
  - "CS1677" # ERR_BadParamExtraRef: Parameter {0} should not be declared with the '{1}' keyword.
  - "CS1678" # ERR_BadParamType: Parameter {0} is declared as type '{1}' but should be '{2}'.
  - "CS1686"
  - "CS1688" # ERR_CantConvAnonMethNoParams: Cannot convert anonymous method block without a parameter list to delegate type '{0}' because it has one or more out parameters.
  - "CS1706"
  - "CS1731" # ERR_CantConvAnonMethReturnsNoDelegate (not used in Roslyn): Cannot convert expression to delegate because some of the return types in the block are not implicitly convertible to the delegate return type.
  - "CS1732" # ERR_ParameterExpected (not used in Roslyn): Expected parameter.
  - "CS1764" # ERR_FixedLocalInLambda: Cannot use fixed local '{0}' inside an anonymous method, lambda expression, or query expression.
  - "CS1911" # WRN_BaseAccessInClosureError: Access to member through 'base' keyword from anonymous method, lambda expression, query expression, or iterator results in unverifiable code.
  - "CS8030"
  - "CS8175"
  - "CS8820" # ERR_StaticAnonymousFunctionCannotCaptureVariable: A static anonymous function cannot contain a reference to '{0}'.
  - "CS8821" # ERR_StaticAnonymousFunctionCannotCaptureThis: A static anonymous function cannot contain a reference to 'this' or 'base'.
  - "CS8916"
  - "CS8917" # ERR_CannotInferDelegateType: The delegate type could not be inferred.
  - "CS8934" # ERR_CantConvAnonMethReturnType: Cannot convert {0} to type '{1}' because the return type does not match the delegate return type.
  - "CS8971"
  - "CS8974" # WRN_MethGrpToNonDel: Converting method group '{0}' to non-delegate type '{1}'. Did you intend to invoke the method?
  - "CS8975"
  - "CS9098" # ERR_ImplicitlyTypedDefaultParameter: Implicitly typed lambda parameter '{0}' cannot have a default value.
  - "CS9099" # WRN_OptionalParamValueMismatch: The default parameter value does not match in the target delegate type.
  - "CS9100" # WRN_ParamsArrayInLambdaOnly: Parameter has params modifier in lambda but not in target delegate type.
  - "CS9236" # INF_TooManyBoundLambdas: Compiling requires binding the lambda expression at least {0} times.
helpviewer_keywords:
  - "CS0407"
  - "CS0428"
  - "CS0467"
  - "CS0748"
  - "CS0815"
  - "CS0828"
  - "CS0835"
  - "CS0837"
  - "CS1065"
  - "CS1621"
  - "CS1628"
  - "CS1632"
  - "CS1643"
  - "CS1660"
  - "CS1661"
  - "CS1662"
  - "CS1673"
  - "CS1676"
  - "CS1677"
  - "CS1678"
  - "CS1686"
  - "CS1688"
  - "CS1706"
  - "CS1731"
  - "CS1732"
  - "CS1764"
  - "CS1911"
  - "CS8030"
  - "CS8175"
  - "CS8820"
  - "CS8821"
  - "CS8916"
  - "CS8917"
  - "CS8934"
  - "CS8971"
  - "CS8974"
  - "CS8975"
  - "CS9098"
  - "CS9099"
  - "CS9100"
  - "CS9236"
ms.date: 03/04/2026
---
# Errors and warnings when using lambda expressions and anonymous functions

There are several *errors* related to declaring and using lambda expressions:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0407**](#lambda-expression-delegate-type): *'method' has the wrong return type.*
- [**CS0428**](#lambda-expression-delegate-type): *Cannot convert method group 'Identifier' to non-delegate type 'type'. Did you intend to invoke the method?*
- [**CS0748**](#lambda-expression-parameters-and-returns): *Inconsistent lambda parameter usage; parameter types must be all explicit or all implicit.*
- [**CS0815**](#lambda-expression-delegate-type): *Cannot assign 'expression' to an implicitly-typed variable.*
- [**CS0828**](#lambda-expression-delegate-type): *Cannot assign 'expression' to anonymous type property.*
- [**CS0837**](#syntax-limitations-in-lambda-expressions): *The first operand of an 'is' or 'as' operator may not be a lambda expression, anonymous method, or method group.*
- [**CS1065**](#lambda-expression-parameters-and-returns): *Default values are not valid in this context.*
- [**CS1621**](#syntax-limitations-in-lambda-expressions): *The yield statement cannot be used inside an anonymous method or lambda expression.*
- [**CS1628**](#syntax-limitations-in-lambda-expressions): *Cannot use `in` `ref` or `out` parameter inside an anonymous method, lambda expression, or query expression.*
- [**CS1632**](#syntax-limitations-in-lambda-expressions): *Control cannot leave the body of an anonymous method or lambda expression.*
- [**CS1643**](#lambda-expression-parameters-and-returns): *Not all code paths return a value in anonymous method of type 'type'.*
- [**CS1660**](#lambda-expression-delegate-type): *Cannot convert lambda expression to type 'type' because it is not a delegate type.*
- [**CS1661**](#lambda-expression-parameters-and-returns): *Cannot convert anonymous method block to type 'type' because the parameter types do not match the delegate parameter types.*
- [**CS1662**](#lambda-expression-parameters-and-returns): *Cannot convert anonymous method block to intended delegate type because some of the return types in the block are not implicitly convertible to the delegate return type.*
- [**CS1673**](#syntax-limitations-in-lambda-expressions): *Anonymous methods, lambda expressions, and query expressions inside structs cannot access instance members of 'this'.*
- [**CS1676**](#lambda-expression-parameters-and-returns): *Parameter 'number' must be declared with the 'keyword' keyword.*
- [**CS1677**](#lambda-expression-parameters-and-returns): *Parameter 'number' should not be declared with the 'keyword' keyword.*
- [**CS1678**](#lambda-expression-parameters-and-returns): *Parameter 'number' is declared as type 'type1' but should be 'type2'.*
- [**CS1686**](#syntax-limitations-in-lambda-expressions): *Local variable or its members cannot have their address taken and be used inside an anonymous method or lambda expression.*
- [**CS1688**](#lambda-expression-parameters-and-returns): *Cannot convert anonymous method block without a parameter list to delegate type 'delegate' because it has one or more out parameters.*
- [**CS1706**](#syntax-limitations-in-lambda-expressions): *Expression cannot contain anonymous methods or lambda expressions.*
- [**CS1731**](#lambda-expression-parameters-and-returns): *Cannot convert expression to delegate because some of the return types in the block are not implicitly convertible to the delegate return type.*
- [**CS1732**](#lambda-expression-parameters-and-returns): *Expected parameter.*
- [**CS1764**](#syntax-limitations-in-lambda-expressions): *Cannot use fixed local inside an anonymous method, lambda expression, or query expression.*
- [**CS8030**](#syntax-limitations-in-lambda-expressions): *Anonymous function converted to a void returning delegate cannot return a value.*
- [**CS8175**](#syntax-limitations-in-lambda-expressions): *Cannot use ref local inside an anonymous method, lambda expression, or query expression.*
- [**CS8820**](#syntax-limitations-in-lambda-expressions): *A static anonymous function cannot contain a reference to 'variable'.*
- [**CS8821**](#syntax-limitations-in-lambda-expressions): *A static anonymous function cannot contain a reference to 'this' or 'base'.*
- [**CS8916**](#lambda-expression-parameters-and-returns): *Attributes on lambda expressions require a parenthesized parameter list.*
- [**CS8917**](#lambda-expression-delegate-type): *The delegate type could not be inferred.*
- [**CS8934**](#lambda-expression-parameters-and-returns): *Cannot convert anonymous method to type 'type' because the return type does not match the delegate return type.*
- [**CS8971**](#syntax-limitations-in-lambda-expressions): *InterpolatedStringHandlerArgument has no effect when applied to lambda parameters and will be ignored at the call site.*
- [**CS8975**](#lambda-expression-parameters-and-returns): *The contextual keyword `var` cannot be used as an explicit lambda return type.*
- [**CS9098**](#lambda-expression-parameters-and-returns): *Implicitly typed lambda parameter '...' cannot have a default value.*

In addition, there are several *warnings* related to declaring and using lambda expressions:

- [**CS8971**](#syntax-limitations-in-lambda-expressions): *InterpolatedStringHandlerArgument has no effect when applied to lambda parameters and will be ignored at the call site.*
- [**CS1911**](#syntax-limitations-in-lambda-expressions): *Access to member through a 'base' keyword from an anonymous method, lambda expression, query expression, or iterator results in unverifiable code.*
- [**CS0467**](#lambda-expression-delegate-type): *Ambiguity between method 'method' and non-method 'non-method'. Using method group.*
- [**CS8974**](#lambda-expression-delegate-type): *Converting method group 'method' to non-delegate type 'type'. Did you intend to invoke the method?*
- [**CS9099**](#lambda-expression-delegate-type): *The default parameter value does not match in the target delegate type.*
- [**CS9100**](#lambda-expression-delegate-type): *Parameter has params modifier in lambda but not in target delegate type.*

The compiler also produces the following *informational* message:

- [**CS9236**](#syntax-limitations-in-lambda-expressions): *Compiling requires binding the lambda expression at least count times. Consider declaring the lambda expression with explicit parameter types, or if the containing method call is generic, consider using explicit type arguments.*

## Syntax limitations in lambda expressions

Some C# syntax is prohibited in lambda expressions and anonymous methods. Using invalid constructs in a lambda expression causes the following errors:

- **CS0837**: *The first operand of an `is` or `as` operator may not be a lambda expression, anonymous method, or method group.*
- **CS1621**: *The `yield` statement cannot be used inside an anonymous method or lambda expression.*
- **CS1628**: *Cannot use `in`, `ref`, or `out` parameter inside an anonymous method, lambda expression, or query expression.*
- **CS1632**: *Control cannot leave the body of an anonymous method or lambda expression.*
- **CS1673**: *Anonymous methods, lambda expressions, and query expressions inside structs cannot access instance members of `this`.*
- **CS1686**: *Local variable or its members cannot have their address taken and be used inside an anonymous method or lambda expression.*
- **CS1764**: *Cannot use fixed local inside an anonymous method, lambda expression, or query expression.*
- **CS8175**: *Cannot use ref local inside an anonymous method, lambda expression, or query expression.*
- **CS8820**: *A static anonymous function cannot contain a reference to 'variable'.*
- **CS8821**: *A static anonymous function cannot contain a reference to 'this' or 'base'.*

All the following constructs are disallowed in lambda expressions:

- `yield` statements (`yield return` or `yield break`)
- Calling a method that has an `in`, `ref`, or `out` parameter
- `ref` local variables
- `fixed` local variables
- `break`, `goto`, and `continue` statements
- `this` access when `this` is a `struct` type
- Anonymous methods or lambda expressions inside another expression, such as an Attribute constructor.
- Lambda expressions, anonymous methods, and method groups as the first operand of `is` or `as`.

In addition, a `static` anonymous function or lambda expression can't capture local variables, parameters, `this`, or `base`:

- **CS8820**: *A static anonymous function cannot contain a reference to 'variable'.*
- **CS8821**: *A static anonymous function cannot contain a reference to 'this' or 'base'.*

You can't use any of these constructs in a lambda expression or an anonymous method. Many are allowed in a [local function](../../programming-guide/classes-and-structs/local-functions.md).

In addition, interpolated string handler types are ignored when applied to a lambda parameter. If you use one, you see the following warning:

- **CS8971**:  *InterpolatedStringHandlerArgument has no effect when applied to lambda parameters and will be ignored at the call site.*

Accessing a virtual member through the `base` keyword inside an anonymous method or lambda expression produces unverifiable code:

- **CS1911**: *Access to member through a 'base' keyword from an anonymous method, lambda expression, query expression, or iterator results in unverifiable code.*

Certain expressions cause the compiler to emit the following informational warning:

- **CS9236**: *Compiling requires binding the lambda expression at least count times. Consider declaring the lambda expression with explicit parameter types, or if the containing method call is generic, consider using explicit type arguments.*

The complexity of the lambda expressions and how they invoke other lambda expressions is negatively impacting compiler performance. The reason is that the compiler must infer parameter and argument types through the lambda expressions and the potential types takes time.

## Lambda expression parameters and returns

These errors indicate a problem with a parameter declaration:

- **CS0748**:  *Inconsistent lambda parameter usage; parameter types must be all explicit or all implicit.*
- **CS1065**:  *Default values are not valid in this context.*
- **CS1643**:  *Not all code paths return a value in anonymous method of type 'type'.*
- **CS1661**:  *Cannot convert anonymous method block to type 'type' because the parameter types do not match the delegate parameter types.*
- **CS1662**:  *Cannot convert anonymous method block to intended delegate type because some of the return types in the block are not implicitly convertible to the delegate return type.*
- **CS1676**:  *Parameter 'number' must be declared with the 'keyword' keyword.*
- **CS1677**:  *Parameter 'number' should not be declared with the 'keyword' keyword.*
- **CS1678**:  *Parameter 'number' is declared as type 'type1' but should be 'type2'.*
- **CS1688**:  *Cannot convert anonymous method block without a parameter list to delegate type 'delegate' because it has one or more out parameters.*
- **CS1731**:  *Cannot convert expression to delegate because some of the return types in the block are not implicitly convertible to the delegate return type.*
- **CS1732**:  *Expected parameter.*
- **CS9098**:  *Implicitly typed lambda parameter '...' cannot have a default value.*
- **CS8030**:  *Anonymous function converted to a void returning delegate cannot return a value.*
- **CS8916**:  *Attributes on lambda expressions require a parenthesized parameter list.*
- **CS8975**:  *The contextual keyword 'var' cannot be used as an explicit lambda return type.*

Lambda expression parameters must follow these rules:

- When a lambda expression has multiple parameters, either all parameters must be explicitly typed or all parameters must be implicitly typed.
- All lambda parameters with a default value must be explicitly typed.
- Default values aren't allowed in anonymous methods declared with the `delegate` operator.
- If attributes are applied to any parameters, the parameter list must be enclosed in parentheses.

Return types of lambda expression must follow these rules:

- A lambda expression that returns any value can't be converted to a `void` returning delegate, such as `Action`.
- The return type is either inferred, or an explicit type. A return type declared using the keyword `var` isn't allowed.

## Lambda expression delegate type

- **CS0407**: *'method' has the wrong return type.*
- **CS0428**: *Cannot convert method group 'Identifier' to non-delegate type 'type'. Did you intend to invoke the method?*
- **CS0467**: Warning: *Ambiguity between method 'method' and non-method 'non-method'. Using method group.*
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
