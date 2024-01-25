---
title: System.Delegate.CreateDelegate methods
description: Learn about the System.Delegate.CreateDelegate methods.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
---
# System.Delegate.CreateDelegate methods

[!INCLUDE [context](includes/context.md)]

The <xref:System.Delegate.CreateDelegate%2A> methods create a delegate of a specified type.

## <xref:System.Delegate.CreateDelegate(System.Type,System.Reflection.MethodInfo)> method

This method overload is equivalent to calling the <xref:System.Delegate.CreateDelegate(System.Type,System.Reflection.MethodInfo,System.Boolean)> method overload and specifying `true` for `throwOnBindFailure`.

### Examples

This section contains two code examples. The first example demonstrates the two kinds of delegates that can be created with this method overload: open over an instance method and open over a static method.

The second code example demonstrates compatible parameter types and return types.

#### Example 1

The following code example demonstrates the two ways a delegate can be created using this overload of the <xref:System.Delegate.CreateDelegate%2A> method.

> [!NOTE]
> There are two overloads of the <xref:System.Delegate.CreateDelegate%2A> method that specify a <xref:System.Reflection.MethodInfo> but not a first argument; their functionality is the same except that one allows you to specify whether to throw on failure to bind, and the other always throws. This code example uses both overloads.

The example declares a class `C` with a static method `M2` and an instance method `M1`, and two delegate types: `D1` takes an instance of `C` and a string, and `D2` takes a string.

A second class named `Example` contains the code that creates the delegates.

- A delegate of type `D1`, representing an open instance method, is created for the instance method `M1`. An instance must be passed when the delegate is invoked.
- A delegate of type `D2`, representing an open static method, is created for the static method `M2`.

:::code language="csharp" source="./snippets/System/Delegate/CreateDelegate/csharp/openClosedOver.cs" interactive="try-dotnet" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Delegate/CreateDelegate/fsharp/openClosedOver.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Delegate/CreateDelegate/vb/openClosedOver.vb" id="Snippet1":::

#### Example 2

The following code example demonstrates compatibility of parameter types and return types.

The code example defines a base class named `Base` and a class named `Derived` that derives from `Base`. The derived class has a `static` (`Shared` in Visual Basic) method named `MyMethod` with one parameter of type `Base` and a return type of `Derived`. The code example also defines a delegate named `Example` that has one parameter of type `Derived` and a return type of `Base`.

The code example demonstrates that the delegate named `Example` can be used to represent the method `MyMethod`. The method can be bound to the delegate because:

- The parameter type of the delegate (`Derived`) is more restrictive than the parameter type of `MyMethod` (`Base`), so that it is always safe to pass the argument of the delegate to `MyMethod`.
- The return type of `MyMethod` (`Derived`) is more restrictive than the parameter type of the delegate (`Base`), so that it is always safe to cast the return type of the method to the return type of the delegate.

The code example produces no output.

:::code language="csharp" source="./snippets/System/Delegate/CreateDelegate/csharp/source1.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Delegate/CreateDelegate/fsharp/source1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Delegate/CreateDelegate/vb/source.vb" id="Snippet1":::

## <xref:System.Delegate.CreateDelegate(System.Type,System.Object,System.Reflection.MethodInfo)> and <xref:System.Delegate.CreateDelegate(System.Type,System.Object,System.Reflection.MethodInfo,System.Boolean)> methods

The functionality of these two overloads is the same except that one allows you to specify whether to throw on failure to bind, and the other always throws.

The delegate type and the method must have compatible return types. That is, the return type of `method` must be assignable to the return type of `type`.

`firstArgument`, the second parameter to these overloads, is the first argument of the method the delegate represents. If `firstArgument` is supplied, it is passed to `method` every time the delegate is invoked; `firstArgument` is said to be bound to the delegate, and the delegate is said to be closed over its first argument. If `method` is `static` (`Shared` in Visual Basic), the argument list supplied when invoking the delegate includes all parameters except the first; if `method` is an instance method, then `firstArgument` is passed to the hidden instance parameter (represented by `this` in C#, or by `Me` in Visual Basic).

If `firstArgument` is supplied, the first parameter of `method` must be a reference type, and `firstArgument` must be compatible with that type.

> [!IMPORTANT]
> If `method` is `static` (`Shared` in Visual Basic) and its first parameter is of type <xref:System.Object> or <xref:System.ValueType>, then `firstArgument` can be a value type. In this case `firstArgument` is automatically boxed. Automatic boxing does not occur for any other arguments, as it would in a C# or Visual Basic function call.

If `firstArgument` is a null reference and `method` is an instance method, the result depends on the signatures of the delegate type `type` and of `method`:

- If the signature of `type` explicitly includes the hidden first parameter of `method`, the delegate is said to represent an open instance method. When the delegate is invoked, the first argument in the argument list is passed to the hidden instance parameter of `method`.
- If the signatures of `method` and `type` match (that is, all parameter types are compatible), then the delegate is said to be closed over a null reference. Invoking the delegate is like calling an instance method on a null instance, which is not a particularly useful thing to do.

If `firstArgument` is a null reference and `method` is static, the result depends on the signatures of the delegate type `type` and of `method`:

- If the signature of `method` and `type` match (that is, all parameter types are compatible), the delegate is said to represent an open static method. This is the most common case for static methods. In this case, you can get slightly better performance by using the <xref:System.Delegate.CreateDelegate(System.Type,System.Reflection.MethodInfo)> method overload.
- If the signature of `type` begins with the second parameter of `method` and the rest of the parameter types are compatible, then the delegate is said to be closed over a null reference. When the delegate is invoked, a null reference is passed to the first parameter of `method`.

### Example

The following code example shows all the methods a single delegate type can represent: closed over an instance method, open over an instance method, open over a static method, and closed over a static method.

The code example defines two classes, `C` and `F`, and a delegate type `D` with one argument of type `C`. The classes have matching static and instance methods `M1`, `M3`, and `M4`, and class `C` also has an instance method `M2` that has no arguments.

A third class named `Example` contains the code that creates the delegates.

- Delegates are created for instance method `M1` of type `C` and type `F`; each is closed over an instance of the respective type. Method `M1` of type `C` displays the `ID` properties of the bound instance and of the argument.
- A delegate is created for method `M2` of type `C`. This is an open instance delegate, in which the argument of the delegate represents the hidden first argument on the instance method. The method has no other arguments. It is called as if it were a static method.
- Delegates are created for static method `M3` of type `C` and type `F`; these are open static delegates.
- Finally, delegates are created for static method `M4` of type `C` and type `F`; each method has the declaring type as its first argument, and an instance of the type is supplied, so the delegates are closed over their first arguments. Method `M4` of type `C` displays the `ID` properties of the bound instance and of the argument.

:::code language="csharp" source="./snippets/System/Delegate/CreateDelegate/csharp/source.cs" interactive="try-dotnet" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Delegate/CreateDelegate/fsharp/source.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Delegate/CreateDelegate/vb/source1.vb" id="Snippet1":::

## Compatible parameter types and return type

The parameter types and return type of a delegate created using this method overload must be compatible with the parameter types and return type of the method the delegate represents; the types do not have to match exactly.

A parameter of a delegate is compatible with the corresponding parameter of a method if the type of the delegate parameter is more restrictive than the type of the method parameter, because this guarantees that an argument passed to the delegate can be passed safely to the method.

Similarly, the return type of a delegate is compatible with the return type of a method if the return type of the method is more restrictive than the return type of the delegate, because this guarantees that the return value of the method can be cast safely to the return type of the delegate.

For example, a delegate with a parameter of type <xref:System.Collections.Hashtable> and a return type of <xref:System.Object> can represent a method with a parameter of type <xref:System.Object> and a return value of type <xref:System.Collections.Hashtable>.

## Determine the methods a delegate can represent

Another useful way to think of the flexibility provided by the <xref:System.Delegate.CreateDelegate(System.Type,System.Object,System.Reflection.MethodInfo)> overload is that any given delegate can represent four different combinations of method signature and method kind (static versus instance). Consider a delegate type `D` with one argument of type `C`. The following describes the methods `D` can represent, ignoring the return type since it must match in all cases:

- `D` can represent any instance method that has exactly one argument of type `C`, regardless of what type the instance method belongs to. When <xref:System.Delegate.CreateDelegate%2A> is called, `firstArgument` is an instance of the type `method` belongs to, and the resulting delegate is said to be closed over that instance. (Trivially, `D` can also be closed over a null reference if `firstArgument` is a null reference.)

- `D` can represent an instance method of `C` that has no arguments. When <xref:System.Delegate.CreateDelegate%2A> is called, `firstArgument` is a null reference. The resulting delegate represents an open instance method, and an instance of `C` must be supplied each time it is invoked.

- `D` can represent a static method that takes one argument of type `C`, and that method can belong to any type. When <xref:System.Delegate.CreateDelegate%2A> is called, `firstArgument` is a null reference. The resulting delegate represents an open static method, and an instance of `C` must be supplied each time it is invoked.

- `D` can represent a static method that belongs to type `F` and has two arguments, of type `F` and type `C`. When <xref:System.Delegate.CreateDelegate%2A> is called, `firstArgument` is an instance of `F`. The resulting delegate represents a static method that is closed over that instance of `F`. Note that in the case where `F` and `C` are the same type, the static method has two arguments of that type. (In this case, `D` is closed over a null reference if `firstArgument` is a null reference.)
