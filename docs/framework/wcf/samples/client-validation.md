---
title: "Client Validation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f0c1f805-1a81-4d0d-a112-bf5e2e87a631
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Client Validation
Services frequently publish metadata to enable automatic generation and configuration of client proxy types. When the service is not trusted, client applications should validate that the metadata conforms to the client application's policy regarding security, transactions, the type of service contract and so on. The following sample demonstrates how to write a client endpoint behavior that validates the service endpoint to ensure that service endpoint is safe to use.  
  
 The service exposes four service endpoints. The first endpoint uses the WSDualHttpBinding, the second endpoint uses NTLM authentication, the third endpoint enables transaction flow, and the fourth endpoint uses certificate-based authentication.  
  
 The client uses the <xref:System.ServiceModel.Description.MetadataResolver> class to retrieve the metadata for the service. The client enforces a policy of prohibiting duplex bindings, NTLM authentication, and transaction flow using a validating behavior. For each <xref:System.ServiceModel.Description.ServiceEndpoint> instance imported from the service's metadata, the client application adds an instance of the `InternetClientValidatorBehavior` endpoint behavior to the <xref:System.ServiceModel.Description.ServiceEndpoint> before attempting to use a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] client to connect to the endpoint. The behavior's `Validate` method runs before any operations on the service are called and enforces the client's policy by throwing `InvalidOperationExceptions`.  
  
### To build the sample  
  
1.  To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
### To run the sample on the same computer  
  
1.  Open a Visual Studio command prompt with administrator privileges and run Setup.bat from the sample install folder. This installs all the certificates required for running the sample.  
  
2.  Run the service application from \service\bin\Debug.  
  
3.  Run the client application from \client\bin\Debug. Client activity is displayed on the client console application.  
  
4.  If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
5.  Remove the certificates by running Cleanup.bat when you have finished with the sample. Other security samples use the same certificates.  
  
### To run the sample across computers  
  
1.  On the server, in a Visual Studio command prompt run with administrator privileges, type `setup.bat service`. Running `setup.bat` with the `service` argument creates a service certificate with the fully-qualified domain name of the computer and exports the service certificate to a file named Service.cer.  
  
2.  On the server, edit App.config to reflect the new certificate name. That is, change the `findValue` attribute in the [\<serviceCertificate>](../../../../docs/framework/configure-apps/file-schema/wcf/servicecertificate-of-clientcredentials-element.md) element to the fully-qualified domain name of the computer.  
  
3.  Copy the Service.cer file from the service directory to the client directory on the client computer.  
  
4.  On the client, open a Visual Studio command prompt with administrator privileges, and type `setup.bat client`. Running `setup.bat` with the `client` argument creates a client certificate named Client.com and exports the client certificate to a file named Client.cer.  
  
5.  In the client.cs file change the address value of the MEX endpoint and the `findValue` for setting the default server certificate to match the new address of your service. You do this by replacing localhost with the fully-qualified domain name of the server. Rebuild.  
  
6.  Copy the Client.cer file from the client directory to the service directory on the server.  
  
7.  On the client, run ImportServiceCert.bat in a Visual Studio command prompt opened with administrator privileges. This imports the service certificate from the Service.cer file into the CurrentUser - TrustedPeople store.  
  
8.  On the server, run ImportClientCert.bat in a Visual Studio command prompt opened with administrator privileges. This imports the client certificate from the Client.cer file into the LocalMachine - TrustedPeople store.  
  
9. On the service computer, build the service project in Visual Studio and run service.exe.  
  
10. On the client computer, run client.exe.  
  
    1.  If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
### To clean up after the sample  
  
-   Run Cleanup.bat in the samples folder once you have finished running the sample.  
  
    > [!NOTE]
    >  This script does not remove service certificates on a client when running this sample across computers. If you have run [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] samples that use certificates across computers, be sure to clear the service certificates that have been installed in the CurrentUser - TrustedPeople store. To do this, use the following command: `certmgr -del -r CurrentUser -s TrustedPeople -c -n <Fully Qualified Server Machine Name>. For example: certmgr -del -r CurrentUser -s TrustedPeople -c -n server1.contoso.com`.  
  
## See Also  
 [Using Metadata](../../../../docs/framework/wcf/feature-details/using-metadata.md)
