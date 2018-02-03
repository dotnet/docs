---
title: Attributes - C#
description: Learn how attributes work in C#.
keywords: .NET, .NET Core, C#, attributes
author: mgroves
ms.author: wiwagn
ms.date: 03/06/2017
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: b152cf36-76e4-43a5-b805-1a1952e53b79
---

# Using Attributes in C# #

Attributes provide a way of associating information with code in a declarative way. They can also provide a reusable element that can be applied to a variety of targets.

Consider the `[Obsolete]` attribute. It can be applied to classes, structs, methods, constructors, and more. It _declares_ that the element is obsolete. It's then up to the C#
compiler to look for this attribute, and do some action in response.

In this tutorial, you'll be introduced to how to add attributes to your code, how to create and use your own attributes, and how to use some
attributes that are built into .NET Core.

## Prerequisites
You’ll need to setup your machine to run .NET core. You can find the
installation instructions on the [.NET Core](https://www.microsoft.com/net/core)
page.
You can run this application on Windows, Ubuntu Linux, macOS or in a Docker container. 
You’ll need to install your favorite code editor. The descriptions below
use [Visual Studio Code](https://code.visualstudio.com/) which is an open
source, cross platform editor. However, you can use whatever tools you are
comfortable with.

## Create the Application

Now that you've installed all the tools, create a new .NET Core application. To use the command line generator, execute the following command in your favorite shell:

`dotnet new console`

This command will create barebones .NET core project files. You will need to execute `dotnet restore` to restore the dependencies needed to compile this project.

[!INCLUDE[DotNet Restore Note](~/includes/dotnet-restore-note.md)]

To execute the program, use `dotnet run`. You should see "Hello, World" output to the console.

## How to add attributes to code

In C#, attributes are classes that inherit from the `Attribute` base class. Any class that inherits from `Attribute` can be used as a sort of "tag" on other pieces of code.
For instance, there is an attribute called `ObsoleteAttribute`. This is used to signal that code is obsolete and shouldn't be used anymore. You can place this attribute on a class,
for instance, by using square brackets.

[!code-csharp[Obsolete attribute example](../../../samples/snippets/csharp/tutorials/attributes/Program.cs#ObsoleteExample1)]  

Note that while the class is called `ObsoleteAttribute`, it's only necessary to use `[Obsolete]` in the code. This is a convention that C# follows.
You can use the full name `[ObsoleteAttribute]` if you choose.

When marking a class obsolete, it's a good idea to provide some information as to *why* it's obsolete, and/or *what* to use instead. Do this by passing a string
parameter to the Obsolete attribute.

[!code-csharp[Obsolete attribute example with parameters](../../../samples/snippets/csharp/tutorials/attributes/Program.cs#ObsoleteExample2)]

The string is being passed as an argument to an `ObsoleteAttribute` constructor, just as if you were writing `var attr = new ObsoleteAttribute("some string")`.

Parameters to an attribute constructor are limited to simple types/literals: `bool, int, double, string, Type, enums, etc` and arrays of those types.
You can not use an expression or a variable. You are free to use positional or named parameters.

## How to create your own attribute

Creating an attribute is as simple as inheriting from the `Attribute` base class.

[!code-csharp[Create your own attribute](../../../samples/snippets/csharp/tutorials/attributes/Program.cs#CreateAttributeExample1)]

With the above, I can now use `[MySpecial]` (or `[MySpecialAttribute]`) as an attribute elsewhere in the code base.

[!code-csharp[Using your own attribute](../../../samples/snippets/csharp/tutorials/attributes/Program.cs#CreateAttributeExample2)]

Attributes in the .NET base class library like `ObsoleteAttribute` trigger certain behaviors within the compiler. However, any attribute you create acts
only as metadata, and doesn't result in any code within the attribute class being executed. It's up to you to act
on that metadata elsewhere in your code (more on that later in the tutorial).

There is a 'gotcha' here to watch out for. As mentioned above, only certain types are allowed to be passed as arguments when using attributes. However, when creating an attribute type,
the C# compiler won't stop you from creating those parameters. In the below example, I've created an attribute with a constructor that compiles just fine.

[!code-csharp[Valid constructor used in an attribute](../../../samples/snippets/csharp/tutorials/attributes/Program.cs#AttributeGothca1)]

However, you will be unable to use this constructor with attribute syntax.

[!code-csharp[Invalid attempt to use the attribute constructor](../../../samples/snippets/csharp/tutorials/attributes/Program.cs#AttributeGotcha2)]

The above will cause a compiler error like `Attribute constructor parameter 'myClass' has type 'Foo', which is not a valid attribute parameter type`

## How to restrict attribute usage

Attributes can be used on a number of "targets". The above examples show them on classes, but they can also be used on:

* Assembly
* Class
* Constructor
* Delegate
* Enum
* Event
* Field
* GenericParameter
* Interface
* Method
* Module
* Parameter
* Property
* ReturnValue
* Struct

When you create an attribute class, by default, C# will allow you to use that attribute on any of the possible attribute targets. If you want to restrict your attribute
to certain targets, you can do so by using the `AttributeUsageAttribute` on your attribute class. That's right, an attribute on an attribute!

[!code-csharp[Using your own attribute](../../../samples/snippets/csharp/tutorials/attributes/Program.cs#AttributeUsageExample1)]

If you attempt to put the above attribute on something that's not a class or a struct, you will get a compiler error
like `Attribute 'MyAttributeForClassAndStructOnly' is not valid on this declaration type. It is only valid on 'class, struct' declarations`

[!code-csharp[Using your own attribute](../../../samples/snippets/csharp/tutorials/attributes/Program.cs#AttributeUsageExample2)]

## How to use attributes attached to a code element

Attributes act as metadata. Without some outward force, they won't actually do anything.

To find and act on attributes, [Reflection](../programming-guide/concepts/reflection.md) is generally needed. I won't cover Reflection in-depth in this tutorial, but the basic
idea is that Reflection allows you to write code in C# that examines other code.

For instance, you can use Reflection to get information about a class: 

[!code-csharp[Getting type information with Reflection](../../../samples/snippets/csharp/tutorials/attributes/Program.cs#ReflectionExample1)]

That will print out something like: `The assembly qualified name of MyClass is ConsoleApplication.MyClass, attributes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null`

Once you have a `TypeInfo` object (or a `MemberInfo`, `FieldInfo`, etc), you can use the `GetCustomAttributes` method. This will return a collection of `Attribute` objects.
You can also use `GetCustomAttribute` and specify an Attribute type.

Here's an example of using `GetCustomAttributes` on a `MemberInfo` instance for `MyClass` (which we saw earlier has an `[Obsolete]` attribute on it).

[!code-csharp[Getting type information with Reflection](../../../samples/snippets/csharp/tutorials/attributes/Program.cs#ReflectionExample2)]

That will print to console: `Attribute on MyClass: ObsoleteAttribute`. Try adding other attributes to `MyClass`.

It's important to note that these `Attribute` objects are instantiated lazily. That is, they won't be instantiated until you use `GetCustomAttribute` or `GetCustomAttributes`.
They are also instantiated each time. Calling `GetCustomAttributes` twice in a row will return two different instances of `ObsoleteAttribute`.

## Common attributes in the base class library (BCL)

Attributes are used by many tools and frameworks. NUnit uses attributes like `[Test]` and `[TestFixture]` that are used by the NUnit test runner. ASP.NET MVC uses attributes like `[Authorize]`
and provides an action filter framework to perform cross-cutting concerns on MVC actions. [PostSharp](https://www.postsharp.net) uses the attribute syntax to allow aspect-oriented programming in C#.

Here are a few notable attributes built into the .NET Core base class libraries:

* `[Obsolete]`. This one was used in the above examples, and it lives in the `System` namespace. It is useful to provide declarative documentation about a changing code base. A message can be provided in the form of a string,
and another boolean parameter can be used to escalate from a compiler warning to a compiler error.

* `[Conditional]`. This attribute is in the `System.Diagnostics` namespace. This attribute can be applied to methods (or attribute classes). You must pass a string to the constructor.
If that string matches a `#define` directive, then any calls to that method (but not the method itself) will be removed by the C# compiler. Typically this is used for debugging (diagnostics) purposes.

* `[CallerMemberName]`. This attribute can be used on parameters, and lives in the `System.Runtime.CompilerServices` namespace. This is an attribute that is used to inject the name
of the method that is calling another method. This is typically used as a way to eliminate 'magic strings' when implementing INotifyPropertyChanged in various UI frameworks. As an
example:

[!code-csharp[Using CallerMemberName when implementing INotifyPropertyChanged](../../../samples/snippets/csharp/tutorials/attributes/Program.cs#CallerMemberName1)]

In the above code, you don't have to have a literal `"Name"` string. This can help prevent typo-related bugs and also makes for smoother refactoring/renaming.

## Summary

Attributes bring declarative power to C#. But they are a form of code as meta-data, and don't act by themselves.
