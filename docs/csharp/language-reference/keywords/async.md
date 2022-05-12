---
description: "async - C# Reference"
title: "async - C# Reference"
ms.date: 05/22/2017
f1_keywords:
  - "async_CSharpKeyword"
helpviewer_keywords: 
  - "async keyword [C#]"
  - "async method [C#]"
  - "async [C#]"
ms.assetid: 16f14f09-b2ce-42c7-a875-e4eca5d50674
---

# async (C# Reference)

Use the `async` modifier to specify that a method, [lambda expression](../operators/lambda-expressions.md), or [anonymous method](../operators/delegate-operator.md) is asynchronous. If you use this modifier on a method or expression, it's referred to as an *async method*. The following example defines an async method named `ExampleMethodAsync`:

```csharp
public async Task<int> ExampleMethodAsync()
{
    //...
}
```

If you're new to asynchronous programming or do not understand how an async method uses the [`await` operator](../operators/await.md) to do potentially long-running work without blocking the caller's thread, read the introduction in [Asynchronous programming with async and await](../../programming-guide/concepts/async/index.md). The following code is found inside an async method and calls the <xref:System.Net.Http.HttpClient.GetStringAsync%2a?displayProperty=nameWithType> method:

```csharp
string contents = await httpClient.GetStringAsync(requestUrl);
```

An async method runs synchronously until it reaches its first `await` expression, at which point the method is suspended until the awaited task is complete. In the meantime, control returns to the caller of the method, as the example in the next section shows.

If the method that the `async` keyword modifies doesn't contain an `await` expression or statement, the method executes synchronously. A compiler warning alerts you to any async methods that don't contain `await` statements, because that situation might indicate an error. See [Compiler Warning (level 1) CS4014](../compiler-messages/cs4014.md).

 The `async` keyword is contextual in that it's a keyword only when it modifies a method, a lambda expression, or an anonymous method. In all other contexts, it's interpreted as an identifier.

## Example

The following example shows the structure and flow of control between an async event handler, `StartButton_Click`, and an async method, `ExampleMethodAsync`. The result from the async method is the number of characters of a web page. The code is suitable for a Windows Presentation Foundation (WPF) app or Windows Store app that you create in Visual Studio; see the code comments for setting up the app.

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
- Add using directives for System.Net.Http and System.Threading.Tasks.

[!code-csharp[wpf-async](../../../../samples/snippets/csharp/language-reference/keywords/async/wpf/MainWindow.xaml.cs#1)]

> [!IMPORTANT]
> For more information about tasks and the code that executes while waiting for a task, see [Asynchronous programming with async and await](../../programming-guide/concepts/async/index.md). For a full console example that uses similar elements, see [Process asynchronous tasks as they complete (C#)](../../programming-guide/concepts/async/start-multiple-async-tasks-and-process-them-as-they-complete.md).

## Return Types

An async method can have the following return types:

- <xref:System.Threading.Tasks.Task>
- <xref:System.Threading.Tasks.Task%601>
- [void](../builtin-types/void.md). `async void` methods are generally discouraged for code other than event handlers because callers cannot `await` those methods and must implement a different mechanism to report successful completion or error conditions.
- Starting with C# 7.0, any type that has an accessible `GetAwaiter` method. The `System.Threading.Tasks.ValueTask<TResult>` type is one such implementation. It is available by adding the NuGet package `System.Threading.Tasks.Extensions`.

The async method can't declare any [in](./in-parameter-modifier.md), [ref](./ref.md) or [out](./out-parameter-modifier.md) parameters, nor can it have a [reference return value](../../programming-guide/classes-and-structs/ref-returns.md), but it can call methods that have such parameters.

You specify `Task<TResult>` as the return type of an async method if the [return](../statements/jump-statements.md#the-return-statement) statement of the method specifies an operand of type `TResult`. You use `Task` if no meaningful value is returned when the method is completed. That is, a call to the method returns a `Task`, but when the `Task` is completed, any `await` expression that's awaiting the `Task` evaluates to `void`.

You use the `void` return type primarily to define event handlers, which require that return type. The caller of a `void`-returning async method can't await it and can't catch exceptions that the method throws.

Starting with C# 7.0, you return another type, typically a value type, that has a `GetAwaiter` method to minimize memory allocations in performance-critical sections of code.

For more information and examples, see [Async Return Types](../../programming-guide/concepts/async/async-return-types.md).

## See also

- <xref:System.Runtime.CompilerServices.AsyncStateMachineAttribute>
- [await](../operators/await.md)
- [Asynchronous programming with async and await](../../programming-guide/concepts/async/index.md)
- [Process asynchronous tasks as they complete](../../programming-guide/concepts/async/start-multiple-async-tasks-and-process-them-as-they-complete.md)
