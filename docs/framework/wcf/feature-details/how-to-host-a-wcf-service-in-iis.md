---
title: "How to: Host a WCF Service in IIS"
description: Learn how to create a WCF service that is hosted in Internet Information Services (IIS). You can use IIS hosting only with an HTTP transport.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: b044b1c9-c1e5-4c9f-84d8-0f02f4537f8b
---
# How to: Host a WCF Service in IIS

This topic outlines the basic steps required to create a Windows Communication Foundation (WCF) service that is hosted in Internet Information Services (IIS). This topic assumes you are familiar with IIS and understand how to use the IIS management tool to create and manage IIS applications. For more information about IIS see [Internet Information Services](https://www.iis.net/). A WCF service that runs in the IIS environment takes full advantage of IIS features, such as process recycling, idle shutdown, process health monitoring, and message-based activation. This hosting option requires that IIS be properly configured, but it does not require that any hosting code be written as part of the application. You can use IIS hosting only with an HTTP transport.  
  
 For more information about how WCF and ASP.NET interact, see [WCF Services and ASP.NET](wcf-services-and-aspnet.md). For more information about configuring security, see [Security](security.md).  
  
 For the source copy of this example, see [IIS Hosting Using Inline Code](../samples/iis-hosting-using-inline-code.md).  
  
### To create a service hosted by IIS  
  
1. Confirm that IIS is installed and running on your computer. For more information about installing and configuring IIS see [Installing and Configuring IIS 7.0](/iis/install/installing-iis-7/installing-necessary-iis-components-on-windows-vista)  
  
2. Create a new folder for your application files called "IISHostedCalcService", ensure that ASP.NET has access to the contents of the folder, and use the IIS management tool to create a new IIS application that is physically located in this application directory. When creating an alias for the application directory use "IISHostedCalc".  
  
3. Create a new file named "service.svc" in the application directory. Edit this file by adding the following @ServiceHost element.  
  
   ```aspx-csharp
   <%@ServiceHost language=c# Debug="true" Service="Microsoft.ServiceModel.Samples.CalculatorService"%>
   ```  
  
4. Create an App_Code subdirectory within the application directory.  
  
5. Create a code file named Service.cs in the App_Code subdirectory.  
  
6. Add the following using statements to the top of the Service.cs file.  
  
    ```csharp  
    using System;  
    using System.ServiceModel;  
    ```  
  
7. Add the following namespace declaration after the using statements.  
  
    ```csharp  
    namespace Microsoft.ServiceModel.Samples  
    {  
    }  
    ```  
  
8. Define the service contract inside the namespace declaration as shown in the following code.  
  
     [!code-csharp[c_HowTo_HostInIIS#11](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_hostiniis/cs/source.cs#11)]
     [!code-vb[c_HowTo_HostInIIS#11](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howto_hostiniis/vb/source.vb#11)]  
  
9. Implement the service contract after the service contract definition as shown in the following code.  
  
     [!code-csharp[c_HowTo_HostInIIS#12](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_hostiniis/cs/source.cs#12)]
     [!code-vb[c_HowTo_HostInIIS#12](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howto_hostiniis/vb/source.vb#12)]  
  
10. Create a file named "Web.config" in the application directory and add the following configuration code into the file. At runtime, the WCF infrastructure uses the information to construct an endpoint that client applications can communicate with.  
  
     [!code-xml[c_HowTo_HostInIIS#100](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_hostiniis/common/web.config#100)]
  
     This example explicitly specifies endpoints in the configuration file. If you do not add any endpoints to the service, the runtime adds default endpoints for you. For more information about default endpoints, bindings, and behaviors see [Simplified Configuration](../simplified-configuration.md) and [Simplified Configuration for WCF Services](../samples/simplified-configuration-for-wcf-services.md).  
  
11. To make sure the service is hosted correctly, open an instance of Internet Explorer and browse to the service's URL: `http://localhost/IISHostedCalc/Service.svc`  
  
## Example  

 The following is a complete listing of the code for the IIS hosted calculator service.  
  
 [!code-csharp[C_HowTo_HostInIIS#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_hostiniis/cs/source.cs#1)]
 [!code-vb[C_HowTo_HostInIIS#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howto_hostiniis/vb/source.vb#1)]
 [!code-xml[c_HowTo_HostInIIS#100](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howto_hostiniis/common/web.config#100)]  
  
## See also

- [Hosting in Internet Information Services](hosting-in-internet-information-services.md)
- [Hosting Services](../hosting-services.md)
- [WCF Services and ASP.NET](wcf-services-and-aspnet.md)
- [Security](security.md)
- [Windows Server App Fabric Hosting Features](/previous-versions/appfabric/ee677189(v=azure.10))
