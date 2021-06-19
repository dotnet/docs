---
title: "Accessing the Service from a Web Browser (WCF Data Services Quickstart)"
description: Learn to start WCF Data Services in Visual Studio and disable feed reading in a browser. Get the service definition document and access data service resources.
ms.date: "03/30/2017"
ms.assetid: 5a6fa180-3094-4e6e-ba2b-8c80975d18d1
recommendations: false
---
# Accessing the Service from a Web Browser (WCF Data Services Quickstart)

[!INCLUDE [wcf-deprecated](~/includes/wcf-deprecated.md)]

This is the second task of the WCF Data Services quickstart. In this task, you start the WCF Data Services from Visual Studio and optionally disable feed reading in the Web browser. You then retrieve the service definition document as well as access data service resources by submitting HTTP GET requests through a Web browser to the exposed resources.

> [!NOTE]
> By default, Visual Studio auto-assigns a port number to the `localhost` URI on your computer. This task uses the port number `12345` in the URI examples. For more information about how to set a specific port number in your Visual Studio project see [Creating the Data Service](creating-the-data-service.md).

## To request the default service document by using Internet Explorer

1. In Internet Explorer, from the **Tools** menu, select **Internet Options**, click the **Content** tab, click **Settings**, and clear **Turn on feed viewing**.

     This makes sure that feed reading is disabled. If you do not disable this functionality, then the Web browser will treat the returned AtomPub encoded document as an XML feed instead of displaying the raw XML data.

    > [!NOTE]
    > If your browser cannot display the feed as raw XML data, you should still be able to view the feed as the source code for the page.

2. In Visual Studio, press the **F5** key to start debugging the application.

3. Open a Web browser on the local computer. In the address bar, enter the following URI:

    ```http
    http://localhost:12345/northwind.svc
    ```

     This returns the default service document, which contains a list of entity sets that are exposed by this data service.

## To access entity set resources from a Web browser

1. In the address bar of your Web browser, enter the following URI:

    ```http
    http://localhost:12345/northwind.svc/Customers
    ```

     This returns a set of all customers in the Northwind sample database.

2. In the address bar of your Web browser, enter the following URI:

    ```http
    http://localhost:12345/northwind.svc/Customers('ALFKI')
    ```

     This returns an entity instance for the specific customer, `ALFKI`.

3. In the address bar of your Web browser, enter the following URI:

    ```http
    http://localhost:12345/northwind.svc/Customers('ALFKI')/Orders
    ```

     This traverses the relationship between customers and orders to return a set of all orders for the specific customer `ALFKI`.

4. In the address bar of your Web browser, enter the following URI:

    ```http
    http://localhost:12345/northwind.svc/Customers('ALFKI')/Orders?$filter=OrderID eq 10643
    ```

     This filters orders that belong to the specific customer `ALFKI` so that only a specific order is returned based on the supplied `OrderID` value.

## Next Steps

You have successfully accessed the WCF Data Services from a Web browser, with the browser issuing HTTP GET requests to specified resources. A Web browser provides an easy way to experiment with the addressing syntax of requests and view the results. However, a production data service is not generally accessed by this method. Typically, applications interact with the data service through application code or scripting languages. Next, you will create a client application that uses client libraries to access data service resources as if they were common language runtime (CLR) objects:

> [!div class="nextstepaction"]
> [Creating the .NET Framework Client Application](creating-the-dotnet-client-application-wcf-data-services-quickstart.md)

## See also

- [Accessing Data Service Resources](accessing-data-service-resources-wcf-data-services.md)
