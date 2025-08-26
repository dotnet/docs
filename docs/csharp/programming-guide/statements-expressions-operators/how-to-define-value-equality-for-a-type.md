---
title: "How to define value equality for a class or struct"
description: Learn how to define value equality for a class or struct. See code examples and view available resources.
ms.topic: how-to
ms.date: 03/26/2021
ai-usage: ai-assisted
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

- **Automatic implementation**: Records automatically implement <xref:System.IEquatable%601?displayProperty=nameWithType> and override <xref:System.Object.Equals%2A?displayProperty=nameWithType>, <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType>, and the `==`/`!=` operators.
- **Correct inheritance behavior**: Records implement `IEquatable<T>` using virtual methods that check the runtime type of both operands, ensuring correct behavior in inheritance hierarchies and polymorphic scenarios.
- **Immutability by default**: Records encourage immutable design, which works well with value equality semantics.
- **Concise syntax**: Positional parameters provide a compact way to define data types.
- **Better performance**: The compiler-generated equality implementation is optimized and doesn't use reflection like the default struct implementation.

Use records when your primary goal is to store data and you need value equality semantics.

## Records with members that use reference equality

When records contain members that use reference equality, the automatic value equality behavior of records doesn't work as expected. This applies to collections like <xref:System.Collections.Generic.List%601?displayProperty=nameWithType>, arrays, and other reference types that don't implement value-based equality (with the notable exception of <xref:System.String?displayProperty=nameWithType>, which does implement value equality).

> [!IMPORTANT]
> While records provide excellent value equality for basic data types, they don't automatically solve value equality for members that use reference equality. If a record contains a <xref:System.Collections.Generic.List%601?displayProperty=nameWithType>, <xref:System.Array?displayProperty=nameWithType>, or other reference types that don't implement value equality, two record instances with identical content in those members will still not be equal because the members use reference equality.
>
> ```csharp
> public record PersonWithHobbies(string Name, List<string> Hobbies);
> 
> var person1 = new PersonWithHobbies("Alice", new List<string> { "Reading", "Swimming" });
> var person2 = new PersonWithHobbies("Alice", new List<string> { "Reading", "Swimming" });
> 
> Console.WriteLine(person1.Equals(person2)); // False - different List instances!
> ```

This is because records use the <xref:System.Object.Equals%2A?displayProperty=nameWithType> method of each member, and collection types typically use reference equality rather than comparing their contents.

The following shows the problem:

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/RecordCollectionsIssue/Program.cs" id="ProblemExample":::

Here's how this behaves when you run the code:

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/RecordCollectionsIssue/Program.cs" id="ProblemDemonstration":::

### Solutions for records with reference-equality members

- **Custom <xref:System.IEquatable%601?displayProperty=nameWithType> implementation**: Replace the compiler-generated equality with a hand-coded version that provides content-based comparison for reference-equality members. For collections, implement element-by-element comparison using <xref:System.Linq.Enumerable.SequenceEqual%2A?displayProperty=nameWithType> or similar methods.

- **Use value types where possible**: Consider if your data can be represented with value types or immutable structures that naturally support value equality, such as <xref:System.Numerics.Vector%601?displayProperty=nameWithType> or <xref:System.Numerics.Plane>.

- **Use types with value-based equality**: For collections, consider using types that implement value-based equality or implement custom collection types that override <xref:System.Object.Equals%2A?displayProperty=nameWithType> to provide content-based comparison, such as <xref:System.Collections.Immutable.ImmutableArray%601?displayProperty=nameWithType> or <xref:System.Collections.Immutable.ImmutableList%601?displayProperty=nameWithType>.

- **Design with reference equality in mind**: Accept that some members will use reference equality and design your application logic accordingly, ensuring that you reuse the same instances when equality is important.

Here's an example of implementing custom equality for records with collections:

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/RecordCollectionsIssue/Program.cs" id="SolutionExample":::

This custom implementation works correctly:

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/RecordCollectionsIssue/Program.cs" id="SolutionDemonstration":::

The same issue affects arrays and other collection types:

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/RecordCollectionsIssue/Program.cs" id="OtherTypes":::

Arrays also use reference equality, producing the same unexpected results:

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/RecordCollectionsIssue/Program.cs" id="ArrayExample":::

Even readonly collections exhibit this reference equality behavior:

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/RecordCollectionsIssue/Program.cs" id="ImmutableExample":::

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

## Polymorphic equality

When implementing value equality in inheritance hierarchies with classes, the standard approach shown in the class example can lead to incorrect behavior when objects are used polymorphically. The issue occurs because <xref:System.IEquatable%601?displayProperty=nameWithType> implementations are chosen based on compile-time type, not runtime type.

### The problem with standard implementations

Consider this problematic scenario:

```csharp
TwoDPoint p1 = new ThreeDPoint(1, 2, 3);  // Declared as TwoDPoint
TwoDPoint p2 = new ThreeDPoint(1, 2, 4);  // Declared as TwoDPoint
Console.WriteLine(p1.Equals(p2)); // True - but should be False!
```

The comparison returns `True` because the compiler selects `TwoDPoint.Equals(TwoDPoint)` based on the declared type, ignoring the `Z` coordinate differences.

The key to correct polymorphic equality is ensuring that all equality comparisons use the virtual <xref:System.Object.Equals%2A?displayProperty=nameWithType> method, which can check runtime types and handle inheritance correctly. This can be achieved by using explicit interface implementation for <xref:System.IEquatable%601?displayProperty=nameWithType> that delegates to the virtual method:

The base class demonstrates the key patterns:

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/ValueEqualityPolymorphic/Program.cs" id="TwoDPointClass":::

The derived class correctly extends the equality logic:

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/ValueEqualityPolymorphic/Program.cs" id="ThreeDPointClass":::

Here's how this implementation handles the problematic polymorphic scenarios:

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/ValueEqualityPolymorphic/Program.cs" id="PolymorphicTest":::

The implementation also correctly handles direct type comparisons:

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/ValueEqualityPolymorphic/Program.cs" id="DirectTest":::

The equality implementation also works properly with collections:

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/ValueEqualityPolymorphic/Program.cs" id="CollectionTest":::

The preceding code demonstrates key elements to implementing value based equality:

- **Virtual `Equals(object?)` override**: The main equality logic happens in the virtual <xref:System.Object.Equals%2A?displayProperty=nameWithType> method, which is called regardless of compile-time type.
- **Runtime type checking**: Using `this.GetType() != p.GetType()` ensures that objects of different types are never considered equal.
- **Explicit interface implementation**: The <xref:System.IEquatable%601?displayProperty=nameWithType> implementation delegates to the virtual method, preventing compile-time type selection issues.
- **Protected virtual helper method**: The `protected virtual Equals(TwoDPoint? p)` method allows derived classes to override equality logic while maintaining type safety.

Use this pattern when:

- You have inheritance hierarchies where value equality is important
- Objects might be used polymorphically (declared as base type, instantiated as derived type)
- You need reference types with value equality semantics

The preferred approach is to use `record` types to implement value based equality. This approach requires a more complex implementation than the standard approach and requires thorough testing of polymorphic scenarios to ensure correctness.

## Struct example

The following example shows how to implement value equality in a struct (value type). While structs have default value equality, a custom implementation can improve performance:

:::code language="csharp" source="snippets/how-to-define-value-equality-for-a-type/ValueEqualityStruct/Program.cs":::
  
For structs, the default implementation of <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType> (which is the overridden version in <xref:System.ValueType?displayProperty=nameWithType>) performs a value equality check by using reflection to compare the values of every field in the type. Although this implementation produces correct results, it is relatively slow compared to a custom implementation that you write specifically for the type.

When you override the virtual `Equals` method in a struct, the purpose is to provide a more efficient means of performing the value equality check and optionally to base the comparison on some subset of the struct's fields or properties.
  
The [==](../../language-reference/operators/equality-operators.md#equality-operator-) and [!=](../../language-reference/operators/equality-operators.md#inequality-operator-) operators can't operate on a struct unless the struct explicitly overloads them.

## See also

- [Equality comparisons](equality-comparisons.md)
