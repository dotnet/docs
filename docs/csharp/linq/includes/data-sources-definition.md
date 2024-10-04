---
author: BillWagner
ms.author: wiwagn
ms.topic: include
ms.date: 10/04/2024
---

The following examples in this article use the common data sources for this area:

:::code language="csharp" source="../standard-query-operators/snippets/standard-query-operators/DataSources.cs" id="QueryDataSource":::

Each `Student` has a grade level, a primary department, and a series of scores. A `Teacher` also has a `City` property that identifies the campus where the teacher holds classes. A `Department` has a name, and a reference to a `Teacher` who serves as the department head.

You can find the data set in the [source repo](https://github.com/dotnet/docs/blob/main/docs/csharp/linq/standard-query-operators/snippets/standard-query-operators/DataSources.cs#L41).
