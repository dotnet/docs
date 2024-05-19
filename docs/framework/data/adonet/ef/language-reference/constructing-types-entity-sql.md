---
description: "Learn more about: Constructing Types (Entity SQL)"
title: "Constructing Types (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 41fa7bde-8d20-4a3f-a3d2-fb791e128010
---
# Constructing Types (Entity SQL)

<!-- markdownlint-disable DOCSMD001 -->
Entity SQL provides three kinds of constructors: row constructors, named type constructors, and collection constructors.

## Row Constructors

You use row constructors in Entity SQL to construct anonymous, structurally typed records from one or more values. The result type of a row constructor is a row type whose field types correspond to the types of the values used to construct the row. For example, the following expression constructs a value of type `Record(a int, b string, c int)`:

`ROW(1 AS a, "abc" AS b, a + 34 AS c)`

If you do not provide an alias for an expression in a row constructor, the Entity Framework will try to generate one. For more information, see the "Aliasing Rules" section in [Identifiers](identifiers-entity-sql.md).

The following rules apply to expression aliasing in a row constructor:

- Expressions in a row constructor cannot refer to other aliases in the same constructor.
- Two expressions in the same row constructor cannot have the same alias.

For more information about row constructors, see [ROW](row-entity-sql.md).

## Collection Constructors

You use collection constructors in Entity SQL to create an instance of a multiset from a list of values. All the values in the constructor must be of mutually compatible type `T`, and the constructor produces a collection of type `Multiset<T>`. For example, the following expression creates a collection of integers:

`Multiset(1, 2, 3)`

`{1, 2, 3}`

Empty multiset constructors are not allowed because the type of the elements cannot be determined. The following is not valid:

`multiset() {}`

For more information, see [MULTISET](multiset-entity-sql.md).

## Named Type Constructors (NamedType Initializers)

Entity SQL allows type constructors (initializers) to create instances of named complex types and entity types. For example, the following expression creates an instance of a `Person` type.

`Person("abc", 12)`

The following expression creates an instance of a complex type.

`MyModel.ZipCode('98118', '4567')`

The following expression creates an instance of a nested complex type.

`MyModel.AddressInfo('My street address', 'Seattle', 'WA', MyModel.ZipCode('98118', '4567'))`

The following expression creates an instance of an entity with a nested complex type.

`MyModel.Person("Bill", MyModel.AddressInfo('My street address', 'Seattle', 'WA', MyModel.ZipCode('98118', '4567')))`

The following example shows how to initialize a property of a complex type to null. `MyModel.ZipCode('98118', null)`

The arguments to the constructor are assumed to be in the same order as the declaration of the attributes of the type.

For more information, see [Named Type Constructor](named-type-constructor-entity-sql.md).

## See also

- [Entity SQL Reference](entity-sql-reference.md)
- [Entity SQL Overview](entity-sql-overview.md)
- [Type System](type-system-entity-sql.md)
