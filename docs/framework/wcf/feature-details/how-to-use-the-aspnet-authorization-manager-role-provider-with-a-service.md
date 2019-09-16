---
title: "How to: Use the ASP.NET Authorization Manager Role Provider with a Service"
ms.date: "03/30/2017"
ms.assetid: f21deb81-91ef-49ef-94d6-494785143271
---
# How to: Use the ASP.NET Authorization Manager Role Provider with a Service
When ASP.NET hosts a Web service, you can integrate Authorization Manager into the application to provide authorization to the service. Authorization Manager enables an application developer to define individual operations, which can be grouped together to form tasks. An administrator can then authorize roles to perform specific tasks or individual operations. Authorization Manager provides an administration tool as a Microsoft Management Console (MMC) snap-in to manage roles, tasks, operations, and users. Administrators configure an Authorization Manager policy store in an XML file, Active Directory, or in an Active Directory Application Mode (ADAM) store.  
  
 Authorization Manager is Integrated into the application by configuring the Authorization Manager ASP.NET role provider for the ASP.NET application that is hosting the Web service. Like other ASP.NET role providers, the Authorization Manager ASP.NET role provider is configured using the <`providers`> element.  
  
 The following code example is a portion of a configuration file for a Web service that is integrating Authorization Manager into the application.  
  
```xml  
<system.web>  
    <roleManager enabled="true" defaultProvider="AzManRoleProvider">  
      <providers>  
        <add name="AzManRoleProvider"  
             type="System.Web.Security.AuthorizationStoreRoleProvider, System.Web, Version=2.0.0.0, Culture=neutral, publicKeyToken=b03f5f7f11d50a3a"  
             connectionStringName="AzManPolicyStoreConnectionString"   
             applicationName="SecureService"/>  
      </providers>  
    </roleManager>  
</system.web>  
```  
  
 For more information about integrating an ASP.NET role provider with a WCF application, see [How to: Use the ASP.NET Role Provider with a Service](../../../../docs/framework/wcf/feature-details/how-to-use-the-aspnet-role-provider-with-a-service.md). For more information about using Authorization Manager with ASP.NET, see [How to: Use Authorization Manager (AzMan) with ASP.NET 2.0](https://go.microsoft.com/fwlink/?LinkId=71303).  
  
## See also

- [How to: Use the ASP.NET Role Provider with a Service](../../../../docs/framework/wcf/feature-details/how-to-use-the-aspnet-role-provider-with-a-service.md)
