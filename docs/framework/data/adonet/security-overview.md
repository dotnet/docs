---
title: "Security Overview2"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 33e09965-61d5-48cc-9e8c-3b047cc4f194
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Security Overview
Securing an application is an ongoing process. There will never be a point where a developer can guarantee that an application is safe from all attacks, because it is impossible to predict what kinds of future attacks new technologies will bring about. Conversely, just because nobody has yet discovered (or published) security flaws in a system does not mean that none exist or could exist. You need to plan for security during the design phase of the project, as well as plan how security will be maintained over the lifetime of the application.  
  
## Design for Security  
 One of the biggest problems in developing secure applications is that security is often an afterthought, something to implement after a project is code-complete. Not building security into an application at the outset leads to insecure applications because little thought has been given to what makes an application secure.  
  
 Last minute security implementation leads to more bugs, as software breaks under the new restrictions or has to be rewritten to accommodate unanticipated functionality. Every line of revised code contains the possibility of introducing a new bug. For this reason, you should consider security early in the development process so that it can proceed in tandem with the development of new features.  
  
### Threat Modeling  
 You cannot protect a system against attack unless you understand all the potential attacks that it is exposed to. The process of evaluating security threats, called *threat modeling*, is necessary to determine the likelihood and ramifications of security breaches in your ADO.NET application.  
  
 Threat modeling is composed of three high-level steps: understanding the adversary’s view, characterizing the security of the system, and determining threats.  
  
 Threat modeling is an iterative approach to assessing vulnerabilities in your application to find those that are the most dangerous because they expose the most sensitive data. Once you identify the vulnerabilities, you rank them in order of severity and create a prioritized set of countermeasures to counter the threats.  
  
 For more information, see the following resources.  
  
|Resource|Description|  
|--------------|-----------------|  
|The [Threat Modeling](http://go.microsoft.com/fwlink/?LinkId=98353) site on the MSDN Security Developer Center|The resources on this page will help you understand the threat modeling process and build threat models that you can use to secure your own applications|  
  
## The Principle of Least Privilege  
 When you design, build, and deploy your application, you must assume that your application will be attacked. Often these attacks come from malicious code that executes with the permissions of the user running the code. Others can originate with well-intentioned code that has been exploited by an attacker. When planning security, always assume the worst-case scenario will occur.  
  
 One counter-measure you can employ is to try to erect as many walls around your code as possible by running with least privilege. The principle of least privilege says that any given privilege should be granted to the least amount of code necessary for the shortest duration of time that is required to get the job done.  
  
 The best practice for creating secure applications is to start with no permissions at all and then add the narrowest permissions for the particular task being performed. By contrast, starting with all permissions and then denying individual ones leads to insecure applications that are difficult to test and maintain because security holes may exist from unintentionally granting more permissions than required.  
  
 For more information on securing your applications, see the following resources.  
  
|Resource|Description|  
|--------------|-----------------|  
|[Securing Applications](/visualstudio/ide/securing-applications)|Contains links to general security topics. Also contains links to topics for securing distributed applications, Web applications, mobile applications, and desktop applications.|  
  
## Code Access Security (CAS)  
 Code access security (CAS) is a mechanism that helps limit the access that code has to protected resources and operations. In the .NET Framework, CAS performs the following functions:  
  
-   Defines permissions and permission sets that represent the right to access various system resources.  
  
-   Enables administrators to configure security policy by associating sets of permissions with groups of code (code groups).  
  
-   Enables code to request the permissions it requires in order to run, as well as the permissions that would be useful to have, and specifies which permissions the code must never have.  
  
-   Grants permissions to each assembly that is loaded, based on the permissions requested by the code and on the operations permitted by security policy.  
  
-   Enables code to demand that its callers have specific permissions.  
  
-   Enables code to demand that its callers possess a digital signature, thus allowing only callers from a particular organization or site to call the protected code.  
  
-   Enforces restrictions on code at run time by comparing the granted permissions of every caller on the call stack to the permissions that callers must have.  
  
 To minimize the amount of damage that can occur if an attack succeeds, choose a security context for your code that grants access only to the resources it needs to get its work done and no more.  
  
 For more information, see the following resources.  
  
|Resource|Description|  
|--------------|-----------------|  
|[Code Access Security and ADO.NET](../../../../docs/framework/data/adonet/code-access-security.md)|Describes the interactions between code access security, role-based security, and partially trusted environments from the perspective of an ADO.NET application.|  
|[Code Access Security](http://msdn.microsoft.com/library/23a20143-241d-4fe5-9d9f-3933fd594c03)|Contains links to additional topics describing CAS in the .NET Framework.|  
  
## Database Security  
 The principle of least privilege also applies to your data source. Some general guidelines for database security include:  
  
-   Create accounts with the lowest possible privileges.  
  
-   Do not allow users access to administrative accounts just to get code working.  
  
-   Do not return server-side error messages to client applications.  
  
-   Validate all input at both the client and the server.  
  
-   Use parameterized commands and avoid dynamic SQL statements.  
  
-   Enable security auditing and logging for the database you are using so that you are alerted to any security breaches.  
  
 For more information, see the following resources.  
  
|Resource|Description|  
|--------------|-----------------|  
|[SQL Server Security](../../../../docs/framework/data/adonet/sql/sql-server-security.md)|Provides an overview of SQL Server security with application scenarios that provide guidance for creating secure ADO.NET applications that target SQL Server.|  
|[Recommendations for Data Access Strategies](http://msdn.microsoft.com/library/72411f32-d12a-4de8-b961-e54fca7faaf5)|Provides recommendations for accessing data and performing database operations.|  
  
## Security Policy and Administration  
 Improperly administering code access security (CAS) policy can potentially create security weaknesses. Once an application is deployed, techniques for monitoring security should be used and risks evaluated as new threats emerge.  
  
 For more information, see the following resources.  
  
|Resource|Description|  
|--------------|-----------------|  
|[NIB: Security Policy Management](http://msdn.microsoft.com/library/d754e05d-29dc-4d3a-a2c2-95eaaf1b82b9)|Provides information on creating and administering security policy.|  
|[NIB: Security Policy Best Practices](http://msdn.microsoft.com/library/d49bc4d5-efb7-4caa-a2fe-e4d3cec63c05)|Provides links describing how to administer security policy.|  
  
## See Also  
 [Securing ADO.NET Applications](../../../../docs/framework/data/adonet/securing-ado-net-applications.md)  
 [PAVE Security in Native and .NET Framework Code](http://msdn.microsoft.com/library/bd61be84-c143-409a-a75a-44253724f784)  
 [SQL Server Security](../../../../docs/framework/data/adonet/sql/sql-server-security.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
