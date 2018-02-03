---
title: "Working with Data Definition Language"
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
ms.assetid: ec50083d-44f4-4093-9b23-5eacd601f96e
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Working with Data Definition Language
Starting with the [!INCLUDE[dnprdnshort](../../../../../includes/dnprdnshort-md.md)] version 4, the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] supports data definition language (DDL). This allows you to create or delete a database instance based on the connection string and the metadata of the storage (SSDL) model.  
  
 The following methods on the <xref:System.Data.Objects.ObjectContext> use the connection string and the SSDL content to accomplish the following: create or delete the database, check whether the database exists, and view the generated DDL script:  
  
-   <xref:System.Data.Objects.ObjectContext.CreateDatabase%2A>  
  
-   <xref:System.Data.Objects.ObjectContext.DeleteDatabase%2A>  
  
-   <xref:System.Data.Objects.ObjectContext.DatabaseExists%2A>  
  
-   <xref:System.Data.Objects.ObjectContext.CreateDatabaseScript%2A>  
  
> [!NOTE]
>  Executing the DDL commands assumes sufficient permissions.  
  
 The methods previously listed delegate most of the work to the underlying ADO.NET data provider. It is the provider’s responsibility to ensure that the naming convention used to generate database objects is consistent with conventions used for querying and updates.  
  
 The following example shows you how to generate the database based on the existing model. It also adds a new entity object to the object context and then saves it to the database.  
  
## Procedures  
  
#### To define a database based on the existing model  
  
1.  Create a console application.  
  
2.  Add an existing model to your application.  
  
    1.  Add an empty model named `SchoolModel`. To create an empty model, see the [How to: Create a New .edmx File](http://msdn.microsoft.com/library/beb8189e-e51c-4051-839c-9902c224abf2) topic.  
  
     The SchoolModel.edmx file is added to your project.  
  
    1.  Copy the conceptual, storage, and mapping content for the School model from the [School Model](http://msdn.microsoft.com/library/859a9587-81ea-4a45-9bc0-f8d330e1adac) topic.  
  
    2.  Open the SchoolModel.edmx file and paste the content within the `edmx:Runtime` tags.  
  
3.  Add the following code to your main function. The code initializes the connection string to your database server, views the DDL script, creates the database, adds a new entity to the context, and saves the changes to the database.  
  
     [!code-csharp[DP ObjectServices Concepts#DDL](../../../../../samples/snippets/csharp/VS_Snippets_Data/DP ObjectServices Concepts/CS/Source.cs#ddl)]
     [!code-vb[DP ObjectServices Concepts#DDL](../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DP ObjectServices Concepts/VB/Source.vb#ddl)]
