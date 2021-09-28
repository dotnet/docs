---
title: "Variance in Generic Interfaces (C#)"
description: View variance support information for generic interfaces, including updated information for existing interfaces in .NET Framework 4 and 4.5.
ms.date: 06/06/2019
ms.assetid: 4828a8f9-48c0-4128-9749-7fcd6bf19a06
---

# Variance in Generic Interfaces (C#)

.NET Framework 4 introduced variance support for several existing generic interfaces. Variance support enables implicit conversion of classes that implement these interfaces.

Starting with .NET Framework 4, the following interfaces are variant:

- <xref:System.Collections.Generic.IEnumerable%601> (T is covariant)

- <xref:System.Collections.Generic.IEnumerator%601> (T is covariant)

- <xref:System.Linq.IQueryable%601> (T is covariant)

- <xref:System.Linq.IGrouping%602> (`TKey` and `TElement` are covariant)

- <xref:System.Collections.Generic.IComparer%601> (T is contravariant)

- <xref:System.Collections.Generic.IEqualityComparer%601> (T is contravariant)

- <xref:System.IComparable%601> (T is contravariant)

Starting with .NET Framework 4.5, the following interfaces are variant:

- <xref:System.Collections.Generic.IReadOnlyList%601> (T is covariant)

- <xref:System.Collections.Generic.IReadOnlyCollection%601> (T is covariant)

Covariance permits a method to have a more derived return type than that defined by the generic type parameter of the interface. To illustrate the covariance feature, consider these generic interfaces: `IEnumerable<Object>` and `IEnumerable<String>`. The `IEnumerable<String>` interface does not inherit the `IEnumerable<Object>` interface. However, the `String` type does inherit the `Object` type, and in some cases you may want to assign objects of these interfaces to each other. This is shown in the following code example.

```csharp
IEnumerable<String> strings = new List<String>();
IEnumerable<Object> objects = strings;
```

In earlier versions of .NET Framework, this code causes a compilation error in C# and, if `Option Strict` is on, in Visual Basic. But now you can use `strings` instead of `objects`, as shown in the previous example, because the <xref:System.Collections.Generic.IEnumerable%601> interface is covariant.

Contravariance permits a method to have argument types that are less derived than that specified by the generic parameter of the interface. To illustrate contravariance, assume that you have created a `BaseComparer` class to compare instances of the `BaseClass` class. The `BaseComparer` class implements the `IEqualityComparer<BaseClass>` interface. Because the <xref:System.Collections.Generic.IEqualityComparer%601> interface is now contravariant, you can use `BaseComparer` to compare instances of classes that inherit the `BaseClass` class. This is shown in the following code example.

```csharp
// Simple hierarchy of classes.
class BaseClass { }
class DerivedClass : BaseClass { }

// Comparer class.
class BaseComparer : IEqualityComparer<BaseClass>
{
    public int GetHashCode(BaseClass baseInstance)
    {
        return baseInstance.GetHashCode();
    }
    public bool Equals(BaseClass x, BaseClass y)
    {
        return x == y;
    }
}
class Program
{
    static void Test()
    {
        IEqualityComparer<BaseClass> baseComparer = new BaseComparer();

        // Implicit conversion of IEqualityComparer<BaseClass> to
        // IEqualityComparer<DerivedClass>.
        IEqualityComparer<DerivedClass> childComparer = baseComparer;
    }
}
```

For more examples, see [Using Variance in Interfaces for Generic Collections (C#)](./using-variance-in-interfaces-for-generic-collections.md).

Variance in generic interfaces is supported for reference types only. Value types do not support variance. For example, `IEnumerable<int>` cannot be implicitly converted to `IEnumerable<object>`, because integers are represented by a value type.

```csharp
IEnumerable<int> integers = new List<int>();
// The following statement generates a compiler error,
// because int is a value type.
// IEnumerable<Object> objects = integers;
```

It is also important to remember that classes that implement variant interfaces are still invariant. For example, although <xref:System.Collections.Generic.List%601> implements the covariant interface <xref:System.Collections.Generic.IEnumerable%601>, you cannot implicitly convert `List<String>` to `List<Object>`. This is illustrated in the following code example.

```csharp
// The following line generates a compiler error
// because classes are invariant.
// List<Object> list = new List<String>();

// You can use the interface object instead.
IEnumerable<Object> listObjects = new List<String>();
```

## See also

- [Using Variance in Interfaces for Generic Collections (C#)](./using-variance-in-interfaces-for-generic-collections.md)
- [Creating Variant Generic Interfaces (C#)](./creating-variant-generic-interfaces.md)
- [Generic Interfaces](../../../../standard/generics/interfaces.md)
- [Variance in Delegates (C#)](./variance-in-delegates.md)
