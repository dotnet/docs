---
title: "ADO.NET Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ee3bc1d8-11db-4be4-89eb-c708cf04117d
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# ADO.NET Overview
ADO.NET provides consistent access to data sources such as SQL Server and XML, and to data sources exposed through OLE DB and ODBC. Data-sharing consumer applications can use ADO.NET to connect to these data sources and retrieve, handle, and update the data that they contain.  
  
 ADO.NET separates data access from data manipulation into discrete components that can be used separately or in tandem. ADO.NET includes .NET Framework data providers for connecting to a database, executing commands, and retrieving results. Those results are either processed directly, placed in an ADO.NET <xref:System.Data.DataSet> object in order to be exposed to the user in an ad hoc manner, combined with data from multiple sources, or passed between tiers. The `DataSet` object can also be used independently of a .NET Framework data provider to manage data local to the application or sourced from XML.  
  
 The ADO.NET classes are found in System.Data.dll, and are integrated with the XML classes found in System.Xml.dll. For sample code that connects to a database, retrieves data from it, and then displays that data in a console window, see [ADO.NET Code Examples](../../../../docs/framework/data/adonet/ado-net-code-examples.md).  
  
 ADO.NET provides functionality to developers who write managed code similar to the functionality provided to native component object model (COM) developers by ActiveX Data Objects (ADO). We recommend that you use ADO.NET, not ADO, for accessing data in your .NET applications.  
  
 ADO.NET provides the most direct method of data access within the .NET Framework. For a higher-level abstraction that allows applications to work against a conceptual model instead of the underlying storage model, see the [ADO.NET Entity Framework](../../../../docs/framework/data/adonet/ef/index.md).  
  
 **Privacy Statement**: The System.Data.dll, System.Data.Design.dll, System.Data.OracleClient.dll, System.Data.SqlXml.dll, System.Data.Linq.dll, System.Data.SqlServerCe.dll, and System.Data.DataSetExtensions.dll assemblies do not distinguish between a user's private data and non-private data.  These assemblies do not collect, store, or transport any user's private data. However, third-party applications might collect, store, or transport a user's private data using these assemblies.  
  
## In This Section  
 [ADO.NET Architecture](../../../../docs/framework/data/adonet/ado-net-architecture.md)  
 Provides an overview of the architecture and components of ADO.NET.  
  
 [ADO.NET Technology Options and Guidelines](../../../../docs/framework/data/adonet/ado-net-technology-options-and-guidelines.md)  
 Describes the products and technologies included with the Entity Data Platform.  
  
 [LINQ and ADO.NET](../../../../docs/framework/data/adonet/linq-and-ado-net.md)  
 Describes how Language-Integrated Query (LINQ) is implemented in ADO.NET and provides links to relevant topics.  
  
 [.NET Framework Data Providers](../../../../docs/framework/data/adonet/data-providers.md)  
 Provides an overview of the design of the .NET Framework data provider and of the .NET Framework data providers that are included with ADO.NET.  
  
 [ADO.NET DataSets](../../../../docs/framework/data/adonet/ado-net-datasets.md)  
 Provides an overview of the `DataSet` design and components.  
  
 [Side-by-Side Execution in ADO.NET](../../../../docs/framework/data/adonet/side-by-side-execution.md)  
 Discusses differences in ADO.NET versions and their effect on side-by-side execution and application compatibility.  
  
 [ADO.NET Code Examples](../../../../docs/framework/data/adonet/ado-net-code-examples.md)  
 Provides code samples that retrieve data using the ADO.NET data providers.  
  
## Related Sections  
 [What's New in ADO.NET](../../../../docs/framework/data/adonet/whats-new.md)  
 Introduces features that are new in [!INCLUDE[vstecado](../../../../includes/vstecado-md.md)].  
  
 [Securing ADO.NET Applications](../../../../docs/framework/data/adonet/securing-ado-net-applications.md)  
 Describes secure coding practices when using ADO.NET.  
  
 [Data Type Mappings in ADO.NET](../../../../docs/framework/data/adonet/data-type-mappings-in-ado-net.md)  
 Describes data type mappings between .NET Framework data types and the .NET Framework data providers.  
  
 [Retrieving and Modifying Data in ADO.NET](../../../../docs/framework/data/adonet/retrieving-and-modifying-data.md)  
 Describes how to connect to a data source, retrieve data, and modify data. This includes `DataReaders` and `DataAdapters`.  
  
## See Also  
 [ADO.NET](../../../../docs/framework/data/adonet/index.md)  
 [Accessing data in Visual Studio](/visualstudio/data-tools/accessing-data-in-visual-studio)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
