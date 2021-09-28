---
description: "Learn more about: Canonical Functions"
title: "Canonical Functions"
ms.date: "03/30/2017"
ms.assetid: bbcc9928-36ea-4dff-9e31-96549ffed958
---
# Canonical Functions

This section discusses canonical functions that are supported by all data providers, and can be used by all querying technologies. Canonical functions cannot be extended by a provider.

 These canonical functions will be translated to the corresponding data source functionality for the provider. This allows for function invocations expressed in a common form across data sources.

 Because these canonical functions are independent of data sources, argument and return types of canonical functions are defined in terms of types in the conceptual model. However, some data sources might not support all types in the conceptual model.

 When canonical functions are used in an Entity SQL query, the appropriate function will be called at the data source.

 All canonical functions have both null-input behavior and error conditions explicitly specified. Store providers should comply with that behavior, but Entity Framework does not enforce this behavior.

 For LINQ scenarios, queries against the Entity Framework involve mapping CLR methods to methods in the underlying data source. The CLR methods map to canonical functions, so that a specific set of methods will correctly map, regardless of the data source.

## Canonical Functions Namespace

 The namespace for canonical function is <xref:System.Data.Metadata.Edm>. The <xref:System.Data.Metadata.Edm> namespace is automatically included in all queries. However, if another namespace is imported that contains a function with the same name as a canonical function (in the <xref:System.Data.Metadata.Edm> namespace), you must specify the namespace.

## In This Section

 [Aggregate Canonical Functions](aggregate-canonical-functions.md)
 Discusses aggregate Entity SQL canonical functions.

 [Math Canonical Functions](math-canonical-functions.md)
 Discusses math Entity SQL canonical functions.

 [String Canonical Functions](string-canonical-functions.md)
 Discusses string Entity SQL canonical functions.

 [Date and Time Canonical Functions](date-and-time-canonical-functions.md)
 Discusses date and time Entity SQL canonical functions.

 [Bitwise Canonical Functions](bitwise-canonical-functions.md)
 Discusses bitwise Entity SQL canonical functions.

 [Spatial Functions](spatial-functions.md)
 Discusses Spatial Entity SQL canonical functions.

 [Other Canonical Functions](other-canonical-functions.md)
 Discusses functions not classified as bitwise, date/time, string, math, or aggregate.

## See also

- [Entity SQL Overview](entity-sql-overview.md)
- [Entity SQL Reference](entity-sql-reference.md)
- [Conceptual Model Canonical to SQL Server Functions Mapping](../conceptual-model-canonical-to-sql-server-functions-mapping.md)
- [User-Defined Functions](user-defined-functions-entity-sql.md)
