---
title: "Custom Secure Metadata Endpoint"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9e369e99-ea4a-49ff-aed2-9fdf61091a48
caps.latest.revision: 19
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Custom Secure Metadata Endpoint
This sample demonstrates how to implement a service with a secure metadata endpoint that uses one of the non-metadata exchange bindings, and how to configure [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) or clients to fetch the metadata from such a metadata endpoint. There are two system-provided bindings available for exposing metadata endpoints: mexHttpBinding and mexHttpsBinding. mexHttpBinding is used to expose a metadata endpoint over HTTP in a non-secure manner. mexHttpsBinding is used to expose a metadata endpoint over HTTPS in a secure manner. This sample illustrates how to expose a secure metadata endpoint using the <xref:System.ServiceModel.WSHttpBinding>. You would want to do this when you want to change the security settings on the binding, but you do not want to use HTTPS. If you use the mexHttpsBinding your metadata endpoint will be secure, but there is no way to modify the binding settings.  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic.  
  
## Service  
 The service in this sample has two endpoints. The application endpoint serves the `ICalculator` contract on a `WSHttpBinding` with `ReliableSession` enabled and `Message` security using certificates. The metadata endpoint also uses `WSHttpBinding`, with the same security settings but with no `ReliableSession`. Here is the relevant configuration:  
  
```xml  
<services>   
    <service name="Microsoft.ServiceModel.Samples.CalculatorService"  
             behaviorConfiguration="CalculatorServiceBehavior">  
     <!-- use base address provided by host -->  
     <endpoint address=""  
       binding="wsHttpBinding"  
       bindingConfiguration="Binding2"  
       contract="Microsoft.ServiceModel.Samples.ICalculator" />  
     <endpoint address="mex"  
       binding="wsHttpBinding"  
       bindingConfiguration="Binding1"  
       contract="IMetadataExchange" />  
     </service>  
 </services>  
 <bindings>  
   <wsHttpBinding>  
     <binding name="Binding1">  
       <security mode="Message">  
         <message clientCredentialType="Certificate" />  
       </security>  
     </binding>  
     <binding name="Binding2">  
       <reliableSession inactivityTimeout="00:01:00" enabled="true" />  
       <security mode="Message">  
         <message clientCredentialType="Certificate" />  
       </security>  
     </binding>  
   </wsHttpBinding>  
 </bindings>  
```  
  
 In many of the other samples, the metadata endpoint uses the default `mexHttpBinding`, which is not secure. Here the metadata is secured using `WSHttpBinding` with `Message` security. In order for metadata clients to retrieve this metadata, they must be configured with a matching binding. This sample demonstrates two such clients.  
  
 The first client uses Svcutil.exe to fetch the metadata and generate client code and configuration at design time. Because the service uses a non-default binding for the metadata, the Svcutil.exe tool must be specifically configured so that it can get the metadata from the service using that binding.  
  
 The second client uses the `MetadataResolver` to dynamically fetch the metadata for a known contract and then invoke operations on the dynamically generated client.  
  
## Svcutil client  
 When using the default binding to host your `IMetadataExchange` endpoint, you can run Svcutil.exe with the address of that endpoint:  
  
```  
svcutil http://localhost/servicemodelsamples/service.svc/mex  
```  
  
 and it works. But in this sample, the server uses a non-default endpoint to host the metadata. So Svcutil.exe must be instructed to use the correct binding. This can be done using a Svcutil.exe.config file.  
  
 The Svcutil.exe.config file looks like a normal client configuration file. The only unusual aspects are the client endpoint name and contract:  
  
```xml  
<endpoint name="http"  
          binding="wsHttpBinding"  
          bindingConfiguration="Binding1"  
          behaviorConfiguration="ClientCertificateBehavior"  
          contract="IMetadataExchange" />  
```  
  
 The endpoint name must be the name of the scheme of the address where the metadata is hosted and the endpoint contract must be `IMetadataExchange`. Thus, when Svcutil.exe is run with a command-line such as the following:  
  
```  
svcutil http://localhost/servicemodelsamples/service.svc/mex  
```  
  
 it looks for the endpoint named "http" and contract `IMetadataExchange` to configure the binding and behavior of the communication exchange with the metadata endpoint. The rest of the Svcutil.exe.config file in the sample specifies the binding configuration and behavior credentials to match the server's configuration of the metadata endpoint.  
  
 In order for Svcutil.exe to pick up the configuration in Svcutil.exe.config, Svcutil.exe must be in the same directory as the configuration file. As a result, you must copy Svcutil.exe from its install location to the directory that contains the Svcutil.exe.config file. Then from that directory, run the following command:  
  
```  
.\svcutil.exe http://localhost/servicemodelsamples/service.svc/mex  
```  
  
 The leading ".\\" ensures that the copy of Svcutil.exe in this directory (the one which has a corresponding Svcutil.exe.config) is run.  
  
## MetadataResolver client  
 If the client knows the contract and how to talk to the metadata at design time, the client can dynamically find out the binding and address of application endpoints using the `MetadataResolver`. This sample client demonstrates this, showing how to configure the binding and credentials used by `MetadataResolver` by creating and configuring a `MetadataExchangeClient`.  
  
 The same binding and certificate information that appeared in Svcutil.exe.config can be specified imperatively on the `MetadataExchangeClient`:  
  
```  
// Specify the Metadata Exchange binding and its security mode  
WSHttpBinding mexBinding = new WSHttpBinding(SecurityMode.Message);  
mexBinding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;  
  
// Create a MetadataExchangeClient for retrieving metadata, and set the // certificate details  
MetadataExchangeClient mexClient = new MetadataExchangeClient(mexBinding);  
mexClient.SoapCredentials.ClientCertificate.SetCertificate(    StoreLocation.CurrentUser, StoreName.My,  
    X509FindType.FindBySubjectName, "client.com");  
mexClient.SoapCredentials.ServiceCertificate.Authentication.    CertificateValidationMode =    X509CertificateValidationMode.PeerOrChainTrust;  
mexClient.SoapCredentials.ServiceCertificate.SetDefaultCertificate(    StoreLocation.CurrentUser, StoreName.TrustedPeople,  
    X509FindType.FindBySubjectName, "localhost");  
```  
  
 With the `mexClient` configured, we can enumerate the contracts we are interested in, and use `MetadataResolver` to fetch a list of endpoints with those contracts:  
  
```  
// The contract we want to fetch metadata for  
Collection<ContractDescription> contracts =    new Collection<ContractDescription>();  
ContractDescription contract =    ContractDescription.GetContract(typeof(ICalculator));  
contracts.Add(contract);  
// Find endpoints for that contract  
EndpointAddress mexAddress = new    EndpointAddress(ConfigurationManager.AppSettings["mexAddress"]);  
ServiceEndpointCollection endpoints =    MetadataResolver.Resolve(contracts, mexAddress, mexClient);  
```  
  
 Finally we can use the information from those endpoints to initialize the binding and address of a `ChannelFactory` used to create channels to communicate with the application endpoints.  
  
```  
ChannelFactory<ICalculator> cf = new    ChannelFactory<ICalculator>(endpoint.Binding, endpoint.Address);  
```  
  
 The key point of this sample client is to demonstrate that, if you are using `MetadataResolver`, and you must specify custom bindings or behaviors for the metadata exchange communication, you can use a `MetadataExchangeClient` to specify those custom settings.  
  
#### To set up and build the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
#### To run the sample on the same machine  
  
1.  Run Setup.bat from the sample install folder. This installs all the certificates required for running the sample. Note that Setup.bat uses the FindPrivateKey.exe tool, which is installed by running setupCertTool.bat from [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  Run the client application from \MetadataResolverClient\bin or \SvcutilClient\bin. Client activity is displayed on the client console application.  
  
3.  If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
4.  Remove the certificates by running Cleanup.bat when you have finished with the sample. Other security samples use the same certificates.  
  
#### To run the sample across machines  
  
1.  On the server, run `setup.bat service`. Running `setup.bat` with the `service` argument creates a service certificate with the fully-qualified domain name of the machine and exports the service certificate to a file named Service.cer.  
  
2.  On the server, edit Web.config to reflect the new certificate name. That is, change the `findValue` attribute in the [\<serviceCertificate>](../../../../docs/framework/configure-apps/file-schema/wcf/servicecertificate-of-clientcredentials-element.md) element to the fully-qualified domain name of the machine.  
  
3.  Copy the Service.cer file from the service directory to the client directory on the client machine.  
  
4.  On the client, run `setup.bat client`. Running `setup.bat` with the `client` argument creates a client certificate named Client.com and exports the client certificate to a file named Client.cer.  
  
5.  In the App.config file of the `MetadataResolverClient` on the client machine, change the address value of the mex endpoint to match the new address of your service. You do this by replacing localhost with the fully-qualified domain name of the server. Also change the occurrence of "localhost" in the metadataResolverClient.cs file to the new service certificate name (the fully-qualified domain name of the server). Do the same thing for the App.config of the SvcutilClient project.  
  
6.  Copy the Client.cer file from the client directory to the service directory on the server.  
  
7.  On the client, run `ImportServiceCert.bat`. This imports the service certificate from the Service.cer file into the CurrentUser - TrustedPeople store.  
  
8.  On the server, run `ImportClientCert.bat`, This imports the client certificate from the Client.cer file into the LocalMachine - TrustedPeople store.  
  
9. On the service machine, build the service project in Visual Studio and select the help page in a web browser to verify that it is running.  
  
10. On the client machine, run the MetadataResolverClient or the SvcutilClient from VS.  
  
    1.  If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
#### To clean up after the sample  
  
-   Run Cleanup.bat in the samples folder once you have finished running the sample.  
  
    > [!NOTE]
    >  This script does not remove service certificates on a client when running this sample across machines. If you have run [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] samples that use certificates across machines, be sure to clear the service certificates that have been installed in the CurrentUser - TrustedPeople store. To do this, use the following command: `certmgr -del -r CurrentUser -s TrustedPeople -c -n <Fully Qualified Server Machine Name>`. For example: `certmgr -del -r CurrentUser -s TrustedPeople -c -n server1.contoso.com`.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Extensibility\Metadata\CustomMexEndpoint`  
  
## See Also
