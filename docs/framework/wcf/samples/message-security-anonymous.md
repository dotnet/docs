---
title: "Message Security Anonymous"
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
ms.assetid: c321cbf9-8c05-4cce-b5a5-4bf7b230ee03
caps.latest.revision: 52
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Message Security Anonymous
The Message Security Anonymous sample demonstrates how to implement a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] application that uses message-level security with no client authentication but that requires server authentication using the server's X.509 certificate. All application messages between the client and server are signed and encrypted. This sample is based on the [WSHttpBinding](../../../../docs/framework/wcf/samples/wshttpbinding.md) sample. This sample consists of a client console program (.exe) and a service library (.dll) hosted by Internet Information Services (IIS). The service implements a contract that defines a request-reply communication pattern.  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic.  
  
 This sample adds a new operation to the calculator interface that returns `True` if the client was not authenticated.  
  
```  
public class CalculatorService : ICalculator  
{  
    public bool IsCallerAnonymous()  
    {  
        // ServiceSecurityContext.IsAnonymous returns true if the caller is not authenticated.  
        return ServiceSecurityContext.Current.IsAnonymous;  
    }  
    ...  
}  
```  
  
 The service exposes a single endpoint for communicating with the service, defined using a configuration file (Web.config). The endpoint consists of an address, a binding, and a contract. The binding is configured with a `wsHttpBinding` binding. The default security mode for the `wsHttpBinding` binding is `Message`. The `clientCredentialType` attribute is set to `None`.  
  
```xml  
<system.serviceModel>  
  
  <protocolMapping>  
    <add scheme="http" binding="wsHttpBinding" />  
  </protocolMapping>  
  
  <bindings>  
    <wsHttpBinding>  
     <!--   
     <!--This configuration defines the security mode as Message and-->  
     <!--the clientCredentialType as None. This mode provides -- >  
     <!--server authentication only using the service certificate.-->  
  
     <binding>  
       <security mode="Message">  
         <message clientCredentialType="None" />  
       </security>  
     </binding>  
    </wsHttpBinding>  
  </bindings>  
  ...  
</system.serviceModel>  
```  
  
 The credentials to be used for service authentication are specified in the [\<behavior>](../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md). The server certificate must contain the same value for the `SubjectName` as the value specified for the `findValue` attribute as shown in the following sample code.  
  
```xml  
<behaviors>  
  <serviceBehaviors>  
    <behavior>  
      <!--   
    The serviceCredentials behavior allows you to define a service certificate.  
    A service certificate is used by a client to authenticate the service and provide message protection.  
    This configuration references the "localhost" certificate installed during the setup instructions.  
    -->  
      <serviceCredentials>  
        <serviceCertificate findValue="localhost" storeLocation="LocalMachine" storeName="My" x509FindType="FindBySubjectName" />  
      </serviceCredentials>  
      <serviceMetadata httpGetEnabled="True"/>  
      <serviceDebug includeExceptionDetailInFaults="False" />  
    </behavior>  
  </serviceBehaviors>  
</behaviors>  
```  
  
 The client endpoint configuration consists of an absolute address for the service endpoint, the binding, and the contract. The client security mode for the `wsHttpBinding` binding is `Message`. The `clientCredentialType` attribute is set to `None`.  
  
```xml  
<system.serviceModel>  
  <client>  
    <endpoint name=""  
             address="http://localhost/servicemodelsamples/service.svc"   
             binding="wsHttpBinding"   
             behaviorConfiguration="ClientCredentialsBehavior"  
             bindingConfiguration="Binding1"   
             contract="Microsoft.ServiceModel.Samples.ICalculator" />  
  </client>  
  
  <bindings>  
    <wsHttpBinding>  
      <!--This configuration defines the security mode as -->  
      <!--Message and the clientCredentialType as None. -->  
      <binding name="Binding1">  
        <security mode = "Message">  
          <message clientCredentialType="None"/>  
        </security>  
      </binding>  
    </wsHttpBinding>  
  </bindings>   
  ...  
</system.serviceModel>  
```  
  
 The sample sets the <xref:System.ServiceModel.Security.X509ServiceCertificateAuthentication.CertificateValidationMode%2A> to <xref:System.ServiceModel.Security.X509CertificateValidationMode.PeerOrChainTrust> for authenticating the service's certificate. This is done in the client's App.config file in the `behaviors` section. This means that if the certificate is in the user's Trusted People store, then it is trusted without performing a validation of the certificate's issuer chain. This setting is used here for convenience so that the sample can be run without requiring certificates issued by a certification authority (CA). This setting is less secure than the default, ChainTrust. The security implications of this setting should be carefully considered before using `PeerOrChainTrust` in production code.  
  
 The client implementation adds a call to the `IsCallerAnonymous` method and otherwise does not differ from the [WSHttpBinding](../../../../docs/framework/wcf/samples/wshttpbinding.md) sample.  
  
```  
// Create a client with a client endpoint configuration.  
CalculatorClient client = new CalculatorClient();  
  
// Call the GetCallerIdentity operation.  
Console.WriteLine("IsCallerAnonymous returned: {0}", client.IsCallerAnonymous());  
  
// Call the Add service operation.  
double value1 = 100.00D;  
double value2 = 15.99D;  
double result = client.Add(value1, value2);  
Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);  
  
...  
  
//Closing the client gracefully closes the connection and cleans up resources.  
client.Close();  
  
Console.WriteLine();  
Console.WriteLine("Press <ENTER> to terminate client.");  
Console.ReadLine();  
```  
  
 When you run the sample, the operation requests and responses are displayed in the client console window. Press ENTER in the client window to shut down the client.  
  
```  
IsCallerAnonymous returned: True  
Add(100,15.99) = 115.99  
Subtract(145,76.54) = 68.46  
Multiply(9,81.25) = 731.25  
Divide(22,7) = 3.14285714285714  
Press <ENTER> to terminate client.  
```  
  
 The Setup.bat batch file included with the Message Security Anonymous sample enables you to configure the server with a relevant certificate to run a hosted application that requires certificate-based security. The batch file can be run in two modes. To run the batch file in the single-computer mode, type `setup.bat` at the command line. To run it in service mode, type `setup.bat service`. Use this mode when running the sample across computers. See the setup procedure at the end of this topic for details.  
  
 The following provides a brief overview of the different sections of the batch files:  
  
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
  
     The %SERVER_NAME% variable specifies the server name. The certificate is stored in the LocalMachine store. If the setup batch file is run with an argument of service (such as `setup.bat service`) the %SERVER_NAME% contains the fully-qualified domain name of the computer. Otherwise it defaults to localhost.  
  
-   Installing the server certificate into the client's trusted certificate store.  
  
     The following line copies the server certificate into the client trusted people store. This step is required because certificates generated by Makecert.exe are not implicitly trusted by the client system. If you already have a certificate that is rooted in a client trusted root certificate—for example, a Microsoft-issued certificate—this step of populating the client certificate store with the server certificate is not required.  
  
    ```  
    certmgr.exe -add -r LocalMachine -s My -c -n %SERVER_NAME% -r CurrentUser -s TrustedPeople  
    ```  
  
-   Granting permissions on the certificate's private key.  
  
     The following lines in the Setup.bat batch file make the server certificate stored in the LocalMachine store accessible to the [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] worker process account.  
  
    ```  
    echo ************  
    echo setting privileges on server certificates  
    echo ************  
    for /F "delims=" %%i in ('"%MSSDK%\bin\FindPrivateKey.exe" My LocalMachine -n CN^=%SERVER_NAME% -a') do set PRIVATE_KEY_FILE=%%i set WP_ACCOUNT=NT AUTHORITY\NETWORK SERVICE  
    (ver | findstr "5.1") && set WP_ACCOUNT=%COMPUTERNAME%\ASPNET  
    echo Y|cacls.exe "%PRIVATE_KEY_FILE%" /E /G "%WP_ACCOUNT%":R  
    iisreset  
    ```  
  
> [!NOTE]
>  If you are using a non-U.S. English edition of Windows you must edit the Setup.bat file and replace the `NT AUTHORITY\NETWORK SERVICE` account name with your regional equivalent.  
  
### To set up, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
### To run the sample on the same computer  
  
1.  Ensure that the path includes the folder where Makecert.exe and FindPrivateKey.exe are located.  
  
2.  Run Setup.bat from the sample install folder in a Visual Studio command prompt run with administrator privileges. This installs all the certificates required for running the sample.  
  
    > [!NOTE]
    >  The setup batch file is designed to be run from a  [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)]Command Prompt. It requires that the path environment variable point to the directory where the SDK is installed. This environment variable is automatically set within a [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)]Command Prompt.  
  
3.  Verify access to the service using a browser by entering the address http://localhost/servicemodelsamples/service.svc.  
  
4.  Launch Client.exe from \client\bin. Client activity is displayed on the client console application.  
  
5.  If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
### To run the sample across computers  
  
1.  Create a directory on the service computer. Create a virtual application named servicemodelsamples for this directory by using the Internet Information Services (IIS) management tool.  
  
2.  Copy the service program files from \inetpub\wwwroot\servicemodelsamples to the virtual directory on the service computer. Ensure that you copy the files in the \bin subdirectory. Also copy the Setup.bat and Cleanup.bat files to the service computer.  
  
3.  Create a directory on the client computer for the client binaries.  
  
4.  Copy the client program files to the client directory on the client computer. Also copy the Setup.bat, Cleanup.bat, and ImportServiceCert.bat files to the client.  
  
5.  On the server, run `setup.bat service` in a Visual Studio command prompt opened with administrator privileges. Running `setup.bat` with the `service` argument creates a service certificate with the fully-qualified domain name of the computer and exports the service certificate to a file named Service.cer.  
  
6.  Edit Web.config to reflect the new certificate name (in the `findValue` attribute in the [\<serviceCertificate>](../../../../docs/framework/configure-apps/file-schema/wcf/servicecertificate-of-servicecredentials.md)), which is the same as the fully-qualified domain name of the computer.  
  
7.  Copy the Service.cer file from the service directory to the client directory on the client computer.  
  
8.  In the Client.exe.config file on the client computer, change the address value of the endpoint to match the new address of your service.  
  
9. On the client, run ImportServiceCert.bat in a Visual Studio command prompt opened with administrator privileges. This imports the service certificate from the Service.cer file into the CurrentUser - TrustedPeople store.  
  
10. On the client computer, launch Client.exe from a command prompt. If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
### To clean up after the sample  
  
-   Run Cleanup.bat in the samples folder after you have finished running the sample.  
  
> [!NOTE]
>  This script does not remove service certificates on a client when running this sample across computers. If you have run [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] samples that use certificates across computers, be sure to clear the service certificates that have been installed in the CurrentUser - TrustedPeople store. To do this, use the following command: `certmgr -del -r CurrentUser -s TrustedPeople -c -n <Fully Qualified Server Machine Name>` For example: `certmgr -del -r CurrentUser -s TrustedPeople -c -n server1.contoso.com.`  
  
## See Also
