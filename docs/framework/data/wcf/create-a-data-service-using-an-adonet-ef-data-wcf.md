---
title: "How to: Create a Data Service Using an ADO.NET Entity Framework Data Source (WCF Data Services)"
ms.date: 08/24/2018
helpviewer_keywords:
  - "WCF Data Services, providers"
  - "WCF Data Services, Entity Framework"
ms.assetid: 6d11fec8-0108-42f5-8719-2a7866d04428
---
# How to: Create a Data Service Using an ADO.NET Entity Framework Data Source (WCF Data Services)

WCF Data Services exposes entity data as a data service. This entity data is provided by the ADO.NETEntity Framework when the data source is a relational database. This topic shows you how to create an Entity Framework-based data model in a Visual Studio Web application that is based on an existing database and use this data model to create a new data service.

The Entity Framework also provides a command line tool that can generate an Entity Framework model outside of a Visual Studio project. For more information, see [How to: Use EdmGen.exe to Generate the Model and Mapping Files](../adonet/ef/how-to-use-edmgen-exe-to-generate-the-model-and-mapping-files.md).

## To add an Entity Framework model that is based on an existing database to an existing Web application

1. On the **Project** menu, click **Add** > **New Item**.

2. In the **Templates** pane, click the **Data** category, and then select **ADO.NET Entity Data Model**.

3. Enter the model name and then click **Add**.

     The first page of the Entity Data Model Wizard is displayed.

4. In the **Choose Model Contents** dialog box, select **Generate from database**. Then click **Next**.

5. Click the **New Connection** button.

6. In the **Connection Properties** dialog box, type your server name, select the authentication method, type the database name, and then click **OK**.

     The **Choose Your Data Connection** dialog box is updated with your database connection settings.

7. Ensure that the **Save entity connection settings in App.Config as:** checkbox is checked. Then click **Next**.

8. In the **Choose Your Database Objects** dialog box, select all of database objects that you plan to expose in the data service.

    > [!NOTE]
    > Objects included in the data model are not automatically exposed by the data service. They must be explicitly exposed by the service itself. For more information, see [Configuring the Data Service](configuring-the-data-service-wcf-data-services.md).

9. Click **Finish** to complete the wizard.

     This creates a default data model based on the specific database. The Entity Framework enables to customize the data model. For more information, see [Entity Data Model Tools Tasks](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb738480(v=vs.100)).

## To create the data service by using the new data model

1. In Visual Studio, open the .edmx file that represents the data model.

2. In the **Model Browser**, right-click the model, click **Properties**, and then note the name of the entity container.

3. In **Solution Explorer**, right-click the name of your ASP.NET project, and then click **Add** > **New Item**.

4. In the **Add New Item** dialog box, select the **WCF Data Service** template in the **Web** category.

   ![WCF Data Service item template in Visual Studio 2015](./media/wcf-data-service-item-template.png)

   > [!NOTE]
   > The **WCF Data Service** template is available in Visual Studio 2015, but not in Visual Studio 2017.

5. Supply a name for the service, and then click **OK**.

     Visual Studio creates the XML markup and code files for the new service. By default, the code-editor window opens.

6. In the code for the data service, replace the comment `/* TODO: put your data source class name here */` in the definition of the class that defines the data service with the type that inherits from the <xref:System.Data.Objects.ObjectContext> class and that is the entity container of the data model, which was noted in step 2.

7. In the code for the data service, enable authorized clients to access the entity sets that the data service exposes. For more information, see [Creating the Data Service](creating-the-data-service.md).

8. To test the Northwind.svc data service by using a Web browser, follow the instructions in the topic [Accessing the Service from a Web Browser](accessing-the-service-from-a-web-browser-wcf-data-services-quickstart.md).

## See also

- [Defining WCF Data Services](defining-wcf-data-services.md)
- [Data Services Providers](data-services-providers-wcf-data-services.md)
- [How to: Create a Data Service Using the Reflection Provider](create-a-data-service-using-rp-wcf-data-services.md)
- [How to: Create a Data Service Using a LINQ to SQL Data Source](create-a-data-service-using-linq-to-sql-wcf.md)
