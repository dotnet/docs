---
title: System.Data.Linq.Mapping.TableAttribute class
description: Learn about the System.Data.Linq.Mapping.TableAttribute class through these additional API remarks.
ms.date: 01/02/2024
dev_langs:
  - CSharp
  - VB
---
# System.Data.Linq.Mapping.TableAttribute class

[!INCLUDE [context](includes/context.md)]

Use the <xref:System.Data.Linq.Mapping.TableAttribute> attribute to designate a class as an entity class that is associated with a database table or view. LINQ to SQL treats classes that have the <xref:System.Data.Linq.Mapping.TableAttribute> attribute as persistent classes.

LINQ to SQL supports only single-table mapping. That is, an entity class must be mapped to exactly one database table, and you cannot map a database table to multiple classes at the same time.

You can use the <xref:System.Data.Linq.Mapping.TableAttribute.Name%2A> property of the <xref:System.Data.Linq.Mapping.TableAttribute> attribute to specify a name for the table, and you can optionally use the schema name to qualify a table name. If you do not specify a name by using the <xref:System.Data.Linq.Mapping.TableAttribute.Name%2A> property, the table name is assumed to be the same as the class name.

## Schema-qualified names

You can optionally use the schema name to qualify a table name. By default, the token to the left of the first period in the <xref:System.Data.Linq.Mapping.TableAttribute.Name%2A> string is considered to be the schema name. The remainder of the name is considered to be the table name. The provider quotes the table name as appropriate. For example, the LINQ to SQL provider for SQL Server makes sure that brackets are used at least where they are needed.

> [!NOTE]
> In some cases, you must explicitly quote attributes because the SQL Server provider cannot auto-quote. The following table shows some examples.

| Case | Example: Identifier name | Example: Expected string in attributes | Otherwise… |
|------|--------------------------|----------------------------------------|------------|
|Schema name contains a period|Schema: "A.B"<br /><br />Table: "C"|"[A.B].C"|The first period is assumed to separate the schema name from the table name.|
|Schema/table name starts with `@`|"@SomeName"|"[@SomeName]"|Assumed to be a parameter name.|
|Schema starts with `[` and ends with `]`|"[Schema.Table]"|"[[Schema].[Table]]]"|The unquoted identifier resembles a quoted identifier.|
|Table starts with `[` and ends with `]`|"[Table]"|"[[Table]]]"|The unquoted identifier resembles a quoted identifier.|

## Examples

:::code language="csharp" source="./snippets/csharp/System.Data.Linq.Mapping/TableAttribute/Overview/cs/Program.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Data.Linq.Mapping/TableAttribute/Overview/vb/Module1.vb" id="Snippet1":::
