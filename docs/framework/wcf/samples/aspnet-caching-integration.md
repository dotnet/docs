---
description: "Learn more about: ASP.NET Caching Integration"
title: "ASP.NET Caching Integration"
ms.date: "03/30/2017"
ms.assetid: f581923a-8a72-42fc-bd6a-46de2aaeecc1
---
# ASP.NET Caching Integration

The [AspNetCachingIntegration sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to utilize the ASP.NET output cache with the WCF WEB HTTP programming model. This topic focuses on the ASP.NET output cache integration feature.

## Demonstrates

Integration with the ASP.NET Output Cache.

## Discussion

The sample uses the <xref:System.ServiceModel.Web.AspNetCacheProfileAttribute> to utilize ASP.NET output caching with the Windows Communication Foundation (WCF) service. The <xref:System.ServiceModel.Web.AspNetCacheProfileAttribute> is applied to service operations, and provides the name of a cache profile in a configuration file that should be applied to responses from the given operation.

In the Service.cs file of the sample Service project, both the `GetCustomer` and `GetCustomers` operations are marked with the <xref:System.ServiceModel.Web.AspNetCacheProfileAttribute>, which provides the cache profile name "CacheFor60Seconds". In the Web.config file of the Service project, the cache profile "CacheFor60Seconds" is provided under the <`caching`> element of <`system.web`>. For this cache profile, the value of the `duration` attribute is "60", so responses associated with this profile are cached in the ASP.NET output cache for 60 seconds. Also, for this cache profile, the `varmByParam` attribute is set to "format" so requests with different values for the `format` query string parameter have their responses cached separately. Lastly, the cache profile's `varyByHeader` attribute is set to "Accept", so requests with different Accept header values have their responses cached separately.

Program.cs in the Client project demonstrates how such a client can be authored using <xref:System.Net.HttpWebRequest>. Note that this is just one way to access a WCF service. It is also possible to access the service using other .NET Framework classes like the WCF channel factory and <xref:System.Net.WebClient>. Other samples in the SDK (such as the [Basic HTTP Service](basic-http-service.md) sample) illustrate how to use these classes to communicate with a WCF service.

## To run the sample

The sample consists of three projects:

- **Service**: A Web Application project that includes a WCF HTTP service hosted in ASP.NET.

- **Client**: A console application project that makes calls to the service.

- **Common**: A shared library that contains the Customer type used by the client and service.

As the Client console application runs, the client makes requests to the service and writes the pertinent information from the responses to the console window.

#### To run the sample

1. Open the solution for the ASP.NET Caching Integration Sample.

2. Press **Ctrl**+**Shift**+**B** to build the solution.

3. If the **Solution Explorer** window is not already open, press CTRL+W+S.

4. From the **Solution Explorer** window, right click the **Service** project and select **Start New Instance**. This launches the ASP.NET development server, which hosts the service.

5. From the **Solution Explorer** window, right click the **Client** project and select **Start New Instance**.

6. The client console window appears and provides the URI of the running service and the URI of the HTML help page for the running service. At any point in time you can view the HTML help page by typing the URI of the help page in a browser.

7. As the sample runs, the client writes the status of the current activity.

8. Press any key to terminate the client console application.

9. Press SHIFT+F5 to stop debugging the service.

10. In the Windows Notification Area, right click the ASP.NET development server icon and select **Stop**.
