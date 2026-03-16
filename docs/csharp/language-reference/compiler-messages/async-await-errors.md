---
title: Resolve errors and warnings that involve `async`, `await` and the Task-asynchronous protocol
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
 - "CS4001"
 - "CS4003"
 - "CS4005"
 - "CS4006"
 - "CS4007"
 - "CS4008"
 - "CS4009"
 - "CS4010"
 - "CS4011"
 - "CS4012"
 - "CS4014"
 - "CS4015"
 - "CS4016"
 - "CS4027"
 - "CS4028"
 - "CS4029"
 - "CS4030"
 - "CS4031"
 - "CS4032"
 - "CS4033"
 - "CS4034"
 - "CS8031"
 - "CS8100"
 - "CS8177"
 - "CS8178"
 - "CS8204"
 - "CS8403"
 - "CS8411"
 - "CS8892"
 - "CS8935"
 - "CS8940"
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
 - "CS4001"
 - "CS4003"
 - "CS4005"
 - "CS4006"
 - "CS4007"
 - "CS4008"
 - "CS4009"
 - "CS4010"
 - "CS4011"
 - "CS4012"
 - "CS4014"
 - "CS4015"
 - "CS4016"
 - "CS4027"
 - "CS4028"
 - "CS4029"
 - "CS4030"
 - "CS4031"
 - "CS4032"
 - "CS4033"
 - "CS4034"
 - "CS8031"
 - "CS8100"
 - "CS8177"
 - "CS8178"
 - "CS8204"
 - "CS8403"
 - "CS8411"
 - "CS8892"
 - "CS8935"
 - "CS8940"
 - "CS9123"
 - "CS9330"
ms.date: 03/16/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings in async methods that use the await operator

This article covers the following compiler errors:

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
- [**CS4001**](#await-expression-requirements): *Cannot await '{0}'.*
- [**CS4003**](#await-expression-requirements): *'`await`' cannot be used as an identifier within an async method or lambda expression.*
- [**CS4005**](#async-method-signature-requirements): *Async methods cannot have pointer type parameters.*
- [**CS4006**](#async-method-signature-requirements): *\_\_arglist is not allowed in the parameter list of async methods.*
- [**CS4007**](#await-expression-requirements): *Instance of type '{0}' cannot be preserved across '`await`' or '`yield`' boundary.*
- [**CS4008**](#await-expression-requirements): *Cannot await '`void`'.*
- [**CS4009**](#async-method-signature-requirements): *A void or int returning entry point cannot be async.*
- [**CS4010**](#async-method-signature-requirements): *Cannot convert async {0} to delegate type '{1}'. An async {0} may return void, Task or Task\<T\>, none of which are convertible to '{1}'.*
- [**CS4011**](#await-expression-requirements): *'`await`' requires that the return type '{0}' of '{1}.GetAwaiter()' have suitable 'IsCompleted', 'OnCompleted', and 'GetResult' members, and implement 'INotifyCompletion' or 'ICriticalNotifyCompletion'.*
- [**CS4012**](#async-method-signature-requirements): *Parameters of type '{0}' cannot be declared in async methods or async lambda expressions.*
- [**CS4014**](#async-practices): *Because this call is not awaited, execution of the current method continues before the call is completed. Consider applying the `await` operator to the result of the call.*
- [**CS4015**](#async-method-signature-requirements): *'MethodImplOptions.Synchronized' cannot be applied to an async method.*
- [**CS4016**](#async-method-signature-requirements): *Since this is an async method, the return expression must be of type '{0}' rather than '{1}'.*
- [**CS4027**](#await-expression-requirements): *'{0}' does not implement '{1}'.*
- [**CS4028**](#await-expression-requirements): *'`await`' requires that the type '{0}' have a suitable 'GetAwaiter' method. Are you missing a using directive for 'System'?*
- [**CS4029**](#async-practices): *Cannot return an expression of type 'void'.*
- [**CS4030**](#async-practices): *Security attribute '{0}' cannot be applied to an Async method.*
- [**CS4031**](#async-practices): *Async methods are not allowed in an Interface, Class, or Structure which has the 'SecurityCritical' or 'SecuritySafeCritical' attribute.*
- [**CS4032**](#await-expression-requirements): *The '`await`' operator can only be used within an async method. Consider marking this method with the 'async' modifier and changing its return type to '`Task<T>`'.*
- [**CS4033**](#await-expression-requirements): *The '`await`' operator can only be used within an async method. Consider marking this method with the '`async`' modifier and changing its return type to '`Task`'.*
- [**CS4034**](#await-expression-requirements): *The '`await`' operator can only be used within an async {0}. Consider marking this {0} with the 'async' modifier.*
- [**CS8031**](#async-method-signature-requirements): *Async lambda expression converted to a '{0}' returning delegate cannot return a value.*
- [**CS8100**](#await-expression-requirements): *The '`await`' operator cannot be used in a static script variable initializer.*
- [**CS8177**](#async-practices): *Async methods cannot have by-reference locals.*
- [**CS8178**](#await-expression-requirements): *A reference returned by a call to '{0}' cannot be preserved across '`await`' or '`yield`' boundary.*
- [**CS8204**](#async-method-signature-requirements): *For type '{0}' to be used as an AsyncMethodBuilder for type '{1}', its Task property should return type '{1}' instead of type '{2}'.*
- [**CS8403**](#async-method-signature-requirements): *Method '{0}' with an iterator block must be '`async`' to return '{1}'.*
- [**CS8411**](#await-expression-requirements): *Asynchronous foreach statement cannot operate on variables of type '{0}' because '{0}' does not contain a suitable public instance or extension definition for '{1}'.*
- [**CS8892**](#async-method-signature-requirements): *Method will not be used as an entry point because a synchronous entry point was found.*
- [**CS8935**](#async-method-signature-requirements): *The AsyncMethodBuilder attribute is disallowed on anonymous methods without an explicit return type.*
- [**CS8940**](#async-method-signature-requirements): *A generic task-like return type was expected, but the type '{0}' found in 'AsyncMethodBuilder' attribute was not suitable. It must be an unbound generic type of arity one, and its containing type (if any) must be non-generic.*
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
- **CS4034**: *The '`await`' operator can only be used within an async {0}. Consider marking this {0} with the 'async' modifier.*
- **CS8178**: *A reference returned by a call to '{0}' cannot be preserved across '`await`' or '`yield`' boundary.*
- **CS8411**: *Asynchronous foreach statement cannot operate on variables of type '{0}' because '{0}' does not contain a suitable public instance or extension definition for '{1}'.*
- **CS4001**: *Cannot await '{0}'.*
- **CS4003**: *'`await`' cannot be used as an identifier within an async method or lambda expression.*
- **CS4007**: *Instance of type '{0}' cannot be preserved across '`await`' or '`yield`' boundary.*
- **CS4011**: *'`await`' requires that the return type '{0}' of '{1}.GetAwaiter()' have suitable 'IsCompleted', 'OnCompleted', and 'GetResult' members, and implement 'INotifyCompletion' or 'ICriticalNotifyCompletion'.*
- **CS4027**: *'{0}' does not implement '{1}'.*
- **CS4028**: *'`await`' requires that the type '{0}' have a suitable 'GetAwaiter' method. Are you missing a using directive for 'System'?*
- **CS8100**: *The '`await`' operator cannot be used in a static script variable initializer.*

To use the `await` operator correctly, follow these rules. For more information, see [Asynchronous programming with async and await](../../asynchronous-programming/index.md).

- Don't use `await` in catch clauses (**CS1985**). While you can use `await` in try blocks and finally blocks (in C# 6 and later), catch blocks present special challenges with exception handling and control flow.
- Don't use `await` inside [`lock` statement](../statements/lock.md) blocks (**CS1996**). The compiler doesn't support this to avoid emitting code prone to deadlocks.
- Use `await` only in specific locations within [query expressions](../keywords/query-keywords.md) (**CS1995**): within the first collection expression of the initial `from` clause, or within the collection expression of a `join` clause.
- Mark methods or lambda expressions with the `async` modifier before using `await` (**CS1992**, **CS4032**, **CS4033**, **CS4034**).
- Ensure awaited types have an accessible `GetAwaiter` method that returns an awaiter type (**CS1986**, **CS4028**). If the type has a `GetAwaiter` method but you're missing a `using` directive for `System`, the compiler provides a more specific message (**CS4028**).
- Don't apply `await` to expressions of type `void` (**CS4008**) or to intrinsic types that can't be awaited (**CS4001**).
- Ensure the awaiter type returned by `GetAwaiter()` has the required `IsCompleted`, `OnCompleted`, and `GetResult` members and implements `INotifyCompletion` or `ICriticalNotifyCompletion` (**CS4011**, **CS4027**).
- Don't use `await` in an expression that contains a call to a by-reference returning method (**CS8178**). The reference can't be preserved across the `await` boundary because the async state machine may suspend and resume on a different thread or context. Store the result of the by-ref call in a local variable before using `await`.
- Ensure types used with `await foreach` have a suitable `GetAsyncEnumerator` method (**CS8411**). The type must implement <xref:System.Collections.Generic.IAsyncEnumerable%601> or have an accessible `GetAsyncEnumerator` method that returns a type with `Current` and `MoveNextAsync` members.
- Don't use `await` as an identifier within an async method or lambda expression (**CS4003**). The word `await` is a contextual keyword in async methods.
- Don't use `await` in a static script variable initializer (**CS8100**). The `await` operator requires an async context, which isn't available in static initializers.
- Ensure instances of `ref struct` types don't need to be preserved across `await` or `yield` boundaries (**CS4007**). The async state machine can't safely preserve reference types that are stack-bound.
- Change the return type to `Task` for methods that don't return a value, or `Task<T>` for methods that return a value.

## Async method signature requirements

- **CS1983**: *Since this is an async method, the return expression must be of type '`Task<T>`' rather than '`T`'.*
- **CS1994**: *The '`async`' modifier can only be used in methods that have a body.*
- **CS4009**: *A void or int returning entry point cannot be async.*
- **CS8892**: *Method will not be used as an entry point because a synchronous entry point was found.*
- **CS8935**: *The AsyncMethodBuilder attribute is disallowed on anonymous methods without an explicit return type.*
- **CS8940**: *A generic task-like return type was expected, but the type '{0}' found in 'AsyncMethodBuilder' attribute was not suitable. It must be an unbound generic type of arity one, and its containing type (if any) must be non-generic.*
- **CS8403**: *Method '{0}' with an iterator block must be '`async`' to return '{1}'.*
- **CS9330**: *'`MethodImplAttribute.Async`' cannot be manually applied to methods. Mark the method '`async`'.*
- **CS4005**: *Async methods cannot have pointer type parameters.*
- **CS4006**: *\_\_arglist is not allowed in the parameter list of async methods.*
- **CS4010**: *Cannot convert async {0} to delegate type '{1}'. An async {0} may return void, Task or Task\<T\>, none of which are convertible to '{1}'.*
- **CS4012**: *Parameters of type '{0}' cannot be declared in async methods or async lambda expressions.*
- **CS4015**: *'MethodImplOptions.Synchronized' cannot be applied to an async method.*
- **CS4016**: *Since this is an async method, the return expression must be of type '{0}' rather than '{1}'.*
- **CS8031**: *Async lambda expression converted to a '{0}' returning delegate cannot return a value.*
- **CS8204**: *For type '{0}' to be used as an AsyncMethodBuilder for type '{1}', its Task property should return type '{1}' instead of type '{2}'.*

To declare async methods correctly, follow these signature requirements. For more information, see [Async main return values](../../fundamentals/program-structure/main-command-line.md#async-main-return-values).

- Return one of the valid types: `void`, <xref:System.Threading.Tasks.Task>, `Task<T>`, a task-like type, <xref:System.Collections.Generic.IAsyncEnumerable%601>, or <xref:System.Collections.Generic.IAsyncEnumerator%601> (**CS1983**).
- Use the `async` modifier only on methods with a body (**CS1994**). Remove the `async` modifier on abstract methods in interfaces or classes.
- Update to C# 7.1 or higher to use `async` on the `Main` entry point, or avoid using `async` on entry points in earlier versions (**CS4009**).
- Remove synchronous entry points if you have both sync and async entry points (**CS8892**).
- Don't apply the `AsyncMethodBuilder` attribute to anonymous methods (lambdas) that don't have an explicit return type (**CS8935**). The compiler needs to know the return type to resolve the builder type. Provide an explicit return type on the lambda, or remove the attribute.
- Ensure the type specified in the `AsyncMethodBuilder` attribute is an unbound generic type of arity one when a generic task-like return type is expected (**CS8940**). The builder type must match the expected pattern (for example, `MyTaskMethodBuilder<>` rather than `MyTaskMethodBuilder<T>` or a non-generic type), and its containing type, if any, must be non-generic.
- Use the `async` keyword instead of manually applying `MethodImplAttribute.Async` (**CS9330**).
- Add the `async` modifier to methods with iterator blocks that return <xref:System.Collections.Generic.IAsyncEnumerable%601> or <xref:System.Collections.Generic.IAsyncEnumerator%601> (**CS8403**). Async iterators require the `async` modifier to use `await` in the iterator body and to return an async stream type.
- Don't use pointer types as parameters in async methods (**CS4005**). Pointers reference fixed memory locations that can't be safely preserved across async suspension points.
- Don't use `__arglist` in async method parameter lists (**CS4006**). Variable argument lists aren't compatible with the async state machine.
- Don't use `ref`, `in`, or `out` parameters, or parameters of `ref struct` types like <xref:System.Span%601> or <xref:System.ReadOnlySpan%601>, in async methods or async lambda expressions (**CS4012**). These parameter types can't be safely captured in the async state machine.
- Return the correct type from the async method's return expression (**CS4016**). When an async method returns `Task<T>`, the return expression must be of type `T`, not `Task<T>`. The async infrastructure wraps the value automatically.
- Ensure the return type of an async lambda is convertible to the target delegate type (**CS4010**). An async lambda can return `void`, `Task`, or `Task<T>`. If the target delegate expects a different return type, the conversion fails.
- Don't return a value from an async lambda that's converted to a `Task`-returning (non-generic) delegate (**CS8031**). Use `Task<T>` as the return type if the lambda needs to return a value.
- Don't apply `MethodImplOptions.Synchronized` to async methods (**CS4015**). Synchronized methods acquire a lock for the duration of the method call, which is incompatible with async suspension.
- Ensure the custom `AsyncMethodBuilder` type's `Task` property returns the correct type (**CS8204**). The builder's `Task` property must return the same type as the async method's declared return type.

## Async practices

- **CS1989**: *Async lambda expressions cannot be converted to expression trees.*
- **CS1991**: *'Type' cannot implement 'event' because it is a Windows Runtime event and 'event' is a regular .NET event.*
- **CS1997**: *Since function is an async method that returns a value, a return keyword must not be followed by an object expression.*
- **CS1998**: *This async method lacks '`await`' operators and will run synchronously. Consider using the '`await`' operator to await non-blocking API calls, or '`await Task.Run(...)`' to do CPU-bound work on a background thread.*
- **CS4014**: *Because this call is not awaited, execution of the current method continues before the call is completed. Consider applying the `await` operator to the result of the call.*
- **CS8177**: *Async methods cannot have by-reference locals.*
- **CS9123**: *The '`&`' operator should not be used on parameters or local variables in async methods.*
- **CS4029**: *Cannot return an expression of type 'void'.*
- **CS4030**: *Security attribute '{0}' cannot be applied to an Async method.*
- **CS4031**: *Async methods are not allowed in an Interface, Class, or Structure which has the 'SecurityCritical' or 'SecuritySafeCritical' attribute.*

To write async code correctly and avoid common pitfalls, follow these best practices. For more information, see [Asynchronous programming with async and await](../../asynchronous-programming/index.md).

- Always [await](../operators/await.md) calls to async methods that return <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601> (**CS4014**). Unawaited calls can lead to lost exceptions and unexpected behavior.
- Don't return a value from async methods that return `Task` (non-generic); use `Task<T>` instead (**CS1997**).
- Include at least one `await` operator in async methods, or remove the `async` modifier (**CS1998**).
- Remove the `return` statement if the method should return `Task` (**CS1997**, **CS1998**).
- Change the method's return type to `Task<T>` to return a value (**CS1997**, **CS1998**).
- Remove the `async` modifier and return the task directly if you don't need the async state machine (**CS1997**, **CS1998**).
- Don't use async methods in expression trees (**CS1989**). Expression trees represent code as data and don't support the complex state machine transformations required by async methods.
- Don't mark add or remove accessors in an interface or WinRT event as async (**CS1991**). This is a platform-specific restriction for Windows Runtime interoperability.
- Avoid using the address-of operator (`&`) on expressions inside async methods (**CS9123**). The target may be relocated in memory during suspension, making the pointer invalid.
- Don't use by-reference locals in async methods (**CS8177**). The async state machine captures local variables in heap-allocated closures, and references to stack locations can't be safely preserved across suspension points. In C# 13 and later, `ref` locals are allowed in async methods when they don't span an `await` boundary, and this error is no longer produced.
- Don't return an expression of type `void` from an async method (**CS4029**). This error occurs when you try to return the result of a `void`-returning method call. If you don't need to return a value, remove the `return` statement or change the called method's return type.
- Don't apply security attributes like `SecurityCritical` or `SecuritySafeCritical` to async methods (**CS4030**), and don't declare async methods in types marked with these attributes (**CS4031**). The async state machine transformation is incompatible with code access security annotations.
