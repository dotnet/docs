---
title: "Main() and command-line arguments"
description: Learn about Main() and command-line arguments. The 'Main' method is the entry point of an executable program.
ms.date: 05/14/2021
f1_keywords:
  - "main_CSharpKeyword"
  - "Main"
helpviewer_keywords:
  - "Main method [C#]"
  - "C# language, command-line arguments"
  - "arguments [C#], command-line"
  - "command line [C#], arguments"
  - "command-line arguments [C#], Main method"
---
# Main() and command-line arguments

The `Main` method is the entry point of a C# application. (Libraries and services do not require a `Main` method as an entry point.) When the application is started, the `Main` method is the first method that is invoked.

There can only be one entry point in a C# program. If you have more than one class that has a `Main` method, you must compile your program with the **StartupObject** compiler option to specify which `Main` method to use as the entry point. For more information, see [**StartupObject** (C# Compiler Options)](../../language-reference/compiler-options/advanced.md#mainentrypoint-or-startupobject).

:::code language="csharp" source="snippets/main-command-line/TestClass.cs":::

Starting in C# 9, you can omit the `Main` method, and write C# statements as if they were in the `Main` method, as in the following example:

:::code language="csharp" source="snippets/top-level-statements-1/Program.cs":::

For information about how to write application code with an implicit entry point method, see [Top-level statements](top-level-statements.md).

## Overview

- The `Main` method is the entry point of an executable program; it is where the program control starts and ends.
- `Main` is declared inside a class or struct. `Main` must be [`static`](../../language-reference/keywords/static.md) and it need not be [`public`](../../language-reference/keywords/public.md). (In the earlier example, it receives the default access of [`private`](../../language-reference/keywords/private.md).) The enclosing class or struct is not required to be static.
- `Main` can either have a `void`, `int`, or, starting with C# 7.1, `Task`, or `Task<int>` return type.
- If and only if `Main` returns a `Task` or `Task<int>`, the declaration of `Main` may include the [`async`](../../language-reference/keywords/async.md) modifier. This specifically excludes an `async void Main` method.
- The `Main` method can be declared with or without a `string[]` parameter that contains command-line arguments. When using Visual Studio to create Windows applications, you can add the parameter manually or else use the <xref:System.Environment.GetCommandLineArgs> method to obtain the command-line arguments. Parameters are read as zero-indexed command-line arguments. Unlike C and C++, the name of the program is not treated as the first command-line argument in the `args` array, but it is the first element of the <xref:System.Environment.GetCommandLineArgs> method.

The following list shows valid `Main` signatures:

```csharp
public static void Main() { }
public static int Main() { }
public static void Main(string[] args) { }
public static int Main(string[] args) { }
public static async Task Main() { }
public static async Task<int> Main() { }
public static async Task Main(string[] args) { }
public static async Task<int> Main(string[] args) { }
```

The preceding examples all use the `public` accessor modifier. That's typical, but not required.

The addition of `async` and `Task`, `Task<int>` return types simplifies program code when console applications need to start and `await` asynchronous operations in `Main`.

## Main() return values

You can return an `int` from the `Main` method by defining the method in one of the following ways:

| `Main` method code             | `Main` signature                             |
|--------------------------------|----------------------------------------------|
| No use of `args` or `await`    | `static int Main()`                          |
| Uses `args`, no use of `await` | `static int Main(string[] args)`             |
| No use of `args`, uses `await` | `static async Task<int> Main()`              |
| Uses `args` and `await`        | `static async Task<int> Main(string[] args)` |

If the return value from `Main` is not used, returning `void` or `Task` allows for slightly simpler code.

| `Main` method code             | `Main` signature                        |
|--------------------------------|-----------------------------------------|
| No use of `args` or `await`    | `static void Main()`                    |
| Uses `args`, no use of `await` | `static void Main(string[] args)`       |
| No use of `args`, uses `await` | `static async Task Main()`              |
| Uses `args` and `await`        | `static async Task Main(string[] args)` |

However, returning `int` or `Task<int>` enables the program to communicate status information to other programs or scripts that invoke the executable file.

The following example shows how the exit code for the process can be accessed.

This example uses [.NET Core](../../../core/introduction.md) command-line tools. If you are unfamiliar with .NET Core command-line tools, you can learn about them in this [get-started article](../../../core/tutorials/with-visual-studio-code.md).

Create a new application by running `dotnet new console`. Modify the `Main` method in *Program.cs* as follows:

:::code language="csharp" source="snippets/main-command-line/MainReturnValTest.cs":::

When a program is executed in Windows, any value returned from the `Main` function is stored in an environment variable. This environment variable can be retrieved using `ERRORLEVEL` from a batch file, or `$LastExitCode` from PowerShell.

You can build the application using the [dotnet CLI](../../../core/tools/dotnet.md) `dotnet build` command.

Next, create a PowerShell script to run the application and display the result. Paste the following code into a text file and save it as `test.ps1` in the folder that contains the project. Run the PowerShell script by typing `test.ps1` at the PowerShell prompt.

Because the code returns zero, the batch file will report success. However, if you change MainReturnValTest.cs to return a non-zero value and then recompile the program, subsequent execution of the PowerShell script will report failure.

```powershell
dotnet run
if ($LastExitCode -eq 0) {
    Write-Host "Execution succeeded"
} else
{
    Write-Host "Execution Failed"
}
Write-Host "Return value = " $LastExitCode
```

```output
Execution succeeded
Return value = 0
```

### Async Main return values

When you declare an `async` return value for `Main`, the compiler generates the boilerplate code for calling asynchronous methods in `Main`.  If you don't specify the `async` keyword, you need to write that code yourself, as shown in the following example. The code in the example ensures that your program runs until the asynchronous operation is completed:

```csharp
public static void Main()
{
    AsyncConsoleWork().GetAwaiter().GetResult();
}

private static async Task<int> AsyncConsoleWork()
{
    // Main body here
    return 0;
}
```

This boilerplate code can be replaced by:

:::code language="csharp" source="snippets/main-arguments/Program.cs" id="AsyncMain":::

An advantage of declaring `Main` as `async` is that the compiler always generates the correct code.

When the application entry point returns a `Task` or `Task<int>`, the compiler generates a new entry point that calls the entry point method declared in the application code. Assuming that this entry point is called `$GeneratedMain`, the compiler generates the following code for these entry points:

- `static Task Main()` results in the compiler emitting the equivalent of `private static void $GeneratedMain() => Main().GetAwaiter().GetResult();`
- `static Task Main(string[])` results in the compiler emitting the equivalent of `private static void $GeneratedMain(string[] args) => Main(args).GetAwaiter().GetResult();`
- `static Task<int> Main()` results in the compiler emitting the equivalent of `private static int $GeneratedMain() => Main().GetAwaiter().GetResult();`
- `static Task<int> Main(string[])` results in the compiler emitting the equivalent of `private static int $GeneratedMain(string[] args) => Main(args).GetAwaiter().GetResult();`

> [!NOTE]
>If the examples used `async` modifier on the `Main` method, the compiler would generate the same code.

## Command-Line Arguments

You can send arguments to the `Main` method by defining the method in one of the following ways:

| `Main` method code                 | `Main` signature                             |
|------------------------------------|----------------------------------------------|
| No return value, no use of `await` | `static void Main(string[] args)`            |
| Return value, no use of `await`    | `static int Main(string[] args)`             |
| No return value, uses `await`      | `static async Task Main(string[] args)`      |
| Return value, uses `await`         | `static async Task<int> Main(string[] args)` |

If the arguments are not used, you can omit `args` from the method signature for slightly simpler code:

| `Main` method code                 | `Main` signature                |
|------------------------------------|---------------------------------|
| No return value, no use of `await` | `static void Main()`            |
| Return value, no use of `await`    | `static int Main()`             |
| No return value, uses `await`      | `static async Task Main()`      |
| Return value, uses `await`         | `static async Task<int> Main()` |

> [!NOTE]
> You can also use <xref:System.Environment.CommandLine%2A?displayProperty=nameWithType> or <xref:System.Environment.GetCommandLineArgs%2A?displayProperty=nameWithType> to access the command-line arguments from any point in a console or Windows Forms application. To enable command-line arguments in the `Main` method signature in a Windows Forms application, you must manually modify the signature of `Main`. The code generated by the Windows Forms designer creates `Main` without an input parameter.

The parameter of the `Main` method is a <xref:System.String> array that represents the command-line arguments. Usually you determine whether arguments exist by testing the `Length` property, for example:

:::code language="csharp" source="snippets/main-command-line/Program.cs" ID="Snippet4":::

> [!TIP]
> The `args` array can't be null. So, it's safe to access the `Length` property without null checking.

You can also convert the string arguments to numeric types by using the <xref:System.Convert> class or the `Parse` method. For example, the following statement converts the `string` to a `long` number by using the <xref:System.Int64.Parse%2A> method:

```csharp
long num = Int64.Parse(args[0]);
```

It is also possible to use the C# type `long`, which aliases `Int64`:

```csharp
long num = long.Parse(args[0]);
```

You can also use the `Convert` class method `ToInt64` to do the same thing:

```csharp
long num = Convert.ToInt64(s);
```

For more information, see <xref:System.Int64.Parse%2A> and <xref:System.Convert>.

The following example shows how to use command-line arguments in a console application. The application takes one argument at run time, converts the argument to an integer, and calculates the factorial of the number. If no arguments are supplied, the application issues a message that explains the correct usage of the program.

To compile and run the application from a command prompt, follow these steps:

1. Paste the following code into any text editor, and then save the file as  a text file with the name *Factorial.cs*.

    :::code language="csharp" source="./snippets/main-command-line/Factorial.cs":::

2. From the **Start** screen or **Start** menu, open a Visual Studio **Developer Command Prompt** window, and then navigate to the folder that contains the file that you created.

3. Enter the following command to compile the application.
  
     `dotnet build`  
  
     If your application has no compilation errors, an executable file that's named *Factorial.exe* is created.
  
4. Enter the following command to calculate the factorial of 3:
  
     `dotnet run -- 3`  
  
5. The command produces this output: `The factorial of 3 is 6.`

> [!NOTE]
> When running an application in Visual Studio, you can specify command-line arguments in the [Debug Page, Project Designer](/visualstudio/ide/reference/debug-page-project-designer).

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- <xref:System.Environment?displayProperty=nameWithType>
- [How to display command line arguments](../tutorials/how-to-display-command-line-arguments.md)
