---
title: "Secure Client Applications"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6239592e-fa7d-4dea-9f00-d296d0048b01
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Secure Client Applications
Applications typically consist of many parts that must all be protected from vulnerabilities that could result in data loss or otherwise compromise the system. Creating secure user interfaces can prevent many problems by blocking attackers before they can access data or system resources.  
  
## Validate User Input  
 When constructing an application that accesses data, you should assume that all user input is malicious until proven otherwise. Failure to do so can leave your application vulnerable to attack. The .NET Framework contains classes to help you enforce a domain of values for input controls, such as limiting the number of characters that can be entered. Event hooks allow you to write procedures to check the validity of values. User input data can be validated and strongly typed, limiting an application's exposure to script and SQL injection exploits.  
  
> [!IMPORTANT]
>  You must also validate user input at the data source as well as in the client application. An attacker may choose to circumvent your application and attack the data source directly.  
  
 [Security and User Input](../../../../docs/standard/security/security-and-user-input.md)  
 Describes how to handle subtle and potentially dangerous bugs involving user input.  
  
 [Validating User Input in ASP.NET Web Pages](http://msdn.microsoft.com/library/4ad3dacb-89e0-4cee-89ac-40a3f2a85461)  
 Overview of validating user input using ASP.NET validation controls.  
  
 [User Input in Windows Forms](../../../../docs/framework/winforms/user-input-in-windows-forms.md)  
 Provides links and information for validating mouse and keyboard input in a Windows Forms application.  
  
 [.NET Framework Regular Expressions](../../../../docs/standard/base-types/regular-expressions.md)  
 Describes how to use the <xref:System.Text.RegularExpressions.Regex> class to check the validity of user input.  
  
## Windows Applications  
 In the past, Windows applications generally ran with full permissions. The .NET Framework provides the infrastructure to restrict code executing in a Windows application by using code access security (CAS). However, CAS alone is not enough to protect your application.  
  
 [Windows Forms Security](../../../../docs/framework/winforms/windows-forms-security.md)  
 Discusses how to secure Windows Forms applications and provides links to related topics.  
  
 [Windows Forms and Unmanaged Applications](../../../../docs/framework/winforms/advanced/windows-forms-and-unmanaged-applications.md)  
 Describes how to interact with unmanaged applications in a Windows Forms application.  
  
 [ClickOnce Deployment for Windows Forms Applications](http://msdn.microsoft.com/library/34d8c770-48f2-460c-8d67-4ea5684511df)  
 Describes how to use `ClickOnce` deployment in a Windows Forms application and discusses the security implications.  
  
## ASP.NET and XML Web Services  
 ASP.NET applications generally need to restrict access to some portions of the Web site and provide other mechanisms for data protection and site security. These links provide useful information for securing your ASP.NET application.  
  
 An XML Web service provides data that can be consumed by an ASP.NET application, a Windows Forms application, or another Web service. You need to manage security for the Web service itself as well as security for the client application.  
  
 For more information, see the following resources.  
  
|Resource|Description|  
|--------------|-----------------|  
|[NIB: ASP.NET Security](http://msdn.microsoft.com/library/04b37532-18d9-40b4-8e5f-ee09a70b311d)|Discusses how to secure ASP.NET applications.|  
|[Securing XML Web Services Created Using ASP.NET](http://msdn.microsoft.com/library/354b2ab1-2782-4542-b32a-dc560178b90c)|Discusses how to implement security for an ASP.NET Web Service.|  
|[Script Exploits Overview](http://msdn.microsoft.com/library/772c7312-211a-4eb3-8d6e-eec0aa1dcc07)|Discusses how to guard against a script exploit attack, which attempts to insert malicious characters into a Web page.|  
|[NIB:Basic Security Practices for ASP.NET Web Applications](http://msdn.microsoft.com/library/94a52ab8-731d-417e-b997-721baf43df38)|General security information and links to further discussion,|  
  
## Remoting  
 .NET remoting enables you to build widely distributed applications easily, whether the application components are all on one computer or spread out across the entire world. You can build client applications that use objects in other processes on the same computer or on any other computer that is reachable over its network. You can also use .NET remoting to communicate with other application domains in the same process.  
  
|Resource|Description|  
|--------------|-----------------|  
|[Configuration of Remote Applications](http://msdn.microsoft.com/library/92c0c097-d984-4315-835b-7490ecdf1097)|Discusses how to configure remoting applications in order to avoid common problems.|  
|[Security in Remoting](http://msdn.microsoft.com/library/9574262c-d4b1-41c5-8600-24ff147c0add)|Describes authentication and encryption as well as additional security topics relevant to remoting.|  
|[Security and Remoting Considerations](../../../../docs/framework/misc/security-and-remoting-considerations.md)|Describes security issues with protected objects and application domain crossing.|  
  
## See Also  
 [Securing ADO.NET Applications](../../../../docs/framework/data/adonet/securing-ado-net-applications.md)  
 [Recommendations for Data Access Strategies](http://msdn.microsoft.com/library/72411f32-d12a-4de8-b961-e54fca7faaf5)  
 [Securing Applications](/visualstudio/ide/securing-applications)  
 [Protecting Connection Information](../../../../docs/framework/data/adonet/protecting-connection-information.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
