---
title: "Secure Client Applications | Microsoft Docs"
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
author: "JennieHubbard"
ms.author: "jhubbard"
manager: "jhubbard"
---
# Secure Client Applications
Applications typically consist of many parts that must all be protected from vulnerabilities that could result in data loss or otherwise compromise the system. Creating secure user interfaces can prevent many problems by blocking attackers before they can access data or system resources.  
  
## Validate User Input  
 When constructing an application that accesses data, you should assume that all user input is malicious until proven otherwise. Failure to do so can leave your application vulnerable to attack. The .NET Framework contains classes to help you enforce a domain of values for input controls, such as limiting the number of characters that can be entered. Event hooks allow you to write procedures to check the validity of values. User input data can be validated and strongly typed, limiting an application's exposure to script and SQL injection exploits.  
  
> [!IMPORTANT]
>  You must also validate user input at the data source as well as in the client application. An attacker may choose to circumvent your application and attack the data source directly.  
  
 [Security and User Input](../../../../docs/standard/security/security-and-user-input.md)  
 Describes how to handle subtle and potentially dangerous bugs involving user input.  
  
 [Validating User Input in ASP.NET Web Pages](https://msdn.microsoft.com/library/7kh55542.aspx)  
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
  
 [ClickOnce Deployment for Windows Forms Applications](https://msdn.microsoft.com/library/wh45kb66(v=vs.90).aspx)  
 Describes how to use `ClickOnce` deployment in a Windows Forms application and discusses the security implications.  
  
## ASP.NET and XML Web Services  
 ASP.NET applications generally need to restrict access to some portions of the Web site and provide other mechanisms for data protection and site security. These links provide useful information for securing your ASP.NET application.  
  
 An XML Web service provides data that can be consumed by an ASP.NET application, a Windows Forms application, or another Web service. You need to manage security for the Web service itself as well as security for the client application.  
  
 For more information, see the following resources.  
  
|Resource|Description|  
|--------------|-----------------|  
|[NIB: ASP.NET Security](https://msdn.microsoft.com/library/91f66yxt(v=vs.100).aspx)|Discusses how to secure ASP.NET applications.|  
|[Securing XML Web Services Created Using ASP.NET](https://msdn.microsoft.com/library/w67h0dw7(v=vs.100).aspx)|Discusses how to implement security for an ASP.NET Web Service.|  
|[Script Exploits Overview](https://msdn.microsoft.com/library/w1sw53ds.aspx)|Discusses how to guard against a script exploit attack, which attempts to insert malicious characters into a Web page.|  
|[NIB:Basic Security Practices for ASP.NET Web Applications](https://msdn.microsoft.com/library/t4ahd590(v=vs.90).aspx)|General security information and links to further discussion,|  
  
## Remoting  
 .NET remoting enables you to build widely distributed applications easily, whether the application components are all on one computer or spread out across the entire world. You can build client applications that use objects in other processes on the same computer or on any other computer that is reachable over its network. You can also use .NET remoting to communicate with other application domains in the same process.  
  
|Resource|Description|  
|--------------|-----------------|  
|[Configuration of Remote Applications](https://msdn.microsoft.com/library/b8tysty8(v=vs.100).aspx)|Discusses how to configure remoting applications in order to avoid common problems.|  
|[Security in Remoting](https://msdn.microsoft.com/library/9hwst9th(v=vs.100).aspx)|Describes authentication and encryption as well as additional security topics relevant to remoting.|  
|[Security and Remoting Considerations](../../../../docs/framework/misc/security-and-remoting-considerations.md)|Describes security issues with protected objects and application domain crossing.|  
  
## See Also  
 [Securing ADO.NET Applications](../../../../docs/framework/data/adonet/securing-ado-net-applications.md)   
 [Recommendations for Data Access Strategies](https://msdn.microsoft.com/library/8fxztkff(v=vs.100).aspx)   
 [Securing Applications](/visualstudio/ide/securing-applications)   
 [Protecting Connection Information](../../../../docs/framework/data/adonet/protecting-connection-information.md)   
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
