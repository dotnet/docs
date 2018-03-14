---
title: "How to: Implement User Login with Client Application Services"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
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
  - "validating users [client application services]"
  - "validation [.NET Framework], client application services"
  - "client application services, authenticate users"
ms.assetid: 5431a671-eb02-4e18-a651-24764fccec9a
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Implement User Login with Client Application Services
You can use client application services to validate users through an existing [!INCLUDE[ajax_current_short](../../../includes/ajax-current-short-md.md)] profile service. For information about how to set up the [!INCLUDE[ajax_current_short](../../../includes/ajax-current-short-md.md)] profile service, see [Using Forms Authentication with Microsoft Ajax](http://msdn.microsoft.com/library/c50f7dc5-323c-4c63-b4f3-96edfc1e815e).  
  
 The following procedures describe how to validate users through the authentication service when your application is configured to use one of the client authentication service providers. For more information, see [How to: Configure Client Application Services](../../../docs/framework/common-client-technologies/how-to-configure-client-application-services.md).  
  
 You will typically perform all validation through the `static` <xref:System.Web.Security.Membership.ValidateUser%2A?displayProperty=nameWithType> method. This method manages the interaction with the authentication service through the configured authentication provider. For more information, see [Client Application Services Overview](../../../docs/framework/common-client-technologies/client-application-services-overview.md).  
  
 The forms authentication procedures require access to a running [!INCLUDE[ajax_current_short](../../../includes/ajax-current-short-md.md)] authentication service. For guidance on end-to-end testing of client application services features, see [Walkthrough: Using Client Application Services](../../../docs/framework/common-client-technologies/walkthrough-using-client-application-services.md).  
  
### To authenticate a user with forms authentication using a membership credentials provider  
  
1.  Implement the <xref:System.Web.ClientServices.Providers.IClientFormsAuthenticationCredentialsProvider> interface. The following code example shows a <xref:System.Web.ClientServices.Providers.IClientFormsAuthenticationCredentialsProvider.GetCredentials%2A?displayProperty=nameWithType> implementation for a login dialog box class derived from  <xref:System.Windows.Forms.Form?displayProperty=nameWithType>. This dialog box has text boxes for user name and password and a "remember me" check box. When the client authentication provider calls the <xref:System.Web.ClientServices.Providers.IClientFormsAuthenticationCredentialsProvider.GetCredentials%2A> method, the form is displayed. When the user fills in the information in the login dialog box and clicks OK, the specified values are returned in a new <xref:System.Web.ClientServices.Providers.ClientFormsAuthenticationCredentials> object.  
  
     [!code-csharp[ClientApplicationServices#210](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Login.cs#210)]
     [!code-vb[ClientApplicationServices#210](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Login.vb#210)]  
  
2.  Call the `static` <xref:System.Web.Security.Membership.ValidateUser%2A?displayProperty=nameWithType> method and pass in empty strings as the parameter values. When you specify empty strings, this method internally calls the <xref:System.Web.ClientServices.Providers.IClientFormsAuthenticationCredentialsProvider.GetCredentials%2A> method for the credentials provider configured for your application. The following code example calls this method to restrict access to an entire Windows Forms application. You can add this code to a <xref:System.Windows.Forms.Form.Load?displayProperty=nameWithType> handler.  
  
     [!code-csharp[ClientApplicationServices#317](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Class1.cs#317)]
     [!code-vb[ClientApplicationServices#317](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Class1.vb#317)]  
  
### To authenticate a user with forms authentication without using a membership credentials provider  
  
-   Call the `static` <xref:System.Web.Security.Membership.ValidateUser%2A?displayProperty=nameWithType> method and pass in user name and password values retrieved from the user.  
  
     [!code-csharp[ClientApplicationServices#318](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Class1.cs#318)]
     [!code-vb[ClientApplicationServices#318](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Class1.vb#318)]  
  
### To authenticate a user with Windows authentication  
  
-   Call the `static` <xref:System.Web.Security.Membership.ValidateUser%2A?displayProperty=nameWithType> method and pass empty strings for the parameters. This method call will always return `true` and will add a cookie to the user's cookie cache that contains the Windows identity.  
  
     [!code-csharp[ClientApplicationServices#319](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Class1.cs#319)]
     [!code-vb[ClientApplicationServices#319](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Class1.vb#319)]  
  
## Robust Programming  
 The example code in this topic demonstrates the simplest usages of authentication in a Windows client application. When you call the `static` <xref:System.Web.Security.Membership.ValidateUser%2A?displayProperty=nameWithType> method with client application services and forms authentication, however, your code can throw a <xref:System.Net.WebException>. This indicates that the authentication service is unavailable. For an example of how to handle this exception, see [Walkthrough: Using Client Application Services](../../../docs/framework/common-client-technologies/walkthrough-using-client-application-services.md).  
  
## See Also  
 [Client Application Services](../../../docs/framework/common-client-technologies/client-application-services.md)  
 [Client Application Services Overview](../../../docs/framework/common-client-technologies/client-application-services-overview.md)  
 [How to: Configure Client Application Services](../../../docs/framework/common-client-technologies/how-to-configure-client-application-services.md)  
 [Walkthrough: Using Client Application Services](../../../docs/framework/common-client-technologies/walkthrough-using-client-application-services.md)  
 [Using Forms Authentication with Microsoft Ajax](http://msdn.microsoft.com/library/c50f7dc5-323c-4c63-b4f3-96edfc1e815e)
