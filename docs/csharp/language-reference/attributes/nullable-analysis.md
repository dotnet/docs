---
title: "C# Reserved attributes: Nullable static analysis"
ms.date: 04/14/2020
description: These attributes are interpreted by the compiler to provide better static analysis for nullable and non-nullable reference types.
---
# Reserved attributes contribute to the compiler's null state static analysis

In a nullable context, the compiler performs static analysis of code to determine the null state of all reference type variables:

- *not null*: Static analysis determined that the variable is assigned to a non-null value.
- *maybe null*: Static analysis cannot determine that a variable is assigned a non-null value.

You can apply a number of attributes that provide information to the compiler about the semantics of your APIs. That information helps the compiler perform static analysis and determine when a variable is not null. This article provides a brief description of each of those attributes and how to use them. All the examples assume C# 8.0 or newer, and the code is in a nullable context.

Let's start with a familiar example. Imagine your library has the following API to retrieve a resource string:

```csharp
bool TryGetMessage(string key, out string message)
```

The preceding example follows the familiar `Try*` pattern in .NET. There are two reference arguments for this API: the `key` and the `message` parameter. This API has the following rules relating to the nullness of these arguments:

- Callers shouldn't pass `null` as the argument for `key`.
- Callers can pass a variable whose value is `null` as the argument for `message`.
- If the `TryGetMessage` method returns `true`, the value of `message` isn't null. If the return value is `false,` the value of `message` (and its null state) is null.

The rule for `key` can be expressed by the variable type: `key` should be a non-nullable reference type. The `message` parameter is more complex. It allows `null` as the argument, but guarantees that, on success, that `out` argument isn't null. For these scenarios, you need a richer vocabulary to describe the expectations.

Several attributes have been added to express additional information about the null state of variables. All code you wrote before C# 8 introduced nullable reference types was *null oblivious*. That means any reference type variable may be null, but null checks aren't required. Once your code is *nullable aware*, those rules change. Reference types should never be the `null` value, and nullable reference types must be checked against `null` before being dereferenced.

The rules for your APIs are likely more complicated, as you saw with the `TryGetValue` API scenario. Many of your APIs have more complex rules for when variables can or can't be `null`. In these cases, you'll use one of the following attributes to express those rules:

- [AllowNull](xref:System.Diagnostics.CodeAnalysis.AllowNullAttribute): A non-nullable input argument may be null.
- [DisallowNull](xref:System.Diagnostics.CodeAnalysis.DisallowNullAttribute): A nullable input argument should never be null.
- [MaybeNull](xref:System.Diagnostics.CodeAnalysis.MaybeNullAttribute): A non-nullable return value may be null.
- [NotNull](xref:System.Diagnostics.CodeAnalysis.NotNullAttribute): A nullable return value will never be null.
- [MaybeNullWhen](xref:System.Diagnostics.CodeAnalysis.MaybeNullWhenAttribute): A non-nullable input argument may be null when the method returns the specified `bool` value.
- [NotNullWhen](xref:System.Diagnostics.CodeAnalysis.NotNullWhenAttribute): A nullable input argument will not be null when the method returns the specified `bool` value.
- [NotNullIfNotNull](xref:System.Diagnostics.CodeAnalysis.NotNullIfNotNullAttribute): A return value isn't null if the argument for the specified parameter isn't null.
- [DoesNotReturn](xref:System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute): A method never returns. In other words, it always throws an exception.
- [DoesNotReturnIf](xref:System.Diagnostics.CodeAnalysis.DoesNotReturnIfAttribute): This method never returns if the associated `bool` parameter has the specified value.

The preceding descriptions are a quick reference to what each attribute does. Each following section describes the behavior and meaning more thoroughly.

Adding these attributes gives the compiler more information about the rules for your API. When calling code is compiled in a nullable enabled context, the compiler will warn callers when they violate those rules. These attributes don't enable additional checks on your implementation.

## Specify preconditions: `AllowNull` and `DisallowNull`

Consider a read/write property that never returns `null` because it has a reasonable default value. Callers pass `null` to the set accessor when setting it to that default value. For example, consider a messaging system that asks for a screen name in a chat room. If none is provided, the system generates a random name:

```csharp
public string ScreenName
{
   get => _screenName;
   set => _screenName = value ?? GenerateRandomScreenName();
}
private string _screenName;
```

When you compile the preceding code in a nullable oblivious context, everything is fine. Once you enable nullable reference types, the `ScreenName` property becomes a non-nullable reference. That's correct for the `get` accessor: it never returns `null`. Callers don't need to check the returned property for `null`. But now setting the property to `null` generates a warning. In order to continue to support this type of code, you add the <xref:System.Diagnostics.CodeAnalysis.AllowNullAttribute?displayProperty=nameWithType> attribute to the property, as shown in the following code:

```csharp
[AllowNull]
public string ScreenName
{
   get => _screenName;
   set => _screenName = value ?? GenerateRandomScreenName();
}
private string _screenName = GenerateRandomScreenName();
```

You may need to add a `using` directive for <xref:System.Diagnostics.CodeAnalysis> to use this and other attributes discussed in this article. The attribute is applied to the property, not the `set` accessor. The `AllowNull` attribute specifies *pre-conditions*, and only applies to inputs. The `get` accessor has a return value, but no input arguments. Therefore, the `AllowNull` attribute only applies to the `set` accessor.

The preceding example demonstrates what to look for when adding the `AllowNull` attribute on an argument:

1. The general contract for that variable is that it shouldn't be `null`, so you want a non-nullable reference type.
1. There are scenarios for the input variable to be `null`, though they aren't the most common usage.

Most often you'll need this attribute for properties, or `in`, `out`, and `ref` arguments. The `AllowNull` attribute is the best choice when a variable is typically non-null, but you need to allow `null` as a precondition.

Contrast that with scenarios for using `DisallowNull`: You use this attribute to specify that an input variable of a nullable reference type shouldn't be `null`. Consider a property where `null` is the default value, but clients can only set it to a non-null value. Consider the following code:

```csharp
public string ReviewComment
{
    get => _comment;
    set => _comment = value ?? throw new ArgumentNullException(nameof(value), "Cannot set to null");
}
string _comment;
```

The preceding code is the best way to express your design that the `ReviewComment` could be `null`, but can't be set to `null`. Once this code is nullable aware, you can express this concept more clearly to callers using the <xref:System.Diagnostics.CodeAnalysis.DisallowNullAttribute?displayProperty=nameWithType>:

```csharp
[DisallowNull]
public string? ReviewComment
{
    get => _comment;
    set => _comment = value ?? throw new ArgumentNullException(nameof(value), "Cannot set to null");
}
string? _comment;
```

In a nullable context, the `ReviewComment` `get` accessor could return the default value of `null`. The compiler warns that it must be checked before access. Furthermore, it warns callers that, even though it could be `null`, callers shouldn't explicitly set it to `null`. The `DisallowNull` attribute also specifies a *pre-condition*, it does not affect the `get` accessor. You use the `DisallowNull` attribute when you observe these characteristics about:

1. The variable could be `null` in core scenarios, often when first instantiated.
1. The variable shouldn't be explicitly set to `null`.

These situations are common in code that was originally *null oblivious*. It may be that object properties are set in two distinct initialization operations. It may be that some properties are set only after some asynchronous work has completed.

The `AllowNull` and `DisallowNull` attributes enable you to specify that preconditions on variables may not match the nullable annotations on those variables. These provide more detail about the characteristics of your API. This additional information helps callers use your API correctly. Remember you specify preconditions using the following attributes:

- [AllowNull](xref:System.Diagnostics.CodeAnalysis.AllowNullAttribute): A non-nullable input argument may be null.
- [DisallowNull](xref:System.Diagnostics.CodeAnalysis.DisallowNullAttribute): A nullable input argument should never be null.

## Specify post-conditions: `MaybeNull` and `NotNull`

Suppose you have a method with the following signature:

```csharp
public Customer FindCustomer(string lastName, string firstName)
```

You've likely written a method like this to return `null` when the name sought wasn't found. The `null` clearly indicates that the record wasn't found. In this example, you'd likely change the return type from `Customer` to `Customer?`. Declaring the return value as a nullable reference type specifies the intent of this API clearly.

For reasons covered under [Generic definitions and nullability](../../nullable-migration-strategies.md#generic-definitions-and-nullability) that technique does not work with generic methods. You may have a generic method that follows a similar pattern:

```csharp
public T Find<T>(IEnumerable<T> sequence, Func<T, bool> predicate)
```

You can't specify that the return value is `T?`. The method returns `null` when the sought item isn't found. Since you can't declare a `T?` return type, you add the `MaybeNull` annotation to the method return:

```csharp
[return: MaybeNull]
public T Find<T>(IEnumerable<T> sequence, Func<T, bool> predicate)
```

The preceding code informs callers that the contract implies a non-nullable type, but the return value *may* actually be null.  Use the `MaybeNull` attribute when your API should be a non-nullable type, typically a generic type parameter, but there may be instances where `null` would be returned.

You can also specify that a return value or an `out` or `ref` argument isn't null even though the type is a nullable reference type. Consider a method that ensures an array is large enough to hold a number of elements. If the input argument doesn't have capacity, the routine would allocate a new array and copy all the existing elements into it. If the input argument is `null`, the routine would allocate new storage. If there's sufficient capacity, the routine does nothing:

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

After enabling null reference types, you want to ensure that the preceding code compiles without warnings. When the method returns, the `storage` argument is guaranteed to be not null. However, it's acceptable to call `EnsureCapacity` with a null reference. You can make `storage` a nullable reference type, and add the `NotNull` post-condition to the parameter declaration:

```csharp
public void EnsureCapacity<T>([NotNull] ref T[]? storage, int size)
```

The preceding code expresses the existing contract clearly: Callers can pass a variable with the `null` value, but the return value is guaranteed to never be null. The `NotNull` attribute is most useful for `ref` and `out` arguments where `null` may be passed as an argument, but that argument is guaranteed to be not null when the method returns.

You specify unconditional postconditions using the following attributes:

- [MaybeNull](xref:System.Diagnostics.CodeAnalysis.MaybeNullAttribute): A non-nullable return value may be null.
- [NotNull](xref:System.Diagnostics.CodeAnalysis.NotNullAttribute): A nullable return value will never be null.

## Specify conditional post-conditions: `NotNullWhen`, `MaybeNullWhen`, and `NotNullIfNotNull`

You're likely familiar with the `string` method <xref:System.String.IsNullOrEmpty(System.String)?DisplayProperty=nameWithType>. This method returns `true` when the argument is null or an empty string. It's a form of null-check: Callers don't need to null-check the argument if the method returns `false`. To make a method like this nullable aware, you'd set the argument to a nullable reference type, and add the `NotNullWhen` attribute:

```csharp
bool IsNullOrEmpty([NotNullWhen(false)] string? value);
```

That informs the compiler that any code where the return value is `false` need not be null-checked. The addition of the attribute informs the compiler's static analysis that `IsNullOrEmpty` performs the necessary null check: when it returns `false`, the input argument is not `null`.

```csharp
string? userInput = GetUserInput();
if (!string.IsNullOrEmpty(userInput))
{
   int messageLength = userInput.Length; // no null check needed.
}
// null check needed on userInput here.
```

The <xref:System.String.IsNullOrEmpty(System.String)?DisplayProperty=nameWithType> method will be annotated as shown above for .NET Core 3.0. You may have similar methods in your codebase that check the state of objects for null values. The compiler won't recognize custom null check methods, and you'll need to add the annotations yourself. When you add the attribute, the compiler's static analysis knows when the tested variable has been null checked.

Another use for these attributes is the `Try*` pattern. The postconditions for `ref` and `out` variables are communicated through the return value. Consider this method shown earlier:

```csharp
bool TryGetMessage(string key, out string message)
```

The preceding method follows a typical .NET idiom: the return value indicates if `message` was set to the found value or, if no message is found, to the default value. If the method returns `true`, the value of `message` isn't null; otherwise, the method sets `message` to null.

You can communicate that idiom using the `NotNullWhen` attribute. When you update the signature for nullable reference types, make `message` a `string?` and add an attribute:

```csharp
bool TryGetMessage(string key, [NotNullWhen(true)] out string? message)
```

In the preceding example, the value of `message` is known to be not null when `TryGetMessage` returns `true`. You should annotate similar methods in your codebase in the same way: the arguments could be `null`, and are known to be not null when the method returns `true`.

There's one final attribute you may also need. Sometimes the null state of a return value depends on the null state of one or more input arguments. These methods will return a non-null value whenever certain input arguments aren't `null`. To correctly annotate these methods, you use the `NotNullIfNotNull` attribute. Consider the following method:

```csharp
string GetTopLevelDomainFromFullUrl(string url);
```

If the `url` argument isn't null, the output isn't `null`. Once nullable references are enabled, that signature works correctly, provided your API never accepts a null input. However, if the input could be null, then return value could also be null. Therefore, you could change the signature to the following code:

```csharp
string? GetTopLevelDomainFromFullUrl(string? url);
```

That also works, but will often force callers to implement extra `null` checks. The contract is that the return value would be `null` only when the input argument `url` is `null`. To express that contract, you would annotate this method as shown in the following code:

```csharp
[return: NotNullIfNotNull("url")]
string? GetTopLevelDomainFromFullUrl(string? url);
```

The return value and the argument have both been annotated with the `?` indicating that either could be `null`. The attribute further clarifies that the return value won't be null when the `url` argument isn't `null`.

You specify conditional postconditions using these attributes:

- [MaybeNullWhen](xref:System.Diagnostics.CodeAnalysis.MaybeNullWhenAttribute): A non-nullable input argument may be null when the method returns the specified `bool` value.
- [NotNullWhen](xref:System.Diagnostics.CodeAnalysis.NotNullWhenAttribute): A nullable input argument will not be null when the method returns the specified `bool` value.
- [NotNullIfNotNull](xref:System.Diagnostics.CodeAnalysis.NotNullIfNotNullAttribute): A return value isn't null if the input argument for the specified parameter isn't null.

## Verify unreachable code

Some methods, typically exception helpers or other utility methods, always exit by throwing an exception. Or, a helper may throw an exception based on the value of a Boolean argument.

In the first case, you can add the `DoesNotReturn` attribute to the method declaration. The compiler helps you in three ways. First, the compiler issues a warning if there is a path where the method can exit without throwing an exception. Second, the compiler marks any code after a call to that method as *unreachable*, until an appropriate `catch` clause is encountered. Third, the unreachable code won't affect any null states. Consider this method:

```csharp
[DoesNotReturn]
private void FailFast()
{
    throw new InvalidOperationException();
}

public void SetState(object containedField)
{
    if (!isInitialized)
    {
        FailFast();
    }

    // unreachable code:
    _field = containedField;
}
```

In the second case, you add the `DoesNotReturnIf` attribute to a Boolean parameter of the method. You can modify the previous example as follows:

```csharp
private void FailFast([DoesNotReturnIf(false)] bool isValid)
{
    if (!isValid)
    {
        throw new InvalidOperationException();
    }
}

public void SetState(object containedField)
{
    FailFast(isInitialized);

    // unreachable code when "isInitialized" is false:
    _field = containedField;
}
```

## Summary

[!INCLUDE [C# version alert](../../includes/csharp-version-alert.md)]

Adding nullable reference types provides an initial vocabulary to describe your APIs expectations for variables that could be `null`. The additional attributes provide a richer vocabulary to describe the null state of variables as preconditions and postconditions. These attributes more clearly describe your expectations and provide a better experience for the developers using your APIs.

As you update libraries for a nullable context, add these attributes to guide users of your APIs to the correct usage. These attributes help you fully describe the null-state of input arguments and return values:

- [AllowNull](xref:System.Diagnostics.CodeAnalysis.AllowNullAttribute): A non-nullable input argument may be null.
- [DisallowNull](xref:System.Diagnostics.CodeAnalysis.DisallowNullAttribute): A nullable input argument should never be null.
- [MaybeNull](xref:System.Diagnostics.CodeAnalysis.MaybeNullAttribute): A non-nullable return value may be null.
- [NotNull](xref:System.Diagnostics.CodeAnalysis.NotNullAttribute): A nullable return value will never be null.
- [MaybeNullWhen](xref:System.Diagnostics.CodeAnalysis.MaybeNullWhenAttribute): A non-nullable input argument may be null when the method returns the specified `bool` value.
- [NotNullWhen](xref:System.Diagnostics.CodeAnalysis.NotNullWhenAttribute): A nullable input argument will not be null when the method returns the specified `bool` value.
- [NotNullIfNotNull](xref:System.Diagnostics.CodeAnalysis.NotNullIfNotNullAttribute): A return value isn't null if the input argument for the specified parameter isn't null.
- [DoesNotReturn](xref:System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute): A method never returns. In other words, it always throws an exception.
- [DoesNotReturnIf](xref:System.Diagnostics.CodeAnalysis.DoesNotReturnIfAttribute): This method never returns if the associated `bool` parameter has the specified value.
