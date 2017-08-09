---
title: The History of C# - C# Guide
description: What did the language look like in its earliest versions, and how has it evolved since?
keywords: C#, .NET, .NET Core, What's New, C# History
author: erikdietrich
ms.author: wiwagn
ms.date: 2017/08/09
ms.topic: article
ms.prod: visual-studio-dev-15
ms.technology: devlang-csharp
ms.devlang: csharp
---

# The History of C# #

What did the language look like in its earliest incarnations?  And how has it evolved in the years since?

## C# Version 1

When you go back and look, C# version 1 really did look an awful lot like Java.  As [part of its stated design goals for ECMA](http://feeldotneteasy.blogspot.com/2011/01/c-design-goals.html), it sought to be a &quot;simple, modern, general purpose object-oriented language.&quot;  At the time, it could have done worse thank looking like Java in order to achieve those goals.

But if you looked back on C# 1.0 now, you&#39;d find yourself a little dizzy.  It lacked the built in async capabilities and some of the slick functionality around generics that we take for granted.  As a matter of fact, it lacked generics altogether.  And [Linq](https://msdn.microsoft.com/en-us/library/bb308959.aspx)?  Nope.  That would take some years to come out.

C# version 1 looked pretty stripped of features, compared to today.  You&#39;d find yourself writing some verbose code.  But yet, you have to start somewhere.

## C# Version 2

Now things start to get interesting.  Let&#39;s take a look at some major features of C# 2.0, released in 2005, along with Visual Studio 2005.

- [Generics](https://www.tutorialspoint.com/csharp/csharp_generics.htm)
- [Partial types](https://www.dotnetperls.com/partial)
- [Anonymous methods](https://www.tutorialspoint.com/csharp/csharp_anonymous_methods.htm)
- [Nullable types](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/nullable-types/)
- [Iterators](https://msdn.microsoft.com/en-us/library/65zzykke(v=vs.100).aspx)
- [Covariance and contravariance](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/covariance-contravariance/)

While C# may have started as a pretty generic object-oriented language, C# Version 2 changed that in a hurry.  Once they had their feet under them, they went after some serious developer pain points.  And they went after them in a big way.

With generics, you have types and methods that can operate on an arbitrary type while still retaining type safety.  So, for instance, having a List&lt;T&gt; lets you have List&lt;string&gt; or List&lt;int&gt;  and perform type safe operations on those strings or ints while you iterate through them.  This certainly beats creating ListInt inheritors or casting from Object for every operation.

Oh, and speaking of iterators, C# Version 2 brought iterators.  To put it succinctly, this let you iterate through the items in List (or other Enumerable types) with a foreach loop.  Having this as a first class part of the language dramatically enhanced readability of the language and people&#39;s ability to reason about the code.

And yet, C# continued to play a bit of catch up with Java.  Java had already released versions that included generics and iterators.  But that would soon change as the languages continued to evolve apart.

## C# Version 3

C# Version 3 came in late 2007, along with Visual Studio 2008, though the full boat of language features would actually come with C# Version 3.5.  And what a version this proved to be.  This established C# as a truly formidable programming language.  Let&#39;s take a look at some major features in this version.

- [Auto implemented properties](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties)
- [Anonymous types](http://www.c-sharpcorner.com/UploadFile/ff2f08/anonymous-types-in-C-Sharp/)
- [Query expressions](https://docs.microsoft.com/en-us/dotnet/csharp/linq/query-expression-basics)
- [Lambda expression](https://www.daedtech.com/introduction-to-c-lambda-expressions/)
- [Expression trees](https://blogs.msdn.microsoft.com/charlie/2008/01/31/expression-tree-basics/)
- [Extension methods](https://www.codeproject.com/Tips/709310/Extension-Method-In-Csharp)

In retrospect, many of these features seem both inevitable and inseparable.  They all fit together so strategically.  It's generally thought that C# Version 3&#39;s killer feature was the query expression, also known as Linq ( **L** anguage **IN** tegrated **Q** uery).

A more nuanced view examines expression tress, lamba expressions and anonymous types as the foundation upon which LINQ is constructed.  But, in either case, C# 3 presented with a fairly revolutionary concept.  C# 3 had begun to lay the groundwork for turning C# into a hybrid OO-functional language.

Specifically, you could now write SQL-style, declarative queries to perform operations on collections, among other things.  Instead of writing a for loop to compute the average of a list of integers, you could now do that as simply as list.Average().  The combination of query expressions and extension methods made it look as though that list of ints had gotten a whole lot smarter.

It took a little while for people to really grasp and integrate the concept, but they gradually did.  And now, years later, code is much more concise, simple, and functional.

## C# Version 4

C# Version 4 would have had a difficult time living up to the groundbreaking status of version 3.  With version 3, C# had moved the language firmly out from the shadow of Java and into prominence.  The language was quickly becoming elegant

The next version did introduce some cool stuff, though.

- [Dynamic binding](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/dynamic)
- [Named/optional arguments](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments)
- [Generic covariant and contravariant](https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance)
- [Embedded interop types](https://stackoverflow.com/questions/20514240/whats-the-difference-setting-embed-interop-types-true-and-false-in-visual-studi)

Embedded interop types alleviated a deployment pain.  Generic covariance and contravariance give you a lot of power, but they&#39;re a bit academic and probably most appreciated by framework and library authors.  Named and optional parameters let you eliminate a lot of method overloads and provide convenience.  But none of those are exactly paradigm altering.

The major feature was the introduction of the dynamic keyword.  The `dynamic` introduced into C# Version 4 the ability to override the compiler on compile time typing.  By using the dynamic keyword, you can create constructs similar to dynamically typed languages like JavaScript.  You can create a dynamic x = &quot;a string&quot; and then add six to it, leaving it up to the runtime to sort out what on should happen next.

This gives you the potential for errors but also great power within the language.

## C# Version 5

C# Version 5 wasa very focused version of the language.  Nearly all of their effort for that version into another pretty groundbreaking language concept.  Here is the major features list.

- [Asynchronous members](https://msdn.microsoft.com/library/hh191443(vs.110).aspx)
- [Caller info attributes](https://www.codeproject.com/Tips/606379/Caller-Info-Attributes-in-Csharp)

The caller info attribute is pretty cool.  It lets you easily retrieve information about the context in which you&#39;re running without resorting to a ton of boilerplate reflection code.  Many developers love this feature.

But async and await are the real stars of this release.  When this came out in 2012, C# changed the game again by baking asynchrony into the language as a first class participant.  If you&#39;ve ever dealt with long running operations and the implementation of webs of callbacks, you probably loved this language feature.

## C# Version 6

With versions 3 and 5, C# had added some pretty impressive stuff in an OO language.  (Version 2 did as well, but it was fast following Java with those language features.)  With version 6, it would go away from doing a dominant killer feature and instead release a lot of features that delighted users of the language.  Here are some of them.

- [Static imports (a la Java)](http://geekswithblogs.net/BlackRabbitCoder/archive/2015/04/16/c.net-little-wonders-static-using-statements-in-c-6.aspx)
- [Exception filters](https://www.thomaslevesque.com/2015/06/21/exception-filters-in-c-6/)
- [Property initializers](http://geekswithblogs.net/WinAZ/archive/2015/06/30/whatrsquos-new-in-c-6.0-auto-property-initializers.aspx)
- [Expression bodied members](https://lostechies.com/jimmybogard/2015/12/17/c-6-feature-review-expression-bodied-function-members/)
- [Null propagator](https://davefancher.com/2014/08/14/c-6-0-null-propagation-operator/)
- [String interpolation](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interpolated-strings)
- [nameof operator](https://stackoverflow.com/questions/31695900/what-is-the-purpose-of-nameof)
- [Dictionary initializer](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer)

Taken individually, these are all cool language features.  But if you look at them altogether, you see an interesting pattern.  In this version, C# eliminated language boilerplate to make code more terse and readable.  So for fans of clean, simple code, this language version was a huge win.

Oh, and they did do one other thing along with this version, though it&#39;s not a traditional language feature, per se.  They released [Roslyn the compiler as a service](https://github.com/dotnet/roslyn).  C# now uses C# to build C#, and they let you use the compiler as part of your programming efforts.

## C# Version 7

Finally, we arrive at C# version 7.  This has some evolutionary and cool stuff in the vein of C# 6, but without the compiler as a service.  Here are some of the new features.

- [Out variables](http://www.c-sharpcorner.com/article/out-variables-in-c-sharp-7-0/)
- [Tuples and deconstruction](https://www.thomaslevesque.com/2016/08/23/tuple-deconstruction-in-c-7/)
- [Pattern matching](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#pattern-matching)
- [Local functions](http://www.infoworld.com/article/3182416/application-development/c-7-in-depth-exploring-local-functions.html)
- [Expanded expression bodied members](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#more-expression-bodied-members)
- [Ref locals and returns](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#ref-locals-and-returns)

All of these offer cool new capabilities for developers and the opportunity to write even cleaner code than ever.  A highlight is condensing the declaration of variables to use with the `out` keyword and by allowing multiple return values via tuple.

But C# is being put to ever broader use.  .NET now targets any operating system and has its eyes firmly on the cloud and on portability.  This certainly occupies the language designers&#39; thoughts and time, in addition to coming up with new features.

_Article_ [_originally published on the NDepend blog_](https://blog.ndepend.com/c-versions-look-language-history/)_, courtesy of Erik Dietrich and Patrick Smacchia._
