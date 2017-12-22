---
title: "ReadMe for Extended Protection Authentication Sample"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 80bf2e97-398d-4db5-9040-d96478a2ccab
caps.latest.revision: 3
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# ReadMe for Extended Protection Authentication Sample
Extended Protection is a security initiative to protect against man-in-the-middle (MITM) attacks, in which an attacker (the "man-in-the-middle") intercepts a client’s credentials and uses them to access secure resources on the client’s intended server.  
  
 For more information, see [Extended Protection for Authentication Overview](../../../../docs/framework/wcf/feature-details/extended-protection-for-authentication-overview.md).  
  
> [!NOTE]
>  This sample only works when hosted on IIS. It does not work on Visual Studio Development Server because that does not support HTTPS.  
  
## To Set Up, Build, and Run the Sample  
  
1.  Install IIS on the machine from Add/Remove Programs -> Windows Features.  
  
2.  Turn on Windows Authentication in Windows features: Internet Information Services -> World Wide Web Services -> Security -> Windows Authentication.  
  
3.  Turn on HTTP Activation in Windows features: Microsoft .NET Framework 3.5.1 -> Windows Communication Foundation HTTP Activation.  
  
4.  This sample requires the client to establish a secure channel with the server and so it requires the presence of a server certificate which can be installed from Internet Information Services (IIS) Manager.  
  
    1.  Open the IIS manager -> Server certificates (from the feature view tab).  
  
    2.  For the purpose of testing this sample, you can create a self-signed certificate. (If you don’t want Internet Explorer to prompt you about the certificate not being secure, you can install it in the Trusted Certificate Root authority store).  
  
5.  Go to the Actions pane for the Default Web site. Click Edit Site -> Bindings. Add HTTPS as a type if it is not already present, with port number 443, and assign the SSL certificate created in the above step.  
  
6.  Build the service. This creates a virtual directory in IIS for you (from the post build action specified in the project properties) and copies the dll, .svc and config files as needed for a service to be Web hosted.  
  
7.  Open the IIS Manager. Right-click the virtual directory (ExtendedProtection) that you created in the previous step and select Convert to Application.  
  
8.  Open the Authentication module in IIS Manager for this virtual directory and enable Windows Authentication.  
  
9. Open the Advanced Settings for Windows Authentication for this virtual directory and set it to Required, since, in the sample, the corresponding ExtendedProtection setting is set to Always.  
  
10. You can test the service by accessing the URL from a browser window. If you want to access this URL from a cross machine, make sure that the firewall is opened for all incoming HTTP and HTTPS connections.  
  
11. Open the client config file and provide a full machine name for the \<client> - \<endpoint> - address attribute, replacing <<full_machine_name>>.  
  
12. Run the client. The client communicates to the service by establishing a secure channel and using extended protection under the covers.
