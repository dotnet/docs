---
title: Return a query from a method
description: How to return a query.
ms.date: 11/30/2016
ms.assetid: db220f79-c35b-41f2-886c-cd068672d42d
---
# How to return a query from a method

This example shows how to return a query from a method as the return value and as an `out` parameter.  
  
 Query objects are composable, meaning that you can return a query from a method. Objects that represent queries do not store the resulting collection, but rather the steps to produce the results when needed. The advantage of returning query objects from methods is that they can be further composed or modified. Therefore any return value or `out` parameter of a method that returns a query must also have that type. If a method materializes a query into a concrete <xref:System.Collections.Generic.List%601> or <xref:System.Array> type, it is considered to be returning the query results instead of the query itself. A query variable that is returned from a method can still be composed or modified.  
  
## Example

In the following example, the first method `QueryMethod1` returns a query as a return value, and the second method `QueryMethod2` returns a query as an `out` parameter (`returnQ` in the example). Note that in both cases it is a query that is returned, not query results.

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/ReturnQueryFromMethod.cs" id="return_query_from_method_1":::

Query `myQuery1` is executed in the following foreach loop.

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/ReturnQueryFromMethod.cs" id="return_query_from_method_2":::

Rest the mouse pointer over `myQuery1` to see its type.

You also can execute the query returned from `QueryMethod1` directly, without using `myQuery1`.

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/ReturnQueryFromMethod.cs" id="return_query_from_method_3":::

Rest the mouse pointer over the call to `QueryMethod1` to see its return type.

`QueryMethod2` returns a query as the value of its out parameter:
:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/ReturnQueryFromMethod.cs" id="return_query_from_method_4":::

You can modify a query by using query composition. In this case, the previous query object is used to create a new query object. This new object will return different results than the original query object.

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/ReturnQueryFromMethod.cs" id="return_query_from_method_5":::

## See also

- [Language Integrated Query (LINQ)](index.md)
