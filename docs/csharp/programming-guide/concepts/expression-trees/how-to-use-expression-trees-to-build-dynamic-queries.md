---
title: "Querying based on runtime state (C#)"
description: Describes various techniques your code can use to query dynamically depending on runtime state, by varying either LINQ method calls or the expression trees passed into those methods.
ms.date: 07/20/2015
ms.assetid: 52cd44dd-a3ec-441e-b93a-4eca388119c7
---
# Querying based on runtime state (C#)

Consider code that defines an <xref:System.Linq.IQueryable%601> or an <xref:System.Linq.IQueryable> against a data source:

```csharp
var companyNames = new[] {
    "Consolidated Messenger", "Alpine Ski House", "Southridge Video",
    "City Power & Light", "Coho Winery", "Wide World Importers",
    "Graphic Design Institute", "Adventure Works", "Humongous Insurance",
    "Woodgrove Bank", "Margie's Travel", "Northwind Traders",
    "Blue Yonder Airlines", "Trey Research", "The Phone Company",
    "Wingtip Toys", "Lucerne Publishing", "Fourth Coffee"
};

// We're using an in-memory array as the data source, but the IQueryable could have come
// from anywhere -- an ORM backed by a database, a web request, or any other LINQ provider.
IQueryable<string> companyNamesSource = companyNames.AsQueryable();

var qry = companyNames.OrderBy(x => x);
```

Every time you run this code, the same exact query will be executed. This is frequently not very useful, as you may want your code to execute different queries under varying conditions. This article describes how you can execute a different query based on runtime state.

## IQueryable, IQueryable\<T> and expression trees

Fundamentally, an <xref:System.Linq.IQueryable> has two components:

* <xref:System.Linq.IQueryable.Expression>&mdash;a language- and datasource-agnostic representation of the current query's elements, in the form of an expression tree.
* <xref:System.Linq.IQueryable.Provider>&mdash;an object which knows how to translate the current query into actual .NET objects, a.k.a. an instance of a LINQ provider.

In the context of dynamic querying, the provider will usually remain the same; the expression tree of the query will differ from query to query.

Because expression trees are immutable, if you want a different expression tree&mdash;and thus a different query&mdash;you'll need to translate the existing expression tree to a new one, and thus to a new **IQueryable**.

The following sections describe specific techniques for querying differently in response to runtime state:

- Referencing runtime state directly in the expression tree
- Calling additional LINQ methods
- Varying the expression tree passed into the LINQ methods
- Constructing expression trees using the factory methods at <xref:System.Linq.Expressions.Expression>

## Referencing runtime state from the expression tree

Assuming the LINQ provider supports it, the simplest way to query dynamically is to reference the runtime state directly in the query, via a closed-over variable:

```csharp
var length = 1;
var qry = companyNamesSource
    .Select(x => x.Substring(0, length))
    .Distinct();
    
Console.WriteLine(string.Join(",", qry));
// prints: C, A, S, W, G, H, M, N, B, T, L, F

length = 2;
Console.WriteLine(string.Join(",", qry));
// prints: Co, Al, So, Ci, Wi, Gr, Ad, Hu, Wo, Ma, No, Bl, Tr, Th, Lu, Fo 
```

The expression tree hasn't been modified; the query returns different values only because the value of `length` has been changed.

## Call additional LINQ methods

The LINQ methods on <xref:System.Linq.Queryable> generally consist of two steps:

* Wrap the current expression tree in a <xref:System.Linq.Expressions.MethodCallExpression> representing the method call.
* Pass the wrapped expression tree back to the provider, either to return a value via the provider's <xref:System.Linq.IQueryProvider.Execute%2A?displayProperty=nameWithType> method; or to return a translated query object via the <xref:System.Linq.IQueryProvider.CreateQuery%2A?displayProperty=nameWithType> method.

Thus, you can replace the original query with the result of an [IQueryable\<T>](xref:System.Linq.IQueryable%601)-returning method, to get a new query.

You can do this based on runtime state, as in the following example:

```csharp
bool sortByLength = /* ... */;

var qry = companyNamesSource;
if (sortByLength) {
    qry = qry.OrderBy(x => x.Length);
}
```

## Vary the expression tree passed into the LINQ methods

You can pass in different expressions to the LINQ methods, depending on runtime state:

```csharp
string startsWith = /* ... */;
string endsWith = /* ... */;

Expression<Func<string, bool>>? expr = null;
if (!string.IsNullOrEmpty(startsWith) && !string.IsNullOrEmpty(endsWith)) {
    expr = x => x.StartsWith(startsWith) || x.EndsWith(endsWith);
} else if (!string.IsNullOrEmpty(startsWith)) {
    expr = x => x.StartsWith(startsWith);
} else if (!string.IsNullOrEmpty(endsWith)) {
    expr = x => x.EndsWith(endsWith);
} else {
    expr = x => true;
}

var qry = companyNamesSource.Where(expr);
```

You might also want to compose the various sub-expressions using a third-party library such as [LinqKit](http://www.albahari.com/nutshell/linqkit.aspx)'s [PredicateBuilder](http://www.albahari.com/nutshell/predicatebuilder.aspx):

```csharp
// using LinqKit;

// This is functionally equivalent to the previous example.

string startsWith = /* ... */;
string endsWith = /* ... */;

var qry = companyNamesSource;

bool hasStartsWith = !string.IsNullOrEmpty(startsWith);
bool hasEndsWith = !string.IsNullOrEmpty(endsWith);

if (hasStartsWith || hasEndsWith) {
    Expression<Func<string, bool>>? expr = PredicateBuilder.New<string>(false);
    if (hasStartsWith) {
        expr = expr.Or(x => x.StartsWith(startsWith));
    }
    if (hasEndsWith) {
        expr = expr.Or(x => x.EndsWith(endsWith));
    }
    qry = qry.Where(expr);
}
```

## Construct expression trees and queries using factory methods

In all the examples up to this point, we've known the element type at compile time&mdash;`string`&mdash;and thus the type of the query&mdash;`IQueryable<string>`. But what if you want to add components to a query without limiting yourself to a specific element type? And moreover, what if the components you want to add are different depending on the type?

To do this, you must create the expression trees from the ground up, using the factory methods at <xref:System.Linq.Expressions.Expression>.

For example, let's say you have multiple entity types:

```csharp
record Person(string LastName, string FirstName, DateTime DateOfBirth);
record Car(string Model, int Year);
```

For any of these entity types, you want to filter and return only those entities that have a given text inside one of their `string` fields. For `Person`, you'd want to search the `FirstName` and `LastName` properties:

```csharp
string term = /* ... */;
var personsQry = new List<Person>()
    .AsQueryable()
    .Where(x => x.FirstName.Contains(term) || x.LastName.Contains(term));
```

but for `Car`, you'd want to search only the `Model` property:

```csharp
string term = /* ... */;
var carsQry = new List<Car>()
    .AsQueryable()
    .Where(x => x.Model.Contains(term));
```

While you could write one custom function for `IQueryable<Person>` and another for `IQueryable<Car>`, the following example shows a function that adds this filtering to any existing query, irrespective of the specific element type. Note that because it takes and returns an `IQueryable<T>`, you can add further strongly-typed query elements after the text filter.

```csharp
// using static System.Linq.Expressions.Expression

IQueryable<T> TextFilter<T>(IQueryable<T> source, string term) {
    if (string.IsNullOrEmpty(term)) { return source; }

    // T is a compile-time placeholder for the element type of the query.
    var elementType = typeof(T);

    // Get all the string properties on this specific type.
    var stringProperties = 
        elementType.GetProperties()
            .Where(x => x.PropertyType == typeof(string))
            .ToArray();
    if (!stringProperties.Any()) { return source; }

    // Get a hold of the right overload of the Contains method
    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) })!;

    // Create a parameter for the expression tree; the `x`
    // The type of this parameter is the query's element type
    var prm = Parameter(elementType);

    Expression? body = null;
    foreach (var prp in stringProperties) {
        // For each property, we have to construct an expression tree like x.PropertyName.Contains("term")
        var clause =
            Call(                      // .Contains(...) 
                Property(prm, prp),        // .PropertyName
                containsMethod,
                Constant(term)             // "term" 
            );

        // If this is the first clause
        if (body is null) {
            body = clause;
        } else {
            // Combine this clause with the current body using ||
            body = Or(body, clause);
        }
    }

    // Wrap the expression body in a strongly-typed lambda expression
    Expression<Func<T, bool>> lambda = Lambda<Func<T, bool>>(body, prm);

    // Because the lambda is strongly typed (albeit with a generic parameter), w e can use it with the Where method
    return source.Where(lambda);
}
```

Finally, if all you have is an `IQueryable` and not an `IQueryable<T>`, you can't directly call the generic LINQ methods at <xref:System.Linq.Queryable>. One alternative is to build the inner expression tree, and invoke the appropriate LINQ method with that expression tree using reflection.

You could also duplicate the LINQ method's functionality, by wrapping the entire tree in a `MethodCallExpression` node which represents a call to the LINQ method:

```csharp
IQueryable TextFilter(IQueryable source, string term) {
    if (string.IsNullOrEmpty(term)) { return source; }
    var type = source.ElementType;

    // build the expression body based on the element type's string properties
    // as in the previous example
    var (body, prm) = /* ... */;

    var filteredTree = Call(
        typeof(Queryable),
        "Where",
        new[] { source.ElementType },
        source.Expression,
        Lambda(body, prm)
    );

    return source.Provider.CreateQuery(filteredTree);
}
```

## The Dynamic LINQ library

Constructing expression trees using factory methods is relatively complex; it is easier to compose strings. The [Dynamic LINQ library](https://dynamic-linq.net/) exposes a set of extension methods on <xref:System.Linq.IQueryable> corresponding to the standard LINQ methods at <xref:System.Linq.Queryable>, and which accept strings in a [special syntax](https://dynamic-linq.net/expression-language) instead of expression trees. The library generates the appropriate expression tree from the string, and returns the resultant translated <xref:System.Linq.IQueryable>.

For instance, the previous example could be rewritten as follows:

```csharp
// using System.Linq.Dynamic.Core

IQueryable TextFilter(IQueryable source, string term) {
    if (string.IsNullOrEmpty(term)) { return source; }

    var type = source.ElementType;

    // Get all the string property names on this specific type.
    var stringProperties = 
        elementType.GetProperties()
            .Where(x => x.PropertyType == typeof(string))
            .ToArray();
    if (!stringProperties.Any()) { return source; }

    // Build the string expression
    string filterExpr = string.Join(
        " || ",
        stringProperties.Select(prp => $"{prp.Name}.Contains(@0)")
    );

    return source.Where(filterExpr);
}
```

## See also

- [Expression Trees (C#)](./index.md)
- [How to execute expression trees (C#)](./how-to-execute-expression-trees.md)
- [Dynamically specify predicate filters at runtime](../../../linq/dynamically-specify-predicate-filters-at-runtime.md)
