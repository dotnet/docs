---
title: "Working with Data Definition Language"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: ec50083d-44f4-4093-9b23-5eacd601f96e
---
# Working with Data Definition Language
Starting with the .NET Framework version 4, the Entity Framework supports data definition language (DDL). This allows you to create or delete a database instance based on the connection string and the metadata of the storage (SSDL) model.  
  
 The following methods on the <xref:System.Data.Objects.ObjectContext> use the connection string and the SSDL content to accomplish the following: create or delete the database, check whether the database exists, and view the generated DDL script:  
  
- <xref:System.Data.Objects.ObjectContext.CreateDatabase%2A>  
  
- <xref:System.Data.Objects.ObjectContext.DeleteDatabase%2A>  
  
- <xref:System.Data.Objects.ObjectContext.DatabaseExists%2A>  
  
- <xref:System.Data.Objects.ObjectContext.CreateDatabaseScript%2A>  
  
> [!NOTE]
> Executing the DDL commands assumes sufficient permissions.  
  
 The methods previously listed delegate most of the work to the underlying ADO.NET data provider. It is the provider’s responsibility to ensure that the naming convention used to generate database objects is consistent with conventions used for querying and updates.  
  
 The following example shows you how to generate the database based on the existing model. It also adds a new entity object to the object context and then saves it to the database.  
  
## Procedures  
  
### To define a database based on the existing model  
  
1. Create a console application.  
  
2. Add an existing model to your application.  
  
    1. Add an empty model named `SchoolModel`. To create an empty model, see the [How to: Create a New .edmx File](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/cc716703(v=vs.100)) topic.  
  
     The SchoolModel.edmx file is added to your project.  
  
    1. Copy the conceptual, storage, and mapping content for the School model from the [School Model](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb896300(v=vs.100)) topic.  
  
    2. Open the SchoolModel.edmx file and paste the content within the `edmx:Runtime` tags.  
  
3. Add the following code to your main function. The code initializes the connection string to your database server, views the DDL script, creates the database, adds a new entity to the context, and saves the changes to the database.  
  
     [!code-csharp[DP ObjectServices Concepts#DDL](../../../../../samples/snippets/csharp/VS_Snippets_Data/DP ObjectServices Concepts/CS/Source.cs#ddl)]
     [!code-vb[DP ObjectServices Concepts#DDL](../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DP ObjectServices Concepts/VB/Source.vb#ddl)]
