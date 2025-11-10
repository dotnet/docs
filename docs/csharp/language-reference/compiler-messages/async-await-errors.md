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
- [**CS1983**](#async-method-signature-requirements): *The return type of an async method must be void, Task, Task\<T\>, a task-like type (A task-like type is one that adheres to the pattern, [described here](~/_csharpstandard/standard/classes.md#15151-general), required by the C# specification), IAsyncEnumerable\<T\>, or IAsyncEnumerator\<T\>*
- [**CS1985**](#restrictions-on-await-usage-and-awaitable-requirements): *Cannot await in a catch clause*
- [**CS1986**](#restrictions-on-await-usage-and-awaitable-requirements): *'await' requires that the type have a suitable 'GetAwaiter' method*
- [**CS1989**](#async-best-practices-and-special-cases): *Async methods cannot be used in expression trees*
- [**CS1991**](#async-best-practices-and-special-cases): *Cannot have an add or remove accessor in an interface or a WinRT event*
- [**CS1992**](#restrictions-on-await-usage-and-awaitable-requirements): *The 'await' operator can only be used when contained within a method or lambda expression marked with the 'async' modifier*
- [**CS1994**](#async-method-signature-requirements): *The 'async' modifier can only be used in methods that have a body.*
- [**CS1995**](#restrictions-on-await-usage-and-awaitable-requirements): *The 'await' operator may only be used in a query expression within the first collection expression of the initial 'from' clause or within the collection expression of a 'join' clause*
- [**CS1996**](#restrictions-on-await-usage-and-awaitable-requirements): *Cannot await in the body of a lock statement*
- [**CS1997**](#async-best-practices-and-special-cases): *Since `method` is an async method that returns `Task`, a return keyword must not be followed by an object expression. Did you intend to return `Task<T>`?*
- [**CS1998**](#async-best-practices-and-special-cases): *This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.*
- [**CS4008**](#restrictions-on-await-usage-and-awaitable-requirements): *Cannot await 'void'*
- [**CS4009**](#async-method-signature-requirements): *'Type.Method': an entry point cannot be marked with the `async` modifier.*
- [**CS4014**](#async-best-practices-and-special-cases): *Because this call is not awaited, execution of the current method continues before the call is completed. Consider applying the `await` operator to the result of the call.*
- [**CS4032**](#restrictions-on-await-usage-and-awaitable-requirements): *The 'await' operator can only be used within an async method. Consider marking this method with the 'async' modifier and changing its return type to 'Task\<T\>'.*
- [**CS4033**](#restrictions-on-await-usage-and-awaitable-requirements): *The 'await' operator can only be used within an async method. Consider marking this method with the 'async' modifier and changing its return type to 'Task'.*
- [**CS8892**](#async-method-signature-requirements): *Method 'method' will not be used as an entry point because a synchronous entry point 'method' was found.*
- [**CS9123**](#async-best-practices-and-special-cases): *Using the address-of operator on certain expressions inside an async method may not work as expected, as the target may be moved between the point where the address-of is performed and the point where it is referenced.*
- [**CS9330**](#async-method-signature-requirements): *'`MethodImplAttribute.Async`' cannot be manually applied to methods. Mark the method '`async`'.*

## Restrictions on await usage and awaitable requirements

The `await` operator has restrictions on where it can be used and what types can be awaited. The following errors indicate violations of these restrictions:

- **CS1985**: *Cannot await in a catch clause*
- **CS1986**: *'await' requires that the type have a suitable 'GetAwaiter' method*
- **CS1992**: *The 'await' operator can only be used when contained within a method or lambda expression marked with the 'async' modifier*
- **CS1995**: *The 'await' operator may only be used in a query expression within the first collection expression of the initial 'from' clause or within the collection expression of a 'join' clause*
- **CS1996**: *Cannot await in the body of a lock statement*
- **CS4008**: *Cannot await 'void'*
- **CS4032**: *The 'await' operator can only be used within an async method. Consider marking this method with the 'async' modifier and changing its return type to 'Task\<T\>'.*
- **CS4033**: *The 'await' operator can only be used within an async method. Consider marking this method with the 'async' modifier and changing its return type to 'Task'.*

### Restrictions on await location

You can't use the `await` operator in certain contexts where the compiler can't guarantee correct behavior.

**Cannot await in a catch clause (CS1985)**: The `await` operator isn't allowed in catch blocks. While you can use `await` in try blocks and finally blocks (in C# 6 and later), catch blocks present special challenges with exception handling and control flow that make awaiting operations problematic.

**Cannot await in lock statements (CS1996)**: Asynchronous code within a [`lock` statement](../statements/lock.md) block is hard to implement reliably. The C# compiler doesn't support this to avoid emitting code prone to deadlocks. The following example generates CS1996:

```csharp
public class C
{
    private readonly Dictionary<string, string> keyValuePairs = new();

    public async Task<string> ReplaceValueAsync(string key, HttpClient httpClient)
    {
        lock (keyValuePairs)
        {
            // CS1996: Cannot await in the body of a lock statement
            var newValue = await httpClient.GetStringAsync(string.Empty);
            if (keyValuePairs.ContainsKey(key)) keyValuePairs[key] = newValue;
            else keyValuePairs.Add(key, newValue);
            return newValue;
        }
    }
}
```

Extract the asynchronous code from the `lock` statement block to correct this error:

```csharp
public class C
{
    private readonly Dictionary<string, string> keyValuePairs = new();

    public async Task<string> ReplaceValueAsync(string key, HttpClient httpClient)
    {
        var newValue = await httpClient.GetStringAsync(string.Empty);
        lock (keyValuePairs)
        {
            if (keyValuePairs.ContainsKey(key)) keyValuePairs[key] = newValue;
            else keyValuePairs.Add(key, newValue);
            return newValue;
        }
    }
}
```

**Cannot await in query expressions (CS1995)**: The `await` operator can only be used in specific locations within [query expressions](../keywords/query-keywords.md): within the first collection expression of the initial `from` clause, or within the collection expression of a `join` clause. This restriction ensures that async operations integrate correctly with LINQ query processing.

### Awaitable type requirements

For a type to be awaitable with the `await` operator, it must implement the awaitable pattern.

**Missing GetAwaiter method (CS1986)**: A type must have an accessible `GetAwaiter` method that returns an awaiter type. The following example generates CS1986:

```csharp
using System.Runtime.CompilerServices;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task M(MyTask<int> x)
    {
        // CS1986: 'await' requires that the type 'MyTask<int>' have a suitable 'GetAwaiter' method
        var z = await x;
        System.Console.WriteLine(z);
    }
}

public class MyTask<TResult>
{
    readonly MyTaskAwaiter<TResult> awaiter;
    public MyTask(TResult value)
    {
        this.awaiter = new MyTaskAwaiter<TResult>(value);
    }
    // Error: GetAwaiter is static when it should be an instance method
    public static MyTaskAwaiter<TResult> GetAwaiter() => throw new NotImplementedException();
}

public class MyTaskAwaiter<TResult> : INotifyCompletion
{
    TResult value;
    public MyTaskAwaiter(TResult value)
    {
        this.value = value;
    }
    public bool IsCompleted { get => true; }
    public TResult GetResult() => value;
    public void OnCompleted(Action continuation) => throw new NotImplementedException();
}
```

The `GetAwaiter` method must be a non-static instance method that returns a type implementing <xref:System.Runtime.CompilerServices.INotifyCompletion> (and optionally <xref:System.Runtime.CompilerServices.ICriticalNotifyCompletion>). The awaiter type must expose:

- A `bool IsCompleted { get; }` property
- A `void OnCompleted(Action continuation)` method
- A `GetResult()` method (which can return `void` or a value)

To correct this error, make `GetAwaiter` an instance method:

```csharp
public class MyTask<TResult>
{
    readonly MyTaskAwaiter<TResult> awaiter;
    public MyTask(TResult value)
    {
        this.awaiter = new MyTaskAwaiter<TResult>(value);
    }
    public MyTaskAwaiter<TResult> GetAwaiter() => awaiter;
}
```

For more information on implementing custom awaitable types, see [await anything](https://devblogs.microsoft.com/pfxteam/await-anything/).

**Cannot await void (CS4008)**: You can't apply the `await` operator to expressions of type `void`. The following example generates CS4008:

```csharp
using System.Threading.Tasks;

class Test
{
    public async void goo()
    {
        await Task.Factory.StartNew(() => { });
    }

    public async void bar()
    {
        // CS4008: Cannot await 'void'
        await goo();
    }

    public static void Main() { }
}
```

If a method doesn't need to return a value and doesn't require `await` internally, consider returning a <xref:System.Threading.Tasks.Task> instead:

```csharp
public Task goo()
{
    return Task.Factory.StartNew(() => { });
}
```

This avoids creating an unnecessary async state machine. For more information on async method return types, see [Asynchronous programming with async and await](../../asynchronous-programming/index.md).

### Using await without async context

The `await` operator requires the containing method or lambda to be marked with the `async` modifier. Without this modifier, the compiler can't generate the necessary state machine for asynchronous execution.

**Using await in non-async methods (CS1992, CS4032, CS4033)**: When you use `await` in a method or lambda expression, that method must be declared with the `async` modifier. The compiler error messages CS4032 and CS4033 provide specific guidance on the return type your async method should use.

CS4032 occurs when you use `await` in a method that should return `Task<T>`:

```csharp
using System.Collections.Generic;
using System.Threading.Tasks;

class C
{
    static IAsyncEnumerator<int> M(int value)
    {
        yield return value;
        // CS4032: The 'await' operator can only be used within an async method.
        // Consider marking this method with the 'async' modifier and changing its return type to 'Task<T>'.
        await Task.CompletedTask;
    }
}
```

To correct this error, add the `async` modifier to the method signature:

```csharp
using System.Collections.Generic;
using System.Threading.Tasks;

class C
{
    static async IAsyncEnumerator<int> M(int value)
    {
        yield return value;
        await Task.CompletedTask;
    }
}
```

CS4033 occurs when you use `await` in a method that should return `Task`:

```csharp
using System.Collections.Generic;

class C
{
    void M(IAsyncEnumerable<int> collection)
    {
        // CS4033: The 'await' operator can only be used within an async method.
        // Consider marking this method with the 'async' modifier and changing its return type to 'Task'.
        await foreach (var i in collection)
        {
        }
    }
}
```

To correct this error, add the `async` modifier to the method signature:

```csharp
using System.Collections.Generic;

class C
{
    async void M(IAsyncEnumerable<int> collection)
    {
        await foreach (var i in collection)
        {
        }
    }
}
```

CS1992 is a more general version of this error that applies to methods and lambda expressions. The `await` operator can only appear within an async context - either an `async` method or an `async` lambda expression. Always ensure your method or lambda is marked with the `async` modifier before using `await`.

## Async method signature requirements

Async methods have specific requirements for their signatures, including return types, method bodies, and entry point restrictions. The following errors indicate violations of these requirements:

- **CS1983**: *The return type of an async method must be void, Task, Task\<T\>, a task-like type, IAsyncEnumerable\<T\>, or IAsyncEnumerator\<T\>*
- **CS1994**: *The 'async' modifier can only be used in methods that have a body.*
- **CS4009**: *'Type.Method': an entry point cannot be marked with the `async` modifier.*
- **CS8892**: *Method 'method' will not be used as an entry point because a synchronous entry point 'method' was found.*
- **CS9330**: *'`MethodImplAttribute.Async`' cannot be manually applied to methods. Mark the method '`async`'.*

### Valid return types for async methods

**Invalid return type (CS1983)**: Async methods must return one of the following types: `void`, <xref:System.Threading.Tasks.Task>, `Task<T>`, a task-like type (a type that adheres to the awaitable pattern required by the C# specification), <xref:System.Collections.Generic.IAsyncEnumerable%601>, or <xref:System.Collections.Generic.IAsyncEnumerator%601>.

The following example generates CS1983:

```csharp
using System.Collections.Generic;

class C
{
    static async IEnumerable<int> M()
    {
        yield return await Task.FromResult(1);
    }
}
```

Since `IEnumerable.GetEnumerator` returns an `IEnumerator<T>` whose `MoveNext` method doesn't return a value of `Task<T>`, it isn't compatible with an `async` method.

Use an interface that results in the invocation of a method that returns a type of `Task<T>`, for example, `IAsyncEnumerable<T>`:

```csharp
using System.Collections.Generic;
using System.Threading.Tasks;

class C
{
    static async IAsyncEnumerable<int> M()
    {
        yield return await Task.FromResult(1);
    }
}
```

### Async methods require method bodies

**Async requires body (CS1994)**: The `async` modifier can only be used in methods that have a body. The compiler needs the method body to generate the state machine required for asynchronous execution.

The following example generates CS1994:

```csharp
interface IInterface
{
    async void F();
}
```

A non-concrete method declaration in an interface declaration has no method body. To support the `async` modifier, the compiler must generate a state machine from the method body logic. Without a method body, the compiler can't emit this state machine.

For a non-concrete method where you're deferring the implementation to a class that implements the interface, remove the `async` modifier:

```csharp
interface IInterface
{
    void F();
}
```

Alternatively, declare a concrete default method (introduced in C# 8.0) within the interface:

```csharp
interface IInterface
{
    async void F()
    {
        await Task.Run(() =>
        {
            /* do something useful*/
        });
    }
}
```

### Entry point restrictions

**Async entry point (CS4009, CS8892)**: Before C# 7.1, you couldn't use the `async` keyword in the application entry point (typically the `Main` method). Starting with C# 7.1, the `Main` method can have an `async` modifier. For more information, see [Async main return values](../../fundamentals/program-structure/main-command-line.md#async-main-return-values).

The following example generates CS4009:

```csharp
using System;
using System.Threading.Tasks;

public class Example
{
    public static async void Main()
    {
        Console.WriteLine("About to wait two seconds");
        await WaitTwoSeconds();
        Console.WriteLine("About to exit the program");
    }

    private static async Task WaitTwoSeconds()
    {
        await Task.Delay(2000);
        Console.WriteLine("Returning from an asynchronous method");
    }
}
```

To correct this error, [update the C# language version](../configure-language-version.md) used by the project to 7.1 or higher.

If you use C# 7.0 or lower, remove the `async` keyword from the signature of the application entry point. Also remove any `await` keywords you've used to await asynchronous methods in your application entry point. However, you still have to wait for the asynchronous method to complete before your entry point resumes execution. Otherwise, compilation generates compiler warning CS4014, and the application will terminate before the asynchronous operation completes.

To await a method that returns a <xref:System.Threading.Tasks.Task>, call its <xref:System.Threading.Tasks.Task.Wait%2A> method:

```csharp
using System;
using System.Threading.Tasks;

public class Example
{
    public static void Main()
    {
        Console.WriteLine("About to wait two seconds");
        WaitTwoSeconds().Wait();
        Console.WriteLine("About to exit the program");
    }

    private static async Task WaitTwoSeconds()
    {
        await Task.Delay(2000);
        Console.WriteLine("Returning from an asynchronous method");
    }
}
```

To await a method that returns a <xref:System.Threading.Tasks.Task%601>, retrieve the value of its <xref:System.Threading.Tasks.Task%601.Result> property:

```csharp
using System;
using System.Threading.Tasks;

public class Example
{
    public static void Main()
    {
        Console.WriteLine("About to calculate result");
        int result = CalculateAsync().Result;
        Console.WriteLine($"Result: {result}");
    }

    private static async Task<int> CalculateAsync()
    {
        await Task.Delay(1000);
        return 42;
    }
}
```

CS8892 occurs when you have both synchronous and asynchronous entry points in your application. The compiler will use the synchronous entry point and ignore the async one. To correct this, either remove the synchronous entry point or update your C# language version to use the async entry point.

### Use async keyword instead of attributes

**Use keywords (CS9330)**: The implementation of `async` and `await` adds attributes to the method signature. You should use the `async` keyword instead of manually applying the `MethodImplAttribute.Async` attribute.

## Async best practices and special cases

Several compiler warnings and errors help you write better async code and handle special scenarios. The following errors and warnings indicate potential issues or unsupported scenarios:

- **CS1989**: *Async methods cannot be used in expression trees*
- **CS1991**: *Cannot have an add or remove accessor in an interface or a WinRT event*
- **CS1997**: *Since `method` is an async method that returns `Task`, a return keyword must not be followed by an object expression. Did you intend to return `Task<T>`?*
- **CS1998**: *This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.*
- **CS4014**: *Because this call is not awaited, execution of the current method continues before the call is completed. Consider applying the `await` operator to the result of the call.*
- **CS9123**: *Using the address-of operator on certain expressions inside an async method may not work as expected, as the target may be moved between the point where the address-of is performed and the point where it is referenced.*

### Awaiting async method calls

**Call not awaited (CS4014)**: When you call an async method that returns a <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601>, you should apply the [await](../operators/await.md) operator to the result. If you don't await the call, the program continues without waiting for the task to complete, which can lead to unexpected behavior.

The call to the async method starts an asynchronous task. However, because no `await` operator is applied, the program continues without waiting for the task to complete. In most cases, that behavior isn't what you expect. Usually other aspects of the calling method depend on the results of the call or, minimally, the called method is expected to complete before you return from the method that contains the call.

An equally important issue is what happens to exceptions raised in the called async method. An exception raised in a method that returns a <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601> is stored in the returned task. If you don't await the task or explicitly check for exceptions, the exception is lost. If you await the task, its exception is rethrown.

As a best practice, you should always await the call.

You should consider suppressing the warning only if you're sure that you don't want to wait for the asynchronous call to complete and that the called method won't raise any exceptions. In that case, you can suppress the warning by assigning the task result of the call to a variable.

The following example shows how to cause the warning, how to suppress it, and how to await the call:

```csharp
static async Task CallingMethodAsync(int millisecondsDelay)
{
    Console.WriteLine("  Entering calling method.");

    // Call #1.
    // Call an async method. Because you don't await it, its completion
    // isn't coordinated with the current method, CallingMethodAsync.
    // The following line causes warning CS4014.
    CalledMethodAsync(millisecondsDelay);

    // Call #2.
    // To suppress the warning without awaiting, you can assign the
    // returned task to a variable. The assignment doesn't change how
    // the program runs. However, recommended practice is always to
    // await a call to an async method.

    // Replace Call #1 with the following line.
    // Task delayTask = CalledMethodAsync(millisecondsDelay);

    // Call #3
    // To contrast with an awaited call, replace the unawaited call
    // (Call #1 or Call #2) with the following awaited call. Best
    // practice is to await the call.

    // await CalledMethodAsync(millisecondsDelay);

    Console.WriteLine("  Returning from calling method.");
}

static async Task CalledMethodAsync(int millisecondsDelay)
{
    Console.WriteLine("    Entering called method, starting and awaiting Task.Delay.");

    await Task.Delay(millisecondsDelay);

    Console.WriteLine("    Task.Delay is finished--returning from called method.");
}
```

### Async methods without await operators

**Async lacks awaits (CS1998)**: If an async method doesn't contain any `await` operators, the method runs synchronously. The compiler issues this warning because marking a method as `async` without using `await` creates unnecessary overhead from the generated state machine.

Consider these corrections:

- If the method should be asynchronous, add `await` operators for async operations
- If the method is actually synchronous, remove the `async` modifier

This warning helps you identify methods that were intended to be async but don't actually perform any asynchronous operations, or methods where you forgot to use `await`.

### Return value mismatches

**Return value from Task (CS1997)**: When an async method returns `Task` (not `Task<T>`), you shouldn't return a value with the `return` statement. The following example generates CS1997:

```csharp
using System.Threading.Tasks;

class C
{
    public static async Task F1()
    {
        // CS1997: Since 'C.F1()' is an async method that returns 'Task', 
        // a return keyword must not be followed by an object expression
        return await Task.Factory.StartNew(() => 1);
    }
}
```

A `return` statement in an `async` method returns the result of an awaitable statement. If the awaitable statement doesn't have a result, the state machine emitted by the compiler encapsulates returning the non-generic `Task`, eliminating the need for a `return` statement. This error indicates the current method's implementation doesn't align with its declared return type.

To correct this error, either remove the `return` statement:

```csharp
public static async Task F1()
{
    await Task.Factory.StartNew(() => 1);
}
```

Or change the method's return type to `Task<T>`:

```csharp
public static async Task<int> F1()
{
    return await Task.Factory.StartNew(() => 1);
}
```

If you don't need the async state machine, you can also remove the `async` modifier and return the task directly:

```csharp
public static Task<int> F1()
{
    return Task.Factory.StartNew(() => 1);
}
```

### Special restrictions and limitations

**Async methods in expression trees (CS1989)**: Async methods can't be used in expression trees. Expression trees are data structures that represent code as data, and they don't support the complex state machine transformations required by async methods.

**WinRT event accessors (CS1991)**: You can't have an add or remove accessor in an interface or a WinRT event that's marked as async. This is a platform-specific restriction for Windows Runtime interoperability.

**Address-of in async methods (CS9123)**: Using the address-of operator (`&`) on certain expressions inside an async method may not work as expected. The target may be moved between the point where the address-of is performed and the point where it's referenced, because async methods can suspend and resume execution at different points. This can lead to the pointer becoming invalid if the object is relocated in memory during the suspension.
