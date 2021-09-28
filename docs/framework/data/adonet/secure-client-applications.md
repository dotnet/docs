---
description: "Learn more about: Secure Client Applications"
title: "Secure Client Applications"
ms.date: "03/30/2017"
ms.assetid: 6239592e-fa7d-4dea-9f00-d296d0048b01
---
# Secure Client Applications

Applications typically consist of many parts that must all be protected from vulnerabilities that could result in data loss or otherwise compromise the system. Creating secure user interfaces can prevent many problems by blocking attackers before they can access data or system resources.  
  
## Validate User Input  

 When constructing an application that accesses data, you should assume that all user input is malicious until proven otherwise. Failure to do so can leave your application vulnerable to attack. The .NET Framework contains classes to help you enforce a domain of values for input controls, such as limiting the number of characters that can be entered. Event hooks allow you to write procedures to check the validity of values. User input data can be validated and strongly typed, limiting an application's exposure to script and SQL injection exploits.  
  
> [!IMPORTANT]
> You must also validate user input at the data source as well as in the client application. An attacker may choose to circumvent your application and attack the data source directly.  
  
 [Security and User Input](../../../standard/security/security-and-user-input.md)  
 Describes how to handle subtle and potentially dangerous bugs involving user input.  
  
 [Validating User Input in ASP.NET Web Pages](/previous-versions/aspnet/7kh55542(v=vs.100))  
 Overview of validating user input using ASP.NET validation controls.  
  
 [User Input in Windows Forms](/dotnet/desktop/winforms/user-input-in-windows-forms)  
 Provides links and information for validating mouse and keyboard input in a Windows Forms application.  
  
 [.NET Framework Regular Expressions](../../../standard/base-types/regular-expressions.md)  
 Describes how to use the <xref:System.Text.RegularExpressions.Regex> class to check the validity of user input.  
  
## Windows Applications  

 In the past, Windows applications generally ran with full permissions. The .NET Framework provides the infrastructure to restrict code executing in a Windows application by using code access security (CAS). However, CAS alone is not enough to protect your application.  
  
 [Windows Forms Security](/dotnet/desktop/winforms/windows-forms-security)  
 Discusses how to secure Windows Forms applications and provides links to related topics.  
  
 [Windows Forms and Unmanaged Applications](/dotnet/desktop/winforms/advanced/windows-forms-and-unmanaged-applications)  
 Describes how to interact with unmanaged applications in a Windows Forms application.  
  
 [ClickOnce Deployment for Windows Forms](/dotnet/desktop/winforms/clickonce-deployment-for-windows-forms)  
 Describes how to use `ClickOnce` deployment in a Windows Forms application and discusses the security implications.  
  
## ASP.NET and XML Web Services  

 ASP.NET applications generally need to restrict access to some portions of the Web site and provide other mechanisms for data protection and site security. These links provide useful information for securing your ASP.NET application.  
  
 An XML Web service provides data that can be consumed by an ASP.NET application, a Windows Forms application, or another Web service. You need to manage security for the Web service itself as well as security for the client application.  
  
 For more information, see the following resources.  
  
|Resource|Description|  
|--------------|-----------------|  
|[Securing ASP.NET Web Sites](/previous-versions/aspnet/91f66yxt(v=vs.100))|Discusses how to secure ASP.NET applications.|  
|[Securing XML Web Services Created Using ASP.NET](/previous-versions/dotnet/netframework-4.0/w67h0dw7(v=vs.100))|Discusses how to implement security for an ASP.NET Web Service.|  
|[Script Exploits Overview](/previous-versions/aspnet/w1sw53ds(v=vs.100))|Discusses how to guard against a script exploit attack, which attempts to insert malicious characters into a Web page.|  
|[Basic Security Practices for Web Applications](/previous-versions/aspnet/zdh19h94(v=vs.100))|General security information and links to further discussion,|  
  
## Remoting  

 .NET remoting enables you to build widely distributed applications easily, whether the application components are all on one computer or spread out across the entire world. You can build client applications that use objects in other processes on the same computer or on any other computer that is reachable over its network. You can also use .NET remoting to communicate with other application domains in the same process.  
  
|Resource|Description|  
|--------------|-----------------|  
|[Configuration of Remote Applications](/previous-versions/dotnet/netframework-4.0/b8tysty8(v=vs.100))|Discusses how to configure remoting applications in order to avoid common problems.|  
|[Security in Remoting](/previous-versions/dotnet/netframework-4.0/9hwst9th(v=vs.100))|Describes authentication and encryption as well as additional security topics relevant to remoting.|  
|[Security and Remoting Considerations](/previous-versions/dotnet/framework/code-access-security/security-and-remoting-considerations)|Describes security issues with protected objects and application domain crossing.|  
  
## See also

- [Securing ADO.NET Applications](securing-ado-net-applications.md)
- [Recommendations for Data Access Strategies](/previous-versions/visualstudio/visual-studio-2008/8fxztkff(v=vs.90))
- [Securing Applications](/visualstudio/ide/securing-applications)
- [Protecting Connection Information](protecting-connection-information.md)
- [ADO.NET Overview](ado-net-overview.md)
