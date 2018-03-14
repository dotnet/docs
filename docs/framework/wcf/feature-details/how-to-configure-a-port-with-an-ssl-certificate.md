---
title: "How to: Configure a Port with an SSL Certificate"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "SSL"
  - "WCF, security mode"
  - "WCF, security"
ms.assetid: b8abcc8e-a5f5-4317-aca5-01e3c40ab24d
caps.latest.revision: 18
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Configure a Port with an SSL Certificate
When creating a self-hosted [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service with the <xref:System.ServiceModel.WSHttpBinding> class that uses transport security, you must also configure a port with an X.509 certificate. If you are not creating a self-hosted service, you can host your service on Internet Information Services (IIS). [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [HTTP Transport Security](../../../../docs/framework/wcf/feature-details/http-transport-security.md).  
  
 To configure a port, the tool you use depends on the operating system that is running on your machine.  
  
 If you are running [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] or [!INCLUDE[wxp](../../../../includes/wxp-md.md)], use the HttpCfg.exe tool. With [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] this tool is installed. With [!INCLUDE[wxp](../../../../includes/wxp-md.md)], you can download the tool at [Windows XP Service Pack 2 Support Tools](http://go.microsoft.com/fwlink/?LinkId=88606). [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Httpcfg Overview](http://go.microsoft.com/fwlink/?LinkId=88605). The [Windows Support Tools documentation](http://go.microsoft.com/fwlink/?LinkId=94840) explains the syntax for the Httpcfg.exe tool.  
  
 If you are running [!INCLUDE[wv](../../../../includes/wv-md.md)], use the Netsh.exe tool that is already installed.  
  
 This topic describes how to accomplish several procedures:  
  
-   Determining a computer's current port configuration.  
  
-   Getting a certificate's thumbprint (necessary for the following two procedures).  
  
-   Binding an SSL certificate to a port configuration.  
  
-   Binding an SSL certificate to a port configuration and supporting client certificates.  
  
-   Deleting an SSL certificate from a port number.  
  
 Note that modifying certificates stored on the computer requires administrative privileges.  
  
### To determine how ports are configured  
  
1.  In [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] or [!INCLUDE[wxp](../../../../includes/wxp-md.md)], use the HttpCfg.exe tool to view the current port configuration, using the **query** and **ssl** switches, as shown in the following example.  
  
    ```  
    httpcfg query ssl  
    ```  
  
2.  In [!INCLUDE[wv](../../../../includes/wv-md.md)], use the Netsh.exe tool to view the current port configuration, as shown in the following example.  
  
    ```  
    netsh http show sslcert  
    ```  
  
### To get a certificate's thumbprint  
  
1.  Use the Certificates MMC snap-in to find an X.509 certificate that has an intended purpose of client authentication. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: View Certificates with the MMC Snap-in](../../../../docs/framework/wcf/feature-details/how-to-view-certificates-with-the-mmc-snap-in.md).  
  
2.  Access the certificate's thumbprint. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: Retrieve the Thumbprint of a Certificate](../../../../docs/framework/wcf/feature-details/how-to-retrieve-the-thumbprint-of-a-certificate.md).  
  
3.  Copy the thumbprint of the certificate into a text editor, such as Notepad.  
  
4.  Remove all spaces between the hexadecimal characters. One way to accomplish this is to use the text editor's find-and-replace feature and replace each space with a null character.  
  
### To bind an SSL certificate to a port number  
  
1.  In [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] or [!INCLUDE[wxp](../../../../includes/wxp-md.md)], use the HttpCfg.exe tool in "set" mode on the Secure Sockets Layer (SSL) store to bind the certificate to a port number. The tool uses the thumbprint to identify the certificate, as shown in the following example.  
  
    ```  
    httpcfg set ssl -i 0.0.0.0:8012 -h 0000000000003ed9cd0c315bbb6dc1c08da5e6  
    ```  
  
    -   The **-i** switch has the syntax of `IP`:`port` and instructs the tool to set the certificate to port 8012 of the computer. Optionally, the four zeroes that precede the number can also be replaced by the actual IP address of the computer.  
  
    -   The **-h** switch specifies the thumbprint of the certificate.  
  
2.  In [!INCLUDE[wv](../../../../includes/wv-md.md)], use the Netsh.exe tool, as shown in the following example.  
  
    ```  
    netsh http add sslcert ipport=0.0.0.0:8000 certhash=0000000000003ed9cd0c315bbb6dc1c08da5e6 appid={00112233-4455-6677-8899-AABBCCDDEEFF}   
    ```  
  
    -   The **certhash** parameter specifies the thumbprint of the certificate.  
  
    -   The **ipport** parameter specifies the IP address and port, and functions just like the **-i** switch of the Httpcfg.exe tool described.  
  
    -   The **appid** parameter is a GUID that can be used to identify the owning application.  
  
### To bind an SSL certificate to a port number and support client certificates  
  
1.  In [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] or [!INCLUDE[wxp](../../../../includes/wxp-md.md)], to support clients that authenticate with X.509 certificates at the transport layer, follow the preceding procedure but pass an additional command-line parameter to HttpCfg.exe, as shown in the following example.  
  
    ```  
    httpcfg set ssl -i 0.0.0.0:8012 -h 0000000000003ed9cd0c315bbb6dc1c08da5e6 -f 2  
    ```  
  
     The **-f** switch has the syntax of `n` where n is a number between 1 and 7. A value of 2, as shown in the preceding example, enables client certificates at the transport layer. A value of 3 enables client certificates and maps those certificates to a Windows account. See HttpCfg.exe Help for the behavior of other values.  
  
2.  In [!INCLUDE[wv](../../../../includes/wv-md.md)], to support clients that authenticate with X.509 certificates at the transport layer, follow the preceding procedure, but with an additional parameter, as shown in the following example.  
  
    ```  
    netsh http add sslcert ipport=0.0.0.0:8000 certhash=0000000000003ed9cd0c315bbb6dc1c08da5e6 appid={00112233-4455-6677-8899-AABBCCDDEEFF} clientcertnegotiation=enable  
    ```  
  
### To delete an SSL certificate from a port number  
  
1.  Use the HttpCfg.exe or Netsh.exe tool to see the ports and thumbprints of all bindings on the computer. To print the information to disk, use the redirection character ">", as shown in the following example.  
  
    ```  
    httpcfg query ssl>myMachinePorts.txt  
    ```  
  
2.  In [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)] or [!INCLUDE[wxp](../../../../includes/wxp-md.md)], use the HttpCfg.exe tool with the **delete** and **ssl** keywords. Use the **-i** switch to specify the `IP`:`port` number, and the **-h** switch to specify the thumbprint.  
  
    ```  
    httpcfg delete ssl -i 0.0.0.0:8005 -h 0000000000003ed9cd0c315bbb6dc1c08da5e6  
    ```  
  
3.  In [!INCLUDE[wv](../../../../includes/wv-md.md)], use the Netsh.exe tool, as shown in the following example.  
  
    ```  
    Netsh http delete sslcert ipport=0.0.0.0:8005  
    ```  
  
## Example  
 The following code shows how to create a self-hosted service using the <xref:System.ServiceModel.WSHttpBinding> class set to transport security. When creating an application, specify the port number in the address.  
  
 [!code-csharp[c_WsHttpService#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_wshttpservice/cs/source.cs#3)]
 [!code-vb[c_WsHttpService#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_wshttpservice/vb/source.vb#3)]  
  
## See Also  
 [HTTP Transport Security](../../../../docs/framework/wcf/feature-details/http-transport-security.md)
