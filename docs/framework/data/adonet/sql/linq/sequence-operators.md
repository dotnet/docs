---
description: "Learn more about: Sequence Operators"
title: "Sequence Operators"
ms.date: "03/30/2017"
ms.assetid: 4d332d32-3806-4451-b7af-25af269194ae
---
# Sequence Operators

Generally speaking, [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not support sequence operators that have one or more of the following qualities:

- Take a lambda with an index parameter.

- Rely on the properties of sequential rows, such as <xref:System.Linq.Queryable.TakeWhile*>.

- Rely on an arbitrary CLR implementation, such as <xref:System.Collections.Generic.IComparer`1>.

|Examples of Unsupported|
|-----------------------------|
|<xref:System.Linq.Enumerable.Where``1%28System.Collections.Generic.IEnumerable%7B``0%7D%2CSystem.Func%7B``0%2CSystem.Int32%2CSystem.Boolean%7D%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.Select``2%28System.Collections.Generic.IEnumerable%7B``0%7D%2CSystem.Func%7B``0%2CSystem.Int32%2C``1%7D%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.Select``2%28System.Collections.Generic.IEnumerable%7B``0%7D%2CSystem.Func%7B``0%2C``1%7D%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.TakeWhile``1%28System.Collections.Generic.IEnumerable%7B``0%7D%2CSystem.Func%7B``0%2CSystem.Boolean%7D%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.TakeWhile``1%28System.Collections.Generic.IEnumerable%7B``0%7D%2CSystem.Func%7B``0%2CSystem.Int32%2CSystem.Boolean%7D%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.SkipWhile``1%28System.Collections.Generic.IEnumerable%7B``0%7D%2CSystem.Func%7B``0%2CSystem.Boolean%7D%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.SkipWhile``1%28System.Collections.Generic.IEnumerable%7B``0%7D%2CSystem.Func%7B``0%2CSystem.Int32%2CSystem.Boolean%7D%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.GroupBy``3%28System.Collections.Generic.IEnumerable%7B``0%7D%2CSystem.Func%7B``0%2C``1%7D%2CSystem.Func%7B``0%2C``2%7D%2CSystem.Collections.Generic.IEqualityComparer%7B``1%7D%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.GroupBy``4%28System.Collections.Generic.IEnumerable%7B``0%7D%2CSystem.Func%7B``0%2C``1%7D%2CSystem.Func%7B``0%2C``2%7D%2CSystem.Func%7B``1%2CSystem.Collections.Generic.IEnumerable%7B``2%7D%2C``3%7D%2CSystem.Collections.Generic.IEqualityComparer%7B``1%7D%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.Reverse``1%28System.Collections.Generic.IEnumerable%7B``0%7D%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.DefaultIfEmpty``1%28System.Collections.Generic.IEnumerable%7B``0%7D%2C``0%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.ElementAt``1%28System.Collections.Generic.IEnumerable%7B``0%7D%2CSystem.Int32%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.ElementAtOrDefault``1%28System.Collections.Generic.IEnumerable%7B``0%7D%2CSystem.Int32%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.Range%28System.Int32%2CSystem.Int32%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.Repeat``1%28``0%2CSystem.Int32%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.Empty``1?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.Contains``1%28System.Collections.Generic.IEnumerable%7B``0%7D%2C``0%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.Aggregate``1%28System.Collections.Generic.IEnumerable%7B``0%7D%2CSystem.Func%7B``0%2C``0%2C``0%7D%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.Aggregate``2%28System.Collections.Generic.IEnumerable%7B``0%7D%2C``1%2CSystem.Func%7B``1%2C``0%2C``1%7D%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.Aggregate``3%28System.Collections.Generic.IEnumerable%7B``0%7D%2C``1%2CSystem.Func%7B``1%2C``0%2C``1%7D%2CSystem.Func%7B``1%2C``2%7D%29?displayProperty=nameWithType>|
|<xref:System.Linq.Enumerable.SequenceEqual*?displayProperty=nameWithType>|

## Differences from .NET

 All supported sequence operators work as expected in the common language runtime (CLR) except for `Average`. `Average` returns a value of the same type as the type being averaged, whereas in the CLR `Average` always returns either a <xref:System.Double> or a <xref:System.Decimal>. If the source argument is explicitly cast to double / decimal or the selector casts to double / decimal, the resulting SQL will also have such a conversion and the result will be as expected.

## See also

- [Data Types and Functions](data-types-and-functions.md)
