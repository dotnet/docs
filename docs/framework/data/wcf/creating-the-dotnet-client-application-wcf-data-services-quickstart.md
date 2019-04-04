---
title: "Creating the .NET Framework Client Application (WCF Data Services Quickstart)"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 41ade767-eeab-437d-9121-9797e8fb8045
---
# Creating the .NET Framework Client Application (WCF Data Services Quickstart)

This is the final task of the WCF Data Services quickstart. In this task, you will add a console application to the solution, add a reference to the [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)] feed into this new client application, and access the OData feed from the client application by using the generated client data service classes and client libraries.

> [!NOTE]
> A .NET Framework-based client application is not required to access a data feed. The data service can be accessed by any application component that consumes an OData feed. For more information, see [Using a Data Service in a Client Application](../../../../docs/framework/data/wcf/using-a-data-service-in-a-client-application-wcf-data-services.md).

## To create the client application by using Visual Studio

1.  In **Solution Explorer**, right-click the solution, click **Add**, and then click **New Project**.

2.  In the left pane, select **Installed** > [**Visual C#** or **Visual Basic**] > **Windows Desktop**, and then select the **WPF App** template.

3.  Enter `NorthwindClient` for the project name, and then click **OK**.

4.  Open the file MainWindow.xaml and replace the XAML code with the following code:

     [!code-xaml[Astoria Quickstart Client#Window1Xaml](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria quickstart client/vb/window1.xaml#window1xaml)]

## To add a data service reference to the project

1.  In **Solution Explorer**, right-click the NorthwindClient project, click **Add** > **Service Reference**, and then click **Discover**.

     This displays the Northwind data service that you created in the first task.

2.  In the **Namespace** text box, type `Northwind`, and then click **OK**.

     This adds a new code file to the project, which contains the data classes that are used to access and interact with data service resources as objects. The data classes are created in the namespace `NorthwindClient.Northwind`.

## To access data service data in the WPF application

1.  In **Solution Explorer** under **NorthwindClient**, right-click the project and click **Add Reference**.

2.  In the **Add Reference** dialog box, click the **.NET** tab, select the System.Data.Services.Client.dll assembly, and then click **OK**.

3. In **Solution Explorer** under **NorthwindClient**, open the code page for the MainWindow.xaml file, and add the following `using` statement (`Imports` in Visual Basic).

     [!code-csharp[Astoria Quickstart Client#Using](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria quickstart client/cs/window1.xaml.cs#using)]
     [!code-vb[Astoria Quickstart Client#Using](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria quickstart client/vb/window1.xaml.vb#using)]

3.  Insert the following code that queries that data service and binds the result to a <xref:System.Data.Services.Client.DataServiceCollection%601> into the `MainWindow` class:

    > [!NOTE]
    > You must replace the host name `localhost:12345` with the server and port that is hosting your instance of the Northwind data service.

     [!code-csharp[Astoria Quickstart Client#QueryCode](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria quickstart client/cs/window1.xaml.cs#querycode)]
     [!code-vb[Astoria Quickstart Client#QueryCode](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria quickstart client/vb/window1.xaml.vb#querycode)]

4.  Insert the following code that saves changes into the `MainWindow` class:

     [!code-csharp[Astoria Quickstart Client#SaveChanges](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria quickstart client/cs/window1.xaml.cs#savechanges)]
     [!code-vb[Astoria Quickstart Client#SaveChanges](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria quickstart client/vb/window1.xaml.vb#savechanges)]

## To build and run the NorthwindClient application

1.  In **Solution Explorer**, right-click the NorthwindClient project and select **Set as startup project**.

2.  Press **F5** to start the application.

     This builds the solution and starts the client application. Data is requested from the service and displayed in the console.

3.  Edit a value in the **Quantity** column of the data grid, and then click **Save**.

     Changes are saved to the data service.

    > [!NOTE]
    > This version of the NorthwindClient application does not support adding and deleting of entities.

## Next Steps

You have successfully created the client application that accesses the sample Northwind OData feed. You've also completed the WCF Data Services quickstart!

For more information about accessing an OData feed from a [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] application, see [WCF Data Services Client Library](../../../../docs/framework/data/wcf/wcf-data-services-client-library.md).

## See also

- [Getting Started](../../../../docs/framework/data/wcf/getting-started-with-wcf-data-services.md)
- [Resources](../../../../docs/framework/data/wcf/wcf-data-services-resources.md)
