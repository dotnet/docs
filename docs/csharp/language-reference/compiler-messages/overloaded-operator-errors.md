---
title: Resolve errors and warnings related to operator declarations and overflow
description: This article helps you diagnose and correct compiler errors and warnings related to user-defined operator declarations, checked operators, and overflow or underflow in your types
f1_keywords:
  - "CS0031"
  - "CS0056"
  - "CS0057"
  - "CS0215"
  - "CS0216"
  - "CS0217"
  - "CS0218"
  - "CS0220"
  - "CS0221"
  - "CS0448"
  - "CS0463"
  - "CS0543"
  - "CS0552"
  - "CS0553"
  - "CS0554"
  - "CS0555"
  - "CS0556"
  - "CS0557"
  - "CS0558"
  - "CS0559"
  - "CS0562"
  - "CS0563"
  - "CS0564"
  - "CS0567"
  - "CS0590"
  - "CS0594"
  - "CS0652"
  - "CS0659"
  - "CS0660"
  - "CS0661"
  - "CS0715"
  - "CS1021"
  - "CS1037"
  - "CS1553"
  - "CS8778"
  - "CS8973"
  - "CS9023"
  - "CS9024"
  - "CS9025"
  - "CS9308"
  - "CS9310"
  - "CS9311"
  - "CS9312"
  - "CS9313"
  - "CS9340"
  - "CS9341"
  - "CS9342"
helpviewer_keywords:
  - "CS0031"
  - "CS0056"
  - "CS0057"
  - "CS0215"
  - "CS0216"
  - "CS0217"
  - "CS0218"
  - "CS0220"
  - "CS0221"
  - "CS0448"
  - "CS0463"
  - "CS0543"
  - "CS0552"
  - "CS0553"
  - "CS0554"
  - "CS0555"
  - "CS0556"
  - "CS0557"
  - "CS0558"
  - "CS0559"
  - "CS0562"
  - "CS0563"
  - "CS0564"
  - "CS0567"
  - "CS0590"
  - "CS0594"
  - "CS0652"
  - "CS0659"
  - "CS0660"
  - "CS0661"
  - "CS0715"
  - "CS1021"
  - "CS1037"
  - "CS1553"
  - "CS8778"
  - "CS8973"
  - "CS9023"
  - "CS9024"
  - "CS9025"
  - "CS9027"
  - "CS9308"
  - "CS9310"
  - "CS9311"
  - "CS9312"
  - "CS9313"
  - "CS9340"
  - "CS9341"
  - "CS9342"
ms.date: 03/25/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings for operator declarations and overflow

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0031**](#overflow-and-underflow-errors): *Constant value 'value' cannot be converted to a 'type'*
- [**CS0056**](#inconsistent-accessibility): *Inconsistent accessibility: return type 'type' is less accessible than operator 'operator'*
- [**CS0057**](#inconsistent-accessibility): *Inconsistent accessibility: parameter type 'type' is less accessible than operator 'operator'*
- [**CS0215**](#boolean-and-short-circuit-operators): *The return type of operator True or False must be bool*
- [**CS0216**](#boolean-and-short-circuit-operators): *The operator 'operator' requires a matching operator 'missing_operator' to also be defined*
- [**CS0217**](#boolean-and-short-circuit-operators): *In order to be applicable as a short circuit operator a user-defined logical operator ('operator') must have the same return type as the type of its 2 parameters.*
- [**CS0218**](#boolean-and-short-circuit-operators): *The type ('type') must contain declarations of operator true and operator false*
- [**CS0220**](#overflow-and-underflow-errors): *The operation overflows at compile time in checked mode*
- [**CS0221**](#overflow-and-underflow-errors): *Constant value 'value' cannot be converted to a 'type' (use 'unchecked' syntax to override)*
- [**CS0448**](#operator-signature-requirements): *The return type for `++` or `--` operator must be the containing type or derived from the containing type*
- [**CS0463**](#overflow-and-underflow-errors): *Evaluation of the decimal constant expression failed with error: 'error'*
- [**CS0543**](#overflow-and-underflow-errors): *'enumeration' : the enumerator value is too large to fit in its type*
- [**CS0552**](#user-defined-conversion-restrictions): *'conversion routine' : user defined conversion to/from interface*
- [**CS0553**](#user-defined-conversion-restrictions): *'conversion routine' : user defined conversion to/from base class*
- [**CS0554**](#user-defined-conversion-restrictions): *'conversion routine' : user defined conversion to/from derived class*
- [**CS0555**](#user-defined-conversion-restrictions): *User-defined operator cannot take an object of the enclosing type and convert to an object of the enclosing type*
- [**CS0556**](#user-defined-conversion-restrictions): *User-defined conversion must convert to or from the enclosing type*
- [**CS0557**](#user-defined-conversion-restrictions): *Duplicate user-defined conversion in type*
- [**CS0558**](#operator-declaration-requirements): *User-defined operator must be declared static and public*
- [**CS0559**](#operator-signature-requirements): *The parameter type for `++` or `--` operator must be the containing type*
- [**CS0562**](#operator-signature-requirements): *The parameter of a unary operator must be the containing type*
- [**CS0563**](#operator-signature-requirements): *One of the parameters of a binary operator must be the containing type*
- [**CS0564**](#operator-signature-requirements): *The first operand of an overloaded shift operator must have the same type as the containing type, and the type of the second operand must be int*
- [**CS0567**](#operator-signature-requirements): *Interfaces cannot contain operators*
- [**CS0590**](#operator-signature-requirements): *User-defined operators cannot return void*
- [**CS0594**](#overflow-and-underflow-errors): *Floating-point constant is outside the range of type 'type'*
- [**CS0652**](#overflow-and-underflow-errors): *Comparison to integral constant is useless; the constant is outside the range of type 'type'*
- [**CS0659**](#equality-operators): *'class' overrides Object.Equals(object o) but does not override Object.GetHashCode()*
- [**CS0660**](#equality-operators): *Type defines `operator ==` or `operator !=` but does not override `Object.Equals(object o)`*
- [**CS0661**](#equality-operators): *Type defines `operator ==` or `operator !=` but does not override `Object.GetHashCode()`*
- [**CS0715**](#operator-declaration-requirements): *Static classes cannot contain user-defined operators*
- [**CS1021**](#overflow-and-underflow-errors): *Integral constant is too large*
- [**CS1037**](#operator-declaration-requirements): *Overloadable operator expected*
- [**CS1553**](#operator-declaration-requirements): *Declaration is not valid; use 'modifier operator \<dest-type> (...' instead*
- [**CS8930**](static-abstract-interfaces.md#errors-in-type-implementing-interface-declaration): *Explicit implementation of a user-defined operator must be declared static*
- [**CS8931**](static-abstract-interfaces.md#errors-in-interface-declaration): *User-defined conversion in an interface must convert to or from a type parameter on the enclosing type constrained to the enclosing type*
- [**CS8778**](#overflow-and-underflow-errors): *Constant value 'value' may overflow 'type' at runtime (use 'unchecked' syntax to override)*
- [**CS8973**](#overflow-and-underflow-errors): *The operation may overflow at runtime (use 'unchecked' syntax to override)*
- [**CS9023**](#checked-operators): *Operator cannot be made checked.*
- [**CS9024**](#checked-operators): *Operator cannot be made unchecked.*
- [**CS9025**](#checked-operators): *Operator requires a matching non-checked version to also be declared.*
- [**CS9027**](#checked-operators): *Unexpected keyword 'unchecked'.*
- [**CS9308**](#operator-declaration-requirements): *User-defined operator must be declared public.*
- [**CS9310**](#operator-signature-requirements): *The return type for this operator must be void.*
- [**CS9311**](#interface-and-inheritance-requirements): *Type does not implement interface member. The type cannot implement member because one of them is not an operator.*
- [**CS9312**](#interface-and-inheritance-requirements): *Type cannot override inherited member because one of them is not an operator.*
- [**CS9313**](#interface-and-inheritance-requirements): *Overloaded compound assignment operator takes one parameter.*
- [**CS9340**](#operator-signature-requirements): *Operator cannot be applied to operands. The closest inapplicable candidate is shown.*
- [**CS9341**](#operator-signature-requirements): *Operator cannot be applied to operand. The closest inapplicable candidate is shown.*
- [**CS9342**](#operator-signature-requirements): *Operator resolution is ambiguous between the following members.*

## Operator signature requirements

- **CS0448**: *The return type for `++` or `--` operator must be the containing type or derived from the containing type.*
- **CS0559**: *The parameter type for `++` or `--` operator must be the containing type.*
- **CS0562**: *The parameter of a unary operator must be the containing type.*
- **CS0563**: *One of the parameters of a binary operator must be the containing type.*
- **CS0564**: *The first operand of an overloaded shift operator must have the same type as the containing type, and the type of the second operand must be int.*
- **CS0567**: *Interfaces can't contain operators.*
- **CS0590**: *User-defined operators can't return void.*
- **CS9310**: *The return type for this operator must be void.*
- **CS9340**: *Operator cannot be applied to operands. The closest inapplicable candidate is shown.*
- **CS9341**: *Operator cannot be applied to operand. The closest inapplicable candidate is shown.*
- **CS9342**: *Operator resolution is ambiguous between the following members.*

Each operator type has specific parameter and return type requirements defined by the language specification. For the full rules on which operators can be overloaded, see [Operator overloading](../operators/operator-overloading.md) and [Operators](~/_csharpstandard/standard/expressions.md#124-operators) in the C# specification.

- Change the return type of `++` or `--` operators to the containing type or a type derived from it (**CS0448**). The language requires that increment and decrement operators return a value compatible with the containing type so the result can be assigned back to the same variable.
- Change the parameter of `++` or `--` operators to the containing type (**CS0559**). Increment and decrement operators must operate on instances of their own type.
- Change the parameter of a unary operator to the containing type (**CS0562**). Unary operators must accept an operand of the type that declares them.
- Ensure at least one parameter of a binary operator is the containing type (**CS0563**). Binary operators must involve the declaring type so the compiler can resolve them through that type.
- Change the first parameter of a shift operator to the containing type and the second parameter to `int` (**CS0564**). The language defines shift operators with a specific signature: the type being shifted and an integer shift amount.
- Move operator declarations out of interfaces and into classes or structs (**CS0567**). Traditional (non-static abstract) operator declarations aren't permitted in interfaces. For static abstract operators in interfaces, see [Static abstract and virtual interface member errors](static-abstract-interfaces.md).
- Change the return type of the operator to a non-void type (**CS0590**). Most user-defined operators must return a value. The exception is compound assignment operators, which require a `void` return type (**CS9310**).
- Correct the parameter types or add missing operator overloads so the compiler can find a matching operator for the operand types used at the call site (**CS9340**, **CS9341**). When no applicable operator exists, the compiler shows the closest candidate to help diagnose the mismatch.
- Add explicit casts at the call site, or provide more specific overloads to eliminate ambiguity when multiple operator overloads match equally well (**CS9342**).

> [!IMPORTANT]
> The signature requirements for static binary operators and the corresponding instance compound assignment operators are different. Make sure the signature matches the declaration you want.

## Operator declaration requirements

- **CS0558**: *User-defined operator must be declared static and public.*
- **CS0715**: *Static classes can't contain user-defined operators.*
- **CS1037**: *Overloadable operator expected.*
- **CS1553**: *Declaration isn't valid; use 'modifier operator \<dest-type\> (...' instead.*
- **CS9308**: *User-defined operator must be declared public.*

The language requires specific modifiers and syntax for operator declarations. For the full rules, see [Operator overloading](../operators/operator-overloading.md) and [User-defined conversion operators](../operators/user-defined-conversion-operators.md).

- Add both the `static` and `public` modifiers to the operator declaration (**CS0558**, **CS9308**). The C# language requires all user-defined operators to be both static and public so they're accessible and callable without an instance.
- Move the operator declaration from a static class into a non-static class or struct (**CS0715**). Static classes can't have instances, so user-defined operators—which operate on instances of their containing type—aren't meaningful in static classes.
- Replace the invalid operator symbol with a [valid overloadable operator](../operators/operator-overloading.md#overloadable-operators) (**CS1037**). Only specific operators defined by the language can be overloaded.
- Correct the syntax to follow the required conversion operator form: `public static implicit operator <dest-type>(<source-type> parameter)` or `public static explicit operator <dest-type>(<source-type> parameter)` (**CS1553**). The compiler expects conversion operators to follow a specific declaration pattern.

For errors related to explicit interface implementations of operators in static abstract interfaces, see [Static abstract and virtual interface member errors](static-abstract-interfaces.md#errors-in-type-implementing-interface-declaration).

## Inconsistent accessibility

- **CS0056**: *Inconsistent accessibility: return type 'type' is less accessible than operator 'operator'.*
- **CS0057**: *Inconsistent accessibility: parameter type 'type' is less accessible than operator 'operator'.*

All types used in a public operator's signature must be at least as accessible as the operator itself. For the full rules, see [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md) and [Accessibility constraints](~/_csharpstandard/standard/basic-concepts.md#755-accessibility-constraints) in the C# specification.

- Change the return type to a type that's at least as accessible as the operator, or reduce the accessibility of the operator to match the return type (**CS0056**). A `public` operator can't expose a less-accessible type through its return value because callers outside the assembly wouldn't be able to use the result.
- Change the parameter type to a type that's at least as accessible as the operator, or reduce the accessibility of the operator to match the parameter type (**CS0057**). A `public` operator can't require a less-accessible type as a parameter because callers outside the assembly wouldn't be able to provide the argument.

## User-defined conversion restrictions

- **CS0552**: *User-defined conversion to/from interface.*
- **CS0553**: *User-defined conversion to/from base class.*
- **CS0554**: *User-defined conversion to/from derived class.*
- **CS0555**: *User-defined operator can't take an object of the enclosing type and convert to an object of the enclosing type.*
- **CS0556**: *User-defined conversion must convert to or from the enclosing type.*
- **CS0557**: *Duplicate user-defined conversion in type.*

The C# language restricts which types can participate in user-defined conversions. For the full rules, see [User-defined conversion operators](../operators/user-defined-conversion-operators.md) and [Conversion operators](~/_csharpstandard/standard/classes.md#15104-conversion-operators) in the C# specification.

- Remove the conversion operator that converts to or from an interface type (**CS0552**). The language prohibits user-defined conversions involving interface types because interface conversions are handled through the type system's reference conversions and boxing. Use explicit interface implementations or helper methods instead.
- Remove the conversion operator that converts to or from a base class (**CS0553**). Conversions between a type and its base class already exist through implicit reference conversions (upcast) and explicit reference conversions (downcast), so a user-defined conversion would create ambiguity.
- Remove the conversion operator that converts to or from a derived class (**CS0554**). Like base class conversions, conversions between a type and its derived types are built into the language through inheritance, and user-defined conversions would conflict with them.
- Remove the conversion operator that converts the enclosing type to itself (**CS0555**). Every type already has an implicit identity conversion to itself, so a user-defined conversion from a type to the same type is redundant and not permitted.
- Change one of the types in the conversion operator so that either the source or destination type is the enclosing type (**CS0556**). A user-defined conversion must involve the type that declares it—you can't define a conversion between two unrelated external types in a third type.
- Remove the duplicate conversion operator, or change one of the duplicate operators so the source and destination types differ from the other (**CS0557**). A type can declare only one implicit and one explicit conversion for any given pair of source and destination types.

## Boolean and short-circuit operators

- **CS0215**: *The return type of operator true or false must be bool.*
- **CS0216**: *The operator requires a matching operator to also be defined.*
- **CS0217**: *In order to be applicable as a short-circuit operator, a user-defined logical operator must have the same return type as the type of its 2 parameters.*
- **CS0218**: *The type must contain declarations of operator true and operator false.*

The C# language requires specific pairings and signatures for Boolean operators and short-circuit evaluation. For the full rules, see [true and false operators](../operators/true-false-operators.md), [Boolean logical operators](../operators/boolean-logical-operators.md), and [User-defined conditional logical operators](~/_csharpstandard/standard/expressions.md#12163-user-defined-conditional-logical-operators) in the C# specification.

- Change the return type of `operator true` and `operator false` to `bool` (**CS0215**). These operators determine whether a value is logically true or false, so the language requires them to return `bool`.
- Define the matching paired operator (**CS0216**). The language requires certain operators to be declared in pairs: `operator ==` with `operator !=`, `operator <` with `operator >`, `operator <=` with `operator >=`, and `operator true` with `operator false`.
- Change the return type of the user-defined `&` or `|` operator to match both parameter types (**CS0217**). For short-circuit evaluation (`&&` and `||`), the compiler requires the `&` or `|` operator's return type, both parameter types, and the containing type to all be the same type.
- Add both `operator true` and `operator false` declarations to the type (**CS0218**). The compiler rewrites `&&` and `||` using `operator true`, `operator false`, and the corresponding `&` or `|` operator, so all three must be present for short-circuit evaluation to work.

## Checked operators

- **CS9023**: *Operator can't be made checked*
- **CS9024**: *Operator can't be made unchecked*
- **CS9025**: *Checked operator requires a matching non-checked version to also be declared*
- **CS9027**: *Unexpected keyword 'unchecked'*

The `checked` and `unchecked` keywords can only be applied to specific operator declarations. For the full rules, see [Arithmetic operators](../operators/arithmetic-operators.md#user-defined-checked-operators) and [User-defined checked operators](~/_csharplang/proposals/csharp-11.0/checked-user-defined-operators.md).

- Remove the `checked` or `unchecked` keyword from an unsupported operator (**CS9023**, **CS9024**). Only the arithmetic operators `+`, `-`, `*`, `/`, `++`, `--`, and explicit conversion operators support checked and unchecked variants. Other operators, such as comparison or equality operators, don't have distinct overflow behavior and can't be marked checked or unchecked.
- Add a matching non-checked version of the operator (**CS9025**). A `checked` operator provides the overflow-throwing behavior, but the compiler also needs the corresponding unchecked version to use in `unchecked` contexts and as the default when neither context is specified.
- Remove the `unchecked` keyword from the invalid position (**CS9027**). The `unchecked` keyword in an operator declaration is only valid as part of the operator syntax (for example, `public static explicit operator unchecked int(MyType t)`). Placing it elsewhere in the declaration causes a syntax error.

## Interface and inheritance requirements

- **CS9311**: *Type doesn't implement interface member. The type can't implement member because one of them isn't an operator*
- **CS9312**: *Type can't override inherited member because one of them isn't an operator*
- **CS9313**: *Overloaded compound assignment operator takes one parameter*

The compiler enforces strict matching between operator declarations and the interface members or base class members they implement or override. For the full rules, see [Operator overloading](../operators/operator-overloading.md) and [Interfaces](../../fundamentals/types/interfaces.md).

- Change the implementing member to an operator declaration that matches the interface's operator member, or change the interface member to a method if the implementing member is a method (**CS9311**). An operator can only implement an interface member that's also declared as an operator—you can't satisfy an operator contract with a regular method, or vice versa.
- Change the overriding member to an operator declaration that matches the base class's operator member, or change the base class member to a method if the derived class member is a method (**CS9312**). Like interface implementation, an override must match the kind of member being overridden—an operator can't override a non-operator member.
- Change the compound assignment operator declaration to accept exactly one parameter (**CS9313**). Compound assignment operators are instance members where the left operand is implicitly `this`, so only the right-hand operand is declared as a parameter.

## Equality operators

- **CS0659**: *'class' overrides Object.Equals(object o) but does not override Object.GetHashCode()*
- **CS0660**: *Type defines operator == or operator != but doesn't override Object.Equals(object o)*
- **CS0661**: *Type defines operator == or operator != but doesn't override Object.GetHashCode()*

The compiler requires that equality-related overrides and operator definitions stay in sync. When you override <xref:System.Object.Equals*?displayProperty=nameWithType> or define `operator ==` / `operator !=`, you must also provide the related overrides. For the full rules, see [How to define value equality for a type](../../programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type.md) and [Equality operators](../operators/equality-operators.md).

- Add an override of <xref:System.Object.GetHashCode*?displayProperty=nameWithType> when you override <xref:System.Object.Equals*?displayProperty=nameWithType> (**CS0659**). Hash-based collections like <xref:System.Collections.Generic.Dictionary`2> and <xref:System.Collections.Generic.HashSet`1> rely on the contract that two objects that are equal must return the same hash code. Without a matching `GetHashCode` override, objects that compare as equal might hash to different buckets, causing lookups and deduplication to fail silently.
- Add an override of <xref:System.Object.Equals*?displayProperty=nameWithType> when you define `operator ==` or `operator !=` (**CS0660**). Code that calls `Equals` directly—including many framework APIs, LINQ methods, and collection operations—won't use your custom operator. Without a consistent `Equals` override, the same two objects might be considered equal by `==` but not by `Equals`, leading to unpredictable behavior.
- Add an override of <xref:System.Object.GetHashCode*?displayProperty=nameWithType> when you define `operator ==` or `operator !=` (**CS0661**). Like **CS0659**, you need `GetHashCode` to be consistent with your equality semantics. If `operator ==` considers two objects equal but they return different hash codes, hash-based collections won't function correctly.

## Overflow and underflow errors

- **CS0031**: *Constant value 'value' cannot be converted to a 'type'*
- **CS0220**: *The operation overflows at compile time in checked mode*
- **CS0221**: *Constant value 'value' cannot be converted to a 'type' (use 'unchecked' syntax to override)*
- **CS0463**: *Evaluation of the decimal constant expression failed with error: 'error'*
- **CS0543**: *'enumeration' : the enumerator value is too large to fit in its type*
- **CS0594**: *Floating-point constant is outside the range of type 'type'*
- **CS0652**: *Comparison to integral constant is useless; the constant is outside the range of type 'type'*
- **CS1021**: *Integral constant is too large*
- **CS8778**: *Constant value 'value' may overflow 'type' at runtime (use 'unchecked' syntax to override)*
- **CS8973**: *The operation may overflow at runtime (use 'unchecked' syntax to override)*

The compiler evaluates constant expressions at compile time and reports errors or warnings when a value exceeds the valid range of its target type. For the full rules, see [checked and unchecked statements](../statements/checked-and-unchecked.md) and [Integral types](../builtin-types/integral-numeric-types.md).

- Change the constant value to one that fits within the target type's range, or change the target to a larger numeric type (**CS0031**). The compiler can't implicitly narrow a constant that doesn't fit—for example, assigning `256` to a `byte` (range 0–255) produces this error. If the truncation is intentional, use an explicit cast in an `unchecked` context.
- Correct the arithmetic in the constant expression so the result fits the target type, or wrap the expression in an [unchecked](../statements/checked-and-unchecked.md) context to allow silent overflow (**CS0220**). The compiler evaluates the entire constant expression at compile time in a checked context by default, so intermediate or final results that exceed the type's range cause this error.
- Change the constant value or target type so the conversion is valid, or wrap the expression in an `unchecked` context if you intentionally want the truncated result (**CS0221**). Unlike **CS0220**, this error applies to explicit constant conversions where the source value doesn't fit the destination type.
- Simplify or break apart the `decimal` constant expression so it stays within the range and precision of the `decimal` type (**CS0463**). The `decimal` type has a maximum value of approximately $7.9 \times 10^{28}$ and 28–29 significant digits, and the compiler evaluates the full expression at compile time.
- Change the enum member value to one that fits in the enum's underlying type, or change the underlying type to a larger integral type (**CS0543**). By default, enums use `int` as the underlying type. If a member's value exceeds the underlying type's range, specify a larger type like `long`.
- Change the floating-point constant to a value within the range of the target type, or use a higher-precision type like `double` instead of `float` (**CS0594**). The `float` type supports values up to approximately $3.4 \times 10^{38}$, and `double` supports up to approximately $1.7 \times 10^{308}$.
- Remove or correct the comparison so the constant is within the range of the variable's type (**CS0652**). Comparing a `byte` variable to `300`, for example, can never be true, so the compiler warns that the comparison is useless. This warning often indicates a logic error or a mismatch between the variable type and the intended range of values.
- Use a larger numeric type or split the value across multiple operations (**CS1021**). This error occurs when an integer literal exceeds the range of even the largest integral type (`ulong`, up to $1.8 \times 10^{19}$). For values beyond that range, consider using <xref:System.Numerics.BigInteger>.
- Wrap the expression in an `unchecked` context to suppress the warning, or change the value to fit within the target type's range (**CS8778**). This warning indicates a constant conversion that might lose data at runtime—the compiler can't prove the overflow will definitely happen, but it identifies the risk.
- Wrap the expression in an `unchecked` context to suppress the warning, or restructure the arithmetic to avoid potential overflow (**CS8973**). This warning is similar to **CS8778** but applies to arithmetic operations rather than conversions—the compiler detects that the operation might overflow at runtime.
