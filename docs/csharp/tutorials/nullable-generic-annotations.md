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
bool TryGetvalue(int key, out string val)
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


<< Note that these only are checked for callers, not internal to the method>>

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
1. There are scenarios for the input variable to be `null`, though they are not the most common usage.

Most often you'll need this attribute for properties, or `in` `out` and `ref` arguments. The `AllowNull` attribute is the best choice when a variable is typically non-null, but you need to allow `null` as a precondition.

Contrast that with scenarios for using `DisallowNull`: You use this attribute to specify that an input variable of a nullable type should not be `null`. Consider a property where `null` is the default value, but clients can only set it to a non-null value. Consider the following code:

```csharp
public string ReviewComment // Comments can be added, but not removed.
{
    get { return _comment;}
    set
    {
        if (value == null) throw new ArgumentNullException(nameof(value), "Cannot set to null");
        _comment = null;
    }
}
string _comment;
```

The preceding code is the best way to express your design that the `ReviewComment` could be `null`, but cannot be set to `null`. Once this code is nullable aware, you can express this concept more clearly to callers:

```csharp
public string? ReviewComment // Comments can be added, but not removed.
{
    get { return _comment;}
    [DisallowNull] set
    {
        if (value == null) throw new ArgumentNullException(nameof(value), "Cannot set to null");
        _comment = null;
    }
}
string? _comment;
```

In a nullable context, the preceding code warns callers that the `ReviewComment` could be `null`, so it must be checked before access. Furthermore, it warns callers that, even though it could be `null`, callers should not explicitly set it to `null`. You should choose to use the `DisallowNull` attribute when you observe these characteristics about:

1. The variable could be `null` in primary scenarios, often when first instantiated.
1. The variable should not be explicitly set to `null`.

These situations are common in code that was originally *null oblivious*. It may be that object properties are set in two distinct initialization operations. It may be that some properties are set only after some asynchronous work has completed.

The `AllowNull` and `DisallowNull` attributes enable you to specify that preconditions on variables may not match the nullable annotations on those variables. These provide more detail about the characteristics of your API. This additional information helps callers use your API correctly.

## Specify post-conditions: `MaybeNull` and `NotNull`

Suppose you have a method with the following signature:

```csharp
public Customer FindCustomer(string lastName, string firstName)
```

You'd likely have written a method like this to return `null` when the name sought wasn't found. The `null` clearly indicates that the record wasn't found. In this example, you'd likely change the return type from `Customer` to `Customer?`. Instead, suppose it was a generic method like the following code:

```csharp
public T Find(IEnumerable<T> sequence, Func<T, bool> match)
```

You want to continue to express that the sequence does not contain `null` values, and the `match` function will not be called with a `null` value. But, if the sought element isn't found, the returned value could be `null`. That's when you add the `MaybeNull` annotation to the method return:

```csharp
[return: MaybeNull]
public T Find(IEnumerable<T> sequence, Func<T, bool> match)
```

The preceding code informs callers that the contract implies a non-nullable type, but the return value *may* actually be null.  Use the `MaybeNull` attribute when your API should be a non-nullable type, typically a generic type parameter, but there may be instances where `null` would be returned.

You can also specify that a return, or an `out` or `ref` argument is not null even though the type is a nullable type. Consider a method that ensures an `Array` is large enough to hold a number of elements. If the input argument doesn't have capacity, the routine would allocate a new array and copy all the existing elements into it. If the input argument is `null`, the routine would allocate new storage. If there is sufficient capacity, the routine does nothing:

```csharp
public void EnsureCapacity<T>(ref T[] storage, int size)
```

You could call this routine as follows:

```csharp
// messages has the default value (null) when EnsureCapacity is called:
EnsureCapacity<string>(ref messages, 10);
// messages is not null.
EnsureCapacity<string>(messages, 50);
```

After enabling null reference types, you want to  ensure that the preceding code compiles without warnings. When the method returns, the `storage` argument is guaranteed to be not null. However, it's acceptable to call `EnsureCapacity` with a null reference. You can make `storage` a nullable reference type, and add the `NotNull` post-condition to the parameter declaration:

```csharp
public void EnsureCapacity<T>([NotNull]ref T[]? storage, int size)
```

The preceding code expresses the existing contract very clearly: Callers can pass a variable with the `null` value, but the return value is guaranteed to never be null. The `NotNull` attribute is most useful for `ref` and `out` arguments where `null` may be passed as an argument, but that argument is guaranteed to be not null when the method returns.

## Specify conditional post-conditions: `NotNullWhen` and `MaybeNullWhen`

You're likely familiar with the `string` method <xref:System.String.IsNullOrEmpty(string)?DisplayProperty=nameWithType>. This method returns `true` when the argument is not null, and not the empty string. Callers should not need to null-check the argument if the method returns `false`. To make a method like this nullable aware, you'd set the argument to a nullable type, and add teh `NotNullWhen` attribute:

```csharp
bool IsNullOrEmpty([NotNullWhen(false)]string? value);
```

That informs the compiler that any code where the return value is `false` need not be checked:

```csharp
string? userInput = GetUserInput();
if (!(string.IsNullOrEmpty(userInput))
{
   int messageLength = userInput.Length; // no null check needed.
}
// null check needed on userInput here.
```

The <xref:System.String.IsNullOrEmpty(string)?DisplayProperty=nameWithType> method will be annotated as shown above for .NET Core 3.0. You may have similar methods in your codebase that checks the state of objects for null values. The compiler won't recognize those, and you'll need to add the annotations yourself.

Another use for these attributes is the Try* pattern. The postconditions for `ref` and `out` variables are communicated through the return value. Consider this method shown earlier:

```csharp
bool TryGetvalue(int key, out string val)
```

The preceding method follows a typical .NET idiom: the return value indicates if `val` was set or not. If the method returns `true`, the value is not null, `false`, and the method did not set `val`.

You can communicate that idiom using the `NotNullWhen` attribute. When you update the signature for nullable reference types, make `val` and `string?` and add an attribute:

```csharp
bool TryGetvalue(int key, [NotNullWhen(true)out string? val)
```

In the preceding example, the value of `val` is known to be not null when `TryGetValue` returns true.  You should annotate similar methods in your codebase in the same way: the arguments could be `null`, and are known to be not null when the method returns `true`.

There's one final attribute you may also need. Some methods manipulate string arguments. These methods will return a non-null string whenever the argument is not null. To correctly annotate these methods, you use the `NotNullIfNotNull` attribute. Consider the following method:

```csharp
string GetTopLevelDomainFromFullUrl(string url);
```

If the `url` argument is not null, the output is not `null`. You would annotate this method as the following code:

```csharp
[return: NotNullWhenNotNull("url")]
string? GetTopLevelDomainFromFullUrl(string? url);
```

The return value and the argument have both been annotated with the `?` indicating that either could be `null`. The attribute further clarifies that the return value will not be null when the `url` argument is not `null`.

## Generic definitions and nullability

Correctly communicating the null state of generic types and generic methods requires special care. This stems from the fact that a nullable value type and a nullable reference type are fundamentally different. An `int?` is a synonym for `Nullable<int>`, whereas `string?` is `string` with an attribute added by the compiler. The result is that the compiler cannot generate correct code for `T?` without knowing if `T` is a `class` or a `struct`. 

This doesn't mean you can use a nullable type (either value type or reference type) as the type argument for a closed generic type. Both `List<string?>` and `List<int?>` are valid instantiations of `List<T>`. 

What it does mean is that you cannot use `T?` in a generic class or method declaration without constraints. For example, <xref:System.Linq.Enumerable%601(System.Collections.Generic.IEnumerable%601)?displayProperty=nameWithType> will not be changed to return `T?`. You can overcome this limitation by adding either the `struct` or `class` constraint. With either of those constraints, the compiler knows how to generate code for both `T` and `T?`.

You may want to restrict the types used for a generic type argument to be non-nullable types. You can do that by adding the `notnull` constraint on that type argument. When that attribute is applied, the type argument nust not be a nullable type.

## Conclusions

Adding nullable reference types provides an initial vocabulary to describe your APIs expectations for if variables could be `null`. The additional attributes provide a richer vocabulary to describe the null state of variables as preconditions and postconditions. These more clearly describe your expectations and provide a better experience for the developers using your APIs.

As you update libraries for a nullable context, add these attributes to guide users of your APIs to the correct usage.
