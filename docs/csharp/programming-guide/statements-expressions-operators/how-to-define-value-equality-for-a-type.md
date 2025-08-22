---
title: "How to define value equality for a class or struct"
description: Learn how to define value equality for a class or struct. See code examples and view available resources.
ms.topic: how-to
ms.date: 03/26/2021
ai-usage: ai-generated
helpviewer_keywords: 
  - "overriding Equals method [C#]"
  - "object equivalence [C#]"
  - "Equals method [C#], overriding"
  - "value equality [C#]"
  - "equivalence [C#]"
ms.assetid: 4084581e-b931-498b-9534-cf7ef5b68690
---
# How to define value equality for a class or struct (C# Programming Guide)

> [!TIP]
> **Consider using [records](../../fundamentals/types/records.md) first.** Records automatically implement value equality with minimal code, making them the recommended approach for most data-focused types. If you need custom value equality logic or cannot use records, continue with the manual implementation steps below.

When you define a class or struct, you decide whether it makes sense to create a custom definition of value equality (or equivalence) for the type. Typically, you implement value equality when you expect to add objects of the type to a collection, or when their primary purpose is to store a set of fields or properties. You can base your definition of value equality on a comparison of all the fields and properties in the type, or you can base the definition on a subset.

In either case, and in both classes and structs, your implementation should follow the five guarantees of equivalence (for the following rules, assume that `x`, `y` and `z` are not null):  
  
1. The reflexive property: `x.Equals(x)` returns `true`.
  
2. The symmetric property: `x.Equals(y)` returns the same value as `y.Equals(x)`.
  
3. The transitive property: if `(x.Equals(y) && y.Equals(z))` returns `true`, then `x.Equals(z)` returns `true`.
  
4. Successive invocations of `x.Equals(y)` return the same value as long as the objects referenced by x and y aren't modified.  
  
5. Any non-null value isn't equal to null. However, `x.Equals(y)` throws an exception when `x` is null. That breaks rules 1 or 2, depending on the argument to `Equals`.

Any struct that you define already has a default implementation of value equality that it inherits from the <xref:System.ValueType?displayProperty=nameWithType> override of the <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType> method. This implementation uses reflection to examine all the fields and properties in the type. Although this implementation produces correct results, it is relatively slow compared to a custom implementation that you write specifically for the type.  
  
The implementation details for value equality are different for classes and structs. However, both classes and structs require the same basic steps for implementing equality:  
  
1. **Override the [virtual](../../language-reference/keywords/virtual.md) <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType> method.** This provides polymorphic equality behavior, allowing your objects to be compared correctly when treated as `object` references. It ensures proper behavior in collections and when using polymorphism. In most cases, your implementation of `bool Equals( object obj )` should just call into the type-specific `Equals` method that is the implementation of the <xref:System.IEquatable%601?displayProperty=nameWithType> interface. (See step 2.)  
  
2. **Implement the <xref:System.IEquatable%601?displayProperty=nameWithType> interface by providing a type-specific `Equals` method.** This provides type-safe equality checking without boxing, resulting in better performance. It also avoids unnecessary casting and enables compile-time type checking. This is where the actual equivalence comparison is performed. For example, you might decide to define equality by comparing only one or two fields in your type. Don't throw exceptions from `Equals`. For classes that are related by inheritance:

   * This method should examine only fields that are declared in the class. It should call `base.Equals` to examine fields that are in the base class. (Don't call `base.Equals` if the type inherits directly from <xref:System.Object>, because the <xref:System.Object> implementation of <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType> performs a reference equality check.)

   * Two variables should be deemed equal only if the run-time types of the variables being compared are the same. Also, make sure that the `IEquatable` implementation of the `Equals` method for the run-time type is used if the run-time and compile-time types of a variable are different. One strategy for making sure run-time types are always compared correctly is to implement `IEquatable` only in `sealed` classes. For more information, see the [class example](#class-example) later in this article.
  
3. **Optional but recommended: Overload the [==](../../language-reference/operators/equality-operators.md#equality-operator-) and [!=](../../language-reference/operators/equality-operators.md#inequality-operator-) operators.** This provides consistent and intuitive syntax for equality comparisons, matching user expectations from built-in types. It ensures that `obj1 == obj2` and `obj1.Equals(obj2)` behave the same way.  
  
4. **Override <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType> so that two objects that have value equality produce the same hash code.** This is required for correct behavior in hash-based collections like `Dictionary<TKey,TValue>` and `HashSet<T>`. Objects that are equal must have equal hash codes, or these collections won't work correctly.  
  
5. **Optional: To support definitions for "greater than" or "less than," implement the <xref:System.IComparable%601> interface for your type, and also overload the [<=](../../language-reference/operators/comparison-operators.md#less-than-or-equal-operator-) and [>=](../../language-reference/operators/comparison-operators.md#greater-than-or-equal-operator-) operators.** This enables sorting operations and provides a complete ordering relationship for your type, useful when adding objects to sorted collections or when sorting arrays or lists.  

## Record example

The following example shows how records automatically implement value equality with minimal code. The first record `TwoDPoint` is a simple record type that automatically implements value equality. The second record `ThreeDPoint` demonstrates that records can be derived from other records and still maintain proper value equality behavior:

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/ValueEqualityRecord/Program.cs":::

Records provide several advantages for value equality:

- **Automatic implementation**: Records automatically implement `IEquatable<T>` and override `Equals(object?)`, `GetHashCode()`, and the `==`/`!=` operators.
- **Correct inheritance behavior**: Unlike the class example shown earlier, records handle inheritance scenarios correctly.
- **Immutability by default**: Records encourage immutable design, which works well with value equality semantics.
- **Concise syntax**: Positional parameters provide a compact way to define data types.
- **Better performance**: The compiler-generated equality implementation is optimized and doesn't use reflection like the default struct implementation.

Use records when your primary goal is to store data and you need value equality semantics.

> [!IMPORTANT]
> **Records with reference-equality members**: While records provide excellent value equality for basic data types, they don't automatically solve value equality for members that use reference equality. For example, if a record contains a `List<T>`, `Array`, or other reference types that don't implement value equality, two record instances with identical content in those members will still not be equal because the members use reference equality.
>
> ```csharp
> public record PersonWithHobbies(string Name, List<string> Hobbies);
> 
> var person1 = new PersonWithHobbies("Alice", new List<string> { "Reading", "Swimming" });
> var person2 = new PersonWithHobbies("Alice", new List<string> { "Reading", "Swimming" });
> 
> Console.WriteLine(person1.Equals(person2)); // False - different List instances!
> ```
>
> See the [Records with collections](#records-with-collections) section for solutions to this issue.

## Records with collections

When records contain collection types like `List<T>`, arrays, or other reference types that use reference equality, the automatic value equality behavior of records doesn't work as expected. This is because records use the `Equals` method of each member, and collection types typically use reference equality rather than comparing their contents.

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/RecordCollectionsIssue/Program.cs":::

### Solutions for records with collections

1. **Custom `IEquatable<T>` implementation**: Override the compiler-generated equality to provide content-based comparison for collection members.

2. **Use value types where possible**: Consider if your data can be represented with value types that naturally support value equality.

3. **Immutable collection patterns**: Design your records to work with the limitations by being explicit about when reference equality is acceptable.

4. **Consider composition over inheritance**: Sometimes restructuring the data model can avoid these equality complications.

The key insight is that records solve the *structural* equality problem but don't change the *semantic* equality behavior of the types they contain.

## Class example

The following example shows how to implement value equality in a class (reference type). This manual approach is needed when you can't use records or need custom equality logic:

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/ValueEqualityClass/Program.cs":::

On classes (reference types), the default implementation of both <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType> methods performs a reference equality comparison, not a value equality check. When an implementer overrides the virtual method, the purpose is to give it value equality semantics.

The `==` and `!=` operators can be used with classes even if the class does not overload them. However, the default behavior is to perform a reference equality check. In a class, if you overload the `Equals` method, you should overload the `==` and `!=` operators, but it is not required.

> [!IMPORTANT]
> The preceding example code may not handle every inheritance scenario the way you expect. Consider the following code:
>
> ```csharp
> TwoDPoint p1 = new ThreeDPoint(1, 2, 3);
> TwoDPoint p2 = new ThreeDPoint(1, 2, 4);
> Console.WriteLine(p1.Equals(p2)); // output: True
> ```
>
> This code reports that `p1` equals `p2` despite the difference in `z` values. The difference is ignored because the compiler picks the `TwoDPoint` implementation of `IEquatable` based on the compile-time type. This is a fundamental issue with polymorphic equality in inheritance hierarchies.
>
> The built-in value equality of `record` types handles scenarios like this correctly. If `TwoDPoint` and `ThreeDPoint` were `record` types, the result of `p1.Equals(p2)` would be `False`. For more information, see [Equality in `record` type inheritance hierarchies](../../language-reference/builtin-types/record.md#equality-in-inheritance-hierarchies). For classes that must use inheritance and value equality, see the [Polymorphic equality](#polymorphic-equality) section for a safer approach.

## Polymorphic equality

When implementing value equality in inheritance hierarchies with classes, the standard approach shown in the class example can lead to incorrect behavior when objects are used polymorphically. The issue occurs because `IEquatable<T>` implementations are chosen based on compile-time type, not runtime type.

### The problem with standard implementations

Consider this problematic scenario:

```csharp
TwoDPoint p1 = new ThreeDPoint(1, 2, 3);  // Declared as TwoDPoint
TwoDPoint p2 = new ThreeDPoint(1, 2, 4);  // Declared as TwoDPoint
Console.WriteLine(p1.Equals(p2)); // True - but should be False!
```

The comparison returns `True` because the compiler selects `TwoDPoint.Equals(TwoDPoint)` based on the declared type, ignoring the `Z` coordinate differences.

### Solution: Explicit interface implementation

A safer approach for polymorphic equality uses [explicit interface implementation](../interfaces/explicit-interface-implementation.md) for `IEquatable<T>`. This forces all equality comparisons to go through the virtual `Equals(object?)` method, which uses runtime type information:

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/ValueEqualityPolymorphic/Program.cs":::

### Key benefits of explicit interface implementation

- **Runtime type checking**: All equality comparisons use the `virtual Equals(object?)` method, ensuring runtime type compatibility.
- **Safe polymorphism**: Objects behave correctly regardless of their declared type.
- **Inheritance-friendly**: Derived classes can safely override the base implementation.
- **Collection compatibility**: Works correctly with hash-based collections like `Dictionary<TKey,TValue>` and `HashSet<T>`.

### When to use this approach

Use explicit interface implementation for `IEquatable<T>` when:

- You have inheritance hierarchies where value equality is important
- Objects might be used polymorphically (declared as base type, instantiated as derived type)
- You cannot use `record` types for your scenario
- You need reference types with value equality semantics

### Considerations

- **Performance**: Slight overhead from virtual method calls and type checking
- **Complexity**: More complex implementation than the standard approach
- **Testing**: Requires thorough testing of polymorphic scenarios to ensure correctness

## Struct example

The following example shows how to implement value equality in a struct (value type). While structs have default value equality, a custom implementation can improve performance:

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/ValueEqualityStruct/Program.cs":::
  
For structs, the default implementation of <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType> (which is the overridden version in <xref:System.ValueType?displayProperty=nameWithType>) performs a value equality check by using reflection to compare the values of every field in the type. Although this implementation produces correct results, it is relatively slow compared to a custom implementation that you write specifically for the type.

When you override the virtual `Equals` method in a struct, the purpose is to provide a more efficient means of performing the value equality check and optionally to base the comparison on some subset of the struct's fields or properties.
  
The [==](../../language-reference/operators/equality-operators.md#equality-operator-) and [!=](../../language-reference/operators/equality-operators.md#inequality-operator-) operators can't operate on a struct unless the struct explicitly overloads them.

## See also

- [Equality comparisons](equality-comparisons.md)
