---
title: "Reference Types (C# Reference)"
ms.date: 07/20/2015
f1_keywords: 
  - "cs.referencetypes"
helpviewer_keywords: 
  - "reference types [C#]"
  - "C# language, reference types"
  - "types [C#], reference types"
ms.assetid: 801cf030-6e2d-4a0d-9daf-1431b0c31f47
---
# Reference Types (C# Reference)
There are two kinds of types in C#: reference types and value types. Variables of reference types store references to their data (objects), while variables of value types directly contain their data. With reference types, two variables can reference the same object; therefore, operations on one variable can affect the object referenced by the other variable. With value types, each variable has its own copy of the data, and it is not possible for operations on one variable to affect the other (except in the case of in, ref and out parameter variables; see [in](../../../csharp/language-reference/keywords/in-parameter-modifier.md), [ref](../../../csharp/language-reference/keywords/ref.md) and [out](../../../csharp/language-reference/keywords/out-parameter-modifier.md) parameter modifier).  
  
 The following keywords are used to declare reference types:  
  
-   [class](../../../csharp/language-reference/keywords/class.md)  
  
-   [interface](../../../csharp/language-reference/keywords/interface.md)  
  
-   [delegate](../../../csharp/language-reference/keywords/delegate.md)  
  
 C# also provides the following built-in reference types:  
  
-   [dynamic](../../../csharp/language-reference/keywords/dynamic.md)  
  
-   [object](../../../csharp/language-reference/keywords/object.md)  
  
-   [string](../../../csharp/language-reference/keywords/string.md)  

  
## Example
When working with these two examples, it's important to keep in mind that
both types behave differently.
It's also good to know that Reference Types variables holds the reference to the allocated memory location
on the heap, while value types holds the value itself on the stack.


## Value Types
What happens with value types is that the
value get copied over to the destination but the origin isn't effected.
```csharp
class Program
    {
        static void Main(string[] args)
        {
            //Origin
            int x = 50;
            //Pass x into the ChangeValue method.
            ChangeValue(x);

            Console.WriteLine(x);
            //Output: 50
        }
        
        public static void ChangeValue(int x)
        {
            x = 100;
        }
}
```
The value of x is merely copied over to the method and that's why the origin doesnt change.
If we look at this from a stack point of view, we can see that both the variable and it's corresponding
value is stored there.
This however is not the case with reference types.


## Reference Types

When it comes to reference types, what's being stored on the heap is not just the variable and a value.
It's actually a reference pointing to the memory location on the heap where it's been allocated for said object.

```text
    --- Stack ---
---------------------
|       Varga       | //Variable portion
|-------------------|
| reference to heap | //Data portion
---------------------

    --- Heap ---
---------------------
|       Name        |
|       Age         |
---------------------
```

```csharp
    Programmer Varga = new Programmer();
    Varga.Age = "Chris";
    Varga.Age = 20;
```

Right now there's been memory allocated on the heap for the object.
And what's stored on the stack is the variable but not the ```Name ``` and the ```Age ```
Because they are located in the memory that has been allocated for this object on the heap.

```text
                 --- Stack ---
----------------------------------------------
|                   Daniel                   | //Variable portion
|--------------------------------------------|
| Points to the memory allocated for 'Varga' | //Data portion
----------------------------------------------
```

By declaring a new Programmer variable and assining it the value
of the previously created object ```Varga ```,
What's essentially happening is that we are not passing over the values of the object,
we are passing over the address to that memory location on the heap

```csharp
Programmer Daniel = Varga;
Daniel.Age = 22;
```
And by doing a similar ```Change(); ``` example, we can see how just how these two types react differently.
```csharp
class Program
    {
        static void Main(string[] args)
        {
            Programmer Carl = new Programmer();
            Carl.Name = "Carl";
            Carl.Age = 34;
            ChangeValue(Carl);

            Console.WriteLine($"Carls name has now changed to {Carl.Name} " +
                              $"and his age is now {Carl.Age}.");
            //Output: Carls name has now changed to George and his age is now 20.
        }

        public static void ChangeValue(Programmer p)
        {
            p.Name = "George";
            p.Age = 20;
        }
    }

    public class Programmer
    {
        public string Name;
        public int Age;
    }
```

With reference types you are accessing the allocated memory location
on the heap where the data corresponding to that object is stored
so that you can manipulate that data.


## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Types](../../../csharp/language-reference/keywords/types.md)  
 [Value Types](../../../csharp/language-reference/keywords/value-types.md)  
 [Stack Allocation](https://docs.microsoft.com/sv-se/cpp/build/stack-allocation)  
 [Heap](https://docs.microsoft.com/sv-se/cpp/mfc/memory-management-heap-allocation)  

