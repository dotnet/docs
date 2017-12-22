---
title: "Discovery Security Sample"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b8db01f4-b4a1-43fe-8e31-26d4e9304a65
caps.latest.revision: 13
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Discovery Security Sample
The Discovery specification does not require that endpoints that participate in the discovery process to be secure. Enhancing the discovery messages with security mitigates various types of attacks (message alteration, denial of service, replay, spoofing). This sample implements custom channels that compute and verify message signatures using the compact signature format (described in Section 8.2 of the WS-Discovery specification). The sample supports both the [2005 Discovery specification](http://go.microsoft.com/fwlink/?LinkId=177912) and the [1.1 version](http://go.microsoft.com/fwlink/?LinkId=179677).  
  
 The custom channel is applied on top of the existing channel stack for Discovery and Announcement endpoints. This way, a signature header is applied for every message sent. The signature is verified on received messages and when it does not match or when the messages do not have a signature, the messages are dropped. To sign and verify messages, the sample uses certificates.  
  
## Discussion  
 WCF is very extensible and allows users the possibility to customize channels as desired. The sample implements a discovery secure binding element that builds secure channels. The secure channels apply and verify message signatures and are applied on top of the current stack.  
  
 The secure binding element builds secure channel factories and channel listeners.  
  
## Secure Channel Factory  
 The secure channel factory creates output or duplex channels that add a compact signature to message headers. To keep messages as small as possible the compact signature format is used. The structure of a compact signature is shown in the following example.  
  
```xml  
<d:Security ... >   
  [<d:Sig Scheme="xs:anyURI"   
         [KeyId="xs:base64Binary"]?  
          Refs="..."  
         [PrefixList]="xs:NMTOKENS"   
          Sig="xs:base64Binary"   
          ... />]?  
  ...   
</d:Security>  
```  
  
> [!NOTE]
>  The `PrefixList` was added in the 2008 Discovery version protocol.  
  
 To compute the signature, the sample determines the expanded signature items. An XML signature (`SignedInfo`) is created, using the `ds` namespace prefix, as required by the WS-Discovery specification. The body and all the headers in discovery and addressing namespaces are referenced in the signature, so they cannot be tampered with. Each referenced element is transformed using the Exclusive Canonicalization (http://www.w3.org/2001/10/xml-exc-c14n# ), and then an SHA-1 digest value is computed (http://www.w3.org/2000/09/xmldsig#sha1 ). Based on all referenced elements and their digest values, the signature value is computed using the RSA algorithm (http://www.w3.org/2000/09/xmldsig#rsa-sha1 ).  
  
 The messages are signed with a client-specified certificate. The store location, name and the certificate subject name must be specified when the binding element is created. The `KeyId` in the compact signature represents the key identifier of the signing token and is the Subject Key Identifier (SKI) of the signing token or (if the SKI does not exist) a SHA-1 hash of the public key of the signing token.  
  
## Secure Channel Listener  
 The secure channel listener creates input or duplex channels that verify the compact signature in received messages. To verify the signature, the `KeyId` specified in the compact signature attached to the message is used to select a certificate from the specified store. If the message does not have a signature or the signature check fails, the messages are dropped. To use the secure binding, the sample defines a factory that creates custom <xref:System.ServiceModel.Discovery.UdpDiscoveryEndpoint> and <xref:System.ServiceModel.Discovery.UdpAnnouncementEndpoint> with the added discovery secure binding element. These secure endpoints can be used in discovery announcement listeners and discoverable services.  
  
## Sample Details  
 The sample includes a library and 4 console applications:  
  
-   **DiscoverySecurityChannels**: A library that exposes the secure binding. The library computes and verifies the compact signature for outgoing/incoming messages.  
  
-   **Service**: A service exposing ICalculatorService contract, self hosted. The service is marked as Discoverable. The user specifies the details of the certificate used to sign messages by specifying the store location and name and the subject name or other unique identifier for the certificate, and the store where the client certificates are located (the certificates used to check signature for incoming messages). Based on these details, a UdpDiscoveryEndpoint with added security is built and used.  
  
-   **Client**: This class tries to discover an ICalculatorService and to call methods on the service. Again, a <xref:System.ServiceModel.Discovery.UdpDiscoveryEndpoint> with added security is built and used to sign and verify the messages.  
  
-   **AnnouncementListener**: A self-hosted service that listens for online and offline announcements and uses the secure announcement endpoint.  
  
> [!NOTE]
>  If Setup.bat is run multiple times, the certificate manager prompts you for choosing a certificate to add, as there are duplicate certificates. In that case, Setup.bat should be aborted and Cleanup.bat should be called, because the duplicates have already been created. Cleanup.bat also prompts you to choose a certificate to delete. Select a certificate from the list and continue executing Cleanup.bat until no certificates are remaining.  
  
#### To use this sample  
  
1.  Execute the Setup.bat script from a Visual Studio command prompt. The sample uses certificates to sign and verify messages. The script creates the certificates using Makecert.exe and then installs them using Certmgr.exe. The script must be run with administrator privileges.  
  
2.  To build and run the sample, open the Security.sln file in Visual Studio and choose **Rebuild All**. Update the solution properties to start multiple projects: select **Start** for all projects except DiscoverySecureChannels. Run the solution normally.  
  
3.  After you are done with the sample, execute the Cleanup.bat script that removes the certificates created for this sample.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Scenario\DiscoveryScenario`  
  
## See Also
