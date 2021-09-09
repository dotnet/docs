---
description: "Learn more about: ADO.NET Technology Options and Guidelines"
title: "Technology Options and Guidelines"
ms.date: "03/30/2017"
ms.assetid: c8577281-38e6-4ce5-b036-572039a4c3d8
---
# ADO.NET Technology Options and Guidelines

The ADO.NET Data Platform is a multi-release strategy to decrease the amount of coding and maintenance required for developers by enabling them to program against conceptual entity data models. This platform includes the ADO.NET Entity Framework and related technologies.  
  
## Entity Framework  

 The ADO.NET Entity Framework is designed to enable developers to create data access applications by programming against a conceptual application model instead of programming directly against a relational storage schema. The goal is to decrease the amount of code and maintenance required for data-oriented applications. For more information, see [ADO.NET Entity Framework](./ef/index.md).  
  
### Entity Data Model (EDM)  

 An Entity Data Model (EDM) is a design specification that defines application data as sets of entities and relationships. Data in this model supports object-relational mapping and data programmability across application boundaries.  
  
### Object Services  

 Object Services allows programmers to interact with the conceptual model through a set of common language runtime (CLR) classes. These classes can be automatically generated from the conceptual model or can be developed independently to reflect the structure of the conceptual model. Object Services also provides infrastructure support for the Entity Framework, including services such as state management, change tracking, identity resolution, loading and navigating relationships, propagating object changes to database modifications, and query building support for Entity SQL. For more information, see [Object Services Overview (Entity Framework)](/previous-versions/bb386871(v=vs.100)).  
  
### LINQ to Entities  

 LINQ to Entities is a language-integrated query (LINQ) implementation that allows developers to create strongly typed queries against the Entity Framework object context by using LINQ expressions and LINQ standard query operators. LINQ to Entities allows developers to work against a conceptual model with a flexible object-relational mapping across Microsoft SQL Server and third-party databases. For more information, see [LINQ to Entities](./ef/language-reference/linq-to-entities.md).  
  
### Entity SQL  

 Entity SQL is a text-based query language designed to interact with an Entity Data Model. Entity SQL is an SQL dialect that contains constructs for querying in terms of higher-level modeling concepts, such as inheritance, complex types, and explicit relationships. Developers can also use Entity SQL directly with Object Services. For more information, see [Entity SQL Language](./ef/language-reference/entity-sql-language.md).  
  
### EntityClient  

 EntityClient is a new .NET Framework data provider used for interacting with an Entity Data Model. EntityClient follows the .NET Framework data provider pattern of exposing <xref:System.Data.EntityClient.EntityConnection> and <xref:System.Data.EntityClient.EntityCommand> objects that return an <xref:System.Data.EntityClient.EntityDataReader>. EntityClient works with the Entity SQL language, providing flexible mapping to storage-specific data providers. For more information, see [EntityClient Provider for the Entity Framework](./ef/entityclient-provider-for-the-entity-framework.md).  
  
### Entity Data Model Tools  

 The Entity Framework provides command-line tools, wizards, and designers to facilitate building EDM applications. The EntityDataSource control supports data binding scenarios based on the EDM. The programming surface of the EntityDataSource control is similar to other data source controls in Visual Studio. For more information, see [ADO.NET Entity Data Model Tools](/previous-versions/dotnet/netframework-4.0/bb399249(v=vs.100)).  
  
## LINQ to SQL  

 LINQ to SQL is an object relational mapping (OR/M) implementation that allows you to model a SQL Server database by using .NET Framework classes. LINQ to SQL allows you to query your database by using LINQ, as well as update, insert, and delete data from it. LINQ to SQL supports transactions, views, and stored procedures, providing an easy way to integrate data validation and business logic rules into your data model. You can use the Object Relational Designer (O/R Designer) to model the entity classes and associations that are based on objects in a database. For more information, see [LINQ to SQL Tools in Visual Studio](/visualstudio/data-tools/linq-to-sql-tools-in-visual-studio2).  
  
## WCF Data Services  

 WCF Data Services deploys data services on the Web or on an intranet. The data is structured as entities and relationships according to the specifications of the Entity Data Model. Data deployed on this model is addressable by standard HTTP protocol. For more information, see [WCF Data Services 4.5](/previous-versions/dotnet/framework/data/wcf/index).  
  
## See also

- [ADO.NET Overview](ado-net-overview.md)
- [What's New in ADO.NET](whats-new.md)
