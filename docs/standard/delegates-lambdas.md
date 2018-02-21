---
title: Delegates and lambdas
description: Learn how delegates define a type, which specify a particular method signature, that can be called directly or passed to another method and called.
keywords: .NET, .NET Core
author: richlander
ms.author: wiwagn
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: fe2e4b4c-6483-4106-a4b4-a33e2e306591
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# Delegates and lambdas

Delegates define a type, which specify a particular method signature. A method (static or instance) that satisfies this signature can be assigned to a variable of that type, then called directly (with the appropriate arguments) or passed as an argument itself to another method and then called. The following example demonstrates delegate use.

```csharp
public class Program
{

  public delegate string Reverse(string s);

  static string ReverseString(string s)
  {
      return new string(s.Reverse().ToArray());
  }

  static void Main(string[] args)
  {
      Reverse rev = ReverseString;

      Console.WriteLine(rev("a string"));
  }
}
```

*   On line 4 we create a delegate type of a certain signature, in this case a method that takes a string parameter and then returns a string parameter.
*   On line 6, we define the implementation of the delegate by providing a method that has the exact same signature.
*   On line 13, the method is assigned to a type that conforms to the `Reverse` delegate.
*   Finally, on line 15 we invoke the delegate passing a string to be reversed.

In order to streamline the development process, .NET includes a set of delegate types that programmers can reuse and not have to create new types. These are `Func<>`, `Action<>` and `Predicate<>`, and they can be used in various places throughout the .NET APIs without the need to define new delegate types. Of course, there are some differences between the three as you will see in their signatures which mostly have to do with the way they were meant to be used:

*   `Action<>` is used when there is a need to perform an action using the arguments of the delegate.
*   `Func<>` is used usually when you have a transformation on hand, that is, you need to transform the arguments of the delegate into a different result. Projections are a prime example of this.
*   `Predicate<>` is used when you need to determine if the argument satisfies the condition of the delegate. It can also be written as a `Func<T, bool>`.

We can now take our example above and rewrite it using the `Func<>` delegate instead of a custom type. The program will continue running exactly the same.

```csharp
public class Program
{

  static string ReverseString(string s)
  {
      return new string(s.Reverse().ToArray());
  }

  static void Main(string[] args)
  {
      Func<string, string> rev = ReverseString;

      Console.WriteLine(rev("a string"));
  }
}
```

For this simple example, having a method defined outside of the Main() method seems a bit superfluous. It is because of this that .NET Framework 2.0 introduced the concept of **anonymous delegates**. With their support you are able to create "inline" delegates without having to specify any additional type or method. You simply inline the definition of the delegate where you need it.

For an example, we are going to switch it up and use our anonymous delegate to filter out a list of only even numbers and then print them to the console.

```csharp
public class Program
{

  public static void Main(string[] args)
  {
    List<int> list = new List<int>();

    for (int i = 1; i <= 100; i++)
    {
        list.Add(i);
    }

    List<int> result = list.FindAll(
      delegate(int no)
      {
          return (no%2 == 0);
      }
    );

    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
  }
}
```

Notice the highlighted lines. As you can see, the body of the delegate is just a set of expressions, as any other delegate. But instead of it being a separate definition, we’ve introduced it _ad hoc_ in our call to the `FindAll()` method of the `List<T>` type.

However, even with this approach, there is still much code that we can throw away. This is where **lambda expressions** come into play.

Lambda expressions, or just "lambdas" for short, were introduced first in C# 3.0, as one of the core building blocks of Language Integrated Query (LINQ). They are just a more convenient syntax for using delegates. They declare a signature and a method body, but don’t have an formal identity of their own, unless they are assigned to a delegate. Unlike delegates, they can be directly assigned as the left-hand side of event registration or in various Linq clauses and methods.

Since a lambda expression is just another way of specifying a delegate, we should be able to rewrite the above sample to use a lambda expression instead of an anonymous delegate.

```csharp
public class Program
{

  public static void Main(string[] args)
  {
    List<int> list = new List<int>();

    for (int i = 1; i <= 100; i++)
    {
        list.Add(i);
    }

    List<int> result = list.FindAll(i => i % 2 == 0);

    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
  }
}
```

If you take a look at the highlighted lines, you can see how a lambda expression looks like. Again, it is just a **very** convenient syntax for using delegates, so what happens under the covers is similar to what happens with the anonymous delegate.

Again, lambdas are just delegates, which means that they can be used as an event handler without any problems, as the following code snippet illustrates.

```csharp
public MainWindow()
{
    InitializeComponent();

    Loaded += (o, e) =>
    {
        this.Title = "Loaded";
    };
}
```

## Further reading and resources

*   [Delegates](../../docs/csharp/programming-guide/delegates/index.md)
*   [Anonymous Functions](../../docs/csharp/programming-guide/statements-expressions-operators/anonymous-functions.md)
*   [Lambda expressions](../../docs/csharp/programming-guide/statements-expressions-operators/lambda-expressions.md)
