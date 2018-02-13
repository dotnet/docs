---
title: "Token Provider"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 947986cf-9946-4987-84e5-a14678d96edb
caps.latest.revision: 22
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Token Provider
This sample demonstrates how to implement a custom token provider. A token provider in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] is used for supplying credentials to the security infrastructure. The token provider in general examines the target and issues appropriate credentials so that the security infrastructure can secure the message. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] ships with the default Credential Manager Token Provider. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] also ships with an [!INCLUDE[infocard](../../../../includes/infocard-md.md)] token provider. Custom token providers are useful in the following cases:  
  
-   If you have a credential store that these token providers cannot operate with.  
  
-   If you want to provide your own custom mechanism for transforming the credentials from the point when the user provides the details to when the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client framework uses the credentials.  
  
-   If you are building a custom token.  
  
 This sample shows how to build a custom token provider that transforms the input from the user into a different format.  
  
 To summarize, this sample demonstrates the following:  
  
-   How a client can authenticate using a username/password pair.  
  
-   How a client can be configured with a custom token provider.  
  
-   How the server can validate the client credentials using a password with a custom <xref:System.IdentityModel.Selectors.UserNamePasswordValidator> that validates that the username and password match.  
  
-   How the server is authenticated by the client using the server's X.509 certificate.  
  
 This sample also shows how the caller's identity is accessible after the custom token authentication process.  
  
 The service exposes a single endpoint for communicating with the service, defined using the App.config configuration file. The endpoint consists of an address, a binding, and a contract. The binding is configured with a standard `wsHttpBinding`, which uses message security by default. This sample sets the standard `wsHttpBinding` to use client username authentication. The service also configures the service certificate using the serviceCredentials behavior. The serviceCredentials behavior allows you to configure a service certificate. A service certificate is used by a client to authenticate the service and provide message protection. The following configuration references the localhost certificate installed during the sample setup as described in the following setup instructions.  
  
```xml  
<system.serviceModel>  
    <services>  
      <service   
          name="Microsoft.ServiceModel.Samples.CalculatorService"  
          behaviorConfiguration="CalculatorServiceBehavior">  
        <host>  
          <baseAddresses>  
            <!-- configure base address provided by host -->  
            <add baseAddress ="http://localhost:8000/servicemodelsamples/service"/>  
          </baseAddresses>  
        </host>  
        <!-- use base address provided by host -->  
        <endpoint address=""  
                  binding="wsHttpBinding"  
                  bindingConfiguration="Binding1"   
                  contract="Microsoft.ServiceModel.Samples.ICalculator" />  
      </service>  
    </services>  
  
    <bindings>  
      <wsHttpBinding>  
        <binding name="Binding1">  
          <security mode="Message">  
            <message clientCredentialType="UserName" />  
          </security>  
        </binding>  
      </wsHttpBinding>  
    </bindings>  
  
    <behaviors>  
      <serviceBehaviors>  
        <behavior name="CalculatorServiceBehavior">  
          <serviceDebug includeExceptionDetailInFaults="False" />  
          <!--   
        The serviceCredentials behavior allows one to define a service certificate.  
        A service certificate is used by a client to authenticate the service and provide message protection.  
        This configuration references the "localhost" certificate installed during the setup instructions.  
        -->  
          <serviceCredentials>  
            <serviceCertificate findValue="localhost" storeLocation="LocalMachine" storeName="My" x509FindType="FindBySubjectName" />  
          </serviceCredentials>  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
  </system.serviceModel>  
```  
  
 The client endpoint configuration consists of a configuration name, an absolute address for the service endpoint, the binding, and the contract. The client binding is configured with the appropriate `Mode` and message `clientCredentialType`.  
  
```xml  
<system.serviceModel>  
  <client>  
    <endpoint name=""  
              address="http://localhost:8000/servicemodelsamples/service"   
              binding="wsHttpBinding"   
              bindingConfiguration="Binding1"   
              contract="Microsoft.ServiceModel.Samples.ICalculator">  
    </endpoint>  
  </client>  
  
  <bindings>  
    <wsHttpBinding>  
      <binding name="Binding1">  
        <security mode="Message">  
          <message clientCredentialType="UserName" />  
        </security>  
      </binding>  
    </wsHttpBinding>  
  </bindings>  
</system.serviceModel>  
```  
  
 The following steps show how to develop a custom token provider and integrate it with the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security framework:  
  
1.  Write a custom token provider.  
  
     The sample implements a custom token provider that obtains the username and password. The password must match this username. This custom token provider is for demonstration purposes only and is not recommended for real world deployment.  
  
     To perform this task, the custom token provider derives the <xref:System.IdentityModel.Selectors.SecurityTokenProvider> class and overrides the <xref:System.IdentityModel.Selectors.SecurityTokenProvider.GetTokenCore%28System.TimeSpan%29> method. This method creates and returns a new `UserNameSecurityToken`.  
  
    ```  
    protected override SecurityToken GetTokenCore(TimeSpan timeout)  
    {  
        // obtain username and password from the user using console window  
        string username = GetUserName();  
        string password = GetPassword();  
        Console.WriteLine("username: {0}", username);  
  
        // return new UserNameSecurityToken containing information obtained from user  
        return new UserNameSecurityToken(username, password);  
    }  
    ```  
  
2.  Write custom security token manager.  
  
     The <xref:System.IdentityModel.Selectors.SecurityTokenManager> is used to create <xref:System.IdentityModel.Selectors.SecurityTokenProvider> for specific <xref:System.IdentityModel.Selectors.SecurityTokenRequirement> that is passed to it in `CreateSecurityTokenProvider` method. Security token manager is also used to create token authenticators and a token serializer, but those are not covered by this sample. In this sample, the custom security token manager inherits from <xref:System.ServiceModel.ClientCredentialsSecurityTokenManager> class and overrides the `CreateSecurityTokenProvider` method to return custom username token provider when the passed token requirements indicate that username provider is requested.  
  
    ```  
    public class MyUserNameSecurityTokenManager : ClientCredentialsSecurityTokenManager  
    {  
        MyUserNameClientCredentials myUserNameClientCredentials;  
  
        public MyUserNameSecurityTokenManager(MyUserNameClientCredentials myUserNameClientCredentials)  
            : base(myUserNameClientCredentials)  
        {  
            this.myUserNameClientCredentials = myUserNameClientCredentials;  
        }  
  
        public override SecurityTokenProvider CreateSecurityTokenProvider(SecurityTokenRequirement tokenRequirement)  
        {  
            // if token requirement matches username token return custom username token provider  
            // otherwise use base implementation  
            if (tokenRequirement.TokenType == SecurityTokenTypes.UserName)  
            {  
                return new MyUserNameTokenProvider();  
            }  
            else  
            {  
                return base.CreateSecurityTokenProvider(tokenRequirement);  
            }  
        }  
    }  
    ```  
  
3.  Write a custom client credential.  
  
     Client credentials class is used to represent the credentials that are configured for the client proxy and creates security token manager that is used to obtain token authenticators, token providers and a token serializer.  
  
    ```  
    public class MyUserNameClientCredentials : ClientCredentials  
    {  
        public MyUserNameClientCredentials()  
            : base()  
        {  
        }  
  
        protected override ClientCredentials CloneCore()  
        {  
            return new MyUserNameClientCredentials();  
        }  
  
        public override SecurityTokenManager CreateSecurityTokenManager()  
        {  
            // return custom security token manager  
            return new MyUserNameSecurityTokenManager(this);  
        }  
    }  
    ```  
  
4.  Configure the client to use the custom client credential.  
  
     In order for the client to use the custom client credential, the sample deletes the default client credential class and supplies the new client credential class.  
  
    ```  
    static void Main()  
    {  
        // ...  
           // Create a client with given client endpoint configuration  
          CalculatorClient client = new CalculatorClient();  
  
          // set new credentials  
           client.ChannelFactory.Endpoint.Behaviors.Remove(typeof(ClientCredentials));  
         client.ChannelFactory.Endpoint.Behaviors.Add(new MyUserNameClientCredentials());  
       // ...  
    }  
    ```  
  
 On the service, to display the caller's information, use the <xref:System.ServiceModel.ServiceSecurityContext.PrimaryIdentity%2A> as shown in the following code example. The <xref:System.ServiceModel.ServiceSecurityContext.Current%2A> contains claims information about the current caller.  
  
```  
static void DisplayIdentityInformation()  
{  
    Console.WriteLine("\t\tSecurity context identity  :  {0}",   
        ServiceSecurityContext.Current.PrimaryIdentity.Name);  
}  
```  
  
 When you run the sample, the operation requests and responses are displayed in the client console window. Press ENTER in the client window to shut down the client.  
  
## Setup Batch File  
 The Setup.bat batch file included with this sample allows you to configure the server with the relevant certificate to run a self-hosted application that requires server certificate-based security. This batch file must be modified to work across computers or to work in a non-hosted case.  
  
 The following provides a brief overview of the different sections of the batch files so that they can be modified to run in the appropriate configuration:  
  
-   Creating the server certificate.  
  
     The following lines from the Setup.bat batch file create the server certificate to be used. The `%SERVER_NAME%` variable specifies the server name. Change this variable to specify your own server name. The default value in this batch file is localhost.  
  
    ```  
    echo ************  
    echo Server cert setup starting  
    echo %SERVER_NAME%  
    echo ************  
    echo making server cert  
    echo ************  
    makecert.exe -sr LocalMachine -ss MY -a sha1 -n CN=%SERVER_NAME% -sky exchange -pe  
    ```  
  
-   Installing the server certificate into the client's trusted certificate store:  
  
     The following lines in the Setup.bat batch file copy the server certificate into the client trusted people store. This step is required because certificates generated by Makecert.exe are not implicitly trusted by the client system. If you already have a certificate that is rooted in a client trusted root certificate—for example, a Microsoft issued certificate—this step of populating the client certificate store with the server certificate is not required.  
  
    ```  
    certmgr.exe -add -r LocalMachine -s My -c -n %SERVER_NAME% -r CurrentUser -s TrustedPeople  
    ```  
  
> [!NOTE]
>  The Setup.bat batch file is designed to be run from a Windows SDK Command Prompt. It requires that the MSSDK environment variable point to the directory where the SDK is installed. This environment variable is automatically set within a Windows SDK Command Prompt.  
  
#### To set up and build the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
#### To run the sample on the same computer  
  
1.  Run Setup.bat from the sample installation folder inside a [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] command prompt opened with administrator privileges. This installs all the certificates required for running the sample.  
  
    > [!NOTE]
    >  The Setup.bat batch file is designed to be run from a [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] Command Prompt. The PATH environment variable set within the [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] Command Prompt points to the directory that contains executables required by the Setup.bat script.  
  
2.  Launch service.exe from service\bin.  
  
3.  Launch Client.exe from \client\bin. Client activity is displayed on the client console application.  
  
4.  At the username prompt, type a user name.  
  
5.  At the password prompt, use the same string that was typed for the username prompt.  
  
6.  If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
#### To run the sample across computers  
  
1.  Create a directory on the service computer for the service binaries.  
  
2.  Copy the service program files to the service directory on the service computer. Also copy the Setup.bat and Cleanup.bat files to the service computer.  
  
3.  You must have a server certificate with the subject name that contains the fully-qualified domain name of the computer. The Service.exe.config file must be updated to reflect this new certificate name. You can create server certificate by modifying the Setup.bat batch file. Note that the setup.bat file must be run from a Visual Studio command prompt opened with administrator privileges. You must set `%SERVER_NAME%` variable to fully-qualified host name of the computer that is used to host the service.  
  
4.  Copy the server certificate into the CurrentUser-TrustedPeople store of the client. You do not need to do this when the server certificate is issued by a client trusted issuer.  
  
5.  In the Service.exe.config file on the service computer, change the value of the base address to specify a fully-qualified computer name instead of localhost.  
  
6.  On the service computer, run service.exe from a command prompt.  
  
7.  Copy the client program files from the \client\bin\ folder, under the language-specific folder, to the client computer.  
  
8.  In the Client.exe.config file on the client computer, change the address value of the endpoint to match the new address of your service.  
  
9. On the client computer, launch `Client.exe` from a command prompt window.  
  
10. If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
#### To clean up after the sample  
  
1.  Run Cleanup.bat in the samples folder once you have finished running the sample.  
  
## See Also
