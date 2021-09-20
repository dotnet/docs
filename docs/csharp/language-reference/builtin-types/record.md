---
title: "Records - C# reference"
description: Learn about the record type in C#
ms.date: 07/01/2021
f1_keywords: 
  - "record_CSharpKeyword"
helpviewer_keywords: 
  - "record keyword [C#]"
  - "record type [C#]"
---
# Records (C# reference)

Beginning with C# 9, you use the `record` keyword to define a [reference type](reference-types.md) that provides built-in functionality for encapsulating data. You can create record types with immutable properties by using positional parameters or standard property syntax:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="PositionalRecord":::
:::code language="csharp" source="snippets/shared/RecordType.cs" id="ImmutableRecord":::

You can also create record types with mutable properties and fields:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="MutableRecord":::

While records can be mutable, they are primarily intended for supporting immutable data models. The record type offers the following features:

* [Concise syntax for creating a reference type with immutable properties](#positional-syntax-for-property-definition)
* Built-in behavior useful for a data-centric reference type:
  * [Value equality](#value-equality)
  * [Concise syntax for nondestructive mutation](#nondestructive-mutation)
  * [Built-in formatting for display](#built-in-formatting-for-display)
* [Support for inheritance hierarchies](#inheritance)

You can also use [structure types](struct.md) to design data-centric types that provide value equality and little or no behavior. But for relatively large data models, structure types have some disadvantages:

* They don't support inheritance.
* They're less efficient at determining value equality. For value types, the <xref:System.ValueType.Equals%2A?displayProperty=nameWithType> method uses reflection to find all fields. For records, the compiler generates the `Equals` method. In practice, the implementation of value equality in records is measurably faster.
* They use more memory in some scenarios, since every instance has a complete copy of all of the data. Record types are [reference types](reference-types.md), so a record instance contains only a reference to the data.

## Positional syntax for property definition

You can use positional parameters to declare properties of a record and to initialize the property values when you create an instance:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="InstantiatePositional":::

When you use the positional syntax for property definition, the compiler creates:

* A public init-only auto-implemented property for each positional parameter provided in the record declaration. An [init-only](../keywords/init.md) property can only be set in the constructor or by using a property initializer.
* A primary constructor whose parameters match the positional parameters on the record declaration.
* A `Deconstruct` method with an `out` parameter for each positional parameter provided in the record declaration. This method is provided only if there are two or more positional parameters. The method deconstructs properties defined by using positional syntax; it ignores properties that are defined by using standard property syntax.

You may want to add attributes to any of these elements the compiler creates from the record definition. You can add a *target* to any attribute you apply to the positional record's properties. The following example applies the <xref:System.Text.Json.Serialization.JsonPropertyNameAttribute?displayProperty=nameWithType> to each property of the `Person` record. The `property:` target indicates that the attribute is applied to the compiler generated property. Other values are `field:` to apply the attribute to the field, and `param:` to apply the attribute to the parameter.

:::code language="csharp" source="snippets/shared/RecordType.cs" id="PositionalAttributes":::

The preceding example also shows how to create XML documentation comments for the record. You can add the `<param>` tag to add documentation for the primary constructor's parameters.

If the generated auto-implemented property definition isn't what you want, you can define your own property of the same name. If you do that, the generated constructor and deconstructor will use your property definition. For instance, the following example makes the `FirstName` positional property `internal` instead of `public`.

:::code language="csharp" source="snippets/shared/RecordType.cs" id="PositionalWithManualProperty":::

A record type doesn't have to declare any positional properties. You can declare a record without any positional properties, and you can declare additional fields and properties, as in the following example:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="MixedSyntax":::

If you define properties by using standard property syntax but omit the access modifier, the properties are implicitly `private`.
<!-- Todo -- Explain issues surrounding use of attributes on positional properties. -->

## Immutability

A record type is not necessarily immutable. You can declare properties with `set` accessors and fields that aren't `readonly`. But while records can be mutable, they make it easier to create immutable data models.

Immutability can be useful when you need a data-centric type to be thread-safe or you're depending on a hash code remaining the same in a hash table. Immutability isn't appropriate for all data scenarios, however. [Entity Framework Core](/ef/core/), for example, doesn't support updating with immutable entity types.

Init-only properties, whether created from positional parameters or by specifying `init` accessors, have *shallow immutability*. After initialization, you can't change the value of value-type properties or the reference of reference-type properties. However, the data that a reference-type property refers to can be changed. The following example shows that the content of a reference-type immutable property (an array in this case) is mutable:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="ShallowImmutability":::

The features unique to record types are implemented by compiler-synthesized methods, and none of these methods compromises immutability by modifying object state.

## Value equality

Value equality means that two variables of a record type are equal if the types match and all property and field values match. For other reference types, equality means identity. That is, two variables of a reference type are equal if they refer to the same object.

Reference equality is required for some data models. For example, [Entity Framework Core](/ef/core/) depends on reference equality to ensure that it uses only one instance of an entity type for what is conceptually one entity. For this reason, record types aren't appropriate for use as entity types in Entity Framework Core.

The following example illustrates value equality of record types:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="Equality":::

To implement value equality, the compiler synthesizes the following methods:

* An override of <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType>.

  This method is used as the basis for the <xref:System.Object.Equals(System.Object,System.Object)?displayProperty=nameWithType> static method when both parameters are non-null.

* A virtual `Equals` method whose parameter is the record type. This method implements <xref:System.IEquatable%601>.

* An override of <xref:System.Object.GetHashCode?displayProperty=nameWithType>.

* Overrides of operators `==` and `!=`.

In `class` types, you could manually override equality methods and operators to achieve value equality, but developing and testing that code would be time-consuming and error-prone. Having this functionality built-in prevents bugs that would result from forgetting to update custom override code when properties or fields are added or changed.

You can write your own implementations to replace any of these synthesized methods. If a record type has a method that matches the signature of any synthesized method, the compiler doesn't synthesize that method.

If you provide your own implementation of `Equals` in a record type, provide an implementation of `GetHashCode` also.

## Nondestructive mutation

If you need to mutate immutable properties of a record instance, you can use a `with` expression to achieve *nondestructive mutation*. A `with` expression makes a new record instance that is a copy of an existing record instance, with specified properties and fields modified. You use [object initializer](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) syntax to specify the values to be changed, as shown in the following example:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="WithExpressions":::

The `with` expression can set positional properties or properties created by using standard property syntax. Non-positional properties must have an `init` or `set` accessor to be changed in a `with` expression.

The result of a `with` expression is a *shallow copy*, which means that for a reference property, only the reference to an instance is copied. Both the original record and the copy end up with a reference to the same instance.

To implement this feature, the compiler synthesizes a clone method and a copy constructor. The virtual clone method returns a new record initialized by the copy constructor. When you use a `with` expression, the compiler creates code that calls the clone method and then sets the properties that are specified in the `with` expression.

If you need different copying behavior, you can write your own copy constructor. If you do that, the compiler won't synthesize one. Make your constructor `private` if the record is `sealed`, otherwise make it `protected`.

You can't override the clone method, and you can't create a member named `Clone`. The actual name of the clone method is compiler-generated.

## Built-in formatting for display

Record types have a compiler-generated <xref:System.Object.ToString%2A> method that displays the names and values of public properties and fields. The `ToString` method returns a string of the following format:

> \<record type name> { \<property name> = \<value>, \<property name> = \<value>, ...}

For reference types, the type name of the object that the property refers to is displayed instead of the property value. In the following example, the array is a reference type, so `System.String[]` is displayed instead of the actual array element values:

```
Person { FirstName = Nancy, LastName = Davolio, ChildNames = System.String[] }
```

To implement this feature, the compiler synthesizes a virtual `PrintMembers` method and a <xref:System.Object.ToString%2A> override.
The `ToString` override creates a <xref:System.Text.StringBuilder> object with the type name followed by an opening bracket. It calls `PrintMembers` to add property names and values, then adds the closing bracket. The following example shows code similar to what the synthesized override contains:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="ToStringOverrideDefault":::

You can provide your own implementation of `PrintMembers` or the `ToString` override. Examples are provided in the [`PrintMembers` formatting in derived records](#printmembers-formatting-in-derived-records) section later in this article. In C# 10 and later, your implementation of `ToString` may include the `sealed` modifier, which prevents the compiler from synthesizing a `ToString` implementation for any derived records. Effectively, that means the `ToString` output will not include the runtime type information. (All members and values are displayed, because derived records will still have a PrintMembers method generated.)

## Inheritance

A record can inherit from another record. However, a record can't inherit from a class, and a class can't inherit from a record.

### Positional parameters in derived record types

The derived record declares positional parameters for all the parameters in the base record primary constructor. The base record declares and initializes those properties. The derived record doesn't hide them, but only creates and initializes properties for parameters that aren't declared in its base record.

The following example illustrates inheritance with positional property syntax:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="PositionalInheritance":::

### Equality in inheritance hierarchies

For two record variables to be equal, the run-time type must be equal. The types of the containing variables might be different. This is illustrated in the following code example:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="InheritanceEquality":::

In the example, all instances have the same properties and the same property values. But `student == teacher` returns `False` although both are `Person`-type variables, and `student == student2` returns `True` although one is a `Person` variable and one is a `Student` variable.

To implement this behavior, the compiler synthesizes an `EqualityContract` property that returns a <xref:System.Type> object that matches the type of the record. This enables the equality methods to compare the runtime type of objects when they are checking for equality. If the base type of a record is `object`, this property is `virtual`. If the base type is another record type, this property is an override. If the record type is `sealed`, this property is `sealed`.

When comparing two instances of a derived type, the synthesized equality methods check all properties of the base and derived types for equality. The synthesized `GetHashCode` method uses the `GetHashCode` method from all properties and fields declared in the base type and the derived record type.

### `with` expressions in derived records

The result of a `with` expression has the same run-time type as the expression's operand. All properties of the run-time type get copied, but you can only set properties of the compile-time type, as the following example shows:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="WithExpressionInheritance":::

### `PrintMembers` formatting in derived records

The synthesized `PrintMembers` method of a derived record type calls the base implementation. The result is that all public properties and fields of both derived and base types are included in the `ToString` output, as shown in the following example:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="ToStringInheritance":::

You can provide your own implementation of the `PrintMembers` method. If you do that, use the following signature:

* For a `sealed` record that derives from `object` (doesn't declare a base record): `private bool PrintMembers(StringBuilder builder)`;
* For a `sealed` record that derives from another record: `protected sealed override bool PrintMembers(StringBuilder builder)`;
* For a record that isn't `sealed` and derives from object: `protected virtual bool PrintMembers(StringBuilder builder);`
* For a record that isn't `sealed` and derives from another record: `protected override bool PrintMembers(StringBuilder builder);`

Here is an example of code that replaces the synthesized `PrintMembers` methods, one for a record type that derives from object, and one for a record type that derives from another record:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="PrintMembersImplementation":::

> [!NOTE]
> In C# 10.0 and later, the compiler will synthesize `PrintMembers` when a base record has sealed the `ToString` method. You can also create your own implementation of `PrintMembers`.

### Deconstructor behavior in derived records

The `Deconstruct` method of a derived record returns the values of all positional properties of the compile-time type. If the variable type is a base record, only the base record properties are deconstructed unless the object is cast to the derived type. The following example demonstrates calling a deconstructor on a derived record.

:::code language="csharp" source="snippets/shared/RecordType.cs" id="DeconstructorInheritance":::

## Generic constraints

There is no generic constraint that requires a type to be a record. Records satisfy the `class` constraint. To make a constraint on a specific hierarchy of record types, put the constraint on the base record as you would a base class. For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md).

## C# language specification

For more information, see the [Classes](~/_csharplang/spec/classes.md) section of the [C# language specification](~/_csharplang/spec/introduction.md).

For more information about features introduced in C# 9 and later, see the following feature proposal notes:

- [Records](~/_csharplang/proposals/csharp-9.0/records.md)
- [Init-only setters](~/_csharplang/proposals/csharp-9.0/init.md)
- [Covariant returns](~/_csharplang/proposals/csharp-9.0/covariant-returns.md)

## See also

- [C# reference](../index.md)
- [Design guidelines - Choosing between class and struct](../../../standard/design-guidelines/choosing-between-class-and-struct.md)
- [Design guidelines - Struct design](../../../standard/design-guidelines/struct.md)
- [Classes, structs, and records](../../fundamentals/object-oriented/index.md)
- [`with` expression](../operators/with-expression.md)
