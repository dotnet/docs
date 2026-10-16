---
title: Delegates in F#
titleSuffix: ""
description: Learn how to work with delegates in F#.
ms.date: 09/25/2026
ai-usage: ai-assisted
---
# Delegates (F#)

A delegate represents a function call as an object. In F#, you ordinarily should use function values to represent functions as first-class values; however, delegates are used in the .NET Framework and so are needed when you interoperate with APIs that expect them. They may also be used when authoring libraries designed for use from other .NET Framework languages.

## Syntax

```fsharp
type delegate-typename = delegate of type1 -> type2
```

## Remarks

In the previous syntax, `type1` represents the argument type or types and `type2` represents the return type. The argument types that are represented by `type1` are automatically curried. This suggests that for this type you use a tuple form if the arguments of the target function are curried, and a parenthesized tuple for arguments that are already in the tuple form. The automatic currying removes a set of parentheses, leaving a tuple argument that matches the target method. Refer to the code example for the syntax you should use in each case.

Delegates can be attached to F# function values, and static or instance methods. F# function values can be passed directly as arguments to delegate constructors. For a static method, you construct the delegate by using the name of the class and the method. For an instance method, you provide the object instance and method in one argument. In both cases, the member access operator (`.`) is used.

The `Invoke` method on the delegate type calls the encapsulated function. Also, delegates can be passed as function values by referencing the Invoke method name without the parentheses.

The following code shows the syntax for creating delegates that represent various methods in a class. Depending on whether the method is a static method or an instance method, and whether it has arguments in the tuple form or the curried form, the syntax for declaring and assigning the delegate is a little different.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet4201.fs)]

The following code shows some of the different ways you can work with delegates.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet4202.fs)]

The output of the previous code example is as follows.

```console
aaaaa
bbbbb
ccccc
[|"aaa"; "bbb"|]
```

Names can be added to delegate parameters like so:

```fs
// http://www.pinvoke.net/default.aspx/user32/WinEventDelegate.html
type WinEventDelegate = delegate of hWinEventHook:nativeint * eventType:uint32 * hWnd:nativeint * idObject:int * idChild:int * dwEventThread:uint32 * dwmsEventTime:uint32 -> unit
```

Delegate parameter names are optional and will be shown in the `Invoke` method. They are not required to match the parameter names in the implementation. They are only allowed for the curried form but not the tupled form.

```fs
type D1 = delegate of item1: int * item2: string -> unit
let a = D1(fun a b -> printf "%s" b)
a.Invoke(item2 = "a", item1 = 1) // Calling with named arguments

type D2 = delegate of int * item2: string -> unit // Omitting one name
let b = D2(fun a b -> printf "%s" b)
b.Invoke(1, item2 = "a")
```

The output of the previous code example is as follows.

```console
aa
```

## Direct construction and framework metadata

To preserve parameter names and attributes for reflection-based frameworks, F# 11 can target a compatible named function or method directly instead of a generated wrapper.

For example, [ASP.NET Core Minimal API parameter binding](/aspnet/core/fundamentals/minimal-apis/parameter-binding) uses route names and binding attributes to populate handler arguments:

:::code language="fsharp" source="snippets/delegates/Program.fs" id="Handler":::

Check the original metadata through <xref:System.Delegate.Method>:

:::code language="fsharp" source="snippets/delegates/Program.fs" id="Metadata":::

For the complete runnable application, see the [sample project](https://github.com/dotnet/docs/blob/main/docs/fsharp/language-reference/snippets/delegates/ShipmentApi.fsproj).

### Which targets are direct?

Prefer `Func<...>(namedFunction)` for direct construction in both optimized and unoptimized builds. An explicit forwarding lambda retains its wrapper in unoptimized builds. Captures, argument adaptation, and mandatory inline expansion can also require wrappers.

Direct delegates with the same method and receiver compare equal. For reliable event unsubscription, retain and reuse the subscribed delegate.

> [!IMPORTANT]
> Validate instance receivers before direct delegate construction. A null receiver can throw `ArgumentException` for a non-virtual method or `NullReferenceException` for a virtual method before invocation.

```fsharp
let receiver: System.Text.StringBuilder = null
let callback = System.Func<char, System.Text.StringBuilder>(receiver.Append)
```

Wrappers can use parameter names from the delegate's `Invoke` signature when the function supplies none; they don't preserve the original method's metadata.

## See also

- [F# Language Reference](index.md)
- [Parameters and Arguments](parameters-and-arguments.md)
- [Events](./members/events.md)
