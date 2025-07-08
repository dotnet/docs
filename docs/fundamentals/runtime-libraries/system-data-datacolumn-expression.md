---
title: System.Data.DataColumn.Expression property
description: Learn about the System.Data.DataColumn.Expression property.
ms.date: 01/24/2024
---
# System.Data.DataColumn.Expression property

[!INCLUDE [context](includes/context.md)]

One use of the <xref:System.Data.DataColumn.Expression> property is to create calculated columns. For example, to calculate a tax value, the unit price is multiplied by a tax rate of a specific region. Because tax rates vary from region to region, it would be impossible to put a single tax rate in a column; instead, the value is calculated using the <xref:System.Data.DataColumn.Expression> property, as shown in the following code:

```vb
DataSet1.Tables("Products").Columns("tax").Expression = "UnitPrice * 0.086"
```

A second use is to create an aggregate column. Similar to a calculated value, an aggregate performs an operation based on the complete set of rows in the <xref:System.Data.DataTable>. A simple example is to count the number of rows returned in the set. This is the method you would use to count the number of transactions completed by a particular salesperson, as shown in the following code:

```vb
DataSet1.Tables("Orders").Columns("OrderCount").Expression = "Count(OrderID)"
```

## Expression syntax

When you create an expression, use the <xref:System.Data.DataColumn.ColumnName> property to refer to columns. For example, if the <xref:System.Data.DataColumn.ColumnName> for one column is "UnitPrice", and another "Quantity", the expression is:

`"UnitPrice * Quantity"`

> [!NOTE]
> If a column is used in an expression, then the expression is said to have a dependency on that column. If a dependent column is renamed or removed, no exception is thrown. An exception will be thrown when the now-broken expression column is accessed.

When you create an expression for a filter, enclose strings with single quotation marks:

`"LastName = 'Jones'"`

If a column name contains any non-alphanumeric characters, starts with a digit, or matches (case-insensitively) any of the following reserved words, it requires special handling, as described in the following paragraphs.

:::row:::
   :::column:::
      `And`
   :::column-end:::
   :::column:::
      `Between`
   :::column-end:::
   :::column:::
      `Child`
   :::column-end:::
   :::column:::
      `False`
   :::column-end:::
:::row-end:::
:::row:::
   :::column:::
      `In`
   :::column-end:::
   :::column:::
      `Is`
   :::column-end:::
   :::column:::
      `Like`
   :::column-end:::
   :::column:::
      `Not`
   :::column-end:::
:::row-end:::
:::row:::
   :::column:::
      `Null`
   :::column-end:::
   :::column:::
      `Or`
   :::column-end:::
   :::column:::
      `Parent`
   :::column-end:::
   :::column:::
      `True`
   :::column-end:::
:::row-end:::

If a column name satisfies one of the previous conditions, it must be wrapped in either square brackets or "\`" (grave accent) quotes. For example, to use a column named "Column#" in an expression, you would write either "[Column#]" or "\`Column#`":

`Total * [Column#]`

If the column name is enclosed in square brackets, then any ']' and '\\' characters (but not any other characters) in it must be escaped by prepending them with the backslash ("\\") character. If the column name is enclosed in grave accent characters, then it must not contain any grave accent characters. For example, a column named "Column[]\\" would be written:

`Total * [Column[\]\\]`

or

Total * \`Column[]\\`

## User-defined values

User-defined values may be used within expressions to be compared with column values. String values should be enclosed within single quotation marks (and each single quotation character in a string value has to be escaped by prepending it with another single quotation character). Date values should be enclosed within pound signs (#) or single quotes (') based on the data provider. Decimals and scientific notation are permissible for numeric values. For example:

`"FirstName = 'John'"`

`"Price <= 50.00"`

`"Birthdate < #1/31/2006#"`

For columns that contain enumeration values, cast the value to an integer data type. For example:

`"EnumColumn = 5"`

## Parse literal expressions

All literal expressions must be expressed in the invariant culture locale. When `DataSet` parses and converts literal expressions, it always uses the invariant culture, not the current culture.

String literals are identified when there are single quotes surrounding the value. For example, `'John'`.

`Boolean` literals are `true` and `false`; they aren't quoted in expressions.

`Integer` literals [+-]?[0-9]+ are treated as `System.Int32`, `System.Int64`, or `System.Double`. `System.Double` can lose precision depending on how large the number is. For example, if the number in the literal is 2147483650, `DataSet` will first attempt to parse the number as an `Int32`. This won't succeed because the number is too large. In this case `DataSet`, parses the number as an `Int64`, which will succeed. If the literal is a number larger than the maximum value of an Int64, `DataSet` parses the literal using `Double`.

Real literals that use scientific notation, such as 4.42372E-30, are parsed using `System.Double`.

Real literals without scientific notation, but with a decimal point, are treated as `System.Decimal`. If the number exceeds the maximum or minimum values supported by `System.Decimal`, then it is parsed as a `System.Double`. For example:

- 142526.144524 is converted to a `Decimal`.
- 345262.78036719560925667 is treated as a `Double`.

## Operators

Concatenation is allowed using Boolean AND, OR, and NOT operators. You can use parentheses to group clauses and force precedence. The AND operator has precedence over other operators. For example:

`(LastName = 'Smith' OR LastName = 'Jones') AND FirstName = 'John'`

When you create comparison expressions, the following operators are allowed:

- \<
- \>
- \<=
- \>=
- =
- `IN`
- `LIKE`

The following arithmetic operators are also supported in expressions:

- \+ (addition)
- \- (subtraction)
- \* (multiplication)
- / (division)
- % (modulus)

## String operators

To concatenate a string, use the `+` character. The value of the <xref:System.Data.DataSet.CaseSensitive> property of the <xref:System.Data.DataSet> class determines whether string comparisons are case-sensitive. However, you can override that value with the <xref:System.Data.DataTable.CaseSensitive> property of the <xref:System.Data.DataTable> class.

## Wildcard characters

Both the `*` and `%` characters can be used interchangeably for wildcard characters in a LIKE comparison. If the string in a LIKE clause contains a `*` or `%`, those characters should be enclosed in brackets (`[]`). If a bracket is in the clause, each bracket character should be enclosed in brackets (for example `[[]` or `[]]`). A wildcard is allowed at the start and end of a pattern, or at the end of a pattern, or at the start of a pattern. For example:

- `"ItemName LIKE '*product*'"`
- `"ItemName LIKE '*product'"`
- `"ItemName LIKE 'product*'"`

Wildcard characters are not allowed in the middle of a string. For example, `'te*xt'` is not allowed.

## Parent/child relation referencing

A parent table may be referenced in an expression by prepending the column name with `Parent`. For example, `Parent.Price` references the parent table's column named `Price`.

When a child has more than one parent row, use `Parent(RelationName).ColumnName`. For example, `Parent(RelationName).Price` references the parent table's column named "Price" via the relation.

A column in a child table may be referenced in an expression by prepending the column name with `Child`. However, because child relationships may return multiple rows, you must include the reference to the child column in an aggregate function. For example, `Sum(Child.Price)` would return the sum of the column named `Price` in the child table.

If a table has more than one child, the syntax is: `Child(RelationName)`. For example, if a table has two child tables named `Customers` and `Orders`, and the <xref:System.Data.DataRelation> object is named `Customers2Orders`, the reference would be as follows:

`Avg(Child(Customers2Orders).Quantity)`

## Aggregates

The following aggregate types are supported:

- `Sum` (Sum)
- `Avg` (Average)
- `Min` (Minimum)
- `Max` (Maximum)
- `Count` (Count)
- `StDev` (Statistical standard deviation)
- `Var` (Statistical variance)

Aggregates are ordinarily performed along relationships. Create an aggregate expression by using one of the functions listed earlier and a child table column as detailed in [Parent/child relation referencing](#parentchild-relation-referencing). For example:

- `Avg(Child.Price)`
- `Avg(Child(Orders2Details).Price)`

An aggregate can also be performed on a single table. For example, to create a summary of figures in a column named "Price":

`Sum(Price)`

> [!NOTE]
> If you use a single table to create an aggregate, there would be no group-by functionality. Instead, all rows would display the same value in the column.

If a table has no rows, the aggregate functions will return `null`.

Data types can always be determined by examining the <xref:System.Data.DataColumn.DataType> property of a column. You can also convert data types using the `Convert` function, shown in the following section.

An aggregate can only be applied to a single column, and no other expressions can be used inside the aggregate.

## Functions

The following functions are also supported.

### `CONVERT`

This function converts an expression to a specified .NET type.

```csharp
Convert(expression, type)
```

| Argument     | Description                                     |
|--------------|-------------------------------------------------|
| `expression` | The expression to convert.                      |
| `type`       | .NET type to which the value will be converted. |

Example: `myDataColumn.Expression="Convert(total, 'System.Int32')"`

All conversions are valid with the following exceptions: `Boolean` can be coerced to and from `Byte`, `SByte`, `Int16`, `Int32`, `Int64`, `UInt16`, `UInt32`, `UInt64`, `String` and itself only. `Char` can be coerced to and from `Int32`, `UInt32`, `String`, and itself only. `DateTime` can be coerced to and from `String` and itself only. `TimeSpan` can be coerced to and from `String` and itself only.

### `LEN`

This function gets the length of a string.

```csharp
LEN(expression)
```

| Arguments    | Description                 |
|--------------|-----------------------------|
| `expression` | The string to be evaluated. |

Example: `myDataColumn.Expression="Len(ItemName)"`

### `ISNULL`

This function checks an expression and either returns the checked expression or a replacement value.

```csharp
ISNULL(expression, replacementvalue)
```

| Arguments          | Description                                              |
|--------------------|----------------------------------------------------------|
| `expression`       | The expression to check.                                 |
| `replacementvalue` | If expression is `null`, `replacementvalue` is returned. |

Example: `myDataColumn.Expression="IsNull(price, -1)"`

### `IIF`

This function gets one of two values depending on the result of a logical expression.

```csharp
IIF(expr, truepart, falsepart)
```

| Arguments   | Description                                     |
|-------------|-------------------------------------------------|
| `expr`      | The expression to evaluate.                     |
| `truepart`  | The value to return if the expression is true.  |
| `falsepart` | The value to return if the expression is false. |

Example: `myDataColumn.Expression = "IIF(total>1000, 'expensive', 'dear')`

### `TRIM`

This function removes all leading and trailing blank characters like \r, \n, \t, and ' '.

```csharp
TRIM(expression)
```

| Argument     | Description             |
|--------------|-------------------------|
| `expression` | The expression to trim. |

### `SUBSTRING`

This function gets a substring of a specified length, starting at a specified point in the string.

```csharp
SUBSTRING(expression, start, length)
```

| Argument     | Description                                         |
|--------------|-----------------------------------------------------|
| `expression` | The source string for the substring                 |
| `start`      | Integer that specifies where the substring starts.  |
| `length`     | Integer that specifies the length of the substring. |

Example: `myDataColumn.Expression = "SUBSTRING(phone, 7, 8)"`

> [!NOTE]
> You can reset the <xref:System.Data.DataColumn.Expression> property by assigning it a null value or empty string. If a default value is set on the expression column, all previously filled rows are assigned the default value after the <xref:System.Data.DataColumn.Expression> property is reset.
