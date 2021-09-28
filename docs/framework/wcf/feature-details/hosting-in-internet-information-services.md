---
description: "Learn more about: Host in Internet Information Services"
title: "Hosting in Internet Information Services"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "hosting services [WCF], IIS"
ms.assetid: ddae14e8-143c-442d-b660-2046809b2d43
---
# Host in Internet Information Services

One option for hosting Windows Communication Foundation (WCF) services is inside of an Internet Information Services (IIS) application. This hosting model is similar to the model used by ASP.NET and ASP.NET Web services (ASMX) Web Services.

## Versions of IIS

WCF can be hosted on the following versions of IIS on the following operating systems:

- IIS 5.1 on Windows XP SP2. This environment is useful for the design and development of IIS-hosted applications that are later deployed on a server operating system such as Windows Server 2003.

- IIS 6.0 on Windows Server 2003. IIS 6.0 provides an advanced process model that offers improved scalability, reliability, and application isolation. This environment is suitable for production deployment of WCF services that use HTTP communication exclusively.

- IIS 7.0 on Windows Vista and Windows Server 2008. IIS 7.0 provides the same advanced process model as IIS 6.0, but uses the Windows Process Activation Service (WAS) to allow activation and network communication over protocols other than HTTP. This environment is suitable for the development of WCF services that communicate over any network protocol supported by WCF (including HTTP, net.tcp, net.pipe, and net.msmq). For more information about WAS, see [Hosting in Windows Process Activation Service](hosting-in-windows-process-activation-service.md).

- [Windows Server AppFabric](/previous-versions/appfabric/ff384253(v=azure.10)) works with IIS 7.0 and Windows Process Activation Service (WAS) to provide a rich application hosting environment for NET4 WCF and WF services. These benefits include process life-cycle management, process recycling, shared hosting, rapid failure protection, process orphaning, on-demand activation, and health monitoring. For detailed information, see [AppFabric Hosting Features](/previous-versions/appfabric/ee677189(v=azure.10)) and [AppFabric Hosting Concepts](/previous-versions/appfabric/ee677371(v=azure.10)).

## Benefits of IIS hosting

Hosting WCF services in IIS has several benefits:

- WCF services hosted in IIS are deployed and managed like any other type of IIS application, including ASP.NET applications and ASMX.

- IIS provides process activation, health management, and recycling capabilities to increase the reliability of hosted applications.

- Like ASP.NET, WCF services hosted in ASP.NET can take advantage of the ASP.NET shared hosting model where multiple applications reside in a common worker process for improved server density and scalability.

- WCF services hosted in IIS use the same dynamic compilation model as ASP.NET 2.0, which simplifies development and deployment of hosted services.

When deciding to host WCF services in IIS, it is important to remember that IIS 5.1 and IIS 6.0 are limited to HTTP communication only. For more information about choosing a hosting environment, see [Hosting Services](../hosting-services.md).

## Deploy an IIS-hosted WCF service

Developing and deploying an IIS-hosted WCF service consists of the following tasks:

- Ensure that IIS, ASP.NET, WCF, and the WCF HTTP activation component are correctly installed and registered.

- Create a new IIS application, or reuse an existing ASP.NET application.

- Create a .svc file for the WCF service.

- Deploy the service implementation to the IIS application.

- Configure the WCF service.

For a discussion of each of these tasks, see [Deploying an Internet Information Services-Hosted WCF Service](deploying-an-internet-information-services-hosted-wcf-service.md).

## WCF services and ASP.NET

WCF services can be hosted either side-by-side with ASP.NET or in ASP.NET Compatibility Mode in which services can take full advantage of features provided by the ASP.NET Web application platform. For a discussion of these features, see [WCF Services and ASP.NET](wcf-services-and-aspnet.md).

## See also

- [Extending Hosting Using ServiceHostFactory](../extending/extending-hosting-using-servicehostfactory.md)
- [Deploying an Internet Information Services-Hosted WCF Service](deploying-an-internet-information-services-hosted-wcf-service.md)
- [WCF Services and ASP.NET](wcf-services-and-aspnet.md)
- [Internet Information Services Hosting Best Practices](internet-information-services-hosting-best-practices.md)
- [Configuring Internet Information Services 7.0 for Windows Communication Foundation](configuring-iis-for-wcf.md)
- [Windows Server App Fabric Hosting Features](/previous-versions/appfabric/ee677189(v=azure.10))
