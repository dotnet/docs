---
title: "Instance Constructors - C# Programming Guide"
description: Instance constructors in C# create and initialize any instance member variables when you use the new expression to create an object of a class.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "constructors [C#], instance constructors"
  - "instance constructors [C#]"
ms.assetid: 24663779-c1e5-4af4-a942-ca554e4c542d
---
# Instance Constructors (C# Programming Guide)

Instance constructors are used to create and initialize any instance member variables when you use the [new](../../language-reference/operators/new-operator.md) expression to create an object of a [class](../../language-reference/keywords/class.md). To initialize a [static](../../language-reference/keywords/static.md) class, or static variables in a non-static class, you define a static constructor. For more information, see [Static Constructors](./static-constructors.md).  
  
 The following example shows an instance constructor:  
  
 [!code-csharp[CoordsWithParameterlessConstructorOnly#1](snippets/instance-constructors/coords/Program.cs#1)]
  
> [!NOTE]
> For clarity, this class contains public fields. The use of public fields is not a recommended programming practice because it allows any method anywhere in a program unrestricted and unverified access to an object's inner workings. Data members should generally be private, and should be accessed only through class methods and properties.  
  
 This instance constructor is called whenever an object based on the `Coords` class is created. A constructor like this one, which takes no arguments, is called a *parameterless constructor*. However, it is often useful to provide additional constructors. For example, we can add a constructor to the `Coords` class that allows us to specify the initial values for the data members:  
  
 [!code-csharp[TwoArgumentConstructor#2](snippets/instance-constructors/coords/Program.cs#2)]
  
 This allows `Coords` objects to be created with default or specific initial values, like this:  
  
 [!code-csharp[InstantiatingCoords#3](snippets/instance-constructors/coords/Program.cs#3)]
  
 If a class does not have a constructor, a parameterless constructor is automatically generated and default values are used to initialize the object fields. For example, an [int](../../language-reference/builtin-types/integral-numeric-types.md) is initialized to 0. For information about the type default values, see [Default values of C# types](../../language-reference/builtin-types/default-values.md). Therefore, because the `Coords` class parameterless constructor initializes all data members to zero, it can be removed altogether without changing how the class works. A complete example using multiple constructors is provided in Example 1 later in this topic, and an example of an automatically generated constructor is provided in Example 2.  
  
 Instance constructors can also be used to call the instance constructors of base classes. The class constructor can invoke the constructor of the base class through the initializer, as follows:  
  
```csharp
class Circle : Shape
{
    public Circle(double radius)
        : base(radius, 0)
    {
    }
}
```
  
 In this example, the `Circle` class passes values representing radius and height to the constructor provided by `Shape` from which `Circle` is derived. A complete example using `Shape` and `Circle` appears in this topic as Example 3.  
  
## Example 1  

 The following example demonstrates a class with two class constructors, one without parameters and one with two parameters.  
  
 [!code-csharp[CoordsFullExample#4](snippets/instance-constructors/coords/Program.cs#4)]
  
## Example 2  

 In this example, the class `Person` does not have any constructors, in which case, a parameterless constructor is automatically provided and the fields are initialized to their default values.  
  
 [!code-csharp[Person](snippets/instance-constructors/person/Program.cs)]
  
 Notice that the default value of `age` is `0` and the default value of `name` is `null`.
  
## Example 3  

 The following example demonstrates using the base class initializer. The `Circle` class is derived from the general class `Shape`, and the `Cylinder` class is derived from the `Circle` class. The constructor on each derived class is using its base class initializer.  
  
 [!code-csharp[ShapesExample](snippets/instance-constructors/shapes/Program.cs)]
  
 For more examples on invoking the base class constructors, see [virtual](../../language-reference/keywords/virtual.md), [override](../../language-reference/keywords/override.md), and [base](../../language-reference/keywords/base.md).  
  
## See also

- [C# Programming Guide](../index.md)
- [Classes, structs, and records](/dotnet/csharp/fundamentals/object-oriented)
- [Constructors](./constructors.md)
- [Finalizers](./finalizers.md)
- [static](../../language-reference/keywords/static.md)
