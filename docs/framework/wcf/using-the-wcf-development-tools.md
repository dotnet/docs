---
title: "Using the WCF Development Tools"
ms.date: "03/30/2017"
ms.assetid: 054adb87-c244-4d5a-83d1-0b2b44bd454b
---
# Using the WCF Development Tools
This section describes the Visual Studio development tools that can assist you in developing your WCFservice.  
  
 You can use the Visual Studio templates as a foundation to quickly build your own service, then use WCF Service Auto Host and WCF Test Client to debug and test your service. These tools together provide a fast and seamless debug and testing cycle, and preclude the need to commit to a hosting model at an early stage.  
  
## The WCF Developer Tools  
 [WCF Visual Studio Templates](../../../docs/framework/wcf/wcf-vs-templates.md)  
  
 You can use the predefined Visual Studio project and item templates in Visual Studio to quickly build WCF services and surrounding applications.  
  
 [WCF Service Host (WcfSvcHost.exe)](../../../docs/framework/wcf/wcf-service-host-wcfsvchost-exe.md)  
  
 The WCF Service Auto Host (WcfSvcHost.exe) allows you to launch the Visual Studio debugger (F5) to automatically host and test a service you have implemented. You can then test the service using the WCF Test Client (wcfTestClient.exe) or your own client to find and fix any potential errors.  
  
 [WCF Test Client (WcfTestClient.exe)](../../../docs/framework/wcf/wcf-test-client-wcftestclient-exe.md)  
  
 WCF Test Client (WcfTestClient.exe) is a GUI tool that allows you to input parameters of arbitrary types, submit that input to the service, and view the response the service sends back. It provides a seamless service testing experience when combined with WCF Service Auto Host.  
  
 [Generating Data Type Classes from XML](../../../docs/framework/wcf/generating-data-type-classes-from-xml.md)  
  
 XML data stored in the clipboard can be pasted into a code page. The classes defined in the data will be converted to code types.  
  
## Using the Tools without Administrator privilege  
 To enable users without administrator privilege to develop WCF services, an ACL (Access Control List) is created for the namespace "http://+:8731/Design_Time_Addresses" during the installation of Visual Studio. The ACL is set to (UI), which includes all interactive users logged on to the machine. Administrators can add or remove users from this ACL, or open additional ports.This ACL enables WCF or WF templates to send and receive data in their default configuration. It also enables users to use the WCF Service Auto Host (wcfSvcHost.exe) without granting them administrator privileges.  
  
 You can modify access using the Netsh.exe tool in [!INCLUDE[wv](../../../includes/wv-md.md)] under the elevated administrator account. The following is an example of using Netsh.exe.  
  
```  
netsh http add urlacl url=http://+:8001/MyService user=<domain>\<user>  
```  
  
 For more information about Netsh.exe, see [How to Use the Netsh.exe Tool and Command-Line Switches](https://go.microsoft.com/fwlink/?LinkId=97877).  
  
## See Also  
 [WCF Visual Studio Templates](../../../docs/framework/wcf/wcf-vs-templates.md)  
 [WCF Service Host (WcfSvcHost.exe)](../../../docs/framework/wcf/wcf-service-host-wcfsvchost-exe.md)  
 [WCF Test Client (WcfTestClient.exe)](../../../docs/framework/wcf/wcf-test-client-wcftestclient-exe.md)
