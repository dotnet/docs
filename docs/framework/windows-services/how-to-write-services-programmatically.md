---
title: "How to: Write Services Programmatically"
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
  - "services, creating"
  - "Windows Service applications, creating"
ms.assetid: 3abbb2ec-78d2-41e6-b9f9-6662d4e2cdc7
caps.latest.revision: 21
author: "ghogen"
ms.author: "ghogen"
manager: "douge"
ms.workload: 
  - "dotnet"
---
# How to: Write Services Programmatically
If you choose not to use the Windows Service project template, you can write your own services by setting up the inheritance and other infrastructure elements yourself. When you create a service programmatically, you must perform several steps that the template would otherwise handle for you:  
  
-   You must set up your service class to inherit from the <xref:System.ServiceProcess.ServiceBase> class.  
  
-   You must create a `Main` method for your service project that defines the services to run and calls the <xref:System.ServiceProcess.ServiceBase.Run%2A> method on them.  
  
-   You must override the <xref:System.ServiceProcess.ServiceBase.OnStart%2A> and <xref:System.ServiceProcess.ServiceBase.OnStop%2A> procedures and fill in any code you want them to run.  
  
### To write a service programmatically  
  
1.  Create an empty project and create a reference to the necessary namespaces by following these steps:  
  
    1.  In **Solution Explorer**, right-click the **References** node and click **Add Reference**.  
  
    2.  On the **.NET Framework** tab, scroll to **System.dll** and click **Select**.  
  
    3.  Scroll to **System.ServiceProcess.dll** and click **Select**.  
  
    4.  Click **OK**.  
  
2.  Add a class and configure it to inherit from <xref:System.ServiceProcess.ServiceBase>:  
  
     [!code-csharp[VbRadconService#7](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/VbRadconService/CS/MyNewService.cs#7)]
     [!code-vb[VbRadconService#7](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbRadconService/VB/MyNewService.vb#7)]  
  
3.  Add the following code to configure your service class:  
  
     [!code-csharp[VbRadconService#8](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/VbRadconService/CS/MyNewService.cs#8)]
     [!code-vb[VbRadconService#8](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbRadconService/VB/MyNewService.vb#8)]  
  
4.  Create a `Main` method for your class, and use it to define the service your class will contain; `userService1` is the name of the class:  
  
     [!code-csharp[VbRadconService#9](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/VbRadconService/CS/MyNewService.cs#9)]
     [!code-vb[VbRadconService#9](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbRadconService/VB/MyNewService.vb#9)]  
  
5.  Override the <xref:System.ServiceProcess.ServiceBase.OnStart%2A> method, and define any processing you want to occur when your service is started.  
  
     [!code-csharp[VbRadconService#10](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/VbRadconService/CS/MyNewService.cs#10)]
     [!code-vb[VbRadconService#10](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbRadconService/VB/MyNewService.vb#10)]  
  
6.  Override any other methods you want to define custom processing for, and write code to determine the actions the service should take in each case.  
  
7.  Add the necessary installers for your service application. For more information, see [How to: Add Installers to Your Service Application](../../../docs/framework/windows-services/how-to-add-installers-to-your-service-application.md).  
  
8.  Build your project by selecting **Build Solution** from the **Build** menu.  
  
    > [!NOTE]
    >  Do not press F5 to run your project — you cannot run a service project in this way.  
  
9. Create a setup project and the custom actions to install your service. For an example, see [Walkthrough: Creating a Windows Service Application in the Component Designer](../../../docs/framework/windows-services/walkthrough-creating-a-windows-service-application-in-the-component-designer.md).  
  
10. Install the service. For more information, see [How to: Install and Uninstall Services](../../../docs/framework/windows-services/how-to-install-and-uninstall-services.md).  
  
## See Also  
 [Introduction to Windows Service Applications](../../../docs/framework/windows-services/introduction-to-windows-service-applications.md)  
 [How to: Create Windows Services](../../../docs/framework/windows-services/how-to-create-windows-services.md)  
 [How to: Add Installers to Your Service Application](../../../docs/framework/windows-services/how-to-add-installers-to-your-service-application.md)  
 [How to: Log Information About Services](../../../docs/framework/windows-services/how-to-log-information-about-services.md)  
 [Walkthrough: Creating a Windows Service Application in the Component Designer](../../../docs/framework/windows-services/walkthrough-creating-a-windows-service-application-in-the-component-designer.md)
