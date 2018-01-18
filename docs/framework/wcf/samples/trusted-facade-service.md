---
title: "Trusted Facade Service"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c34d1a8f-e45e-440b-a201-d143abdbac38
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Trusted Facade Service
This scenario sample demonstrates how to flow caller's identity information from one service to another using [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] security infrastructure.  
  
 It is a common design pattern to expose the functionality provided by a service to the public network using a façade service. The façade service typically resides in the perimeter network (also known as DMZ, demilitarized zone, and screened subnet) and communicates with a backend service that implements the business logic and has access to internal data. The communication channel between the façade service and the backend service goes through a firewall and is usually limited for a single purpose only.  
  
 This sample consists of the following components:  
  
-   Calculator client  
  
-   Calculator façade service  
  
-   Calculator backend service  
  
 The façade service is responsible for validating the request and authenticating the caller. After successful authentication and validation, it forwards the request to the backend service using the controlled communication channel from the perimeter network to the internal network. As a part of the forwarded request, the façade service includes information about the caller's identity so that the backend service can use this information in its processing. The caller's identity is transmitted using a `Username` security token inside the message `Security` header. The sample uses the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security infrastructure to transmit and extract this information from the `Security` header.  
  
> [!IMPORTANT]
>  The backend service trusts the façade service to authenticate the caller. Because of this, the backend service does not authenticate the caller again; it uses the identity information provided by the façade service in the forwarded request. Because of this trust relationship, the backend service must authenticate the façade service to ensure that the forwarded message comes from a trusted source - in this case, the façade service.  
  
## Implementation  
 There are two communication paths in this sample. First is between the client and the façade service, the second is between the façade service and the backend service.  
  
### Communication Path between Client and Façade Service  
 The client to the façade service communication path uses `wsHttpBinding` with a `UserName` client credential type. This means that the client uses username and password to authenticate to the façade service and the façade service uses X.509 certificate to authenticate to the client. The binding configuration looks like the following example.  
  
```xml  
<bindings>  
  <wsHttpBinding>  
    <binding name="Binding1">  
      <security mode="Message">  
        <message clientCredentialType="UserName"/>  
      </security>  
    </binding>  
  </wsHttpBinding>  
</bindings>  
```  
  
 The façade service authenticates the caller using custom `UserNamePasswordValidator` implementation. For demonstration purposes, the authentication only ensures that the caller's username matches the presented password. In the real world situation, the user is probably authenticated using Active Directory or custom ASP.NET Membership provider. The validator implementation resides in `FacadeService.cs` file.  
  
```  
public class MyUserNamePasswordValidator : UserNamePasswordValidator  
{  
    public override void Validate(string userName, string password)  
    {  
        // check that username matches password  
        if (null == userName || userName != password)  
        {  
            Console.WriteLine("Invalid username or password");  
            throw new SecurityTokenValidationException(  
                       "Invalid username or password");  
        }  
    }  
}  
```  
  
 The custom validator is configured to be used inside the `serviceCredentials` behavior in the façade service configuration file. This behavior is also used to configure the service's X.509 certificate.  
  
```xml  
<behaviors>  
  <serviceBehaviors>  
    <behavior name="FacadeServiceBehavior">  
      <!--The serviceCredentials behavior allows you to define -->  
      <!--a service certificate. -->  
      <!--A service certificate is used by the service to  -->  
      <!--authenticate itself to its clients and to provide  -->  
      <!--message protection. -->  
      <!--This configuration references the "localhost"  -->  
      <!--certificate installed during the setup instructions. -->  
      <serviceCredentials>  
        <serviceCertificate   
               findValue="localhost"   
               storeLocation="LocalMachine"   
               storeName="My"   
               x509FindType="FindBySubjectName" />  
        <userNameAuthentication userNamePasswordValidationMode="Custom"  
            customUserNamePasswordValidatorType=  
           "Microsoft.ServiceModel.Samples.MyUserNamePasswordValidator,  
            FacadeService"/>  
      </serviceCredentials>  
    </behavior>  
  </serviceBehaviors>  
</behaviors>  
```  
  
### Communication Path between Façade Service and Backend Service  
 The façade service to the backend service communication path uses a `customBinding` that consists of several binding elements. This binding accomplishes two things. It authenticates the façade service and backend service to ensure that the communication is secure and is coming from a trusted source. Additionally, it also transmits the initial caller's identity inside the `Username` security token. In this case, only the initial caller's username is transmitted to the backend service, the password is not included in the message. This is because the backend service trusts the façade service to authenticate the caller before forwarding the request to it. Because the façade service authenticates itself to the backend service, the backend service can trust the information contained in the forwarded request.  
  
 The following is the binding configuration for this communication path.  
  
```xml  
<bindings>  
  <customBinding>  
    <binding name="ClientBinding">  
      <security authenticationMode="UserNameOverTransport"/>  
      <windowsStreamSecurity/>  
      <tcpTransport/>  
    </binding>  
  </customBinding>  
</bindings>  
```  
  
 The [\<security>](../../../../docs/framework/configure-apps/file-schema/wcf/security-of-custombinding.md) binding element takes care of the initial caller's username transmission and extraction. The [\<windowsStreamSecurity>](../../../../docs/framework/configure-apps/file-schema/wcf/windowsstreamsecurity.md) and [\<tcpTransport>](../../../../docs/framework/configure-apps/file-schema/wcf/tcptransport.md) take care of authenticating façade and backend services and message protection.  
  
 To forward the request, the façade service implementation must provide the initial caller's username so that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security infrastructure can place this into the forwarded message. The initial caller's username is provided in the façade service implementation by setting it in the `ClientCredentials` property on the client proxy instance that façade service uses to communicate with the backend service.  
  
 The following code shows how `GetCallerIdentity` method is implemented on the façade service. Other methods use the same pattern.  
  
```  
public string GetCallerIdentity()  
{  
    CalculatorClient client = new CalculatorClient();  
    client.ClientCredentials.UserName.UserName = ServiceSecurityContext.Current.PrimaryIdentity.Name;  
    string result = client.GetCallerIdentity();  
    client.Close();  
    return result;  
}  
```  
  
 As shown in the previous code, the password is not set on the `ClientCredentials` property, only the username is set. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security infrastructure creates a username security token without a password in this case, which is exactly what is required in this scenario.  
  
 On the backend service, the information contained in the username security token must be authenticated. By default, [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security attempts to map the user to a Windows account using the provided password. In this case, there is no password provided and the backend service is not required to authenticate the username because the authentication was already performed by the façade service. To implement this functionality in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], a custom `UserNamePasswordValidator` is provided that only enforces that a username is specified in the token and does not perform any additional authentication.  
  
```  
public class MyUserNamePasswordValidator : UserNamePasswordValidator  
{  
    public override void Validate(string userName, string password)  
    {  
        // Ignore the password because it is empty,   
        // we trust the facade service to authenticate the client.  
        // Accept the username information here so that the   
        // application gets access to it.  
        if (null == userName)  
        {  
            Console.WriteLine("Invalid username");  
            throw new   
             SecurityTokenValidationException("Invalid username");  
        }  
    }  
}  
```  
  
 The custom validator is configured to be used inside the `serviceCredentials` behavior in the façade service configuration file.  
  
```xml  
<behaviors>  
  <serviceBehaviors>  
    <behavior name="BackendServiceBehavior">  
      <serviceCredentials>  
        <userNameAuthentication userNamePasswordValidationMode="Custom"  
           customUserNamePasswordValidatorType=  
          "Microsoft.ServiceModel.Samples.MyUserNamePasswordValidator,   
           BackendService"/>  
      </serviceCredentials>  
    </behavior>  
  </serviceBehaviors>  
</behaviors>  
```  
  
 To extract the username information and information about the trusted façade service account, the backend service implementation uses the `ServiceSecurityContext` class. The following code shows how the `GetCallerIdentity` method is implemented.  
  
```  
public string GetCallerIdentity()  
{  
    // Facade service is authenticated using Windows authentication.  
    //Its identity is accessible.  
    // On ServiceSecurityContext.Current.WindowsIdentity.  
    string facadeServiceIdentityName =   
          ServiceSecurityContext.Current.WindowsIdentity.Name;  
  
    // The client name is transmitted using Username authentication on   
    //the message level without the password  
    // using a supporting encrypted UserNameToken.  
    // Claims extracted from this supporting token are available in   
    // ServiceSecurityContext.Current.AuthorizationContext.ClaimSets   
    // collection.  
    string clientName = null;  
    foreach (ClaimSet claimSet in   
        ServiceSecurityContext.Current.AuthorizationContext.ClaimSets)  
    {  
        foreach (Claim claim in claimSet)  
        {  
            if (claim.ClaimType == ClaimTypes.Name &&   
                                   claim.Right == Rights.Identity)  
            {  
                clientName = (string)claim.Resource;  
                break;  
            }  
        }  
    }  
    if (clientName == null)  
    {  
        // In case there was no UserNameToken attached to the request.  
        // In the real world implementation the service should reject   
        // this request.  
        return "Anonymous caller via " + facadeServiceIdentityName;  
    }  
  
    return clientName + " via " + facadeServiceIdentityName;  
}  
```  
  
 The façade service account information is extracted using the `ServiceSecurityContext.Current.WindowsIdentity` property. To access the information about the initial caller the backend service uses the `ServiceSecurityContext.Current.AuthorizationContext.ClaimSets` property. It looks for an `Identity` claim with a type `Name`. This claim is automatically generated by [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] security infrastructure from the information contained in the `Username` security token.  
  
## Running the sample  
 When you run the sample, the operation requests and responses are displayed in the client console window. Press ENTER in the client window to shut down the client. You can press ENTER in the façade and backend service console windows to shut down the services.  
  
```  
Username authentication required.  
Provide a valid machine or domain ac  
   Enter username:  
user  
   Enter password:  
****  
user via MyMachine\testaccount  
Add(100,15.99) = 115.99  
Subtract(145,76.54) = 68.46  
Multiply(9,81.25) = 731.25  
Divide(22,7) = 3.14285714285714  
  
Press <ENTER> to terminate client.  
```  
  
 The Setup.bat batch file included with the Trusted Facade scenario sample enables you to configure the server with a relevant certificate to run the façade service that requires certificate-based security to authenticate itself to the client. See the setup procedure at the end of this topic for details.  
  
 The following provides a brief overview of the different sections of the batch files.  
  
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
  
     The `%SERVER_NAME%` variable specifies the server name - the default value is localhost. The certificate is stored in the LocalMachine store.  
  
-   Installing the façade service's certificate into the client's trusted certificate store.  
  
     The following line copies the façade service's certificate into the client trusted people store. This step is required because certificates generated by Makecert.exe are not implicitly trusted by the client system. If you already have a certificate that is rooted in a client trusted root certificate—for example, a Microsoft-issued certificate—this step of populating the client certificate store with the server certificate is not required.  
  
    ```  
    certmgr.exe -add -r LocalMachine -s My -c -n %SERVER_NAME% -r CurrentUser -s TrustedPeople  
    ```  
  
#### To set up, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
#### To run the sample on the same machine  
  
1.  Ensure that the path includes the folder where Makecert.exe is located.  
  
2.  Run Setup.bat from the sample install folder. This installs all the certificates required for running the sample.  
  
3.  Launch the BackendService.exe from \BackendService\bin directory in a separate console window  
  
4.  Launch the FacadeService.exe from \FacadeService\bin directory in a separate console window  
  
5.  Launch Client.exe from \client\bin. Client activity is displayed on the client console application.  
  
6.  If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
#### To clean up after the sample  
  
1.  Run Cleanup.bat in the samples folder once you have finished running the sample.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Scenario\TrustedFacade`  
  
## See Also
