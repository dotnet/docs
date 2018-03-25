---
title: The history of C# - C# Guide
description: What did the language look like in its earliest versions, and how has it evolved since?
keywords: C#, .NET, .NET Core, What's New, C# History
author: erikdietrich
ms.author: wiwagn
ms.date: 09/20/2017
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
---

# The history of C# #

What did the language look like in its earliest incarnations? And how has it evolved in the years since?

## C# version 1.0

When you go back and look, C# version 1.0 looked a lot like Java. As [part of its stated design goals for ECMA](http://feeldotneteasy.blogspot.com/2011/01/c-design-goals.html), it sought to be a "simple, modern, general purpose object-oriented language."  At the time, looking like Java meant it achieved those early design goals.

But if you look back on C# 1.0 now, you'd find yourself a little dizzy. It lacked the built-in async capabilities and some of the slick functionality around generics that we take for granted. As a matter of fact, it lacked generics altogether.  And [LINQ](../linq/index.md)? Not available yet. That would take some years to come out.

C# version 1.0 looked stripped of features, compared to today. You'd find yourself writing some verbose code. But yet, you have to start somewhere. C# version 1.0 was a viable alternative to Java on the Windows platform.

## C# version 2.0

Now things start to get interesting. Let's take a look at some major features of C# 2.0, released in 2005, along with Visual Studio 2005:

- [Generics](../programming-guide/generics/index.md)
- [Partial types](../programming-guide/classes-and-structs/partial-classes-and-methods.md#partial-classes)
- [Anonymous methods](../programming-guide/statements-expressions-operators/anonymous-methods.md)
- [Nullable types](../programming-guide/nullable-types/index.md)
- [Iterators](../programming-guide/concepts/iterators.md)
- [Covariance and contravariance](../programming-guide/concepts/covariance-contravariance/index.md)

While C# may have started as a pretty generic Object-Oriented (OO) language, C# version 2.0 changed that in a hurry. Once they had their feet under them, they went after some serious developer pain points. And they went after them in a big way.

With generics, you have types and methods that can operate on an arbitrary type while still retaining type safety. So, for instance, having a <xref:System.Collections.Generic.List%601> lets you have `List<string>` or `List<int>` and perform type safe operations on those strings or integers while you iterate through them. This is better than creating `ListInt` inheritors or casting from `Object` for every operation.

C# version 2.0 brought iterators. To put it succinctly, this lets you iterate through the items in a `List` (or other Enumerable types) with a `foreach` loop. Having this as a first-class part of the language dramatically enhanced readability of the language and people's ability to reason about the code.

And yet, C# continued to play a bit of catch-up with Java. Java had already released versions that included generics and iterators. But that would soon change as the languages continued to evolve apart.

## C# version 3.0

C# version 3.0 came in late 2007, along with Visual Studio 2008, though the full boat of language features would actually come with C# version 3.5. This version marked a major change in the growth of C#. It established C# as a truly formidable programming language. Let's take a look at some major features in this version:

- [Auto implemented properties](../programming-guide/classes-and-structs/auto-implemented-properties.md)
- [Anonymous types](../programming-guide/classes-and-structs/anonymous-types.md)
- [Query expressions](../linq/query-expression-basics.md)
- [Lambda expression](https://www.daedtech.com/introduction-to-c-lambda-expressions/)
- [Expression trees](https://blogs.msdn.microsoft.com/charlie/2008/01/31/expression-tree-basics/)
- [Extension methods](https://www.codeproject.com/Tips/709310/Extension-Method-In-Csharp)

In retrospect, many of these features seem both inevitable and inseparable. They all fit together strategically. It's generally thought that C# version's killer feature was the query expression, also known as Language-Integrated Query (LINQ).

A more nuanced view examines expression tress, lambda expressions, and anonymous types as the foundation upon which LINQ is constructed. But, in either case, C# 3.0 presented a revolutionary concept. C# 3.0 had begun to lay the groundwork for turning C# into a hybrid Object Oriented / Functional language.

Specifically, you could now write SQL-style, declarative queries to perform operations on collections, among other things. Instead of writing a `for` loop to compute the average of a list of integers, you could now do that as simply as `list.Average()`. The combination of query expressions and extension methods made it look as though that list of integers had gotten a whole lot smarter.

It took time for people to really grasp and integrate the concept, but they gradually did. And now, years later, code is much more concise, simple, and functional.

## C# version 4.0

C# version 4.0 would have had a difficult time living up to the groundbreaking status of version 3.0. With version 3.0, C# had moved the language firmly out from the shadow of Java and into prominence. The language was quickly becoming elegant.

The next version did introduce some interesting new features:

- [Dynamic binding](../language-reference/keywords/dynamic.md)
- [Named/optional arguments](../programming-guide/classes-and-structs/named-and-optional-arguments.md)
- [Generic covariant and contravariant](../../standard/generics/covariance-and-contravariance.md)
- [Embedded interop types](https://stackoverflow.com/questions/20514240/whats-the-difference-setting-embed-interop-types-true-and-false-in-visual-studi)

Embedded interop types alleviated a deployment pain. Generic covariance and contravariance give you more power to use generics, but they're a bit academic and probably most appreciated by framework and library authors. Named and optional parameters let you eliminate many method overloads and provide convenience. But none of those features are exactly paradigm altering.

The major feature was the introduction of the `dynamic` keyword. The `dynamic` keyword introduced into C# version 4.0 the ability to override the compiler on compile-time typing. By using the dynamic keyword, you can create constructs similar to dynamically typed languages like JavaScript. You can create a `dynamic x = "a string"` and then add six to it, leaving it up to the runtime to sort out what should happen next.

This gives you the potential for errors but also great power within the language.

## C# version 5.0

C# version 5.0 was a very focused version of the language. Nearly all of the effort for that version went into another groundbreaking language concept.  Here is the major features list:

- [Asynchronous members](../async.md)
- [Caller info attributes](https://www.codeproject.com/Tips/606379/Caller-Info-Attributes-in-Csharp)

The caller info attribute lets you easily retrieve information about the context in which you're running without resorting to a ton of boilerplate reflection code. It has many uses in diagnostics and logging tasks.

But `async` and `await` are the real stars of this release. When these features came out in 2012, C# changed the game again by baking asynchrony into the language as a first-class participant. If you've ever dealt with long running operations and the implementation of webs of callbacks, you probably loved this language feature.

## C# version 6.0

With versions 3.0 and 5.0, C# had added some impressive features in an object oriented language. With version 6.0, it would go away from doing a dominant killer feature and instead release many features that delighted users of the language. Here are some of them:

- [Static imports](../language-reference/keywords/using-static.md)
- [Exception filters](https://www.thomaslevesque.com/2015/06/21/exception-filters-in-c-6/)
- [Property initializers](http://geekswithblogs.net/WinAZ/archive/2015/06/30/whatrsquos-new-in-c-6.0-auto-property-initializers.aspx)
- [Expression bodied members](https://lostechies.com/jimmybogard/2015/12/17/c-6-feature-review-expression-bodied-function-members/)
- [Null propagator](https://davefancher.com/2014/08/14/c-6-0-null-propagation-operator/)
- [String interpolation](../language-reference/tokens/interpolated.md)
- [nameof operator](https://stackoverflow.com/questions/31695900/what-is-the-purpose-of-nameof)
- [Dictionary initializer](../programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer.md)

Each of these features is interesting in its own right. But if you look at them altogether, you see an interesting pattern. In this version, C# eliminated language boilerplate to make code more terse and readable. So for fans of clean, simple code, this language version was a huge win.

They did one other thing along with this version, though it's not a traditional language feature in itself. They released [Roslyn the compiler as a service](https://github.com/dotnet/roslyn). The C# compiler is now written in C#, and you can use the compiler as part of your programming efforts.

## C# version 7.0

The most recent major version is C# version 7.0. This version has some evolutionary and cool stuff in the vein of C# 6.0, but without the compiler as a service. Here are some of the new features:

- [Out variables](http://www.c-sharpcorner.com/article/out-variables-in-c-sharp-7-0/)
- [Tuples and deconstruction](https://www.thomaslevesque.com/2016/08/23/tuple-deconstruction-in-c-7/)
- [Pattern matching](./csharp-7.md#pattern-matching)
- [Local functions](http://www.infoworld.com/article/3182416/application-development/c-7-in-depth-exploring-local-functions.html)
- [Expanded expression bodied members](./csharp-7.md#more-expression-bodied-members)
- [Ref locals and returns](./csharp-7.md#ref-locals-and-returns)

All of these features offer cool new capabilities for developers and the opportunity to write even cleaner code than ever. A highlight is condensing the declaration of variables to use with the `out` keyword and by allowing multiple return values via tuple.

But C# is being put to ever broader use. .NET Core now targets any operating system and has its eyes firmly on the cloud and on portability.  This certainly occupies the language designers' thoughts and time, in addition to coming up with new features.

_Article_ [_originally published on the NDepend blog_](https://blog.ndepend.com/c-versions-look-language-history/)_, courtesy of Erik Dietrich and Patrick Smacchia._
