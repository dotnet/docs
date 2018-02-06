---
title: "Modifying Data with a DbDataAdapter"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: e35c7f9e-648b-4fcc-9361-d365c3e42c9a
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Modifying Data with a DbDataAdapter
The <xref:System.Data.Common.DbProviderFactory.CreateDataAdapter%2A> method of a <xref:System.Data.Common.DbProviderFactory> object gives you a <xref:System.Data.Common.DbDataAdapter> object that is strongly typed to the underlying data provider specified at the time you create the factory. You can then use a <xref:System.Data.Common.DbCommandBuilder> to create commands to insert, update, and delete data from a <xref:System.Data.DataSet> to a data source.  
  
## Retrieving Data with a DbDataAdapter  
 This example demonstrates how to create a strongly typed `DbDataAdapter` based on a provider name and connection string. The code uses the <xref:System.Data.Common.DbProviderFactory.CreateConnection%2A> method of the <xref:System.Data.Common.DbProviderFactory> to create a <xref:System.Data.Common.DbConnection>. Next, the code uses the <xref:System.Data.Common.DbProviderFactory.CreateCommand%2A> method to create a <xref:System.Data.Common.DbCommand> to select data by setting its `CommandText` and `Connection` properties. Finally, the code creates a <xref:System.Data.Common.DbDataAdapter> object using the <xref:System.Data.Common.DbProviderFactory.CreateDataAdapter%2A> method and sets its `SelectCommand` property. The `Fill` method of the `DbDataAdapter` loads the data into a <xref:System.Data.DataTable>.  
  
 [!code-csharp[DataWorks DbProviderFactories.DbDataAdapter#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks DbProviderFactories.DbDataAdapter/CS/source.cs#1)]
 [!code-vb[DataWorks DbProviderFactories.DbDataAdapter#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks DbProviderFactories.DbDataAdapter/VB/source.vb#1)]  
  
## Modifying Data with a DbDataAdapter  
 This example demonstrates how to modify data in a `DataTable` using a <xref:System.Data.Common.DbDataAdapter> by using a <xref:System.Data.Common.DbCommandBuilder> to generate the commands required for updating data at the data source. The <xref:System.Data.Common.DbDataAdapter.SelectCommand%2A> of the `DbDataAdapter` is set to retrieve the CustomerID and CompanyName from the Customers table. The <xref:System.Data.Common.DbCommandBuilder.GetInsertCommand%2A> method is used to set the <xref:System.Data.Common.DbDataAdapter.InsertCommand%2A> property, the <xref:System.Data.Common.DbCommandBuilder.GetUpdateCommand%2A> method is used to set the <xref:System.Data.Common.DbDataAdapter.UpdateCommand%2A> property, and the <xref:System.Data.Common.DbCommandBuilder.GetDeleteCommand%2A> method is used to set the <xref:System.Data.Common.DbDataAdapter.DeleteCommand%2A> property. The code adds a new row to the Customers table and updates the data source. The code then locates the added row by searching on the CustomerID, which is the primary key defined for the Customers table. It changes the CompanyName and updates the data source. Finally, the code deletes the row.  
  
 [!code-csharp[DataWorks DbProviderFactories.DbDataAdapterModify#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks DbProviderFactories.DbDataAdapterModify/CS/source.cs#1)]
 [!code-vb[DataWorks DbProviderFactories.DbDataAdapterModify#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks DbProviderFactories.DbDataAdapterModify/VB/source.vb#1)]  
  
## Handling Parameters  
 The .NET Framework data providers handle naming and specifying parameters and parameter placeholders differently. This syntax is tailored to a specific data source, as described in the following table.  
  
|Data provider|Parameter naming syntax|  
|-------------------|-----------------------------|  
|`SqlClient`|Uses named parameters in the format `@`*parametername*.|  
|`OracleClient`|Uses named parameters in the format `:`*parmname* (or *parmname*).|  
|`OleDb`|Uses positional parameter markers indicated by a question mark (`?`).|  
|`Odbc`|Uses positional parameter markers indicated by a question mark (`?`).|  
  
 The factory model is not helpful for creating parameterized `DbCommand` and `DbDataAdapter` objects. You will need to branch in your code to create parameters that are tailored to your data provider.  
  
> [!IMPORTANT]
>  Avoiding provider-specific parameters altogether by using string concatenation to construct direct SQL statements is not recommended for security reasons. Using string concatenation instead of parameters leaves your application vulnerable to SQL injection attacks.  
  
## See Also  
 [DbProviderFactories](../../../../docs/framework/data/adonet/dbproviderfactories.md)  
 [Obtaining a DbProviderFactory](../../../../docs/framework/data/adonet/obtaining-a-dbproviderfactory.md)  
 [DbConnection, DbCommand and DbException](../../../../docs/framework/data/adonet/dbconnection-dbcommand-and-dbexception.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
