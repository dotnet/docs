---
title: Common Patterns for Delegates
description: Learn about common patterns for using delegates in your code to avoid strong coupling between your components.
keywords: .NET, .NET Core
author: BillWagner
ms.author: wiwagn
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 0ff8fdfd-6a11-4327-b061-0f2526f35b43
---

# Common Patterns for Delegates

[Previous](delegates-strongly-typed.md)

Delegates provide a mechanism that enables software designs
involving minimal coupling between components.

One excellent example for this kind of design is LINQ. The LINQ
Query Expression Pattern relies on delegates for all of its
features. Consider this simple example:

```csharp
var smallNumbers = numbers.Where(n => n < 10);
```

This filters the sequence of numbers to only those less than the value 10.
The `Where` method uses a delegate that determines which elements of a
sequence pass the filter. When you create a LINQ query, you supply the
implementation of the delegate for this specific purpose.

The prototype for the Where method is:

```csharp
public static IEnumerable<TSource> Where<in TSource> (IEnumerable<TSource> source, Func<TSource, bool> predicate);
```

This example is repeated with all the methods that are part of LINQ. They
all rely on delegates for the code that manages the specific query. This API
design pattern is a very powerful one to learn and understand.

This simple example illustrates how delegates require very little coupling
between components. You don't need to create a class that derives from a
particular base class. You don't need to implement a specific interface.
The only requirement is to provide the implementation of one method that
is fundamental to the task at hand.

## Building Your Own Components with Delegates

Let's build on that example by creating a component using a design that
relies on delegates.

Let's define a component that could be used for log messages in a large
system. The library components could be used in many different environments,
on multiple different platforms. There are a lot of common features in the
component that manages the logs. It will need to accept messages from any
component in the system. Those messages will have different priorities, which
the core component can manage. The messages should have timestamps in their
final archived form. For more advanced scenarios, you could filter messages by
the source component.

There is one aspect of the feature that will change often: where messages are
written. In some environments, they may be written to the error console. In
others, a file. Other possibilities include database storage, OS event logs,
or other document storage.

There are also combinations of output that might be used in different
scenarios. You may want to write messages to the console and to a file.

A design based on delegates will provide a great deal of flexibility, and
make it easy to support storage mechanisms that may be added in the future.

Under this design, the primary log component can be a non-virtual, even
sealed class. You can plug in any set of delegates to write the messages
to different storage media. The built in support for multicast delegates
makes it easy to support scenarios where messages must be written to multiple
locations (a file, and a console).

## A First Implementation

Let's start small: the initial implementation will accept new messages,
and write them using any attached delegate. You can start with one delegate
that writes messages to the console.

```csharp
public static class Logger
{
    public static Action<string> WriteMessage;
    
    public static void LogMessage(string msg)
    {
        WriteMessage(msg);
    }
}
```

The static class above is the simplest thing that can work. We need to
write the single implementation for the method that writes messages
to the console: 

```csharp
public static void LogToConsole(string message)
{
    Console.Error.WriteLine(message);
}
```

Finally, you need to hook up the delegate by attaching it to
the WriteMessage delegate declared in the logger:

```csharp
Logger.WriteMessage += LogToConsole;
```

## Practices

Our sample so far is fairly simple, but it still demonstrates some
of the important guidelines for designs involving delegates.

Using the delegate types defined in the Core Framework makes it easier
for users to work with the delegates. You don't need to define new types,
and developers using your library do not need to learn new, specialized
delegate types.

The interfaces used are as minimal and as flexible as possible: To create
a new output logger, you must create one method. That method may be a static
method, or an instance method. It may have any access.

## Formatting Output

Let's make this first version a bit more robust, and then start
creating other logging mechanisms.

Next, let's add a few arguments to the `LogMessage()` method so that
your log class creates more structured messages:

```csharp
// Logger implementation two
public enum Severity
{
    Verbose,
    Trace,
    Information,
    Warning,
    Error,
    Critical
}

public static class Logger
{
    public static Action<string> WriteMessage;
    
    public static void LogMessage(Severity s, string component, string msg)
    {
        var outputMsg = $"{DateTime.Now}\t{s}\t{component}\t{msg}";
        WriteMessage(outputMsg);
    }
}
```

Next, let's make use of that `Severity` argument to filter the messages
that are sent to the log's output. 

```csharp
public static class Logger
{
    public static Action<string> WriteMessage;
    
    public static Severity LogLevel {get;set;} = Severity.Warning;
    
    public static void LogMessage(Severity s, string component, string msg)
    {
        if (s < LogLevel)
            return;
            
        var outputMsg = $"{DateTime.Now}\t{s}\t{component}\t{msg}";
        WriteMessage(outputMsg);
    }
}
```
## Practices

You've added new features to the logging infrastructure. Because
the logger component is very loosely coupled to any output mechanism,
these new features can be added with no impact on any of the code
implementing the logger delegate.

As you keep building this, you'll see more examples of how this loose
coupling enables greater flexibility in updating parts of the site without
any changes to other locations. In fact, in a larger application, the logger
output classes might be in a different assembly, and not even need to be
rebuilt.

## Building a Second Output Engine

The Log component is coming along well. Let's add one more output
engine that logs messages to a file. This will be a slightly more
involved output engine. It will be a class that encapsulates the
file operations, and ensures that the file is always closed after
each write. That ensures that all the data is flushed to disk after
each message is generated.

Here is that file based logger:

```csharp
public class FileLogger
{
    private readonly string logPath;
    public FileLogger(string path)
    {
        logPath = path;
        Logger.WriteMessage += LogMessage;
    }
    
    public void DetachLog() => Logger.WriteMessage -= LogMessage;

    // make sure this can't throw.
    private void LogMessage(string msg)
    {
        try {
            using (var log = File.AppendText(logPath))
            {
                log.WriteLine(msg);
                log.Flush();
            }
        } catch (Exception e)
        {
            // Hmm. Not sure what to do.
            // Logging is failing...
        }
    }
}
```

Once you've created this class, you can instantiate it and it attaches
its LogMessage method to the Logger component:

```csharp
var file = new FileLogger("log.txt");
```

These two are not mutually exclusive. You could attach both log
methods and generate messages to the console and a file:

```csharp
var fileOutput = new FileLogger("log.txt");
Logger.WriteMessage += LogToConsole;
```

Later, even in the same application, you can remove one of the
delegates without any other issues to the system:

```csharp
Logger.WriteMessage -= LogToConsole;
```

## Practices

Now, you've added a second output handler for the logging sub-system.
This one needs a bit more infrastructure to correctly support the file
system. The delegate is an instance method. It's also a private method.
There's no need for greater accessibility because the delegate
infrastructure can connect the delegates.

Second, the delegate-based design enables multiple output methods
without any extra code. You don't need to build any additional infrastructure
to support multiple output methods. They simply become another method
on the invocation list.

Pay special attention to the code in the file logging output method. It
is coded to ensure that it does not throw any exceptions. While this isn't
always strictly necessary, it's often a good practice. If either of the
delegate methods throws an exception, the remaining delegates that are
on the invocation won't be invoked.

As a last note, the file logger must manage its resources by opening and
closing the file on each log message. You could choose to keep the file
open and implement IDisposable to close the file when you are completed.
Either method has its advantages and disadvantages. Both do create a bit
more coupling between the classes.

None of the code in the Logger class would need to be updated
in order to support either scenario.

## Handling Null Delegates

Finally, let's update the LogMessage method so that it is robust
for those cases when no output mechanism is selected. The current
implementation will throw a `NullReferenceException` when the
`WriteMessage` delegate does not have an invocation list attached.
You may prefer a design that silently continues when no methods
have been attached. This is easy using the null conditional operator,
combined with the `Delegate.Invoke()` method:

```csharp
public static void LogMessage(string msg)
{
    WriteMessage?.Invoke(msg);
}
```

The null conditional operator (`?.`) short-circuits when the left operand
(`WriteMessage` in this case) is null, which means no attempt is made
to log a message.

You won't find the `Invoke()` method listed in the documentation for
`System.Delegate` or `System.MulticastDelegate`. The compiler generates
a type safe `Invoke` method for any delegate type declared. In this example,
that means `Invoke` takes a single `string` argument, and has a void
return type.

## Summary of Practices

You've seen the beginnings of a log component that could be expanded
with other writers, and other features. By using delegates in the design
these different components are very loosely coupled. This provides
several advantages. It's very easy to create new output mechanisms
and attach them to the system. These other mechanisms only need one
method: the method that writes the log message. It's a design that
is very resilient when new features are added. The contract required
for any writer is to implement one method. That method could be a
static or instance method. It could be public, private, or any other
legal access.

The Logger class can make any number of enhancements or changes without
introducing breaking changes. Like any class, you cannot modify the
public API without the risk of breaking changes. But, because the
coupling between the logger and any output engines is only through
the delegate, no other types (like interfaces or base classes) are
involved. The coupling is as small as possible.

[Next](events-overview.md)
