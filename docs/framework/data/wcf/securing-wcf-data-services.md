---
title: "Securing WCF Data Services"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-oob"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "securing application [WCF Data Services]"
  - "WCF Data Services, security"
ms.assetid: 99fc2baa-a040-4549-bc4d-f683d60298af
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Securing WCF Data Services
This topic describes security considerations that are specific to developing, deploying, and running [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] and applications that access services that support the [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)]. You should also follow recommendations for creating secure [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] applications.  
  
 When planning how to secure a [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)]-based [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] service, you must address both authentication, the process of discovering and verifying the identity of a principal, and authorization, the process of determining whether an authenticated principal is allowed to access the requested resources. You should also consider whether to encrypt the message by using SSL.  
  
## Authenticating Client Requests  
 [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] does not implement any kind of authentication of its own, but rather relies on the authentication provisions of the data service host. This means that the service assumes that any request that it receives has already been authenticated by the network host and that the host has correctly identified the principle for the request appropriately via the interfaces provided by [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)]. These authentication options and approaches are detailed in [OData and Authentication series](http://go.microsoft.com/fwlink/?LinkId=200381).  
  
### Authentication Options for a WCF Data Service  
 The following table lists some of the authentication mechanisms that are available to help you authenticate requests to a WCF Data Service.  
  
|Authentication Options|Description|  
|----------------------------|-----------------|  
|Anonymous authentication|When HTTP anonymous authentication is enabled, any principle is able to connect to the data service. Credentials are not required for anonymous access. Use this option only when you want to allow anyone to access the data service.|  
|Basic and digest authentication|Credentials consisting of a user name and password are required for authentication. Supports authentication of non-Windows clients. **Security Note:**  Basic authentication credentials (user name and password) are sent in the clear and can be intercepted. Digest authentication sends a hash based-on the supplied credentials, which makes it more secure than basic authentication. Both are susceptible to man-in-the-middle attacks. When using these authentication methods, you should consider encrypting communication between client and the data service by using the Secure Sockets Layer (SSL). <br /><br /> Microsoft Internet Information Services (IIS) provides an implementation of both basic and digest authentication for HTTP requests in an [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] application. This Windows Authentication Provider implementation enables a .NET Framework client application to supply credentials in the HTTP header of the request to the data service to seamlessly negotiate authentication of a Windows user. For more information, see [Digest Authentication Technical Reference](http://go.microsoft.com/fwlink/?LinkId=200408).<br /><br /> When you want to have your data service use basic authentication based on some custom authentication service and not Windows credentials, you must implement a custom [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] HTTP Module for authentication.<br /><br /> [!INCLUDE[crexample](../../../../includes/crexample-md.md)] how to use a custom basic authentication scheme with [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)], see the post on [Custom Basic Authentication](http://go.microsoft.com/fwlink/?LinkID=200388) in the [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] and authentication series.|  
|Windows authentication|Windows-based credentials are exchanged by using NTLM or Kerberos. This mechanism is more secure than basic or digest authentication, but it requires that the client be a Windows-based application. IIS also provides an implementation of Windows authentication for HTTP requests in an [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] application. For more information, see [ASP.NET Forms Authentication Overview](http://msdn.microsoft.com/library/099c1587-6934-476e-ac95-28f534bc9708).<br /><br /> [!INCLUDE[crexample](../../../../includes/crexample-md.md)] how to use Windows authentication with [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)], see the post on [Windows Authentication](http://go.microsoft.com/fwlink/?LinkID=200384) in the [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] and authentication series.|  
|[!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] forms authentication|Forms authentication lets you authenticate users by using your own code and then maintain an authentication token in a cookie or in the page URL. You authenticate the user name and password of your users using a login form that you create. Unauthenticated requests are redirected to a login page, where the user provides credentials and submits the form. If the application authenticates the request, the system issues a ticket that contains a key for reestablishing the identity for subsequent requests. For more information, see [Forms Authentication Provider](http://msdn.microsoft.com/library/77e21ba2-bad1-4967-a8ec-74942dea7e47). **Security Note:**  By default, the cookie that contains the forms authentication ticket is not secured when you use forms authentication in a [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Web application. You should consider requiring SSL to protect both the authentication ticket and the initial login credentials. <br /><br /> [!INCLUDE[crexample](../../../../includes/crexample-md.md)] how to use forms authentication with [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)], see the post on [Forms Authentication](http://go.microsoft.com/fwlink/?LinkID=200389) in the [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] and authentication series.|  
|Claims-based authentication|In claims-based authentication, the data service relies on a trusted "third-party" identity provider service to authenticate the user. The identity provider positively authenticates the user that is requesting access to data service resources and issues a token that grants access to the requested resources. This token is then presented to the data service, which then grants access to the user based on the trust relationship with the identity service that issued the access token.<br /><br /> The benefit of using a claims-based authentication provider is that they can be used to authenticate various types of clients across trust domains. By employing such a third-party provider, a data service can offload the requirements of maintaining and authenticating users. OAuth 2.0 is a claims-based authentication protocol that is supported by Windows Azure AppFabric Access Control for federated authorization as a service. This protocol supports REST-based services. [!INCLUDE[crexample](../../../../includes/crexample-md.md)] how to use OAuth 2.0 with [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)], see the post on [OData and OAuth](http://go.microsoft.com/fwlink/?LinkId=200514) in the [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] and authentication series.|  
  
<a name="clientAuthentication"></a>   
### Authentication in the Client Library  
 By default, the [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] client library does not supply credentials when making a request to an [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] service. When login credentials are required by the data service to authenticate a user, these credentials can be supplied in a <xref:System.Net.NetworkCredential> accessed from the <xref:System.Data.Services.Client.DataServiceContext.Credentials%2A> property of the <xref:System.Data.Services.Client.DataServiceContext>, as in the following example:  
  
```csharp  
// Set the client authentication credentials.  
context.Credentials =  
    new NetworkCredential(userName, password, domain);  
```  
  
```vb  
' Set the client authentication credentials.  
context.Credentials = _  
    New NetworkCredential(userName, password, domain)  
```  
  
 For more information, see [How to: Specify Client Credentials for a Data Service Request](../../../../docs/framework/data/wcf/specify-client-creds-for-a-data-service-request-wcf.md).  
  
 When the data service requires login credentials that cannot be specified by using a <xref:System.Net.NetworkCredential> object, such as a claims-based token or cookie, you must manually set headers in the HTTP request, usually the `Authorization` and `Cookie` headers. For more information about this kind of authentication scenario, see the post [OData and Authentication: Client-Side Hooks](http://go.microsoft.com/fwlink/?LinkID=200385). For an example of how to set HTTP headers in a request message, see [How to: Set Headers in the Client Request](../../../../docs/framework/data/wcf/how-to-set-headers-in-the-client-request-wcf-data-services.md).  
  
## Impersonation  
 Generally, the data service accesses required resources, such as files on the server or a database, by using the credentials of the worker process that is hosting the data service. When using impersonation, [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] applications can execute with the Windows identity (user account) of the user making the request. Impersonation is commonly used in applications that rely on IIS to authenticate the user, and the credentials of this principle are used to access the required resources. For more information, see [ASP.NET Impersonation](http://msdn.microsoft.com/library/a0cb3024-562f-4184-9d3c-095504787d3d).  
  
## Configuring Data Service Authorization  
 Authorization is the granting of access to application resources to a principle or process that is identified based on a previously successful authentication. As a general practice, you should only grant sufficient rights to users of the data service to perform the operations required by client applications.  
  
### Restrict Access to Data Service Resources  
 By default, [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] enables you to grant common read and write access against data service resources (entity set and service operations) to any user that is able to access the data service. Rules that define read and write access can be defined separately for each entity set exposed by the data service, as well as to any service operations. We recommend limiting both read and write access to only the resources required by the client application. For more information, see [Minimum Resource Access Requirements](../../../../docs/framework/data/wcf/configuring-the-data-service-wcf-data-services.md#accessRequirements).  
  
### Implement Role-Based Interceptors  
 Interceptors enable you to intercept requests against data service resources before they are acted on by the data service. For more information, see [Interceptors](../../../../docs/framework/data/wcf/interceptors-wcf-data-services.md). Interceptors enable you to make authorization decisions based the authenticated user that is making the request. [!INCLUDE[crexample](../../../../includes/crexample-md.md)] how to restrict access to data service resources based on an authenticated user identity, see [How to: Intercept Data Service Messages](../../../../docs/framework/data/wcf/how-to-intercept-data-service-messages-wcf-data-services.md).  
  
### Restrict Access to the Persisted Data Store and Local Resources  
 The accounts that are used to access the persisted store should be granted only enough rights in a database or the file system to support the requirements of the data service. When anonymous authentication is used, this is the account used to run the hosting application. For more information, see [How to: Develop a WCF Data Service Running on IIS](../../../../docs/framework/data/wcf/how-to-develop-a-wcf-data-service-running-on-iis.md). When impersonation is used, authenticated users must be granted access to these resources, usually as part of a Windows group.  
  
## Other Security Considerations  
  
### Secure the Data in the Payload  
 [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] is based on the HTTP protocol. In an HTTP message, the header may contain valuable user credentials, depending on the authentication implemented by the data service. The message body may also contain valuable customer data that must be protected. In both of these cases, we recommend that you use SSL to protect this information over the wire.  
  
### Ignored Message Headers and Cookies  
 HTTP request headers, other than those that declare content types and resource locations, are ignored and are never set by the data service.  
  
 Cookies can be used as part of an authentication scheme, such as with [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Forms Authentication. However, any HTTP cookies set on an incoming request are ignored by [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)]. The host of a data service may process the cookie, but the [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] runtime never analyzes or returns cookies. The [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] client library also does not process cookies sent in the response.  
  
### Custom Hosting Requirements  
 By default, [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] is created as an [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] application hosted in IIS. This enables the data service to leverage the secure behaviors of this platform. You can define [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] that are hosted by a custom host. For more information, see [Hosting the Data Service](../../../../docs/framework/data/wcf/hosting-the-data-service-wcf-data-services.md). The components and platform hosting a data service must ensure the following security behaviors to prevent attacks on the data service:  
  
-   Limit the length of the URI accepted in a data service request for all possible operations.  
  
-   Limit the size of both incoming and outgoing HTTP messages.  
  
-   Limit the total number of outstanding requests at any given time.  
  
-   Limit the size of HTTP headers and their values, and provide [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] access to header data.  
  
-   Detect and counter known attacks, such as TCP SYN and message replay attacks.  
  
### Values Are Not Further Encoded  
 Property values sent to the data service are not further encoded by the [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] runtime. For example, when a string property of an entity contains formatted HTML content, the tags are not HTML encoded by the data service. The data service also does not further encode property values in the response. The client library also does not perform any additional encoding.  
  
### Considerations for Client Applications  
 The following security considerations apply to applications that use the [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] client to access [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] services:  
  
-   The client library assumes that the protocols used to access the data service provide an appropriate level of security.  
  
-   The client library uses all the default values for timeouts and parsing options of the underlying platform-provided transport stacks.  
  
-   The client library does not read any settings from application configuration files.  
  
-   The client library does not implement any cross domain access mechanisms. Instead, it relies on the mechanisms provided by the underlying HTTP stack.  
  
-   The client library has no user interface elements, and it never tries to display or render the data that it receives or sends.  
  
-   We recommend that client applications always validate user input as well as data accepted from untrusted services.  
  
## See Also  
 [Defining WCF Data Services](../../../../docs/framework/data/wcf/defining-wcf-data-services.md)  
 [WCF Data Services Client Library](../../../../docs/framework/data/wcf/wcf-data-services-client-library.md)
