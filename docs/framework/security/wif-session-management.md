---
title: "WIF Session Management"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 98bce126-18a9-401b-b20d-67ee462a5f8a
caps.latest.revision: 7
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# WIF Session Management
When a client first tries to access a protected resource that is hosted by a relying party, the client must first authenticate itself to a security token service (STS) that is trusted by the relying party. The STS then issues a security token to the client. The client presents this token to the relying party, which then grants the client access to the protected resource. However, you don’t want the client to have to re-authenticate to the STS for each request, especially because it might not even be on the same computer or in the same domain as the relying party. Instead, Windows Identity Foundation (WIF) has the client and relying party establish a session in which the client uses a session security token to authenticate itself to the relying party for all requests after the first request. The relying party can use this session security token, which is stored inside a cookie, to reconstruct the client’s <xref:System.Security.Claims.ClaimsPrincipal?displayProperty=nameWithType>.  
  
 The STS defines what authentication the client must provide. However, the client might have multiple credentials with which it can authenticate itself to the STS. For example, it might have a token from Windows Live, a user name and password, a certificate, and a smartkey. In that case, the STS grants the client several identities, with each identity corresponding to one of the credentials that the client presents. The relying party can use one or more of these identities when it decides what level of access to grant the client.  
  
 The <xref:System.IdentityModel.Tokens.SessionSecurityToken?displayProperty=nameWithType> is used to reconstruct the client’s <xref:System.Security.Claims.ClaimsPrincipal?displayProperty=nameWithType>, which contains all of the client’s identities in <xref:System.Security.Claims.ClaimsPrincipal.Identities%2A>. Each <xref:System.Security.Claims.ClaimsIdentity?displayProperty=nameWithType> in the collection contains the bootstrap tokens that are associated with that identity.  
  
 If a new session token is issued with the session ID of the original session token, <xref:System.IdentityModel.Tokens.SessionSecurityTokenHandler?displayProperty=nameWithType> does not update the session token in the token cache. You should always instantiate a session token with a unique session ID.  
  
> [!NOTE]
>  Session.SecurityTokenHandler.ReadToken throws a <xref:System.Xml.XmlException> exception if it receives invalid input; for example, if the cookie that contains the session token is corrupted. We recommend that you catch this exception and provide application-specific behavior.  
  
 If a protected Web page contains lots of resources (such as small graphics) that are also in the protected domain, the client must re-authenticate itself to the relying party to download each of those resources. Use of a session authentication token avoids the need to authenticate to the STS for each request, but it still means that many cookies are being sent over. You might want to set up the Web page so that the important data and resources are stored in the protected domain while minor items are stored in an unprotected domain and linked to from the main Web page. Also, set the cookie path to reference only the protected domain.  
  
 To operate in reference mode, Microsoft recommends providing a handler for the <xref:System.IdentityModel.Services.WSFederationAuthenticationModule.SessionSecurityTokenCreated> event in the **global.asax.cs** file and setting the **IsReferenceMode** property on the token passed in the <xref:System.IdentityModel.Services.SessionSecurityTokenCreatedEventArgs.SessionToken%2A> property. These updates will ensure that the session token operates in reference mode for every request and is favored over merely setting the  <xref:System.IdentityModel.Services.SessionAuthenticationModule.IsReferenceMode%2A> property on the Session Authentication Module.  
  
## Extensibility  
 You can extend the session management mechanism. One reason for this would be to improve the performance. For example, you could create a custom cookie handler that transforms or optimizes the session security token between its in-memory state and what goes into the cookie. To do so, you can configure the <xref:System.IdentityModel.Services.SessionAuthenticationModule.CookieHandler%2A?displayProperty=nameWithType> property of the <xref:System.IdentityModel.Services.SessionAuthenticationModule?displayProperty=nameWithType> to use a custom cookie handler that derives from <xref:System.IdentityModel.Services.CookieHandler?displayProperty=nameWithType>. <xref:System.IdentityModel.Services.ChunkedCookieHandler?displayProperty=nameWithType> is the default cookie handler because the cookies exceed the allowable size for Hypertext Transfer Protocol (HTTP); if you use a custom cookie handler instead, you must implement chunking.  
  
 For more information, see [ClaimsAwareWebFarm](http://go.microsoft.com/fwlink/?LinkID=248408) (http://go.microsoft.com/fwlink/?LinkID=248408) sample. This sample shows a farm ready session cache (as opposed to a tokenreplycache) so that you can use sessions by reference instead of exchanging big cookies; this sample also demonstrates an easier way of securing cookies in a farm. The session cache is WCF-based. With regard to session securing, the sample demonstrates a new capability in WIF 4.5 of a cookie transform based on MachineKey, which can be activated by simply pasting the appropriate snippet in the web.config. The sample itself is not "farmed", but it demonstrates what you need for making your app farm-ready.
