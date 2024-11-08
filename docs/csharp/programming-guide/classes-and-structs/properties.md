---
title: "Properties"
description: A property in C# is a member that uses accessor methods to read, write, or compute the value of a private field as if it were a public data member.
ms.date: 10/30/2024
f1_keywords:
  - "cs.properties"
helpviewer_keywords:
  - "properties [C#]"
  - "C# language, properties"
---
# Properties (C# Programming Guide)

A *property* is a member that provides a flexible mechanism to read, write, or compute the value of a data field. Properties appear as public data members, but they're implemented as special methods called *accessors*. This feature enables callers to access data easily and still helps promote data safety and flexibility. The syntax for properties is a natural extension to fields. A field defines a storage location:

:::code language="csharp" source="./snippets/properties/Person.cs" id="Field":::

## Automatically implemented properties

A property definition contains declarations for a `get` and `set` accessor that retrieves and assigns the value of that property:

:::code language="csharp" source="./snippets/properties/Person.cs" id="AutoImplemented":::

The preceding example shows an *automatically implemented property*. The compiler generates a hidden backing field for the property. The compiler also implements the body of the `get` and `set` accessors. Any attributes are applied to the automatically implemented property. You can apply the attribute to the compiler-generated backing field by specifying the `field:` tag on the attribute.

You can initialize a property to a value other than the default by setting a value after the closing brace for the property. You might prefer the initial value for the `FirstName` property to be the empty string rather than `null`. You would specify that as shown in the following code:

:::code language="csharp" source="./snippets/properties/Person.cs" id="Initializer":::

## Field backed properties

In C# 13, you can add validation or other logic in the accessor for a property using the [`field`](../../language-reference/keywords/field.md) keyword preview feature. The `field` keyword accesses the compiler synthesized backing field for a property. It enables you to write a property accessor without explicitly declaring a separate backing field.

:::code language="csharp" source="./snippets/properties/Person.cs" id="FieldBackedProperty":::

[!INCLUDE[field-preview](../../includes/field-preview.md)]

## Required properties

The preceding example allows a caller to create a `Person` using the default constructor, without setting the `FirstName` property. The property changed type to a *nullable* string. Beginning in C# 11, you can *require* callers to set a property:

:::code language="csharp" source="./snippets/properties/Person.cs" id="Required":::

The preceding code makes two changes to the `Person` class. First, the `FirstName` property declaration includes the `required` modifier. That means any code that creates a new `Person` must set this property using an [object initializer](./object-and-collection-initializers.md). Second, the constructor that takes a `firstName` parameter has the <xref:System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute?displayProperty=fullName> attribute. This attribute informs the compiler that this constructor sets *all* `required` members. Callers using this constructor aren't required to set `required` properties with an object initializer.

> [!IMPORTANT]
> Don't confuse `required` with *non-nullable*. It's valid to set a `required` property to `null` or `default`. If the type is non-nullable, such as `string` in these examples, the compiler issues a warning.

:::code language="csharp" source="./snippets/properties/Program.cs" id="SnippetInitialize":::

## Expression body definitions

Property accessors often consist of single-line statements. The accessors assign or return the result of an expression. You can implement these properties as expression-bodied members. Expression body definitions consist of the `=>` token followed by the expression to assign to or retrieve from the property.

Read-only properties can implement the `get` accessor as an expression-bodied member. The following example implements the read-only `Name` property as an expression-bodied member:

:::code language="csharp" source="./snippets/properties/Person.cs" id="ExpressionBodiedProperty":::

The `Name` property is a computed property. There's no backing field for `Name`. The property computes it each time.

## Access control

The preceding examples showed read / write properties. You can also create read-only properties, or give different accessibility to the set and get accessors. Suppose that your `Person` class should only enable changing the value of the `FirstName` property from other methods in the class. You could give the set accessor `private` accessibility instead of `internal` or `public`:

:::code language="csharp" source="./snippets/properties/Person.cs" id="AccessorModifiers":::

The `FirstName` property can be read from any code, but it can be assigned only from code in the `Person` class.

You can add any restrictive access modifier to either the set or get accessors. An access modifier on an individual accessor must be more restrictive than the access of the property. The preceding code is legal because the `FirstName` property is `public`, but the set accessor is `private`. You couldn't declare a `private` property with a `public` accessor. Property declarations can also be declared `protected`, `internal`, `protected internal`, or, even `private`.

There are two special access modifiers for `set` accessors:

- A `set` accessor can have `init` as its access modifier. That `set` accessor can be called only from an object initializer or the type's constructors. It's more restrictive than `private` on the `set` accessor.
- An automatically implemented property can declare a `get` accessor without a `set` accessor. In that case, the compiler allows the `set` accessor to be called only from the type's constructors. It's more restrictive than the `init` accessor on the `set` accessor.

Modify the `Person` class so as follows:

:::code language="csharp" source="./snippets/properties/Person.cs" id="Readonly":::

The preceding example requires callers to use the constructor that includes the `FirstName` parameter. Callers can't use [object initializers](./object-and-collection-initializers.md) to assign a value to the property. To support initializers, you can make the `set` accessor an `init` accessor, as shown in the following code:

:::code language="csharp" source="./snippets/properties/Person.cs" id="InitOnly":::

These modifiers are often used with the `required` modifier to force proper initialization.

## Properties with backing fields

You can mix the concept of a computed property with a private field and create a *cached evaluated property*. For example, update the `FullName` property so that the string formatting happens on the first access:

:::code language="csharp" source="./snippets/properties/Person.cs" id="CachedBackingStore":::

This implementation works because the `FirstName` and `LastName` properties are readonly. People can change their name. Updating the `FirstName` and `LastName` properties to allow `set` accessors requires you to invalidate any cached value for `fullName`. You modify the `set` accessors of the `FirstName` and `LastName` property so the `fullName` field is calculated again:

:::code language="csharp" source="./snippets/properties/Person.cs" id="UseBackingFields":::

This final version evaluates the `FullName` property only when needed. The previously calculated version is used if valid. Otherwise, the calculation updates the cached value. Developers using this class don't need to know the details of the implementation. None of these internal changes affect the use of the Person object.

Beginning with C# 13, you can create [`partial` properties](../../language-reference/keywords/partial-member.md) in `partial` classes. The implementing declaration for a `partial` property can't be an automatically implemented property. An automatically implemented property uses the same syntax as a declaring partial property declaration.

## Properties

Properties are a form of smart fields in a class or object. From outside the object, they appear like fields in the object. However, properties can be implemented using the full palette of C# functionality. You can provide validation, different accessibility, lazy evaluation, or any requirements your scenarios need.

- Simple properties that require no custom accessor code can be implemented either as expression body definitions or as [automatically implemented properties](./auto-implemented-properties.md).
- Properties enable a class to expose a public way of getting and setting values, while hiding implementation or verification code.
- A [get](../../language-reference/keywords/get.md) property accessor is used to return the property value, and a [set](../../language-reference/keywords/set.md) property accessor is used to assign a new value. An [init](../../language-reference/keywords/init.md) property accessor is used to assign a new value only during object construction. These accessors can have different access levels. For more information, see [Restricting Accessor Accessibility](./restricting-accessor-accessibility.md).
- The [value](../../language-reference/keywords/value.md) keyword is used to define the value the `set` or `init` accessor is assigning.
- Properties can be *read-write* (they have both a `get` and a `set` accessor), *read-only* (they have a `get` accessor but no `set` accessor), or *write-only* (they have a `set` accessor, but no `get` accessor). Write-only properties are rare.

## C# Language Specification

For more information, see [Properties](~/_csharpstandard/standard/classes.md#157-properties) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.

## See also

- [Indexers](../indexers/index.md)
- [init keyword](../../language-reference/keywords/init.md)
- [get keyword](../../language-reference/keywords/get.md)
- [set keyword](../../language-reference/keywords/set.md)
