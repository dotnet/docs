---
title: Data types
ms.date: 12/13/2019
description: Describes the supported data types and some of the limitations around them.
no-loc: ["INTEGER", "BLOB", "TEXT", "REAL"]
---
# Data types

SQLite only has four primitive data types: INTEGER, REAL, TEXT, and BLOB. APIs that return database values as an `object` will only ever return one of these four types. Additional .NET types are supported by Microsoft.Data.Sqlite, but values are ultimately coerced between these types and one of the four primitive types.

| .NET           | SQLite  | Remarks                                                                           |
| -------------- | ------- | ----------------------------------------------------------------------------------|
| :::no-loc text="Boolean":::        | INTEGER | `0` or `1`                                                    |
| :::no-loc text="Byte":::           | INTEGER |                                                               |
| :::no-loc text="Byte[] ":::        | BLOB    |                                                               |
| :::no-loc text="Char":::           | TEXT    | UTF-8                                                         |
| :::no-loc text="DateOnly":::       | TEXT    | :::no-loc text="yyyy-MM-dd":::                                |
| :::no-loc text="DateTime":::       | TEXT    | :::no-loc text="yyyy-MM-dd HH:mm:ss.FFFFFFF":::               |
| :::no-loc text="DateTimeOffset"::: | TEXT    | :::no-loc text="yyyy-MM-dd HH:mm:ss.FFFFFFFzzz":::            |
| :::no-loc text="Decimal":::        | TEXT    | `0.0###########################` format. REAL would be lossy. |
| :::no-loc text="Double":::         | REAL    |                                                               |
| :::no-loc text="Guid":::           | TEXT    | 00000000-0000-0000-0000-000000000000                          |
| :::no-loc text="Int16":::          | INTEGER |                                                               |
| :::no-loc text="Int32":::          | INTEGER |                                                               |
| :::no-loc text="Int64":::          | INTEGER |                                                               |
| :::no-loc text="SByte":::          | INTEGER |                                                               |
| :::no-loc text="Single":::         | REAL    |                                                               |
| :::no-loc text="String":::         | TEXT    | UTF-8                                                         |
| :::no-loc text="TimeOnly":::       | TEXT    | HH:mm:ss.fffffff                                              |
| :::no-loc text="TimeSpan":::       | TEXT    | d.hh:mm:ss.fffffff                                            |
| :::no-loc text="UInt16":::         | INTEGER |                                                               |
| :::no-loc text="UInt32":::         | INTEGER |                                                               |
| :::no-loc text="UInt64":::         | INTEGER | Large values overflow                                         |

## Alternative types

Some .NET types can be read from alternative SQLite types. Parameters can also be configured to use these alternative types. For more information, see [Parameters](parameters.md#alternative-types).

| .NET           | SQLite  | Remarks                              |
| -------------- | ------- | ------------------------------------ |
| :::no-loc text="Char":::           | INTEGER | UTF-16           |
| :::no-loc text="DateOnly":::       | REAL    | Julian day value |
| :::no-loc text="DateTime":::       | REAL    | Julian day value |
| :::no-loc text="DateTimeOffset"::: | REAL    | Julian day value |
| :::no-loc text="Guid":::           | BLOB    |                  |
| :::no-loc text="TimeOnly":::       | REAL    | In days          |
| :::no-loc text="TimeSpan":::       | REAL    | In days          |

For example, the following query reads a TimeSpan value from a REAL column in the result set.

[!code-csharp[](../../../../samples/snippets/standard/data/sqlite/DateAndTimeSample/Program.cs?name=snippet_AlternativeType)]

## Column types

SQLite uses a dynamic type system where the type of a value is associated with the value itself and not the column where it's stored. You're free to use whatever column type name you want. Microsoft.Data.Sqlite won't apply any additional semantics to these names.

The column type name does have an impact on the [type affinity](https://www.sqlite.org/datatype3.html#type_affinity). One common gotcha is that using a column type of STRING will try to convert values to INTEGER or REAL, which can lead to unexpected results. We recommend only using the four primitive SQLite type names: INTEGER, REAL, TEXT, and BLOB.

SQLite allows you to specify type facets like length, precision, and scale, but they are not enforced by the database engine. Your app is responsible for enforcing these.

## See also

- [Datatypes In SQLite](https://www.sqlite.org/datatype3.html)
