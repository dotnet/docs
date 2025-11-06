---
title: "Anonymous Types and Tuples"
description: Anonymous types in C# encapsulate a set of read-only properties in an object without having to explicitly define a type. The compiler generates a name.
ms.date: 11/06/2025
f1_keywords:
  - "anonymousObject_CSharpKeyword"
helpviewer_keywords:
  - "anonymous types [C#]"
  - "C# Language, anonymous types"
---
# Anonymous types and tuples

Anonymous types provide a convenient way to encapsulate a set of read-only properties into a single object without having to explicitly define a type first. The compiler generates the type name, and it's not available at the source code level. The compiler infers the type of each property.

In most scenarios, [tuples](../../language-reference/builtin-types/value-tuples.md) are the preferred choice over anonymous types. Tuples provide better performance, support deconstruction, and offer more flexible syntax. Use anonymous types primarily when you need expression tree support or when working with code that requires reference types.

## Anonymous types vs tuples

Both anonymous types and tuples let you group multiple values without defining a named type. However, tuples have better language support and compile to a more efficient data structure. The following table summarizes the key differences:

| Feature | Anonymous types | Tuples |
|---------|----------------|--------|
| Type | Reference type (`class`) | Value type (`struct`) |
| Performance | Heap allocation | Stack allocation (better performance) |
| Mutability | Read-only properties | Mutable fields |
| Deconstruction | Not supported | Supported |
| Expression trees | Supported | Not supported |
| Access modifier | `internal` | `public` |
| Member names | Required or inferred | Optional (with default names like `Item1`, `Item2`) |

## When to use tuples

Use tuples when:

- You need better performance through stack allocation.
- You want to deconstruct values into separate variables.
- You're returning multiple values from a method.
- You don't need expression tree support.

The following example shows how tuples provide similar functionality to anonymous types with cleaner syntax:

:::code language="csharp" source="snippets/anonymous-types/Program.cs" ID="TupleExample":::

### Tuple deconstruction

You can deconstruct a tuple into separate variables, which provides a convenient way to work with individual tuple elements. C# supports several ways to deconstruct tuples:

```csharp
// Define a method that returns a tuple
(string Name, int Age, string City) GetPersonInfo()
{
    return ("Alice", 30, "Seattle");
}

// Deconstruct using var for all variables
var (name, age, city) = GetPersonInfo();
Console.WriteLine($"{name} is {age} years old and lives in {city}");
// Output: Alice is 30 years old and lives in Seattle

// Deconstruct with explicit types
(string personName, int personAge, string personCity) = GetPersonInfo();
Console.WriteLine($"{personName}, {personAge}, {personCity}");

// Deconstruct into existing variables
string existingName;
int existingAge;
string existingCity;
(existingName, existingAge, existingCity) = GetPersonInfo();

// Deconstruct and discard unwanted values using the discard pattern (_)
var (name2, _, city2) = GetPersonInfo();
Console.WriteLine($"{name2} lives in {city2}");
// Output: Alice lives in Seattle
```

Deconstruction is useful in loops and pattern matching scenarios:

```csharp
var people = new List<(string Name, int Age)>
{
    ("Bob", 25),
    ("Carol", 35),
    ("Dave", 40)
};

foreach (var (name, age) in people)
{
    Console.WriteLine($"{name} is {age} years old");
}
```

### Tuples as a method return type

A common use case for tuples is as a method return type. Instead of defining `out` parameters, you can group method results in a tuple. The following example demonstrates using tuples with dictionary lookups to return configuration ranges:

```csharp
var configLookup = new Dictionary<int, (int Min, int Max)>()
{
    [2] = (4, 10),
    [4] = (10, 20),
    [6] = (0, 23)
};

if (configLookup.TryGetValue(4, out (int Min, int Max) range))
{
    Console.WriteLine($"Found range: min is {range.Min}, max is {range.Max}");
}
// Output: Found range: min is 10, max is 20
```

This pattern is useful when working with methods that need to return both a success indicator and multiple result values. The tuple allows you to use named fields (`Min` and `Max`) instead of generic names like `Item1` and `Item2`, making the code more readable and self-documenting.

## When to use anonymous types

Use anonymous types when:

- You're working with expression trees (for example, in some Microsoft Language-Integrated Query (LINQ) providers).
- You need the object to be a reference type.
- You're projecting query results in LINQ and want named properties without defining a class.

The most common scenario is to initialize an anonymous type with properties from another type. In the following example, assume that a class exists that is named `Product`. Class `Product` includes `Color` and `Price` properties, together with other properties that you aren't interested in:

:::code language="csharp" source="snippets/anonymous-types/Program.cs" ID="ProductDefinition":::

The anonymous type declaration starts with the [`new`](../../language-reference/operators/new-operator.md) operator together with an [object initializer](../../programming-guide/classes-and-structs/object-and-collection-initializers.md). The declaration initializes a new type that uses only two properties from `Product`. Anonymous types are typically used in the [`select`](../../language-reference/keywords/select-clause.md) clause of a query expression to return a smaller amount of data. For more information about queries, see [LINQ in C#](../../linq/index.md).

If you don't specify member names in the anonymous type, the compiler gives the anonymous type members the same name as the property used to initialize them. You provide a name for a property that's being initialized with an expression, as shown in the previous example.

In the following example, the names of the properties of the anonymous type are `Color` and `Price`. The instances are items from the `products` collection of `Product` types:

:::code language="csharp" source="snippets/anonymous-types/Program.cs" ID="snippet81":::

### Projection initializers with anonymous types

Anonymous types support *projection initializers*, which allow you to use local variables or parameters directly without explicitly specifying the member name. The compiler infers the member names from the variable names. The following example demonstrates this simplified syntax:

:::code language="csharp" source="snippets/anonymous-types/Program.cs" ID="ProjectionInitializers":::

This simplified syntax is useful when creating anonymous types with many properties:

:::code language="csharp" source="snippets/anonymous-types/Program.cs" ID="ProjectionExample":::

The member name isn't inferred in the following cases:

- The candidate name duplicates another property member in the same anonymous type, either explicit or implicit.
- The candidate name isn't a valid identifier (for example, it contains spaces or special characters).

In these cases, you must explicitly specify the member name.

> [!TIP]
> You can use .NET style rule [IDE0037](../../../fundamentals/code-analysis/style-rules/ide0037.md) to enforce whether inferred or explicit member names are preferred.

You can also define a field by using an object of another type: class, struct, or even another anonymous type. To do this, use the variable that holds this object. The following example shows two anonymous types that use already instantiated user-defined types. In both cases, the `product` field in the anonymous types `shipment` and `shipmentWithBonus` is of type `Product` and contains the default values of each field. The `bonus` field is of an anonymous type created by the compiler.

:::code language="csharp" source="snippets/anonymous-types/Program.cs" ID="snippet03":::

Typically, when you use an anonymous type to initialize a variable, you declare the variable as an implicitly typed local variable by using [var](../../language-reference/statements/declarations.md#implicitly-typed-local-variables). You can't specify the type name in the variable declaration because only the compiler has access to the underlying name of the anonymous type. For more information about `var`, see [Implicitly Typed Local Variables](../../programming-guide/classes-and-structs/implicitly-typed-local-variables.md).

You can create an array of anonymously typed elements by combining an implicitly typed local variable and an implicitly typed array, as shown in the following example.

```csharp
var anonArray = new[] { new { name = "apple", diam = 4 }, new { name = "grape", diam = 1 }};
```

Anonymous types are [`class`](../../language-reference/keywords/class.md) types that derive directly from [`object`](../../language-reference/builtin-types/reference-types.md), and you can't cast them to any type except [`object`](../../language-reference/builtin-types/reference-types.md). The compiler provides a name for each anonymous type, although your application can't access it. From the perspective of the common language runtime, an anonymous type is no different from any other reference type.

If two or more anonymous object initializers in an assembly specify a sequence of properties that are in the same order and that have the same names and types, the compiler treats the objects as instances of the same type. They share the same compiler-generated type information.

Anonymous types support non-destructive mutation in the form of [with expressions](../../language-reference/operators/with-expression.md). This feature enables you to create a new instance of an anonymous type where one or more properties have new values:

:::code language="csharp" source="snippets/anonymous-types/Program.cs" ID="snippet02":::

You can't declare a field, a property, an event, or the return type of a method as having an anonymous type. Similarly, you can't declare a formal parameter of a method, property, constructor, or indexer as having an anonymous type. To pass an anonymous type, or a collection that contains anonymous types, as an argument to a method, you can declare the parameter as type `object`. However, using `object` for anonymous types defeats the purpose of strong typing. If you must store query results or pass them outside the method boundary, consider using an ordinary named struct or class instead of an anonymous type.

Because the <xref:System.Object.Equals%2A> and <xref:System.Object.GetHashCode%2A> methods on anonymous types are defined in terms of the `Equals` and `GetHashCode` methods of the properties, two instances of the same anonymous type are equal only if all their properties are equal.

> [!NOTE]
> The [accessibility level](../../programming-guide/classes-and-structs/access-modifiers.md) of an anonymous type is `internal`. Hence, two anonymous types defined in different assemblies aren't of the same type.
> Therefore, instances of anonymous types can't be equal to each other when defined in different assemblies, even when having all their properties equal.

Anonymous types do override the <xref:System.Object.ToString%2A> method, concatenating the name and `ToString` output of every property surrounded by curly braces.

```
var v = new { Title = "Hello", Age = 24 };

Console.WriteLine(v.ToString()); // "{ Title = Hello, Age = 24 }"
```

## See also

- [Tuple types](../../language-reference/builtin-types/value-tuples.md)
- [Choosing between anonymous and tuple types](../../../standard/base-types/choosing-between-anonymous-and-tuple.md)
- [Object and Collection Initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md)
- [LINQ in C#](../../linq/index.md)
