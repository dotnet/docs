---
title: "Message Security Certificate"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WS Security"
ms.assetid: 909333b3-35ec-48f0-baff-9a50161896f6
caps.latest.revision: 51
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Message Security Certificate
This sample demonstrates how to implement an application that uses WS-Security with X.509 v3 certificate authentication for the client and requires server authentication using the server's X.509 v3 certificate. This sample uses default settings such that all application messages between the client and server are signed and encrypted. This sample is based on the [WSHttpBinding](../../../../docs/framework/wcf/samples/wshttpbinding.md) and consists of a client console program and a service library hosted by Internet Information Services (IIS). The service implements a contract that defines a request-reply communication pattern.  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic.  
  
 The sample demonstrates controlling authentication by using configuration and how to obtain the caller’s identity from the security context, as shown in the following sample code.  
  
```  
public class CalculatorService : ICalculator  
{  
    public string GetCallerIdentity()  
    {  
        // The client certificate is not mapped to a Windows identity by default.  
        // ServiceSecurityContext.PrimaryIdentity is populated based on the information  
        // in the certificate that the client used to authenticate itself to the service.  
        return ServiceSecurityContext.Current.PrimaryIdentity.Name;  
    }  
    ...  
}  
```  
  
 The service exposes one endpoint for communicating with the service and one endpoint for exposing the service's WSDL document using the WS-MetadataExchange protocol, defined by using the configuration file (Web.config). The endpoint consists of an address, a binding, and a contract. The binding is configured with a standard [\<wsHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/wshttpbinding.md) element, which defaults to using message security. This sample sets the `clientCredentialType` attribute to Certificate to require client authentication.  
  
```xml  
<system.serviceModel>  
    <protocolMapping>  
      <add scheme="http" binding="wsHttpBinding"/>  
    </protocolMapping>  
    <bindings>  
      <wsHttpBinding>  
        <!--   
        This configuration defines the security mode as Message and   
        the clientCredentialType as Certificate.  
        -->  
        <binding>  
          <security mode ="Message">  
            <message clientCredentialType="Certificate" />  
          </security>  
        </binding>  
      </wsHttpBinding>  
    </bindings>  
    <!--For debugging purposes set the includeExceptionDetailInFaults attribute to true-->  
    <behaviors>  
      <serviceBehaviors>  
        <behavior>  
          <serviceMetadata httpGetEnabled="True"/>  
          <serviceDebug includeExceptionDetailInFaults="False" />  
          <!--   
        The serviceCredentials behavior allows one to define a service certificate.  
        A service certificate is used by the service to authenticate itself to its clients and to provide message protection.  
        This configuration references the "localhost" certificate installed during the setup instructions.  
        -->  
          <serviceCredentials>  
            <serviceCertificate findValue="localhost" storeLocation="LocalMachine" storeName="My" x509FindType="FindBySubjectName" />  
            <clientCertificate>  
              <!--   
            Setting the certificateValidationMode to PeerOrChainTrust means that if the certificate   
            is in the user's Trusted People store, then it will be trusted without performing a  
            validation of the certificate's issuer chain. This setting is used here for convenience so that the   
            sample can be run without having to have certificates issued by a certification authority (CA).  
            This setting is less secure than the default, ChainTrust. The security implications of this   
            setting should be carefully considered before using PeerOrChainTrust in production code.   
            -->  
              <authentication certificateValidationMode="PeerOrChainTrust" />  
            </clientCertificate>  
          </serviceCredentials>  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
  </system.serviceModel>  
```  
  
 The behavior specifies the service's credentials that are used when the client authenticates the service. The server certificate subject name is specified in the `findValue` attribute in the [\<serviceCredentials>](../../../../docs/framework/configure-apps/file-schema/wcf/servicecredentials.md) element.  
  
```xml  
<!--For debugging purposes, set the includeExceptionDetailInFaults attribute to true.-->  
<behaviors>  
      <serviceBehaviors>  
        <behavior>  
          <serviceMetadata httpGetEnabled="True"/>  
          <serviceDebug includeExceptionDetailInFaults="False" />  
          <!--   
        The serviceCredentials behavior allows one to define a service certificate.  
        A service certificate is used by the service to authenticate itself to its clients and to provide message protection.  
        This configuration references the "localhost" certificate installed during the setup instructions.  
        -->  
          <serviceCredentials>  
            <serviceCertificate findValue="localhost" storeLocation="LocalMachine" storeName="My" x509FindType="FindBySubjectName" />  
            <clientCertificate>  
              <!--   
            Setting the certificateValidationMode to PeerOrChainTrust means that if the certificate   
            is in the user's Trusted People store, then it will be trusted without performing a  
            validation of the certificate's issuer chain. This setting is used here for convenience so that the   
            sample can be run without having to have certificates issued by a certification authority (CA).  
            This setting is less secure than the default, ChainTrust. The security implications of this   
            setting should be carefully considered before using PeerOrChainTrust in production code.   
            -->  
              <authentication certificateValidationMode="PeerOrChainTrust" />  
            </clientCertificate>  
          </serviceCredentials>  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
```  
  
 The client endpoint configuration consists of an absolute address for the service endpoint, the binding, and the contract. The client binding is configured with the appropriate security mode and authentication mode. When running in a cross-computer scenario, ensure that the service endpoint address is changed accordingly.  
  
```xml  
<system.serviceModel>  
    <client>  
      <!-- Use a behavior to configure the client certificate to present to the service. -->  
      <endpoint address="http://localhost/servicemodelsamples/service.svc" binding="wsHttpBinding" bindingConfiguration="Binding1" behaviorConfiguration="ClientCertificateBehavior" contract="Microsoft.Samples.Certificate.ICalculator"/>  
    </client>  
  
    <bindings>  
      <wsHttpBinding>  
        <!--   
        This configuration defines the security mode as Message and   
        the clientCredentialType as Certificate.  
        -->  
        <binding name="Binding1">  
          <security mode="Message">  
            <message clientCredentialType="Certificate"/>  
          </security>  
        </binding>  
      </wsHttpBinding>  
    </bindings>  
...  
</system.serviceModel>  
```  
  
 The client implementation can set the certificate to use, either through the configuration file or through code. The following sample shows how to set the certificate to use in the configuration file.  
  
```xml  
<system.serviceModel>  
  ...  
  
<behaviors>  
      <endpointBehaviors>  
        <behavior name="ClientCertificateBehavior">  
          <!--   
        The clientCredentials behavior allows one to define a certificate to present to a service.  
        A certificate is used by a client to authenticate itself to the service and provide message integrity.  
        This configuration references the "client.com" certificate installed during the setup instructions.  
        -->  
          <clientCredentials>  
            <clientCertificate findValue="client.com" storeLocation="CurrentUser" storeName="My" x509FindType="FindBySubjectName"/>  
            <serviceCertificate>  
              <!--   
            Setting the certificateValidationMode to PeerOrChainTrust means that if the certificate   
            is in the user's Trusted People store, then it will be trusted without performing a  
            validation of the certificate's issuer chain. This setting is used here for convenience so that the   
            sample can be run without having to have certificates issued by a certificate authority (CA).  
            This setting is less secure than the default, ChainTrust. The security implications of this   
            setting should be carefully considered before using PeerOrChainTrust in production code.   
            -->  
              <authentication certificateValidationMode="PeerOrChainTrust"/>  
            </serviceCertificate>  
          </clientCredentials>  
        </behavior>  
      </endpointBehaviors>  
    </behaviors>  
  
</system.serviceModel>  
```  
  
 The following sample shows how to call the service in your program.  
  
```  
// Create a client.  
CalculatorClient client = new CalculatorClient();  
  
// Call the GetCallerIdentity service operation.  
Console.WriteLine(client.GetCallerIdentity());  
...  
//Closing the client gracefully closes the connection and cleans up resources.  
client.Close();  
```  
  
 When you run the sample, the operation requests and responses are displayed in the client console window. Press ENTER in the client window to shut down the client.  
  
```  
CN=client.com  
Add(100,15.99) = 115.99  
Subtract(145,76.54) = 68.46  
Multiply(9,81.25) = 731.25  
Divide(22,7) = 3.14285714285714  
Press <ENTER> to terminate client.  
```  
  
 The Setup.bat batch file included with the Message Security samples enables you to configure the client and server with relevant certificates to run a hosted application that requires certificate-based security. The batch file can be run in three modes. To run in single-computer mode type **setup.bat** in a Visual Studio Command Prompt ; for service mode type **setup.bat service**; and for client mode type **setup.bat client**. Use the client and server mode when running the sample across computers. See the setup procedure at the end of this topic for details. The following provides a brief overview of the different sections of the batch files so that they can be modified to run in appropriate configuration:  
  
-   Creating the client certificate.  
  
     The following line in the batch file creates the client certificate. The client name specified is used in the subject name of the certificate created. The certificate is stored in `My` store at the `CurrentUser` store location.  
  
    ```  
    echo ************  
    echo making client cert  
    echo ************  
    makecert.exe -sr CurrentUser -ss MY -a sha1 -n CN=%CLIENT_NAME% -sky exchange -pe  
    ```  
  
-   Installing the client certificate into the server’s trusted certificate store.  
  
     The following line in the batch file copies the client certificate into the server's TrustedPeople store so that the server can make the relevant trust or no-trust decisions. In order for a certificate installed in the TrustedPeople store to be trusted by a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service, the client certificate validation mode must be set to `PeerOrChainTrust` or `PeerTrust`. See the previous service configuration sample to learn how this can be done by using a configuration file.  
  
    ```  
    echo ************  
    echo copying client cert to server's LocalMachine store  
    echo ************  
    certmgr.exe -add -r CurrentUser -s My -c -n %CLIENT_NAME% -r LocalMachine -s TrustedPeople   
    ```  
  
-   Creating the server certificate.  
  
     The following lines from the Setup.bat batch file create the server certificate to be used.  
  
    ```  
    echo ************  
    echo Server cert setup starting  
    echo %SERVER_NAME%  
    echo ************  
    echo making server cert  
    echo ************  
    makecert.exe -sr LocalMachine -ss MY -a sha1 -n CN=%SERVER_NAME% -sky exchange -pe  
    ```  
  
     The %SERVER_NAME% variable specifies the server name. The certificate is stored in the LocalMachine store. If the Setup.bat batch file is run with an argument of service (such as, **setup.bat service**) the %SERVER_NAME% contains the fully-qualified domain name of the computer. Otherwise it defaults to localhost.  
  
-   Installing the server certificate into the client’s trusted certificate store.  
  
     The following line copies the server certificate into the client trusted people store. This step is required because certificates generated by Makecert.exe are not implicitly trusted by the client system. If you already have a certificate that is rooted in a client trusted root certificate—for example, a Microsoft-issued certificate—this step of populating the client certificate store with the server certificate is not required.  
  
    ```  
    certmgr.exe -add -r LocalMachine -s My -c -n %SERVER_NAME% -r CurrentUser -s TrustedPeople  
    ```  
  
-   Granting permissions on the certificate's private key.  
  
     The following lines in the Setup.bat file make the server certificate stored in the LocalMachine store accessible to the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] worker process account.  
  
    ```  
    echo ************  
    echo setting privileges on server certificates  
    echo ************  
    for /F "delims=" %%i in ('"%ProgramFiles%\ServiceModelSampleTools\FindPrivateKey.exe" My LocalMachine -n CN^=%SERVER_NAME% -a') do set PRIVATE_KEY_FILE=%%i  
    set WP_ACCOUNT=NT AUTHORITY\NETWORK SERVICE  
    (ver | findstr /C:"5.1") && set WP_ACCOUNT=%COMPUTERNAME%\ASPNET  
    echo Y|cacls.exe "%PRIVATE_KEY_FILE%" /E /G "%WP_ACCOUNT%":R  
    iisreset  
    ```  
  
    > [!NOTE]
    >  If you are using a non-U.S. English edition of Windows, you must edit the Setup.bat file and replace the "NT AUTHORITY\NETWORK SERVICE" account name with your regional equivalent.  
  
> [!NOTE]
>  The tools used in this batch file are located in either C:\Program Files\Microsoft Visual Studio 8\Common7\tools or C:\Program Files\Microsoft SDKs\Windows\v6.0\bin. One of these directories must be in your system path. If you have Visual Studio installed, the easiest way to get this directory in your path is to open the Visual Studio Command Prompt. Click **Start**, and then select **All Programs**, **Visual Studio 2012**, **Tools**. This command prompt has the appropriate paths already configured. Otherwise you must add the appropriate directory to your path manually.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing:  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory:  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Basic\Binding\WS\MessageSecurity`  
  
### To set up, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
### To run the sample on the same computer  
  
1.  Open a Visual Studio Command Prompt  with administrator privileges and run Setup.bat from the sample install folder. This installs all the certificates required for running the sample.  
  
    > [!NOTE]
    >  The Setup.bat batch file is designed to be run from a Visual Studio Command Prompt . It requires that the path environment variable point to the directory where the SDK is installed. This environment variable is automatically set within a Visual Studio Command Prompt (2010).  
  
2.  Verify access to the service using a browser by entering the address `http://localhost/servicemodelsamples/service.svc`.  
  
3.  Launch Client.exe from \client\bin. Client activity is displayed on the client console application.  
  
4.  If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
### To run the sample across computers  
  
1.  Create a directory on the service computer. Create a virtual application named servicemodelsamples for this directory by using the Internet Information Services (IIS) management tool.  
  
2.  Copy the service program files from \inetpub\wwwroot\servicemodelsamples to the virtual directory on the service computer. Ensure that you copy the files in the \bin subdirectory. Also copy the Setup.bat, Cleanup.bat, and ImportClientCert.bat files to the service computer.  
  
3.  Create a directory on the client computer for the client binaries.  
  
4.  Copy the client program files to the client directory on the client computer. Also copy the Setup.bat, Cleanup.bat, and ImportServiceCert.bat files to the client.  
  
5.  On the server, run **setup.bat service** in a Visual Studio command prompt with administrator privileges. Running **setup.bat** with the **service** argument creates a service certificate with the fully-qualified domain name of the computer and exports the service certificate to a file named Service.cer.  
  
6.  Edit Web.config to reflect the new certificate name (in the `findValue` attribute in the [\<serviceCertificate>](../../../../docs/framework/configure-apps/file-schema/wcf/servicecertificate-of-servicecredentials.md)) which is the same as the fully-qualified domain name of the computer.  
  
7.  Copy the Service.cer file from the service directory to the client directory on the client computer.  
  
8.  On the client, run **setup.bat client** in a Visual Studio command prompt with administrator privileges. Running **setup.bat** with the **client** argument creates a client certificate named client.com and exports the client certificate to a file named Client.cer.  
  
9. In the Client.exe.config file on the client computer, change the address value of the endpoint to match the new address of your service. Do this by replacing localhost with the fully-qualified domain name of the server.  
  
10. Copy the Client.cer file from the client directory to the service directory on the server.  
  
11. On the client, run ImportServiceCert.bat in a Visual Studio command prompt with administrative privileges. This imports the service certificate from the Service.cer file into the CurrentUser - TrustedPeople store.  
  
12. On the server, run ImportClientCert.bat in a Visual Studio command prompt with administrative privileges. This imports the client certificate from the Client.cer file into the LocalMachine - TrustedPeople store.  
  
13. On the client computer, launch Client.exe from a command prompt window. If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
### To clean up after the sample  
  
-   Run Cleanup.bat in the samples folder after you have finished running the sample.  
  
    > [!NOTE]
    >  This script does not remove service certificates on a client when running this sample across computers. If you have run [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] samples that use certificates across computers, be sure to clear the service certificates that have been installed in the CurrentUser - TrustedPeople store. To do this, use the following command: `certmgr -del -r CurrentUser -s TrustedPeople -c -n <Fully Qualified Server Machine Name>` For example: `certmgr -del -r CurrentUser -s TrustedPeople -c -n server1.contoso.com`.  
  
## See Also
