---
title: "WCF Data Services 4.5"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Astoria"
  - "WCF Data Services, getting started"
ms.assetid: 73d2bec3-7c92-4110-b905-11bb0462357a
---

# WCF Data Services 4.5

WCF Data Services (formerly known as "ADO.NET Data Services") is a component of the .NET Framework that enables you to create services that use the Open Data Protocol (OData) to expose and consume data over the Web or intranet by using the semantics of [representational state transfer (REST)](https://go.microsoft.com/fwlink/?LinkId=113919). OData exposes data as resources that are addressable by URIs. Data is accessed and changed by using standard HTTP verbs of GET, PUT, POST, and DELETE. OData uses the entity-relationship conventions of the [Entity Data Model](../adonet/entity-data-model.md) to expose resources as sets of entities that are related by associations.

WCF Data Services uses the OData protocol for addressing and updating resources. In this way, you can access these services from any client that supports OData. OData enables you to request and write data to resources by using well-known transfer formats: Atom, a set of standards for exchanging and updating data as XML, and JavaScript Object Notation (JSON), a text-based data exchange format used extensively in AJAX applications.

WCF Data Services can expose data that originates from various sources as OData feeds. Visual Studio tools make it easier for you to create an OData-based service by using an ADO.NET Entity Framework data model. You can also create OData feeds based on common language runtime (CLR) classes and even late-bound or un-typed data.

WCF Data Services also includes a set of client libraries, one for general .NET Framework client applications and another specifically for Silverlight-based applications. These client libraries provide an object-based programming model when you access an OData feed from environments such as the .NET Framework and Silverlight.

## Where Should I Start?

Depending on your interests, consider getting started with WCF Data Services in one of the following topics.

I want to jump right in...

- [Quickstart](quickstart-wcf-data-services.md)

- [Getting Started](getting-started-with-wcf-data-services.md)

- [Silverlight Quickstart](https://go.microsoft.com/fwlink/?LinkID=192782)

- [Silverlight Quickstart for Windows Phone Development](https://go.microsoft.com/fwlink/?LinkID=214535)

Just show me some code...

- [Quickstart](quickstart-wcf-data-services.md)

- [How to: Execute Data Service Queries](how-to-execute-data-service-queries-wcf-data-services.md)

- [How to: Bind Data to Windows Presentation Foundation Elements](bind-data-to-wpf-elements-wcf-data-services.md)

I want to know more about OData...

- [Whitepaper: Introducing OData](https://go.microsoft.com/fwlink/?LinkId=220867)

- [Open Data Protocol Web site](https://go.microsoft.com/fwlink/?LinkID=184554)

- [OData: SDK](https://go.microsoft.com/fwlink/?LinkID=185248)

- [OData: Frequently Asked Questions](https://go.microsoft.com/fwlink/?LinkId=185867)

I want to watch some videos...

- [Beginner's Guide to WCF Data Services](https://go.microsoft.com/fwlink/?LinkId=220864)

- [WCF Data Services Developer Videos](https://go.microsoft.com/fwlink/?LinkId=220861)

- [OData: Developers Web site](https://go.microsoft.com/fwlink/?LinkId=185866)

I want to see end-to-end samples...

- [WCF Data Services Documentation Samples on MSDN Samples Gallery](https://go.microsoft.com/fwlink/?LinkID=220865)

- [Other WCF Data Services Samples on MSDN Samples Gallery](https://go.microsoft.com/fwlink/?LinkId=220866)

- [OData: SDK](https://go.microsoft.com/fwlink/?LinkID=185248)

How does it integrate with Visual Studio?

- [Generating the Data Service Client Library](generating-the-data-service-client-library-wcf-data-services.md)

- [Creating the Data Service](creating-the-data-service.md)

- [Entity Framework Provider](entity-framework-provider-wcf-data-services.md)

What can I do with it?

- [Overview](wcf-data-services-overview.md)

- [Whitepaper: Introducing OData](https://go.microsoft.com/fwlink/?LinkId=220867)

- [Application Scenarios](application-scenarios-wcf-data-services.md)

I want to use Silverlight...

- [Silverlight Quickstart](https://go.microsoft.com/fwlink/?LinkID=192782)

- [WCF Data Services (Silverlight)](https://go.microsoft.com/fwlink/?LinkID=143149)

- [Getting Started with Silverlight](https://go.microsoft.com/fwlink/?LinkId=148366)

I want to use LINQ...

- [Querying the Data Service](querying-the-data-service-wcf-data-services.md)

- [LINQ Considerations](linq-considerations-wcf-data-services.md)

- [How to: Execute Data Service Queries](how-to-execute-data-service-queries-wcf-data-services.md)

I still need some more information...

- [WCF Data Services Team Blog](https://go.microsoft.com/fwlink/?LinkID=150511)

- [Resources](wcf-data-services-resources.md)

- [WCF Data Services Developer Center](https://go.microsoft.com/fwlink/?LinkId=220868)

- [Open Data Protocol Web site](https://go.microsoft.com/fwlink/?LinkID=184554)

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

- [Representational State Transfer (REST)](https://go.microsoft.com/fwlink/?LinkId=113919)
