---
title: Communicate nullable constraints on generic APIs
description: This advanced tutorial explains how to annotate generic types and methods to express nullability constraints. Adding those will help callers to use your APIs correctly
ms.date: 07/19/2019
ms.custom: mvc
---
# Tutorial: Annotate existing libraries for nullable reference types

The introduction of nullable reference types gives you the means to annotate APIs with your expectations on if arguments can be null or not, and whether methods may return null or not. These features enable the compiler to spot potential causes of `NullReferenceException` errors in your code. The better you describe your API's guarantees and expectations for accepting or return null values, the better the compiler can provide accurate warnings. You want warnings that help you find potential errors but not warnings that are false positives.

Nullable reference types affect all your API signatures. Converting a reasonable size library or application takes time. The work will affect every public API. Every argument and return value has expected preconditions and postconditions describing if and when null is valid. It's not enough to add `?` to some variable declarations. There's a richer vocabulary to more clearly describe when and where null might be used as an argument or a return value.

In this article, you'll learn techniques to make your library or application nullable-aware, while balancing other requirements and deliverables. You'll see how to balance ongoing development enabling nullable reference types. You'll learn challenges for generic type definitions. You'll learn to apply attributes to describe pre- and post-conditions on individual APIs.

## Choose a nullable strategy

The first choice is whether nullable reference types should be on or off by default. You have two strategies:

- Enable nullable reference types for the entire project, and disable it in code that's not ready.
- Only enable nullable reference types for code that's been annotated for nullable reference types.

The first strategy works best when you are adding other features to the library as you update it for nullable reference types. All new development is nullable aware. As you update existing code, you enable nullable reference types in those classes.

Following this first strategy, you do the following tasks:

1. Enable nullable types for the entire project by adding the `<Nullable>enable</Nullable>` element to your *csproj* files. 
1. Add the `#nullable disable` pragma to every source file in your project. 
1. As you work on each file, remove the pragma and address any warnings.

This first strategy has more up-front work to add the pragma to every file. The advantage is that every new code file added to the project will be nullable enabled. Any new work will be nullable aware; only existing code must be updated.

The second strategy works better if the library is generally stable, and the main focus of the development is to adopt nullable reference types. You turn on nullable reference types as you annotate APIs. When you have finished, you enable nullable reference types for the entire project.

Following this second strategy you do the following tasks:

1. Add the `#nullable enable` pragma to the file you want to make nullable aware.
1. Address any warnings.
1. Continue these first two steps until you have made the entire library nullable aware.
1. Enable nullable types for the entire project by adding the `<Nullable>enable</Nullable>` element to your *csproj* files. 
1. Remove the `#nullable enable` pragmas, as they are no longer needed.

This second strategy has less work up-front. The tradeoff is that the first task when you create a new file is to add the pragma and make it nullable aware. If any developers on your team forget, that new code is now in the backlog of work to make nullable aware.

Which of these strategies you pick depends on how much active development is taking place in your project. The more mature and stable your project, the better the second strategy. The more active features are being developed, the better the first strategy.

## Should nullable warnings introduce breaking changes?

Before you enable nullable reference types, variables are considered *nullable oblivious*. Once you enable nullable reference types, all those variables are *non-nullable*. The compiler will issue warnings if those variables aren't initialized to non-null values.

Another likely source of warnings are return values when the value has not been initialized.

The first step is to use `?` annotations on parameters and return types to indicate when arguments or return values may be null, or must not be null. As you do this, your goal isn't just to fix warnings. The deeper goal is to make the compiler understand your intent for potential null values. As you examine the warnings, you reach your next major decision for your application. Do you want to consider modifying API signatures to more clearly communicate your design intent?

Let's examine a common pattern:

```csharp
bool TrtGetvalue(int key, out string val)
```

Should the `val` parameter be an `out string?`? Maybe, because you can pass `null` into this method. The input to `val` won't be changed if the `key` wasn't found. It would still be `null`. On the other hand, `val` would never be `null` if the `key` was found.

If you want to consider breaking changes in your public API, a better signature might be:

```csharp
string? TryGetValue(int key);
```

The return value indicates success or failure, and carries the value if the value was found. In many cases, changing API signatures can improve how they communicate null values.

However, for public libraries, or libraries with large user bases, you may prefer not introducing any API signature changes. For those cases, and other common patterns, you can apply attributes to more clearly define when an argument or return value may be null.

Whether or not you consider changing the surface of your API, you'll likely find that type annotations alone are not sufficient for describing when `null` values for arguments or return values. In those instances, you can apply attributes to more clearly describe an API. 

## Attributes extend type annotations

A number of attributes have been added that you use to express further information about the null state of variables. All code you wrote before C# 8 introduced nullable reference types was *null oblivious*. That means any reference type variable may be null, but null checks aren't required. Once your code is *nullable aware*, those rules change. Reference types should never be the `null` value, and nullable reference types must be checked against null before being dereferenced.

Those rules aren't sufficient for much existing code. Many of our APIs have more complex rules for when it could or can't be `null`. In these cases, you'll use one of these attributes to express those rules:

- `AllowNull`: A non-nullable input argument may be null.
- `DisallowNull`: A nullable input argument should never be null.
- `MaybeNull`: A non-nullable return value may be null.
- `NotNull`: A nullable return value will never be null.
- `MaybeNullWhen`: A non-nullable `out` or `ref` argument may be null when the return value satisfies a condition.
- `NotNullWhen`: A nullable `out` or `ref` argument may not be null when the return value satisfies a condition.
- `NotNullIfNotNull`: a string return value is not null when the input string argument is not null.

In addition, generic types or methods can now use the `notnull` constraint to specify that a type argument cannot be nullable.

The examples that demonstrate these attributes and the `notnull` constraint are contrived to show the kinds of API shapes that prompted their addition. These represent the types of APIs where you'll want to apply these attributes. Many of these examples use properties or `ref` and `out` arguments, because those APIs often have different nullability constraints on the same variable used as input or output.

## Specify Preconditions: `AllowNull` and `DisallowNull`

Consider a read / write property that never returns `null` because it has a reasonable default value. Callers pass `null` to the set accessor when set it to that default value. For example, consider a messaging system that asks for a screen name in a chat room. If none is provided, the system generates a random name:

```csharp
public string ScreenName
{
   get { return screenName; }
   set { screenName = value ?? GenerateRandomScreenName(); }
}
private string screenName;
```

When you compile the preceding code in a nullable oblivious context, everything is fine. Once you enable nullable reference types, the `ScreenName` property becomes a non-nullable reference. That's correct for the `get` accessor: it never returns `null`. Callers don't need to check the returned property for `null`. But now setting the property to `null` generates a warning. In order to continue to support this type of code, you add the `AllowNull` attribute to the `set` accessor, as shown in the following code: 

```csharp
public string ScreenName
{
   get { return screenName; }
   [AllowNull] set { screenName = value ?? GenerateRandomScreenName(); }
}
private string screenName;
```

The preceding example demonstrates what to look for when adding the `AllowNull` attribute on an argument:

1. The general contract for that variable is that it should not be `null`, so you want a non-nullable reference type.
1. There are scenarios for the input variable to be `null`.

Most often you'll need this attribute for properties, or `in` `out` and `ref` arguments.


Or, a property may have the default value of `null`, but it should never be set to `null`:

```csharp
public string? FindABetterExample
{
   get;
   [DisallowNull] set;
}
```

The other situation where these attributes are most useful is when you are using `ref` or `out` parameters. You may want the argument type to be a non-nullable, but the caller may not be required to initialize it:

```csharp
// example
```

```csharp
// example calling out with variable declaration
```

## Overriding types on return values

Find examples for return value `MaybeNull`, or `NotNull`.

Properties could be really good here. 

## Conditional constraints on return values

Where `NotNullWhen(bool)` and `MaybeNullWhen(bool)` is discussed.

## Conditional constraints on string return values

Consider `NotNullIfNotNull(string)`


## Apply constaints to type parameters

Where `notnull` is discussed.  Likely a place to run into where you need `!`

## How to target older version

Discuss how to include nullable annotations when targetting an older version of .NET



## Conclusions
