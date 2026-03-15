---
title: Lambda expression errors and warnings
description: This article helps you diagnose and correct compiler errors and warnings for lambda expression declarations and usage.
ai-usage: ai-assisted
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
ms.date: 03/05/2026
---
# Errors and warnings when using lambda expressions and anonymous functions

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error or warning for SEO purposes.
 -->

Several *errors* relate to declaring and using [lambda expressions](../operators/lambda-expressions.md) and [anonymous methods](../operators/delegate-operator.md):

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
- [**CS8030**](#lambda-expression-parameters-and-returns): *Anonymous function converted to a void returning delegate cannot return a value.*
- [**CS8175**](#syntax-limitations-in-lambda-expressions): *Cannot use ref local inside an anonymous method, lambda expression, or query expression.*
- [**CS8820**](#syntax-limitations-in-lambda-expressions): *A static anonymous function cannot contain a reference to 'variable'.*
- [**CS8821**](#syntax-limitations-in-lambda-expressions): *A static anonymous function cannot contain a reference to 'this' or 'base'.*
- [**CS8916**](#lambda-expression-parameters-and-returns): *Attributes on lambda expressions require a parenthesized parameter list.*
- [**CS8917**](#lambda-expression-delegate-type): *The delegate type could not be inferred.*
- [**CS8934**](#lambda-expression-parameters-and-returns): *Cannot convert anonymous method to type 'type' because the return type does not match the delegate return type.*
- [**CS8975**](#lambda-expression-parameters-and-returns): *The contextual keyword `var` cannot be used as an explicit lambda return type.*
- [**CS9098**](#lambda-expression-parameters-and-returns): *Implicitly typed lambda parameter '...' cannot have a default value.*

In addition, several *warnings* relate to declaring and using lambda expressions:

- [**CS0467**](#lambda-expression-delegate-type): *Ambiguity between method 'method' and non-method 'non-method'. Using method group.*
- [**CS1911**](#syntax-limitations-in-lambda-expressions): *Access to member through a 'base' keyword from an anonymous method, lambda expression, query expression, or iterator results in unverifiable code.*
- [**CS8971**](#syntax-limitations-in-lambda-expressions): *InterpolatedStringHandlerArgument has no effect when applied to lambda parameters and will be ignored at the call site.*
- [**CS8974**](#lambda-expression-delegate-type): *Converting method group 'method' to non-delegate type 'type'. Did you intend to invoke the method?*
- [**CS9099**](#lambda-expression-delegate-type): *The default parameter value does not match in the target delegate type.*
- [**CS9100**](#lambda-expression-delegate-type): *Parameter has params modifier in lambda but not in target delegate type.*

The compiler also produces the following *informational* message:

- [**CS9236**](#syntax-limitations-in-lambda-expressions): *Compiling requires binding the lambda expression at least count times. Consider declaring the lambda expression with explicit parameter types, or if the containing method call is generic, consider using explicit type arguments.*

## Syntax limitations in lambda expressions

- **CS0837**: *The first operand of an `is` or `as` operator may not be a lambda expression, anonymous method, or method group.*
- **CS1621**: *The `yield` statement cannot be used inside an anonymous method or lambda expression.*
- **CS1628**: *Cannot use `in`, `ref`, or `out` parameter inside an anonymous method, lambda expression, or query expression.*
- **CS1632**: *Control cannot leave the body of an anonymous method or lambda expression.*
- **CS1673**: *Anonymous methods, lambda expressions, and query expressions inside structs cannot access instance members of `this`.*
- **CS1686**: *Local variable or its members cannot have their address taken and be used inside an anonymous method or lambda expression.*
- **CS1706**: *Expression cannot contain anonymous methods or lambda expressions.*
- **CS1764**: *Cannot use fixed local inside an anonymous method, lambda expression, or query expression.*
- **CS1911**: Warning: *Access to member through a 'base' keyword from an anonymous method, lambda expression, query expression, or iterator results in unverifiable code.*
- **CS8175**: *Cannot use ref local inside an anonymous method, lambda expression, or query expression.*
- **CS8820**: *A static anonymous function cannot contain a reference to 'variable'.*
- **CS8821**: *A static anonymous function cannot contain a reference to 'this' or 'base'.*
- **CS8971**: Warning: *InterpolatedStringHandlerArgument has no effect when applied to lambda parameters and will be ignored at the call site.*
- **CS9236**: Informational: *Compiling requires binding the lambda expression at least count times. Consider declaring the lambda expression with explicit parameter types, or if the containing method call is generic, consider using explicit type arguments.*

The compiler prohibits certain C# constructs inside [lambda expressions](../operators/lambda-expressions.md) and [anonymous methods](../operators/delegate-operator.md). These restrictions exist because the compiler transforms lambdas and anonymous methods into [delegate](../../programming-guide/delegates/index.md) invocations or [expression trees](../../advanced-topics/expression-trees/index.md), and some constructs can't be represented in those forms. For more information, see the [anonymous function expressions](~/_csharpstandard/standard/expressions.md#1221-anonymous-function-expressions) section of the C# specification.

You can correct these errors by using the following guidance:

- Move any [`yield return` or `yield break`](../statements/yield.md) statement out of the lambda body and into the enclosing [iterator method](../statements/yield.md), or convert the lambda to a [local function](../../programming-guide/classes-and-structs/local-functions.md), which supports `yield` statements (**CS1621**).
- Avoid referencing [`in`, `ref`, or `out`](../keywords/method-parameters.md) parameters from the enclosing method inside the lambda body. When the lambda captures these parameters as part of a [closure](../../programming-guide/classes-and-structs/local-functions.md#local-functions-vs-lambda-expressions), the reference semantics of `ref`-like parameters can't be preserved. Copy the value to a local variable and use that local instead, or convert the lambda to a local function (**CS1628**).
- Remove any `break`, `goto`, or `continue` statement that transfers control out of the lambda body. Control flow statements must target labels or loops within the same lambda body (**CS1632**).
- In a `struct` type, avoid referencing instance members through `this` inside a lambda expression, anonymous method, or query expression. Because the compiler captures `this` by value in a `struct`, mutations inside the lambda don't affect the original instance. Extract the needed member values into local variables before the lambda, or convert to a local function, which can access `this` directly (**CS1673**).
- Don't take the address of a local variable that the lambda also captures. The compiler moves captured variables to a heap-allocated closure object, making their address unstable. Separate the address-taking logic from the lambda, or use a local function instead (**CS1686**).
- Move the lambda expression or anonymous method out of the containing expression that prohibits it. Some expressions, such as attribute constructors, don't support lambda expressions or anonymous methods as arguments (**CS1706**).
- Don't use a `fixed` local variable inside a lambda body. The pinning guarantee of the [`fixed` statement](../statements/fixed.md) applies only to the enclosing scope, not to the closure that the compiler generates (**CS1764**).
- Don't use a [`ref` local](../statements/declarations.md#reference-variables) inside a lambda body. Like `ref` parameters, `ref` locals can't be captured in the closure the compiler generates for the lambda. Assign the value to a non-`ref` local variable, or convert the lambda to a local function (**CS8175**).
- Don't use a lambda expression, anonymous method, or method group as the first operand of the [`is`](../operators/type-testing-and-cast.md#the-is-operator) or [`as`](../operators/type-testing-and-cast.md#the-as-operator) operator. These constructs don't have a type that can be tested at run time. Assign the expression to a variable first, then test the variable (**CS0837**).
- Remove the `static` modifier from the lambda, or remove the reference to the captured variable. A [`static` lambda](../operators/lambda-expressions.md) explicitly prohibits capturing local variables, parameters, or `this` to avoid unintended closure allocations. If you need to reference outer variables, remove the `static` modifier. If you want to keep heap allocation minimal, pass the values as parameters to the lambda (**CS8820**, **CS8821**).
- Remove the <xref:System.Runtime.CompilerServices.InterpolatedStringHandlerArgumentAttribute> from the lambda parameter, or move the logic to a method where the attribute is honored. The compiler ignores this attribute on lambda parameters because lambda invocations don't use the same interpolated string handler lowering as regular method calls (**CS8971**).
- Avoid calling a virtual member through the `base` keyword inside a lambda or anonymous method. The compiler generates a non-virtual call through a helper method, which produces unverifiable code. Consider extracting the `base` call into a separate method and calling that method from the lambda instead (**CS1911**).
- Reduce the complexity of overloaded method calls that accept lambda expressions, or add explicit type information. When the compiler must bind a lambda expression multiple times to resolve overloads, it emits this informational diagnostic. Declaring the lambda with [explicit parameter types](../operators/lambda-expressions.md#input-parameters-of-a-lambda-expression), or providing explicit type arguments on the generic method call, reduces the number of binding passes the compiler must perform (**CS9236**).

## Lambda expression parameters and returns

- **CS0748**: *Inconsistent lambda parameter usage; parameter types must be all explicit or all implicit.*
- **CS1065**: *Default values are not valid in this context.*
- **CS1643**: *Not all code paths return a value in anonymous method of type 'type'.*
- **CS1661**: *Cannot convert anonymous method block to type 'type' because the parameter types do not match the delegate parameter types.*
- **CS1662**: *Cannot convert anonymous method block to intended delegate type because some of the return types in the block are not implicitly convertible to the delegate return type.*
- **CS1676**: *Parameter 'number' must be declared with the 'keyword' keyword.*
- **CS1677**: *Parameter 'number' should not be declared with the 'keyword' keyword.*
- **CS1678**: *Parameter 'number' is declared as type 'type1' but should be 'type2'.*
- **CS1688**: *Cannot convert anonymous method block without a parameter list to delegate type 'delegate' because it has one or more out parameters.*
- **CS1731**: *Cannot convert expression to delegate because some of the return types in the block are not implicitly convertible to the delegate return type.*
- **CS1732**: *Expected parameter.*
- **CS8030**: *Anonymous function converted to a void returning delegate cannot return a value.*
- **CS8916**: *Attributes on lambda expressions require a parenthesized parameter list.*
- **CS8934**: *Cannot convert anonymous method to type 'type' because the return type does not match the delegate return type.*
- **CS8975**: *The contextual keyword 'var' cannot be used as an explicit lambda return type.*
- **CS9098**: *Implicitly typed lambda parameter '...' cannot have a default value.*

These errors indicate a problem with a [lambda expression parameter](../operators/lambda-expressions.md#input-parameters-of-a-lambda-expression) or return type declaration. For the full rules on lambda parameter and return types, see [lambda expressions](../operators/lambda-expressions.md), [anonymous methods](../operators/delegate-operator.md), and the [anonymous function expressions](~/_csharpstandard/standard/expressions.md#1221-anonymous-function-expressions) section of the C# specification.

> [!NOTE]
> **CS1731** and **CS1732** are no longer produced by the current version of the C# compiler (Roslyn). They might appear if you're using an older compiler version.

You can correct these errors by using the following guidance:

- Ensure that all parameters in a lambda expression use the same typing style. When a lambda has multiple parameters, each parameter must be either [explicitly typed](../operators/lambda-expressions.md#input-parameters-of-a-lambda-expression) or implicitly typed—you can't mix the two styles in the same parameter list (**CS0748**).
- Add explicit types to any lambda parameter that has a [default value](../operators/lambda-expressions.md#input-parameters-of-a-lambda-expression). The compiler requires explicit types on parameters with defaults because it must generate a custom delegate type that encodes the default value. Implicitly typed parameters don't provide enough information for the compiler to construct that delegate type (**CS1065**, **CS9098**).
- Remove default parameter values from anonymous methods declared by using the [`delegate` operator](../operators/delegate-operator.md). Default parameter values are supported only in lambda expressions, not in anonymous methods. Convert the anonymous method to a lambda expression if you need default values (**CS1065**).
- Match the parameter types, `ref`/`out`/`in` modifiers, and parameter count of the lambda or anonymous method to the target [delegate type](../../programming-guide/delegates/index.md). The compiler performs an exact match of parameter signatures when converting an anonymous function to a delegate: each parameter must have the correct type, and any `ref`, `out`, or `in` modifier must be present exactly when the delegate expects it (**CS1661**, **CS1676**, **CS1677**, **CS1678**).
- Add a parameter list to the anonymous method when the target delegate type has `out` parameters. An anonymous method declared without a parameter list (by using `delegate { }` syntax) can match most delegate types, but the compiler can't synthesize the required `out` parameters implicitly. Declare the parameters explicitly to match the delegate signature (**CS1688**).
- Ensure that all code paths in the lambda or anonymous method return a value when the target delegate type has a non-void return type. Every branch through the body must produce a return value that's implicitly convertible to the delegate's return type (**CS1643**, **CS1662**, **CS1731**, **CS8934**).
- Remove any `return` statement with a value from a lambda or anonymous method that's assigned to a `void`-returning delegate type such as `Action`. Because the delegate's return type is `void`, the body can't return a value (**CS8030**).
- Enclose the parameter list in parentheses when [attributes](../operators/lambda-expressions.md#attributes) are applied to any lambda parameter. The compiler needs the parenthesized form to distinguish attribute syntax from other expressions. For example, write `([MyAttribute] int x) => x` instead of `[MyAttribute] x => x` (**CS8916**).
- Use a specific type name instead of `var` as the explicit return type of a lambda expression. The keyword `var` is reserved for [implicitly typed local variables](../statements/declarations.md#implicitly-typed-local-variables) and can't be used as a lambda return type annotation. Specify the actual return type, or omit the return type and let the compiler infer it (**CS8975**).
- Fix the parameter list so the compiler can recognize it as a valid parameter declaration. This error indicates a malformed parameter list where the compiler expected a parameter identifier but found something else (**CS1732**).

## Lambda expression delegate type

- **CS0407**: *'method' has the wrong return type.*
- **CS0428**: *Cannot convert method group 'Identifier' to non-delegate type 'type'. Did you intend to invoke the method?*
- **CS0467**: Warning: *Ambiguity between method 'method' and non-method 'non-method'. Using method group.*
- **CS0815**: *Cannot assign 'expression' to an implicitly-typed variable.*
- **CS0828**: *Cannot assign 'expression' to anonymous type property.*
- **CS1660**: *Cannot convert lambda expression to type 'type' because it is not a delegate type.*
- **CS8917**: *The delegate type could not be inferred.*
- **CS8974**: Warning: *Converting method group 'method' to non-delegate type 'type'. Did you intend to invoke the method?*
- **CS9099**: Warning: *The default parameter value does not match in the target delegate type.*
- **CS9100**: Warning: *Parameter has params modifier in lambda but not in target delegate type.*

These errors indicate a problem with the [delegate type](../../programming-guide/delegates/index.md) that the compiler infers or expects for a [lambda expression](../operators/lambda-expressions.md), [anonymous method](../operators/delegate-operator.md), or [method group](~/_csharpstandard/standard/conversions.md#108-method-group-conversions). For the full rules on delegate conversions, see [lambda expressions](../operators/lambda-expressions.md), [anonymous methods](../operators/delegate-operator.md), and the [anonymous function expressions](~/_csharpstandard/standard/expressions.md#1221-anonymous-function-expressions) section of the C# specification.

> [!NOTE]
> The current version of the C# compiler (Roslyn) doesn't produce **CS0467**. You might see this error if you're using an older compiler version.

You can correct these errors by using the following guidance:

- Ensure that the target type of the assignment or conversion is a [delegate type](../../programming-guide/delegates/index.md) or <xref:System.Linq.Expressions.Expression?displayProperty=nameWithType>. A lambda expression or anonymous method can't be assigned to a non-delegate type such as `object` or an interface. Change the variable's type to a compatible delegate type like `Func<>` or `Action<>`, or use `var` to let the compiler infer the delegate type (**CS1660**).
- Provide enough context for the compiler to determine a single delegate type for the lambda expression. When assigned to `var`, the compiler needs an unambiguous return type and parameter list. When assigned to an anonymous type property, the compiler can't infer a delegate type at all. Assign the lambda to a variable with an explicit delegate type, then use that variable in the anonymous type initializer (**CS0815**, **CS0828**, **CS8917**).
- Match the return type of the method group to the delegate's declared return type. A [method group conversion](~/_csharpstandard/standard/conversions.md#108-method-group-conversions) requires the method's return type to be identity-convertible or implicitly convertible to the delegate's return type. Change the method's return type, or change the delegate type to match (**CS0407**).
- Invoke the method instead of assigning the method group when the target type isn't a delegate. If the target type is `string`, `int`, or another non-delegate type, you likely intended to call the method and assign its result. Add parentheses and arguments to invoke the method (**CS0428**, **CS8974**).
- Resolve ambiguity between a method and a non-method member that share the same name. Rename one of the conflicting members, or use a fully qualified reference to remove the ambiguity (**CS0467**).
- Remove the [default parameter value](../operators/lambda-expressions.md#input-parameters-of-a-lambda-expression) or [`params` modifier](../operators/lambda-expressions.md#input-parameters-of-a-lambda-expression) from the lambda when the target delegate type is a standard `Func<>` or `Action<>` type. Default values and `params` modifiers cause the compiler to generate a custom delegate type that doesn't match `Func<>` or `Action<>`. Either use `var` to let the compiler synthesize the correct delegate type, or remove the default value or `params` modifier so the lambda matches the declared delegate type (**CS9099**, **CS9100**).
