---
title: "WS Transport With Message Credential"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0d092f3a-b309-439b-920b-66d8f46a0e3c
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WS Transport With Message Credential
This sample demonstrates the use of SSL transport security in combination with client credential being carried in the message. This sample uses the `wsHttpBinding` binding.  
  
 By default, the `wsHttpBinding` binding provides HTTP communication. When configured for transport security, the binding supports HTTPS communication. HTTPS provides confidentiality and integrity protection for the messages that are transmitted over the wire. However the set of authentication mechanisms that can be used to authenticate the client to the service is limited to what the HTTPS transport supports. [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] offers a `TransportWithMessageCredential` security mode that is designed to overcome this limitation. When this security mode is configured, the transport security is used to provide confidentiality and integrity for the transmitted messages and to perform the service authentication. However, the client authentication is performed by putting the client credential directly in the message. This allows you to use any credential type that is supported by the message security mode for the client authentication while keeping the performance benefit of transport security mode.  
  
 In this sample, a `UserName` credential type is used to authenticate the client to the service.  
  
 This sample is based on the [Getting Started](../../../../docs/framework/wcf/samples/getting-started-sample.md) that implements a calculator service. The `wsHttpBinding` binding is specified and configured in the application configuration files for the client and service.  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic.  
  
 The program code in the sample is almost identical to that of the [Getting Started](../../../../docs/framework/wcf/samples/getting-started-sample.md) service. There is one additional operation provided by the service contract - `GetCallerIdentity`. This operation returns the name of the caller's identity to the caller.  
  
```  
public string GetCallerIdentity()  
{  
    // Use ServiceSecurityContext.WindowsIdentity to get the name of the caller.  
    return ServiceSecurityContext.Current.WindowsIdentity.Name;  
}  
```  
  
 You must create a certificate and assign it by using the Web Server Certificate Wizard before building and running the sample. The endpoint definition and binding definition in the configuration file settings enable `TransportWithMessageCredential` security mode, as shown in the following sample configuration for the client.  
  
```xml  
<system.serviceModel>  
  <client>  
    <endpoint name=""  
              address="https://localhost/servicemodelsamples/service.svc"   
              binding="wsHttpBinding"   
              bindingConfiguration="Binding1"   
              contract="Microsoft.ServiceModel.Samples.ICalculator" />  
  </client>  
  
  <bindings>  
    <wsHttpBinding>  
      <!--   
        This configuration defines the security mode as TransportWithMessageCredential.  
        and the clientCredentialType as UserName.  
        -->  
      <binding name="Binding1">  
        <security mode ="TransportWithMessageCredential">  
          <message clientCredentialType="UserName" />  
        </security>  
      </binding>  
    </wsHttpBinding>  
  </bindings>  
</system.serviceModel>  
```  
  
 The address specified uses the https:// scheme. The binding configuration sets the security mode to `TransportWithMessageCredential`. The same security mode must be specified in the service's Web.config file.  
  
 Because the certificate used in this sample is a test certificate created with Makecert.exe, a security alert appears when you try to access an https: address, such as https://localhost/servicemodelsamples/service.svc, from your browser. To allow the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client to work with a test certificate in place, some additional code has been added to the client to suppress the security alert. This code, and the accompanying class, is not required when using production certificates.  
  
```  
// WARNING: This code is only needed for test certificates such as those created by makecert. It is   
// not recommended for production code.  
PermissiveCertificatePolicy.Enact("CN=ServiceModelSamples-HTTPS-Server");  
```  
  
 When you run the sample, the operation requests and responses are displayed in the client console window. Press ENTER in the client window to shut down the client.  
  
```  
Username authentication required.  
Provide a valid machine or domain account. [domain\\user]  
   Enter username:   
YourDomainName\YourAccountName  
   Enter password:   
********  
YourDomainName\YourAccountName  
Add(100,15.99) = 115.99  
Subtract(145,76.54) = 68.46  
Multiply(9,81.25) = 731.25  
Divide(22,7) = 3.14285714285714  
  
Press <ENTER> to terminate client.  
```  
  
### To set up, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  Ensure that you have performed the [Internet Information Services (IIS) Server Certificate Installation Instructions](../../../../docs/framework/wcf/samples/iis-server-certificate-installation-instructions.md).  
  
3.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
4.  To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
## See Also
