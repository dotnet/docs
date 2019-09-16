---
title: "Migration Considerations (Entity Framework)"
ms.date: "03/30/2017"
ms.assetid: c85b6fe8-cc32-4642-8f0a-dc0e5a695936
---
# Migration Considerations (Entity Framework)
The ADO.NET Entity Framework provides several benefits to an existing application. One of the most important of these benefits is the ability to use a conceptual model to separate data structures used by the application from the schema in the data source. This enables you to easily make future changes to the storage model or to the data source itself without making compensating changes to the application. For more information about the benefits of using the Entity Framework, see [Entity Framework Overview](overview.md) and [Entity Data Model](../entity-data-model.md).  
  
 To take advantage of the benefits of the Entity Framework, you can migrate an existing application to the Entity Framework. Some tasks are common to all migrated applications. These common tasks include upgrading the application to use the .NET Framework starting with version 3.5 Service Pack 1 (SP1), defining models and mapping, and configuring the Entity Framework. When you migrate an application to the Entity Framework, there are additional considerations that apply. These considerations depend on the type of application being migrated and on the specific functionality of the application. This topic provides information to help you choose the best approach to use when you upgrade an existing application.  
  
## General Migration Considerations  
 The following considerations apply when you migrate any application to the Entity Framework:  
  
- Any application that uses the .NET Framework starting with version 3.5 SP1 can be migrated to the Entity Framework, as long as the data provider for the data source that is used by the application supports the Entity Framework.  
  
- The Entity Framework may not support all the functionality of a data source provider, even if that provider supports the Entity Framework.  
  
- For a large or complex application, you are not required to migrate the whole application to the Entity Framework at one time. However, any part of the application that does not use the Entity Framework must still be changed when the data source changes.  
  
- The data provider connection used by the Entity Framework can be shared with other parts of your application because the Entity Framework uses ADO.NET data providers to access the data source. For example, the SqlClient provider is used by the Entity Framework to access a SQL Server database. For more information, see [EntityClient Provider for the Entity Framework](entityclient-provider-for-the-entity-framework.md).  
  
## Common Migration Tasks  
 The path to migrate an existing application to the Entity Framework depends both on the type of application and on the existing data access strategy. However, you must always perform the following tasks when you migrate an existing application to the Entity Framework.  
  
> [!NOTE]
> All of these tasks are performed automatically when you use the Entity Data Model tools starting with Visual Studio 2008. For more information, see [How to: Use the Entity Data Model Wizard](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb738677(v=vs.100)).  
  
1. Upgrade the application.  
  
     A project created by using an earlier version of Visual Studio and the .NET Framework must be upgraded to use Visual Studio 2008 SP1 and the .NET Framework starting with version 3.5 SP1.  
  
2. Define the models and mapping.  
  
     The model and mapping files define entities in the conceptual model; structures in the data source, such as tables, stored procedures, and views; and the mapping between the entities and data source structures. For more information, see [How to: Manually Define the Model and Mapping Files](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb399785(v=vs.100)).  
  
     Types that are defined in the storage model must match the name of objects in the data source. If the existing application exposes data as objects, you must ensure that the entities and properties that are defined in the conceptual model match the names of these existing data classes and properties. For more information, see [How to: Customize Modeling and Mapping Files to Work with Custom Objects](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb738625(v=vs.100)).  
  
    > [!NOTE]
    > The Entity Data Model Designer can be used to rename entities in the conceptual model to match existing objects. For more information, see [Entity Data Model Designer](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/cc716685(v=vs.100)).  
  
3. Define the connection string.  
  
     The Entity Framework uses a specially formatted connection string when executing queries against a conceptual model. This connection string encapsulates information about the model and mapping files and the connection to the data source. For more information, see [How to: Define the Connection String](how-to-define-the-connection-string.md).  
  
4. Configure the Visual Studio project.  
  
     References to Entity Framework assemblies and the model and mapping files must be added to the Visual Studio project. You can add these mapping files to the project to ensure that they are deployed with the application in the location that is indicated in the connection string. For more information, see [How to: Manually Configure an Entity Framework Project](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb738546(v=vs.100)).  
  
## Considerations for Applications with Existing Objects  
 Starting with the .NET Framework 4, the Entity Framework supports "plain old" CLR objects (POCO), also called persistence-ignorant objects. In most cases, your existing objects can work with the Entity Framework by making minor changes. For more information, see [Working with POCO Entities](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/dd456853(v=vs.100)). You can also migrate an application to the Entity Framework and use the data classes that are generated by the Entity Framework tools. For more information, see [How to: Use the Entity Data Model Wizard](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb738677(v=vs.100)).  
  
## Considerations for Applications that Use ADO.NET Providers  
 ADO.NET providers, such as SqlClient, enable you to query a data source to return tabular data. Data can also be loaded into an ADO.NET DataSet. The following list describes considerations for upgrading an application that uses an existing ADO.NET provider:  
  
- Displaying tabular data by using a data reader.  

  You may consider executing an [!INCLUDE[esql](../../../../../includes/esql-md.md)] query using the EntityClient provider and enumerating through the returned <xref:System.Data.EntityClient.EntityDataReader> object. Do this only if your application displays tabular data using a data reader and does not require the facilities provided by the Entity Framework for materializing data into objects, tracking changes, and making updates. You can continue to use existing data access code that makes updates to the data source, but you can use the existing connection accessed from the <xref:System.Data.EntityClient.EntityConnection.StoreConnection%2A> property of <xref:System.Data.EntityClient.EntityConnection>. For more information, see [EntityClient Provider for the Entity Framework](entityclient-provider-for-the-entity-framework.md).  
  
- Working with DataSets.  

  The Entity Framework provides many of the same functionalities provided by DataSet, including in-memory persistence, change tracking, data binding, and serializing objects as XML data. For more information, see [Working with Objects](working-with-objects.md).  
  
  If the Entity Framework does not provide the functionality of DataSet needed by your application, you can still take advantage of the benefits of LINQ queries by using LINQ to DataSet. For more information, see [LINQ to DataSet](../linq-to-dataset.md).  
  
## Considerations for Applications that Bind Data to Controls  
 The .NET Framework lets you encapsulate data in a data source, such as a DataSet or an ASP.NET data source control, and then bind user interface elements to those data controls. The following list describes considerations for binding controls to Entity Framework data.  
  
- Binding data to controls.  

  When you query the conceptual model, the Entity Framework returns the data as objects that are instances of entity types. These objects can be bound directly to controls, and this binding supports updates. This means that changes to data in a control, such as a row in a <xref:System.Windows.Forms.DataGridView>, automatically get saved to the database when the <xref:System.Data.Objects.ObjectContext.SaveChanges%2A> method is called.  
  
  If your application enumerates the results of a query to display data in a <xref:System.Windows.Forms.DataGridView> or other type of control that supports data binding, you can modify your application to bind the control to the result of an <xref:System.Data.Objects.ObjectQuery%601>.  
  
  For more information, see [Binding Objects to Controls](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb738469(v=vs.100)).  
  
- ASP.NET data source controls.  

  The Entity Framework includes a data source control designed to simplify data binding in ASP.NET Web applications. For more information, see [EntityDataSource Web Server Control Overview](https://docs.microsoft.com/previous-versions/aspnet/cc488502(v=vs.100)).  
  
## Other Considerations  
 The following are considerations that may apply when you migrate specific types of applications to the Entity Framework.  
  
- Applications that expose data services.  

  Web services and applications that are based on the Windows Communication Foundation (WCF) expose data from an underlying data source by using an XML request/response messaging format. The Entity Framework supports the serialization of entity objects by using binary, XML, or WCF data contract serialization. Binary and WCF serialization both support full serialization of object graphs. For more information, see [Building N-Tier Applications](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb896304(v=vs.100)).  
  
- Applications that use XML data.  

  Object serialization enables you to create Entity Framework data services. These services provide data to applications that consume XML data, such as AJAX-based Internet applications. In these cases, consider using [!INCLUDE[ssAstoria](../../../../../includes/ssastoria-md.md)]. These data services are based on the Entity Data Model and provide dynamic access to entity data by using standard Representational State Transfer (REST) HTTP actions, such as GET, PUT, and POST. For more information, see [WCF Data Services 4.5](../../wcf/index.md).  
  
  The Entity Framework does not support a native-XML data type. This means that when an entity is mapped to a table with an XML column, the equivalent entity property for the XML column is a string. Objects can be disconnected and serialized as XML. For more information, see [Serializing Objects](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb738446(v=vs.100)).  
  
  If your application requires the ability to query XML data, you can still take advantage of the benefits of LINQ queries by using LINQ to XML. For more information, see [LINQ to XML (C#)](../../../../csharp/programming-guide/concepts/linq/linq-to-xml-overview.md) or [LINQ to XML (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/linq-to-xml.md).  
  
- Applications that maintain state.  

  ASP.NET Web applications must frequently maintain the state of a Web page or of a user session. Objects in an <xref:System.Data.Objects.ObjectContext> instance can be stored in the client view state or in the session state on the server, and later retrieved and reattached to a new object context. For more information, see [Attaching and Detaching Objects](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb896271(v=vs.100)).  
  
## See also

- [Deployment Considerations](deployment-considerations.md)
- [Entity Framework Terminology](terminology.md)
