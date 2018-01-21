---
title: "How to: Create a Data Service Using an ADO.NET Entity Framework Data Source (WCF Data Services)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-oob"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WCF Data Services, providers"
  - "WCF Data Services, Entity Framework"
ms.assetid: 6d11fec8-0108-42f5-8719-2a7866d04428
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create a Data Service Using an ADO.NET Entity Framework Data Source (WCF Data Services)
[!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] exposes entity data as a data service. This entity data is provided by the [!INCLUDE[vstecado](../../../../includes/vstecado-md.md)][!INCLUDE[adonet_ef](../../../../includes/adonet-ef-md.md)] when the data source is a relational database. This topic shows you how to create an [!INCLUDE[adonet_ef](../../../../includes/adonet-ef-md.md)]-based data model in a [!INCLUDE[vs_current_short](../../../../includes/vs-current-short-md.md)] Web application that is based on an existing database and use this data model to create a new data service.  
  
 The [!INCLUDE[adonet_ef](../../../../includes/adonet-ef-md.md)] also provides a command line tool that can generate an [!INCLUDE[adonet_ef](../../../../includes/adonet-ef-md.md)] model outside of a [!INCLUDE[vs_current_short](../../../../includes/vs-current-short-md.md)] project. For more information, see [How to: Use EdmGen.exe to Generate the Model and Mapping Files](../../../../docs/framework/data/adonet/ef/how-to-use-edmgen-exe-to-generate-the-model-and-mapping-files.md).  
  
### To add an Entity Framework model that is based on an existing database to an existing Web application  
  
1.  On the **Project** menu, click **Add new item**.  
  
2.  In the **Templates** pane, click the **Data** category, and then select **ADO.NET Entity Data Model**.  
  
3.  Type the model name and then click **Add**.  
  
     The first page of the [!INCLUDE[adonet_edm](../../../../includes/adonet-edm-md.md)] Wizard is displayed.  
  
4.  In the **Choose Model Contents** dialog box, select **Generate from database**. Then click **Next**.  
  
5.  Click the **New Connection** button.  
  
6.  In the **Connection Properties** dialog box, type your server name, select the authentication method, type the database name, and then click **OK**.  
  
     The **Choose Your Data Connection**s dialog box is updated with your database connection settings.  
  
7.  Ensure that the **Save entity connection settings in App.Config as:** checkbox is checked. Then click **Next**.  
  
8.  In the **Choose Your Database Objects** dialog box, select all of database objects that you plan to expose in the data service.  
  
    > [!NOTE]
    >  Objects included in the data model are not automatically exposed by the data service. They must be explicitly exposed by the service itself. For more information, see [Configuring the Data Service](../../../../docs/framework/data/wcf/configuring-the-data-service-wcf-data-services.md).  
  
9. Click **Finish** to complete the wizard.  
  
     This creates a default data model based on the specific database. The [!INCLUDE[adonet_ef](../../../../includes/adonet-ef-md.md)] enables to customize the data model. For more information, see [Tasks](http://msdn.microsoft.com/library/7166f1f1-4de8-4bd4-86b5-5e20a2ebaccb).  
  
### To create the data service by using the new data model  
  
1.  In [!INCLUDE[vs_current_short](../../../../includes/vs-current-short-md.md)], open the .edmx file that represents the data model.  
  
2.  In the **Model Browser**, right-click the model, click **Properties**, and then note the name of the entity container.  
  
3.  In **Solution Explorer**, right-click the name of your [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] project, and then click **Add New Item**.  
  
4.  In the **Add New Item** dialog box, select **WCF Data Service**.  
  
5.  Supply a name for the service, and then click **OK**.  
  
     [!INCLUDE[vs_current_short](../../../../includes/vs-current-short-md.md)] creates the XML markup and code files for the new service. By default, the code-editor window opens.  
  
6.  In the code for the data service, replace the comment `/* TODO: put your data source class name here */` in the definition of the class that defines the data service with the type that inherits from the <xref:System.Data.Objects.ObjectContext> class and that is the entity container of the data model, which was noted in step 2.  
  
7.  In the code for the data service, enable authorized clients to access the entity sets that the data service exposes. For more information, see [Creating the Data Service](../../../../docs/framework/data/wcf/creating-the-data-service.md).  
  
8.  To test the Northwind.svc data service by using a Web browser, follow the instructions in the topic [Accessing the Service from a Web Browser](../../../../docs/framework/data/wcf/accessing-the-service-from-a-web-browser-wcf-data-services-quickstart.md).  
  
## See Also  
 [Defining WCF Data Services](../../../../docs/framework/data/wcf/defining-wcf-data-services.md)  
 [Data Services Providers](../../../../docs/framework/data/wcf/data-services-providers-wcf-data-services.md)  
 [How to: Create a Data Service Using the Reflection Provider](../../../../docs/framework/data/wcf/create-a-data-service-using-rp-wcf-data-services.md)  
 [How to: Create a Data Service Using a LINQ to SQL Data Source](../../../../docs/framework/data/wcf/create-a-data-service-using-linq-to-sql-wcf.md)
