---
title: "WCF Data Services 4.5"
description: Learn about WCF Data Services, a .NET Framework component which supports services to expose and consume data using REST semantics.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Astoria"
  - "WCF Data Services, getting started"
ms.assetid: 73d2bec3-7c92-4110-b905-11bb0462357a
---

# WCF Data Services 4.5

WCF Data Services (formerly known as "ADO.NET Data Services") is a component of the .NET Framework that enables you to create services that use the Open Data Protocol (OData) to expose and consume data over the Web or intranet by using the semantics of [representational state transfer (REST)](https://www.ics.uci.edu/~fielding/pubs/dissertation/rest_arch_style.htm). OData exposes data as resources that are addressable by URIs. Data is accessed and changed by using standard HTTP verbs of GET, PUT, POST, and DELETE. OData uses the entity-relationship conventions of the [Entity Data Model](../adonet/entity-data-model.md) to expose resources as sets of entities that are related by associations.

WCF Data Services uses the OData protocol for addressing and updating resources. In this way, you can access these services from any client that supports OData. OData enables you to request and write data to resources by using well-known transfer formats: Atom, a set of standards for exchanging and updating data as XML, and JavaScript Object Notation (JSON), a text-based data exchange format used extensively in AJAX applications.

WCF Data Services can expose data that originates from various sources as OData feeds. Visual Studio tools make it easier for you to create an OData-based service by using an ADO.NET Entity Framework data model. You can also create OData feeds based on common language runtime (CLR) classes and even late-bound or un-typed data.

WCF Data Services also includes a set of client libraries, one for general .NET Framework client applications and another specifically for Silverlight-based applications. These client libraries provide an object-based programming model when you access an OData feed from environments such as the .NET Framework and Silverlight.

## Where Should I Start?

Depending on your interests, consider getting started with WCF Data Services in one of the following topics.

I want to jump right in...

- [Quickstart](quickstart-wcf-data-services.md)

- [Getting Started](getting-started-with-wcf-data-services.md)

Just show me some code...

- [Quickstart](quickstart-wcf-data-services.md)

- [How to: Execute Data Service Queries](how-to-execute-data-service-queries-wcf-data-services.md)

- [How to: Bind Data to Windows Presentation Foundation Elements](bind-data-to-wpf-elements-wcf-data-services.md)

I want to know more about OData...

- [White paper: Introducing OData](https://download.microsoft.com/download/E/5/A/E5A59052-EE48-4D64-897B-5F7C608165B8/IntroducingOData.pdf)
- [Open Data Protocol website](https://www.odata.org/)
- [OData: SDK](https://www.odata.org/ecosystem/)

I want to see end-to-end samples...

- [WCF Data Services Quickstart](https://github.com/microsoftarchive/msdn-code-gallery-community-s-z/tree/master/WCF%20Data%20Services%20Quickstart%20(OData%20Service%20and%20WPF%20Client))
- [OData SDK - Sample Code](https://www.odata.org/ecosystem/#sdk)

How does it integrate with Visual Studio?

- [Generating the Data Service Client Library](generating-the-data-service-client-library-wcf-data-services.md)

- [Creating the Data Service](creating-the-data-service.md)

- [Entity Framework Provider](entity-framework-provider-wcf-data-services.md)

What can I do with it?

- [Overview](wcf-data-services-overview.md)

- [Application Scenarios](application-scenarios-wcf-data-services.md)

I want to use LINQ...

- [Querying the Data Service](querying-the-data-service-wcf-data-services.md)

- [LINQ Considerations](linq-considerations-wcf-data-services.md)

- [How to: Execute Data Service Queries](how-to-execute-data-service-queries-wcf-data-services.md)

I still need some more information...

- [WCF Data Services Team Blog](https://docs.microsoft.com/archive/blogs/astoriateam/)

- [Resources](wcf-data-services-resources.md)

## In This Section

[Overview](wcf-data-services-overview.md)

Provides an overview of the features and functionality available in WCF Data Services.

[What's New in WCF Data Services 5.0](https://docs.microsoft.com/previous-versions/dotnet/wcf-data-services/ee373845(v=vs.103))

Describes new functionality in WCF Data Services and support for new OData features.

[Getting Started](getting-started-with-wcf-data-services.md)

Describes how to expose and consume OData feeds by using WCF Data Services.

[Defining WCF Data Services](defining-wcf-data-services.md)

Describes how to create and configure a data service that exposes OData feeds.

[WCF Data Services Client Library](wcf-data-services-client-library.md)

Describes how to use client libraries to consume OData feeds from a .NET Framework client application.

## See also

- [Representational State Transfer (REST)](https://www.ics.uci.edu/~fielding/pubs/dissertation/rest_arch_style.htm)
