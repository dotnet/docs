---
title: "Custom Binding Security"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a6383dff-4308-46d2-bc6d-acd4e18b4b8d
caps.latest.revision: 30
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Custom Binding Security
This sample demonstrates how to configure security by using a custom binding. It shows how to use a custom binding to enable message-level security together with a secure transport. This is useful when a secure transport is required to transmit the messages between client and service and simultaneously the messages must be secure on the message level. This configuration is not supported by system-provided bindings.  
  
 This sample consists of a client console program (EXE) and a service console program (EXE). The service implements a duplex contract. The contract is defined by the `ICalculatorDuplex` interface, which exposes math operations (Add, Subtract, Multiply, and Divide). The `ICalculatorDuplex` interface allows the client to perform math operations, calculating a running result over a session. Independently, the service may return results on the `ICalculatorDuplexCallback` interface. A duplex contract requires a session, because a context must be established to correlate the set of messages being sent between the client and the service. A custom binding is defined that supports duplex communication and is secure.  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic.  
  
 The service configuration defines a custom binding that supports the following:  
  
-   TCP communication protected by using the TLS/SSL protocol.  
  
-   Windows message security.  
  
 The custom binding configuration enables secure transport by simultaneously enabling the message-level security. The ordering of binding elements is important in defining a custom binding, because each represents a layer in the channel stack (see [Custom Bindings](../../../../docs/framework/wcf/extending/custom-bindings.md)). The custom binding is defined in the service and client configuration files, as shown in the following sample configuration.  
  
```xml  
<bindings>  
  <!-- Configure a custom binding. -->  
  <customBinding>  
    <binding name="Binding1">  
      <security authenticationMode="SecureConversation"  
                 requireSecurityContextCancellation="true">  
      </security>  
      <textMessageEncoding messageVersion="Soap12WSAddressing10" writeEncoding="utf-8"/>  
      <sslStreamSecurity requireClientCertificate="false"/>  
      <tcpTransport/>  
    </binding>  
  </customBinding>  
</bindings>  
```  
  
 The custom binding uses a service certificate to authenticate the service on the transport level and to protect the messages during the transmission between client and service. This is accomplished by the `sslStreamSecurity` binding element. The service's certificate is configured using a service behavior as shown in the following sample configuration.  
  
```xml  
<behaviors>  
      <serviceBehaviors>  
        <behavior name="CalculatorServiceBehavior">  
          <serviceMetadata />  
          <serviceDebug includeExceptionDetailInFaults="False" />  
          <serviceCredentials>  
            <serviceCertificate findValue="localhost" storeLocation="LocalMachine" storeName="My" x509FindType="FindBySubjectName"/>  
          </serviceCredentials>  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
```  
  
 Additionally, the custom binding uses message security with Windows credential type - this is the default credential type. This is accomplished by the `security` binding element. Both client and service are authenticated using message-level security if the Kerberos authentication mechanism is available. This happens if the sample is run in the Active Directory environment. If the Kerberos authentication mechanism is not available, NTLM authentication is used. NTLM authenticates the client to the service but does not authenticate the service to the client. The `security` binding element is configured to use `SecureConversation``authenticationType`, which results in the creation of a security session on both the client and the service. This is required to enable the service's duplex contract to work.  
  
 When you run the sample, the operation requests and responses are displayed in the client's console window. Press ENTER in the client window to shut down the client.  
  
```  
Press <ENTER> to terminate client.  
Result(100)  
Result(50)  
Result(882.5)  
Result(441.25)  
Equation(0 + 100 - 50 * 17.65 / 2 = 441.25)  
```  
  
 When you run the sample, you see the messages returned to the client on the callback interface sent from the service. Each intermediate result is displayed, followed by the entire equation upon completion of all operations. Press ENTER to shut down the client.  
  
 The included Setup.bat file enables you to configure the client and server with the relevant service certificate to run a hosted application that requires certificate-based security. This batch file must be modified to work across computers or to work in a non-hosted case.  
  
 The following provides a brief overview of the different sections of the batch files that apply to this sample so that they can be modified to run in the appropriate configuration:  
  
-   Creating the server certificate.  
  
     The following lines from the Setup.bat file create the server certificate to be used. The `%SERVER_NAME%` variable specifies the server name. Change this variable to specify your own server name. This batch file defaults the server name to localhost.  
  
     The certificate is stored in the CurrentUser store for the Web-hosted services.  
  
    ```  
    echo ************  
    echo Server cert setup starting  
    echo %SERVER_NAME%  
    echo ************  
    echo making server cert  
    echo ************  
    makecert.exe -sr LocalMachine -ss MY -a sha1 -n CN=%SERVER_NAME% -sky exchange -pe  
    ```  
  
-   Installing the server certificate into the client's trusted certificate store.  
  
     The following lines in the Setup.bat file copy the server certificate into the client trusted people store. This step is required because certificates generated by Makecert.exe are not implicitly trusted by the client system. If you already have a certificate that is rooted in a client trusted root certificate—for example, a Microsoft-issued certificate—this step of populating the client certificate store with the server certificate is not required.  
  
    ```  
    certmgr.exe -add -r LocalMachine -s My -c -n %SERVER_NAME% -r CurrentUser -s TrustedPeople  
    ```  
  
    > [!NOTE]
    >  The Setup.bat batch file is designed to be run from a Visual Studio 2010 Command Prompt. It requires that the MSSDK environment variable point to the directory where the SDK is installed. This environment variable is automatically set within a Visual Studio 2010 Command Prompt.  
  
### To set up, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
3.  To run the sample in a single- or cross-computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
### To run the sample on the same computer  
  
1.  Open a Visual Studio Command Prompt window with administrator privileges and run Setup.bat from the sample install folder. This installs all the certificates required for running the sample.  
  
    > [!NOTE]
    >  The Setup.bat batch file is designed to be run from a [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] Command Prompt. The PATH environment variable set within the [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] Command Prompt points to the directory that contains executables required by the Setup.bat script.  
  
2.  Launch Service.exe from \service\bin.  
  
3.  Launch Client.exe from \client\bin. Client activity is displayed on the client console application.  
  
4.  If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
### To run the sample across computers  
  
1.  On the service computer:  
  
    1.  Create a virtual directory named servicemodelsamples on the service computer.  
  
    2.  Copy the service program files from \inetpub\wwwroot\servicemodelsamples to the virtual directory on the service computer. Ensure that you copy the files in the \bin subdirectory.  
  
    3.  Copy the Setup.bat and Cleanup.bat files to the service computer.  
  
    4.  Run the following command in a Visual Studio command prompt opened with administrator privileges: `Setup.bat service`. This creates the service certificate with the subject name matching the name of the computer the batch file was run on.  
  
        > [!NOTE]
        >  The Setup.bat batch file is designed to be run from a Visual Studio 2010 Command Prompt. It requires that the path environment variable point to the directory where the SDK is installed. This environment variable is automatically set within a Visual Studio 2010 Command Prompt.  
  
    5.  Change the [\<serviceCertificate>](../../../../docs/framework/configure-apps/file-schema/wcf/servicecertificate-of-servicecredentials.md) inside the Service.exe.config file to reflect the subject name of the certificate generated in the previous step.  
  
    6.  Run Service.exe from a command prompt.  
  
2.  On the client computer:  
  
    1.  Copy the client program files from the \client\bin\ folder to the client computer. Also copy the Cleanup.bat file.  
  
    2.  Run Cleanup.bat to remove any old certificates from previous samples.  
  
    3.  Export the service's certificate by opening a Visual Studio command prompt with administrative privileges, and running the following command on the service computer (substitute `%SERVER_NAME%` with the fully-qualified name of the computer where the service is running):  
  
        ```  
        certmgr -put -r LocalMachine -s My -c -n %SERVER_NAME% %SERVER_NAME%.cer  
        ```  
  
    4.  Copy %SERVER_NAME%.cer to the client computer (substitute %SERVER_NAME% with the fully-qualified name of the computer where the service is running).  
  
    5.  Import the service's certificate by opening a Visual Studio command prompt with administrative privileges, and running the following command on the client computer (substitute %SERVER_NAME% with the fully-qualified name of the computer where the service is running):  
  
        ```  
        certmgr.exe -add -c %SERVER_NAME%.cer -s -r CurrentUser TrustedPeople  
        ```  
  
         Steps c, d, and e are not necessary if the certificate is issued by a Trusted Issuer.  
  
    6.  Modify the client’s App.config file as follows:  
  
        ```xml  
        <client>  
            <endpoint name="default"  
                address="net.tcp://ReplaceThisWithServiceMachineName:8000/ServiceModelSamples/Service"   
                binding="customBinding"   
                bindingConfiguration="Binding1"   
                contract="Microsoft.ServiceModel.Samples.ICalculatorDuplex"  
        behaviorConfiguration="CalculatorClientBehavior" />  
        </client>  
        ```  
  
    7.  If the service is running under an account other than the NetworkService or LocalSystem account in a domain environment, you might need to modify the endpoint identity for the service endpoint inside the client's App.config file to set the appropriate UPN or SPN based on the account that is used to run the service. For more information about endpoint identity, see the [Service Identity and Authentication](../../../../docs/framework/wcf/feature-details/service-identity-and-authentication.md) topic.  
  
    8.  Run Client.exe from a command prompt.  
  
### To clean up after the sample  
  
-   Run Cleanup.bat in the samples folder after you have finished running the sample.  
  
## See Also
