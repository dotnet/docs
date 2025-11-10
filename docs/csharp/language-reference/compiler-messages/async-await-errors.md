---
title: Resolve errors and warnings `async`, `await` and the Task-asynchronous protocol
description: These compiler errors and warnings indicate errors in the syntax for declaring and implementing `async` methods that use the `await` expression.
f1_keywords:
 - "CS1983"
 - "CS1985"
 - "CS1986"
 - "CS1994"
 - "CS1996"
 - "CS1997"
 - "CS4008"
 - "CS4009"
 - "CS4014"
 - "CS4032"
 - "CS4033"
 - "CS9330"
helpviewer_keywords:
 - "CS1983"
 - "CS1985"
 - "CS1986"
 - "CS1994"
 - "CS1996"
 - "CS1997"
 - "CS4008"
 - "CS4009"
 - "CS4014"
 - "CS4032"
 - "CS4033"
 - "CS9330"
ms.date: 11/10/2025
ai-usage: ai-assisted
---
# Resolve errors and warnings in async methods using the await operator

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS1983**](#invalid-return-type): *The return type of an async method must be void, Task, Task\<T\>, a task-like type (A task-like type is one that adheres to the pattern, [described here](~/_csharpstandard/standard/classes.md#15151-general), required by the C# specification), IAsyncEnumerable\<T\>, or IAsyncEnumerator\<T\>*
- [**CS1985**](#await-in-catch): *Cannot await in a catch clause*
- [**CS1986**](#missing-getawaiter): *'await' requires that the type have a suitable 'GetAwaiter' method*
- [**CS1994**](#async-requires-body): *The 'async' modifier can only be used in methods that have a body.*
- [**CS1996**](#await-in-lock): *Cannot await in the body of a lock statement*
- [**CS1997**](#return-value-from-task): *Since `method` is an async method that returns `Task`, a return keyword must not be followed by an object expression. Did you intend to return `Task<T>`?*
- [**CS4008**](#await-void): *Cannot await 'void'*
- [**CS4009**](#async-entry-point): *'Type.Method': an entry point cannot be marked with the `async` modifier.*
- [**CS4014**](#call-not-awaited): *Because this call is not awaited, execution of the current method continues before the call is completed. Consider applying the `await` operator to the result of the call.*
- [**CS4032**](#await-requires-async-taskt): *The 'await' operator can only be used within an async method. Consider marking this method with the 'async' modifier and changing its return type to 'Task\<T\>'.*
- [**CS4033**](#await-requires-async-task): *The 'await' operator can only be used within an async method. Consider marking this method with the 'async' modifier and changing its return type to 'Task'.*
- [**CS9330**](#use-keywords): *'`MethodImplAttribute.Async`' cannot be manually applied to methods. Mark the method '`async`'.*

## Invalid return type

- CS1983: *The return type of an async method must be void, Task, Task\<T\>, a task-like type (A task-like type is one that adheres to the pattern, [described here](~/_csharpstandard/standard/classes.md#15151-general), required by the C# specification), IAsyncEnumerable\<T\>, or IAsyncEnumerator\<T\>*

The following sample generates CS1983:

```csharp
// CS1983.cs (4,62)
using System.Collections.Generic;

class C
{
    static async IEnumerable<int> M()
    {
        yield return await Task.FromResult(1);
    }
}
```

Since  `IEnumerable.GetEnumerator` returns an `IEnumerator<T>` whose `MoveNext` method does not return a value of `Task<T>`, it is not compatible with an `async` method.

Use an interface that results in the invocation of method that returns a type of `Task<T>`, for example, `IAsyncEnumerable<T>`:

```csharp
using System.Collections.Generic;

class C
{
    static async IAsyncEnumerable<int> M()
    {
        yield return await Task.FromResult(1);
    }
}
```

## Missing GetAwaiter

- CS1986: *'await' requires that the type have a suitable 'GetAwaiter' method*

The following sample generates CS1986:

```csharp
using System.Runtime.CompilerServices;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task M(MyTask<int> x)
    {
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

A `GetAwaiter` method must be a non-static method named `GetAwaiter` and return an instance of an object that implements `INotifyCompletion`.

A GetAwaiter needs to implement the `INotifyCompletion` interface (and optionally the `ICriticalNotifyCompletion` interface) and return a type that itself exposes three members [1]:

```csharp
bool IsCompleted { get; }
void OnCompleted(Action continuation);
TResult GetResult(); // TResult can also be void
```

The reason CS1986 is raised in the example is that the `GetAwaiter` method is `static`.  To correct this error, remove the `static` modifier (and correctly implement the method):

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

[1] [await anything;](https://devblogs.microsoft.com/pfxteam/await-anything/)

## Async requires body

- CS1994: *The 'async' modifier can only be used in methods that have a body.*

The following sample generates CS1994:

```csharp
interface IInterface
{
    async void F();
}
```

A non-concrete method declaration in an interface declaration has no method body.  In order to support the `async` modifier, the compiler subsumes the method body logic in a state machine.  Without a method body, the compiler cannot emit this state machine.  In addition, the logic of a method body must contain an await operator to signify a continuation the state machine must manage.  Without that `await` operator, a state machine has nothing to manage.

In the case of a non-concrete method, if deferring the implementation of a method body to a class that implements the interface, simply removing the async modifier will correct the error:

```csharp
interface IInterface
{
    void F();
}
```

Alternatively, a concrete default method (introduced in C# 8.0) could be declared within the interface:

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

## Await in lock

- CS1996: *Cannot await in the body of a lock statement*

The following sample generates CS1996:

```csharp
public class C
{
    private readonly Dictionary<string, string> keyValuePairs = new();

    public async Task<string> ReplaceValueAsync(string key, HttpClient httpClient)
    {
        lock (keyValuePairs)
        {
            var newValue = await httpClient.GetStringAsync(string.Empty);
            if (keyValuePairs.ContainsKey(key)) keyValuePairs[key] = newValue;
            else keyValuePairs.Add(key, newValue);
            return newValue;
        }
    }
}
```

The preceding code produces the same error with C# 13, as the `await` is in the `lock` statement block.

Asynchronous code within a `lock` statement block is hard to implement reliably and even harder to implement in a general sense.  The C# compiler doesn't support doing this to avoid emitting code prone to deadlocks.  Extracting the asynchronous code from the `lock` statement block corrects this error.  For example:

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

## Return value from Task

- CS1997: *Since `method` is an async method that returns `Task`, a return keyword must not be followed by an object expression. Did you intend to return `Task<T>`?*

The following sample generates CS1997:

```csharp
using System.Threading.Tasks;
class C
{
    public static async Task F1()
    {
        return await Task.Factory.StartNew(() => 1);
    }
}
```

A `return` statement in an `async` method returns the result of an awaitable statement.  If the awaitable statement does not have a result, the state machine emitted by the compiler encapsulates returning the non-generic `Task`, eliminating the need for a `return` statement.   Encountering error CS1997 means the referenced code includes a `return` statement that conflicts with the `async` modifier and the method's `return` type.  The error indicates that the current method's implementation does not align with its initial intent.  The simplest way to correct the error is to remove the `return` statement:

```csharp
    public static async Task F1()
    {
        await Task.Factory.StartNew(() => 1);
    }
```

But, the resulting implementation no longer needs the `async` modifier or the `await` operator.  A more accurate way of correcting this error is not to remove the `return` statement, but to remove the `async` modifier and the `await` operator:

```csharp
    public static Task F1()
    {
        return Task.Factory.StartNew(() => 1);
    }
```

## Await void

- CS4008: *Cannot await 'void'*

The following sample generates CS4008:

```csharp
// CS4008.cs (7,33)

using System.Threading.Tasks;

class Test
{
    public async void goo()
    {
        await Task.Factory.StartNew(() => { });
    }

    public async void bar()
    {
        await goo();
    }

    public static void Main() { }
}
```

Although this error can be corrected by changing the signature of `goo`:

```csharp
    public async Task goo()
    {
        await Task.Factory.StartNew(() => { });
    }
```

Simply adding `Task` to the method's signature needlessly perpetuates a compiler-created state machine when it is not needed.  The `goo` method does not require an `await`, nor does it need to be asynchronous.  Instead, consider simply returning the `Task` created by `Task.Factory`:

```csharp
    public Task goo()
    {
        return Task.Factory.StartNew(() => { });
    }
```

## Call not awaited

- CS4014: *Because this call is not awaited, execution of the current method continues before the call is completed. Consider applying the `await` operator to the result of the call.*

The current method calls an async method that returns a <xref:System.Threading.Tasks.Task> or a <xref:System.Threading.Tasks.Task%601> and doesn't apply the [await](../operators/await.md) operator to the result. The call to the async method starts an asynchronous task. However, because no `await` operator is applied, the program continues without waiting for the task to complete. In most cases, that behavior isn't what you expect. Usually other aspects of the calling method depend on the results of the call or, minimally, the called method is expected to complete before you return from the method that contains the call.

An equally important issue is what happens to exceptions that are raised in the called async method. An exception that's raised in a method that returns a <xref:System.Threading.Tasks.Task> or  <xref:System.Threading.Tasks.Task%601> is stored in the returned task. If you don't await the task or explicitly check for exceptions, the exception is lost. If you await the task, its exception is rethrown.

As a best practice, you should always await the call.

You should consider suppressing the warning only if you're sure that you don't want to wait for the asynchronous call to complete and that the called method won't raise any exceptions. In that case, you can suppress the warning by assigning the task result of the call to a variable.

The following example shows how to cause the warning, how to suppress it, and how to await the call.

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

In the example, if you choose Call #1 or Call #2, the unawaited async method `CalledMethodAsync` finishes after both its caller `CallingMethodAsync` and the caller's caller is complete. The last line in the following output shows you when the called method finishes. Entry to and exit from the event handler that calls `CallingMethodAsync` in the full example are marked in the output.

```console
Entering the Click event handler.
  Entering calling method.
    Entering called method, starting and awaiting Task.Delay.
  Returning from calling method.
Exiting the Click event handler.
    Task.Delay is finished--returning from called method.
```

You can also suppress compiler warnings by using [#pragma warning](../preprocessor-directives.md#pragma-warning) directives.

The following console application contains the methods from the previous example. The following steps set up the application.

1. Create a console application, and name it `AsyncWarning`.
1. In the Visual Studio Code Editor, choose the *Program.cs* file.
1. Replace the code in *Program.cs* with the following code.

    ```csharp
    using System;
    using System.Threading.Tasks;

    namespace AsyncWarning
    {
        class Program
        {
            static async Task Main()
            {
                Console.WriteLine("Entering Main() application entry point.");

                int millisecondsDelay = 2000;
                await CallingMethodAsync(millisecondsDelay);

                Console.WriteLine("Exiting Main() application entry point.");

                await Task.Delay(millisecondsDelay + 500);
            }

            static async Task CallingMethodAsync(int millisecondsDelay)
            {
                Console.WriteLine("  Entering calling method.");

                // Call #1.
                // Call an async method. Because you don't await it, its completion
                // isn't coordinated with the current method, CallingMethodAsync.
                // The following line causes warning CS4014.
                // CalledMethodAsync(millisecondsDelay);

                // Call #2.
                // To suppress the warning without awaiting, you can assign the
                // returned task to a variable. The assignment doesn't change how
                // the program runs. However, recommended practice is always to
                // await a call to an async method.

                // Replace Call #1 with the following line.
                //Task delayTask = CalledMethodAsync(millisecondsDelay);

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
        }

        // Output with Call #1 or Call #2. (Wait for the last line to appear.)

        // Entering Main() application entry point.
        //   Entering calling method.
        //     Entering called method, starting and awaiting Task.Delay.
        //   Returning from calling method.
        // Exiting Main() application entry point.
        //     Task.Delay is finished--returning from called method.

        // Output with Call #3, which awaits the call to CalledMethodAsync.

        // Entering Main() application entry point.
        //   Entering calling method.
        //     Entering called method, starting and awaiting Task.Delay.
        //     Task.Delay is finished--returning from called method.
        //   Returning from calling method.
        // Exiting Main() application entry point.
    }
    ```

1. Select the <kbd>F5</kbd> key to run the program.

The expected output appears at the end of the code.

## Await requires async TaskT

- CS4032: *The 'await' operator can only be used within an async method. Consider marking this method with the 'async' modifier and changing its return type to 'Task\<T\>'.*

The following sample generates CS4032:

```csharp
// CS4032.cs (7,9)
using System.Collections.Generic;
using System.Threading.Tasks;

class C
{
    static IAsyncEnumerator<int> M(int value)
    {
        yield return value;
        await Task.CompletedTask;
    }
}
```

To correct this error, change the signature of method `M` to make it asynchronous:

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

## Await requires async Task

- CS4033: *The 'await' operator can only be used within an async method. Consider marking this method with the 'async' modifier and changing its return type to 'Task'.*

The following sample generates CS4033:

```csharp
// CS4033.cs (7,9)

using System.Collections.Generic;
class C
{
    void M(IAsyncEnumerable<int> collection)
    {
        await foreach (var i in collection)
        {
        }
    }
}
```

To correct this error, change the signature of method `M` to make it asynchronous:

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

## Async entry point

- CS4009: *'Type.Method': an entry point cannot be marked with the `async` modifier.*

You cannot use the `async` keyword in the application entry point (typically the `Main` method).

> [!IMPORTANT]
> Starting with C# 7.1, the `Main` method can have an `async` modifier. For more information, see [Async main return values](../../fundamentals/program-structure/main-command-line.md#async-main-return-values). For information about how to select the C# language version, see the [Select the C# language version](../configure-language-version.md) article.

The following example produces CS4009:

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

[Update the C# language version](../configure-language-version.md) used by the project to 7.1 or higher.

If you use C# 7.0 or lower, remove the `async` keyword from the signature of the application entry point. Also remove any `await` keywords you've used to await asynchronous methods in your application entry point.

However, you still have to wait for the asynchronous method to complete before your entry point resumes execution. Otherwise, compilation generates compiler warning CS4014, and the application will terminate before the asynchronous operation completes. The following example illustrates this problem:

[!code-csharp[CS4009](~/samples/snippets/csharp/misc/cs4009-1.cs)]

To await a method that returns a <xref:System.Threading.Tasks.Task>, call its <xref:System.Threading.Tasks.Task.Wait%2A> method, as the following example illustrates:

[!code-csharp[CS4009](~/samples/snippets/csharp/misc/cs4009-2.cs)]

To await a method that returns a <xref:System.Threading.Tasks.Task%601>, retrieve the value of its <xref:System.Threading.Tasks.Task%601.Result> property, as the following example does:

[!code-csharp[CS4009](~/samples/snippets/csharp/misc/cs4009-3.cs)]

## Use keywords- CS9330: *'`MethodImplAttribute.Async`' cannot be manually applied to methods. Mark the method '`async`'.*

The implementation of `async` and `await` add attributes to the method signature. You should use the keywords instead of adding the attribute directly.
