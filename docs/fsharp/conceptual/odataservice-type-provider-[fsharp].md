---
title: ODataService Type Provider (F#)
description: ODataService Type Provider (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: cc8857eb-5594-41cd-9c95-62db72c15632
---

# ODataService Type Provider (F#)

Provides the types to access an Open Data Protocol (OData) service. OData is a protocol for transfer of data over the Internet. Many data providers expose access to their data by publishing an OData web service. The OData type provider generates types for you based on the structure of the OData source, and thereby allows you to use data from any OData data source immediately in your code, without the usual overhead of creating data types.

**Namespace/Module Path:** Microsoft.FSharp.Data.TypeProviders

**Assembly:** FSharp.Data.TypeProviders (in FSharp.Data.TypeProviders.dll)


## Syntax

```fsharp
type ODataService<ServiceUri : string,
                  ?LocalSchemaFile : string,
                  ?ForceUpdate : bool,
                  ?ResolutionFolder : string,
                  ?DataServiceCollection : bool>
```

## Static Type Parameters


|Type Parameter|Description|
|--------------|-----------|
|ServiceUri : string|The URI string for the OData service.|
|?LocalSchemaFile : string|The path to a file that contains the schema. This file is written by the type provider.|
|?ForceUpdate : bool|Requires that the direct connection to the service is available at design/compile time and the local service file is refreshed. The default value is true. When **ForceUpdate** is false, the provider reacts to changes in the **LocalSchemaFile**.|
|?ResolutionFolder : string|A folder to be used to resolve relative file paths at compile time. The default value is the folder that contains the project or script.|
|?DataServiceCollection : bool|Generates collections derived from **System.Data.Services.Client.DataServiceCollection&#96;1**. The default value is false.|

## Remarks
For a walkthrough that shows how to use the ODataService type provider, see [Walkthrough: Accessing an OData Service by Using Type Providers &#40;F&#35;&#41;](Walkthrough-Accessing-an-OData-Service-by-Using-Type-Providers-%5BFSharp%5D.md).


## About OData (Open Data Protocol)
The OData protocol provides read-only or read-write access to a data source over the Internet. The underlying data can be in one of two formats, one that is XML-based and known as Atom, and one that uses the JavaScript Object Notation (JSON) serialization format. The OData protocol was defined by Microsoft and released as an open standard under the Microsoft Open Specification Promise (OSP).

You do not need to know how the OData protocol is defined and implemented to access data though an OData web service. However, the following brief description may help you understand conceptually what’s going on. The OData protocol follows the principles of Representational State Transfer (REST), meaning that client requests are independent of each other; no session state or data is stored on the server between client requests. Instead, all necessary state is transferred from client to server along with each client request. In the case of OData, client requests include create, read, update, and delete (CRUD) operations. Individual requests from clients are HTTP methods, which include GET, PUT, POST, MERGE, and DELETE, the contents of which specify the details of what is being requested. The server responds to those requests over HTTP.

OData data consists of feeds that are collections of entries. For a database, a feed might represent a table and the entries would be the individual records in that table. An OData web service may also contain a service document that lists the available feeds, service operations that are functions available on that service, and a metadata document that describes all relevant information about the service. All of the resources made available by an OData service are described in the metadata document.


## The OData Type Provider
The OData type provider makes data published to an OData service available to an F# developer as a set of types determined from the structure of the data. That is, when you use the OData type provider, a type is made available for each of the feeds provided by that service. For example, if the OData feeds are a set of tables from a relational database, the type provider makes a type available for each table. The columns of that table are properties of the type. The entries for each feed are available as instances of the type.


## Constructing Queries
Queries on an OData service can be created by using query expressions. Query expressions allow you to construct query results using F# code, much the way sequence expressions allow you to specify sequences. The select keyword plays the same role as the yield keyword. Additionally, query operators may be used to customize a query in the same way as you would in LINQ, in another .NET language, or in a SQL query string.

You can use only a subset of the query operators on OData queries. This is due to limitations in the types of queries that the OData protocol supports. Supported query operators include projection (`select`), ordering (`orderBy`, `thenBy`), filtering (`where`, filtering by string and date), and paging (`skip`, `take`). For more information about these query operators and others, see [Query Expressions &#40;F&#35;&#41;](Query-Expressions-%5BFSharp%5D.md). In addition, you can use the OData specific operations [AddQueryOption](http://go.microsoft.com/fwlink/?LinkID=235228) and [Expand](http://go.microsoft.com/fwlink/?LinkID=235232).


## Generated Types
The following table shows the types generated by an instantiation of the form:

```fsharp
type MyService = ODataService<parameters>
```

In the following table, *ServiceTypeName* represents the name of the service type, and `*` represents all the members of a namespace.

|Type|Description|
|----|-----------|
|MyService|The overall container type.<br /><br />Contains the GetDataContext method, which returns a simplified view of the data context. The method returns a new instance of MyService.ServiceTypes.SimpleDataContextTypes.*ServiceTypeName*, which is initialized with the value of `ServiceUri` static parameter or the argument, if one is provided.|
|MyService.ServiceTypes|Contains the embedded full types and simplified types for the database.|
|MyService.ServiceTypes.&#42;|The embedded types generated by DataSvcUtil.exe.|
|MyService.ServiceTypes.*ServiceTypeName*|The service context type, inherited from `System.Data.Linq.DataContext`.|
|MyService.ServiceTypes.SimpleDataContextTypes.*ServiceTypeName*|Contains one property for each property of the full context type, which returns a `System.Data.Services.Client.DataServiceQuery&#96;1`.<br /><br />The Credentials property gets or sets the credentials used to query the OData service at runtime.<br /><br />The DataContext property gets the full data context, of type `System.Data.Linq.DataContext`. This is the base type of the *ServiceTypeName* type generated by the type provider.|

## Platforms
Windows 8.1, Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

[Microsoft.FSharp.Data.TypeProviders Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Data.TypeProviders-Namespace-%5BFSharp%5D.md)

[Walkthrough: Accessing an OData Service by Using Type Providers &#40;F&#35;&#41;](Walkthrough-Accessing-an-OData-Service-by-Using-Type-Providers-%5BFSharp%5D.md)
