---
title: structs | .NET Core
description: structs in C# 
keywords:
author: BillWagner
manager: wpickett
ms.date: 2016/08/10
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.assetid: 88a74571-f741-4a31-a2b5-1ccf165535b8
ms.devlang: csharp

---

# Structs

Like classes, ***structs*** are data structures that can contain data members and function members, but unlike classes, structs are value types and do not require heap allocation. A variable of a struct type directly stores the data of the struct, whereas a variable of a class type stores a reference to a dynamically allocated object. Struct types do not support user-specified inheritance, and all struct types implicitly inherit from type `object`.

Structs are particularly useful for small data structures that have value semantics. Complex numbers, points in a coordinate system, or key-value pairs in a dictionary are all good examples of structs. The use of structs rather than classes for small data structures can make a large difference in the number of memory allocations an application performs. For example, the following program creates and initializes an array of 100 points. With `Point` implemented as a class, 101 separate objects are instantiated—one for the array and one each for the 100 elements.
```csharp
class Point
{
	public int x, y;
	public Point(int x, int y) 
	{
		this.x = x;
		this.y = y;
	}
}
class Example
{
	static void Main() 
	{
		Point[] points = new Point[100];
		for (int i = 0; i < 100; i++)
			points[i] = new Point(i, i);
	}
}
```
An alternative is to make Point a struct.
```csharp
struct Point
{
	public int x, y;
	public Point(int x, int y) 
	{
		this.x = x;
		this.y = y;
	}
}
```

Now, only one object is instantiated—the one for the array—and the `Point` instances are stored in-line in the array.

Struct constructors are invoked with the new operator, but that does not imply that memory is being allocated. Instead of dynamically allocating an object and returning a reference to it, a struct constructor simply returns the struct value itself (typically in a temporary location on the stack), and this value is then copied as necessary.

With classes, it is possible for two variables to reference the same object and thus possible for operations on one variable to affect the object referenced by the other variable. With structs, the variables each have their own copy of the data, and it is not possible for operations on one to affect the other. For example, the output produced by the following code fragment depends on whether Point is a class or a struct.

```csharp
Point a = new Point(10, 10);
Point b = a;
a.x = 20;
Console.WriteLine(b.x);
```

If `Point` is a class, the output is 20 because a and b reference the same object. If Point is a struct, the output is 10 because the assignment of a to b creates a copy of the value, and this copy is unaffected by the subsequent assignment to a.x.

The previous example highlights two of the limitations of structs. First, copying an entire struct is typically less efficient than copying an object reference, so assignment and value parameter passing can be more expensive with structs than with reference types. Second, except for `ref` and `out` parameters, it is not possible to create references to structs, which rules out their usage in a number of situations.
