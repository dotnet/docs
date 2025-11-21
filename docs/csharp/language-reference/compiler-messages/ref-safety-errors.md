---
title: Errors and warnings related to ref safety
description: The compiler issues these errors and warnings when the referent of a reference variable might not be valid. These errors prevent you from creating dangling references.
f1_keywords:
  - "CS8166"
  - "CS8167"
  - "CS8168"
  - "CS8169"
  - "CS8345"
  - "CS8351"
  - "CS8374"
  - "CS9077"
  - "CS9078"
  - "CS9079"
  - "CS9085"
  - "CS9086"
  - "CS9088"
  - "CS9089"
  - "CS9090"
  - "CS9091"
  - "CS9091"
  - "CS9092"
  - "CS9093"
  - "CS9094"
  - "CS9095"
  - "CS9096"
  - "CS9097"
helpviewer_keywords:
  - "CS8166"
  - "CS8167"
  - "CS8168"
  - "CS8169"
  - "CS8345"
  - "CS8351"
  - "CS8374"
  - "CS9077"
  - "CS9078"
  - "CS9079"
  - "CS9085"
  - "CS9086"
  - "CS9087"
  - "CS9089"
  - "CS9091"
  - "CS9092"
  - "CS9093"
  - "CS9094"
  - "CS9095"
  - "CS9096"
  - "CS9097"
ai-usage: ai-assisted
ms.date: 11/21/2024
---
# Errors and warnings related to ref safety

The following errors can be generated when reference variable safety rules are violated:

<!-- The text in the bullet lists generate issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS8166**](#returning-references-with-incompatible-scopes): *Cannot return a parameter by reference because it is not a `ref` parameter*
- [**CS8167**](#returning-references-with-incompatible-scopes): *Cannot return by reference a member of parameter because it is not a `ref` or `out` parameter*
- [**CS8168**](#returning-references-with-incompatible-scopes): *Cannot return local by reference because it is not a ref local*
- [**CS8169**](#returning-references-with-incompatible-scopes): *Cannot return a member of local variable by reference because it is not a ref local*
- [**CS8345**](#struct-member-and-field-restrictions): *Field or auto-implemented property cannot be of type unless it is an instance member of a `ref struct`.*
- [**CS8351**](#escape-scope-violations-and-conditional-operators): *Branches of a `ref` conditional operator cannot refer to variables with incompatible declaration scopes*
- [**CS8374**](#ref-assignments-with-incompatible-scopes): *Cannot ref-assign source has a narrower escape scope than destination.*
- [**CS9075**](#returning-references-with-incompatible-scopes): *Cannot return a parameter by reference because it is scoped to the current method*
- [**CS9076**](#returning-references-with-incompatible-scopes): *Cannot return by reference a member of parameter because it is scoped to the current method*
- [**CS9077**](#returning-references-with-incompatible-scopes): *Cannot return a parameter by reference through a `ref` parameter; it can only be returned in a return statement*
- [**CS9078**](#returning-references-with-incompatible-scopes): *Cannot return by reference a member of parameter through a `ref` parameter; it can only be returned in a return statement*
- [**CS9079**](#ref-assignments-with-incompatible-scopes): *Cannot ref-assign source to destination because source can only escape the current method through a return statement.*
- [**CS9096**](#ref-assignments-with-incompatible-scopes): *Cannot ref-assign source to destination because source has a wider value escape scope than destination allowing assignment through destination of values with narrower escapes scopes than source.*

The following warnings are generated when reference variable safety rules are violated:

- [**CS9080**](#escape-scope-violations-and-conditional-operators): *Use of variable in this context may expose referenced variables outside of their declaration scope*
- [**CS9081**](#escape-scope-violations-and-conditional-operators): *A result of a stackalloc expression of type in this context may be exposed outside of the containing method*
- [**CS9082**](#struct-member-and-field-restrictions): *Local is returned by reference but was initialized to a value that cannot be returned by reference*
- [**CS9083**](#struct-member-and-field-restrictions): *A member of is returned by reference but was initialized to a value that cannot be returned by reference*
- [**CS9084**](#struct-member-and-field-restrictions): *Struct member returns 'this' or other instance members by reference*
- [**CS9085**](#ref-assignments-with-incompatible-scopes): *This ref-assigns source to destination but source has a narrower escape scope than destination.*
- [**CS9086**](#escape-scope-violations-and-conditional-operators): *The branches of the ref conditional operator refer to variables with incompatible declaration scopes*
- [**CS9087**](#returning-references-with-incompatible-scopes): *This returns a parameter by reference but it is not a `ref` parameter*
- [**CS9088**](#returning-references-with-incompatible-scopes): *This returns a parameter by reference but it is scoped to the current method*
- [**CS9089**](#returning-references-with-incompatible-scopes): *This returns by reference a member of parameter that is not a `ref` or `out` parameter*
- [**CS9090**](#returning-references-with-incompatible-scopes): *This returns by reference a member of parameter that is scoped to the current method*
- [**CS9091**](#returning-references-with-incompatible-scopes): *This returns local by reference but it is not a ref local*
- [**CS9092**](#returning-references-with-incompatible-scopes): *This returns a member of local by reference but it is not a ref local*
- [**CS9093**](#ref-assignments-with-incompatible-scopes): *This ref-assigns source to destination but source can only escape the current method through a return statement.*
- [**CS9094**](#returning-references-with-incompatible-scopes): *This returns a parameter by reference through a `ref` parameter; but it can only safely be returned in a return statement*
- [**CS9095**](#returning-references-with-incompatible-scopes): *This returns by reference a member of parameter through a `ref` parameter; but it can only safely be returned in a return statement*
- [**CS9097**](#ref-assignments-with-incompatible-scopes): *This ref-assigns source to destination but source has a wider value escape scope than destination allowing assignment through destination of values with narrower escapes scopes than source.*

## Returning references with incompatible scopes

The compiler prevents you from returning a reference to a variable when the variable's lifetime doesn't extend beyond the method's scope. These errors occur when attempting to return by reference a parameter, local variable, or member that isn't declared with `ref` or has a scope limited to the current method.

Errors:

- **CS8166**: *Cannot return a parameter by reference because it is not a `ref` parameter*
- **CS8167**: *Cannot return by reference a member of parameter because it is not a `ref` or `out` parameter*
- **CS8168**: *Cannot return local by reference because it is not a ref local*
- **CS8169**: *Cannot return a member of local variable by reference because it is not a ref local*
- **CS9075**: *Cannot return a parameter by reference because it is scoped to the current method*
- **CS9076**: *Cannot return by reference a member of parameter because it is scoped to the current method*
- **CS9077**: *Cannot return a parameter by reference through a `ref` parameter; it can only be returned in a return statement*
- **CS9078**: *Cannot return by reference a member of parameter through a `ref` parameter; it can only be returned in a return statement*

Warnings:

- **CS9087**: *This returns a parameter by reference but it is not a `ref` parameter*
- **CS9088**: *This returns a parameter by reference but it is scoped to the current method*
- **CS9089**: *This returns by reference a member of parameter that is not a `ref` or `out` parameter*
- **CS9090**: *This returns by reference a member of parameter that is scoped to the current method*
- **CS9091**: *This returns local by reference but it is not a ref local*
- **CS9092**: *This returns a member of local by reference but it is not a ref local*
- **CS9094**: *This returns a parameter by reference through a `ref` parameter; but it can only safely be returned in a return statement*
- **CS9095**: *This returns by reference a member of parameter through a `ref` parameter; but it can only safely be returned in a return statement*

To resolve these errors:

- Change the method signature to declare parameters with the `ref` keyword instead of passing them by value, which allows the parameter's storage location to be returned safely because the caller controls the variable's lifetime (**CS8166**, **CS8167**, **CS9087**, **CS9089**).
- For local variables, declare them as `ref` locals by assigning them from a ref-returning expression or a ref parameter, which ensures the local refers to storage with a sufficient lifetime rather than creating a new variable with method-scoped lifetime (**CS8168**, **CS8169**, **CS9091**, **CS9092**).
- When a parameter is declared with the `scoped` modifier, avoid returning it by reference because the `scoped` modifier explicitly restricts the parameter's reference from escaping the method, preventing potential dangling references (**CS9075**, **CS9076**, **CS9088**, **CS9090**).
- If you need to return a reference that comes from a `ref` parameter, use a direct `return ref` statement rather than assigning the reference to another `ref` parameter and returning that, because the compiler can only track the escape scope through direct return statements (**CS9077**, **CS9078**, **CS9094**, **CS9095**).

For more information about ref safety rules, see the article on [ref returns and locals](../../programming-guide/classes-and-structs/ref-returns.md) and the C# standard section on [ref safe contexts](~/_csharpstandard/standard/variables.md#972-ref-safe-contexts).

## Ref assignments with incompatible scopes

The compiler prevents ref assignment operations where the source variable has a narrower escape scope than the destination. A ref assignment creates a reference from the destination to the source's storage location. If the source could go out of scope before the destination, the destination would refer to invalid memory.

Errors:

- **CS8374**: *Cannot ref-assign source has a narrower escape scope than destination.*
- **CS9079**: *Cannot ref-assign source to destination because source can only escape the current method through a return statement.*
- **CS9096**: *Cannot ref-assign source to destination because source has a wider value escape scope than destination allowing assignment through destination of values with narrower escapes scopes than source.*

Warnings:

- **CS9085**: *This ref-assigns source to destination but source has a narrower escape scope than destination.*
- **CS9093**: *This ref-assigns source to destination but source can only escape the current method through a return statement.*
- **CS9097**: *This ref-assigns source to destination but source has a wider value escape scope than destination allowing assignment through destination of values with narrower escapes scopes than source.*

To resolve these errors:

- Restructure your code so that the source variable in a ref assignment has an escape scope at least as wide as the destination variable, which ensures the destination reference remains valid for its entire lifetime and prevents dangling references (**CS8374**, **CS9085**).
- When working with variables that can only escape the method through a return statement, avoid assigning them to ref variables that might be accessed through other means such as being stored in fields or returned through ref parameters, because this would violate the restriction that the source can only be used in return statements (**CS9079**, **CS9093**).
- For ref assignments involving value escape scopes, ensure the source's value escape scope isn't wider than the destination's, because a mismatch would allow you to assign narrower-scoped values through the destination reference, potentially creating references to short-lived values (**CS9096**, **CS9097**).

For more information about ref safety rules, see the article on [ref returns and locals](../../programming-guide/classes-and-structs/ref-returns.md) and the C# standard section on [ref safe contexts](~/_csharpstandard/standard/variables.md#972-ref-safe-contexts).

## Escape scope violations and conditional operators

The compiler tracks how variables can escape their declaration scope through various operations. These errors occur when using variables in contexts that could expose referenced variables outside their valid lifetime, including ref conditional operators and stackalloc expressions.

Errors:

- **CS8351**: *Branches of a `ref` conditional operator cannot refer to variables with incompatible declaration scopes*

Warnings:

- **CS9080**: *Use of variable in this context may expose referenced variables outside of their declaration scope*
- **CS9081**: *A result of a stackalloc expression of type in this context may be exposed outside of the containing method*
- **CS9086**: *The branches of the ref conditional operator refer to variables with incompatible declaration scopes*

To resolve these errors:

- Modify the ref conditional operator (the `?:` operator with `ref` returns) so that both the true and false branches refer to variables that have compatible declaration scopes, which means both variables must have lifetimes that extend to at least the same scope level, preventing the conditional expression from potentially returning a reference that becomes invalid (**CS8351**, **CS9086**).
- When using variables in expressions or method calls, ensure the context doesn't allow referenced variables to escape beyond their declaration scope, which typically means avoiding passing scoped variables to methods or expressions where they might be captured or stored beyond their intended lifetime (**CS9080**).
- For stackalloc expressions, avoid assigning the result to variables or using it in contexts where the stack-allocated memory could be accessed outside the containing method, because stack-allocated memory is automatically freed when the method returns and accessing it afterward results in undefined behavior (**CS9081**).

For more information, see the article on [ref returns and locals](../../programming-guide/classes-and-structs/ref-returns.md), the article on [stack allocation](../../../standard/memory-and-spans/memory-t-usage-guidelines.md#stack-allocated-memory), and the C# standard section on [ref safe contexts](~/_csharpstandard/standard/variables.md#972-ref-safe-contexts).

## Struct member and field restrictions

The compiler enforces special rules for struct members and fields to prevent dangling references. These errors occur when struct members return references to instance state or when fields have types that require special handling.

Errors:

- **CS8345**: *Field or auto-implemented property cannot be of type unless it is an instance member of a `ref struct`.*

Warnings:

- **CS9082**: *Local is returned by reference but was initialized to a value that cannot be returned by reference*
- **CS9083**: *A member of is returned by reference but was initialized to a value that cannot be returned by reference*
- **CS9084**: *Struct member returns 'this' or other instance members by reference*

To resolve these errors:

- Ensure that fields and auto-implemented properties with ref-like types (such as `Span<T>` or `ref struct` types) are only declared as instance members within a ref struct rather than in regular structs or classes, because ref-like types can only safely exist on the stack and ref structs provide the necessary lifetime guarantees (**CS8345**).
- When returning a local variable by reference from a method, verify that the local was initialized from a source that has a sufficient escape scope such as a ref parameter or ref-returning method call, rather than from a value-typed expression or local-scoped variable that would create a reference to short-lived storage (**CS9082**, **CS9083**).
- In struct instance methods or properties, avoid returning `this` or any instance fields by reference, because structs are value types that are often copied, and returning a reference to an instance member could create a reference to a temporary copy that's immediately destroyed after the method returns (**CS9084**).

For more information, see the article on [ref struct types](../../language-reference/builtin-types/ref-struct.md) and the C# standard section on [ref safe contexts](~/_csharpstandard/standard/variables.md#972-ref-safe-contexts).
