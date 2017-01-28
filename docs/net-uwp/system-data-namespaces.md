---
title: "System.Data namespaces for UWP apps | Microsoft Docs"
ms.custom: ""
ms.date: "12/14/2016"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f72c12ff-c4f2-459b-a996-78edce45047d
caps.latest.revision: 3
author: "msatranjr"
ms.author: "misatran"
manager: "markl"
---
# System.Data namespaces for UWP apps
The `System.Data` namespace and its children namespace (`System.Data.Common`) contain classes for accessing and managing data from diverse sources.  
  
 This topic displays the types in the `System.Data` namespaces that are supported in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)].  
  
## System.Data namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|----------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Data.CommandBehavior>|Provides a description of the results of the query and its effect on the database.|  
|<xref:System.Data.CommandType>|Specifies how a command string is interpreted.|  
|<xref:System.Data.ConnectionState>|Describes the current state of the connection to a data source.|  
|<xref:System.Data.DbType>|Specifies the data type of a field; a property; or a Parameter object of a .NET Framework data provider.|  
|<xref:System.Data.IsolationLevel>|Specifies the transaction locking behavior for the connection.|  
|<xref:System.Data.ParameterDirection>|Specifies the type of a parameter within a query relative to the DataSet.|  
|<xref:System.Data.StateChangeEventArgs>|Provides data for the state change event of a .NET Framework data provider.|  
|<xref:System.Data.StateChangeEventHandler>|Represents the method that will handle the StateChange event.|  
|<xref:System.Data.UpdateRowSource>|Specifies how query command results are applied to the row being updated.|  
  
## System.Data.Common namespace  
  
|Types supported in the [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|----------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Data.Common.DbCommand>|Represents an SQL statement or stored procedure to execute against a data source. Provides a base class for database-specific classes that represent commands. ExecuteNonQueryAsync|  
|<xref:System.Data.Common.DbConnection>|Represents a connection to a database.|  
|<xref:System.Data.Common.DbConnectionStringBuilder>|Provides a base class for strongly typed connection string builders.|  
|<xref:System.Data.Common.DbDataReader>|Reads a forward-only stream of rows from a data source.|  
|<xref:System.Data.Common.DbException>|The base class for all exceptions thrown on behalf of the data source.|  
|<xref:System.Data.Common.DbParameter>|Represents a parameter to a DbCommand and optionally; its mapping to a DataSet column. For more information on parameters; see Configuring Parameters and Parameter Data Types.|  
|<xref:System.Data.Common.DbParameterCollection>|The base class for a collection of parameters relevant to a DbCommand.|  
|<xref:System.Data.Common.DbProviderFactory>|Represents a set of methods for creating instances of a provider's implementation of the data source classes.|  
|<xref:System.Data.Common.DbTransaction>|The base class for a transaction.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)