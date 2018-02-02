---
title: System.Delegate and the `delegate` keyword
description: Learn about the classes in the .NET Framework that support delegates and how those map to the 'delegate' keyword.
keywords: .NET, .NET Core
author: BillWagner
ms.author: wiwagn
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: f3742fda-13c2-4283-8966-9e21c2674393
---

# System.Delegate and the `delegate` keyword

[Previous](delegates-overview.md)

This article will cover the classes in the .NET framework
that support delegates, and how those map to the `delegate`
keyword.

## Defining Delegate Types

Let's start with the 'delegate' keyword, because that's primarily what
you will use as you work with delegates. The code that the
compiler generates when you use the `delegate` keyword will
map to method calls that invoke members of the <xref:System.Delegate> 
and <xref:System.MulticastDelegate> classes. 

You define a delegate type using syntax that is similar to defining
a method signature. You just add the `delegate` keyword to the
definition.

Let's continue to use the List.Sort() method as our example. The first
step is to create a type for the comparison delegate:

```csharp
// From the .NET Core library

// Define the delegate type:
public delegate int Comparison<in T>(T left, T right);
```

The compiler generates a class, derived from `System.Delegate`
that matches the signature used (in this case, a method that
returns an integer, and has two arguments). The type
of that delegate is `Comparison`. The `Comparison` delegate
type is a generic type. For details on generics see [here](generics.md).

Notice that the syntax may appear as though it is declaring
a variable, but it is actually declaring a *type*. You can
define delegate types inside classes, directly inside namespaces,
or even in the global namespace.

> [!NOTE]
> Declaring delegate types (or other types) directly in
> the global namespace is not recommended. 

The compiler also generates add and remove handlers for this new
type so that clients of this class can add and remove methods from an instance's
invocation list. The compiler will enforce that the signature
of the method being added or removed matches the signature
used when declaring the method. 

## Declaring instances of delegates

After defining the delegate, you can create an instance of that type.
Like all variables in C#, you cannot declare delegate instances directly
in a namespace, or in the global namespace.

```csharp
// inside a class definition:

// Declare an instance of that type:
public Comparison<T> comparator;
```

The type of the variable is `Comparison<T>`, the delegate type
 defined earlier. The name of the variable is `comparator`.
 
 That code snippet above declared a member variable inside a class. You can also
 declare delegate variables that are local variables, or arguments to methods.

## Invoking Delegates

You invoke the methods that are in the invocation list of a delegate by calling
that delegate. Inside the `Sort()` method, the code will call the
comparison method to determine which order to place objects:

```csharp
int result = comparator(left, right);
```

In the line above, the code *invokes* the method attached to the delegate.
You treat the variable as a method name, and invoke it using normal
method call syntax.

That line of code makes an unsafe assumption: There's no guarantee that
a target has been added to the delegate. If no targets have been attached,
the line above would cause a `NullReferenceException` to be thrown. The
idioms used to address this problem are more complicated than a simple
null-check, and are covered later in this [series](delegates-patterns.md).

## Assigning, Adding and removing Invocation Targets

That's how a delegate type is defined, and how delegate instances
are declared and invoked.

Developers that want to use the `List.Sort()` method need to define
a method whose signature matches the delegate type definition, and
assign it to the delegate used by the sort method. This assignment
adds the method to the invocation list of that delegate object.

Suppose you wanted to sort a list of strings by their length. Your
comparison function might be the following:

```csharp
private static int CompareLength(string left, string right)
{
    return left.Length.CompareTo(right.Length);
}
```

The method is declared as a private method. That's fine. You may not
want this method to be part of your public interface. It can still
be used as the comparison method when attached to a delegate. The
calling code will have this method attached to the target list of
the delegate object, and can access it through that delegate.

You create that relationship by passing that method to the
`List.Sort()` method:

```csharp
phrases.Sort(CompareLength);
```

Notice that the method name is used, without parentheses. Using the method
as an argument tells the compiler to convert the method reference into a reference
that can be used as a delegate invocation target, and attach that method as
an invocation target.

You could also have been explicit by declaring a variable of type
'Comparison<string>` and doing an assignment:

```csharp
Comparison<string> comparer = CompareLength;
phrases.Sort(comparer);
```

In uses where the method being used as a delegate target is a small method,
it's common to use [Lambda Expression](lambda-expressions.md) syntax
to perform the assignment:

```csharp
Comparison<string> comparer = (left, right) => left.Length.CompareTo(right.Length);
phrases.Sort(comparer);
```

Using Lambda Expressions for delegate targets
is covered more in a [later section](delegates-patterns.md).

The Sort() example typically attaches a single target method to the
delegate. However, delegate objects do support invocation lists that
have multiple target methods attached to a delegate object.

## Delegate and MulticastDelegate classes

The language support described above provides the features
and support you'll typically need to work with delegates. These
features are built on two classes in the .NET Core
framework: <xref:System.Delegate> and <xref:System.MulticastDelegate>.

The `System.Delegate` class, and its single direct sub-class,
`System.MulticastDelegate`, provide the framework support for
creating delegates, registering methods as delegate targets,
and invoking all methods that are registered as a delegate
target. 

Interestingly, the `System.Delegate` and `System.MulticastDelegate`
classes are not themselves delegate types. They do provide the
basis for all specific delegate types. That same language
design process mandated that you cannot declare a class that derives
from `Delegate` or `MulticastDelegate`. The C# language rules prohibit it.
 
Instead, the C# compiler creates instances of a class derived from `MulticastDelegate`
when you use the C# language keyword to declare delegate types.

This design has its roots in the first release of C# and .NET. One
goal for the design team was to ensure that the language enforced
type safety when using delegates. That meant ensuring that delegates
were invoked with the right type and number of arguments. And, that
any return type was correctly indicated at compile time. Delegates
were part of the 1.0 .NET release, which was before generics.

The best way to enforce this type safety was for the compiler to
create the concrete delegate classes that represented the
method signature being used.

Even though you cannot create derived classes directly, you will
use the methods defined on these classes. Let's go through
the most common methods that you will use when you work with delegates.

The first, most important fact to remember is that every delegate you
work with is derived from `MulticastDelegate`. A multicast delegate means
that more than one method target can be invoked when invoking through
a delegate. The original design considered making a distinction between
delegates where only one target method could be attached and invoked,
and delegates where multiple target methods could be attached and
invoked. That distinction proved to be less useful in practice than
originally thought. The two different classes were already created,
and have been in the framework since its initial public release.

The methods that you will use the most with delegates are `Invoke()` and
`BeginInvoke()` / `EndInvoke()`. `Invoke()` will invoke all the methods that
have been attached to a particular delegate instance. As you saw above, you
typically invoke delegates using the method call syntax on the delegate
variable. As you'll see [later in this series](delegates-patterns.md),
there are patterns that work directly with these methods.

Now that you've seen the language syntax and the classes that support
delegates, let's examine how strongly typed delegates are used, created
and invoked.

[Next](delegates-strongly-typed.md)
