---
title: "Using Delegates"
description: Learn how to use delegates. Delegates are an object-oriented, type safe, and secure type that safely encapsulates a method.
ms.date: 12/20/2024
helpviewer_keywords:
  - "delegates [C#], how to use"
ms.topic: concept-article
---
# Using Delegates (C# Programming Guide)

A [delegate](../../language-reference/builtin-types/reference-types.md) is a type that safely encapsulates a method, similar to a function pointer in C and C++. Unlike C function pointers, delegates are object-oriented, type safe, and secure. The following example declares a delegate named `Callback` that can encapsulate a method that takes a [string](../../language-reference/builtin-types/reference-types.md) as an argument and returns [void](../../language-reference/builtin-types/void.md):

:::code language="csharp" source="./snippets/UsingDelegates.cs" id="DeclareDelegate":::

A delegate object is normally constructed by providing the name of the method the delegate wraps, or with a [lambda expression](../../language-reference/operators/lambda-expressions.md). A delegate can be invoked once instantiated in this manner. Invoking a delegate calls the method attached to the delegate instance. The parameters passed to the delegate by the caller are passed to the method. The delegate returns the return value, if any, from the method. For example:

:::code language="csharp" source="./snippets/UsingDelegates.cs" id="DelegateMethod":::

:::code language="csharp" source="./snippets/UsingDelegates.cs" id="UseDelegate":::

Delegate types are derived from the <xref:System.Delegate> class in .NET. Delegate types are [sealed](../../language-reference/keywords/sealed.md), they can't be derived from, and it isn't possible to derive custom classes from <xref:System.Delegate>. Because the instantiated delegate is an object, it can be passed as an argument, or assigned to a property. A method can accept a delegate as a parameter, and call the delegate at some later time. This is known as an asynchronous callback, and is a common method of notifying a caller when a long process completes. When a delegate is used in this fashion, the code using the delegate doesn't need any knowledge of the implementation of the method being used. The functionality is similar to the encapsulation interfaces provide.

Another common use of callbacks is defining a custom comparison method and passing that delegate to a sort method. It allows the caller's code to become part of the sort algorithm. The following example method uses the `Del` type as a parameter:

:::code language="csharp" source="./snippets/UsingDelegates.cs" id="DelegateParameter":::

You can then pass the delegate created in the preceding example to that method:

:::code language="csharp" source="./snippets/UsingDelegates.cs" id="DelegateArgument":::

And receive the following output to the console:

```console
The number is: 3
```

`MethodWithCallback` doesn't need to call the console directly—it doesn't have to be designed with a console in mind. What `MethodWithCallback` does is prepare a string and pass the string to another method. A delegated method can use any number of parameters.

When a delegate is constructed to wrap an instance method, the delegate references both the instance and the method. A delegate has no knowledge of the instance type aside from the method it wraps. A delegate can refer to any type of object as long as there's a method on that object that matches the delegate signature. When a delegate is constructed to wrap a static method, it only references the method. Consider the following declarations:

:::code language="csharp" source="./snippets/UsingDelegates.cs" id="InstanceMethods":::

Along with the static `DelegateMethod` shown previously, we now have three methods that you can wrap in a `Del` instance.

A delegate can call more than one method when invoked, referred to as multicasting. To add an extra method to the delegate's list of methods—the invocation list—simply requires adding two delegates using the addition or addition assignment operators ('+' or '+='). For example:

:::code language="csharp" source="./snippets/UsingDelegates.cs" id="UseInstanceDelegates":::

The `allMethodsDelegate` contains three methods in its invocation list—`Method1`, `Method2`, and `DelegateMethod`. The original three delegates, `d1`, `d2`, and `d3`, remain unchanged. When `allMethodsDelegate` is invoked, all three methods are called in order. If the delegate uses reference parameters, the reference is passed sequentially to each of the three methods in turn, and any changes by one method are visible to the next method. When any of the methods throws an exception that isn't caught within the method, that exception is passed to the caller of the delegate. No subsequent methods in the invocation list are called. If the delegate has a return value and/or out parameters, it returns the return value and parameters of the last method invoked. To remove a method from the invocation list, use the [subtraction or subtraction assignment operators](../../language-reference/operators/subtraction-operator.md) (`-` or `-=`). For example:

:::code language="csharp" source="./snippets/UsingDelegates.cs" id="RemoveAddDelegates":::

Because delegate types are derived from `System.Delegate`, the methods and properties defined by that class can be called on the delegate. For example, to find the number of methods in a delegate's invocation list, you can write:

:::code language="csharp" source="./snippets/UsingDelegates.cs" id="GetInvocationList":::

Delegates with more than one method in their invocation list derive from <xref:System.MulticastDelegate>, which is a subclass of `System.Delegate`. The preceding code works in either case because both classes support `GetInvocationList`.

Multicast delegates are used extensively in event handling. Event source objects send event notifications to recipient objects that registered to receive that event. To register for an event, the recipient creates a method designed to handle the event, then creates a delegate for that method and passes the delegate to the event source. The source calls the delegate when the event occurs. The delegate then calls the event handling method on the recipient, delivering the event data. The event source defines the delegate type for a given event. For more, see [Events](../events/index.md).

Comparing delegates of two different types assigned at compile-time results in a compilation error. If the delegate instances are statically of the type `System.Delegate`, then the comparison is allowed, but returns false at run time. For example:

```csharp
delegate void Callback1();
delegate void Callback2();

static void method(Callback1 d, Callback2 e, System.Delegate f)
{
    // Compile-time error.
    Console.WriteLine(d == e);

    // OK at compile-time. False if the run-time type of f
    // is not the same as that of d.
    Console.WriteLine(d == f);
}
```

## See also

- [Delegates](./index.md)
- [Using Variance in Delegates](../concepts/covariance-contravariance/using-variance-in-delegates.md)
- [Variance in Delegates](../concepts/covariance-contravariance/variance-in-delegates.md)
- [Using Variance for Func and Action Generic Delegates](../concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates.md)
- [Events](../events/index.md)
