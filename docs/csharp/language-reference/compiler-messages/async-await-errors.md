---
title: Resolve errors and warnings `async`, `await` and the Task-asynchronous protocol
description: These compiler errors and warnings indicate errors in the syntax for declaring and implementing `async` methods that use the `await` expression.
f1_keywords:
 - "CS1983"
 - "CS1985"
 - "CS1986"
 - "CS1989"
 - "CS1991"
 - "CS1992"
 - "CS1994"
 - "CS1995"
 - "CS1996"
 - "CS1997"
 - "CS1998"
 - "CS4008"
 - "CS4009"
 - "CS4014"
 - "CS4032"
 - "CS4033"
 - "CS8892"
 - "CS9123"
 - "CS9330"
helpviewer_keywords:
 - "CS1983"
 - "CS1985"
 - "CS1986"
 - "CS1989"
 - "CS1991"
 - "CS1992"
 - "CS1994"
 - "CS1995"
 - "CS1996"
 - "CS1997"
 - "CS1998"
 - "CS4008"
 - "CS4009"
 - "CS4014"
 - "CS4032"
 - "CS4033"
 - "CS8892"
 - "CS9123"
 - "CS9330"
ms.date: 11/10/2025
ai-usage: ai-assisted
---
# Resolve errors and warnings in async methods using the await operator

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS1983**](#async-method-signature-requirements): *Since this is an async method, the return expression must be of type '`Task<T>`' rather than '`T`'.*
- [**CS1985**](#await-expression-requirements): *Cannot await in a catch clause.*
- [**CS1986**](#await-expression-requirements): *'`await`' requires that the type have a suitable '`GetAwaiter`' method.*
- [**CS1989**](#async-practices): *Async lambda expressions cannot be converted to expression trees.*
- [**CS1991**](#async-practices): *'Type' cannot implement 'event' because it is a Windows Runtime event and 'event' is a regular .NET event.*
- [**CS1992**](#await-expression-requirements): *The '`await`' operator can only be used when contained within a method or lambda expression marked with the 'async' modifier.*
- [**CS1994**](#async-method-signature-requirements): *The '`async`' modifier can only be used in methods that have a body.*
- [**CS1995**](#await-expression-requirements): *The '`await`' operator may only be used in a query expression within the first collection expression of the initial '`from`' clause or within the collection expression of a '`join`' clause.*
- [**CS1996**](#await-expression-requirements): *Cannot await in the body of a lock statement.*
- [**CS1997**](#async-practices): *Since function is an async method that returns a value, a return keyword must not be followed by an object expression.*
- [**CS1998**](#async-practices): *This async method lacks '`await`' operators and will run synchronously. Consider using the '`await`' operator to await non-blocking API calls, or '`await Task.Run(...)`' to do CPU-bound work on a background thread.*
- [**CS4008**](#await-expression-requirements): *Cannot await '`void`'.*
- [**CS4009**](#async-method-signature-requirements): *A void or int returning entry point cannot be async.*
- [**CS4014**](#async-practices): *Because this call is not awaited, execution of the current method continues before the call is completed. Consider applying the `await` operator to the result of the call.*
- [**CS4032**](#await-expression-requirements): *The '`await`' operator can only be used within an async method. Consider marking this method with the 'async' modifier and changing its return type to '`Task<T>`'.*
- [**CS4033**](#await-expression-requirements): *The '`await`' operator can only be used within an async method. Consider marking this method with the '`async`' modifier and changing its return type to '`Task`'.*
- [**CS8892**](#async-method-signature-requirements): *Method will not be used as an entry point because a synchronous entry point was found.*
- [**CS9123**](#async-practices): *The '`&`' operator should not be used on parameters or local variables in async methods.*
- [**CS9330**](#async-method-signature-requirements): *'`MethodImplAttribute.Async`' cannot be manually applied to methods. Mark the method 'async'.*

## Await expression requirements

- **CS1985**: *Cannot await in a catch clause.*
- **CS1986**: *'`await`' requires that the type have a suitable '`GetAwaiter`' method.*
- **CS1992**: *The '`await`' operator can only be used when contained within a method or lambda expression marked with the '`async`' modifier.*
- **CS1995**: *The '`await`' operator may only be used in a query expression within the first collection expression of the initial '`from`' clause or within the collection expression of a '`join`' clause.*
- **CS1996**: *Cannot await in the body of a lock statement.*
- **CS4008**: *Cannot await '`void`'.*
- **CS4032**: *The '`await`' operator can only be used within an async method. Consider marking this method with the '`async`' modifier and changing its return type to '`Task<T>`'.*
- **CS4033**: *The '`await`' operator can only be used within an async method. Consider marking this method with the '`async`' modifier and changing its return type to '`Task`'.*

To use the `await` operator correctly, follow these rules. For more information, see [Asynchronous programming with async and await](../../asynchronous-programming/index.md).

- Don't use `await` in catch clauses (**CS1985**). While you can use `await` in try blocks and finally blocks (in C# 6 and later), catch blocks present special challenges with exception handling and control flow.
- Don't use `await` inside [`lock` statement](../statements/lock.md) blocks (**CS1996**). The compiler doesn't support this to avoid emitting code prone to deadlocks.
- Use `await` only in specific locations within [query expressions](../keywords/query-keywords.md) (**CS1995**): within the first collection expression of the initial `from` clause, or within the collection expression of a `join` clause.
- Mark methods or lambda expressions with the `async` modifier before using `await` (**CS1992**, **CS4032**, **CS4033**).
- Ensure awaited types have an accessible `GetAwaiter` method that returns an awaiter type (**CS1986**).
- Don't apply `await` to expressions of type `void` (**CS4008**).
- Add the `async` modifier to methods or lambda expressions before using `await` (**CS1992**, **CS4032**, **CS4033**).
- Change the return type to `Task` for methods that don't return a value, or `Task<T>` for methods that return a value.

## Async method signature requirements

- **CS1983**: *Since this is an async method, the return expression must be of type '`Task<T>`' rather than '`T`'.*
- **CS1994**: *The '`async`' modifier can only be used in methods that have a body.*
- **CS4009**: *A void or int returning entry point cannot be async.*
- **CS8892**: *Method will not be used as an entry point because a synchronous entry point was found.*
- **CS9330**: *'`MethodImplAttribute.Async`' cannot be manually applied to methods. Mark the method '`async`'.*

To declare async methods correctly, follow these signature requirements. For more information, see [Async main return values](../../fundamentals/program-structure/main-command-line.md#async-main-return-values).

- Return one of the valid types: `void`, <xref:System.Threading.Tasks.Task>, `Task<T>`, a task-like type, <xref:System.Collections.Generic.IAsyncEnumerable%601>, or <xref:System.Collections.Generic.IAsyncEnumerator%601> (**CS1983**).
- Use the `async` modifier only on methods with a body (**CS1994**). Remove the `async` modifier on abstract methods in interfaces or classes.
- Update to C# 7.1 or higher to use `async` on the `Main` entry point, or avoid using `async` on entry points in earlier versions (**CS4009**).
- Remove synchronous entry points if you have both sync and async entry points (**CS8892**).
- Use the `async` keyword instead of manually applying `MethodImplAttribute.Async` (**CS9330**).

## Async practices

- **CS1989**: *Async lambda expressions cannot be converted to expression trees.*
- **CS1991**: *'Type' cannot implement 'event' because it is a Windows Runtime event and 'event' is a regular .NET event.*
- **CS1997**: *Since function is an async method that returns an expression, a return keyword must not be followed by an object expression.*
- **CS1998**: *This async method lacks '`await`' operators and will run synchronously. Consider using the '`await`' operator to await non-blocking API calls, or '`await Task.Run(...)`' to do CPU-bound work on a background thread.*
- **CS4014**: *Because this call is not awaited, execution of the current method continues before the call is completed. Consider applying the `await` operator to the result of the call.*
- **CS9123**: *The '`&`' operator should not be used on parameters or local variables in async methods.*

To write async code correctly and avoid common pitfalls, follow these best practices. For more information, see [Asynchronous programming with async and await](../../asynchronous-programming/index.md).

- Always [await](../operators/await.md) calls to async methods that return <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601> (**CS4014**). Unawaited calls can lead to lost exceptions and unexpected behavior.
- Don't return a value from async methods that return `Task` (non-generic); use `Task<T>` instead (**CS1997**).
- Include at least one `await` operator in async methods, or remove the `async` modifier (**CS1998**).
- Remove the `return` statement if the method should return `Task`.
- Change the method's return type to `Task<T>` to return a value.
- Remove the `async` modifier and return the task directly if you don't need the async state machine.
- Don't use async methods in expression trees (**CS1989**). Expression trees represent code as data and don't support the complex state machine transformations required by async methods.
- Don't mark add or remove accessors in an interface or WinRT event as async (**CS1991**). This is a platform-specific restriction for Windows Runtime interoperability.
- Avoid using the address-of operator (`&`) on expressions inside async methods (**CS9123**). The target may be relocated in memory during suspension, making the pointer invalid.
