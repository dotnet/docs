---
title: "Using Variance in Delegates"
description: Learn how to use variance in delegates using the included covariance and contravariance code examples.
ms.date: 07/20/2015
ms.assetid: 1638c95d-dc8b-40c1-972c-c2dcf84be55e
---
# Using Variance in Delegates (C#)

When you assign a method to a delegate, *covariance* and *contravariance* provide flexibility for matching a delegate type with a method signature. Covariance permits a method to have return type that is more derived than that defined in the delegate. Contravariance permits a method that has parameter types that are less derived than those in the delegate type.  
  
## Example 1: Covariance  
  
### Description  

 This example demonstrates how delegates can be used with methods that have return types that are derived from the return type in the delegate signature. The data type returned by `DogsHandler` is of type `Dogs`, which derives from the `Mammals` type that is defined in the delegate.  
  
### Code  
  
```csharp  
class Mammals {}  
class Dogs : Mammals {}  
  
class Program  
{  
    // Define the delegate.  
    public delegate Mammals HandlerMethod();  
  
    public static Mammals MammalsHandler()  
    {  
        return null;  
    }  
  
    public static Dogs DogsHandler()  
    {  
        return null;  
    }  
  
    static void Test()  
    {  
        HandlerMethod handlerMammals = MammalsHandler;  
  
        // Covariance enables this assignment.  
        HandlerMethod handlerDogs = DogsHandler;  
    }  
}  
```  
  
## Example 2: Contravariance  
  
### Description

This example demonstrates how delegates can be used with methods that have parameters whose types are base types of the delegate signature parameter type. With contravariance, you can use one event handler instead of separate handlers. The following example makes use of two delegates:

- A custom `KeyEventHandler` delegate that defines the signature of a key event. Its signature is:

   ```csharp
   public delegate void KeyEventHandler(object sender, KeyEventArgs e)
   ```

- A custom `MouseEventHandler` delegate that defines the signature of a mouse event. Its signature is:

   ```csharp
   public delegate void MouseEventHandler(object sender, MouseEventArgs e)
   ```

The example defines an event handler with an <xref:System.EventArgs> parameter and uses it to handle both key and mouse events. This works because <xref:System.EventArgs> is a base type of both the custom `KeyEventArgs` and `MouseEventArgs` classes defined in the example. Contravariance allows a method that accepts a base type parameter to be used for events that provide derived type parameters.

### How contravariance works in this example

When you subscribe to an event, the compiler checks if your event handler method is compatible with the event's delegate signature. With contravariance:

1. The `KeyDown` event expects a method that takes `KeyEventArgs`.
1. The `MouseClick` event expects a method that takes `MouseEventArgs`.  
1. Your `MultiHandler` method takes the base type `EventArgs`.
1. Since `KeyEventArgs` and `MouseEventArgs` both inherit from `EventArgs`, they can be safely passed to a method expecting `EventArgs`.
1. The compiler allows this assignment because it's safe - the `MultiHandler` can work with any `EventArgs` instance.

This is contravariance in action: you can use a method with a "less specific" (base type) parameter where a "more specific" (derived type) parameter is expected.
  
### Code  

:::code language="csharp" source="snippets/using-variance-in-delegates/ContravarianceExample.cs" id="snippet1":::

### Key points about contravariance

:::code language="csharp" source="snippets/using-variance-in-delegates/ContravarianceExample.cs" id="snippet2":::

When you run this example, you'll see that the same `MultiHandler` method successfully handles both key and mouse events, demonstrating how contravariance enables more flexible and reusable event handling code.  
  
## See also

- [Variance in Delegates (C#)](./variance-in-delegates.md)
- [Using Variance for Func and Action Generic Delegates (C#)](./using-variance-for-func-and-action-generic-delegates.md)
