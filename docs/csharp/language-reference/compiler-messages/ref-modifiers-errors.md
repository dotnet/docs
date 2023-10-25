---
title: Errors and warnings associated with reference parameter modifiers
description: The compiler issues these errors and warnings when you use the reference parameter modifiers incorrectly. They indicate a mismatch between the modifier on the parameter, the argument, or the use of the parameter in the method.
f1_keywords:
  - "CS9190"
  - "CS0192"
  - "CS0199"
  - "CS0206"
  - "CS0631"
  - "CS0767"
  - "CS1510"
  - "CS1605"
  - "CS1623"
  - "CS1649"
  - "CS1651"
  - "CS1655"
  - "CS1657"
  - "CS1741"
  - "CS1939"
  - "CS1988"
  - "CS7084"
  - "CS8166"
  - "CS8167"
  - "CS8168"
  - "CS8169"
  - "CS8325"
  - "CS8326"
  - "CS8327"
  - "CS8329"
  - "CS8330"
  - "CS8331"
  - "CS8332"
  - "CS8337"
  - "CS8338"
  - "CS8345"
  - "CS8351"
  - "CS8373"
  - "CS8374"
  - "CS8388"
  - "CS8977"
  - "CS9072"
  - "CS9077"
  - "CS9078"
  - "CS9079"
  - "CS9096"
  - "CS9109"
  - "CS9110"
  - "CS9116"
  - "CS9119"
  - "CS9130"
  - "CS9190"
  - "CS9199"
  - "CS9085"
  - "CS9086"
  - "CS9087"
  - "CS9089"
  - "CS9091"
  - "CS9092"
  - "CS9093"
  - "CS9094"
  - "CS9095"
  - "CS9097"
  - "CS9184"
  - "CS9191"
  - "CS9192"
  - "CS9193"
  - "CS9195"
  - "CS9196"
  - "CS9197"
  - "CS9198"
  - "CS9200"
  - "CS9201"
helpviewer_keywords:
  - "CS9190"
  - "CS0192"
  - "CS0199"
  - "CS0206"
  - "CS0631"
  - "CS0767"
  - "CS1510"
  - "CS1605"
  - "CS1623"
  - "CS1649"
  - "CS1651"
  - "CS1655"
  - "CS1657"
  - "CS1741"
  - "CS1939"
  - "CS1988"
  - "CS7084"
  - "CS8166"
  - "CS8167"
  - "CS8168"
  - "CS8169"
  - "CS8325"
  - "CS8326"
  - "CS8327"
  - "CS8329"
  - "CS8330"
  - "CS8331"
  - "CS8332"
  - "CS8337"
  - "CS8338"
  - "CS8345"
  - "CS8351"
  - "CS8373"
  - "CS8374"
  - "CS8388"
  - "CS8977"
  - "CS9072"
  - "CS9077"
  - "CS9078"
  - "CS9079"
  - "CS9096"
  - "CS9109"
  - "CS9110"
  - "CS9116"
  - "CS9119"
  - "CS9130"
  - "CS9190"
  - "CS9199"
  - "CS9085"
  - "CS9086"
  - "CS9087"
  - "CS9089"
  - "CS9091"
  - "CS9092"
  - "CS9093"
  - "CS9094"
  - "CS9095"
  - "CS9097"
  - "CS9184"
  - "CS9191"
  - "CS9192"
  - "CS9193"
  - "CS9195"
  - "CS9196"
  - "CS9197"
  - "CS9198"
  - "CS9200"
  - "CS9201"
ms.date: 10/24/2023
---
# Errors and warnings associated with reference parameters, variables, and returns

The following errors can be generated when you're working with reference variables:

<!-- The text in the bullet lists generate issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0192**](#writable-reference-variables-require-a-writable-referent) - *A `readonly` field cannot be used as a `ref` or `out` value (except in a constructor)*
- [**CS0199**](#writable-reference-variables-require-a-writable-referent) - *A `static readonly` field cannot be used as a `ref` or `out` value (except in a static constructor)*
- [**CS0206**](#reference-variables-require-a-referent) - *A non ref-returning property or indexer may not be used as an `out` or `ref` value*
- [**CS0631**](#reference-variable-restrictions) - *`ref` and `out` are not valid in this context*
- [**CS0767**](#reference-variable-restrictions) - *Cannot inherit interface with the specified type parameters because it causes method to contain overloads which differ only on `ref` and `out`*
- [**CS1510**](#reference-variables-require-a-referent) - *A `ref` or `out` value must be an assignable variable*
- [**CS1605**](#writable-reference-variables-require-a-writable-referent) - *Cannot use variable as a `ref` or `out` value because it is read-only*
- [**CS1623**](#reference-variable-restrictions) - *Iterators cannot have `ref`, `in` or `out` parameters*
- [**CS1649**](#writable-reference-variables-require-a-writable-referent) - *Members of a `readonly` field cannot be used as a `ref` or `out` value (except in a constructor)*
- [**CS1651**](#writable-reference-variables-require-a-writable-referent) - *Fields of a static readonly field cannot be used as a `ref` or `out` value (except in a static constructor)*
- [**CS1655**](#writable-reference-variables-require-a-writable-referent) - *Cannot use fields of type as a `ref` or `out` value*
- [**CS1657**](#writable-reference-variables-require-a-writable-referent) - *Cannot use variable as a `ref` or `out` value*
- [**CS1741**](#reference-variable-restrictions) - *A `ref` or `out` parameter cannot have a default value*
- [**CS1939**](#reference-variable-restrictions) - *Cannot pass the range variable as an `out` or `ref` parameter*
- [**CS1988**](#reference-variable-restrictions) - *Async methods cannot have `ref`, `in` or `out` parameters*
- [**CS7084**](#reference-variable-restrictions) - *A Windows Runtime event may not be passed as an `out` or `ref` parameter.*
- [**CS8166**](#ref-safety-violations) - *Cannot return a parameter by reference because it is not a `ref` parameter*
- [**CS8167**](#ref-safety-violations) - *Cannot return by reference a member of parameter because it is not a `ref` or `out` parameter*
- [**CS8168**](#ref-safety-violations) - *Cannot return local by reference because it is not a ref local*
- [**CS8169**](#ref-safety-violations) - *Cannot return a member of local variable by reference because it is not a ref local*
- [**CS8325**](#reference-variable-restrictions) - *'`await`' cannot be used in an expression containing a `ref` conditional operator*
- [**CS8326**](#reference-variable-restrictions) - *Both conditional operator values must be ref values or neither may be a ref value*
- [**CS8327**](#reference-variable-restrictions) - *The expression must be of correct type to match the alternative ref value*
- [**CS8329**](#writable-reference-variables-require-a-writable-referent) - *Cannot use variable as a `ref` or `out` value because it is a readonly variable*
- [**CS8330**](#writable-reference-variables-require-a-writable-referent) - *Members of variable cannot be used as a `ref` or `out` value because it is a readonly variable*
- [**CS8331**](#writable-reference-variables-require-a-writable-referent) - *Cannot assign to variable or use it as the right hand side of a `ref` assignment because it is a readonly variable*
- [**CS8332**](#writable-reference-variables-require-a-writable-referent) - *Cannot assign to a member of variable or use it as the right hand side of a `ref` assignment because it is a readonly variable*
- [**CS8337**](#reference-variable-restrictions) - *The first parameter of a '`ref`' extension method must be a value type or a generic type constrained to struct.*
- [**CS8338**](#reference-variable-restrictions) - *The first '`in`' or '`ref readonly`' parameter of the extension method must be a concrete (non-generic) value type.*
- [**CS8345**](#ref-safety-violations) - *Field or auto-implemented property cannot be of type unless it is an instance member of a `ref struct`.*
- [**CS8351**](#ref-safety-violations) - *Branches of a `ref` conditional operator cannot refer to variables with incompatible declaration scopes*
- [**CS8373**](#incorrect-syntax) - *The left-hand side of a `ref` assignment must be a ref variable.*
- [**CS8374**](#ref-safety-violations) - *Cannot ref-assign source has a narrower escape scope than destination.*
- [**CS8388**](#incorrect-syntax) - *An `out` variable cannot be declared as a ref local*
- [**CS8977**](#reference-variable-restrictions) - *Cannot use '`ref`', '`in`', or '`out`' in the signature of a method attributed with 'UnmanagedCallersOnly'.*
- [**CS9072**](#reference-variable-restrictions) - *A deconstruction variable cannot be declared as a ref local*
- [**CS9077**](#ref-safety-violations) - *Cannot return a parameter by reference through a `ref` parameter; it can only be returned in a return statement*
- [**CS9078**](#ref-safety-violations) - *Cannot return by reference a member of parameter through a `ref` parameter; it can only be returned in a return statement*
- [**CS9079**](#ref-safety-violations) - *Cannot ref-assign because source can only escape the current method through a return statement.*
- [**CS9096**](#ref-safety-violations) - *Cannot ref-assign because source has a wider value escape scope than destination allowing assignment through source of values with narrower escapes scopes than destination.*
- [**CS9109**](#ref-safety-violations) - *Cannot use `ref`, `out`, or `in` primary constructor parameter inside an instance member*
- [**CS9110**](#ref-safety-violations) - *Cannot use primary constructor parameter that has ref-like type inside an instance member*
- [**CS9116**](#writable-reference-variables-require-a-writable-referent) - *A primary constructor parameter of a readonly type cannot be used as a `ref` or `out` value (except in init-only setter of the type or a variable initializer)*
- [**CS9119**](#writable-reference-variables-require-a-writable-referent) - *Members of primary constructor parameter of a readonly type cannot be used as a `ref` or `out` value (except in init-only setter of the type or a variable initializer)*
- [**CS9130**](#incorrect-syntax) - *Using alias cannot be a '`ref`' type.*
- [**CS9190**](#incorrect-syntax) - *`readonly` modifier must be specified after `ref`.*
- [**CS9199**](#reference-variable-restrictions) - *A `ref readonly` parameter cannot have the Out attribute.*

The following warnings are generated when reference variables are used incorrectly:

- [**CS9085**](#ref-safety-violations) - *This ref-assigns variable but destination has a narrower escape scope than source.*
- [**CS9086**](#ref-safety-violations) - *The branches of the `ref` conditional operator refer to variables with incompatible declaration scopes*
- [**CS9087**](#ref-safety-violations) - *This returns a parameter by reference but it is not a `ref` parameter*
- [**CS9089**](#ref-safety-violations) - *This returns by reference a member of parameter that is not a `ref` or `out` parameter*
- [**CS9091**](#ref-safety-violations) - *This returns local by reference but it is not a ref local*
- [**CS9092**](#ref-safety-violations) - *This returns a member of local by reference but it is not a ref local*
- [**CS9093**](#ref-safety-violations) - *This ref-assigns but source can only escape the current method through a return statement.*
- [**CS9094**](#ref-safety-violations) - *This returns a parameter by reference through a `ref` parameter; but it can only safely be returned in a return statement*
- [**CS9095**](#ref-safety-violations) - *This returns by reference a member of parameter through a `ref` parameter; but it can only safely be returned in a return statement*
- [**CS9097**](#ref-safety-violations) - *This ref-assigns  but source has a wider value escape scope than destination allowing assignment through destination of values with narrower escapes scopes than source.*
- [**CS9184**](#reference-variable-restrictions) - *'Inline arrays' language feature is not supported for inline array types with element field which is either a '`ref`' field, or has type that is not valid as a type argument.*
- [**CS9191**](#reference-variables-require-a-referent) - *The `ref` modifier for argument corresponding to `in` parameter is equivalent to `in`. Consider using `in` instead.*
- [**CS9192**](#reference-variables-require-a-referent) - *Argument should be passed with `ref` or `in` keyword.*
- [**CS9193**](#reference-variables-require-a-referent) - *Argument should be a variable because it is passed to a `ref readonly` parameter*
- [**CS9195**](#reference-variables-require-a-referent) - *Argument should be passed with the `in` keyword*
- [**CS9196**](#reference-variable-restrictions) - *Reference kind modifier of parameter doesn't match the corresponding parameter in overridden or implemented member.*
- [**CS9197**](#reference-variable-restrictions) - *Reference kind modifier of parameter doesn't match the corresponding parameter in hidden member.*
- [**CS9198**](#reference-variable-restrictions) - *Reference kind modifier of parameter doesn't match the corresponding parameter in target.*
- [**CS9200**](#reference-variable-restrictions) - *A default value is specified for `ref readonly` parameter, but `ref readonly` should be used only for references. Consider declaring the parameter as `in`.*
- [**CS9201**](#reference-variable-restrictions) - *Ref field should be ref-assigned before use.*

These errors and warnings follow these themes:

- ***[Incorrect syntax](#incorrect-syntax)*** - The syntax of your declaration or usage is invalid.
- ***[Language constructs where `ref` variables aren't valid](#reference-variable-restrictions)*** - Some C# idioms don't allow variables. Usually this is because ref safety analysis can't be performed reliably.
- ***[Value expression used where a reference variable is needed](#reference-variables-require-a-referent)*** - The expression used as a reference variable must be a variable, not a value expression.
- ***[Writable reference variables referring to readonly variables](#writable-reference-variables-require-a-writable-referent)*** - A reference to a readonly variable can't be passed by writable reference.
- ***[violations of ref safety](#ref-safety-violations)*** - A reference variable can't refer to a variable that has a narrower context. That would mean the reference variable could refer to invalid memory.

This article uses the term *reference variable* as a general term for a parameter declared with one of the `in`, `ref readonly`, `ref`, or `out` modifiers, or a `ref` local variable, a `ref` field in a `ref struct`, or a `ref` return. A reference variable refers to another variable, called the *referent*.

## Incorrect syntax

These errors indicate that you're using incorrect syntax regarding reference variables:

- **CS8373** - *The left-hand side of a `ref` assignment must be a ref variable.*
- **CS8388** - *An `out` variable cannot be declared as a ref local.*
- **CS9130** - *Using alias cannot be a '`ref`' type.*
- **CS9190** - *`readonly` modifier must be specified after `ref`.*

You can correct the error with one of these changes:

- The left operand of an `= ref` operator must be a reference variable. For more information on the correct syntax, see [reference variables](../statements/declarations.md#reference-variables).
- The parameter modifier `ref readonly` must be in that order. `readonly ref` is not a legal parameter modifier. Switch the order of the words.
- A local variable can't be declared as `out`. To declare a local reference variable, use `ref`.
- A `using` alias can't be a `ref` type. You must remove that alias.

## Reference variable restrictions

The following errors indicate that a reference variable can't be used where you have one:

- **CS0631** - *`ref` and `out` are not valid in this context*
- **CS0767** - *Cannot inherit interface with the specified type parameters because it causes method to contain overloads which differ only on `ref` and `out`*
- **CS1623** - *Iterators cannot have `ref`, `in` or `out` parameters*
- **CS1741** - *A `ref` or `out` parameter cannot have a default value*
- **CS1939** - *Cannot pass the range variable as an `out` or `ref` parameter*
- **CS1988** - *Async methods cannot have `ref`, `in` or `out` parameters*
- **CS7084** - *A Windows Runtime event may not be passed as an `out` or `ref` parameter.*
- **CS8325** - *'await' cannot be used in an expression containing a `ref` conditional operator*
- **CS8326** - *Both conditional operator values must be ref values or neither may be a ref value*
- **CS8327** - *The expression must be of correct type to match the alternative ref value*
- **CS8337** - *The first parameter of a '`ref`' extension method must be a value type or a generic type constrained to struct.*
- **CS8338** - *The first '`in`' or '`ref readonly`' parameter of the extension method must be a concrete (non-generic) value type.*
- **CS8977** - *Cannot use '`ref`', '`in`', or '`out`' in the signature of a method attributed with 'UnmanagedCallersOnly'.*
- **CS9072** - *A deconstruction variable cannot be declared as a ref local*
- **CS9199** - *A `ref readonly` parameter cannot have the Out attribute.*

The following warnings indicate that a reference variable shouldn't be used, and might be unsafe:

- **CS9184** - *'Inline arrays' language feature is not supported for inline array types with element field which is either a '`ref`' field, or has type that is not valid as a type argument.*
- **CS9196** - *Reference kind modifier of parameter doesn't match the corresponding parameter in overridden or implemented member.*
- **CS9197** - *Reference kind modifier of parameter doesn't match the corresponding parameter in hidden member.*
- **CS9198** - *Reference kind modifier of parameter doesn't match the corresponding parameter in target.*
- **CS9200** - *A default value is specified for `ref readonly` parameter, but `ref readonly` should be used only for references. Consider declaring the parameter as `in`.*
- **CS9201** - *Ref field should be ref-assigned before use.*

To fix the error, remove the reference variable where it isn't allowed:

- Remove `in`, `ref`, and `out` parameters from [indexers](../../programming-guide/indexers/index.md), [iterators](../../iterators.md), and [async methods](../../asynchronous-programming/index.md).
- Remove [ref conditional expressions](../operators/conditional-operator.md#conditional-ref-expression) (`? :`) that include an [await](../operators/await.md).
- Remove the `ref` modifier from the first parameter of a [extension method](../../programming-guide/classes-and-structs/extension-methods.md) where that type isn't a value type or a generic type constrained as a value type.
- Either both or neither [conditional operator expressions] must be `ref` variables. Either remove `ref` from one expression, or add it to the other. If it's a `ref` conditional expression, both expressions must be the same type.
- `ref` and `out` parameters can't have [default values](../../programming-guide/classes-and-structs/named-and-optional-arguments.md). Either remove the `ref` or `out` modifier, or remove the default value.
- The range variable in a [LINQ query expression](../../linq/query-expression-basics.md) can't be passed by reference.
- You can't deconstruct an object into reference variables. Replace the reference variables with value variables.
- You can't implement multiple interfaces where method overloads differ only on `ref` and `out`. For example, one interface declares `void M(ref int i)` and another interface declares `void M(out int i)`. A class can't implement both interfaces because the methods aren't distinguishable. You can only implement one of those interfaces.
- Methods attributed with <xref:System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute?displayProperty=nameWithType> can't use reference parameters.
- A Windows runtime event can't be passed as a reference variable.
- A `ref readonly` parameter can't have the <xref:System.Runtime.InteropServices.OutAttribute?displayProperty=nameWithType> applied to it in remoting API.

## Reference variables require a referent

You must supply a variable as an argument to a reference parameter, reference return, or ref local assignment:

- **CS0206** - *A non ref-returning property or indexer may not be used as an `out` or `ref` value*
- **CS1510** - *A `ref` or `out` value must be an assignable variable*

Warnings:

- **CS9191** - *The `ref` modifier for argument corresponding to `in` parameter is equivalent to `in`. Consider using `in` instead.*
- **CS9192** - *Argument should be passed with `ref` or `in` keyword.*
- **CS9193** - *Argument should be a variable because it is passed to a `ref readonly` parameter*
- **CS9195** - *Argument should be passed with the `in` keyword*

When the compiler emits one of these errors, you've used an expression that calculates a value where a variable must be used. You must store the result of that expression in a variable to use it. For example, properties and indexers return values, not variables. You must store the result in a variable and pass a reference to that variable.

## Writable reference variables require a writable referent

A writable reference variable requires that the referent also be writable. The following errors indicate that the variable isn't writable:

- **CS0192** - *A `readonly` field cannot be used as a `ref` or `out` value (except in a constructor)*
- **CS0199** - *A `static readonly` field cannot be used as a `ref` or `out` value (except in a static constructor)*
- **CS1605** - *Cannot use variable as a `ref` or `out` value because it is read-only*
- **CS1649** - *Members of a `readonly` field cannot be used as a `ref` or `out` value (except in a constructor)*
- **CS1651** - *Fields of a `static readonly` field cannot be used as a `ref` or `out` value (except in a static constructor)*
- **CS1655** - *Cannot use fields of type as a `ref` or `out` value*
- **CS1657** - *Cannot use variable as a `ref` or `out` value*
- **CS8329** - *Cannot use variable as a `ref` or `out` value because it is a readonly variable*
- **CS8330** - *Members of variable cannot be used as a `ref` or `out` value because it is a readonly variable*
- **CS8331** - *Cannot assign to variable or use it as the right hand side of a `ref` assignment because it is a readonly variable*
- **CS8332** - *Cannot assign to a member of variable or use it as the right hand side of a `ref` assignment because it is a readonly variable*
- **CS9116** - *A primary constructor parameter of a `readonly` type cannot be used as a `ref` or `out` value (except in init-only setter of the type or a variable initializer)*
- **CS9119** - *Members of primary constructor parameter of a readonly type cannot be used as a `ref` or `out` value (except in init-only setter of the type or a variable initializer)*

Examples of variables that aren't writable include:

- [readonly](../../language-reference/keywords/readonly.md) fields, both instance and static fields.
- Members of `readonly` fields.
- The `this` variable.
- The [foreach](../../language-reference/statements/iteration-statements.md#the-foreach-statement) iteration variable
- A [using](../../language-reference/statements/using.md) variable, or a [fixed](../../language-reference/statements/fixed.md) variable.

You must copy the value and pass a reference to the copy.

## Ref safety violations

The compiler tracks the safe context of referents and reference variables. The compiler issues errors, or warnings in unsafe code, when a reference variable refers to a referent variable that's no longer valid. The reference variable can't refer to a variable that has been reclaimed while the reference variable is still valid.

- **CS8166** - *Cannot return a parameter by reference because it is not a `ref` parameter*
- **CS8167** - *Cannot return by reference a member of parameter because it is not a `ref` or `out` parameter*
- **CS8168** - *Cannot return local by reference because it is not a ref local*
- **CS8169** - *Cannot return a member of local variable by reference because it is not a ref local*
- **CS8345** - *Field or auto-implemented property cannot be of type unless it is an instance member of a `ref struct`.*
- **CS8351** - *Branches of a `ref` conditional operator cannot refer to variables with incompatible declaration scopes*
- **CS8374** - *Cannot ref-assign source has a narrower escape scope than destination.*
- **CS9077** - *Cannot return a parameter by reference through a `ref` parameter; it can only be returned in a return statement*
- **CS9078** - *Cannot return by reference a member of parameter through a `ref` parameter; it can only be returned in a return statement*
- **CS9079** - *Cannot ref-assign source to destination because source can only escape the current method through a return statement.*
- **CS9096** - *Cannot ref-assign source to destination because source has a wider value escape scope than destination allowing assignment through destination of values with narrower escapes scopes than source.*
- **CS9109** - *Cannot use `ref`, `out`, or `in` primary constructor parameter inside an instance member*
- **CS9110** - *Cannot use primary constructor parameter that has ref-like type inside an instance member*

Warnings:

- **CS9085** - *This ref-assigns source to destination but source has a narrower escape scope than destination.*
- **CS9086** - *The branches of the ref conditional operator refer to variables with incompatible declaration scopes*
- **CS9087** - *This returns a parameter by reference but it is not a `ref` parameter*
- **CS9089** - *This returns by reference a member of parameter that is not a `ref` or `out` parameter*
- **CS9091** - *This returns local by reference but it is not a ref local*
- **CS9092** - *This returns a member of local by reference but it is not a ref local*
- **CS9093** - *This ref-assigns source to destination but source can only escape the current method through a return statement.*
- **CS9094** - *This returns a parameter by reference through a `ref` parameter; but it can only safely be returned in a return statement*
- **CS9095** - *This returns by reference a member of parameter through a `ref` parameter; but it can only safely be returned in a return statement*
- **CS9097** - *This ref-assigns source to destination but source has a wider value escape scope than destination allowing assignment through destination of values with narrower escapes scopes than source.*

The compiler uses static analysis to determine if the referent is valid at all points where the reference variable can be used. You need to refactor code so that the referent remains valid at all locations where the reference variable might refer to it. For details on the rules for ref safety, see the C# standard on [ref safe contexts](~/_csharpstandard/standard/variables.md#972-ref-safe-contexts).
