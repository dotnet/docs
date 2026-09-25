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

Starting with F# 11, a delegate constructed from a compatible named function or method can point directly at that method, instead of a generated closure's `Invoke` method. Reflection-based frameworks then see the original parameter names and attributes.

For example, [ASP.NET Core Minimal API parameter binding](/aspnet/core/fundamentals/minimal-apis/parameter-binding) uses route names and binding attributes to populate handler arguments:

:::code language="fsharp" source="snippets/delegates/Program.fs" id="Handler":::

The delegate's <xref:System.Delegate.Method> preserves the metadata that identifies the route argument, service, and header:

:::code language="fsharp" source="snippets/delegates/Program.fs" id="Metadata":::

Use this project file and the complete `Program.fs` sample:

:::code language="xml" source="snippets/delegates/ShipmentApi.fsproj":::

:::code language="fsharp" source="snippets/delegates/Program.fs" id="App":::

Run `dotnet run -- --urls http://127.0.0.1:5080`, then send:

```console
curl -H "X-Customer: Ada" http://127.0.0.1:5080/shipments/SHP-1042
```

The response is `Ada: SHP-1042 is Dispatched`. The example demonstrates binding, not input validation: it doesn't reject a missing customer header. Add validation if your application requires one.

This example uses ASP.NET Core's delegate-based request binding; it doesn't establish compatibility with every source generator, OpenAPI integration, or Native AOT endpoint-generation path.

### Which targets are direct?

The compiler recognizes transparent forwarding to known functions and methods. `Func<...>(namedFunction)` can use direct construction in both optimized and unoptimized builds. An explicit forwarding lambda, such as `Func<_,_>(fun x -> namedFunction x)`, retains its wrapper in unoptimized builds so the lambda's debug information remains available.

Captures, reordered or converted arguments, mandatory inline expansion, and other adaptations can require a closure. Don't assume every delegate has a null `Target`, or that every F# function value identifies a single method. Prefer the named-function form when a framework needs the method's metadata.

Direct delegates with the same method and receiver compare equal, which helps event unsubscription and <xref:System.Delegate.Remove(System.Delegate,System.Delegate)> work as expected.

> [!IMPORTANT]
> A null instance receiver can now fail when the delegate is constructed, rather than when it is invoked. A non-virtual instance target can throw `ArgumentException` at construction; a virtual target can throw `NullReferenceException`. Validate receivers before constructing delegates.

When a conversion still needs generated parameters and the function supplies no useful names, the compiler can use parameter names from the delegate's `Invoke` signature. This fallback doesn't replace preservation of the original method and its attributes.

## See also

- [F# Language Reference](index.md)
- [Parameters and Arguments](parameters-and-arguments.md)
- [Events](./members/events.md)
