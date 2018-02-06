---
title: "Token Authenticator"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 84382f2c-f6b1-4c32-82fa-aebc8f6064db
caps.latest.revision: 22
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Token Authenticator
This sample demonstrates how to implement a custom token authenticator. A token authenticator in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] is used for validating the token used with the message, verifying that it is self-consistent, and authenticating the identity associated with the token.  
  
 Custom token authenticators are useful in a variety of cases, such as:  
  
-   When you want to override the default authentication mechanism associated with a token.  
  
-   When you are building a custom token.  
  
 This sample demonstrates the following:  
  
-   How a client can authenticate using a username/password pair.  
  
-   How the server can validate the client credentials using a custom token authenticator.  
  
-   How the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service code ties in with the custom token authenticator.  
  
-   How the server can be authenticated using the server's X.509 certificate.  
  
 This sample also shows how the caller's identity is accessible from [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] after the custom token authentication process.  
  
 The service exposes a single endpoint for communicating with the service, defined using the App.config configuration file. The endpoint consists of an address, a binding, and a contract. The binding is configured with a standard `wsHttpBinding`, with the security mode set to message - the default mode of the `wsHttpBinding`. This sample sets the standard `wsHttpBinding` to use client username authentication. The service also configures the service certificate using `serviceCredentials` behavior. The `securityCredentials` behavior allows you to specify a service certificate. A service certificate is used by a client to authenticate the service and provide message protection. The following configuration references the localhost certificate installed during the sample setup as described in the following setup instructions.  
  
```xml  
<system.serviceModel>  
    <services>  
      <service   
          name="Microsoft.ServiceModel.Samples.CalculatorService"  
          behaviorConfiguration="CalculatorServiceBehavior">  
        <host>  
          <baseAddresses>  
            <!-- configure base address provided by host -->  
            <add baseAddress ="http://localhost:8000/servicemodelsamples/service" />  
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
....        -->  
          <serviceCredentials>  
            <serviceCertificate findValue="localhost" storeLocation="LocalMachine" storeName="My" x509FindType="FindBySubjectName" />  
          </serviceCredentials>  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
  
  </system.serviceModel>  
```  
  
 The client endpoint configuration consists of a configuration name, an absolute address for the service endpoint, the binding, and the contract. The client binding is configured with the appropriate `Mode` and `clientCredentialType`.  
  
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
  
 The client implementation sets the user name and password to use.  
  
```  
static void Main()  
{  
     ...  
     client.ClientCredentials.UserNamePassword.UserName = username;  
     client.ClientCredentials.UserNamePassword.Password = password;  
     ...  
}  
```  
  
## Custom Token Authenticator  
 Use the following steps to create a custom token authenticator:  
  
1.  Write a custom token authenticator.  
  
     The sample implements a custom token authenticator that validates that the username has a valid email format. It derives the <xref:System.IdentityModel.Selectors.UserNameSecurityTokenAuthenticator>. The most important method in this class is <xref:System.IdentityModel.Selectors.UserNameSecurityTokenAuthenticator.ValidateUserNamePasswordCore%28System.String%2CSystem.String%29>. In this method, the authenticator validates the format of the username and also that the host name is not from a rogue domain. If both conditions are met, then it returns a read-only collection of <xref:System.IdentityModel.Policy.IAuthorizationPolicy> instances that is then used to provide claims that represent the information stored inside the username token.  
  
    ```  
    protected override ReadOnlyCollection<IAuthorizationPolicy> ValidateUserNamePasswordCore(string userName, string password)  
    {  
        if (!ValidateUserNameFormat(userName))  
            throw new SecurityTokenValidationException("Incorrect UserName format");  
  
        ClaimSet claimSet = new DefaultClaimSet(ClaimSet.System, new Claim(ClaimTypes.Name, userName, Rights.PossessProperty));  
        List<IIdentity> identities = new List<IIdentity>(1);  
        identities.Add(new GenericIdentity(userName));  
        List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>(1);  
        policies.Add(new UnconditionalPolicy(ClaimSet.System, claimSet, DateTime.MaxValue.ToUniversalTime(), identities));  
        return policies.AsReadOnly();  
    }  
    ```  
  
2.  Provide an authorization policy that is returned by custom token authenticator.  
  
     This sample provides its own implementation of <xref:System.IdentityModel.Policy.IAuthorizationPolicy> called `UnconditionalPolicy` that returns set of claims and identities that were passed to it in its constructor.  
  
    ```  
    class UnconditionalPolicy : IAuthorizationPolicy  
    {  
        String id = Guid.NewGuid().ToString();  
        ClaimSet issuer;  
        ClaimSet issuance;  
        DateTime expirationTime;  
        IList<IIdentity> identities;  
  
        public UnconditionalPolicy(ClaimSet issuer, ClaimSet issuance, DateTime expirationTime, IList<IIdentity> identities)  
        {  
            if (issuer == null)  
                throw new ArgumentNullException("issuer");  
            if (issuance == null)  
                throw new ArgumentNullException("issuance");  
  
            this.issuer = issuer;  
            this.issuance = issuance;  
            this.identities = identities;  
            this.expirationTime = expirationTime;  
        }  
  
        public string Id  
        {  
            get { return this.id; }  
        }  
  
        public ClaimSet Issuer  
        {  
            get { return this.issuer; }  
        }  
  
        public DateTime ExpirationTime  
        {  
            get { return this.expirationTime; }  
        }  
  
        public bool Evaluate(EvaluationContext evaluationContext, ref object state)  
        {  
            evaluationContext.AddToTarget(this, this.issuance);  
  
            if (this.identities != null)  
            {  
                object value;  
                IList<IIdentity> contextIdentities;  
                if (!evaluationContext.Properties.TryGetValue("Identities", out value))  
                {  
                    contextIdentities = new List<IIdentity>(this.identities.Count);  
                    evaluationContext.Properties.Add("Identities", contextIdentities);  
                }  
                else  
                {  
                    contextIdentities = value as IList<IIdentity>;  
                }  
                foreach (IIdentity identity in this.identities)  
                {  
                    contextIdentities.Add(identity);  
                }  
            }  
  
            evaluationContext.RecordExpirationTime(this.expirationTime);  
            return true;  
        }  
    }  
    ```  
  
3.  Write a custom security token manager.  
  
     The <xref:System.IdentityModel.Selectors.SecurityTokenManager> is used to create a <xref:System.IdentityModel.Selectors.SecurityTokenAuthenticator> for specific <xref:System.IdentityModel.Selectors.SecurityTokenRequirement> objects that are passed to it in the `CreateSecurityTokenAuthenticator` method. The security token manager is also used to create token providers and token serializers, but those are not covered by this sample. In this sample, the custom security token manager inherits from <xref:System.ServiceModel.Security.ServiceCredentialsSecurityTokenManager> class and overrides the `CreateSecurityTokenAuthenticator` method to return custom username token authenticator when the passed token requirements indicate that username authenticator is requested.  
  
    ```  
    public class MySecurityTokenManager : ServiceCredentialsSecurityTokenManager  
    {  
        MyUserNameCredential myUserNameCredential;  
  
        public MySecurityTokenManager(MyUserNameCredential myUserNameCredential)  
            : base(myUserNameCredential)  
        {  
            this.myUserNameCredential = myUserNameCredential;  
        }  
  
        public override SecurityTokenAuthenticator CreateSecurityTokenAuthenticator(SecurityTokenRequirement tokenRequirement, out SecurityTokenResolver outOfBandTokenResolver)  
        {  
            if (tokenRequirement.TokenType ==  SecurityTokenTypes.UserName)  
            {  
                outOfBandTokenResolver = null;  
                return new MyTokenAuthenticator();  
            }  
            else  
            {  
                return base.CreateSecurityTokenAuthenticator(tokenRequirement, out outOfBandTokenResolver);  
            }  
        }  
    }  
    ```  
  
4.  Write a custom service credential.  
  
     The service credentials class is used to represent the credentials that are configured for the service and creates a security token manager that is used to obtain token authenticators, token providers and token serializers.  
  
    ```  
    public class MyUserNameCredential : ServiceCredentials  
    {  
  
        public MyUserNameCredential()  
            : base()  
        {  
        }  
  
        protected override ServiceCredentials CloneCore()  
        {  
            return new MyUserNameCredential();  
        }  
  
        public override SecurityTokenManager CreateSecurityTokenManager()  
        {  
            return new MySecurityTokenManager(this);  
        }  
  
    }  
    ```  
  
5.  Configure the service to use the custom service credential.  
  
     In order for the service to use the custom service credential, we delete the default service credential class after capturing the service certificate that is already preconfigured in the default service credential, and configure the new service credential instance to use the preconfigured service certificates and add this new service credential instance to service behaviors.  
  
    ```  
    ServiceCredentials sc = serviceHost.Credentials;  
    X509Certificate2 cert = sc.ServiceCertificate.Certificate;  
    MyUserNameCredential serviceCredential = new MyUserNameCredential();  
    serviceCredential.ServiceCertificate.Certificate = cert;  
    serviceHost.Description.Behaviors.Remove((typeof(ServiceCredentials)));  
    serviceHost.Description.Behaviors.Add(serviceCredential);  
    ```  
  
 To display the caller's information, you can use the <xref:System.ServiceModel.ServiceSecurityContext.PrimaryIdentity%2A> as shown in the following code. The <xref:System.ServiceModel.ServiceSecurityContext.Current%2A> contains claims information about the current caller.  
  
```  
static void DisplayIdentityInformation()  
{  
    Console.WriteLine("\t\tSecurity context identity  :  {0}",   
            ServiceSecurityContext.Current.PrimaryIdentity.Name);  
     return;  
}  
```  
  
 When you run the sample, the operation requests and responses are displayed in the client console window. Press ENTER in the client window to shut down the client.  
  
## Setup Batch File  
 The Setup.bat batch file included with this sample allows you to configure the server with relevant certificates to run a self-hosted application that requires server certificate based security. This batch file must be modified to work across computers or to work in a non-hosted case.  
  
 The following provides a brief overview of the different sections of the batch files so that they can be modified to run in appropriate configuration.  
  
-   Creating the server certificate.  
  
     The following lines from the Setup.bat batch file create the server certificate to be used. The `%SERVER_NAME%` variable specifies the server name. Change this variable to specify your own server name. The default in this batch file is localhost.  
  
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
  
     The following lines in the Setup.bat batch file copy the server certificate into the client trusted people store. This step is required because certificates generated by Makecert.exe are not implicitly trusted by the client system. If you already have a certificate that is rooted in a client trusted root certificate—for example, a Microsoft issued certificate—this step of populating the client certificate store with the server certificate is not required.  
  
    ```  
    certmgr.exe -add -r LocalMachine -s My -c -n %SERVER_NAME% -r CurrentUser -s TrustedPeople  
    ```  
  
    > [!NOTE]
    >  The setup batch file is designed to be run from a Windows SDK Command Prompt. It requires that the MSSDK environment variable point to the directory where the SDK is installed. This environment variable is automatically set within a Windows SDK Command Prompt.  
  
#### To set up and build the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
#### To run the sample on the same computer  
  
1.  Run Setup.bat from the sample installation folder inside a [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] command prompt opened with administrator privileges. This installs all the certificates required for running the sample.  
  
    > [!NOTE]
    >  The Setup.bat batch file is designed to be run from a [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] Command Prompt. The PATH environment variable set within the [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] Command Prompt points to the directory that contains executables required by the Setup.bat script.  
  
2.  Launch service.exe from service\bin.  
  
3.  Launch client.exe from \client\bin. Client activity is displayed on the client console application.  
  
4.  If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
#### To run the sample across computers  
  
1.  Create a directory on the service computer for the service binaries.  
  
2.  Copy the service program files to the service directory on the service computer. Also copy the Setup.bat and Cleanup.bat files to the service computer.  
  
3.  You must have a server certificate with the subject name that contains the fully-qualified domain name of the computer. The service App.config file must be updated to reflect this new certificate name. You can create one by using the Setup.bat if you set the `%SERVER_NAME%` variable to fully-qualified host name of the computer on which the service will run. Note that the setup.bat file must be run from a Visual Studio command prompt opened with administrator privileges.  
  
4.  Copy the server certificate into the CurrentUser-TrustedPeople store of the client. You do not need to do this except when the server certificate is issued by a client trusted issuer.  
  
5.  In the App.config file on the service computer, change the value of the base address to specify a fully-qualified computer name instead of localhost.  
  
6.  On the service computer, run service.exe from a command prompt.  
  
7.  Copy the client program files from the \client\bin\ folder, under the language-specific folder, to the client computer.  
  
8.  In the Client.exe.config file on the client computer, change the address value of the endpoint to match the new address of your service.  
  
9. On the client computer, launch Client.exe from a command prompt.  
  
10. If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
#### To clean up after the sample  
  
1.  Run Cleanup.bat in the samples folder once you have finished running the sample.  
  
## See Also
