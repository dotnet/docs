---
title: "Integrated Windows Authentication with Extended Protection"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 81731998-d5e7-49e4-ad38-c8e6d01689d0
caps.latest.revision: 13
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Integrated Windows Authentication with Extended Protection
Enhancements were made that affect how integrated Windows authentication is handled by the <xref:System.Net.HttpWebRequest>, <xref:System.Net.HttpListener>, <xref:System.Net.Mail.SmtpClient>, <xref:System.Net.Security.SslStream>, <xref:System.Net.Security.NegotiateStream>, and related classes in the <xref:System.Net> and related namespaces. Support was added for extended protection to enhance security.  
  
 These changes can affect applications that use these classes to make web requests and receive responses where integrated Windows authentication is used. This change can also impact web servers and client applications that are configured to use integrated Windows authentication.  
  
 These changes can also affect applications that use these classes to make other types of requests and receive responses where integrated Windows authentication is used.  
  
 The changes to support extended protection are available only for applications on Windows 7 and Windows Server 2008 R2. The extended protection features are not available on earlier versions of Windows.  
  
## Overview  
 The design of integrated Windows authentication allows for some credential challenge responses to be universal, meaning they can be re-used or forwarded. The challenge responses should be constructed at a minimum with target specific information and preferably also with some channel specific information. Services can then provide extended protection to ensure that credential challenge responses contain service specific information such as a Service Principal Name (SPN). With this information in the credential exchanges, services are able to better protect against malicious use of credential challenge responses that might have been improperly used.  
  
 The extended protection design is an enhancement to authentication protocols designed to mitigate authentication relay attacks. It revolves around the concept of channel and service binding information.  
  
 The overall objectives are the following:  
  
1.  If the client is updated to support the extended protection, applications should supply a channel binding and service binding information to all supported authentication protocols. Channel binding information can only be supplied when there is a channel (TLS) to bind to. Service binding information should always be supplied.  
  
2.  Updated servers which are properly configured may verify the channel and service binding information when it is present in the client authentication token and reject the authentication attempt if the channel bindings do not match. Depending on the deployment scenario, servers may verify channel binding, service binding or both.  
  
3.  Updated servers have the ability to accept or reject down-level client requests that do not contain the channel binding information based on policy.  
  
 Information used by extended protection consists of one or both of the following two parts:  
  
1.  A Channel Binding Token or CBT.  
  
2.  Service Binding information in the form of a Service Principal Name or SPN.  
  
 Service Binding information is an indication of a client’s intent to authenticate to a particular service endpoint. It is communicated from client to server with the following properties:  
  
-   The SPN value must be available to the server performing client authentication in clear text form.  
  
-   The value of the SPN is public.  
  
-   The SPN must be cryptographically protected in transit such that a man-in-the-middle attack cannot insert, remove or modify its value.  
  
 A CBT is a property of the outer secure channel (such as TLS) used to tie (bind) it to a conversation over an inner, client-authenticated channel. The CBT must have the following properties (also defined by IETF RFC 5056):  
  
-   When an outer channel exists, the value of the CBT must be a property identifying either the outer channel or the server endpoint, independently arrived at by both client and server sides of a conversation.  
  
-   Value of the CBT sent by the client must not be something an attacker can influence.  
  
-   No guarantees are made about secrecy of the CBT value. This does not however mean that the value of the service binding as well as channel binding information can always be examined by any other but the server performing authentication, as the protocol carrying the CBT may be encrypting it.  
  
-   The CBT must be cryptographically integrity protected in transit such that an attacker cannot insert, remove or modify its value.  
  
 Channel binding is accomplished by the client transferring the SPN and the CBT to the server in a tamperproof fashion. The server validates the channel binding information in accordance with its policy and rejects authentication attempts for which it does not believe itself to have been the intended target. This way, the two channels become cryptographically bound together.  
  
 To preserve compatibility with existing clients and applications, a server may be configured to allow authentication attempts by clients that do not yet support extended protection. This is referred to as a "partially hardened" configuration, in contrast to a "fully hardened" configuration.  
  
 Multiple components in the <xref:System.Net> and <xref:System.Net.Security> namespaces perform integrated Windows authentication on behalf of a calling application. This section describes changes to System.Net components to add extended protection in their use of integrated Windows authentication.  
  
 Extended protection is currently supported on Windows 7. A mechanism is provided so an application can determine if the operating system supports extended protection.  
  
## Changes to Support Extended Protection  
 The authentication process used with integrated Windows authentication, depending on the authentication protocol used, often includes a challenge issued by the destination computer and sent back to the client computer. Extended protection adds new features to this authentication process  
  
 The <xref:System.Security.Authentication.ExtendedProtection> namespace provides support for authentication using extended protection for applications. The <xref:System.Security.Authentication.ExtendedProtection.ChannelBinding> class in this namespace represents a channel binding. The <xref:System.Security.Authentication.ExtendedProtection.ExtendedProtectionPolicy> class in this namespace represents the extended protection policy used by the server to validate incoming client connections. Other class members are used with extended protection.  
  
 For server applications, these classes include the following:  
  
 A <xref:System.Security.Authentication.ExtendedProtection.ExtendedProtectionPolicy> that has the following elements:  
  
-   An <xref:System.Security.Authentication.ExtendedProtection.ExtendedProtectionPolicy.OSSupportsExtendedProtection%2A> property that indicates whether the operating system supports integrated windows authentication with extended protection.  
  
-   A <xref:System.Security.Authentication.ExtendedProtection.PolicyEnforcement> value that indicates when the extended protection policy should be enforced.  
  
-   A <xref:System.Security.Authentication.ExtendedProtection.ProtectionScenario> value that indicates the deployment scenario. This influences how extended protection is checked.  
  
-   An optional <xref:System.Security.Authentication.ExtendedProtection.ServiceNameCollection> that contains the custom SPN list that is used to match against the SPN provided by the client as the intended target of the authentication.  
  
-   An optional <xref:System.Security.Authentication.ExtendedProtection.ChannelBinding> that contains a custom channel binding to use for validation. This scenario is not a common case  
  
 The <xref:System.Security.Authentication.ExtendedProtection.Configuration> namespace provides support for configuration of authentication using extended protection for applications.  
  
 A number of feature changes were made to support extended protection in the existing <xref:System.Net> namespace. These changes include the following:  
  
-   A new <xref:System.Net.TransportContext> class added to the <xref:System.Net> namespace that represents a transport context.  
  
-   New <xref:System.Net.HttpWebRequest.EndGetRequestStream%2A> and <xref:System.Net.HttpWebRequest.GetRequestStream%2A> overload methods in the <xref:System.Net.HttpWebRequest> class that allow retrieving the <xref:System.Net.TransportContext> to support extended protection for client applications.  
  
-   Additions to the <xref:System.Net.HttpListener> and <xref:System.Net.HttpListenerRequest> classes to support server applications.  
  
 A feature change was made to support extended protection for SMTP client applications in the existing <xref:System.Net.Mail> namespace:  
  
-   A <xref:System.Net.Mail.SmtpClient.TargetName%2A> property in the <xref:System.Net.Mail.SmtpClient> class that represents the SPN to use for authentication when using extended protection for SMTP client applications.  
  
 A number of feature changes were made to support extended protection in the existing <xref:System.Net.Security> namespace. These changes include the following:  
  
-   New <xref:System.Net.Security.NegotiateStream.BeginAuthenticateAsClient%2A> and <xref:System.Net.Security.NegotiateStream.AuthenticateAsClient%2A> overload methods in the <xref:System.Net.Security.NegotiateStream> class that allow passing a CBT to support extended protection for client applications.  
  
-   New <xref:System.Net.Security.NegotiateStream.BeginAuthenticateAsServer%2A> and <xref:System.Net.Security.NegotiateStream.AuthenticateAsServer%2A> overload methods in the <xref:System.Net.Security.NegotiateStream> class that allow passing an <xref:System.Security.Authentication.ExtendedProtection.ExtendedProtectionPolicy> to support extended protection for server applications.  
  
-   A new <xref:System.Net.Security.SslStream.TransportContext%2A> property in the <xref:System.Net.Security.SslStream> class to support extended protection for client and server applications.  
  
 A <xref:System.Net.Configuration.SmtpNetworkElement> property was added to support configuration of extended protection for SMTP clients in the <xref:System.Net.Security> namespace.  
  
## Extended Protection for Client Applications  
 Extended protection support for most client applications happens automatically. The <xref:System.Net.HttpWebRequest> and <xref:System.Net.Mail.SmtpClient> classes support extended protection whenever the underlying version of Windows supports extended protection. An <xref:System.Net.HttpWebRequest> instance sends an SPN constructed from the <xref:System.Uri>. By default, an <xref:System.Net.Mail.SmtpClient> instance sends an SPN constructed from the host name of the SMTP mail server.  
  
 For custom authentication, client applications can use the <xref:System.Net.HttpWebRequest.EndGetRequestStream%28System.IAsyncResult%2CSystem.Net.TransportContext%40%29?displayProperty=nameWithType> or <xref:System.Net.HttpWebRequest.GetRequestStream%28System.Net.TransportContext%40%29?displayProperty=nameWithType> methods in the <xref:System.Net.HttpWebRequest> class that allow retrieving the <xref:System.Net.TransportContext> and the CBT using the <xref:System.Net.TransportContext.GetChannelBinding%2A> method.  
  
 The SPN to use for integrated Windows authentication sent by an <xref:System.Net.HttpWebRequest> instance to a given service can be overridden by setting the <xref:System.Net.AuthenticationManager.CustomTargetNameDictionary%2A> property.  
  
 The <xref:System.Net.Mail.SmtpClient.TargetName%2A> property can be used to set a custom SPN to use for integrated Windows authentication for the SMTP connection.  
  
## Extended Protection for Server Applications  
 <xref:System.Net.HttpListener> automatically provides mechanisms for validating service bindings when performing HTTP authentication.  
  
 The most secure scenario is to enable extended protection for HTTPS:// prefixes. In this case, set <xref:System.Net.HttpListener.ExtendedProtectionPolicy%2A?displayProperty=nameWithType> to an <xref:System.Security.Authentication.ExtendedProtection.ExtendedProtectionPolicy> with <xref:System.Security.Authentication.ExtendedProtection.PolicyEnforcement> set to <xref:System.Security.Authentication.ExtendedProtection.PolicyEnforcement.WhenSupported> or <xref:System.Security.Authentication.ExtendedProtection.PolicyEnforcement.Always>, and <xref:System.Security.Authentication.ExtendedProtection.ProtectionScenario> set to <xref:System.Security.Authentication.ExtendedProtection.ProtectionScenario.TransportSelected> A value of  <xref:System.Security.Authentication.ExtendedProtection.PolicyEnforcement.WhenSupported> puts <xref:System.Net.HttpListener> in partially hardened mode, while <xref:System.Security.Authentication.ExtendedProtection.PolicyEnforcement.Always> corresponds to fully hardened mode.  
  
 In this configuration when a request is made to the server through an outer secure channel, the outer channel is queried for a channel binding. This channel binding is passed to the authentication SSPI calls, which validate that the channel binding in the authentication blob matches. There are three possible outcomes:  
  
1.  The server’s underlying operating system does not support extended protection. The request will not be exposed to the application, and an unauthorized (401) response will be returned to the client. A message will be logged to the <xref:System.Net.HttpListener> trace source specifying the reason for the failure.  
  
2.  The SSPI call fails indicating that either the client specified a channel binding that did not match the expected value retrieved from the outer channel or the client failed to supply a channel binding when the extended protection policy on the server was configured for <xref:System.Security.Authentication.ExtendedProtection.PolicyEnforcement.Always>. In both cases, the request will not be exposed to the application, and an unauthorized (401) response will be returned to the client. A message will be logged to the <xref:System.Net.HttpListener> trace source specifying the reason for the failure.  
  
3.  The client specifies the correct channel binding or is allowed to connect without specifying a channel binding since the extended protection policy on the server is configured with <xref:System.Security.Authentication.ExtendedProtection.PolicyEnforcement.WhenSupported> The request is returned to the application for processing. No service name check is performed automatically. An application may choose to perform its own service name validation using the <xref:System.Net.HttpListenerRequest.ServiceName%2A> property, but under these circumstances it is redundant.  
  
 If an application makes its own SSPI calls to perform authentication based on blobs passed back and forth within the body of an HTTP request and wishes to support channel binding, it needs to retrieve the expected channel binding from the outer secure channel using <xref:System.Net.HttpListener> in order to pass it to native Win32 [AcceptSecurityContext](http://go.microsoft.com/fwlink/?LinkId=147021) function. To do this, use the <xref:System.Net.HttpListenerRequest.TransportContext%2A> property and call <xref:System.Net.TransportContext.GetChannelBinding%2A> method to retrieve the CBT. Only endpoint bindings are supported. If anything other <xref:System.Security.Authentication.ExtendedProtection.ChannelBindingKind.Endpoint> is specified, a <xref:System.NotSupportedException> will be thrown. If the underlying operating system supports channel binding, the <xref:System.Net.TransportContext.GetChannelBinding%2A> method will return a <xref:System.Security.Authentication.ExtendedProtection.ChannelBinding><xref:System.Runtime.InteropServices.SafeHandle> wrapping a pointer to a channel binding suitable for passing to [AcceptSecurityContext](http://go.microsoft.com/fwlink/?LinkId=147021) function as the pvBuffer member of a SecBuffer structure passed in the `pInput` parameter. The <xref:System.Security.Authentication.ExtendedProtection.ChannelBinding.Size%2A> property contains the length, in bytes, of the channel binding. If the underlying operating system does not support channel bindings, the function will return `null`.  
  
 Another possible scenario is to enable extended protection for HTTP:// prefixes when proxies are not used. In this case, set <xref:System.Net.HttpListener.ExtendedProtectionPolicy%2A?displayProperty=nameWithType> to an <xref:System.Security.Authentication.ExtendedProtection.ExtendedProtectionPolicy> with <xref:System.Security.Authentication.ExtendedProtection.PolicyEnforcement> set to <xref:System.Security.Authentication.ExtendedProtection.PolicyEnforcement.WhenSupported> or <xref:System.Security.Authentication.ExtendedProtection.PolicyEnforcement.Always>, and <xref:System.Security.Authentication.ExtendedProtection.ProtectionScenario> set to <xref:System.Security.Authentication.ExtendedProtection.ProtectionScenario.TransportSelected> A value of  <xref:System.Security.Authentication.ExtendedProtection.PolicyEnforcement.WhenSupported> puts <xref:System.Net.HttpListener> in partially hardened mode, while <xref:System.Security.Authentication.ExtendedProtection.PolicyEnforcement.Always> corresponds to fully hardened mode.  
  
 A default list of allowed service names is created based on the prefixes which have been registered with the <xref:System.Net.HttpListener>. This default list can be examined through the <xref:System.Net.HttpListener.DefaultServiceNames%2A> property. If this list is not comprehensive, an application can specify a custom service name collection in the constructor for the <xref:System.Security.Authentication.ExtendedProtection.ExtendedProtectionPolicy> class which will be used instead of the default service name list.  
  
 In this configuration, when a request is made to the server without an outer secure channel authentication proceeds normally without a channel binding check. If the authentication succeeds, the context is queried for the service name that the client provided and validated against the list of acceptable service names. There are four possible outcomes:  
  
1.  The server’s underlying operating system does not support extended protection. The request will not be exposed to the application, and an unauthorized (401) response will be returned to the client. A message will be logged to the <xref:System.Net.HttpListener> trace source specifying the reason for the failure.  
  
2.  The client’s underlying operating system does not support extended protection. In the <xref:System.Security.Authentication.ExtendedProtection.PolicyEnforcement.WhenSupported> configuration, the authentication attempt will succeed and the request will be returned to the application. In the <xref:System.Security.Authentication.ExtendedProtection.PolicyEnforcement.Always> configuration, the authentication attempt will fail. The request will not be exposed to the application, and an unauthorized (401) response will be returned to the client. A message will be logged to the <xref:System.Net.HttpListener> trace source specifying the reason for the failure.  
  
3.  The client’s underlying operating system supports extended protection, but the application did not specify a service binding. The request will not be exposed to the application, and an unauthorized (401) response will be returned to the client. A message will be logged to the <xref:System.Net.HttpListener> trace source specifying the reason for the failure.  
  
4.  The client specified a service binding. The service binding is compared to the list of allowed service bindings. If it matches, the request is returned to the application. Otherwise, the request will not be exposed to the application, and an unauthorized (401) response will be automatically returned to the client. A message will be logged to the <xref:System.Net.HttpListener> trace source specifying the reason for the failure.  
  
 If this simple approach using an allowed list of acceptable service names is insufficient, an application may provide its own service name validation by querying the <xref:System.Net.HttpListenerRequest.ServiceName%2A> property. In cases 1 and 2 above, the property will return `null`. In case 3, it will return an empty string. In case 4, the service name specified by the client will be returned.  
  
 These extended protection features can also be used by server applications for authentication with other types of requests and when trusted proxies are used.  
  
## See Also  
 <xref:System.Security.Authentication.ExtendedProtection>  
 <xref:System.Security.Authentication.ExtendedProtection.Configuration>
