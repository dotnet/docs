---
title: "Migrating ASP.NET Web Services to WCF"
ms.date: "03/30/2017"
ms.assetid: 1adbb931-f0b1-47f3-9caf-169e4edc9907
---
# Migrating ASP.NET Web Services to WCF
ASP.NET provides .NET Framework class libraries and tools for building Web services, as well as facilities for hosting services within Internet Information Services (IIS). Windows Communication Foundation (WCF) provides .NET Framework class libraries, tools and hosting facilities for enabling software entities to communicate using any protocols, including those used by Web services.  Migrating ASP.NET Web Services to WCF allows your applications to take advantage of new features and improvements that are unique to WCF.  
  
 WCF has several important advantages relative to ASP.NET Web services. While ASP.NET Web services tools are solely for building Web services, WCF provides tools that can be used when software entities must be made to communicate with one another. This will reduce the number of technologies that developers are required to know in order to accommodate different software communication scenarios, which in turn will reduce the cost of software development resources, as well as the time to complete software development projects.  
  
 Even for Web service development projects, WCF supports more Web service protocols than ASP.NET Web services support. These additional protocols provide for more sophisticated solutions involving, amongst other things, reliable sessions and transactions.  
  
 WCF supports more protocols for transporting messages than ASP.NET Web services. ASP.NET Web services only support sending messages by using the Hypertext Transfer Protocol (HTTP). WCF supports sending messages by using HTTP, as well as the Transmission Control Protocol (TCP), named pipes, and Microsoft Message Queuing (MSMQ). More important, WCF can be extended to support additional transport protocols. Therefore, software developed using WCF can be adapted to work together with a wider variety of other software, thereby increasing the potential return on the investment.  
  
 WCF provides much richer facilities for deploying and managing applications than ASP.NET Web services provides. In addition to a configuration system, which ASP.NET also has, WCF offers a configuration editor, activity tracing from senders to receivers and back through any number of intermediaries, a trace viewer, message logging, a vast number of performance counters, and support for Windows Management Instrumentation.  
  
 Given these potential benefits of WCF relative to ASP.NET Web services, if you are using, or are considering using ASP.NET Web services you have several options:  
  
-   Continue to use ASP.NET Web services, and forego the benefits proffered by WCF.  
  
-   Keep using ASP.NET Web services with the intention of adopting WCF at some time in the future. The topics in this section explain how to maximize the prospects for being able to use new ASP.NET Web service applications together with future WCF applications. The topics in this section also explain how to build new ASP.NET Web services so as to make it easier to migrate them to WCF. However, if securing the services is important, or reliability or transaction assurances are required, or if custom management facilities will have to be constructed, then it is a better option to adopt WCF. WCF is designed for precisely such scenarios.  
  
-   Adopt WCF for new development, while continuing to maintain your existing ASP.NET Web service applications. This choice is very likely the optimal one. It yields the benefits of WCF, while sparing the cost of modifying the existing applications to use it. In this scenario, new WCF applications can co-exist with existing ASP.NET applications. New WCF applications will be able to use existing ASP.NET Web services, and WCF can be used to program new operational capabilities into existing ASP.NET applications by virtue of WCF ASP.NET compatibility mode.  
  
-   Adopt WCF and migrate existing ASP.NET Web service applications to WCF. You may choose this option to enhance the existing applications with features provided by WCF, or to reproduce the functionality of existing ASP.NET Web services within new, more powerful WCF applications.  
  
> [!NOTE]
>  Care must be taken if a WCF service is hosted by IIS 5.x and ASP.NET is uninstalled. When a WCF service is hosted by IIS 5.x, the code for the service can be requested if ASP.NET is uninstalled. When ASP.NET is uninstalled on an operating system that is running IIS 5.x and WCF is uninstalled, a file with the .svc extension is considered a text file and the contents, including any source code, is returned to the requester.  
  
 This section describes these options in detail, compares ASP.NET Web Services to WCF and provides instructions on how to migrate your ASP.NET Web Services code to WCF.  
  
## See also
- [Anticipating Adopting the Windows Communication Foundation: Easing Future Migration](../../../../docs/framework/wcf/feature-details/anticipating-adopting-wcf-migration.md)
- [Anticipating Adopting the Windows Communication Foundation: Easing Future Integration](../../../../docs/framework/wcf/feature-details/anticipating-adopting-the-wcf-easing-future-integration.md)
- [Adopting Windows Communication Foundation](../../../../docs/framework/wcf/feature-details/adopting-wcf.md)
- [Comparing ASP.NET Web Services to WCF Based on Purpose and Standards Used](../../../../docs/framework/wcf/feature-details/comparing-aspnet-web-services-to-wcf-based-on-purpose-and-standards-used.md)
- [Comparing ASP.NET Web Services to WCF Based on Development](../../../../docs/framework/wcf/feature-details/comparing-aspnet-web-services-to-wcf-based-on-development.md)
