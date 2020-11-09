---
title: Using observable providers
description: Using observable providers
author: IEvangelist
ms.author: dapine
ms.date: 11/09/2020
---

# Use observable providers

By implementing the `IQbservable` interface and using the factory extension methods provided by the `Qbservable` type, you can write a custom LINQ provider to query any type of external data. You can use the factory LINQ operators provided by the `Qbservable` type to abstract a sequence of events and query, filter and compose them. Subscribing to this sequence will trigger the translation of the LINQ query expression into the target language.

## Query external data with `IQbservable`

When we mention that we want to query for data, we are first concerned about what we want to query. This can be a pulled-based `IEnumerable` collection, or a push-based asynchronous `Observable` sequence. We also want to know where (under which context) do we want to execute the query. For `Observable` sequences, that is handled by the `IScheduler` interface and its various Scheduler implementation types. Finally, we want to know how we do the query. We can represent a query (a lambda expression) in verbatim (compiled into .NET intermediate language (IL) code), in which each operator in the query will be evaluated in a linear fashion. This is the case for the factory operator methods of the `Observable` type. Or you can represent your query using expression trees, which can be traversed to get the represented algorithm (e.g., predicting whether an item is greater than a value), then translate the algorithm into some domain-specific code, such as a T-SQL query statement for querying a SQL database, specific HTTP requests for a particular Web service URI, and PowerShell commands as an example. This is the case for the factory operator methods of the `Qbservable` type. The translated domain-specific code can be executed in a remote target system, or you can use the expression tree representation to do local query optimization.

Just like <xref:System.IObservable%601> and <xref:System.IObserver%601> is a dual of <xref:System.Collections.Generic.IEnumerable%601> and <xref:System.Collections.Generic.IEnumerator%601>, `IQbservable` is the dual of <xref:System.Linq.IQueryable%601> and provides an expression tree representation of an `IObservable` query. You can change between `IQbservable` and <xref:System.IObservable%601> types by using the `AsQbservable` and `AsObservable` methods. Calling `AsQbservable` produces an expression tree made up of a single node that calls the original <xref:System.IObservable%601> instance. This relationship is important for understanding why a complete `IQbservable` query has to be defined starting from an `IQbservable` sequence and cannot be obtained simply by calling `AsQbservable` on an existing `IQbservable` query. In the following example, the call to `AsQbservable` produces a complete query tree only when you build the query by applying `AsQbservable` to the data source.

:::code language="csharp" source="snippets/qbservable/Program.cs":::

The `IQbservable` interface is intended for implementation by query providers. It is only supposed to be implemented by providers that also implement `IQbservable<T>`. If the provider does not also implement `IQbservable<T>`, the standard query operators cannot be used on the provider's data source. The `IQbservable` interface inherits the <xref:System.IObservable%601> interface so that if it represents a query, the results of that query can be subscribed to. Subscription and publication causes the expression tree associated with an `Qbservable` object to be executed. The definition of "executing an expression tree" is specific to a query provider. For example, it may involve translating the expression tree to an appropriate query language for the underlying data source. The `Expression` property encapsulates the expression tree that is associated with the `IQbservable` instance, whereas the Provider encapsulates the query provider that is associated with the data source.

The set of methods declared in the `Qbservable` class provides an implementation of the standard query operators for querying data sources that implement `IQbservable`. The standard query operators are general purpose methods that follow the LINQ pattern and enable you to express traversal, filter, and projection operations over data in any .NET-based programming language. The majority of the methods in this class are defined as extension methods that extend the `IQbservable` type. This means they can be called like an instance method on any object that implements `IQbservable`. These methods that extend `IQbservable` do not perform any querying directly. Instead, their functionality is to build an <xref:System.Linq.Expressions.Expression> object, which is an expression tree that represents the cumulative query. The methods then pass the new expression tree to the `CreateQuery` method. The actual query execution on the target data is performed by a class that implements `IQbservable`.

## See also

- TODO: add see also bits...
