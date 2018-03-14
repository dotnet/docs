---
title: "Authorization Policy"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1db325ec-85be-47d0-8b6e-3ba2fdf3dda0
caps.latest.revision: 38
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Authorization Policy
This sample demonstrates how to implement a custom claim authorization policy and an associated custom service authorization manager. This is useful when the service makes claim-based access checks to service operations and prior to the access checks, grants the caller certain rights. This sample shows both the process of adding claims as well as the process for doing an access check against the finalized set of claims. All application messages between the client and server are signed and encrypted. By default with the `wsHttpBinding` binding, a username and password supplied by the client are used to logon to a valid Windows NT account. This sample demonstrates how to utilize a custom <!--zz <xref:System.IdentityModel.Selectors.UsernamePasswordValidator>--> `System.IdentityModel.Selectors.UsernamePasswordValidator` to authenticate the client. In addition this sample shows the client authenticating to the service using an X.509 certificate. This sample shows an implementation of <xref:System.IdentityModel.Policy.IAuthorizationPolicy> and <xref:System.ServiceModel.ServiceAuthorizationManager>, which between them grant access to specific methods of the service for specific users. This sample is based on the [Message Security User Name](../../../../docs/framework/wcf/samples/message-security-user-name.md), but demonstrates how to perform a claim transformation prior to the <xref:System.ServiceModel.ServiceAuthorizationManager> being called.  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic.  
  
 In summary, this sample demonstrates how:  
  
-   The client can be authenticated using a user name-password.  
  
-   The client can be authenticated using an X.509 certificate.  
  
-   The server validates the client credentials against a custom `UsernamePassword` validator.  
  
-   The server is authenticated using the server's X.509 certificate.  
  
-   The server can use <xref:System.ServiceModel.ServiceAuthorizationManager> to control access to certain methods in the service.  
  
-   How to implement <xref:System.IdentityModel.Policy.IAuthorizationPolicy>.  
  
 The service exposes two endpoints for communicating with the service, defined using the configuration file App.config. Each endpoint consists of an address, a binding, and a contract. One binding is configured with a standard `wsHttpBinding` binding that uses WS-Security and client username authentication. The other binding is configured with a standard `wsHttpBinding` binding that uses WS-Security and client certificate authentication. The [\<behavior>](../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md) specifies that the user credentials are to be used for service authentication. The server certificate must contain the same value for the `SubjectName` property as the `findValue` attribute in the [\<serviceCertificate>](../../../../docs/framework/configure-apps/file-schema/wcf/servicecertificate-of-servicecredentials.md).  
  
```xml  
<system.serviceModel>  
  <services>  
    <service name="Microsoft.ServiceModel.Samples.CalculatorService"  
             behaviorConfiguration="CalculatorServiceBehavior">  
      <host>  
        <baseAddresses>  
          <!-- configure base address provided by host -->  
          <add baseAddress ="http://localhost:8001/servicemodelsamples/service"/>  
        </baseAddresses>  
      </host>  
      <!-- use base address provided by host, provide two endpoints -->  
      <endpoint address="username"  
                binding="wsHttpBinding"  
                bindingConfiguration="Binding1"   
                contract="Microsoft.ServiceModel.Samples.ICalculator" />  
      <endpoint address="certificate"  
                binding="wsHttpBinding"  
                bindingConfiguration="Binding2"   
                contract="Microsoft.ServiceModel.Samples.ICalculator" />  
    </service>  
  </services>  
  
  <bindings>  
    <wsHttpBinding>  
      <!-- Username binding -->  
      <binding name="Binding1">  
        <security mode="Message">  
    <message clientCredentialType="UserName" />  
        </security>  
      </binding>  
      <!-- X509 certificate binding -->  
      <binding name="Binding2">  
        <security mode="Message">  
          <message clientCredentialType="Certificate" />  
        </security>  
      </binding>  
    </wsHttpBinding>  
  </bindings>  
  
  <behaviors>  
    <serviceBehaviors>  
      <behavior name="CalculatorServiceBehavior" >  
        <serviceDebug includeExceptionDetailInFaults ="true" />  
        <serviceCredentials>  
          <!--   
          The serviceCredentials behavior allows one to specify a custom validator for username/password combinations.    
          -->  
          <userNameAuthentication userNamePasswordValidationMode="Custom" customUserNamePasswordValidatorType="Microsoft.ServiceModel.Samples.MyCustomUserNameValidator, service" />  
          <!--   
          The serviceCredentials behavior allows one to specify authentication constraints on client certificates.  
          -->  
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
          <!--   
          The serviceCredentials behavior allows one to define a service certificate.  
          A service certificate is used by a client to authenticate the service and provide message protection.  
          This configuration references the "localhost" certificate installed during the setup instructions.  
          -->  
          <serviceCertificate findValue="localhost" storeLocation="LocalMachine" storeName="My" x509FindType="FindBySubjectName" />  
        </serviceCredentials>  
        <serviceAuthorization serviceAuthorizationManagerType="Microsoft.ServiceModel.Samples.MyServiceAuthorizationManager, service">  
          <!--   
          The serviceAuthorization behavior allows one to specify custom authorization policies.  
          -->  
          <authorizationPolicies>  
            <add policyType="Microsoft.ServiceModel.Samples.CustomAuthorizationPolicy.MyAuthorizationPolicy, PolicyLibrary" />  
          </authorizationPolicies>  
        </serviceAuthorization>  
      </behavior>  
    </serviceBehaviors>  
  </behaviors>  
  
</system.serviceModel>  
```  
  
 Each client endpoint configuration consists of a configuration name, an absolute address for the service endpoint, the binding, and the contract. The client binding is configured with the appropriate security mode as specified in this case in the [\<security>](../../../../docs/framework/configure-apps/file-schema/wcf/security-of-wshttpbinding.md) and `clientCredentialType` as specified in the [\<message>](../../../../docs/framework/configure-apps/file-schema/wcf/message-of-wshttpbinding.md).  
  
```xml  
<system.serviceModel>  
  
    <client>  
      <!-- Username based endpoint -->  
      <endpoint name="Username"  
            address="http://localhost:8001/servicemodelsamples/service/username"   
    binding="wsHttpBinding"   
    bindingConfiguration="Binding1"   
                behaviorConfiguration="ClientCertificateBehavior"  
                contract="Microsoft.ServiceModel.Samples.ICalculator" >  
      </endpoint>  
      <!-- X509 certificate based endpoint -->  
      <endpoint name="Certificate"  
                        address="http://localhost:8001/servicemodelsamples/service/certificate"   
                binding="wsHttpBinding"   
            bindingConfiguration="Binding2"   
                behaviorConfiguration="ClientCertificateBehavior"  
                contract="Microsoft.ServiceModel.Samples.ICalculator">  
      </endpoint>  
    </client>  
  
    <bindings>  
      <wsHttpBinding>  
        <!-- Username binding -->  
      <binding name="Binding1">  
        <security mode="Message">  
          <message clientCredentialType="UserName" />  
        </security>  
      </binding>  
        <!-- X509 certificate binding -->  
        <binding name="Binding2">  
          <security mode="Message">  
            <message clientCredentialType="Certificate" />  
          </security>  
        </binding>  
    </wsHttpBinding>  
    </bindings>  
  
    <behaviors>  
      <behavior name="ClientCertificateBehavior">  
        <clientCredentials>  
          <serviceCertificate>  
            <!--   
            Setting the certificateValidationMode to PeerOrChainTrust  
            means that if the certificate   
            is in the user's Trusted People store, then it will be   
            trusted without performing a  
            validation of the certificate's issuer chain. This setting   
            is used here for convenience so that the   
            sample can be run without having to have certificates   
            issued by a certification authority (CA).  
            This setting is less secure than the default, ChainTrust.   
            The security implications of this   
            setting should be carefully considered before using   
            PeerOrChainTrust in production code.   
            -->  
            <authentication certificateValidationMode = "PeerOrChainTrust" />  
          </serviceCertificate>  
        </clientCredentials>  
      </behavior>  
    </behaviors>  
  
  </system.serviceModel>  
```  
  
 For the user name-based endpoint, the client implementation sets the user name and password to use.  
  
```  
// Create a client with Username endpoint configuration  
CalculatorClient client1 = new CalculatorClient("Username");  
  
client1.ClientCredentials.UserName.UserName = "test1";  
client1.ClientCredentials.UserName.Password = "1tset";  
  
try  
{  
    // Call the Add service operation.  
    double value1 = 100.00D;  
    double value2 = 15.99D;  
    double result = client1.Add(value1, value2);  
    Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);  
    ...  
}  
catch (Exception e)  
{  
    Console.WriteLine("Call failed : {0}", e.Message);  
}  
  
client1.Close();  
```  
  
 For the certificate-based endpoint, the client implementation sets the client certificate to use.  
  
```  
// Create a client with Certificate endpoint configuration  
CalculatorClient client2 = new CalculatorClient("Certificate");  
  
client2.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindBySubjectName, "test1");  
  
try  
{  
    // Call the Add service operation.  
    double value1 = 100.00D;  
    double value2 = 15.99D;  
    double result = client2.Add(value1, value2);  
    Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);  
    ...  
}  
catch (Exception e)  
{  
    Console.WriteLine("Call failed : {0}", e.Message);  
}  
  
client2.Close();  
```  
  
 This sample uses a custom <xref:System.IdentityModel.Selectors.UserNamePasswordValidator> to validate user names and passwords. The sample implements `MyCustomUserNamePasswordValidator`, derived from <xref:System.IdentityModel.Selectors.UserNamePasswordValidator>. See the documentation about <xref:System.IdentityModel.Selectors.UserNamePasswordValidator> for more information. For the purposes of demonstrating the integration with the <xref:System.IdentityModel.Selectors.UserNamePasswordValidator>, this custom validator sample implements the <xref:System.IdentityModel.Selectors.UserNamePasswordValidator.Validate%2A> method to accept user name/password pairs where the user name matches the password as shown in the following code.  
  
```  
public class MyCustomUserNamePasswordValidator : UserNamePasswordValidator  
{  
  // This method validates users. It allows in two users,   
  // test1 and test2 with passwords 1tset and 2tset respectively.  
  // This code is for illustration purposes only and   
  // MUST NOT be used in a production environment because it   
  // is NOT secure.      
  public override void Validate(string userName, string password)  
  {  
    if (null == userName || null == password)  
    {  
      throw new ArgumentNullException();  
    }  
  
    if (!(userName == "test1" && password == "1tset") && !(userName == "test2" && password == "2tset"))  
    {  
      throw new SecurityTokenException("Unknown Username or Password");  
    }  
  }  
}  
```  
  
 Once the validator is implemented in service code, the service host must be informed about the validator instance to use. This is done using the following code.  
  
```  
Servicehost.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;  
serviceHost.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new MyCustomUserNamePasswordValidatorProvider();  
```  
  
 Or you can do the same thing in configuration.  
  
```xml  
<behavior ...>  
    <serviceCredentials>  
      <!--   
      The serviceCredentials behavior allows one to specify a custom validator for username/password combinations.    
      -->  
      <userNameAuthentication userNamePasswordValidationMode="Custom" customUserNamePasswordValidatorType="Microsoft.ServiceModel.Samples.MyCustomUserNameValidator, service" />  
    ...  
    </serviceCredentials>  
</behavior>  
```  
  
 [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] provides a rich claims-based model for performing access checks. The <xref:System.ServiceModel.ServiceAuthorizationManager> object is used to perform the access check and determine whether the claims associated with the client satisfy the requirements necessary to access the service method.  
  
 For the purposes of demonstration, this sample shows an implementation of <xref:System.ServiceModel.ServiceAuthorizationManager> that implements the <xref:System.ServiceModel.ServiceAuthorizationManager.CheckAccessCore%2A> method to allow a user's access to methods based on claims of type http://example.com/claims/allowedoperation whose value is the Action URI of the operation that is allowed to be called.  
  
```  
public class MyServiceAuthorizationManager : ServiceAuthorizationManager  
{  
  protected override bool CheckAccessCore(OperationContext operationContext)  
  {                  
    string action = operationContext.RequestContext.RequestMessage.Headers.Action;  
    Console.WriteLine("action: {0}", action);  
    foreach(ClaimSet cs in operationContext.ServiceSecurityContext.AuthorizationContext.ClaimSets)  
    {  
      if ( cs.Issuer == ClaimSet.System )  
      {  
        foreach (Claim c in cs.FindClaims("http://example.com/claims/allowedoperation", Rights.PossessProperty))  
        {  
          Console.WriteLine("resource: {0}", c.Resource.ToString());  
          if (action == c.Resource.ToString())  
            return true;  
        }  
      }  
    }  
    return false;                   
  }  
}  
```  
  
 Once the custom <xref:System.ServiceModel.ServiceAuthorizationManager> is implemented, the service host must be informed about the <xref:System.ServiceModel.ServiceAuthorizationManager> to use. This is done as shown in the following code.  
  
```xml  
<behavior ...>  
    ...  
    <serviceAuthorization serviceAuthorizationManagerType="Microsoft.ServiceModel.Samples.MyServiceAuthorizationManager, service">  
        ...  
    </serviceAuthorization>  
</behavior>  
```  
  
 The primary <xref:System.IdentityModel.Policy.IAuthorizationPolicy> method to implement is the <xref:System.IdentityModel.Policy.IAuthorizationPolicy.Evaluate%28System.IdentityModel.Policy.EvaluationContext%2CSystem.Object%40%29> method.  
  
```  
public class MyAuthorizationPolicy : IAuthorizationPolicy  
{  
    string id;  
  
    public MyAuthorizationPolicy()  
    {  
    id =  Guid.NewGuid().ToString();  
    }  
  
    public bool Evaluate(EvaluationContext evaluationContext,   
                                            ref object state)  
    {  
        bool bRet = false;  
        CustomAuthState customstate = null;  
  
        if (state == null)  
        {  
            customstate = new CustomAuthState();  
            state = customstate;  
        }  
        else  
            customstate = (CustomAuthState)state;  
        Console.WriteLine("In Evaluate");  
        if (!customstate.ClaimsAdded)  
        {  
           IList<Claim> claims = new List<Claim>();  
  
           foreach (ClaimSet cs in evaluationContext.ClaimSets)  
              foreach (Claim c in cs.FindClaims(ClaimTypes.Name,   
                                         Rights.PossessProperty))  
                  foreach (string s in   
                        GetAllowedOpList(c.Resource.ToString()))  
                  {  
                       claims.Add(new  
               Claim("http://example.com/claims/allowedoperation",   
                                    s, Rights.PossessProperty));  
                            Console.WriteLine("Claim added {0}", s);  
                      }  
                   evaluationContext.AddClaimSet(this,   
                           new DefaultClaimSet(this.Issuer,claims));  
                   customstate.ClaimsAdded = true;  
                   bRet = true;  
                }  
         else  
         {  
              bRet = true;  
         }  
         return bRet;  
     }  
...  
}  
```  
  
 The previous code shows how the <xref:System.IdentityModel.Policy.IAuthorizationPolicy.Evaluate%28System.IdentityModel.Policy.EvaluationContext%2CSystem.Object%40%29> method checks that no new claims have been added that affect the processing and adds specific claims. The claims that are allowed are obtained from the `GetAllowedOpList` method, which is implemented to return a specific list of operations that the user is allowed to perform. The authorization policy adds claims for accessing the particular operation. This is later used by the <xref:System.ServiceModel.ServiceAuthorizationManager> to perform access check decisions.  
  
 Once the custom <xref:System.IdentityModel.Policy.IAuthorizationPolicy> is implemented, the service host must be informed about the authorization policies to use.  
  
```xml  
<serviceAuthorization ...>  
       <authorizationPolicies>   
            <add policyType='Microsoft.ServiceModel.Samples.CustomAuthorizationPolicy.MyAuthorizationPolicy, PolicyLibrary' />  
       </authorizationPolicies>   
</serviceAuthorization>  
```  
  
 When you run the sample, the operation requests and responses are displayed in the client console window. The client successfully calls the Add, Subtract and Multiple methods and gets an "Access is denied" message when trying to call the Divide method. Press ENTER in the client window to shut down the client.  
  
## Setup Batch File  
 The Setup.bat batch file included with this sample allows you to configure the server with relevant certificates to run a self-hosted application that requires server certificate-based security.  
  
 The following provides a brief overview of the different sections of the batch files so that they can be modified to run in the appropriate configuration:  
  
-   Creating the server certificate.  
  
     The following lines from the Setup.bat batch file create the server certificate to be used. The %SERVER_NAME% variable specifies the server name. Change this variable to specify your own server name. The default value is localhost.  
  
    ```  
    echo ************  
    echo Server cert setup starting  
    echo %SERVER_NAME%  
    echo ************  
    echo making server cert  
    echo ************  
    makecert.exe -sr LocalMachine -ss MY -a sha1 -n CN=%SERVER_NAME% -sky exchange -pe  
    ```  
  
-   Installing the server certificate into client's trusted certificate store.  
  
     The following lines in the Setup.bat batch file copy the server certificate into the client trusted people store. This step is required because certificates that are generated by Makecert.exe are not implicitly trusted by the client system. If you already have a certificate that is rooted in a client trusted root certificate—for example, a Microsoft issued certificate—this step of populating the client certificate store with the server certificate is not required.  
  
    ```  
    certmgr.exe -add -r LocalMachine -s My -c -n %SERVER_NAME% -r CurrentUser -s TrustedPeople  
    ```  
  
-   Creating the client certificate.  
  
     The following lines from the Setup.bat batch file create the client certificate to be used. The %USER_NAME% variable specifies the server name. This value is set to "test1" because this is the name the `IAuthorizationPolicy` looks for. If you change the value of %USER_NAME% you must change the corresponding value in the `IAuthorizationPolicy.Evaluate` method.  
  
     The certificate is stored in My (Personal) store under the CurrentUser store location.  
  
    ```  
    echo ************  
    echo making client cert  
    echo ************  
    makecert.exe -sr CurrentUser -ss MY -a sha1 -n CN=%CLIENT_NAME% -sky exchange -pe  
    ```  
  
-   Installing the client certificate into server's trusted certificate store.  
  
     The following lines in the Setup.bat batch file copy the client certificate into the trusted people store. This step is required because certificates that are generated by Makecert.exe are not implicitly trusted by the server system. If you already have a certificate that is rooted in a trusted root certificate—for example, a Microsoft issued certificate—this step of populating the server certificate store with the client certificate is not required.  
  
    ```  
    certmgr.exe -add -r CurrentUser -s My -c -n %CLIENT_NAME% -r LocalMachine -s TrustedPeople  
    ```  
  
#### To set up and build the sample  
  
1.  To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
2.  To run the sample in a single- or cross-computer configuration, use the following instructions.  
  
> [!NOTE]
>  If you use Svcutil.exe to regenerate the configuration for this sample, be sure to modify the endpoint name in the client configuration to match the client code.  
  
#### To run the sample on the same computer  
  
1.  Open a [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] Command Prompt window with administrator privileges and run Setup.bat from the sample install folder. This installs all the certificates required for running the sample.  
  
    > [!NOTE]
    >  The Setup.bat batch file is designed to be run from a [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] Command Prompt. The PATH environment variable set within the [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] Command Prompt points to the directory that contains executables required by the Setup.bat script.  
  
2.  Run Setup.bat in a Visual Studio command prompt opened with administrator privileges from the sample install folder. This installs all the certificates required for running the sample.  
  
3.  Launch Service.exe from service\bin.  
  
4.  Launch Client.exe from \client\bin. Client activity is displayed on the client console application.  
  
5.  If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
#### To run the sample across computers  
  
1.  Create a directory on the service computer.  
  
2.  Copy the service program files from \service\bin to the directory on the service computer. Also copy the Setup.bat, Cleanup.bat, GetComputerName.vbs and ImportClientCert.bat files to the service computer.  
  
3.  Create a directory on the client computerfor the client binaries.  
  
4.  Copy the client program files to the client directory on the client computer. Also copy the Setup.bat, Cleanup.bat, and ImportServiceCert.bat files to the client.  
  
5.  On the server, run `setup.bat service` in a Visual Studio command prompt opened with administrator privileges. Running `setup.bat` with the `service` argument creates a service certificate with the fully-qualified domain name of the computerand exports the service certificate to a file named Service.cer.  
  
6.  Edit Service.exe.config to reflect the new certificate name (in the `findValue` attribute in the [\<serviceCertificate>](../../../../docs/framework/configure-apps/file-schema/wcf/servicecertificate-of-servicecredentials.md)) which is the same as the fully-qualified domain name of the computer. Also change the computername in the \<service>/\<baseAddresses> element from localhost to the fully-qualified name of your service computer.  
  
7.  Copy the Service.cer file from the service directory to the client directory on the client computer.  
  
8.  On the client, run `setup.bat client` in a Visual Studio command prompt opened with administrator privileges. Running `setup.bat` with the `client` argument creates a client certificate named test1 and exports the client certificate to a file named Client.cer.  
  
9. In the Client.exe.config file on the client computer, change the address value of the endpoint to match the new address of your service. Do this by replacing localhost with the fully-qualified domain name of the server.  
  
10. Copy the Client.cer file from the client directory to the service directory on the server.  
  
11. On the client, run ImportServiceCert.bat in a Visual Studio command prompt opened with administrator privileges. This imports the service certificate from the Service.cer file into the CurrentUser - TrustedPeople store.  
  
12. On the server, run ImportClientCert.bat in a Visual Studio command prompt opened with administrator privileges. This imports the client certificate from the Client.cer file into the LocalMachine - TrustedPeople store.  
  
13. On the server computer, launch Service.exe from the command prompt window.  
  
14. On the client computer, launch Client.exe from a command prompt window. If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
#### To clean up after the sample  
  
1.  Run Cleanup.bat in the samples folder once you have finished running the sample. This removes the server and client certificates from the certificate store.  
  
> [!NOTE]
>  This script does not remove service certificates on a client when running this sample across computers. If you have run [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] samples that use certificates across computers, be sure to clear the service certificates that have been installed in the CurrentUser - TrustedPeople store. To do this, use the following command: `certmgr -del -r CurrentUser -s TrustedPeople -c -n <Fully Qualified Server Machine Name>` For example: `certmgr -del -r CurrentUser -s TrustedPeople -c -n server1.contoso.com`.  
  
## See Also
