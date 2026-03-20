---
description: "async - C# Reference"
title: "async keyword"
ms.date: 01/21/2026
f1_keywords:
  - "async_CSharpKeyword"
helpviewer_keywords:
  - "async keyword [C#]"
  - "async method [C#]"
  - "async [C#]"
---

# async (C# reference)

Use the `async` modifier to specify that a method, [lambda expression](../operators/lambda-expressions.md), or [anonymous method](../operators/delegate-operator.md) is asynchronous. If you use this modifier on a method or expression, you create an *async method*. The following example defines an async method named `ExampleMethodAsync`:

```csharp
public async Task<int> ExampleMethodAsync()
{
    //...
}
```

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

If you're new to asynchronous programming or don't understand how an async method uses the [`await` operator](../operators/await.md) to do potentially long-running work without blocking the caller's thread, read the introduction in [Asynchronous programming with async and await](../../asynchronous-programming/index.md). The following code is found inside an async method and calls the <xref:System.Net.Http.HttpClient.GetStringAsync%2a?displayProperty=nameWithType> method:

```csharp
string contents = await httpClient.GetStringAsync(requestUrl);
```

An async method runs synchronously until it reaches its first `await` expression. At that point, the method is suspended until the awaited task is complete. In the meantime, control returns to the caller of the method, as the example in the next section shows.

If the method that the `async` keyword modifies doesn't contain an `await` expression or statement, the method executes synchronously. A compiler warning alerts you to any async methods that don't contain `await` statements, because that situation might indicate an error. See [Compiler Warning (level 1) CS4014](../compiler-messages/async-await-errors.md#async-practices).

 The `async` keyword is contextual. It's a keyword only when it modifies a method, a lambda expression, or an anonymous method. In all other contexts, the compiler interprets it as an identifier.

The following example shows the structure and flow of control between an async event handler, `StartButton_Click`, and an async method, `ExampleMethodAsync`. The result from the async method is the number of characters of a web page. The code is suitable for a Windows Presentation Foundation (WPF) app or Windows Store app that you create in Visual Studio. See the code comments for setting up the app.

You can run this code in Visual Studio as a Windows Presentation Foundation (WPF) app or a Windows Store app. You need a Button control named `StartButton` and a Textbox control named `ResultsTextBox`. Remember to set the names and handler so that you have something like this:

```xaml
<Button Content="Button" HorizontalAlignment="Left" Margin="88,77,0,0" VerticalAlignment="Top" Width="75"
        Click="StartButton_Click" Name="StartButton"/>
<TextBox HorizontalAlignment="Left" Height="137" Margin="88,140,0,0" TextWrapping="Wrap"
         Text="&lt;Enter a URL&gt;" VerticalAlignment="Top" Width="310" Name="ResultsTextBox"/>
```

To run the code as a WPF app:

- Paste this code into the `MainWindow` class in MainWindow.xaml.cs.
- Add a reference to System.Net.Http.
- Add a `using` directive for System.Net.Http.

To run the code as a Windows Store app:

- Paste this code into the `MainPage` class in MainPage.xaml.cs.
- Add `using` directives for System.Net.Http and System.Threading.Tasks.

:::code language="csharp" source="./snippets/async/wpf/MainWindow.xaml.cs" id="1":::

> [!IMPORTANT]
> For more information about tasks and the code that executes while waiting for a task, see [Asynchronous programming with async and await](../../asynchronous-programming/index.md). For a full console example that uses similar elements, see [Process asynchronous tasks as they complete (C#)](../../asynchronous-programming/start-multiple-async-tasks-and-process-them-as-they-complete.md).

## Return types

An async method can have the following return types:

- <xref:System.Threading.Tasks.Task>
- <xref:System.Threading.Tasks.Task%601>
- [`void`](../builtin-types/void.md). Generally, avoid using `async void` methods for code other than event handlers because callers can't `await` those methods and must implement a different mechanism to report successful completion or error conditions.
- Any type that has an accessible `GetAwaiter` method. The `System.Threading.Tasks.ValueTask<TResult>` type is one such implementation. It's available by adding the NuGet package `System.Threading.Tasks.Extensions`.

The async method can't declare any [`in`](method-parameters.md#in-parameter-modifier), [`ref`](./ref.md), [`ref readonly`](./ref.md), or [`out`](method-parameters.md#out-parameter-modifier) parameters, nor can it have a [reference return value](../statements/jump-statements.md#ref-returns). However, it can call methods that have such parameters.

Specify `Task<TResult>` as the return type of an async method if the [return](../statements/jump-statements.md#the-return-statement) statement of the method specifies an operand of type `TResult`. Use `Task` if the method returns no meaningful value when it completes. That is, a call to the method returns a `Task`, but when the `Task` is completed, any `await` expression that's awaiting the `Task` evaluates to `void`. Use the `void` return type primarily to define event handlers, which require that return type. The caller of a `void`-returning async method can't await it and can't catch exceptions that the method throws. Return another type, typically a value type, that has a `GetAwaiter` method to minimize memory allocations in performance-critical sections of code.

For more information and examples, see [Async Return Types](../../asynchronous-programming/async-return-types.md).

## See also

- <xref:System.Runtime.CompilerServices.AsyncStateMachineAttribute>
- [await](../operators/await.md)
- [Asynchronous programming with async and await](../../asynchronous-programming/index.md)
- [Process asynchronous tasks as they complete](../../asynchronous-programming/start-multiple-async-tasks-and-process-them-as-they-complete.md)
- [.NET blog: How async/await really works in C#](https://devblogs.microsoft.com/dotnet/how-async-await-really-works/)
