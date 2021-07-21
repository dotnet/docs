---
title: "How to: Make X.509 Certificates Accessible to WCF"
description: Learn how to make an X.509 certificate accessible to WCF. Application code must specify the certificate store name and location. There might be other requirements. 
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "X.509 certificates [WCF]"
  - "certificates [WCF], making X.509 certificates accessible to WCF"
  - "X.509 certificates [WCF], making accessible to WCF"
ms.assetid: a54e407c-c2b5-4319-a648-60e43413664b
---
# How to: Make X.509 Certificates Accessible to WCF

To make an X.509 certificate accessible to Windows Communication Foundation (WCF), application code must specify the certificate store name and location. In certain circumstances, the process identity must have access to the file that contains the private key associated with the X.509 certificate. To obtain the private key associated with an X.509 certificate in a certificate store, WCF must have permission to do so. By default, only the owner and the System account can access the private key of a certificate.  
  
### To make X.509 certificates accessible to WCF  
  
1. Give the account under which WCF is running read access to the file that contains the private key associated with the X.509 certificate.  
  
    1. Determine whether WCF requires read access to the private key for the X.509 certificate.  
  
         The following table details whether a private key must be available when using an X.509 certificate.  
  
        |X.509 certificate use|Private key|  
        |---------------------------|-----------------|  
        |Digitally signing an outbound SOAP message.|Yes|  
        |Verifying the signature of an inbound SOAP message.|No|  
        |Encrypting an outbound SOAP message.|No|  
        |Decrypting an inbound SOAP message.|Yes|  
  
    2. Determine the certificate store location and name in which the certificate is stored.  
  
         The certificate store in which the certificate is stored is specified either in application code or in configuration. For example, the following example specifies that the certificate is located in the `CurrentUser` certificate store named `My`.  
  
         [!code-csharp[x509Accessible#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/x509accessible/cs/source.cs#1)]
         [!code-vb[x509Accessible#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/x509accessible/vb/source.vb#1)]  
  
    3. Determine where the private key for the certificate is located on the computer by using the [FindPrivateKey](../samples/findprivatekey.md) tool.  
  
         The [FindPrivateKey](../samples/findprivatekey.md) tool requires the certificate store name, certificate store location, and something that uniquely identifies the certificate. The tool accepts either the certificate's subject name or its thumbprint as a unique identifier. For more information about how to determine the thumbprint for a certificate, see [How to: Retrieve the Thumbprint of a Certificate](how-to-retrieve-the-thumbprint-of-a-certificate.md).  
  
         The following code example uses the [FindPrivateKey](../samples/findprivatekey.md) tool to determine the location of the private key for a certificate in the `My` store in `CurrentUser` with a thumbprint of `46 dd 0e 7a ed 0b 7a 31 9b 02 a3 a0 43 7a d8 3f 60 40 92 9d`.  
  
        ```console
        findprivatekey.exe My CurrentUser -t "46 dd 0e 7a ed 0b 7a 31 9b 02 a3 a0 43 7a d8 3f 60 40 92 9d" -a  
        ```  
  
    4. Determine the account that WCF is running under.  
  
         The following table details the account under which WCF is running for a given scenario.  
  
        |Scenario|Process identity|  
        |--------------|----------------------|  
        |Client (console or WinForms application).|Currently logged in user.|  
        |Service that is self-hosted.|Currently logged in user.|  
        |Service that is hosted in IIS 6.0 (Windows Server 2003) or IIS 7.0 (Windows Vista).|NETWORK SERVICE|  
        |Service that is hosted in IIS 5.X (Windows XP).|Controlled by the `<processModel>` element in the Machine.config file. The default account is ASPNET.|  
  
    5. Grant read access to the file that contains the private key to the account that WCF is running under, using a tool such as icacls.exe.  
  
         The following code example edits the discretionary access control list (DACL) for the specified file to grant the NETWORK SERVICE account read (:R) access to the file.  
  
        ```console
        icacls.exe "C:\Documents and Settings\All Users\Application Data\Microsoft\Crypto\RSA\MachineKeys\8aeda5eb81555f14f8f9960745b5a40d_38f7de48-5ee9-452d-8a5a-92789d7110b1" /grant "NETWORK SERVICE":R  
        ```  
  
## See also

- [FindPrivateKey](../samples/findprivatekey.md)
- [How to: Retrieve the Thumbprint of a Certificate](how-to-retrieve-the-thumbprint-of-a-certificate.md)
- [Working with Certificates](working-with-certificates.md)
