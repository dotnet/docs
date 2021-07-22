---
title: "Entity Framework Overview"
description: The Entity Framework in ADO.NET supports development of data-oriented applications that work at a higher level of abstraction than traditional applications.
ms.date: 09/17/2018
ms.assetid: a2166b3d-d8ba-4a0a-8552-6ba1e3eaaee0
---
# Entity Framework overview

The Entity Framework is a set of technologies in ADO.NET that support the development of data-oriented software applications. Architects and developers of data-oriented applications have struggled with the need to achieve two very different objectives. They must model the entities, relationships, and logic of the business problems they are solving, and they must also work with the data engines used to store and retrieve the data. The data may span multiple storage systems, each with its own protocols; even applications that work with a single storage system must balance the requirements of the storage system against the requirements of writing efficient and maintainable application code.

The Entity Framework enables developers to work with data in the form of domain-specific objects and properties, such as customers and customer addresses, without having to concern themselves with the underlying database tables and columns where this data is stored. With the Entity Framework, developers can work at a higher level of abstraction when they deal with data, and can create and maintain data-oriented applications with less code than in traditional applications. Because the Entity Framework is a component of the .NET Framework, Entity Framework applications can run on any computer on which the .NET Framework starting with version 3.5 SP1 is installed.

## Give life to models

 A longstanding and common design approach when building an application or service is the division of the application or service into three parts: a domain model, a logical model, and a physical model. The domain model defines the entities and relationships in the system that is being modeled. The logical model for a relational database normalizes the entities and relationships into tables with foreign key constraints. The physical model addresses the capabilities of a particular data engine by specifying storage details such as partitioning and indexing.

 The physical model is refined by database administrators to improve performance, but programmers writing application code primarily confine themselves to working with the logical model by writing SQL queries and calling stored procedures. Domain models are generally used as a tool for capturing and communicating the requirements of an application, frequently as inert diagrams that are viewed and discussed in the early stages of a project and then abandoned. Many development teams skip creating a conceptual model and begin by specifying tables, columns, and keys in a relational database.

 The Entity Framework gives life to models by enabling developers to query entities and relationships in the domain model (called a *conceptual* model in the Entity Framework) while relying on the Entity Framework to translate those operations to data source–specific commands. This frees applications from hard-coded dependencies on a particular data source.

 When working with Code First, the conceptual model is mapped to the storage model in code. The Entity Framework can infer the conceptual model based on the object types and additional configurations that you define. The mapping metadata is generated during run time based on a combination of how you defined your domain types and additional configuration information that you provide in code. Entity Framework generates the database as needed based on the metadata. For more information, see [Creating a Model](/ef/ef6/modeling/).

 When working with the Entity Data Model Tools, the conceptual model, the storage model, and the mappings between the two are expressed in XML-based schemas and defined in files that have corresponding name extensions:

- Conceptual schema definition language (CSDL) defines the conceptual model. CSDL is the Entity Framework's implementation of the [Entity Data Model](../entity-data-model.md). The file extension is .csdl.

- Store schema definition language (SSDL) defines the storage model, which is also called the logical model. The file extension is .ssdl.

- Mapping specification language (MSL) defines the mappings between the storage and conceptual models. The file extension is .msl.

The storage model and mappings can change as needed without requiring changes to the conceptual model, data classes, or application code. Because storage models are provider-specific, you can work with a consistent conceptual model across various data sources.

The Entity Framework uses these model and mapping files to create, read, update, and delete operations against entities and relationships in the conceptual model to equivalent operations in the data source. The Entity Framework even supports mapping entities in the conceptual model to stored procedures in the data source. For more information, see [CSDL, SSDL, and MSL Specifications](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec).

## Map objects to data

 Object-oriented programming poses a challenge for interacting with data storage systems. Although the organization of classes frequently mirrors the organization of relational database tables, the fit is not perfect. Multiple normalized tables frequently correspond to a single class, and relationships between classes are often represented differently than relationships between tables are represented. For example, to represent the customer for a sales order, an `Order` class might use a property that contains a reference to an instance of a `Customer` class, while an `Order` table row in a database contains a foreign key column (or set of columns) with a value that corresponds to a primary key value in the `Customer` table. A `Customer` class might have a property named `Orders` that contains a collection of instances of the `Order` class, while the `Customer` table in a database has no comparable column. The Entity Framework provides developers with the flexibility to represent relationships in this way, or to more closely model relationships as they are represented in the database.

 Existing solutions have tried to bridge this gap, which is frequently called an "impedance mismatch", by only mapping object-oriented classes and properties to relational tables and columns. Instead of taking this traditional approach, the Entity Framework maps relational tables, columns, and foreign key constraints in logical models to entities and relationships in conceptual models. This enables greater flexibility both in defining objects and optimizing the logical model. The Entity Data Model tools generate extensible data classes based on the conceptual model. These classes are partial classes that can be extended with additional members that the developer adds. By default, the classes that are generated for a particular conceptual model derive from base classes that provide services for materializing entities as objects and for tracking and saving changes. Developers can use these classes to work with the entities and relationships as objects related by associations. Developers can also customize the classes that are generated for a conceptual model. For more information, see [Working with Objects](working-with-objects.md).

## Access and change entity data

More than just another object-relational mapping solution, the Entity Framework is fundamentally about enabling applications to access and change data that is represented as entities and relationships in the conceptual model. The Entity Framework uses information in the model and mapping files to translate object queries against entity types represented in the conceptual model into data source-specific queries. Query results are materialized into objects that the Entity Framework manages. The Entity Framework provides the following ways to query a conceptual model and return objects:

- LINQ to Entities. Provides Language-Integrated Query (LINQ) support for querying entity types that are defined in a conceptual model. For more information, see [LINQ to Entities](./language-reference/linq-to-entities.md).

- Entity SQL. A storage-independent dialect of SQL that works directly with entities in the conceptual model and that supports Entity Data Model concepts. Entity SQL is used both with object queries and queries that are executed by using the EntityClient provider. For more information, see [Entity SQL Overview](./language-reference/entity-sql-overview.md).

The Entity Framework includes the EntityClient data provider. This provider manages connections, translates entity queries into data source-specific queries, and returns a data reader that the Entity Framework uses to materialize entity data into objects. When object materialization is not required, the EntityClient provider can also be used like a standard ADO.NET data provider by enabling applications to execute Entity SQL queries and consume the returned read-only data reader. For more information, see [EntityClient Provider for the Entity Framework](entityclient-provider-for-the-entity-framework.md).

The following diagram illustrates the Entity Framework architecture for accessing data:

![Entity Framework Architectural Diagram](./media/wd-efarchdiagram.gif "wd_EFArchDiagram")

The Entity Data Model Tools can generate a class derived from `System.Data.Objects.ObjectContext` or `System.Data.Entity.DbContext` that represents the entity container in the conceptual model. This object context provides the facilities for tracking changes and managing identities, concurrency, and relationships. This class also exposes a `SaveChanges` method that writes inserts, updates, and deletes to the data source. Like queries, these changes are either made by commands automatically generated by the system or by stored procedures that are specified by the developer.

## Data providers

The `EntityClient` provider extends the ADO.NET provider model by accessing data in terms of conceptual entities and relationships. It executes queries that use Entity SQL. Entity SQL provides the underlying query language that enables `EntityClient` to communicate with the database. For more information, see [EntityClient Provider for the Entity Framework](entityclient-provider-for-the-entity-framework.md).

The Entity Framework includes an updated SqlClient Data Provider that supports canonical command trees. For more information, see [SqlClient for the Entity Framework](sqlclient-for-the-entity-framework.md).

## Entity data model tools

Together with the Entity Framework runtime, Visual Studio includes the mapping and modeling tools. For more information, see [Modeling and Mapping](modeling-and-mapping.md).

## Learn more

To learn more about the Entity Framework, see:

[Getting Started](getting-started.md) - Provides information about how to get up and running quickly using the [Quickstart](/previous-versions/dotnet/netframework-4.0/bb399182(v=vs.100)), which shows how to create a simple Entity Framework application.

[Entity Framework Terminology](terminology.md) - Defines many of the terms that are introduced by the Entity Data Model and the Entity Framework and that are used in Entity Framework documentation.

[Entity Framework Resources](resources.md) - Provides links to conceptual topics and links to external topics and resources for building Entity Framework applications.

## See also

- [ADO.NET Entity Framework](index.md)
