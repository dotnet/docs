---
title: Errors and warnings associated with reference parameter modifiers
description: The compiler issues these errors and warnings when you use the reference parameter modifiers incorrectly. They indicate a mismatch between the modifier on the parameter, the argument, or the use of the parameter in the method.
f1_keywords:
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
  - "CS8196"
  - "CS8325"
  - "CS8326"
  - "CS8327"
  - "CS8329"
  - "CS8330"
  - "CS8331"
  - "CS8332"
  - "CS8337"
  - "CS8338"
  - "CS8373"
  - "CS8388"
  - "CS8987"
  - "CS9061"
  - "CS9062"
  - "CS9063"
  - "CS9065"
  - "CS9066"
  - "CS9072"
  - "CS9073"
  - "CS9074"
  - "CS9101"
  - "CS9102"
  - "CS9104"
  - "CS9104"
  - "CS9104"
  - "CS9104"
  - "CS9104"
  - "CS9104"
  - "CS9104"
  - "CS9190"
  - "CS9191"
  - "CS9192"
  - "CS9193"
  - "CS9195"
  - "CS9196"
  - "CS9197"
  - "CS9198"
  - "CS9199"
  - "CS9200"
  - "CS9201"
  - "CS9205"
  - "CS9265"
helpviewer_keywords:
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
  - "CS8196"
  - "CS8325"
  - "CS8326"
  - "CS8327"
  - "CS8329"
  - "CS8330"
  - "CS8331"
  - "CS8332"
  - "CS8337"
  - "CS8338"
  - "CS8373"
  - "CS8388"
  - "CS8977"
  - "CS9073"
  - "CS9074"
  - "CS9101"
  - "CS9102"
  - "CS9104"
  - "CS9190"
  - "CS9191"
  - "CS9192"
  - "CS9193"
  - "CS9195"
  - "CS9196"
  - "CS9197"
  - "CS9198"
  - "CS9199"
  - "CS9200"
  - "CS9201"
  - "CS9205"
  - "CS9265"
ai-usage: ai-assisted
ms.date: 11/21/2025
---
# Errors and warnings associated with reference parameters, variables, and returns

The following errors can be generated when you're working with reference variables:

<!-- The text in the bullet lists generate issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0192**](#writable-reference-variables-require-a-writable-referent): *A `readonly` field cannot be used as a `ref` or `out` value (except in a constructor)*
- [**CS0199**](#writable-reference-variables-require-a-writable-referent): *A `static readonly` field cannot be used as a `ref` or `out` value (except in a static constructor)*
- [**CS0206**](#reference-variables-require-a-referent): *A non ref-returning property or indexer may not be used as an `out` or `ref` value*
- [**CS0631**](#reference-variable-restrictions): *`ref` and `out` are not valid in this context*
- [**CS0767**](#reference-variable-restrictions): *Cannot inherit interface with the specified type parameters because it causes method to contain overloads which differ only on `ref` and `out`*
- [**CS1510**](#reference-variables-require-a-referent): *A `ref` or `out` value must be an assignable variable*
- [**CS1605**](#writable-reference-variables-require-a-writable-referent): *Cannot use variable as a `ref` or `out` value because it is read-only*
- [**CS1623**](#reference-variable-restrictions): *Iterators cannot have `ref`, `in` or `out` parameters*
- [**CS1649**](#writable-reference-variables-require-a-writable-referent): *Members of a `readonly` field cannot be used as a `ref` or `out` value (except in a constructor)*
- [**CS1651**](#writable-reference-variables-require-a-writable-referent): *Fields of a static readonly field cannot be used as a `ref` or `out` value (except in a static constructor)*
- [**CS1655**](#writable-reference-variables-require-a-writable-referent): *Cannot use fields of type as a `ref` or `out` value*
- [**CS1657**](#writable-reference-variables-require-a-writable-referent): *Cannot use variable as a `ref` or `out` value*
- [**CS1741**](#reference-variable-restrictions): *A `ref` or `out` parameter cannot have a default value*
- [**CS1939**](#reference-variable-restrictions): *Cannot pass the range variable as an `out` or `ref` parameter*
- [**CS1988**](#reference-variable-restrictions): *Async methods cannot have `ref`, `in` or `out` parameters*
- [**CS7084**](#reference-variable-restrictions): *A Windows Runtime event may not be passed as an `out` or `ref` parameter.*
- [**CS8196**](#reference-variable-restrictions): *Reference to an implicitly-typed out variable is not permitted in the same argument list.*
- [**CS8325**](#reference-variable-restrictions): *'`await`' cannot be used in an expression containing a `ref` conditional operator*
- [**CS8326**](#reference-variable-restrictions): *Both conditional operator values must be ref values or neither may be a ref value*
- [**CS8327**](#reference-variable-restrictions): *The expression must be of correct type to match the alternative ref value*
- [**CS8329**](#writable-reference-variables-require-a-writable-referent): *Cannot use variable as a `ref` or `out` value because it is a readonly variable*
- [**CS8330**](#writable-reference-variables-require-a-writable-referent): *Members of variable cannot be used as a `ref` or `out` value because it is a readonly variable*
- [**CS8331**](#writable-reference-variables-require-a-writable-referent): *Cannot assign to variable or use it as the right hand side of a `ref` assignment because it is a readonly variable*
- [**CS8332**](#writable-reference-variables-require-a-writable-referent): *Cannot assign to a member of variable or use it as the right hand side of a `ref` assignment because it is a readonly variable*
- [**CS8337**](#reference-variable-restrictions): *The first parameter of a '`ref`' extension method must be a value type or a generic type constrained to struct.*
- [**CS8338**](#reference-variable-restrictions): *The first '`in`' or '`ref readonly`' parameter of the extension method must be a concrete (non-generic) value type.*
- [**CS8373**](#incorrect-syntax): *The left-hand side of a `ref` assignment must be a ref variable.*
- [**CS8388**](#incorrect-syntax): *An `out` variable cannot be declared as a ref local*
- [**CS8977**](#reference-variable-restrictions): *Cannot use '`ref`', '`in`', or '`out`' in the signature of a method attributed with 'UnmanagedCallersOnly'.*
- [**CS8986**](#reference-variable-restrictions): *The 'scoped' modifier of parameter doesn't match target.*
- [**CS8987**](#reference-variable-restrictions): *The 'scoped' modifier of parameter doesn't match overridden or implemented member.*
- [**CS9061**](#incorrect-syntax): *The 'scoped' modifier cannot be used with discard.*
- [**CS9062**](#incorrect-syntax): *Types and aliases cannot be named 'scoped'.*
- [**CS9063**](#unscoped-ref-restrictions): *UnscopedRefAttribute cannot be applied to this parameter because it is unscoped by default.*
- [**CS9065**](#incorrect-syntax): *Do not use 'System.Runtime.CompilerServices.ScopedRefAttribute'. Use the 'scoped' keyword instead.*
- [**CS9066**](#unscoped-ref-restrictions): *UnscopedRefAttribute cannot be applied to parameters that have a 'scoped' modifier.*
- [**CS9072**](#reference-variable-restrictions): *A deconstruction variable cannot be declared as a ref local*
- [**CS9101**](#unscoped-ref-restrictions): *UnscopedRefAttribute can only be applied to struct or virtual interface instance methods and properties, and cannot be applied to constructors or init-only members.*
- [**CS9102**](#unscoped-ref-restrictions): *UnscopedRefAttribute cannot be applied to an interface implementation  because implemented member doesn't have this attribute.*
- [**CS9104**](#reference-variable-restrictions): *A `using` statement resource of type cannot be used in async methods or async lambda expressions.*
- [**CS9190**](#incorrect-syntax): *`readonly` modifier must be specified after `ref`.*
- [**CS9199**](#reference-variable-restrictions): *A `ref readonly` parameter cannot have the Out attribute.*

The following warnings are generated when reference variables are used incorrectly:

- [**CS9073**](#reference-variable-restrictions): *The 'scoped' modifier of parameter doesn't match target.*
- [**CS9074**](#reference-variable-restrictions): *The 'scoped' modifier of parameter doesn't match overridden or implemented member.*
- [**CS9191**](#reference-variables-require-a-referent): *The `ref` modifier for argument corresponding to `in` parameter is equivalent to `in`. Consider using `in` instead.*
- [**CS9192**](#reference-variables-require-a-referent): *Argument should be passed with `ref` or `in` keyword.*
- [**CS9193**](#reference-variables-require-a-referent): *Argument should be a variable because it is passed to a `ref readonly` parameter*
- [**CS9195**](#reference-variables-require-a-referent): *Argument should be passed with the `in` keyword*
- [**CS9196**](#reference-variable-restrictions): *Reference kind modifier of parameter doesn't match the corresponding parameter in overridden or implemented member.*
- [**CS9197**](#reference-variable-restrictions): *Reference kind modifier of parameter doesn't match the corresponding parameter in hidden member.*
- [**CS9198**](#reference-variable-restrictions): *Reference kind modifier of parameter doesn't match the corresponding parameter in target.*
- [**CS9200**](#reference-variable-restrictions): *A default value is specified for `ref readonly` parameter, but `ref readonly` should be used only for references. Consider declaring the parameter as `in`.*
- [**CS9201**](#reference-variable-restrictions): *Ref field should be ref-assigned before use.*
- [**CS9205**](#incorrect-syntax): *Expected interpolated string.*
- [**CS9265**](#reference-variable-restrictions): *Field is never ref-assigned to, and will always have its default value (null reference)*

These errors and warnings follow these themes:

- ***[Incorrect syntax](#incorrect-syntax)***:  The syntax of your declaration or usage is invalid.
- ***[Language constructs where `ref` variables aren't valid](#reference-variable-restrictions)***:  Some C# idioms don't allow variables. Usually this is because ref safety analysis can't be performed reliably.
- ***[Value expression used where a reference variable is needed](#reference-variables-require-a-referent)***:  The expression used as a reference variable must be a variable, not a value expression.
- ***[Writable reference variables referring to readonly variables](#writable-reference-variables-require-a-writable-referent)***:  A reference to a readonly variable can't be passed by writable reference.

This article uses the term *reference variable* as a general term for a parameter declared with one of the `in`, `ref readonly`, `ref`, or `out` modifiers, or a `ref` local variable, a `ref` field in a `ref struct`, or a `ref` return. A reference variable refers to another variable, called the *referent*.

## Incorrect syntax

These errors indicate that you're using incorrect syntax regarding reference variables:

- **CS8373**:  *The left-hand side of a `ref` assignment must be a ref variable.*
- **CS8388**:  *An `out` variable cannot be declared as a ref local.*
- **CS9190**:  *`readonly` modifier must be specified after `ref`.*
- **CS9205**: *Expected interpolated string.*

To correct these errors:

- Ensure the left operand of a `= ref` operator is a reference variable rather than a value expression or non-reference local. Ref assignment requires both sides to be reference variables that can create an alias to the same storage location (**CS8373**).
- When declaring reference parameters, write the modifier as `ref readonly` rather than `readonly ref`. The C# language specification requires the `ref` keyword to precede the `readonly` modifier in parameter declarations to maintain consistent syntax across all reference parameter types (**CS9190**).
- Use the `ref` keyword instead of `out` when declaring local reference variables. `out` is exclusively a parameter modifier that indicates a method must assign a value before returning, whereas `ref` is the appropriate keyword for creating local variables that alias other storage locations (**CS8388**).
- Pass a regular variable or value expression instead of an interpolated string when calling a method with an `out` parameter. Interpolated strings are immutable temporary values that can't be used as output parameters since they don't represent assignable storage locations (**CS9205**).

For more information about reference variables and their syntax requirements, see [reference variables](../statements/declarations.md#reference-variables) and the [C# Language Specification](~/_csharpstandard/standard/variables.md#96-reference-variables-and-returns).

## Reference variable restrictions

The following errors indicate that a reference variable can't be used where you have one:

- **CS0631**:  *`ref` and `out` are not valid in this context*
- **CS0767**:  *Cannot inherit interface with the specified type parameters because it causes method to contain overloads which differ only on `ref` and `out`*
- **CS1623**:  *Iterators cannot have `ref`, `in` or `out` parameters*
- **CS1741**:  *A `ref` or `out` parameter cannot have a default value*
- **CS1939**:  *Cannot pass the range variable as an `out` or `ref` parameter*
- **CS1988**:  *Async methods cannot have `ref`, `in` or `out` parameters*
- **CS7084**:  *A Windows Runtime event may not be passed as an `out` or `ref` parameter.*
- **CS8196**:  *Reference to an implicitly-typed `out` variable is not permitted in the same argument list.*
- **CS8325**:  *'await' cannot be used in an expression containing a `ref` conditional operator*
- **CS8326**:  *Both conditional operator values must be ref values or neither may be a ref value*
- **CS8327**:  *The expression must be of correct type to match the alternative ref value*
- **CS8337**:  *The first parameter of a '`ref`' extension method must be a value type or a generic type constrained to struct.*
- **CS8338**:  *The first '`in`' or '`ref readonly`' parameter of the extension method must be a concrete (non-generic) value type.*
- **CS8977**:  *Cannot use '`ref`', '`in`', or '`out`' in the signature of a method attributed with 'UnmanagedCallersOnly'.*
- **CS9072**:  *A deconstruction variable cannot be declared as a ref local*
- **CS9104**:  *A `using` statement resource of type cannot be used in async methods or async lambda expressions.*
- **CS9199**:  *A `ref readonly` parameter cannot have the Out attribute.*

The following warnings indicate that a reference variable shouldn't be used, and might be unsafe:

- **CS9196**:  *Reference kind modifier of parameter doesn't match the corresponding parameter in overridden or implemented member.*
- **CS9197**:  *Reference kind modifier of parameter doesn't match the corresponding parameter in hidden member.*
- **CS9198**:  *Reference kind modifier of parameter doesn't match the corresponding parameter in target.*
- **CS9200**:  *A default value is specified for `ref readonly` parameter, but `ref readonly` should be used only for references. Consider declaring the parameter as `in`.*
- **CS9201**:  *Ref field should be ref-assigned before use.*
- **CS9265**: *Field is never ref-assigned to, and will always have its default value (null reference)*

To correct these errors:

- Remove reference parameters from [indexers](../../programming-guide/indexers/index.md). Indexers are designed to provide array-like access syntax and the compiler can't guarantee safe lifetime tracking for references passed through indexer accessors (**CS0631**, **CS1623**).
- Remove reference parameters from [iterator methods](../../iterators.md). Iterators execute code lazily across multiple calls using state machines, and the compiler can't ensure referenced variables remain valid across yield return boundaries where execution is suspended and resumed (**CS1623**).
- Remove reference parameters from [async methods](../../asynchronous-programming/index.md). Async methods may suspend execution at await points and resume on different threads, making it impossible to guarantee that referenced variables remain valid and accessible throughout the method's execution (**CS1988**).
- Avoid using [await expressions](../operators/await.md) inside [ref conditional expressions](../operators/conditional-operator.md#conditional-ref-expression). The await operation may suspend execution and invalidate the references being selected by the conditional operator, leading to potential use of invalidated references when execution resumes (**CS8325**).
- Ensure both branches of a ref conditional operator return references or neither returns a reference, and when both are references they must be the same type. The conditional operator must produce a consistent result type that can be safely used by the calling code regardless of which branch is selected (**CS8326**, **CS8327**).
- Remove default values from `ref` and `out` parameters. Reference parameters must always be provided at the call site to establish the required aliasing relationship between the parameter and an existing variable, making default values semantically meaningless (**CS1741**).
- Avoid declaring an implicitly typed `out` variable in an argument list that also references that same variable. The compiler must infer the variable's type from the method signature while simultaneously validating uses of that variable within the same expression, creating a circular dependency (**CS8196**).
- Don't pass [LINQ query](../../linq/get-started/query-expression-basics.md) range variables as reference parameters. Range variables are compiler-generated iteration variables whose lifetime is managed by the query execution model and don't have stable memory locations that can be safely referenced (**CS1939**).
- Use regular value variables instead of ref locals when [deconstructing](../operators/patterns.md#positional-pattern) objects. Deconstruction creates new variables to receive the deconstructed values and reference variables would attempt to alias these temporary values rather than store them independently (**CS9072**).
- Avoid implementing multiple interfaces where methods differ only by `ref` versus `out` modifiers on parameters. The C# language specification treats these as distinct signatures but doesn't provide a way to disambiguate which implementation to call since both `ref` and `out` share the same calling syntax at implementation boundaries (**CS0767**).
- Remove reference parameters from methods decorated with <xref:System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute?displayProperty=nameWithType>. These methods are callable from unmanaged code that doesn't understand C#'s reference safety rules and can't guarantee proper lifetime management of referenced variables across the managed/unmanaged boundary (**CS8977**).
- Use the `ref` modifier on [extension method](../../programming-guide/classes-and-structs/extension-methods.md) first parameters only for value types or generic types constrained to value types. Reference types are already passed by reference at the CLR level and adding `ref` would create a reference to a reference, while value type extensions with `ref` enable mutation of the extended instance (**CS8337**, **CS8338**).
- Don't pass Windows Runtime events as reference parameters. These events follow the Windows Runtime type system which has different lifetime and threading semantics than .NET references and doesn't support the aliasing behavior required by C# reference parameters (**CS7084**).
- Remove the <xref:System.Runtime.InteropServices.OutAttribute?displayProperty=nameWithType> from `ref readonly` parameters. This attribute is designed for marshaling semantics in platform invoke scenarios where the parameter direction is outbound only, which conflicts with `ref readonly`'s guarantee that the parameter references existing data that won't be reassigned (**CS9199**).
- Ensure all `ref` fields in a type are assigned either in field initializers or in all constructor code paths before the constructor completes. Uninitialized ref fields would contain invalid references that could lead to memory corruption if accessed (**CS9201**, **CS9265**).
- Match the reference kind modifiers (`ref`, `in`, `out`, `ref readonly`) between a method and its overridden base method or implemented interface method. The reference modifier is part of the method signature contract that derived types must honor to maintain substitutability and caller expectations (**CS9196**, **CS9197**, **CS9198**).
- Declare parameters as `in` rather than `ref readonly` when providing default values. `ref readonly` is designed for scenarios where the caller passes a reference to an existing variable, whereas `in` parameters can accept both references and temporary copies of values, making default values meaningful (**CS9200**).

For more information about where reference variables are allowed, see [Method parameters](../keywords/method-parameters.md), [Iterators](../../iterators.md), [Asynchronous programming patterns](../../asynchronous-programming/index.md), and the [C# Language Specification](~/_csharpstandard/standard/variables.md#96-reference-variables-and-returns).

## `unscoped ref` restrictions

The `unscoped` qualifier on `ref` parameters isn't allowed in some locations:

- **CS9101**:  *UnscopedRefAttribute can only be applied to struct instance or virtual interface methods and properties, and cannot be applied to constructors or  or init-only members.*
- **CS9102**:  *UnscopedRefAttribute cannot be applied to an interface implementation because implemented member doesn't have this attribute..*

To correct these errors:

- Remove the `unscoped` modifier or the <xref:System.Runtime.CompilerServices.UnscopedRefAttribute?displayProperty=nameWithType> attribute from struct constructors and init-only members. These members have special initialization semantics where the compiler must ensure that any references don't outlive the initialization phase, and allowing unscoped references would violate the guarantee that initialization completes before the struct becomes fully accessible (**CS9101**).
- Remove the `unscoped` modifier from interface implementation methods when the corresponding interface method doesn't have it. The unscoped characteristic affects the method's contract regarding reference lifetime guarantees, and implementations must maintain the same contract as the interface they're implementing to ensure callers can rely on consistent lifetime behavior regardless of which implementation is invoked (**CS9102**).

For more information about scoped and unscoped references, see [Method parameters](../keywords/method-parameters.md) and the [low-level struct improvements](~/_csharplang/proposals/csharp-11.0/low-level-struct-improvements.md) feature specification.

## Reference variables require a referent

You must supply a variable as an argument to a reference parameter, reference return, or ref local assignment:

- **CS0206**:  *A non ref-returning property or indexer may not be used as an `out` or `ref` value*
- **CS1510**:  *A `ref` or `out` value must be an assignable variable*

Warnings:

- **CS9191**:  *The `ref` modifier for argument corresponding to `in` parameter is equivalent to `in`. Consider using `in` instead.*
- **CS9192**:  *Argument should be passed with `ref` or `in` keyword.*
- **CS9193**:  *Argument should be a variable because it is passed to a `ref readonly` parameter*
- **CS9195**:  *Argument should be passed with the `in` keyword*

To correct these errors:

- Store the result of a property or indexer access in a local variable before passing it as a reference parameter. [Properties](../../programming-guide/classes-and-structs/properties.md) and [indexers](../../programming-guide/indexers/index.md) are methods that return values rather than providing direct access to storage locations, and reference parameters require an actual variable with a stable memory location that can be aliased (**CS0206**, **CS1510**).
- Use the `in` modifier instead of `ref` when passing arguments to `in` parameters. While `ref` technically works due to backward compatibility, the `in` modifier more clearly expresses the intent that the argument is read-only and may be passed more efficiently as a reference without copying (**CS9191**, **CS9195**).
- Add the appropriate reference modifier (`ref`, `in`, or `ref readonly`) when passing arguments to parameters that expect references. Omitting the modifier may cause the compiler to create a temporary copy of the value, which is inefficient and can lead to unexpected behavior if the calling code expects modifications to be reflected in the original variable (**CS9192**, **CS9193**).

For more information about reference parameters and passing variables by reference, see [Method parameters](../keywords/method-parameters.md), [ref keyword](../keywords/ref.md), and the [C# Language Specification](~/_csharpstandard/standard/variables.md#96-reference-variables-and-returns).

## Writable reference variables require a writable referent

A writable reference variable requires that the referent also is writable. The following errors indicate that the variable isn't writable:

- **CS0192**:  *A `readonly` field cannot be used as a `ref` or `out` value (except in a constructor)*
- **CS0199**:  *A `static readonly` field cannot be used as a `ref` or `out` value (except in a static constructor)*
- **CS1605**:  *Cannot use variable as a `ref` or `out` value because it is read-only*
- **CS1649**:  *Members of a `readonly` field cannot be used as a `ref` or `out` value (except in a constructor)*
- **CS1651**:  *Fields of a `static readonly` field cannot be used as a `ref` or `out` value (except in a static constructor)*
- **CS1655**:  *Cannot use fields of type as a `ref` or `out` value*
- **CS1657**:  *Cannot use variable as a `ref` or `out` value*
- **CS8329**:  *Cannot use variable as a `ref` or `out` value because it is a readonly variable*
- **CS8330**:  *Members of variable cannot be used as a `ref` or `out` value because it is a readonly variable*
- **CS8331**:  *Cannot assign to variable or use it as the right hand side of a `ref` assignment because it is a readonly variable*
- **CS8332**:  *Cannot assign to a member of variable or use it as the right hand side of a `ref` assignment because it is a readonly variable*

To correct these errors:

- Copy the value from a [readonly field](../keywords/readonly.md) to a local variable and pass the local variable as a `ref` or `out` parameter. Readonly fields are immutable after initialization (except within constructors) and allowing writable references to them would violate the immutability guarantee that readonly provides (**CS0192**, **CS0199**, **CS1649**, **CS1651**).
- Use `ref readonly` or `in` parameters instead of `ref` or `out` when you need to pass readonly variables, iteration variables, or other non-writable values by reference. These modifiers indicate that the method will only read the referenced value without attempting to modify it. That aligns with the immutability constraints of the original variable (**CS1605**, **CS1655**, **CS1657**, **CS8329**).
- Copy members of readonly variables to local variables before passing them as writable references. Even though the member itself might not be declared as readonly, it's accessed through a readonly path (via a readonly field, `in` parameter, or `ref readonly` local), and the compiler enforces transitivity of readonly-ness to prevent indirect mutation of readonly data (**CS8330**, **CS8332**).
- Avoid writable ref assignments to readonly variables, [foreach iteration variables](../statements/iteration-statements.md#the-foreach-statement), [using statement resources](../statements/using.md), or [fixed statement variables](../statements/fixed.md). These variables have special lifetime semantics managed by the compiler. The variable is automatically finalized or disposed at the end of its scope. External references create dangling references after disposal (**CS8331**).

For more information about readonly semantics and reference parameters, see [readonly keyword](../keywords/readonly.md), [in parameter modifier](../keywords/method-parameters.md#in-parameter-modifier), [ref readonly](../statements/declarations.md#reference-variables), and the [C# Language Specification](~/_csharpstandard/standard/variables.md#96-reference-variables-and-returns).
