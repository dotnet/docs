---
title: "Migration Considerations (Entity Framework)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c85b6fe8-cc32-4642-8f0a-dc0e5a695936
caps.latest.revision: 6
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Migration Considerations (Entity Framework)
The [!INCLUDE[vstecado](../../../../../includes/vstecado-md.md)] Entity Framework provides several benefits to an existing application. One of the most important of these benefits is the ability to use a conceptual model to separate data structures used by the application from the schema in the data source. This enables you to easily make future changes to the storage model or to the data source itself without making compensating changes to the application. For more information about the benefits of using the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)], see [Entity Framework Overview](../../../../../docs/framework/data/adonet/ef/overview.md) and [Entity Data Model](../../../../../docs/framework/data/adonet/entity-data-model.md).  
  
 To take advantage of the benefits of the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)], you can migrate an existing application to the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)]. Some tasks are common to all migrated applications. These common tasks include upgrading the application to use the [!INCLUDE[dnprdnshort](../../../../../includes/dnprdnshort-md.md)] starting with version 3.5 Service Pack 1 (SP1), defining models and mapping, and configuring the Entity Framework. When you migrate an application to the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)], there are additional considerations that apply. These considerations depend on the type of application being migrated and on the specific functionality of the application. This topic provides information to help you choose the best approach to use when you upgrade an existing application.  
  
## General Migration Considerations  
 The following considerations apply when you migrate any application to the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)]:  
  
-   Any application that uses the [!INCLUDE[dnprdnshort](../../../../../includes/dnprdnshort-md.md)] starting with version 3.5 SP1 can be migrated to the Entity Framework, as long as the data provider for the data source that is used by the application supports the Entity Framework.  
  
-   The Entity Framework may not support all the functionality of a data source provider, even if that provider supports the Entity Framework.  
  
-   For a large or complex application, you are not required to migrate the whole application to the Entity Framework at one time. However, any part of the application that does not use the Entity Framework must still be changed when the data source changes.  
  
-   The data provider connection used by the Entity Framework can be shared with other parts of your application because the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] uses [!INCLUDE[vstecado](../../../../../includes/vstecado-md.md)] data providers to access the data source. For example, the SqlClient provider is used by the Entity Framework to access a SQL Server database. For more information, see [EntityClient Provider for the Entity Framework](../../../../../docs/framework/data/adonet/ef/entityclient-provider-for-the-entity-framework.md).  
  
## Common Migration Tasks  
 The path to migrate an existing application to the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] depends both on the type of application and on the existing data access strategy. However, you must always perform the following tasks when you migrate an existing application to the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)].  
  
> [!NOTE]
>  All of these tasks are performed automatically when you use the Entity Data Model tools starting with [!INCLUDE[vsOrcas](../../../../../includes/vsorcas-md.md)]. For more information, see [How to: Use the Entity Data Model Wizard](http://msdn.microsoft.com/library/dadb058a-c5d9-4c5c-8b01-28044112231d).  
  
1.  Upgrade the application.  
  
     A project created by using an earlier version of [!INCLUDE[vsprvs](../../../../../includes/vsprvs-md.md)] and the [!INCLUDE[dnprdnshort](../../../../../includes/dnprdnshort-md.md)] must be upgraded to use [!INCLUDE[vsOrcas](../../../../../includes/vsorcas-md.md)] SP1 and the [!INCLUDE[dnprdnshort](../../../../../includes/dnprdnshort-md.md)] starting with version 3.5 SP1.  
  
2.  Define the models and mapping.  
  
     The model and mapping files define entities in the conceptual model; structures in the data source, such as tables, stored procedures, and views; and the mapping between the entities and data source structures. For more information, see [How to: Manually Define the Model and Mapping Files](http://msdn.microsoft.com/library/d4fd6864-f2a1-48f0-aa32-1e318775a99a).  
  
     Types that are defined in the storage model must match the name of objects in the data source. If the existing application exposes data as objects, you must ensure that the entities and properties that are defined in the conceptual model match the names of these existing data classes and properties. For more information, see [How to: Customize Modeling and Mapping Files to Work with Custom Objects](http://msdn.microsoft.com/library/bb40c4db-0121-4e45-a167-8fb06707a708).  
  
    > [!NOTE]
    >  The Entity Data Model Designer can be used to rename entities in the conceptual model to match existing objects. For more information, see [Entity Data Model Designer](http://msdn.microsoft.com/library/4ccd7ad6-b934-4f7c-82a0-cfd2d4a95faf).  
  
3.  Define the connection string.  
  
     The [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] uses a specially formatted connection string when executing queries against a conceptual model. This connection string encapsulates information about the model and mapping files and the connection to the data source. For more information, see [How to: Define the Connection String](../../../../../docs/framework/data/adonet/ef/how-to-define-the-connection-string.md).  
  
4.  Configure the [!INCLUDE[vsprvs](../../../../../includes/vsprvs-md.md)] project.  
  
     References to [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] assemblies and the model and mapping files must be added to the [!INCLUDE[vsprvs](../../../../../includes/vsprvs-md.md)] project. You can add these mapping files to the project to ensure that they are deployed with the application in the location that is indicated in the connection string. For more information, see [How to: Manually Configure an Entity Framework Project](http://msdn.microsoft.com/library/73f6ae1d-b3b2-4577-aebd-ad5a75954e9e).  
  
## Considerations for Applications with Existing Objects  
 Starting with the [!INCLUDE[dnprdnshort](../../../../../includes/dnprdnshort-md.md)] 4, the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] supports "plain old" CLR objects (POCO), also called persistence-ignorant objects. In most cases, your existing objects can work with the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] by making minor changes. For more information, see [Working with POCO Entities](http://msdn.microsoft.com/library/5e0fb82a-b6d1-41a1-b37b-c12db61629d3). You can also migrate an application to the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] and use the data classes that are generated by the Entity Framework tools. For more information, see [How to: Use the Entity Data Model Wizard](http://msdn.microsoft.com/library/dadb058a-c5d9-4c5c-8b01-28044112231d).  
  
## Considerations for Applications that Use ADO.NET Providers  
 [!INCLUDE[vstecado](../../../../../includes/vstecado-md.md)] providers, such as SqlClient, enable you to query a data source to return tabular data. Data can also be loaded into an [!INCLUDE[vstecado](../../../../../includes/vstecado-md.md)] DataSet. The following list describes considerations for upgrading an application that uses an existing [!INCLUDE[vstecado](../../../../../includes/vstecado-md.md)] provider:  
  
 Displaying tabular data by using a data reader.  
 You may consider executing an [!INCLUDE[esql](../../../../../includes/esql-md.md)] query using the EntityClient provider and enumerating through the returned <xref:System.Data.EntityClient.EntityDataReader> object. Do this only if your application displays tabular data using a data reader and does not require the facilities provided by the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] for materializing data into objects, tracking changes, and making updates. You can continue to use existing data access code that makes updates to the data source, but you can use the existing connection accessed from the <xref:System.Data.EntityClient.EntityConnection.StoreConnection%2A> property of <xref:System.Data.EntityClient.EntityConnection>. For more information, see [EntityClient Provider for the Entity Framework](../../../../../docs/framework/data/adonet/ef/entityclient-provider-for-the-entity-framework.md).  
  
 Working with DataSets.  
 The [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] provides many of the same functionalities provided by DataSet, including in-memory persistence, change tracking, data binding, and serializing objects as XML data. For more information, see [Working with Objects](../../../../../docs/framework/data/adonet/ef/working-with-objects.md).  
  
 If the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] does not provide the functionality of DataSet needed by your application, you can still take advantage of the benefits of LINQ queries by using [!INCLUDE[linq_dataset](../../../../../includes/linq-dataset-md.md)]. For more information, see [LINQ to DataSet](../../../../../docs/framework/data/adonet/linq-to-dataset.md).  
  
## Considerations for Applications that Bind Data to Controls  
 The [!INCLUDE[dnprdnshort](../../../../../includes/dnprdnshort-md.md)] lets you encapsulate data in a data source, such as a DataSet or an [!INCLUDE[vstecasp](../../../../../includes/vstecasp-md.md)] data source control, and then bind user interface elements to those data controls. The following list describes considerations for binding controls to Entity Framework data.  
  
 Binding data to controls.  
 When you query the conceptual model, the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] returns the data as objects that are instances of entity types. These objects can be bound directly to controls, and this binding supports updates. This means that changes to data in a control, such as a row in a <xref:System.Windows.Forms.DataGridView>, automatically get saved to the database when the <xref:System.Data.Objects.ObjectContext.SaveChanges%2A> method is called.  
  
 If your application enumerates the results of a query to display data in a <xref:System.Windows.Forms.DataGridView> or other type of control that supports data binding, you can modify your application to bind the control to the result of an <xref:System.Data.Objects.ObjectQuery%601>.  
  
 For more information, see [Binding Objects to Controls](http://msdn.microsoft.com/library/2fd34855-929b-4303-a91e-4bb69d958f2b).  
  
 [!INCLUDE[vstecasp](../../../../../includes/vstecasp-md.md)] data source controls.  
 The [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] includes a data source control designed to simplify data binding in [!INCLUDE[vstecasp](../../../../../includes/vstecasp-md.md)] Web applications. For more information, see [Entity Framework Data Source Control](http://msdn.microsoft.com/library/1f09af00-9578-4744-a029-765710a3c83f).  
  
## Other Considerations  
 The following are considerations that may apply when you migrate specific types of applications to the Entity Framework.  
  
 Applications that expose data services.  
 Web services and applications that are based on the Windows Communication Foundation (WCF) expose data from an underlying data source by using an XML request/response messaging format. The [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] supports the serialization of entity objects by using binary, XML, or WCF data contract serialization. Binary and WCF serialization both support full serialization of object graphs. For more information, see [Building N-Tier Applications](http://msdn.microsoft.com/library/9439d2ba-6b5f-44e8-be65-8a442d922cbb).  
  
 Applications that use XML data.  
 Object serialization enables you to create [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] data services. These services provide data to applications that consume XML data, such as AJAX-based Internet applications. In these cases, consider using [!INCLUDE[ssAstoria](../../../../../includes/ssastoria-md.md)]. These data services are based on the Entity Data Model and provide dynamic access to entity data by using standard Representational State Transfer (REST) HTTP actions, such as GET, PUT, and POST. For more information, see [WCF Data Services 4.5](../../../../../docs/framework/data/wcf/index.md).  
  
 The [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] does not support a native-XML data type. This means that when an entity is mapped to a table with an XML column, the equivalent entity property for the XML column is a string. Objects can be disconnected and serialized as XML. For more information, see [Serializing Objects](http://msdn.microsoft.com/library/06c77f9b-5b2e-4c78-b3e3-8c148ba0ea99).  
  
 If your application requires the ability to query XML data, you can still take advantage of the benefits of LINQ queries by using LINQ to XML. For more information, see [LINQ to XML](http://msdn.microsoft.com/library/f0fe21e9-ee43-4a55-b91a-0800e5782c13).  
  
 Applications that maintain state.  
 [!INCLUDE[vstecasp](../../../../../includes/vstecasp-md.md)] Web applications must frequently maintain the state of a Web page or of a user session. Objects in an <xref:System.Data.Objects.ObjectContext> instance can be stored in the client view state or in the session state on the server, and later retrieved and reattached to a new object context. For more information, see [Attaching and Detaching Objects](http://msdn.microsoft.com/library/41d5c1ef-1b78-4502-aa10-7e1438d62d23).  
  
## See Also  
 [Deployment Considerations](../../../../../docs/framework/data/adonet/ef/deployment-considerations.md)  
 [Entity Framework Terminology](../../../../../docs/framework/data/adonet/ef/terminology.md)
