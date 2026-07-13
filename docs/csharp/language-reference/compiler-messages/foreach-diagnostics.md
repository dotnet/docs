---
title: "Resolve errors and warnings related to async enumerables, enumerables, and `foreach` statements"
description: "This article helps you diagnose and correct compiler errors and warnings related to async enumerables, enumerables, and foreach statements"
f1_keywords:
  - "CS0202"
  - "CS0230"
  - "CS0278"
  - "CS0279"
  - "CS0280"
  - "CS0446"
  - "CS1579"
  - "CS1640"
  - "CS8186"
  - "CS8412"
  - "CS8413"
  - "CS8414"
  - "CS8415"
  - "CS8419"
  - "CS8420"
  - "CS8424"
  - "CS8425"
  - "CS8426"
  - "CS9353"
helpviewer_keywords:
  - "CS0202"
  - "CS0230"
  - "CS0278"
  - "CS0279"
  - "CS0280"
  - "CS0446"
  - "CS1579"
  - "CS1640"
  - "CS8186"
  - "CS8412"
  - "CS8413"
  - "CS8414"
  - "CS8415"
  - "CS8419"
  - "CS8420"
  - "CS8424"
  - "CS8425"
  - "CS8426"
  - "CS9353"
ms.date: 07/13/2026
ai-usage: ai-assisted
---

# Resolve errors and warnings for `foreach` statements and async enumerables

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

- [**CS0202**](#enumerable-pattern-requirements): *foreach requires that the return type 'type' of 'type.GetEnumerator()' must have a suitable public 'MoveNext' method and public 'Current' property*
- [**CS0230**](#foreach-statement-syntax): *Type and identifier are both required in a foreach statement*
- [**CS0278**](#enumerable-pattern-requirements): *'type' does not implement the 'pattern name' pattern. 'method name' is ambiguous with 'method name'.*
- [**CS0279**](#enumerable-pattern-requirements): *'type' does not implement the 'pattern name' pattern. 'method name' is not a public instance or extension method.*
- [**CS0280**](#enumerable-pattern-requirements): *'type' does not implement the 'pattern name' pattern. 'method name' has the wrong signature.*
- [**CS0446**](#foreach-statement-syntax): *Foreach cannot operate on a 'method group'. Did you intend to invoke the 'method group'?*
- [**CS1579**](#enumerable-pattern-requirements): *foreach statement cannot operate on variables of type 'type' because 'type' does not contain a public instance or extension definition for 'member'*
- [**CS1640**](#multiple-enumerable-implementations): *foreach statement cannot operate on variables of type 'type' because it implements multiple instantiations of 'interface'; try casting to a specific interface instantiation*
- [**CS8186**](#foreach-statement-syntax): *A foreach loop must declare its iteration variables.*
- [**CS8412**](#enumerable-pattern-requirements): *Asynchronous foreach requires that the return type 'type' of 'method' must have a suitable public 'MoveNextAsync' method and public 'Current' property*
- [**CS8413**](#multiple-enumerable-implementations): *Asynchronous foreach statement cannot operate on variables of type 'type' because it implements multiple instantiations of 'interface'; try casting to a specific interface instantiation*
- [**CS8414**](#mismatched-foreach-and-await-foreach): *foreach statement cannot operate on variables of type 'type' because 'type' does not contain a public instance or extension definition for 'member'. Did you mean 'await foreach' rather than 'foreach'?*
- [**CS8415**](#mismatched-foreach-and-await-foreach): *Asynchronous foreach statement cannot operate on variables of type 'type' because 'type' does not contain a public instance or extension definition for 'member'. Did you mean 'foreach' rather than 'await foreach'?*
- [**CS8419**](#async-iterator-method-body): *The body of an async-iterator method must contain a 'yield' statement.*
- [**CS8420**](#async-iterator-method-body): *The body of an async-iterator method must contain a 'yield' statement. Consider removing 'async' from the method declaration or adding a 'yield' statement.*
- [**CS8424**](#enumeratorcancellation-attribute-usage): *The EnumeratorCancellationAttribute applied to parameter 'name' will have no effect. The attribute is only effective on a parameter of type CancellationToken in an async-iterator method returning IAsyncEnumerable*
- [**CS8425**](#enumeratorcancellation-attribute-usage): *Async-iterator 'method' has one or more parameters of type 'CancellationToken' but none of them is decorated with the 'EnumeratorCancellation' attribute, so the cancellation token parameter from the generated 'IAsyncEnumerable<>.GetAsyncEnumerator' will be unconsumed*
- [**CS8426**](#enumeratorcancellation-attribute-usage): *The attribute [EnumeratorCancellation] cannot be used on multiple parameters*
- [**CS9353**](#mismatched-foreach-and-await-foreach): *'type' does not contain a definition for 'member' and no accessible extension method 'member' accepting a first argument of type 'type' could be found (did you mean to iterate over the async collection with 'await foreach' instead?)*

## `foreach` statement syntax

- **CS0230**: *Type and identifier are both required in a foreach statement*
- **CS0446**: *Foreach cannot operate on a 'method group'. Did you intend to invoke the 'method group'?*
- **CS8186**: *A foreach loop must declare its iteration variables.*

These errors indicate that the [`foreach` statement](../statements/iteration-statements.md#the-foreach-statement) itself is malformed, regardless of whether the collection type is valid.

Declare both a type (or `var`) and an identifier for the iteration variable (**CS0230**, **CS8186**). The `foreach` statement requires a loop variable declaration — you can't omit either the type or the name. For example, write `foreach (int x in collection)` rather than `foreach (int in collection)`.

Invoke the method or delegate rather than passing it as a collection expression (**CS0446**). If you reference a method group or delegate without parentheses in the `in` clause, the compiler reports this error because it expects a collection value. Add parentheses to call the method, provided it returns an enumerable type: `foreach (var item in GetItems())`.

## Enumerable pattern requirements

- **CS0202**: *foreach requires that the return type 'type' of 'type.GetEnumerator()' must have a suitable public 'MoveNext' method and public 'Current' property*
- **CS0278**: *'type' does not implement the 'pattern name' pattern. 'method name' is ambiguous with 'method name'.*
- **CS0279**: *'type' does not implement the 'pattern name' pattern. 'method name' is not a public instance or extension method.*
- **CS0280**: *'type' does not implement the 'pattern name' pattern. 'method name' has the wrong signature.*
- **CS1579**: *foreach statement cannot operate on variables of type 'type' because 'type' does not contain a public instance or extension definition for 'member'*
- **CS8412**: *Asynchronous foreach requires that the return type 'type' of 'method' must have a suitable public 'MoveNextAsync' method and public 'Current' property*

The `foreach` statement uses a pattern-based approach rather than requiring a specific interface. For a type to be enumerable, it must provide:

- A public parameterless `GetEnumerator` method (or `GetAsyncEnumerator` for `await foreach`) whose return type is a class, struct, or interface.
- On the enumerator return type: a public `Current` property and a public parameterless `MoveNext` method returning `bool` (or `MoveNextAsync` returning `ValueTask<bool>` for async).

For details on the enumerable pattern, see [Iteration statements - `foreach`](../statements/iteration-statements.md#the-foreach-statement).

Ensure `GetEnumerator` returns a proper enumerator type — not an array or pointer (**CS0202**). The return value must be a type that itself exposes `MoveNext` and `Current`.

Add a public `GetEnumerator` method if the type doesn't have one (**CS1579**). Alternatively, implement <xref:System.Collections.Generic.IEnumerable%601> or provide an extension method named `GetEnumerator`. For `await foreach`, provide `GetAsyncEnumerator` or implement <xref:System.Collections.Generic.IAsyncEnumerable%601>.

Ensure that `GetAsyncEnumerator` returns a type with a public `MoveNextAsync` method returning `ValueTask<bool>` and a public `Current` property (**CS8412**). This is the async equivalent of **CS0202**.

Resolve ambiguity when multiple methods match the pattern name (**CS0278**). This warning occurs when the compiler finds two candidates for `MoveNext` or `GetEnumerator`. Remove or rename the conflicting member, or cast to a specific interface to disambiguate.

Make pattern methods public and non-static (**CS0279**). The enumerable pattern requires that `GetEnumerator`, `MoveNext`, and `Current` be public instance members (or public extension methods). Change `internal` or `static` members to `public` instance members.

Correct the signature of pattern methods (**CS0280**). For example, `MoveNext` must take no parameters and return `bool`. If a field or property shadows the method name, rename it so the compiler can find the correct method.

## Multiple enumerable implementations

- **CS1640**: *foreach statement cannot operate on variables of type 'type' because it implements multiple instantiations of 'interface'; try casting to a specific interface instantiation*
- **CS8413**: *Asynchronous foreach statement cannot operate on variables of type 'type' because it implements multiple instantiations of 'interface'; try casting to a specific interface instantiation*

These errors occur when the collection type implements multiple generic instantiations of <xref:System.Collections.Generic.IEnumerable%601> (**CS1640**) or <xref:System.Collections.Generic.IAsyncEnumerable%601> (**CS8413**), creating ambiguity about which element type to enumerate.

Cast the collection to a specific interface instantiation before iterating. For example, if a type implements both `IEnumerable<int>` and `IEnumerable<string>`, write `foreach (int i in (IEnumerable<int>)collection)` to select the desired element type.

## Mismatched `foreach` and `await foreach`

- **CS8414**: *foreach statement cannot operate on variables of type 'type' because 'type' does not contain a public instance or extension definition for 'member'. Did you mean 'await foreach' rather than 'foreach'?*
- **CS8415**: *Asynchronous foreach statement cannot operate on variables of type 'type' because 'type' does not contain a public instance or extension definition for 'member'. Did you mean 'foreach' rather than 'await foreach'?*
- **CS9353**: *'type' does not contain a definition for 'member' and no accessible extension method 'member' accepting a first argument of type 'type' could be found (did you mean to iterate over the async collection with 'await foreach' instead?)*

These errors indicate a mismatch between the kind of `foreach` statement and the interfaces the collection type implements.

Use `await foreach` instead of `foreach` when the collection implements only <xref:System.Collections.Generic.IAsyncEnumerable%601> (**CS8414**, **CS9353**). Async-enumerable types provide `GetAsyncEnumerator` rather than `GetEnumerator`, so you must use `await foreach` in an `async` method to iterate them.

Use `foreach` instead of `await foreach` when the collection implements only <xref:System.Collections.Generic.IEnumerable%601> (**CS8415**). Synchronous collections don't provide `GetAsyncEnumerator`, so `await foreach` can't enumerate them.

## Async iterator method body

- **CS8419**: *The body of an async-iterator method must contain a 'yield' statement.*
- **CS8420**: *The body of an async-iterator method must contain a 'yield' statement. Consider removing 'async' from the method declaration or adding a 'yield' statement.*

These errors fire when a method's signature declares it as an async iterator (it's `async` and returns <xref:System.Collections.Generic.IAsyncEnumerable%601> or <xref:System.Collections.Generic.IAsyncEnumerator%601>) but the body contains no `yield return` or `yield break` statement.

Add at least one `yield return` statement to the method body to make it a valid async-iterator method. If you didn't intend the method to be an iterator, remove the `async` modifier and change the return type, or return a constructed async enumerable from a different source instead.

For more information on iterator methods, see [Iterators](../../iterators.md) and [`yield` statement](../statements/yield.md).

## `EnumeratorCancellation` attribute usage

- **CS8424**: *The EnumeratorCancellationAttribute applied to parameter 'name' will have no effect. The attribute is only effective on a parameter of type CancellationToken in an async-iterator method returning IAsyncEnumerable*
- **CS8425**: *Async-iterator 'method' has one or more parameters of type 'CancellationToken' but none of them is decorated with the 'EnumeratorCancellation' attribute, so the cancellation token parameter from the generated 'IAsyncEnumerable<>.GetAsyncEnumerator' will be unconsumed*
- **CS8426**: *The attribute [EnumeratorCancellation] cannot be used on multiple parameters*

These diagnostics relate to the <xref:System.Runtime.CompilerServices.EnumeratorCancellationAttribute>, which connects a <xref:System.Threading.CancellationToken> parameter to the token supplied by <xref:System.Collections.Generic.IAsyncEnumerable%601.GetAsyncEnumerator(System.Threading.CancellationToken)>.

Apply `[EnumeratorCancellation]` only to a parameter of type <xref:System.Threading.CancellationToken> in an async-iterator method that returns <xref:System.Collections.Generic.IAsyncEnumerable%601> (**CS8424**). The attribute has no effect in any other context — non-token parameters, non-iterator methods, or methods returning other types.

Add the `[EnumeratorCancellation]` attribute to exactly one `CancellationToken` parameter (**CS8425**). Without this attribute, the token provided by callers through `WithCancellation` is not forwarded to the iterator body. The generated `GetAsyncEnumerator(CancellationToken)` parameter goes unconsumed.

Apply the attribute to only one parameter — not multiple (**CS8426**). The runtime infrastructure supports forwarding a single cancellation token to the iterator. If you have multiple token parameters, designate only one with the attribute and combine others manually using <xref:System.Threading.CancellationTokenSource.CreateLinkedTokenSource(System.Threading.CancellationToken,System.Threading.CancellationToken)>.
