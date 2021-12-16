---
title: "Records - C# reference"
description: Learn about the record type in C#
ms.date: 12/16/2021
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

While records can be mutable, they're primarily intended for supporting immutable data models. The record type offers the following features:

* [Concise syntax for creating a reference type with immutable properties](#positional-syntax-for-property-definition)
* Built-in behavior useful for a data-centric reference type:
  * [Value equality](#value-equality)
  * [Concise syntax for nondestructive mutation](#nondestructive-mutation)
  * [Built-in formatting for display](#built-in-formatting-for-display)
* [Support for inheritance hierarchies](#inheritance)

You can also use [structure types](struct.md) to design data-centric types that provide value equality and little or no behavior. In C# 10 and later, you can define `record struct` types using either positional parameters, or standard property syntax:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="PositionalRecordStruct":::
:::code language="csharp" source="snippets/shared/RecordType.cs" id="ImmutableRecordStruct":::

Record structs can be mutable as well, both positional record structs and record structs with no positional parameters:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="MutablePositionalRecordStruct":::
:::code language="csharp" source="snippets/shared/RecordType.cs" id="MutableRecordStruct":::

The preceding examples show some distinctions between records that are reference types and records that are value types:

- A `record` or a `record class` declares a reference type. The `class` keyword is optional, but can add clarity for readers. A `record struct` declares a value type.
- Positional properties are *immutable* in a `record class` and a `readonly record struct`. They're *mutable* in a `record struct`.

The remainder of this article discusses both `record class` and `record struct` types. The differences are detailed in each section. You should decide between a `record class` and a `record struct` similar to deciding between a `class` and a `struct`. The term *record* is used to describe behavior that applies to all record types. Either `record struct` or `record class` is used to describe behavior that applies to only struct or class types, respectively.

## Positional syntax for property definition

You can use positional parameters to declare properties of a record and to initialize the property values when you create an instance:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="InstantiatePositional":::

When you use the positional syntax for property definition, the compiler creates:

* A public auto-implemented property for each positional parameter provided in the record declaration.
  - For `record` types and `readonly record struct` types: An [init-only](../keywords/init.md) property.
  - For `record struct` types: A read-write property.
* A primary constructor whose parameters match the positional parameters on the record declaration.
* For record struct types, a parameterless constructor that sets each field to its default value.
* A `Deconstruct` method with an `out` parameter for each positional parameter provided in the record declaration. The method deconstructs properties defined by using positional syntax; it ignores properties that are defined by using standard property syntax.

You may want to add attributes to any of these elements the compiler creates from the record definition. You can add a *target* to any attribute you apply to the positional record's properties. The following example applies the <xref:System.Text.Json.Serialization.JsonPropertyNameAttribute?displayProperty=nameWithType> to each property of the `Person` record. The `property:` target indicates that the attribute is applied to the compiler-generated property. Other values are `field:` to apply the attribute to the field, and `param:` to apply the attribute to the parameter.

:::code language="csharp" source="snippets/shared/RecordType.cs" id="PositionalAttributes":::

The preceding example also shows how to create XML documentation comments for the record. You can add the `<param>` tag to add documentation for the primary constructor's parameters.

If the generated auto-implemented property definition isn't what you want, you can define your own property of the same name. For example, you may want to change accessibility or mutability, or provide an implementation for either the `get` or `set` accessor. If you declare the property in your source, you must initialize it from the positional parameter of the record. The generated deconstructor will use your property definition. For instance, the following example declares the `FirstName` and `LastName` properties of a positional record `public`, but restricts the `Id` positional parameter to `internal`. You can use this syntax for records and record struct types.

:::code language="csharp" source="snippets/shared/RecordType.cs" id="PositionalWithManualProperty":::

A record type doesn't have to declare any positional properties. You can declare a record without any positional properties, and you can declare other fields and properties, as in the following example:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="MixedSyntax":::

If you define properties by using standard property syntax but omit the access modifier, the properties are implicitly `private`.
<!-- Todo -- Explain issues surrounding use of attributes on positional properties. -->

## Immutability

A *positional record* and a *positional readonly record struct* declare init-only properties. A *positional record struct* declares read-write properties. You can override either of those defaults, as shown in the previous section.

Immutability can be useful when you need a data-centric type to be thread-safe or you're depending on a hash code remaining the same in a hash table. Immutability isn't appropriate for all data scenarios, however. [Entity Framework Core](/ef/core/), for example, doesn't support updating with immutable entity types.

Init-only properties, whether created from positional parameters (`record class`, and `readonly record struct`) or by specifying `init` accessors, have *shallow immutability*. After initialization, you can't change the value of value-type properties or the reference of reference-type properties. However, the data that a reference-type property refers to can be changed. The following example shows that the content of a reference-type immutable property (an array in this case) is mutable:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="ShallowImmutability":::

The features unique to record types are implemented by compiler-synthesized methods, and none of these methods compromises immutability by modifying object state. Unless specified, the synthesized methods are generated for `record`, `record struct`, and `readonly record struct` declarations.

## Value equality

For any type you define, you can override <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType>, and overload [`operator ==`](../operators/equality-operators.md#equality-operator-). If you don't override `Equals` or overload `operator ==`, the type you declare governs how equality is defined:

- For `class` types, two objects are equal if they refer to the same object in memory.
- For `struct` types, two objects are equal if they are of the same type and store the same values.
- For `record` types, including `record struct` and `readonly record struct`, two objects are equal if they are of the same type and store the same values.

The definition of equality for a `record struct` is the same as for a `struct`. The difference is that for a `struct`, the implementation is in <xref:System.ValueType.Equals(System.Object)?displayProperty=nameWithType> and relies on reflection. For records, the implementation is compiler synthesized and uses the declared data members.

Reference equality is required for some data models. For example, [Entity Framework Core](/ef/core/) depends on reference equality to ensure that it uses only one instance of an entity type for what is conceptually one entity. For this reason, records and record structs aren't appropriate for use as entity types in Entity Framework Core.

The following example illustrates value equality of record types:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="Equality":::

To implement value equality, the compiler synthesizes the following methods:

* An override of <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType>.

  This method is used as the basis for the <xref:System.Object.Equals(System.Object,System.Object)?displayProperty=nameWithType> static method when both parameters are non-null.

* A virtual `Equals` method whose parameter is the record type. This method implements <xref:System.IEquatable%601>.

* An override of <xref:System.Object.GetHashCode?displayProperty=nameWithType>.

* Overrides of operators `==` and `!=`.

You can write your own implementations to replace any of these synthesized methods. If a record type has a method that matches the signature of any synthesized method, the compiler doesn't synthesize that method.

If you provide your own implementation of `Equals` in a record type, provide an implementation of `GetHashCode` also.

## Nondestructive mutation

If you need to copy an instance with some modifications, you can use a `with` expression to achieve *nondestructive mutation*. A `with` expression makes a new record instance that is a copy of an existing record instance, with specified properties and fields modified. You use [object initializer](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) syntax to specify the values to be changed, as shown in the following example:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="WithExpressions":::

The `with` expression can set positional properties or properties created by using standard property syntax. Non-positional properties must have an `init` or `set` accessor to be changed in a `with` expression.

The result of a `with` expression is a *shallow copy*, which means that for a reference property, only the reference to an instance is copied. Both the original record and the copy end up with a reference to the same instance.

To implement this feature for `record class` types, the compiler synthesizes a clone method and a copy constructor. The virtual clone method returns a new record initialized by the copy constructor. When you use a `with` expression, the compiler creates code that calls the clone method and then sets the properties that are specified in the `with` expression.

If you need different copying behavior, you can write your own copy constructor in a `record class`. If you do that, the compiler won't synthesize one. Make your constructor `private` if the record is `sealed`, otherwise make it `protected`. The compiler doesn't synthesize a copy constructor for `record struct` types. You can write one, but the compiler won't generate calls to it for `with` expressions. The values of the `record struct` are copied on assignment.

You can't override the clone method, and you can't create a member named `Clone` in any record type. The actual name of the clone method is compiler-generated.

## Built-in formatting for display

Record types have a compiler-generated <xref:System.Object.ToString%2A> method that displays the names and values of public properties and fields. The `ToString` method returns a string of the following format:

> \<record type name> { \<property name> = \<value>, \<property name> = \<value>, ...}

The string printed for `<value>` is the string returned by the <xref:System.Object.ToString> for the type of the property. In the following example, `ChildNames`is a <xref:System.Array?displayProperty=nameWithType>, where `ToString` returns `System.String[]`:

```
Person { FirstName = Nancy, LastName = Davolio, ChildNames = System.String[] }
```

To implement this feature, in `record class` types, the compiler synthesizes a virtual `PrintMembers` method and a <xref:System.Object.ToString%2A> override. In `record struct` types, this member is `private`.
The `ToString` override creates a <xref:System.Text.StringBuilder> object with the type name followed by an opening bracket. It calls `PrintMembers` to add property names and values, then adds the closing bracket. The following example shows code similar to what the synthesized override contains:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="ToStringOverrideDefault":::

You can provide your own implementation of `PrintMembers` or the `ToString` override. Examples are provided in the [`PrintMembers` formatting in derived records](#printmembers-formatting-in-derived-records) section later in this article. In C# 10 and later, your implementation of `ToString` may include the `sealed` modifier, which prevents the compiler from synthesizing a `ToString` implementation for any derived records. You can do this to create a consistent string representation throughout a hierarchy of `record` types. (Derived records will still have a `PrintMembers` method generated for all derived properties.)

## Inheritance

This section only applies to `record class` types.

A record can inherit from another record. However, a record can't inherit from a class, and a class can't inherit from a record.

### Positional parameters in derived record types

The derived record declares positional parameters for all the parameters in the base record primary constructor. The base record declares and initializes those properties. The derived record doesn't hide them, but only creates and initializes properties for parameters that aren't declared in its base record.

The following example illustrates inheritance with positional property syntax:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="PositionalInheritance":::

### Equality in inheritance hierarchies

This section applies to `record class` types, but not `record struct` types. For two record variables to be equal, the run-time type must be equal. The types of the containing variables might be different. Inherited equality comparison is illustrated in the following code example:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="InheritanceEquality":::

In the example, all variables are declared as `Person`, even when the instance is a derived type of either `Student` or `Teacher`. The instances have the same properties and the same property values. But `student == teacher` returns `False` although both are `Person`-type variables, and `student == student2` returns `True` although one is a `Person` variable and one is a `Student` variable. The equality test depends on the runtime type of the actual object, not the declared type of the variable.

To implement this behavior, the compiler synthesizes an `EqualityContract` property that returns a <xref:System.Type> object that matches the type of the record. The `EqualityContract` enables the equality methods to compare the runtime type of objects when they're checking for equality. If the base type of a record is `object`, this property is `virtual`. If the base type is another record type, this property is an override. If the record type is `sealed`, this property is effectively `sealed` because the type is `sealed`.

When comparing two instances of a derived type, the synthesized equality methods check all properties of the base and derived types for equality. The synthesized `GetHashCode` method uses the `GetHashCode` method from all properties and fields declared in the base type and the derived record type.

### `with` expressions in derived records

The result of a `with` expression has the same run-time type as the expression's operand. All properties of the run-time type get copied, but you can only set properties of the compile-time type, as the following example shows:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="WithExpressionInheritance":::

### `PrintMembers` formatting in derived records

The synthesized `PrintMembers` method of a derived record type calls the base implementation. The result is that all public properties and fields of both derived and base types are included in the `ToString` output, as shown in the following example:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="ToStringInheritance":::

You can provide your own implementation of the `PrintMembers` method. If you do that, use the following signature:

* For a `sealed` record that derives from `object` (doesn't declare a base record): `private bool PrintMembers(StringBuilder builder)`;
* For a `sealed` record that derives from another record (note that the enclosing type is `sealed`, so the method is effectively `sealed`): `protected override bool PrintMembers(StringBuilder builder)`;
* For a record that isn't `sealed` and derives from object: `protected virtual bool PrintMembers(StringBuilder builder);`
* For a record that isn't `sealed` and derives from another record: `protected override bool PrintMembers(StringBuilder builder);`

Here's an example of code that replaces the synthesized `PrintMembers` methods, one for a record type that derives from object, and one for a record type that derives from another record:

:::code language="csharp" source="snippets/shared/RecordType.cs" id="PrintMembersImplementation":::

> [!NOTE]
> In C# 10 and later, the compiler will synthesize `PrintMembers` in derived records even when a base record has sealed the `ToString` method. You can also create your own implementation of `PrintMembers`.

### Deconstructor behavior in derived records

The `Deconstruct` method of a derived record returns the values of all positional properties of the compile-time type. If the variable type is a base record, only the base record properties are deconstructed unless the object is cast to the derived type. The following example demonstrates calling a deconstructor on a derived record.

:::code language="csharp" source="snippets/shared/RecordType.cs" id="DeconstructorInheritance":::

## Generic constraints

There's no generic constraint that requires a type to be a record. Records satisfy either the `class` or `struct` constraint. To make a constraint on a specific hierarchy of record types, put the constraint on the base record as you would a base class. For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md).

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
- [The C# type system](../../fundamentals/types/index.md)
- [`with` expression](../operators/with-expression.md)
