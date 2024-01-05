---
title: System.Object class
description: Learn about the System.Object class.
ms.date: 12/31/2023
---
# System.Object class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Object> class is the ultimate base class of all .NET classes; it is the root of the type hierarchy.

Because all classes in .NET are derived from <xref:System.Object>, every method defined in the <xref:System.Object> class is available in all objects in the system. Derived classes can and do override some of these methods, including:

- <xref:System.Object.Equals%2A>: Supports comparisons between objects.
- <xref:System.Object.Finalize%2A>: Performs cleanup operations before an object is automatically reclaimed.
- <xref:System.Object.GetHashCode%2A>: Generates a number corresponding to the value of the object to support the use of a hash table.
- <xref:System.Object.ToString%2A>: Manufactures a human-readable text string that describes an instance of the class.

Languages typically don't require a class to declare inheritance from <xref:System.Object> because the inheritance is implicit.

## Performance considerations

If you're designing a class, such as a collection, that must handle any type of object, you can create class members that accept instances of the <xref:System.Object> class. However, the process of boxing and unboxing a type carries a performance cost. If you know your new class will frequently handle certain value types you can use one of two tactics to minimize the cost of boxing.

- Create a general method that accepts an <xref:System.Object> type, and a set of type-specific method overloads that accept each value type you expect your class to frequently handle. If a type-specific method exists that accepts the calling parameter type, no boxing occurs and the type-specific method is invoked. If there is no method argument that matches the calling parameter type, the parameter is boxed and the general method is invoked.
- Design your type and its members to use [generics](../../standard/generics.md). The common language runtime creates a closed generic type when you create an instance of your class and specify a generic type argument. The generic method is type-specific and can be invoked without boxing the calling parameter.

Although it's sometimes necessary to develop general purpose classes that accept and return <xref:System.Object> types, you can improve performance by also providing a type-specific class to handle a frequently used type. For example, providing a class that is specific to setting and getting Boolean values eliminates the cost of boxing and unboxing Boolean values.
