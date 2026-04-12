---
title: Resolve pattern matching errors and warnings
description: There are several pattern matching warnings. Learn how to address these warnings.
f1_keywords:
  - "CS8116"
  - "CS8117"
  - "CS8119"
  - "CS8120"
  - "CS8121"
  - "CS8208"
  - "CS8502"
  - "CS8503"
  - "CS8504"
  - "CS8505"
  - "CS8506"
  - "CS8508"
  - "CS8509"
  - "CS8510"
  - "CS8512"
  - "CS8513"
  - "CS8515"
  - "CS8516"
  - "CS8517"
  - "CS8518"
  - "CS8519"
  - "CS8520"
  - "CS8521"
  - "CS8522"
  - "CS8523"
  - "CS8524"
  - "CS8525"
  - "CS8780"
  - "CS8781"
  - "CS8782"
  - "CS8793"
  - "CS8794"
  - "CS8846"
  - "CS8918"
  - "CS8978"
  - "CS8979"
  - "CS8980"
  - "CS8985"
  - "CS9013"
  - "CS9060"
  - "CS9134"
  - "CS9135"
  - "CS9336"
  - "CS9337"
  - "CS9344"
  - "CS9345"
helpviewer_keywords:
  - "CS8116"
  - "CS8117"
  - "CS8119"
  - "CS8120"
  - "CS8121"
  - "CS8208"
  - "CS8502"
  - "CS8503"
  - "CS8504"
  - "CS8505"
  - "CS8506"
  - "CS8508"
  - "CS8509"
  - "CS8510"
  - "CS8512"
  - "CS8513"
  - "CS8515"
  - "CS8516"
  - "CS8517"
  - "CS8518"
  - "CS8519"
  - "CS8520"
  - "CS8521"
  - "CS8522"
  - "CS8523"
  - "CS8524"
  - "CS8525"
  - "CS8780"
  - "CS8781"
  - "CS8782"
  - "CS8793"
  - "CS8794"
  - "CS8846"
  - "CS8918"
  - "CS8978"
  - "CS8979"
  - "CS8980"
  - "CS8985"
  - "CS9013"
  - "CS9060"
  - "CS9134"
  - "CS9336"
  - "CS9337"
  - "CS9344"
  - "CS9345"
ms.date: 03/16/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings in pattern matching expressions

This article covers the following compiler errors and warnings:

- [**CS8116**](#type-pattern-errors): *It is not legal to use nullable type in a pattern; use the underlying type instead.*
- [**CS8117**](#type-pattern-errors): *Invalid operand for pattern match; value required, but found expression.*
- [**CS8119**](#switch-expression-syntax-errors): *The switch expression must be a value; found expression.*
- [**CS8120**](#pattern-completeness-and-redundancy): *The switch case is unreachable. It has already been handled by a previous case or it is impossible to match.*
- [**CS8121**](#type-pattern-errors): *An expression of source type cannot be handled by a pattern of target type.*
- [**CS8208**](#type-pattern-errors): *It is not legal to use the type 'dynamic' in a pattern.*
- [**CS8502**](#subpattern-errors): *Matching the tuple type requires noted subpatterns, but incorrect subpatterns are present.*
- [**CS8503**](#subpattern-errors): *A property subpattern requires a reference to the property or field to be matched, e.g. '{{ Name: value }}'*
- [**CS8504**](#switch-expression-syntax-errors): *Pattern missing*
- [**CS8505**](#switch-expression-syntax-errors): *A default literal 'default' is not valid as a pattern. Use another literal (e.g. '0' or 'null') as appropriate. To match everything, use a discard pattern '\_'.*
- [**CS8506**](#switch-expression-syntax-errors): *No best type was found for the switch expression.*
- [**CS8508**](#type-pattern-errors): *The syntax 'var' for a pattern is not permitted to refer to a type, but `var` type is in scope here.*
- [**CS8509**](#pattern-completeness-and-redundancy): *The switch expression does not handle all possible values of its input type (it is not exhaustive). For example, the pattern '...' is not covered.*
- [**CS8510**](#pattern-completeness-and-redundancy): *The pattern is unreachable. It has already been handled by a previous arm of the switch expression or it is impossible to match.*
- [**CS8512**](#subpattern-errors): *The name '\_' refers to the constant, not the discard pattern. Use 'var \_' to discard the value, or '@\_' to refer to a constant by that name.*
- [**CS8513**](#type-pattern-errors): *The name '\_' refers to the type `_`, not the discard pattern. Use '@\_' for the type, or 'var \_' to discard.*
- [**CS8515**](#switch-expression-syntax-errors): *Parentheses are required around the switch governing expression.*
- [**CS8516**](#subpattern-errors): *The name does not identify a tuple element '{1}'.*
- [**CS8517**](#subpattern-errors): *The name does not match the corresponding 'Deconstruct' parameter.*
- [**CS8518**](#pattern-completeness-and-redundancy): *An expression of this type can never match the provided pattern.*
- [**CS8519**](#pattern-completeness-and-redundancy): *The given expression never matches the provided pattern.*
- [**CS8520**](#pattern-completeness-and-redundancy): *The given expression always matches the provided constant.*
- [**CS8521**](#type-pattern-errors): *Pattern-matching is not permitted for pointer types.*
- [**CS8522**](#subpattern-errors): *Element names are not permitted when pattern-matching via 'System.Runtime.CompilerServices.ITuple'.*
- [**CS8523**](#switch-expression-syntax-errors): *The discard pattern is not permitted as a case label in a switch statement. Use 'case var \_:' for a discard pattern, or 'case @\_:' for a constant named '\_'.*
- [**CS8524**](#pattern-completeness-and-redundancy): *The switch expression does not handle some values of its input type (it is not exhaustive) involving an unnamed enum value.*
- [**CS8525**](#subpattern-errors): *A variable designator must come after a property pattern.*
- [**CS8780**](#subpattern-errors): *A variable may not be declared within a 'not' or 'or' pattern.*
- [**CS8781**](#type-pattern-errors): *Relational patterns may not be used for a value of this type.*
- [**CS8782**](#type-pattern-errors): *Relational patterns may not be used for a floating-point NaN.*
- [**CS8793**](#pattern-completeness-and-redundancy): *The given expression always matches the provided pattern.*
- [**CS8794**](#pattern-completeness-and-redundancy): *An expression of type '{0}' always matches the provided pattern.*
- [**CS8846**](#pattern-completeness-and-redundancy): *The switch expression does not handle all possible values of its input type (it is not exhaustive). For example, this pattern is not covered. However, a pattern with a 'when' clause might successfully match this value.*
- [**CS8918**](#subpattern-errors): *Identifier or a simple member access expected.*
- [**CS8978**](#type-pattern-errors): *'...' cannot be made nullable.*
- [**CS8979**](#list-pattern-errors): *List patterns may not be used for a value of type '...'.*
- [**CS8980**](#list-pattern-errors): *Slice patterns may only be used once and directly inside a list pattern.*
- [**CS8985**](#list-pattern-errors): *List patterns may not be used for a value of type '...'. No suitable 'Length' or 'Count' property was found.*
- [**CS9013**](#list-pattern-errors): *A string 'null' constant is not supported as a pattern for '...'. Use an empty string instead.*
- [**CS9060**](#type-pattern-errors): *Cannot use a numeric constant or relational pattern on '...' because it inherits from or extends 'INumberBase&lt;T&gt;'. Consider using a type pattern to narrow to a specific numeric type.*
- [**CS9134**](#switch-expression-syntax-errors): *A switch expression arm does not begin with a 'case' keyword.*
- [**CS9135**](#switch-expression-syntax-errors): *A constant value of type is expected*
- [**CS9336**](#pattern-completeness-and-redundancy): *The pattern is redundant.*
- [**CS9337**](#pattern-completeness-and-redundancy): *The pattern is too complex to analyze for redundancy.*
- [**CS9344**](#switch-expression-syntax-errors): *The '==' operator is not supported in a pattern.*
- [**CS9345**](#switch-expression-syntax-errors): *The '!=' operator is not supported in a pattern. Use 'not' to represent a negated pattern.*

## Switch expression syntax errors

- **CS8119**: *The switch expression must be a value; found expression.*
- **CS8504**: *Pattern missing*
- **CS8505**: *A default literal 'default' is not valid as a pattern. Use another literal (e.g. '0' or 'null') as appropriate. To match everything, use a discard pattern '\_'.*
- **CS8506**: *No best type was found for the switch expression.*
- **CS8515**: *Parentheses are required around the switch governing expression.*
- **CS8523**: *The discard pattern is not permitted as a case label in a switch statement. Use 'case var \_:' for a discard pattern, or 'case @\_:' for a constant named '\_'.*
- **CS9134**: *A switch expression arm does not begin with a 'case' keyword.*
- **CS9135**: *A constant value of type is expected*
- **CS9344**: *The '==' operator is not supported in a pattern.*
- **CS9345**: *The '!=' operator is not supported in a pattern. Use 'not' to represent a negated pattern.*

Provide a value as the governing expression of a `switch` statement or expression (**CS8119**). The governing expression must produce a value. Types, namespaces, method groups, and `void`-returning methods aren't valid. Use an expression that evaluates to a value.

Provide a pattern where one is expected (**CS8504**). A switch arm or `is` expression requires a pattern after the appropriate syntax. Ensure you include a valid pattern expression.

Don't use the `default` literal as a pattern (**CS8505**). The `default` keyword isn't valid in pattern matching. Use a specific literal value like `0` or `null` instead, or use the discard pattern `_` to match any value.

Specify an explicit type for the switch expression result when the compiler can't deduce the best type from the arms (**CS8506**). This error occurs when the arms return values of different types that don't share a common type the compiler can infer automatically, such as method groups or lambdas. Assign the result to an explicitly typed variable instead of using `var`.

Enclose the governing expression of a `switch` statement in parentheses and the body in curly braces (**CS8515**). The `switch` statement requires parentheses around the expression being evaluated and curly braces around the body. This error occurs when either the parentheses or curly braces are missing.

Use `case var _:` instead of the bare discard `_` as a case label in a `switch` statement (**CS8523**). The bare discard pattern isn't allowed in switch statements because of ambiguity with a constant named `_`. Use `case var _:` for a discard, or `case @_:` to match a constant named `_`.

Remove the `case` keyword from switch expression arms. Switch expressions use a different syntax than switch statements (**CS9134**). In switch expressions, each arm consists of a pattern followed by the `=>` token and an expression, without the `case` keyword that's used in switch statements. Use constant values rather than variables in patterns. Pattern matching requires compile-time constants (**CS9135**). Variables can't be used as patterns. The compiler needs to know the exact values at compile time to generate the appropriate matching code.

Use relational pattern operators (`<`, `>`, `<=`, `>=`) or the `not` keyword instead of `==` and `!=` operators in patterns (**CS9344**, **CS9345**). The equality and inequality operators aren't supported in pattern syntax. Use a constant pattern for equality, and the `not` keyword for inequality.

For more information about the correct syntax, see [Switch expression](../operators/switch-expression.md).

## Pattern completeness and redundancy

- **CS8120**: *The switch case is unreachable. It has already been handled by a previous case or it is impossible to match.*
- **CS8509**: *The switch expression does not handle all possible values of its input type (it is not exhaustive). For example, the pattern '...' is not covered.*
- **CS8510**: *The pattern is unreachable. It has already been handled by a previous arm of the switch expression or it is impossible to match.*
- **CS8518**: *An expression of type can never match the provided pattern.*
- **CS8519**: *The given expression never matches the provided pattern.*
- **CS8520**: *The given expression always matches the provided constant.*
- **CS8524**: *The switch expression does not handle some values of its input type (it is not exhaustive) involving an unnamed enum value. For example, the noted pattern is not covered.*
- **CS8793**: *The given expression always matches the provided pattern.*
- **CS8794**: *An expression of type always matches the provided pattern.*
- **CS8846**: *The switch expression does not handle all possible values of its input type (it is not exhaustive). For example, the noted pattern is not covered. However, a pattern with a 'when' clause might successfully match this value.*
- **CS9336**: *The pattern is redundant.*
- **CS9337**: *The pattern is too complex to analyze for redundancy.*

Reorder or remove unreachable case labels in `switch` statements (**CS8120**). A `case` label is unreachable when a previous case already handles all values that the later case would match. This occurs when a more general pattern appears before a more specific one, or when the pattern is impossible to match for the input type.

Add switch arms that handle all possible input values to create exhaustive switch expressions (**CS8509**, **CS8524**, **CS8846**). Switch expressions must cover every possible value of the input type. Otherwise, the compiler can't guarantee that the expression produces a result for all inputs. The compiler warns separately for unnamed enum values (**CS8524**) and for cases where a `when` clause might match an otherwise-unhandled value (**CS8846**). Use the discard pattern (`_`) as a final catch-all arm to match any remaining values that you don't need to handle explicitly.

Reorder or remove unreachable switch expression arms (**CS8510**). Like **CS8120** for `switch` statements, this error indicates that a switch expression arm is unreachable because a previous arm already handles all values that the later arm would match.

Review patterns that can never match or always match the input (**CS8518**, **CS8519**, **CS8520**, **CS8793**, **CS8794**). These diagnostics indicate that the compiler can determine at compile time whether a pattern always or never matches. An always-matching pattern is redundant, and a never-matching pattern is dead code. Both can indicate logic errors.

Review patterns that the compiler identifies as redundant. Redundant patterns can indicate a logic error where you meant to use `not` or different logical operators (**CS9336**). Simplify complex patterns that are too difficult for the compiler to analyze for redundancy. Break them down into simpler, more maintainable expressions (**CS9337**).

For more information about exhaustiveness requirements and pattern optimization, see [Switch expression](../operators/switch-expression.md), [Switch statement](../statements/selection-statements.md#the-switch-statement), and [Patterns](../operators/patterns.md).

## Type pattern errors

- **CS8116**: *It is not legal to use nullable type in a pattern; use the underlying type instead.*
- **CS8117**: *Invalid operand for pattern match; value required, but found expression.*
- **CS8121**: *An expression of source type cannot be handled by a pattern of target type.*
- **CS8208**: *It is not legal to use the type 'dynamic' in a pattern.*
- **CS8508**: *The syntax 'var' for a pattern is not permitted to refer to a type, but `var` type is in scope here.*
- **CS8513**: *The name '\_' refers to the type `_`, not the discard pattern. Use '@\_' for the type, or 'var \_' to discard.*
- **CS8521**: *Pattern-matching is not permitted for pointer types.*
- **CS8781**: *Relational patterns may not be used for a value of type.*
- **CS8782**: *Relational patterns may not be used for a floating-point NaN.*
- **CS8978**: *'...' cannot be made nullable.*
- **CS9060**: *Cannot use a numeric constant or relational pattern on '...' because it inherits from or extends 'INumberBase&lt;T&gt;'. Consider using a type pattern to narrow to a specific numeric type.*

Use the underlying type instead of the nullable type in patterns (**CS8116**). You can't use a nullable value type like `int?` directly in a type pattern. Instead, use the underlying type (`int`), and the pattern matches both nullable and non-nullable values.

Provide a value as the operand for a pattern match (**CS8117**). The left-hand side of an `is` expression must be a value, not a type, namespace, or method group. Assign the result to a variable first, or use a different expression that produces a value.

Use a pattern type that's compatible with the expression type (**CS8121**). The compiler raises this error when there's no possible conversion between the expression type and the pattern type. For example, you can't match a `string` expression against an `int` type pattern. Change the pattern type to one that's compatible with the expression, or cast the expression to a compatible type.

Don't use `dynamic` as a type in a pattern (**CS8208**). The `dynamic` type isn't supported in pattern matching. Use `object` instead, or cast the value to a specific type before matching.

Rename the type `var` or use an explicit type in the pattern (**CS8508**). When a type named `var` is in scope, the `var` pattern syntax is ambiguous. The compiler can't determine whether you intend to use the `var` pattern or reference the type. Use the fully qualified type name, or rename the type to avoid the conflict.

Use `@_` to reference a type named `_`, or use `var _` for the discard pattern (**CS8513**). When a type named `_` is in scope, the compiler can't determine whether the `_` in a pattern refers to the type or the discard pattern.

Don't use pattern matching with pointer types (**CS8521**). Pointer types aren't supported in pattern matching expressions. Use explicit comparisons or casts instead.

Use a supported type with relational patterns (**CS8781**, **CS8782**). Relational patterns (`<`, `>`, `<=`, `>=`) only work with numeric types that support comparison. They can't be used with NaN values because NaN comparisons always return `false`.

Use the underlying type directly in patterns when working with types that can't be made nullable (**CS8978**). Types like `System.Nullable<T>`, pointer types, and ref struct types can't be made nullable. You must use the base type in your pattern matching logic.

Use type patterns to narrow generic numeric types to specific numeric types before applying numeric constants or relational patterns (**CS9060**). You can't match generic numeric types that implement `INumberBase<T>` directly by using numeric constants or relational patterns. The compiler can't determine which specific numeric type is being matched. You must first narrow the value to a concrete numeric type like `int`, `double`, or `decimal`.

For more information about type patterns, see [Nullable value types](../builtin-types/nullable-value-types.md), [Patterns](../operators/patterns.md), and [Generic math](../../../standard/generics/math.md).

## List pattern errors

- **CS8979**: *List patterns may not be used for a value of type '...'.*
- **CS8980**: *Slice patterns may only be used once and directly inside a list pattern.*
- **CS8985**: *List patterns may not be used for a value of type '...'. No suitable 'Length' or 'Count' property was found.*
- **CS9013**: *A string 'null' constant is not supported as a pattern for '...'. Use an empty string instead.*

Ensure the type supports the required operations for list patterns.  List patterns require types that are countable and indexable (**CS8979**, **CS8985**). The type must have an accessible `Length` or `Count` property and support indexing. Runtime types that support list patterns include arrays, `List<T>`, `Span<T>`, and other collection types with appropriate members.

Place slice patterns (`..`) directly inside a list pattern. Use them only once per list pattern because they can't appear in nested patterns or outside of list patterns (**CS8980**).

When matching `Span<char>` or `ReadOnlySpan<char>` types, use an empty string `""` instead of a string null constant. The literal `null` isn't supported as a pattern for span types (**CS9013**).

For more information about list pattern requirements and syntax, see [List patterns](../operators/patterns.md#list-patterns) and [Patterns](../operators/patterns.md).

## Subpattern errors

- **CS8502**: *Matching the tuple type requires subpatterns, but incorrect subpatterns are present.*
- **CS8503**: *A property subpattern requires a reference to the property or field to be matched, e.g. '{{ Name: value }}'*
- **CS8512**: *The name '\_' refers to the constant, not the discard pattern. Use 'var \_' to discard the value, or '@\_' to refer to a constant by that name.*
- **CS8516**: *The name does not identify tuple element.*
- **CS8517**: *The name does not match the corresponding 'Deconstruct' parameter.*
- **CS8522**: *Element names are not permitted when pattern-matching via 'System.Runtime.CompilerServices.ITuple'.*
- **CS8525**: *A variable designator must come after a property pattern.*
- **CS8780**: *A variable may not be declared within a 'not' or 'or' pattern.*
- **CS8918**: *Identifier or a simple member access expected.*

Provide the correct number of subpatterns when matching a tuple type (**CS8502**). The number of subpatterns in a positional pattern must match the number of elements in the tuple type. Add or remove subpatterns to match the tuple's arity.

Include the property or field name in property subpatterns (**CS8503**). Each property subpattern must specify which property or field to match. Use the syntax `{ PropertyName: pattern }` to identify the member.

Use `var _` for the discard pattern or `@_` for a constant named `_` (**CS8512**). When a constant named `_` is in scope, the bare `_` in a `case` label refers to the constant. To use the discard pattern, write `var _` instead.

Use the correct element names in positional patterns for tuples (**CS8516**) and deconstructed types (**CS8517**). When you name subpatterns in a positional pattern, the names must match the tuple element names or the `Deconstruct` method parameter names.

Don't use element names in positional patterns when matching via `ITuple` (**CS8522**). When a type is matched through the `ITuple` interface rather than through a `Deconstruct` method, there are no named elements. Remove the element names from the pattern.

Place the variable designator after the property pattern, not before it (**CS8525**). In a property pattern with a variable designation, the variable name must follow the closing brace of the pattern. For example, write `{ Length: > 0 } s` rather than `s { Length: > 0 }`.

You can't declare variables within `not` or `or` pattern combinators (**CS8780**). Variable declarations in `not` patterns aren't definitely assigned, and variables in `or` patterns are only assigned in one branch. Move the variable declaration outside the pattern combinator.

Use an identifier or a simple member access expression as property names in property patterns and positional subpatterns (**CS8918**). Complex expressions, method calls, or other non-simple member accesses aren't valid as the left-hand side of a property subpattern. Each subpattern name must be a direct property or field name, or a dotted member access path like `Property.SubProperty`.

For more information about subpattern syntax, see [Property pattern](../operators/patterns.md#property-pattern) and [Positional pattern](../operators/patterns.md#positional-pattern).
