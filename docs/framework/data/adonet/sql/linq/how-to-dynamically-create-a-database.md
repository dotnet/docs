---
title: "How to: Dynamically Create a Database"
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
ms.assetid: fb7f23c4-4572-4c38-9898-a287807d070c
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# How to: Dynamically Create a Database
In LINQ to SQL, an object model is mapped to a relational database. Mapping is enabled by using attribute-based mapping or an external mapping file to describe the structure of the relational database. In both scenarios, there is enough information about the relational database that you can create a new instance of the database using the <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType> method.  
  
 The <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType> method creates a replica of the database only to the extent of the information encoded in the object model. Mapping files and attributes from your object model might not encode everything about the structure of an existing database. Mapping information does not represent the contents of user-defined functions, stored procedures, triggers, or check constraints. This behavior is sufficient for a variety of databases.  
  
 You can use the <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType> method in any number of scenarios, especially if a known data provider like Microsoft SQL Server 2008 is available. Typical scenarios include the following:  
  
-   You are building an application that automatically installs itself on a customer system.  
  
-   You are building a client application that needs a local database to save its offline state.  
  
 You can also use the <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType> method with SQL Server by using an .mdf file or a catalog name, depending on your connection string. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] uses the connection string to define the database to be created and on which server the database is to be created.  
  
> [!NOTE]
>  Whenever possible, use Windows Integrated Security to connect to the database so that passwords are not required in the connection string.  
  
## Example  
 The following code provides an example of how to create a new database named MyDVDs.mdf.  
  
 [!code-csharp[DLinqSubmittingChanges#5](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqSubmittingChanges/cs/Program.cs#5)]
 [!code-vb[DLinqSubmittingChanges#5](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqSubmittingChanges/vb/Module1.vb#5)]  
  
## Example  
 You can use the object model to create a database by doing the following:  
  
 [!code-csharp[DLinqSubmittingChanges#6](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqSubmittingChanges/cs/Program.cs#6)]
 [!code-vb[DLinqSubmittingChanges#6](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqSubmittingChanges/vb/Module1.vb#6)]  
  
## Example  
 When building an application that automatically installs itself on a  customer system, see if the database already exists and drop it before creating a new one. The <xref:System.Data.Linq.DataContext> class provides the <xref:System.Data.Linq.DataContext.DatabaseExists%2A> and <xref:System.Data.Linq.DataContext.DeleteDatabase%2A> methods to help you with this process.  
  
 The following example shows one way these methods can be used to implement this approach:  
  
 [!code-csharp[DLinqSubmittingChanges#7](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqSubmittingChanges/cs/Program.cs#7)]
 [!code-vb[DLinqSubmittingChanges#7](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqSubmittingChanges/vb/Module1.vb#7)]  
  
## See Also  
 [Attribute-Based Mapping](../../../../../../docs/framework/data/adonet/sql/linq/attribute-based-mapping.md)  
 [External Mapping](../../../../../../docs/framework/data/adonet/sql/linq/external-mapping.md)  
 [SQL-CLR Type Mapping](../../../../../../docs/framework/data/adonet/sql/linq/sql-clr-type-mapping.md)  
 [Background Information](../../../../../../docs/framework/data/adonet/sql/linq/background-information.md)  
 [Making and Submitting Data Changes](../../../../../../docs/framework/data/adonet/sql/linq/making-and-submitting-data-changes.md)
