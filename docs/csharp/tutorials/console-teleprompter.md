---
title: Console Application
description: This tutorial teaches you a number of features in .NET Core and the C# language.
keywords: .NET, .NET Core
author: BillWagner
ms.author: wiwagn
ms.date: 03/06/2017
ms.topic: article
ms.prod: .net-core
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 883cd93d-50ce-4144-b7c9-2df28d9c11a0
---

# Console Application

This tutorial teaches you a number of features in .NET Core and the C# language. You’ll learn:

- The basics of the .NET Core Command Line Interface (CLI)
- The structure of a C# Console Application
- Console I/O
- The basics of File I/O APIs in .NET
- The basics of the Task-based Asynchronous Programming in .NET

You’ll build an application that reads a text file, and echoes the
contents of that text file to the console. The output to the console is paced to match reading it aloud. You can speed up or slow down the pace
by pressing the ‘<’ or ‘>’ keys.

There are a lot of features in this tutorial. Let’s build them one by one.

## Prerequisites

You’ll need to setup your machine to run .NET Core. You can find the
installation instructions on the [.NET Core](https://www.microsoft.com/net/core)
page. You can run this
application on Windows, Linux, macOS or in a Docker container.
You’ll need to install your favorite code editor.

## Create the Application

The first step is to create a new application. Open a command prompt and
create a new directory for your application. Make that the current
directory. Type the command `dotnet new console` at the command prompt. This
creates the starter files for a basic "Hello World" application.

Before you start making modifications, let’s go through the steps to run
the simple Hello World application. After creating the application, type
`dotnet restore` at the command prompt. This command runs the NuGet
package restore process. NuGet is a .NET package manager. This command
downloads any of the missing dependencies for your project. As this is a
new project, none of the dependencies are in place, so the first run will
download the .NET Core framework. After this initial step, you will only
need to run `dotnet restore` when you add new dependent packages, or update
the versions of any of your dependencies.

[!INCLUDE[DotNet Restore Note](~/includes/dotnet-restore-note.md)]

After restoring packages, you run `dotnet build`. This executes the build
engine and creates your application executable. Finally, you execute `dotnet run` to
run your application.

The simple Hello World application code is all in Program.cs. Open that
file with your favorite text editor. We’re about to make our first changes.
At the top of the file, see a using statement:

```csharp
using System;
```

This statement tells the compiler that any types from the `System` namespace
are in scope. Like other Object Oriented languages you may have used, C#
uses namespaces to organize types. This Hello World program is no
different. You can see that the program is enclosed in the namespace with the name 
based on the name of the current directory. For this tutorial, let's change the name of the namespace to `TeleprompterConsole`:

```csharp
namespace TeleprompterConsole
```

## Reading and Echoing the File

The first feature to add is the ability to read a text file and display all that text to the console. First, let’s add a text file. Copy the [sampleQuotes.txt](https://github.com/dotnet/samples/raw/master/csharp/getting-started/console-teleprompter/sampleQuotes.txt) file from the GitHub repository for this [sample](https://github.com/dotnet/samples/tree/master/csharp/getting-started/console-teleprompter) into your project directory. This will serve as the script for your application. If you would like information on how to download the sample app for this topic, see the instructions in the [Samples and Tutorials](../../samples-and-tutorials/index.md#viewing-and-downloading-samples) topic.

Next, add the following method in your `Program` class (right below the `Main` method):

```csharp
static IEnumerable<string> ReadFrom(string file)
{
    string line;
    using (var reader = File.OpenText(file))
    {
        while ((line = reader.ReadLine()) != null)
        {
            yield return line;
        }
    }
}
```

This method uses types from two new namespaces. For this to compile you’ll
need to add the following two lines to the top of the file:

```csharp
using System.Collections.Generic;
using System.IO;
```

The <xref:System.Collections.Generic.IEnumerable%601> interface is defined in the
<xref:System.Collections.Generic> namespace. The <xref:System.IO.File> class is defined in the <xref:System.IO> namespace.

This method is a special type of C# method called an *Iterator method*. 
Enumerator methods return sequences that are evaluated lazily. That means 
each item in the sequence is generated as it is requested by the code 
consuming the sequence. Enumerator methods are methods that contain one or 
more [`yield return`](../language-reference/keywords/yield.md) statements. The object returned by the `ReadFrom` 
method contains the code to generate each item in the sequence. In this 
example, that involves reading the next line of text from the source file, 
and returning that string. Each time the calling code requests the next 
item from the sequence, the code reads the next line of text from the file
and returns it. When the file is completely read, the sequence 
indicates that there are no more items.

There are two other C# syntax elements that may be new to you. The [`using`](../language-reference/keywords/using-statement.md) 
statement in this method manages resource cleanup. The variable that is
initialized in the `using` statement (`reader`, in this example) must
implement the <xref:System.IDisposable> interface. That interface
defines a single method, `Dispose`, that should be called when the
resource should be released. The compiler generates that call when
execution reaches the closing brace of the `using` statement. The
compiler-generated code ensures that the resource is released even if an
exception is thrown from the code in the block defined by the using
statement.

The `reader` variable is defined using the `var` keyword. [`var`](../language-reference/keywords/var.md) defines an
*implicitly typed local variable*. That means the type of the variable is
determined by the compile-time type of the object assigned to the
variable. Here, that is the return value from the <xref:System.IO.File.OpenText(System.String)> method, which is
a <xref:System.IO.StreamReader> object.

Now, let’s fill in the code to read the file in the `Main` method:

```csharp
var lines = ReadFrom("sampleQuotes.txt");
foreach (var line in lines)
{
    Console.WriteLine(line);
}
```

Run the program (using `dotnet run`) and you can see every line printed out
to the console.

## Adding Delays and Formatting output

What you have is being displayed far too fast to read aloud. Now you need
to add the delays in the output. As you start, you’ll be building some of
the core code that enables asynchronous processing. However, these first
steps will follow a few anti-patterns. The anti-patterns are pointed out
in comments as you add the code, and the code will be updated in later
steps.

There are two steps to this section. First, you’ll update the iterator
method to return single words instead of entire lines. That’s done with
these modifications. Replace the `yield return line;` statement with the
following code:

```csharp
var words = line.Split(' ');
foreach (var word in words)
{
    yield return word + " ";
}
yield return Environment.NewLine;
```

Next, you need to modify how you consume the lines of the file, and add a
delay after writing each word. Replace the `Console.WriteLine(line)` statement
in the `Main` method with the following block:

```csharp
Console.Write(line);
if (!string.IsNullOrWhiteSpace(line))
{
    var pause = Task.Delay(200);
    // Synchronously waiting on a task is an
    // anti-pattern. This will get fixed in later
    // steps.
    pause.Wait();
}
```

The <xref:System.Threading.Tasks.Task> class is in the <xref:System.Threading.Tasks> namespace, so you need
to add that `using` statement at the top of file:

```csharp
using System.Threading.Tasks;
```

Run the sample, and check the output. Now, each single word is printed,
followed by a 200 ms delay. However, the displayed output shows some
issues because the source text file has several lines that have more than
80 characters without a line break. That can be hard to read while it's
scrolling by. That’s easy to fix. You’ll just keep track of the length of
each line, and generate a new line whenever the line length reaches a
certain threshold. Declare a local variable after the declaration of
`words` in the `ReadFrom` method that holds the line length:

```csharp
var lineLength = 0;
```

Then, add the following code after the `yield return word + " ";` statement
(before the closing brace):

```csharp
lineLength += word.Length + 1;
if (lineLength > 70)
{
    yield return Environment.NewLine;
    lineLength = 0;
}
```

Run the sample, and you’ll be able to read aloud at its pre-configured
pace.

## Async Tasks

In this final step, you’ll add the code to write the output asynchronously
in one task, while also running another task to read input from the user
if they want to speed up or slow down the text display. This has a few
steps in it and by the end, you’ll have all the updates that you need.
The first step is to create an asynchronous <xref:System.Threading.Tasks.Task> returning method that
represents the code you’ve created so far to read and display the file.

Add this method to your `Program` class (it’s taken from the body of your
`Main` method):

```csharp
private static async Task ShowTeleprompter()
{
    var words = ReadFrom("sampleQuotes.txt");
    foreach (var word in words)
    {
        Console.Write(word);
        if (!string.IsNullOrWhiteSpace(word))
        {
            await Task.Delay(200);
        }
    }
}
```

You’ll notice two changes. First, in the body of the method, instead of
calling <xref:System.Threading.Tasks.Task.Wait> to synchronously wait for a task to finish, this version
uses the `await` keyword. In order to do that, you need to add the `async`
modifier to the method signature. This method returns a `Task`. Notice that
there are no return statements that return a `Task` object. Instead, that
`Task` object is created by code the compiler generates when you use the
`await` operator. You can imagine that this method returns when it reaches
an `await`. The returned `Task` indicates that the work has not completed.
The method resumes when the awaited task completes. When it has executed
to completion, the returned `Task` indicates that it is complete.
Calling code can
monitor that returned `Task` to determine when it has completed.

You can call this new method in your `Main` method:

```csharp
ShowTeleprompter().Wait();
```

Here, in `Main`, the code does synchronously wait. You should use the
`await` operator instead of synchronously waiting whenever possible. But,
in a console application’s `Main` method, you cannot use the `await`
operator. That would result in the application exiting before all tasks
have completed.

> [!NOTE]
> If you use C# 7.1 or later, you can create console applications with [`async` `Main` method](../whats-new/csharp-7-1.md#async-main).

Next, you need to write the second asynchronous method to read from the
Console and watch for the ‘<’ and ‘>’ keys. Here’s the method you add for
that task:

```csharp
private static async Task GetInput()
{
    var delay = 200;
    Action work = () =>
    {
        do {
            var key = Console.ReadKey(true);
            if (key.KeyChar == '>')
            {
                delay -= 10;
            }
            else if (key.KeyChar == '<')
            {
                delay += 10;
            }
        } while (true);
    };
    await Task.Run(work);
}
```

This creates a lambda expression to represent an <xref:System.Action> delegate that reads a key
from the Console and modifies a local variable representing the delay when
the user presses the ‘<’ or ‘>’ keys. This method uses <xref:System.Console.ReadKey>
to block and wait for the user to press a key.

To finish this feature, you need to create a new `async Task` returning
method that starts both of these tasks (`GetInput` and 
`ShowTeleprompter`), and also manages the shared data between these two
tasks.

It’s time to create a class that can handle the shared data between these
two tasks. This class contains two public properties: the delay, and a
flag `Done` to indicate that the file has been completely read:

```csharp
namespace TeleprompterConsole
{
    internal class TelePrompterConfig
    {
        private object lockHandle = new object();
        public int DelayInMilliseconds { get; private set; } = 200;

        public void UpdateDelay(int increment) // negative to speed up
        {
            var newDelay = Min(DelayInMilliseconds + increment, 1000);
            newDelay = Max(newDelay, 20);
            lock (lockHandle)
            {
                DelayInMilliseconds = newDelay;
            }
        }

        public bool Done { get; private set; }

        public void SetDone()
        {
            Done = true;
        }
    }
}
```

Put that class in a new file, and enclose that class in the
`TeleprompterConsole` namespace as shown above. You’ll also need to add a `using static`
statement so that you can reference the `Min` and `Max` methods without the
enclosing class or namespace names. A [`using static`](../language-reference/keywords/using-static.md) statement imports the
methods from one class. This is in contrast with the `using` statements used
up to this point that have imported all classes from a namespace.

```csharp
using static System.Math;
```

The other language feature that’s new is the [`lock`](../language-reference/keywords/lock-statement.md) statement. This
statement ensures that only a single thread can be in that code at any
given time. If one thread is in the locked section, other threads must
wait for the first thread to exit that section. The `lock` statement uses an
object that guards the lock section. This class follows a standard idiom
to lock a private object in the class.

Next, you need to update the `ShowTeleprompter` and `GetInput` methods to
use the new `config` object. Write one final `Task` returning `async` method to
start both tasks and exit when the first task finishes:

```csharp
private static async Task RunTeleprompter()
{
    var config = new TelePrompterConfig();
    var displayTask = ShowTeleprompter(config);

    var speedTask = GetInput(config);
    await Task.WhenAny(displayTask, speedTask);
}
```

The one new method here is the <xref:System.Threading.Tasks.Task.WhenAny(System.Threading.Tasks.Task[])> call. That creates a `Task`
that finishes as soon as any of the tasks in its argument list completes.

Next, you need to update both the `ShowTeleprompter` and `GetInput` methods to
use the `config` object for the delay:

```csharp
private static async Task ShowTeleprompter(TelePrompterConfig config)
{
    var words = ReadFrom("sampleQuotes.txt");
    foreach (var line in words)
    {
        Console.Write(line);
        if (!string.IsNullOrWhiteSpace(line))
        {
            await Task.Delay(config.DelayInMilliseconds);
        }
    }
    config.SetDone();
}

private static async Task GetInput(TelePrompterConfig config)
{
    Action work = () =>
    {
        do {
            var key = Console.ReadKey(true);
            if (key.KeyChar == '>')
                config.UpdateDelay(-10);
            else if (key.KeyChar == '<')
                config.UpdateDelay(10);
        } while (!config.Done);
    };
    await Task.Run(work);
}
```

This new version of `ShowTeleprompter` calls a new method in the
`TeleprompterConfig` class. Now, you need to update `Main` to call 
`RunTeleprompter` instead of `ShowTeleprompter`:

```csharp
RunTeleprompter().Wait();
```

## Conclusion

This tutorial showed you a number of the features around the C# language
and the .NET Core libraries related to working in Console applications.
You can build on this knowledge to explore more about the language, and
the classes introduced here. You’ve seen the basics of File and Console
I/O, blocking and non-blocking use of the Task-based asynchronous
programming, a tour of the C# language and how C# programs are
organized and the .NET Core Command Line Interface and tools.

For more information about File I/O, see the [File and Stream I/O](../../standard/io/index.md) topic. For more information about asynchronous programming model used in this tutorial, see the [Task-based Asynchronous Programming](../..//standard/parallel-programming/task-based-asynchronous-programming.md) topic and the [Asynchronous programming](../async.md) topic.
