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
```csharp
    class Program
    {
        static void Main(string[] args)
        {
            //Value Types
            //What happends with value types is that the
            //value get copied over to the destination but the origin isn't effected.

            //Origin
            int x = 50;
            //Pass x into the ChangeValue method.
            ChangeValue(x);

            Console.WriteLine(x);
            //Output: 50


            //Reference Types
            //The variable 'Varga' is stored on the stack with a reference to the address
            //Where the memory has been allocated for 'new Programmer'.

            //    --- Stack ---
            //---------------------
            //|       Varga       | //Variable Portion
            //|-------------------|
            //| reference to heap | //Data Portion
            //---------------------

            //    --- Heap ---
            //---------------------
            //|       Name        |
            //|       Age         |
            //---------------------
            Programmer Varga = new Programmer();
            Varga.Age = 20;
            
            //                 --- Stack ---
            //----------------------------------------------
            //|                   Chris                    | //Variable Portion
            //|--------------------------------------------|
            //| Points to the memory allocated for 'Varga' | //Data Portion
            //----------------------------------------------
            Programmer Chris = Varga;
            Chris.Age = 22;


            //By doing the same Change(); example we can see how these two types react differently.
            Programmer Carl = new Programmer();
            Carl.Name = "Carl";
            Carl.Age = 34;
            ChangeValue(Carl);

            Console.WriteLine($"Carls name has now changed to {Carl.Name} " +
                              $"and his age is now {Carl.Age}.");
            //Output: Carls name has now changed to George and his age is now 20.

            //With reference types you are accessing the same memory location
            //of where the data to that object is stored
            //so that you can manipulate that data.
        }

        public static void ChangeValue(int x)
        {
            x = 100;
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
````

## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Types](../../../csharp/language-reference/keywords/types.md)  
 [Value Types](../../../csharp/language-reference/keywords/value-types.md)
