---
title: "How to: Create a Custom Reliable Session Binding with HTTPS"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fa772232-da1f-4c66-8c94-e36c0584b549
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# How to: Create a Custom Reliable Session Binding with HTTPS

This topic demonstrates the use of Secure Sockets Layer (SSL) transport security with reliable sessions. To use a reliable session over HTTPS, you must create a custom binding that uses a reliable session and the HTTPS transport. You enable the reliable session either imperatively by using code or declaratively in the configuration file. This procedure uses the client and service configuration files to enable the reliable session and the [**\<httpsTransport>**](../../../../docs/framework/configure-apps/file-schema/wcf/httpstransport.md) element.

The key part of this procedure is that the **\<endpoint>** configuration element contain a `bindingConfiguration` attribute that references a custom binding configuration named `reliableSessionOverHttps`. The [**\<binding>**](../../../../docs/framework/misc/binding.md) configuration element references this name to specify that a reliable session and the HTTPS transport are used by including **\<reliableSession>** and **\<httpsTransport>** elements.

For the source copy of this example, see [Custom Binding Reliable Session over HTTPS](../../../../docs/framework/wcf/samples/custom-binding-reliable-session-over-https.md).

### Configure the service with a CustomBinding to use a reliable session with HTTPS

1. Define a service contract for the type of service.

   [!code-csharp[c_HowTo_CreateReliableSessionHTTPS#1121](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_createreliablesessionhttps/cs/service.cs#1121)]

1. Implement the service contract in a service class. Note that the address or binding information isn't specified inside the implementation of the service. You aren't required to write code to retrieve the address or binding information from the configuration file.

   [!code-csharp[c_HowTo_CreateReliableSessionHTTPS#1122](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_createreliablesessionhttps/cs/service.cs#1122)]

1. Create a *Web.config* file to configure an endpoint for the `CalculatorService` with a custom binding named `reliableSessionOverHttps` that uses a reliable session and the HTTPS transport.

   [!code-xml[c_HowTo_CreateReliableSessionHTTPS#2111](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_createreliablesessionhttps/common/web.config#2111)]

1. Create a *Service.svc* file that contains the line:

   ```
   <%@ServiceHost language=c# Service="CalculatorService" %>
   ```

1. Place the *Service.svc* file in your Internet Information Services (IIS) virtual directory.

### Configure the client with a CustomBinding to use a reliable session with HTTPS

1. Use the [ServiceModel Metadata Utility Tool (*Svcutil.exe*)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) from the command line to generate code from service metadata.

   ```console
   Svcutil.exe <Metadata Exchange (MEX) address or HTTP GET address>
   ```

1. The client that's generated contains the `ICalculator` interface that defines the service contract that the client implementation must satisfy.

   [!code-csharp[C_HowTo_CreateReliableSessionHTTPS#1221](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_createreliablesessionhttps/cs/client.cs#1221)]

1. The generated client application also contains the implementation of the `ClientCalculator`. Note that the address and binding information isn't specified inside the implementation of the service. You aren't required to write code to retrieve the address and binding information from the configuration file.

   [!code-csharp[C_HowTo_CreateReliableSessionHTTPS#1222](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_createreliablesessionhttps/cs/client.cs#1222)]

1. Configure a custom binding named `reliableSessionOverHttps` to use the HTTPS transport and reliable sessions.

   [!code-xml[C_HowTo_CreateReliableSessionHTTPS#2211](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_createreliablesessionhttps/common/app.config#2211)]

1. Create an instance of the `ClientCalculator` in an application and then call the service operations.

   [!code-csharp[C_HowTo_CreateReliableSessionHTTPS#1223](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_createreliablesessionhttps/cs/client.cs#1223)]

1. Compile and run the client.  

## .NET Framework security

Because the certificate used in this sample is a test certificate created with *Makecert.exe*, a security alert appears when you try to access an HTTPS address, such as `https://localhost/servicemodelsamples/service.svc`, from your browser.

## See also

[Reliable Sessions](../../../../docs/framework/wcf/feature-details/reliable-sessions.md)
