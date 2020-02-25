---
title: Type Providers
description: Type Providers
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 25697ef6-465e-4248-9de5-1d199d4a8b59
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/tutorials/type-providers/index 
---

# Type Providers

An F# type provider is a component that provides types, properties, and methods for use in your program. Type providers are a significant part of F# 3.0 support for information-rich programming. The key to information-rich programming is to eliminate barriers to working with diverse information sources found on the Internet and in modern enterprise environments. One significant barrier to including a source of information into a program is the need to represent that information as types, properties, and methods for use in a programming language environment. Writing these types manually is very time-consuming and difficult to maintain. A common alternative is to use a code generator which adds files to your project; however, the conventional types of code generation do not integrate well into exploratory modes of programming supported by F# because the generated code must be replaced each time a service reference is adjusted.

The types provided by F# type providers are usually based on external information sources. For example, an F# type provider for SQL will provide the types, properties, and methods you need to work directly with the tables of any SQL database you have access to. Similarly, a type provider for WSDL web services will provide the types, properties, and methods you need to work directly with any WSDL web service.

The set of types, properties, and methods provided by an F# type provider can depend on parameters given in program code. For example, a type provider can provide different types depending on a connection string or a service URL. In this way, the information space available by means of a connection string or URL is directly integrated into your program. A type provider can also ensure that groups of types are only expanded on demand; that is, they are expanded if the types are actually referenced by your program. This allows for the direct, on-demand integration of large-scale information spaces such as online data markets in a strongly typed way.

F# contains several built-in type providers for commonly used Internet and enterprise data services. These type providers give simple and regular access to SQL relational databases and network-based OData and WSDL services and support the use of F# LINQ queries against these data sources.

Where necessary, you can create your own custom type providers, or reference type providers that have been created by others. For example, assume your organization has a data service providing a large and growing number of named data sets, each with its own stable data schema. You may choose to create a type provider that reads the schemas and presents the latest available data sets to the programmer in a strongly typed way.


## Related Topics


|Title|Description|
|-----|-----------|
|[Walkthrough: Accessing a SQL Database by Using Type Providers &#40;F&#35;&#41;](Walkthrough-Accessing-a-SQL-Database-by-Using-Type-Providers-%5BFSharp%5D.md)|Explains how to use the SqlDataConnection type provider to access the tables and stored procedures of a SQL database based on a connection string for a direct connection to a database. The access uses a LINQ to SQL mapping.|
|[Walkthrough: Accessing a SQL Database by Using Type Providers and Entities &#40;F&#35;&#41;](Walkthrough-Accessing-a-SQL-Database-by-Using-Type-Providers-and-Entities-%5BFSharp%5D.md)|Explains how to use the SqlEntityConnection type provider to access the tables and stored procedures of a SQL database, based on a connection string for a direct connection to a database. The access uses a LINQ to Entities mapping. This method works with any database but the example demonstrated is SQL Server.|
|[Walkthrough: Accessing an OData Service by Using Type Providers &#40;F&#35;&#41;](Walkthrough-Accessing-an-OData-Service-by-Using-Type-Providers-%5BFSharp%5D.md)|Explains how to use the ODataService type provider to access an OData service in a strongly typed way based on a service URL.|
|[Walkthrough: Accessing a Web Service by Using Type Providers &#40;F&#35;&#41;](Walkthrough-Accessing-a-Web-Service-by-Using-Type-Providers-%5BFSharp%5D.md)|Explains how to use the WsdlService type provider to access a WSDL web service in a strongly typed way based on a service URL.|
|[Walkthrough: Generating F&#35; Types from a DBML File &#40;F&#35;&#41;](Walkthrough-Generating-FSharp-Types-from-a-DBML-File-%5BFSharp%5D.md)|Explains how to use the DbmlFile type provider to access the tables and stored procedures of a SQLdatabase, based on a DBML file giving a Linq to SQL database schema specification.|
|[Walkthrough: Generating F&#35; Types from an EDMX Schema File &#40;F&#35;&#41;](Walkthrough-Generating-FSharp-Types-from-an-EDMX-Schema-File-%5BFSharp%5D.md)|Explains how to use the EdmxFile type provider to access the tables and stored procedures of a SQL database, based on an EDMX file giving an Entity Framework schema specification.|
|[Tutorial: Creating a Type Provider &#40;F&#35;&#41;](Tutorial-Creating-a-Type-Provider-%5BFSharp%5D.md)|Provides information on writing your own custom type providers.|
|[Type Provider Security](Type-Provider-Security.md)|Provides information about security considerations when developing type providers.|
|[Troubleshooting Type Providers](Troubleshooting-Type-Providers.md)|Provides information about common problems that can arise when working with type providers and includes suggestions for solutions.|

## See Also
[F&#35; Language Reference](FSharp-Language-Reference.md)

[Visual F&#35;](Visual-FSharp.md)

[What's New in Visual Studio 2015](https://msdn.microsoft.com/library/bb386063.aspx)