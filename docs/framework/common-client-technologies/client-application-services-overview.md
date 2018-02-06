---
title: "Client Application Services Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "client application services, classes"
  - "client application services, about client application services"
ms.assetid: f0a2da13-e282-4fd7-88a1-f9102c9aeab1
caps.latest.revision: 25
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Client Application Services Overview
Client application services provide simplified access to [!INCLUDE[ajax_current_short](../../../includes/ajax-current-short-md.md)] login, roles, and profile services from Windows Forms and Windows Presentation Foundation (WPF) applications. [!INCLUDE[ajax_current_short](../../../includes/ajax-current-short-md.md)] application services are included in the Microsoft ASP.NET 2.0 AJAX Extensions, which is included with [!INCLUDE[vs_orcas_long](../../../includes/vs-orcas-long-md.md)] and the [!INCLUDE[net_v35_long](../../../includes/net-v35-long-md.md)]. These services enable multiple Web and Windows-based applications to share user information and user-management functionality from a single server.  
  
 Client application services include client service providers that plug into the Web services extensibility model to enable the following features for Windows-based applications:  
  
-   Simple client configuration. You can enable and configure the login, roles, and profile services by using the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] project designer or by specifying client service providers in your project's App.config file. For more information, see [How to: Configure Client Application Services](../../../docs/framework/common-client-technologies/how-to-configure-client-application-services.md).  
  
-   Simple programmability. After you have enabled and configured client application services, you can access the service providers indirectly through existing [!INCLUDE[dnprdnlong](../../../includes/dnprdnlong-md.md)] membership, roles, and application settings classes. You can also directly access the [!INCLUDE[net_v35_long](../../../includes/net-v35-long-md.md)] classes that implement client application services. However, in most cases, direct access is unnecessary. For more information about the client application services classes, see the "Client Application Services Classes" section of this topic.  
  
-   Offline support. Windows-based applications often have to operate in occasionally connected environments. When your application is online, the client service providers will cache values retrieved from the server for use when the application is offline.  
  
-   Integration with the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] application settings designer. When you add settings to your project in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], you can specify which settings are to be accessed through the client settings service provider.  
  
 The following sections describe these features in more detail. For more information about the [!INCLUDE[ajax_current_short](../../../includes/ajax-current-short-md.md)] application services, see [ASP.NET Application Services Overview](http://msdn.microsoft.com/library/1162e529-0d70-44b2-b3ab-83e60c695013).  
  
## Authentication  
 You can use client application services to validate a user through an existing [!INCLUDE[ajax_current_short](../../../includes/ajax-current-short-md.md)] authentication service. You can validate a user by using Windows or forms authentication. Windows authentication means that the user identity is the one supplied by the operating system when a user logs on to a computer or domain. You will typically use Windows authentication with an application deployed on a corporate intranet. Forms authentication means that you must include login controls in your application and pass the acquired credentials to the authentication provider. You will typically use forms authentication with an application deployed on the Internet.  
  
 To validate a user, you call the `static` <xref:System.Web.Security.Membership.ValidateUser%2A?displayProperty=nameWithType> method. This method accesses the client service provider configured for your application and returns a <xref:System.Boolean> value indicating whether the user is valid. For more information, see [How to: Implement User Login with Client Application Services](../../../docs/framework/common-client-technologies/how-to-implement-user-login-with-client-application-services.md).  
  
 When using Windows authentication, you must pass empty strings or `null` as the parameters of the <xref:System.Web.Security.Membership.ValidateUser%2A> method. When using Windows authentication, this method call will always return `true`.  
  
 With forms authentication, the <xref:System.Web.Security.Membership.ValidateUser%2A> method will return a value indicating whether the remote service has authenticated the user. If validation is successful, an authentication cookie is stored on the local hard disk. This cookie is used to confirm validation when accessing the roles and settings services.  
  
 When using forms authentication, you can pass a user name and password to the <xref:System.Web.Security.Membership.ValidateUser%2A> method. You can also pass empty strings or `null` as the parameters to use a credentials provider. A credentials provider is a class that you provide and specify in your application configuration. A credentials provider class must implement the <xref:System.Web.ClientServices.Providers.IClientFormsAuthenticationCredentialsProvider> interface, which has a single method named <xref:System.Web.ClientServices.Providers.IClientFormsAuthenticationCredentialsProvider.GetCredentials%2A>. Using a credentials provider enables you to share a single login dialog box among multiple applications. For more information, see [How to: Configure Client Application Services](../../../docs/framework/common-client-technologies/how-to-configure-client-application-services.md).  
  
 When you configure your application to use a credentials provider with forms authentication, you must pass empty strings or `null` as the parameters of the <xref:System.Web.Security.Membership.ValidateUser%2A> method. The service provider will then call your <xref:System.Web.ClientServices.Providers.IClientFormsAuthenticationCredentialsProvider.GetCredentials%2A?displayProperty=nameWithType> method implementation. Typically, you will implement this method to display a dialog box and return a populated <xref:System.Web.ClientServices.Providers.ClientFormsAuthenticationCredentials> object.  
  
 For more information about authentication, see [ASP.NET Authentication](http://msdn.microsoft.com/library/fc10b0ef-4ce4-4a7f-9174-886325221ee1). For information about how to set up the [!INCLUDE[ajax_current_short](../../../includes/ajax-current-short-md.md)] authentication service, see [Using Forms Authentication with Microsoft Ajax](http://msdn.microsoft.com/library/c50f7dc5-323c-4c63-b4f3-96edfc1e815e).  
  
## Roles  
 You can use client application services to retrieve role information from an existing [!INCLUDE[ajax_current_short](../../../includes/ajax-current-short-md.md)] roles service. To determine whether the current, authenticated user is in a particular role, you call the <xref:System.Security.Principal.IPrincipal.IsInRole%2A> method of the <xref:System.Security.Principal.IPrincipal> reference retrieved from the `static` <xref:System.Threading.Thread.CurrentPrincipal%2A?displayProperty=nameWithType> property. The <xref:System.Security.Principal.IPrincipal.IsInRole%2A> method takes the role name as a parameter and returns a <xref:System.Boolean> value indicating whether the current user is in the specified role. This method will return `false` if the user is not authenticated or is not in the specified role.  
  
 For information about how to set up the [!INCLUDE[ajax_current_short](../../../includes/ajax-current-short-md.md)] roles service, see [Using Roles Information with Microsoft Ajax](http://msdn.microsoft.com/library/280f6ad9-ba1a-4fc9-b0cc-22e39e54a82d).  
  
## Settings  
 You can use client application services to retrieve user application settings from an existing [!INCLUDE[ajax_current_short](../../../includes/ajax-current-short-md.md)] profile service. The client application services Web settings feature integrates with the application settings feature provided in [!INCLUDE[dnprdnlong](../../../includes/dnprdnlong-md.md)]. To retrieve Web settings, first generate a `Settings` class (accessed as `Properties.Settings.Default` in C# and `My.Settings` in [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)]) for your project by using the **Settings** tab of the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] project designer. On the **Settings** tab, you can use the **Load Web Settings** button to retrieve Web settings and add them to the generated `Settings` class. You can use Web settings configured for use by all authenticated users or by all anonymous users.  
  
 For more information about application settings, see [Application Settings Overview](../../../docs/framework/winforms/advanced/application-settings-overview.md). For information about how to implement your own settings class instead of generating one in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], see [How to: Create Application Settings](../../../docs/framework/winforms/advanced/how-to-create-application-settings.md). For information about how to set up the [!INCLUDE[ajax_current_short](../../../includes/ajax-current-short-md.md)] profile service, see [Using Profile Information with Microsoft Ajax](http://msdn.microsoft.com/library/91239ae6-d01c-4f4e-a433-eb9040dbed61).  
  
## Client Application Services Classes  
 The following table describes the classes that implement the client application services feature.  
  
 Applications that use only the primary authentication, roles, and settings features will not have to access these classes directly. Instead, such applications will access the client application service providers indirectly using application configuration and the APIs described in the previous sections. You will access these classes directly to implement additional features, such as user logout and offline capability.  
  
> [!NOTE]
>  All client application services APIs are synchronous. Client application services do not directly support asynchronous behavior.  
  
 The client application service providers implement or extend standard [!INCLUDE[dnprdnlong](../../../includes/dnprdnlong-md.md)] types, but do not implement every member and feature defined by these types. For example, you cannot use the client application service providers to implement a user-management application for creating new users and managing role membership. To implement this functionality, you must currently use a Web application and server-side code. To determine which members are not implemented, see the reference documentation, which you can access from the links in this table.  
  
|Class|Description|  
|-----------|-----------------|  
|<xref:System.Web.ClientServices.ClientFormsIdentity>|This class manages the user identity and authentication cookies for forms authentication.<br /><br /> The primary reason to access this class directly is to call the <xref:System.Web.ClientServices.ClientFormsIdentity.RevalidateUser%2A> method, which silently revalidates a user (for example, when switching from offline to online mode).<br /><br /> After the user is authenticated using forms authentication, you can retrieve an instance of this class through the <xref:System.Security.Principal.IPrincipal.Identity%2A> property of the <xref:System.Security.Principal.IPrincipal> reference retrieved through the `static` <xref:System.Threading.Thread.CurrentPrincipal%2A?displayProperty=nameWithType> property.|  
|<xref:System.Web.ClientServices.ClientRolePrincipal>|This class manages the user roles.<br /><br /> This class does not have any members that cannot be accessed indirectly. However, after the user is authenticated, you can access an instance of this class through the `static` <xref:System.Threading.Thread.CurrentPrincipal%2A?displayProperty=nameWithType> property.|  
|<xref:System.Web.ClientServices.ConnectivityStatus>|This class provides the `static` <xref:System.Web.ClientServices.ConnectivityStatus.IsOffline%2A> property that you use to switch your application to offline mode.|  
|<xref:System.Web.ClientServices.Providers.ClientFormsAuthenticationCredentials>|This class represents user credentials.<br /><br /> You will use this class only as the return value type of the <xref:System.Web.ClientServices.Providers.IClientFormsAuthenticationCredentialsProvider.GetCredentials%2A> method when you implement the <xref:System.Web.ClientServices.Providers.IClientFormsAuthenticationCredentialsProvider> interface.|  
|<xref:System.Web.ClientServices.Providers.ClientFormsAuthenticationMembershipProvider>|This class manages access to the remote authentication service for forms authentication.<br /><br /> The primary reason to access this class directly is to use its <xref:System.Web.ClientServices.Providers.ClientFormsAuthenticationMembershipProvider.Logout%2A> and <xref:System.Web.ClientServices.Providers.ClientFormsAuthenticationMembershipProvider.UserValidated> members, which are not implemented by the base <xref:System.Web.Security.MembershipProvider> class. You can also set the service location programmatically by using the <xref:System.Web.ClientServices.Providers.ClientFormsAuthenticationMembershipProvider.ServiceUri%2A> property.<br /><br /> You can retrieve an instance of this class through the `static` <xref:System.Web.Security.Membership.Provider%2A?displayProperty=nameWithType> property.|  
|<xref:System.Web.ClientServices.Providers.ClientWindowsAuthenticationMembershipProvider>|This class manages Windows authentication.<br /><br /> The primary reason to access this class directly is to call its <xref:System.Web.ClientServices.Providers.ClientWindowsAuthenticationMembershipProvider.Logout%2A> method. After logout, the user will still be authenticated for Windows, but will be unable to access the remote application services.<br /><br /> You can retrieve an instance of this class through the `static` <xref:System.Web.Security.Membership.Provider%2A?displayProperty=nameWithType> property.|  
|<xref:System.Web.ClientServices.Providers.ClientRoleProvider>|This class manages access to the remote roles service.<br /><br /> The primary reason to access this class is to call its <xref:System.Web.ClientServices.Providers.ClientRoleProvider.ResetCache%2A> method. This can be useful if your application is configured to use a non-zero role service cache time-out value. For more information, see [How to: Configure Client Application Services](../../../docs/framework/common-client-technologies/how-to-configure-client-application-services.md). You can also set the service location programmatically by using the <xref:System.Web.ClientServices.Providers.ClientRoleProvider.ServiceUri%2A> property.<br /><br /> You can retrieve an instance of this class through the `static` <xref:System.Web.Security.Roles.Provider%2A?displayProperty=nameWithType> property.|  
|<xref:System.Web.ClientServices.Providers.ClientSettingsProvider>|This class manages access to the remote Web settings service.<br /><br /> The primary reason to access this class is to handle the <xref:System.Web.ClientServices.Providers.ClientSettingsProvider.SettingsSaved> event. You can also set the service location programmatically by using the <xref:System.Web.ClientServices.Providers.ClientSettingsProvider.ServiceUri%2A> property.|  
|<xref:System.Web.ClientServices.Providers.IClientFormsAuthenticationCredentialsProvider>|This interface provides an indirect way for your application to acquire user credentials for validation, as described earlier in the Authentication section of this topic. For more information, see [How to: Configure Client Application Services](../../../docs/framework/common-client-technologies/how-to-configure-client-application-services.md).|  
|<xref:System.Web.ClientServices.Providers.SettingsSavedEventArgs>|This class provides a <xref:System.Web.ClientServices.Providers.SettingsSavedEventArgs.FailedSettingsList%2A> property for use within a <xref:System.Web.ClientServices.Providers.ClientSettingsProvider.SettingsSaved?displayProperty=nameWithType> event handler.|  
|<xref:System.Web.ClientServices.Providers.UserValidatedEventArgs>|This class provides a <xref:System.Web.ClientServices.Providers.UserValidatedEventArgs.UserName%2A> property for use within a <xref:System.Web.ClientServices.Providers.ClientFormsAuthenticationMembershipProvider.UserValidated> event handler.|  
  
## See Also  
 [Client Application Services](../../../docs/framework/common-client-technologies/client-application-services.md)  
 [How to: Configure Client Application Services](../../../docs/framework/common-client-technologies/how-to-configure-client-application-services.md)  
 [How to: Implement User Login with Client Application Services](../../../docs/framework/common-client-technologies/how-to-implement-user-login-with-client-application-services.md)  
 [Walkthrough: Using Client Application Services](../../../docs/framework/common-client-technologies/walkthrough-using-client-application-services.md)  
 [Application Settings Overview](../../../docs/framework/winforms/advanced/application-settings-overview.md)  
 [ASP.NET Application Services Overview](http://msdn.microsoft.com/library/1162e529-0d70-44b2-b3ab-83e60c695013)  
 [Using Forms Authentication with Microsoft Ajax](http://msdn.microsoft.com/library/c50f7dc5-323c-4c63-b4f3-96edfc1e815e)  
 [Using Roles Information with Microsoft Ajax](http://msdn.microsoft.com/library/280f6ad9-ba1a-4fc9-b0cc-22e39e54a82d)  
 [Using Profile Information with Microsoft Ajax](http://msdn.microsoft.com/library/91239ae6-d01c-4f4e-a433-eb9040dbed61)  
 [ASP.NET Authentication](http://msdn.microsoft.com/library/fc10b0ef-4ce4-4a7f-9174-886325221ee1)  
 [Managing Authorization Using Roles](http://msdn.microsoft.com/library/01954ce4-39a2-487f-8153-a69f6f6f3195)  
 [Creating and Configuring the Application Services Database for SQL Server](http://msdn.microsoft.com/library/ab894e83-7e2f-4af8-a116-b1bff8f815b2)
