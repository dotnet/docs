---
description: "Learn more about: SystemWebRouting Integration Sample"
title: "SystemWebRouting Integration Sample"
ms.date: "03/30/2017"
ms.assetid: f1c94802-95c4-49e4-b1e2-ee9dd126ff93
---
# SystemWebRouting Integration Sample

The [WebRoutingIntegration sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates the hosting layer's integration with the classes in the <xref:System.Web.Routing> namespace. The classes in the <xref:System.Web.Routing> namespace allow an application to use URLs that do not directly correspond to a physical resource. Using Web routing allows the developer to create virtual addresses for HTTP that are then mapped back to actual WCF services. This is useful when a WCF service must be hosted without requiring a physical file or resource, or when services must be accessed with URLs that do not contain files such as .html or .aspx. This sample demonstrates how to utilize the <xref:System.Web.Routing.RouteTable> class to create virtual URIs that map to running services defined in global.asax.

> [!NOTE]
> The classes in the <xref:System.Web.Routing> namespace only work for services hosted over HTTP.

This example uses WCF to create two RSS feeds: a `movies` feed and a `channels` feed. The URLs to activate the services do not contain an extension and are registered in the `Application_Start` method of the `Global` class derived from the <xref:System.Web.HttpApplication> class.

> [!NOTE]
> This sample only works in Internet Information Services (IIS) 7.0 and later, as IIS 6.0 uses a different method for supporting extension-less URLs.

#### To use this sample

1. Using Visual Studio, open the WebRoutingIntegration.sln file.

2. To run the solution and start the Web development server, press **F5**.

     A directory listing for the sample appears. Note that there are no files with an .svc file extension.

3. In the address bar, add `movies` to the URL, so that it reads `http://localhost:[port]/movies` and press ENTER.

     The movies feed appears in the browser.

4. In the address bar, add `channels` to the URL, so that is reads `http://localhost:[port]/channels` and press ENTER.

     The channels feed appears in the browser.

5. Close the Web browser, by pressing ALT+F4.

     If the development server has not exited, right-click the notification area icon and select **Stop**.

#### To use this sample when hosted in IIS

1. Using Visual Studio, open the WebRoutingIntegration.sln file.

2. Build the project, by pressing **Ctrl**+**Shift**+**B**.

3. Create a Web application in Internet Information Services (IIS) Manager.

    1. In IIS Manager, right click the **Default Web Site** and select **Add an Application**.

    2. For the **alias**, type in `WebRoutingIntegration`.

    3. For the **Physical Path**, select the Service folder inside the project.

    4. Press **OK**.

4. Start the application, by right-clicking the Web application and selecting **Manage Application** and then **Browse**.

5. In the address bar, add `movies` to the URL, so that is reads `http://localhost:[port]/movies` and press ENTER.

     The movies feed appears in the browser.

6. In the address bar, add `channels` to the URL, so that is reads `http://localhost:[port]/channels` and press ENTER.

     The channels feed appears in the browser.

7. Close the Web browser, by pressing ALT+F4.

This sample demonstrates that the hosting layer is capable of composing with the classes in the <xref:System.Web.Routing> namespace for routing the requests of services hosted over HTTP.

> [!NOTE]
> You must update the default application pool version to .NET Framework 4 if it's set to version 2.

## See also

- [AppFabric Hosting and Persistence Samples](/previous-versions/appfabric/ff383418(v=azure.10))
