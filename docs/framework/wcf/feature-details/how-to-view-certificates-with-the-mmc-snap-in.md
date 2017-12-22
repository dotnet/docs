---
title: "How to: View Certificates with the MMC Snap-in"
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
  - "certificates [WCF], viewing with the MMC snap-in"
ms.assetid: 2b8782aa-ebb4-4ee7-974b-90299e356dc5
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: View Certificates with the MMC Snap-in
A common type of credential is the X.509 certificate. When creating secure services or clients, you can specify a certificate be used as the client or service credential by using methods such as the <xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential.SetCertificate%2A> method. The method requires various parameters, such as the store where the certificate is stored and a value to use when searching for the certificate. The following procedure demonstrates how to examine the stores on a computer to find an appropriate certificate. For an example of finding the certificate thumbprint, see [How to: Retrieve the Thumbprint of a Certificate](../../../../docs/framework/wcf/feature-details/how-to-retrieve-the-thumbprint-of-a-certificate.md).  
  
### To view certificates in the MMC snap-in  
  
1.  Open a Command Prompt window.  
  
2.  Type `mmc` and press the ENTER key. Note that to view certificates in the local machine store, you must be in the Administrator role.  
  
3.  On the **File** menu, click **Add/Remove Snap In**.  
  
4.  Click **Add**.  
  
5.  In the **Add Standalone Snap-in** dialog box, select **Certificates**.  
  
6.  Click **Add**.  
  
7.  In the **Certificates snap-in** dialog box, select **Computer account** and click **Next**. Optionally, you can select **My User account** or **Service account**. If you are not an administrator of the computer, you can manage certificates only for your user account.  
  
8.  In the **Select Computer** dialog box, click **Finish**.  
  
9. In the **Add Standalone Snap-in** dialog box, click **Close**.  
  
10. On the **Add/Remove Snap-in** dialog box, click **OK**.  
  
11. In the **Console Root** window, click **Certificates (Local Computer)** to view the certificate stores for the computer.  
  
12. Optional. To view certificates for your account, repeat steps 3 to 6. In step 7, instead of selecting **Computer account**, click **My User account** and repeat steps 8 to 10.  
  
13. Optional. On the **File** menu, click **Save** or **Save As**. Save the console file for later reuse.  
  
## Viewing Certificates with Internet Explorer  
 You can also view, export, import, and delete certificates by using Internet Explorer.  
  
#### To view certificates with Internet Explorer  
  
1.  In Internet Explorer, click **Tools**, then click **Internet Options** to display the **Internet Options** dialog box.  
  
2.  Click the **Content** tab.  
  
3.  Under **Certificates**, click **Certificates**.  
  
4.  To view details of any certificate, select the certificate and click **View**.  
  
## See Also  
 [Working with Certificates](../../../../docs/framework/wcf/feature-details/working-with-certificates.md)  
 [How to: Create Temporary Certificates for Use During Development](../../../../docs/framework/wcf/feature-details/how-to-create-temporary-certificates-for-use-during-development.md)  
 [How to: Retrieve the Thumbprint of a Certificate](../../../../docs/framework/wcf/feature-details/how-to-retrieve-the-thumbprint-of-a-certificate.md)
