---
title: "Ref return values and ref locals (C# Guide)"
description: "Learn how to define and use ref return and ref local values"
author: "rpetrusha"
ms.author: "ronpet"
ms.date: "05/30/2017"
ms.topic: "article"
ms.prod: ".net"
ms.technology: "devlang-csharp"
ms.devlang: "csharp"
ms.assetid: "18cf7a4b-29f0-4b14-85b8-80af754aabd8"
---
# Ref returns and ref locals

Starting with C# 7, C# supports reference return values (ref returns). A reference return value allows a method to return a reference to an object, rather than a value, back to a caller. The caller can then choose to treat the returned object returned as if it were returned by value or by reference. A value returned by reference that the caller handles as a reference rather than a value is a ref local).

## What is a reference return value?

Most developers are familiar with passing an argument to a called method *by reference*. A called method's argument list includes a value passed by reference, and any changes made to its value by the called method are returned to the caller. A *reference return value* is the opposite:

- The called method's return value, rather than an argument passed to it, is a reference.

- The caller, rather than the called method, can modify the value returned by the method.

- Instead of modifications to the argument that are reflected in state of the object on the caller, modifications to the method's return value by the caller are reflected in the state of the object whose method was called.

Reference return values can produce more compact code, as well as allow an object to expose only the individual data items, such as an array element, that are of interest to the caller. This reduces the likelihood that the caller will inadvertently modify the object's state.

There are some restrictions on the value that a method can return as a reference return value. These include:

- The return value cannot be `void`. Attempting to define a method with a `void` reference return value generates compiler error CS1547, "Keyword 'void' cannot be used in this context."
 
- The return value cannot be a local variable in the method that returns it; it must have a scope that is outside the method that returns it. It can be an instance or static field of a class, or it can be an argument passed to the method. Attempting to return a local variable generates compiler error CS8168, "Cannot return local 'obj' by reference because it is not a ref local."

- The return value cannot be a `null`. Attempting to return `null` generates compiler error CS8156, "An expression cannot be used in this context because it may not be returned by reference."

   If a method with a ref return needs to return a null value, you can either return a null (uninstantiated) value for a reference type or a [nullable type](../nullable-types/index.md) for a value type.
 
- The return value cannot be a constant, an enumeration member, or a property of a `class` or `struct`. Attempting to return these generates compiler error CS8156, "An expression cannot be used in this context because it may not be returned by reference."

In addition, because an asynchronous method may return before it has finished execution and its return value is known, reference return values are not allowed on `async` methods.
 
## Defining a ref return value

You define a ref return value by adding the [ref](../../language-reference/keywords/ref.md) keyword to the return type of the method signature. For example, the following signature indicates that the `GetContactInformation` property returns a reference to a `Person` object to the caller:

```csharp
public ref Person GetContactInformation(string fname, string lname);
```

In addition, the name of the object returned by each [return](../../language-reference/keywords/return.md) statement in the method body must be preceded by the [ref](../../language-reference/keywords/ref.md) keyword. For example, the following `return` statement returns a `Person` object named `p` by reference:

```csharp
return ref p;
```

## Consuming a ref return value

A caller can handle a ref return value in either of two ways:

- As an ordinary value returned by value from a method. The caller can choose to ignore that the return value is a reference return value. In this case, any changes made to the value returned by the method call are not reflected in the state of the called type. If the returned value is a value type, any changes made to the value returned by the method call are not reflected in the state of the called type.

- As a reference return value. The caller must define the variable to which the reference return value is assigned as a [ref local](#ref-local), and any changes to the value returned by the method call are reflected in the state of the called type. 

## Ref locals

To handle the reference return value as a reference, the caller must declare the value to be a *ref local* by using the `ref` keyword. For example, if the value returned by the `Person.GetContactInfomation` method is to be consumed as a reference rather than a value, the method call appears as:

```csharp
ref Person p = ref contacts.GetContactInformation("Brandie", "Best");
```

Note that the `ref` keyword is used both before the local variable declaration *and* before the method call. Failure to include both `ref` keywords in the variable declaration and assignment results in compiler error CS8172, "Cannot initialize a by-reference variable with a value." 
 
Subsequent changes to the `Person` object returned by the method are reflected in the `contacts` object.

If `p` is not defined as a ref local by using the `ref` keyword, any changes made to `p` by the caller are not reflected in the `contacts` object.
 
## Ref returns and ref locals: an example

The following example defines a `NumberStore` class that stores an array of integer values. The `FindNumber` method returns by reference the first number that is greater than or equal to the number passed as an argument. If no number is greater than or equal to the argument, the method returns the number in index 0. 

[!CODE-cs[ref-returns](../../../../samples/snippets/csharp/programming-guide/ref-returns/ref-returns1.cs#1)]

The following example calls the `NumberStore.FindNumber` method to retrieve the first value that is greater than or equal to 16. The caller then doubles the value returned by the method. As the output from the example shows, this change is reflected in the value of the array elements of the `NumberStore` instance.

[!CODE-cs[ref-returns](../../../../samples/snippets/csharp/programming-guide/ref-returns/ref-returns1.cs#2)]

Without support for reference return values, such an operation is usually performed by returning the index of the array element along with its value. The caller can then use this index to modify the value in a separate method call. However, the caller can also modify the index to access and possibly modify other array values.  
 
## See also

[ref keyword](../../language-reference/keywords/ref.md)
