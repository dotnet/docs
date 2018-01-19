---
title: "Caching in .NET Framework Applications"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "ASP.NET caching"
  - "caching [.NET Framework]"
  - "caching [ASP.NET]"
ms.assetid: c4b47ee0-4b82-4124-9bce-818088385e34
caps.latest.revision: 26
author: "tdykstra"
ms.author: "tdykstra"
manager: "wpickett"
ms.workload: 
  - "tdykstra"
---
# Caching in .NET Framework Applications
Caching enables you to store data in memory for rapid access. When the data is accessed again, applications can get the data from the cache instead of retrieving it from the original source. This can improve performance and scalability. In addition, caching makes data available when the data source is temporarily unavailable.  
  
 The .NET Framework provides caching functionality that you can use to improve the performance and scalability of both Windows client and server applications, including ASP.NET.  
  
> [!NOTE]
>  In the [!INCLUDE[net_v35_short](../../../includes/net-v35-short-md.md)] and earlier versions, ASP.NET provided an in-memory cache implementation in the <xref:System.Web.Caching> namespace. In previous versions of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)], caching was available only in the <xref:System.Web> namespace and therefore required a dependency on ASP.NET classes. In the .NET Framework 4, the <xref:System.Runtime.Caching> namespace contains APIs that are designed for both Web and non-Web applications.  
  
## Caching Data  
 You can cache information by using classes in the <xref:System.Runtime.Caching> namespace. The caching classes in this namespace provide the following features:  
  
-   Abstract types that provide the foundation for creating custom cache implementations.  
  
-   A concrete in-memory object cache implementation.  
  
 The abstract base caching class (<xref:System.Runtime.Caching.ObjectCache>) defines the following caching tasks:  
  
-   Creating and managing cache entries.  
  
-   Specifying expiration and eviction information.  
  
-   Triggering events that are raised in response to changes in cache entries.  
  
 The <xref:System.Runtime.Caching.MemoryCache> class is an in-memory object cache implementation of the <xref:System.Runtime.Caching.ObjectCache> class. You can use the <xref:System.Runtime.Caching.MemoryCache> class for most caching tasks.  
  
> [!NOTE]
>  The <xref:System.Runtime.Caching.MemoryCache> class is modeled on the ASP.NET cache object that is defined in the <xref:System.Web.Caching> namespace. Therefore, the internal caching logic similar to the logic that was provided in earlier versions of ASP.NET.  
  
 For an example of how to use to caching in a WPF application, see [Walkthrough: Caching Application Data in a WPF Application](../../../docs/framework/wpf/advanced/walkthrough-caching-application-data-in-a-wpf-application.md).  
  
## Caching in ASP.NET Applications  
 The caching classes in the <xref:System.Runtime.Caching> namespace provide functionality for caching data in ASP.NET.  
  
> [!NOTE]
>  If your application targets the [!INCLUDE[net_v35_short](../../../includes/net-v35-short-md.md)] or earlier, you must use the caching classes that are defined in the <xref:System.Web.Caching> namespace. For more information, see [ASP.NET Caching Overview](http://msdn.microsoft.com/library/5ec28012-4972-4dc3-b3e8-9d20401fe11d).  
  
> [!NOTE]
>  When you develop new applications, we recommend that you use the <xref:System.Runtime.Caching.MemoryCache> class. The API that is provided in the <xref:System.Runtime.Caching> namespace is like the API that is provided in the <xref:System.Web.Caching.Cache> namespace. Therefore, the API will be familiar if you used caching in earlier versions of ASP.NET. For an example of how to use caching in ASP.NET applications, see [Walkthrough: Caching Application Data in ASP.NET](http://msdn.microsoft.com/library/942236f6-0138-4aaf-af71-a5ea451a1e23).  
  
### Output Caching  
 To manually cache application data, you can use the <xref:System.Runtime.Caching.MemoryCache> class in ASP.NET. ASP.NET also supports output caching, which stores the generated output of pages, controls, and HTTP responses in memory. You can configure output caching declaratively in an ASP.NET Web page or by using settings in the Web.config file. For more information, see [outputCache Element for caching (ASP.NET Settings Schema)](http://msdn.microsoft.com/library/47cd2b47-316f-4dfd-bbf8-539be3066fee).  
  
 ASP.NET lets you extend output caching by creating custom output-cache providers. By using custom providers, you can store cached content using other storage devices such as disks, cloud storage, and distributed cache engines. To create a custom output cache provider, you create a class that derives from the <xref:System.Web.Caching.OutputCacheProvider> class and configure the application to use the custom output cache provider.  
  
## Caching in WCF REST Services  
 For WCF REST services, the .NET Framework enables you to take advantage of the declarative output caching that is available in ASP.NET. This enables you to cache responses from your WCF REST service operations. When a user sends an HTTP GET request to a service that is configured for caching, ASP.NET sends back the cached response, and the service method is not called. After the cache expires, the next time that a user sends an HTTP GET request, your service method is called and the response is again cached.  
  
 The .NET Framework also enables you to implement conditional HTTP GET caching. In REST scenarios, a conditional HTTP GET request is often used by services to implement intelligent HTTP caching as described in the [HTTP Specification](http://go.microsoft.com/fwlink/?LinkId=165800). For more information, see [Caching Support for WCF Web HTTP Services](http://go.microsoft.com/fwlink/?LinkId=184598).  
  
## Extending Caching in the .NET Framework  
 Caching in the .NET Framework is designed to be extensible. The <xref:System.Runtime.Caching.ObjectCache> class enables you to create a custom cache implementation. This class provides members that are available to all managed applications, including Windows Forms, Windows Presentation Foundation (WPF), and Windows Communications Foundation (WCF). You might do this in order to create a cache class that uses a different storage mechanism, or if you want granular control over cache operations.  
  
 To extend caching you can do the following:  
  
-   Create a custom class that derives from the <xref:System.Runtime.Caching.ObjectCache> class and then provide a custom cache implementation in the derived class.  
  
-   Create a class that derives from <xref:System.Runtime.Caching.MemoryCache> class and customize or extend the derived class. For an example of how to do this, see [Caching Application Data by Using Multiple Cache Objects in an ASP.NET Application](http://blogs.msdn.com/aspnetue/archive/2010/03/22/caching-application-data-by-using-multiple-cache-objects-in-an-asp-net-application.aspx).  
  
-   Create a class that derives from the <xref:System.Web.Caching.OutputCacheProvider> class and configure the application to use the custom output cache provider.  
  
 For more information, see the entry [Extensible Output Caching with ASP.NET 4 (VS 2010 and .NET 4.0 Series)](http://go.microsoft.com/fwlink/?LinkId=185772) on Scott Guthrie's blog.  
  
## See Also  
 <xref:System.Runtime.Caching.ObjectCache>  
 <xref:System.Runtime.Caching.MemoryCache>  
 [Walkthrough: Caching Application Data in a WPF Application](../../../docs/framework/wpf/advanced/walkthrough-caching-application-data-in-a-wpf-application.md)  
 [Walkthrough: Caching Application Data in ASP.NET](http://msdn.microsoft.com/library/942236f6-0138-4aaf-af71-a5ea451a1e23)
