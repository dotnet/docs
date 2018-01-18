---
title: "Service Identity Sample"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 79fa8c1c-85bb-4b67-bc67-bfaf721303f8
caps.latest.revision: 24
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Service Identity Sample
This service identity sample demonstrates how to set the identity for a service. At design time, a client can retrieve the identity using the service's metadata and then at runtime the client can authenticate the service's identity. The concept of service identity is to allow a client to authenticate a service before calling any of its operations, thereby protecting the client from unauthenticated calls. On a secure connection the service also authenticates a client's credentials before allowing it access, but this is not the focus of this sample. See the samples in [Client](../../../../docs/framework/wcf/samples/client.md) that show server authentication.  
  
> [!NOTE]
>  The setup procedure and build instructions for this sample are located at the end of this topic.  
  
 This sample illustrates the following features:  
  
-   How to set the different types of identity on different endpoints for a service. Each type of identity has different capabilities. The type of identity to use is dependent on the type of security credentials used on the endpoint's binding.  
  
-   Identity can either be set declaratively in configuration or imperatively in code. Typically for both the client and the service you should use configuration to set the identity.  
  
-   How to set a custom identity on the client. A custom identity is typically a customization of an existing type of identity that enables the client to examine other claim information provided in the service's credentials to make authorization decisions before calling the service.  
  
    > [!NOTE]
    >  This sample checks the identity of a specific certificate called identity.com and the RSA key contained within this certificate. When using the Certificate and RSA identity types in configuration on the client, an easy way to get these values is to inspect the WSDL for the service where these values are serialized.  
  
 The following sample code shows how to configure the identity of a service endpoint with the Domain Name Server (DNS) of a certificate using a WSHttpBinding.  
  
```  
//Create a service endpoint and set its identity to the certificate's DNS                 
WSHttpBinding wsAnonbinding = new WSHttpBinding (SecurityMode.Message);  
// Client are Anonymous to the service  
wsAnonbinding.Security.Message.ClientCredentialType = MessageCredentialType.None;  
WServiceEndpoint ep = serviceHost.AddServiceEndpoint(typeof(ICalculator),wsAnonbinding, String.Empty);  
EndpointAddress epa = new EndpointAddress(dnsrelativeAddress,EndpointIdentity.CreateDnsIdentity("identity.com"));  
ep.Address = epa;  
```  
  
 The identity can also be specified in configuration in the App.config file. The following example shows how to set the UPN (User Principal Name) identity for a service endpoint.  
  
```xml  
<endpoint address="upnidentity"  
        behaviorConfiguration=""  
        binding="wsHttpBinding"  
        bindingConfiguration="WSHttpBinding_Windows"  
        name="WSHttpBinding_ICalculator_Windows"  
        contract="Microsoft.ServiceModel.Samples.ICalculator">  
  <!-- Set the UPN identity for this endpoint -->  
  <identity>  
      <userPrincipalName value="host\myservice.com" />  
  </identity >  
</endpoint>  
```  
  
 A custom identity can be set on the client by deriving from the <xref:System.ServiceModel.EndpointIdentity> and the <xref:System.ServiceModel.Security.IdentityVerifier> classes. Conceptually the <xref:System.ServiceModel.Security.IdentityVerifier> class can be considered to be the client equivalent of the service's `AuthorizationManager` class. The following code example shows an implementation of `OrgEndpointIdentity`, which stores an organization name to match in the subject name of the server's certificate. The authorization check for the organization name occurs in the `CheckAccess` method on the `CustomIdentityVerifier` class.  
  
```  
// This custom EndpointIdentity stores an organization name   
public class OrgEndpointIdentity : EndpointIdentity  
{  
    private string orgClaim;  
    public OrgEndpointIdentity(string orgName)  
    {  
        orgClaim = orgName;  
    }  
    public string OrganizationClaim  
    {  
        get { return orgClaim; }  
        set { orgClaim = value; }  
    }  
}  
  
//This custom IdentityVerifier uses the supplied OrgEndpointIdentity to  
//check that X.509 certificate's distinguished name claim contains  
//the organization name e.g. the string value "O=Contoso"   
class CustomIdentityVerifier : IdentityVerifier  
{  
    public override bool CheckAccess(EndpointIdentity identity, AuthorizationContext authContext)  
    {  
        bool returnvalue = false;  
        foreach (ClaimSet claimset in authContext.ClaimSets)  
        {  
            foreach (Claim claim in claimset)  
            {  
                if (claim.ClaimType == "http://schemas.microsoft.com/ws/2005/05/identity/claims/x500distinguishedname")  
                {  
                    X500DistinguishedName name = (X500DistinguishedName)claim.Resource;  
                    if (name.Name.Contains(((OrgEndpointIdentity)identity).OrganizationClaim))  
                    {  
                        Console.WriteLine("Claim Type: {0}",claim.ClaimType);  
                        Console.WriteLine("Right: {0}", claim.Right);  
                        Console.WriteLine("Resource: {0}",claim.Resource);  
                        Console.WriteLine();  
                        returnvalue = true;  
                    }  
                }  
            }  
        }  
        return returnvalue;  
    }  
}  
```  
  
 This sample uses a certificate called identity.com which is in the language-specific Identity solution folder.  
  
### To set up, build, and run the sample  
  
1.  Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md).  
  
2.  To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/building-the-samples.md).  
  
3.  To run the sample in a single- or cross-computer configuration, follow the instructions in [Running the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/running-the-samples.md).  
  
### To run the sample on the same computer  
  
1.  On [!INCLUDE[wxp](../../../../includes/wxp-md.md)] or [!INCLUDE[wv](../../../../includes/wv-md.md)], import the Identity.pfx certificate file in the Identity solution folder into the LocalMachine/My (Personal) certificate store using the MMC snap-in tool. This file is password protected. During the import you are asked for a password. Type `xyz` into the password box. For more information, see the [How to: View Certificates with the MMC Snap-in](../../../../docs/framework/wcf/feature-details/how-to-view-certificates-with-the-mmc-snap-in.md) topic. Once this is done, run Setup.bat in a Visual Studio command prompt with administrator privileges, which copies this certificate to the CurrentUser/Trusted People store for use on the client.  
  
2.  On [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)], run Setup.bat from the sample install folder inside a [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] command prompt with administrator privileges. This installs all the certificates required for running the sample.  
  
    > [!NOTE]
    >  The Setup.bat batch file is designed to be run from a [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] Command Prompt. The PATH environment variable set within the [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] Command Prompt points to the directory that contains executables required by the Setup.bat script. Ensure that you remove the certificates by running Cleanup.bat when you have finished with the sample. Other security samples use the same certificates.  
  
3.  Launch Service.exe from the \service\bin directory. Ensure that the service indicates that it is ready and displays a prompt to Press \<Enter> to terminate the service.  
  
4.  Launch Client.exe from \client\bin directory or by pressing F5 in Visual Studio to build and run. Client activity is displayed on the client console application.  
  
5.  If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
### To run the sample across computers  
  
1.  Before building the client part of the sample, be sure to change the value for the service's endpoint address in the Client.cs file in the `CallServiceCustomClientIdentity` method. Then build the sample.  
  
2.  Create a directory on the service computer.  
  
3.  Copy the service program files from service\bin to the directory on the service computer. Also copy the Setup.bat and Cleanup.bat files to the service computer.  
  
4.  Create a directory on the client computer for the client binaries.  
  
5.  Copy the client program files to the client directory on the client computer. Also copy the Setup.bat, Cleanup.bat, and ImportServiceCert.bat files to the client.  
  
6.  On the service, run `setup.bat service` in a Visual Studio command prompt opened with administrator privileges. Running `setup.bat` with the `service` argument creates a service certificate with the fully-qualified domain name of the computer and exports the service certificate to a file named Service.cer.  
  
7.  Copy the Service.cer file from the service directory to the client directory on the client computer.  
  
8.  In the Client.exe.config file on the client computer, change the address value of the endpoint to match the new address of your service. There are multiple instances that must be changed.  
  
9. On the client, run ImportServiceCert.bat in a Visual Studio command prompt opened with administrator privileges. This imports the service certificate from the Service.cer file into the CurrentUser - TrustedPeople store.  
  
10. On the service computer, launch the Service.exe from the command prompt.  
  
11. On the client computer, launch Client.exe from a command prompt. If the client and service are not able to communicate, see [Troubleshooting Tips](http://msdn.microsoft.com/library/8787c877-5e96-42da-8214-fa737a38f10b).  
  
### To clean up after the sample  
  
-   Run Cleanup.bat in the samples folder once you have finished running the sample.  
  
    > [!NOTE]
    >  This script does not remove service certificates on a client when running this sample across computers. If you have run [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] samples that use certificates across computers, be sure to clear the service certificates that have been installed in the CurrentUser - TrustedPeople store. To do this, use the following command: `certmgr -del -r CurrentUser -s TrustedPeople -c -n <Fully Qualified Server Machine Name>` For example: `certmgr -del -r CurrentUser -s TrustedPeople -c -n server1.contoso.com`.  
  
## See Also
