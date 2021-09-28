---
description: "Learn more about: How to: Use the ASP.NET Role Provider with a Service"
title: "How to: Use the ASP.NET Role Provider with a Service"
ms.date: "03/30/2017"
ms.assetid: 88d33a81-8ac7-48de-978c-5c5b1257951e
---
# How to: Use the ASP.NET Role Provider with a Service

The ASP.NET role provider (in conjunction with the ASP.NET membership provider) is a feature that enables ASP.NET developers to create Web sites that allow users to create an account with a site and to be assigned roles for authorization purposes. With this feature, any user can establish an account with the site, and log in for exclusive access to the site and its services. This is in contrast to Windows security, which requires users to have accounts in a Windows domain. Instead, any user who supplies their credentials (the user name/password combination) can use the site and its services.  
  
For a sample application, see [Membership and Role Provider](../samples/membership-and-role-provider.md). For more information about the ASP.NET membership provider feature, see [How to: Use the ASP.NET Membership Provider](how-to-use-the-aspnet-membership-provider.md).  
  
The role provider feature uses a SQL Server database to store user information. Windows Communication Foundation (WCF) developers can take advantage of these features for security purposes. When integrated into a WCF application, users must supply a user name/password combination to the WCF client application. To enable WCF to use the database, you must create an instance of the <xref:System.ServiceModel.Description.ServiceAuthorizationBehavior> class, set its <xref:System.ServiceModel.Description.ServiceAuthorizationBehavior.PrincipalPermissionMode%2A> property to <xref:System.ServiceModel.Description.PrincipalPermissionMode.UseAspNetRoles>, and add the instance to the collection of behaviors to the <xref:System.ServiceModel.ServiceHost> that is hosting the service.  
  
## Configure the role provider  
  
1. In the Web.config file, under the <`system.web`> element, add a <`roleManager`> element and set its `enabled` attribute to `true`.  
  
2. Set the `defaultProvider` attribute to `SqlRoleProvider`.  
  
3. As a child to the <`roleManager`> element, add a <`providers`> element.  
  
4. As a child to the <`providers`> element, add an <`add`> element with the following attributes set to appropriate values: `name`, `type`, `connectionStringName`, and `applicationName`, as shown in the following example.  
  
    ```xml  
    <!-- Configure the Sql Role Provider. -->  
    <roleManager enabled ="true"
     defaultProvider ="SqlRoleProvider" >  
       <providers>  
         <add name ="SqlRoleProvider"
           type="System.Web.Security.SqlRoleProvider"
           connectionStringName="SqlConn"
           applicationName="MembershipAndRoleProviderSample"/>  
       </providers>  
    </roleManager>  
    ```  
  
## Configure the service to use the role provider  
  
1. In the Web.config file, add a [\<system.serviceModel>](../../configure-apps/file-schema/wcf/system-servicemodel.md) element.  
  
2. Add a [\<behaviors>](../../configure-apps/file-schema/wcf/behaviors.md) element to the <`system.ServiceModel`> element.  
  
3. Add a [\<serviceBehaviors>](../../configure-apps/file-schema/wcf/servicebehaviors.md) to the <`behaviors`> element.  
  
4. Add a [\<behavior>](../../configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md) element and set the `name` attribute to an appropriate value.  
  
5. Add a [\<serviceAuthorization>](../../configure-apps/file-schema/wcf/serviceauthorization-element.md) to the <`behavior`> element.  
  
6. Set the `principalPermissionMode` attribute to `UseAspNetRoles`.  
  
7. Set the `roleProviderName` attribute to `SqlRoleProvider`. The following example shows a fragment of the configuration.  
  
    ```xml  
    <behaviors>  
     <serviceBehaviors>  
      <behavior name="CalculatorServiceBehavior">  
       <serviceAuthorization principalPermissionMode ="UseAspNetRoles"  
                             roleProviderName ="SqlRoleProvider" />  
      </behavior>  
     </serviceBehaviors>  
    </behaviors>  
    ```  
  
## See also

- [Membership and Role Provider](../samples/membership-and-role-provider.md)
- [How to: Use the ASP.NET Membership Provider](how-to-use-the-aspnet-membership-provider.md)
