---
title: "Creating Variant Generic Interfaces (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 30330ec4-9df2-4838-a535-6c406d0ed4df
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Creating Variant Generic Interfaces (C#)
You can declare generic type parameters in interfaces as covariant or contravariant. *Covariance* allows interface methods to have more derived return types than that defined by the generic type parameters. *Contravariance* allows interface methods to have argument types that are less derived than that specified by the generic parameters. A generic interface that has covariant or contravariant generic type parameters is called *variant*.  
  
> [!NOTE]
>  .NET Framework 4 introduced variance support for several existing generic interfaces. For the list of the variant interfaces in the .NET Framework, see [Variance in Generic Interfaces (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/variance-in-generic-interfaces.md).  
  
## Declaring Variant Generic Interfaces  
 You can declare variant generic interfaces by using the `in` and `out` keywords for generic type parameters.  
  
> [!IMPORTANT]
>  `ref`, `in`, and `out` parameters in C# cannot be variant. Value types also do not support variance.  
  
 You can declare a generic type parameter covariant by using the `out` keyword. The covariant type must satisfy the following conditions:  
  
-   The type is used only as a return type of interface methods and not used as a type of method arguments. This is illustrated in the following example, in which the type `R` is declared covariant.  
  
    ```csharp  
    interface ICovariant<out R>  
    {  
        R GetSomething();  
        // The following statement generates a compiler error.  
        // void SetSometing(R sampleArg);  
  
    }  
    ```  
  
     There is one exception to this rule. If you have a contravariant generic delegate as a method parameter, you can use the type as a generic type parameter for the delegate. This is illustrated by the type `R` in the following example. For more information, see [Variance in Delegates (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/variance-in-delegates.md) and [Using Variance for Func and Action Generic Delegates (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates.md).  
  
    ```csharp  
    interface ICovariant<out R>  
    {  
        void DoSomething(Action<R> callback);  
    }  
    ```  
  
-   The type is not used as a generic constraint for the interface methods. This is illustrated in the following code.  
  
    ```csharp  
    interface ICovariant<out R>  
    {  
        // The following statement generates a compiler error  
        // because you can use only contravariant or invariant types  
        // in generic contstraints.  
        // void DoSomething<T>() where T : R;  
    }  
    ```  
  
 You can declare a generic type parameter contravariant by using the `in` keyword. The contravariant type can be used only as a type of method arguments and not as a return type of interface methods. The contravariant type can also be used for generic constraints. The following code shows how to declare a contravariant interface and use a generic constraint for one of its methods.  
  
```csharp  
interface IContravariant<in A>  
{  
    void SetSomething(A sampleArg);  
    void DoSomething<T>() where T : A;  
    // The following statement generates a compiler error.  
    // A GetSomething();              
}  
```  
  
 It is also possible to support both covariance and contravariance in the same interface, but for different type parameters, as shown in the following code example.  
  
```csharp  
interface IVariant<out R, in A>  
{  
    R GetSomething();  
    void SetSomething(A sampleArg);  
    R GetSetSometings(A sampleArg);  
}  
```  
  
## Implementing Variant Generic Interfaces  
 You implement variant generic interfaces in classes by using the same syntax that is used for invariant interfaces. The following code example shows how to implement a covariant interface in a generic class.  
  
```csharp  
interface ICovariant<out R>  
{  
    R GetSomething();  
}  
class SampleImplementation<R> : ICovariant<R>  
{  
    public R GetSomething()  
    {  
        // Some code.  
        return default(R);  
    }  
}  
```  
  
 Classes that implement variant interfaces are invariant. For example, consider the following code.  
  
```csharp  
// The interface is covariant.  
ICovariant<Button> ibutton = new SampleImplementation<Button>();  
ICovariant<Object> iobj = ibutton;  
  
// The class is invariant.  
SampleImplementation<Button> button = new SampleImplementation<Button>();  
// The following statement generates a compiler error  
// because classes are invariant.  
// SampleImplementation<Object> obj = button;  
```  
  
## Extending Variant Generic Interfaces  
 When you extend a variant generic interface, you have to use the `in` and `out` keywords to explicitly specify whether the derived interface supports variance. The compiler does not infer the variance from the interface that is being extended. For example, consider the following interfaces.  
  
```csharp  
interface ICovariant<out T> { }  
interface IInvariant<T> : ICovariant<T> { }  
interface IExtCovariant<out T> : ICovariant<T> { }  
```  
  
 In the `IInvariant<T>` interface, the generic type parameter `T` is invariant, whereas in `IExtCovariant<out T>` the type parameter is covariant, although both interfaces extend the same interface. The same rule is applied to contravariant generic type parameters.  
  
 You can create an interface that extends both the interface where the generic type parameter `T` is covariant and the interface where it is contravariant if in the extending interface the generic type parameter `T` is invariant. This is illustrated in the following code example.  
  
```csharp  
interface ICovariant<out T> { }  
interface IContravariant<in T> { }  
interface IInvariant<T> : ICovariant<T>, IContravariant<T> { }  
```  
  
 However, if a generic type parameter `T` is declared covariant in one interface, you cannot declare it contravariant in the extending interface, or vice versa. This is illustrated in the following code example.  
  
```csharp  
interface ICovariant<out T> { }  
// The following statement generates a compiler error.  
// interface ICoContraVariant<in T> : ICovariant<T> { }  
```  
  
### Avoiding Ambiguity  
 When you implement variant generic interfaces, variance can sometimes lead to ambiguity. This should be avoided.  
  
 For example, if you explicitly implement the same variant generic interface with different generic type parameters in one class, it can create ambiguity. The compiler does not produce an error in this case, but it is not specified which interface implementation will be chosen at runtime. This could lead to subtle bugs in your code. Consider the following code example.  
  
```csharp  
// Simple class hierarchy.  
class Animal { }  
class Cat : Animal { }  
class Dog : Animal { }  
  
// This class introduces ambiguity  
// because IEnumerable<out T> is covariant.  
class Pets : IEnumerable<Cat>, IEnumerable<Dog>  
{  
    IEnumerator<Cat> IEnumerable<Cat>.GetEnumerator()  
    {  
        Console.WriteLine("Cat");  
        // Some code.  
        return null;  
    }  
  
    IEnumerator IEnumerable.GetEnumerator()  
    {  
        // Some code.  
        return null;  
    }  
  
    IEnumerator<Dog> IEnumerable<Dog>.GetEnumerator()  
    {  
        Console.WriteLine("Dog");  
        // Some code.  
        return null;  
    }  
}  
class Program  
{  
    public static void Test()  
    {  
        IEnumerable<Animal> pets = new Pets();  
        pets.GetEnumerator();  
    }  
}  
```  
  
 In this example, it is unspecified how the `pets.GetEnumerator` method chooses between `Cat` and `Dog`. This could cause problems in your code.  
  
## See Also  
 [Variance in Generic Interfaces (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/variance-in-generic-interfaces.md)  
 [Using Variance for Func and Action Generic Delegates (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates.md)
