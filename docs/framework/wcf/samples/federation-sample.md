---
title: "Federation Sample"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7e9da0ca-e925-4644-aa96-8bfaf649d4bb
caps.latest.revision: 26
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Federation Sample
This sample demonstrates federated security.  
  
## Sample Details  
 [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] provides support for deploying federated security architectures through the `wsFederationHttpBinding`. The `wsFederationHttpBinding` provides a secure, reliable, and interoperable binding that involves the use of HTTP as the underlying transport mechanism for request/reply communication, and Text/XML as the wire format for encoding. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] Federation in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], see [Federation](../../../../docs/framework/wcf/feature-details/federation.md).  
  
 The scenario is made up of 4 pieces:  
  
-   BookStore service  
  
-   BookStore STS  
  
-   HomeRealm STS  
  
-   BookStore Client  
  
 The BookStore service supports two operations, `BrowseBooks` and `BuyBook`. It allows anonymous access to the `BrowseBooks` operation, but requires authenticated access to access the `BuyBooks` operation. The authentication takes the form of a token issued by the BookStore STS. The configuration file for the BookStore Service points clients to the BookStore STS using the `wsFederationHttpBinding`.  
  
```xml  
<wsFederationHttpBinding>  
<!-- This is the Service binding for the BuyBooks endpoint. It redirects clients to the BookStore STS -->  
    <binding name='BuyBookBinding'>  
        <security mode="Message">  
            <message>  
                <issuerMetadata  
  address='http://localhost/FederationSample/BookStoreSTS/STS.svc/mex' >  
                    <identity>  
                        <dns value ='BookStoreSTS.com'/>  
                    </identity>  
                </issuerMetadata>  
            </message>  
        </security>  
    </binding>  
</wsFederationHttpBinding>  
```  
  
 The BookStore STS then requires that clients authenticate using a token issued by the HomeRealm STS. Again, the configuration file for the BookStore STS points clients to the HomeRealm STS using the `wsFederationHttpBinding`.  
  
```xml  
<wsFederationHttpBinding>  
 <!-- This is the binding for the clients requesting tokens from this STS. It redirects clients to the HomeRealm STS -->  
    <binding name='BookStoreSTSBinding'>  
        <security mode='Message'>  
            <message>  
                <issuerMetadata  
 address='http://localhost/FederationSample/HomeRealmSTS/STS.svc/mex' >  
                    <identity>  
                        <dns value ='HomeRealmSTS.com' />  
                    </identity>  
                </issuerMetadata>  
            </message>  
        </security>  
    </binding>  
</wsFederationHttpBinding>  
```  
  
 The sequence of events when accessing the `BuyBook` operation is as follows:  
  
1.  The client authenticates to the HomeRealm STS using Windows credentials.  
  
2.  The HomeRealm STS issues a token that can be used to authenticate to the BookStore STS.  
  
3.  The client authenticates to the BookStore STS using the token issued by the HomeRealm STS.  
  
4.  The BookStore STS issues a token that can be used to authenticate to the BookStore Service.  
  
5.  The client authenticates to the BookStore service using the token issued by the BookStore STS.  
  
6.  The client accesses the `BuyBook` operation.  
  
 See the following instructions about how to set up and run this sample.  
  
> [!NOTE]
>  You must have Write permissions to the **wwwroot** directory to run this sample.  
  
#### To set up, build, and run the sample  
  
1.  Open the SDK command window. In the sample path, run Setup.bat. This creates the virtual directories required for the sample and installs the required certificates with appropriate permissions.  
  
    > [!NOTE]
    >  The Setup.bat batch file is designed to be run from a Windows SDK Command Prompt. It requires that the MSSDK environment variable point to the directory where the SDK is installed. This environment variable is automatically set within a Windows SDK Command Prompt. On [!INCLUDE[wv](../../../../includes/wv-md.md)], you must ensure that IIS 6.0 Management Compatibility is installed because the set up uses IIS administrator scripts. Running the set-up script on [!INCLUDE[wv](../../../../includes/wv-md.md)] requires administrator privileges.  
  
2.  Open FederationSample.sln in Visual Studio and select **Build Solution** from the **Build** menu. This builds the common project files, Bookstore service, Bookstore STS, HomeRealm STS, and deploys them in IIS. This also builds the Bookstore client application and places the executable BookStoreClient.exe in the FederationSample\BookStoreClient\bin\Debug folder.  
  
3.  Double-click BookStoreClient.exe. The BookStoreClient window is displayed.  
  
4.  You can browse the books available in the bookstore by clicking **Browse Books**.  
  
5.  To purchase a particular book, select the book in the list and click **Buy Book**. The application starts up and authenticates using Windows authentication with the HomeRealm Security Token Service.  
  
     The sample is configured to allow users to purchase books that cost $15 or less. Attempting to buy books that cost more than $15 results in the client getting an Access Denied message from the Book Store Service.  
  
    > [!NOTE]
    >  The sample does not update the user’s credit limit after a purchase. You can repeatedly purchase books within the user’s (fixed) credit limit.  
  
#### To clean up  
  
1.  Run Cleanup.bat. This deletes the virtual directories that were created during set up and also removes the certificates installed during setup.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WCF\Scenario\Federation`  
  
## See Also
