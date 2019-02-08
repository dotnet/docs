---
title: "How to: View certificates with the MMC snap-in"
ms.date: 02/07/2019
helpviewer_keywords: 
  - "certificates [WCF], viewing with the MMC snap-in"
ms.assetid: 2b8782aa-ebb4-4ee7-974b-90299e356dc5
---
# How to: View certificates with the MMC snap-in
When you create a secure client or service, you can use a certificate as the credential. For example, a common type of credential is the X.509 certificate, which you create with the <xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential.SetCertificate%2A> method. The certificate method requires various parameters, such as the certificate store and a value to use to search for the certificate. For information about how to find a certificate thumbprint, see [How to: Retrieve the thumbprint of a certificate](how-to-retrieve-the-thumbprint-of-a-certificate.md). 

## Certificate stores
There are three different types of certificate stores that you can examine:

- Local computer: This type of store is local to the device and global to all users on the device.

- Current user: This type of store is local to the current user account on the device.

- Service account: This type of store is local to a particular service on the device.

  
## To view certificates in the MMC snap-in  

The following procedure demonstrates how to examine the stores on your local device to find an appropriate certificate. 
  
1. Select **Run** from the **Start** menu, and then enter *mmc*. 

    The Microsoft Management Console (MMC) appears. To view certificates in the local machine store, you must have the administrator role.
  
2. From the **File** menu, select **Add/Remove Snap In**. 
    
    The **Add or Remove Snap-ins** window appears.
  
3. From the **Available snap-ins** list, choose **Certificates**, then select **Add**.  

    ![Add certificate snap-in](./media/mmc-add-certificate-snap-in.png)
  
4. In the **Certificates snap-in** window, select **Computer account**, and then select **Next**. 
  
    Optionally, you can select **My user account** for the current user or **Service account** for a particular service. If you're not an administrator for the computer, you can manage certificates only for your user account.
  
5. In the **Select Computer** window, leave **Local computer** selected, and then select **Finish**.  
  
6. In the **Add or Remove Snap-in** window, select **OK**.  
  
    ![Add certificate snap-in](./media/mmc-certificate-snap-in-selected.png)

7. Optional: From the **File** menu, select **Save** or **Save As** to save the MMC console file for later reuse.  

8. To view your certificates in the MMC snap-in, select **Console Root** in the left pane, then expand **Certificates (Local Computer)**.

    A list of directories for each type of certificate appears. From each certificate directory, you can view, export, import, and delete its certificates.
  

## View certificates with the Certificate Manager tool
You can also view, export, import, and delete certificates by using the Certificate Manager tool.

### To view certificates with certlm.msc (local device)

1. Select **Run** from the **Start** menu, and then enter *certlm.msc*. 

    The Certificate Manager tool for the local device appears. 
  
2. To view your certificates, under **Certificates - Local Computer** in the left pane, expand the directory for the type of certificate you want to view.

### To view certificates with certmgr.msc (current user)

1. Select **Run** from the **Start** menu, and then enter *certmgr.msc*. 

    The Certificate Manager tool for the current user appears. 
  
2. To view your certificates, under **Certificates - Current User** in the left pane, expand the directory for the type of certificate you want to view.

  
## See also
- [Working with certificates](working-with-certificates.md)
- [How to: Create temporary certificates for use during development](how-to-create-temporary-certificates-for-use-during-development.md)
- [How to: Retrieve the thumbprint of a certificate](how-to-retrieve-the-thumbprint-of-a-certificate.md)
