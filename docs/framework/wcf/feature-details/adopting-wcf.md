---
title: "Adopting Windows Communication Foundation"
ms.date: "03/30/2017"
ms.assetid: 49ba71e2-9468-4082-84c5-cf8daf95e34a
---
# Adopting Windows Communication Foundation

You can choose to use Windows Communication Foundation (WCF) for new development, while continuing to maintain existing applications developed using ASP.NET. Because WCF is intended to be the most suitable choice for facilitating communication with applications built with the .NET Framework in any scenario, it can serve as a standard tool for solving a wide variety of software communications problems in a way that ASP.NET cannot.

New WCF applications can be deployed on the same machines as existing ASP.NET Web services. If the existing ASP.NET Web services use a version of the .NET Framework prior to version 2.0, then you can use the ASP.NET IIS Registration Tool to selectively deploy the .NET Framework 2.0 to IIS applications in which new WCF applications are to be hosted. That tool is documented at [ASP.NET IIS Registration Tool (Aspnet_regiis.exe)](https://go.microsoft.com/fwlink/?LinkId=94687), and has a user interface built into the IIS 6.0 management console.

WCF can be used to add new features to existing ASP.NET Web services by adding WCF services configured to run in ASP.NET compatibility mode to existing ASP.NET Web service applications in IIS. Because of ASP.NET compatibility mode, the code for the new WCF services can access and update the same application state information as the pre-existing ASP.NET code, by using the <xref:System.Web.HttpContext> class. The applications can also share the same class libraries.

WCF clients can use ASP.NET Web services. WCF services that are configured with the <xref:System.ServiceModel.BasicHttpBinding> can be used by ASP.NET Web service clients. ASP.NET Web services can co-exist with WCF applications, and WCF can even be used to add features to existing ASP.NET Web services. Given all of these ways in which WCF and ASP.NET Web services can be used together, you may want to migrate ASP.NET Web services to WCF only if you require features that are provided by WCF and not ASP.NET Web services.

Even in the few cases where it is necessary, migrating code from one technology to another is seldom the correct approach. The reason for adopting the new technology is to meet new requirements that cannot be met with the earlier technology, and in that case, the correct thing to do is to design a new solution to meet the newly-expanded set of requirements. The new design benefits from your experience with the existing system and from wisdom gained since that system was designed. The new design can also use the full capabilities of the new technologies rather than reproducing the old design on the new platform. After prototyping key elements of the new design, it becomes easier to re-use code from the existing system within the new one.

## See Also

- [How to: Retrieve Metadata and Implement a Compliant Service](../../../../docs/framework/wcf/feature-details/how-to-retrieve-metadata-and-implement-a-compliant-service.md)
