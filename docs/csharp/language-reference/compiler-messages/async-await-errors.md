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

- [**CS1983**](#async-method-signature-requirements): *Since this is an async method, the return expression must be of type '`T`' rather than '`Task<T>`'.*
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
- [**CS4001**](#await-expression-requirements): *Cannot await expression.*
- [**CS4003**](#await-expression-requirements): *'`await`' cannot be used as an identifier within an async method or lambda expression.*
- [**CS4005**](#async-method-signature-requirements): *Async methods cannot have pointer type parameters.*
- [**CS4006**](#async-method-signature-requirements): *\_\_arglist is not allowed in the parameter list of async methods.*
- [**CS4007**](#await-expression-requirements): *Instance of type cannot be preserved across '`await`' or '`yield`' boundary.*
- [**CS4008**](#await-expression-requirements): *Cannot await '`void`'.*
- [**CS4009**](#async-method-signature-requirements): *A void or int returning entry point cannot be async.*
- [**CS4010**](#async-method-signature-requirements): *Cannot convert async expression to delegate type. An async expression may return void, Task or Task\<T\>, none of which are convertible to type.*
- [**CS4011**](#await-expression-requirements): *'`await`' requires that the return type of '{1}.GetAwaiter()' have suitable 'IsCompleted', 'OnCompleted', and 'GetResult' members, and implement 'INotifyCompletion' or 'ICriticalNotifyCompletion'.*
- [**CS4012**](#async-method-signature-requirements): *Parameters of type cannot be declared in async methods or async lambda expressions.*
- [**CS4014**](#async-practices): *Because this call is not awaited, execution of the current method continues before the call is completed. Consider applying the `await` operator to the result of the call.*
- [**CS4015**](#async-method-signature-requirements): *'MethodImplOptions.Synchronized' cannot be applied to an async method.*
- [**CS4016**](#async-method-signature-requirements): *Since this is an async method, the return expression must be of type task like type rather than declared type.*
- [**CS4027**](#await-expression-requirements): *Expression type does not implement required member.*
- [**CS4028**](#await-expression-requirements): *'`await`' requires that the type have a suitable 'GetAwaiter' method. Are you missing a using directive for 'System'?*
- [**CS4029**](#async-practices): *Cannot return an expression of type 'void'.*
- [**CS4030**](#async-practices): *Security attribute cannot be applied to an Async method.*
- [**CS4031**](#async-practices): *Async methods are not allowed in an Interface, Class, or Structure which has the 'SecurityCritical' or 'SecuritySafeCritical' attribute.*
- [**CS4032**](#await-expression-requirements): *The '`await`' operator can only be used within an async method. Consider marking this method with the 'async' modifier and changing its return type to '`Task<T>`'.*
- [**CS4033**](#await-expression-requirements): *The '`await`' operator can only be used within an async method. Consider marking this method with the '`async`' modifier and changing its return type to '`Task`'.*
- [**CS4034**](#await-expression-requirements): *The '`await`' operator can only be used within an async method. Consider marking this method with the 'async' modifier.*
- [**CS8031**](#async-method-signature-requirements): *Async lambda expression converted to a task returning delegate cannot return a value.*
- [**CS8100**](#await-expression-requirements): *The '`await`' operator cannot be used in a static script variable initializer.*
- [**CS8177**](#async-practices): *Async methods cannot have by-reference locals.*
- [**CS8178**](#await-expression-requirements): *A reference returned by a call to method cannot be preserved across '`await`' or '`yield`' boundary.*
- [**CS8204**](#async-method-signature-requirements): *For type to be used as an AsyncMethodBuilder for type target, its Task property should return target type instead of declared type.*
- [**CS8403**](#async-method-signature-requirements): *Method with an iterator block must be '`async`' to return IAsyncEnumerable\<T\>.*
- [**CS8411**](#await-expression-requirements): *Asynchronous foreach statement cannot operate on variables of type because type does not contain a suitable public instance or extension definition for required member.*
- [**CS8892**](#async-method-signature-requirements): *Method will not be used as an entry point because a synchronous entry point was found.*
- [**CS8935**](#async-method-signature-requirements): *The AsyncMethodBuilder attribute is disallowed on anonymous methods without an explicit return type.*
- [**CS8940**](#async-method-signature-requirements): *A generic task-like return type was expected, but the type found in 'AsyncMethodBuilder' attribute was not suitable. It must be an unbound generic type of arity one, and its containing type (if any) must be non-generic.*
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
- **CS4034**: *The '`await`' operator can only be used within an async method. Consider marking this method with the 'async' modifier.*
- **CS8178**: *A reference returned by this call cannot be preserved across '`await`' or '`yield`' boundary.*
- **CS8411**: *Asynchronous foreach statement cannot operate on variables of type because type does not contain a suitable public instance or extension definition for required member.*
- **CS4001**: *Cannot await expression.*
- **CS4003**: *'`await`' cannot be used as an identifier within an async method or lambda expression.*
- **CS4007**: *Instance of type cannot be preserved across '`await`' or '`yield`' boundary.*
- **CS4011**: *'`await`' requires that the return type of 'GetAwaiter()' have suitable 'IsCompleted', 'OnCompleted', and 'GetResult' members, and implement 'INotifyCompletion' or 'ICriticalNotifyCompletion'.*
- **CS4027**: *Type does not implement required member.*
- **CS4028**: *'`await`' requires that the type have a suitable 'GetAwaiter' method. Are you missing a using directive for 'System'?*
- **CS8100**: *The '`await`' operator cannot be used in a static script variable initializer.*

The following items explain how to correct each error. For more information about the [`await` operator](../operators/await.md) and the awaiter pattern, see [Asynchronous programming with async and await](../../asynchronous-programming/index.md).

- Add the [`async`](../keywords/async.md) modifier to the method or lambda expression that contains the [`await`](../operators/await.md) expression (**CS1992**, **CS4032**, **CS4033**, **CS4034**). The compiler requires the `async` modifier so it can generate the state machine that handles asynchronous suspension and resumption. The three variants of this error provide context-specific suggestions for the correct return type.
- Move `await` expressions out of [`catch`](../statements/exception-handling-statements.md#the-try-catch-statement) blocks when you target C# 5 or earlier (**CS1985**). Starting with C# 6, the compiler supports `await` in both `catch` and `finally` blocks. This error is no longer produced in C# 6 and later.
- Move `await` expressions out of [`lock` statement](../statements/lock.md) blocks (**CS1996**). Async suspension while holding a lock risks deadlocks. The lock is held across thread switches where other code might be waiting for the same lock.
- Restructure [query expressions](../keywords/query-keywords.md) so that `await` appears only in the first collection expression of the initial `from` clause or in the collection expression of a `join` clause (**CS1995**). Other query clauses translate into lambda expressions that don't support async suspension.
- Change the awaited expression's type so that it exposes an accessible `GetAwaiter()` method that follows the [awaiter pattern](../operators/await.md) (**CS1986**, **CS4028**). The type can implement the pattern directly or through an extension method. If the `GetAwaiter` method exists but you're missing a `using` directive for `System`, the compiler produces the more specific **CS4028** message instead of **CS1986**.
- Ensure the awaiter type returned by `GetAwaiter()` has `IsCompleted`, `OnCompleted`, and `GetResult` members and implements <xref:System.Runtime.CompilerServices.INotifyCompletion> or <xref:System.Runtime.CompilerServices.ICriticalNotifyCompletion> (**CS4011**, **CS4027**). The [`await` expression](../operators/await.md) depends on these members to check completion status, register continuations, and retrieve results.
- Change the called method's return type from `void` to <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task`1> so the result can be awaited (**CS4008**). You can't await a `void`-returning method because there's no task object to track completion or propagate exceptions.
- Change the awaited expression to a type that supports the [awaiter pattern](../operators/await.md) (**CS4001**). Types like `int`, `string`, and other built-in types don't have a `GetAwaiter` method and can't be awaited directly.
- Store the result of a [ref-returning](../statements/jump-statements.md#ref-returns) method call in a local variable before using `await` (**CS8178**). A reference returned by a method can't be preserved across an `await` boundary because the async state machine might suspend and resume on a different thread or context, invalidating the reference.
- Implement <xref:System.Collections.Generic.IAsyncEnumerable`1> on the collection type, or add an accessible `GetAsyncEnumerator` method that returns a type with `Current` and `MoveNextAsync` members (**CS8411**). The [`await foreach` statement](../statements/iteration-statements.md#await-foreach) requires the collection type to follow the async enumerable pattern.
- Rename any local variable or parameter named `await` inside an [`async`](../keywords/async.md) method or lambda expression (**CS4003**). Inside async contexts, `await` is a contextual keyword and can't be used as an identifier.
- Move the `await` expression out of the static script variable initializer and into a method body (**CS8100**). Static initializers run outside an async context, so `await` isn't available in that location.
- Restructure code so that [`ref struct`](../builtin-types/ref-struct.md) instances don't need to be preserved across an `await` or `yield` boundary (**CS4007**). The async state machine stores local variables on the heap, and `ref struct` types are stack-bound by design - they can't be safely moved to heap storage across suspension points.

## Async method signature requirements

- **CS1983**: *Since this is an async method, the return expression must be of type 'T' rather than '`Task<T>`'.*
- **CS1994**: *The '`async`' modifier can only be used in methods that have a body.*
- **CS4009**: *A void or int returning entry point cannot be async.*
- **CS8892**: *Method will not be used as an entry point because a synchronous entry point was found.*
- **CS8935**: *The AsyncMethodBuilder attribute is disallowed on anonymous methods without an explicit return type.*
- **CS8940**: *A generic task-like return type was expected, but the type found in 'AsyncMethodBuilder' attribute was not suitable. It must be an unbound generic type of arity one, and its containing type (if any) must be non-generic.*
- **CS8403**: *Method with an iterator block must be '`async`' to return '{1}'.*
- **CS9330**: *'`MethodImplAttribute.Async`' cannot be manually applied to methods. Mark the method '`async`'.*
- **CS4005**: *Async methods cannot have pointer type parameters.*
- **CS4006**: *\_\_arglist is not allowed in the parameter list of async methods.*
- **CS4010**: *Cannot convert async lambda to delegate type . An async lambda may return void, Task or Task\<T\>, none of which are convertible to return type.*
- **CS4012**: *Parameters of type cannot be declared in async methods or async lambda expressions.*
- **CS4015**: *'MethodImplOptions.Synchronized' cannot be applied to an async method.*
- **CS4016**: *Since this is an async method, the return expression must be of task type rather than type.*
- **CS8031**: *Async lambda expression converted to a task returning delegate cannot return a value.*
- **CS8204**: *For type to be used as an AsyncMethodBuilder for type, its Task property should return required type instead of declared type.*

The following items explain how to correct each error. For more information about async method declarations, see the [`async`](../keywords/async.md) modifier and [Async return types](../../asynchronous-programming/async-return-types.md).

- Change the return expression to match the async method's underlying result type (**CS1983**, **CS4016**). When an async method returns `Task<T>`, the `return` statement must supply a value of type `T`, not `Task<T>`, because the compiler-generated [state machine](../../asynchronous-programming/task-asynchronous-programming-model.md) wraps the value in a task automatically. **CS1983** appears when the method returns `Task<T>` and the expression is `T`; **CS4016** covers the general case where the return expression type doesn't match.
- Remove the [`async`](../keywords/async.md) modifier from methods that don't have a body, such as abstract methods or interface method declarations (**CS1994**). The `async` modifier requires a method body so the compiler can generate the state machine implementation.
- Change an async entry point's return type to <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task`1> (**CS4009**). Starting with C# 7.1, the [`Main` method](../../fundamentals/program-structure/main-command-line.md#main-return-values) can be `async`, but it must return `Task` or `Task<int>` - `async void` and `async int` aren't valid entry point signatures.
- Remove or rename one entry point when the project contains both a synchronous and an asynchronous `Main` method (**CS8892**). The compiler selects the synchronous entry point and issues this warning for the async candidate that it ignores.
- Add an explicit return type to the lambda expression before applying the [`[AsyncMethodBuilder]`](xref:System.Runtime.CompilerServices.AsyncMethodBuilderAttribute) attribute (**CS8935**). The compiler can't resolve the builder type for an anonymous method whose return type is inferred, because the attribute must be matched to a specific return type at compile time.
- Change the type specified in the [`[AsyncMethodBuilder]`](xref:System.Runtime.CompilerServices.AsyncMethodBuilderAttribute) attribute to an unbound generic type of arity one, such as `MyTaskMethodBuilder<>` rather than `MyTaskMethodBuilder<T>` or a non-generic type (**CS8940**). The builder's containing type, if any, must also be non-generic. The compiler requires this shape so it can construct the builder for any concrete task-like return type.
- Replace the manual `[MethodImpl(MethodImplOptions.Async)]` attribute with the [`async`](../keywords/async.md) keyword on the method declaration (**CS9330**). The `MethodImplOptions.Async` flag is reserved for internal runtime use and can't be applied directly in user code.
- Add the [`async`](../keywords/async.md) modifier to methods that contain [iterator blocks](../statements/yield.md) and return <xref:System.Collections.Generic.IAsyncEnumerable`1> or <xref:System.Collections.Generic.IAsyncEnumerator`1> (**CS8403**). Without the `async` modifier, the compiler treats the method as a synchronous iterator and can't generate the async stream state machine.
- Remove pointer-type parameters from async methods (**CS4005**). Pointers reference fixed memory locations that can't be safely preserved across async suspension points where execution might resume on a different thread.
- Remove `__arglist` from async method parameter lists (**CS4006**). Variable-length argument lists depend on stack-based calling conventions that are incompatible with the heap-allocated [async state machine](../../asynchronous-programming/task-asynchronous-programming-model.md).
- Remove `ref`, `in`, or `out` parameters, and parameters of [`ref struct`](../builtin-types/ref-struct.md) types like <xref:System.Span`1> or <xref:System.ReadOnlySpan`1>, from async methods or async lambda expressions (**CS4012**). These parameter types are stack-bound and can't be safely captured in the heap-allocated async state machine closure.
- Change the target delegate type to match the async lambda's return type (**CS4010**). An async lambda can return `void`, <xref:System.Threading.Tasks.Task>, or <xref:System.Threading.Tasks.Task`1>, and the compiler can't convert these to arbitrary delegate types that expect different return types.
- Remove the `return` expression from an async lambda that's assigned to a non-generic `Task`-returning delegate, or change the delegate type to `Func<Task<T>>` so the lambda can return a value (**CS8031**). A non-generic `Task`-returning delegate represents an async operation with no result, so returning a value is a type mismatch.
- Remove the `[MethodImpl(MethodImplOptions.Synchronized)]` attribute from async methods (**CS4015**). The `Synchronized` option acquires a lock for the entire method execution, but an async method suspends and resumes potentially on different threads, making the lock semantics undefined.
- Correct the custom [`AsyncMethodBuilder`](xref:System.Runtime.CompilerServices.AsyncMethodBuilderAttribute) type so its `Task` property returns the same type as the async method's declared return type (**CS8204**). The compiler uses the builder's `Task` property to obtain the final task object, so a type mismatch prevents the state machine from functioning correctly.

## Async practices

- **CS1989**: *Async lambda expressions cannot be converted to expression trees.*
- **CS1991**: *'Type' cannot implement 'event' because it is a Windows Runtime event and 'event' is a regular .NET event.*
- **CS1997**: *Since function is an async method that returns a value, a return keyword must not be followed by an object expression.*
- **CS1998**: *This async method lacks '`await`' operators and will run synchronously. Consider using the '`await`' operator to await non-blocking API calls, or '`await Task.Run(...)`' to do CPU-bound work on a background thread.*
- **CS4014**: *Because this call is not awaited, execution of the current method continues before the call is completed. Consider applying the `await` operator to the result of the call.*
- **CS8177**: *Async methods cannot have by-reference locals.*
- **CS9123**: *The '`&`' operator should not be used on parameters or local variables in async methods.*
- **CS4029**: *Cannot return an expression of type 'void'.*
- **CS4030**: *Security attribute cannot be applied to an Async method.*
- **CS4031**: *Async methods are not allowed in an Interface, Class, or Structure which has the 'SecurityCritical' or 'SecuritySafeCritical' attribute.*

The following items explain how to correct each error. For more information, see [Asynchronous programming with async and await](../../asynchronous-programming/index.md) and the [`await` operator](../operators/await.md).

- Add the [`await`](../operators/await.md) operator to every call that returns <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task`1>, or explicitly discard the result with `_ =` if fire-and-forget behavior is truly intended (**CS4014**). Without `await`, any exception thrown by the asynchronous operation is silently lost, and the calling method continues executing before the operation finishes, which can cause subtle ordering and correctness bugs.
- Remove the `return` expression from an async method whose return type is `Task` (non-generic), or change the return type to `Task<T>` when the method needs to return a value (**CS1997**). In an async method that returns `Task`, the compiler generates the task wrapper - returning a value is a type mismatch because the method signature promises no result.
- Add at least one [`await`](../operators/await.md) expression to the method body, or remove the [`async`](../keywords/async.md) modifier and return the task directly (**CS1998**). An `async` method without any `await` expressions runs entirely synchronously, which adds unnecessary state machine overhead. If the method intentionally wraps a synchronous operation, removing `async` and returning the task explicitly eliminates that overhead.
- Rewrite the lambda expression so it doesn't use `async` when it's assigned to an [expression tree](../../advanced-topics/expression-trees/expression-trees-explained.md) type like `Expression<Func<...>>` (**CS1989**). Expression trees represent code as data structures that the compiler can analyze or translate, but the complex state machine that `async` produces can't be captured in an expression tree.
- Change the event implementation so both the interface declaration and the implementing class agree on whether the event uses Windows Runtime semantics or regular .NET semantics (**CS1991**). This error applies to Windows Runtime interop scenarios where a WinRT event can't be implemented as a regular .NET event or vice versa.
- Remove the [address-of operator](../operators/pointer-related-operators.md#address-of-operator-) (`&`) from expressions that reference parameters or local variables inside async methods (**CS9123**). The async state machine might relocate captured variables to the heap during suspension, which would invalidate any pointer obtained through address-of.
- Remove by-reference local variables from async methods, or ensure they don't span an `await` boundary (**CS8177**). The async state machine captures local variables in heap-allocated closures, and references to stack locations can't be safely preserved across suspension points. In C# 13 and later, `ref` locals are allowed in async methods as long as they don't span an `await` boundary, and this error isn't produced.
- Remove the `return` statement that returns the result of a `void`-returning method, or change the called method to return a value (**CS4029**). You can't use `return SomeVoidMethod();` because `void` isn't a type that can be returned as a value. Either remove the `return` keyword and call the method as a standalone statement, or change the called method's signature to return a concrete type.
- Remove security attributes like `[SecurityCritical]` or `[SecuritySafeCritical]` from async methods (**CS4030**), or remove the [`async`](../keywords/async.md) modifier from methods in types marked with these attributes (**CS4031**). The code access security annotations apply to the declaring method, but the compiler-generated async state machine runs in a separate context where those security annotations can't be enforced.
