---
title: "How to: Debug Windows Service Applications"
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
  - "debugging Windows Service applications"
  - "debugging [Visual Studio], Windows services"
  - "Windows NT services, debugging"
  - "Windows Service applications, debugging"
  - "services, debugging"
ms.assetid: 63ab0800-0f05-4f1e-88e6-94c73fd920a2
caps.latest.revision: 16
author: "ghogen"
ms.author: "ghogen"
manager: "douge"
ms.workload: 
  - "dotnet"
---
# How to: Debug Windows Service Applications
A service must be run from within the context of the Services Control Manager rather than from within Visual Studio. For this reason, debugging a service is not as straightforward as debugging other Visual Studio application types. To debug a service, you must start the service and then attach a debugger to the process in which it is running. You can then debug your application by using all of the standard debugging functionality of Visual Studio.  
  
> [!CAUTION]
>  You should not attach to a process unless you know what the process is and understand the consequences of attaching to and possibly killing that process. For example, if you attach to the WinLogon process and then stop debugging, the system will halt because it can’t operate without WinLogon.  
  
 You can attach the debugger only to a running service. The attachment process interrupts the current functioning of your service; it doesn’t actually stop or pause the service's processing. That is, if your service is running when you begin debugging, it is still technically in the Started state as you debug it, but its processing has been suspended.  
  
 After attaching to the process, you can set breakpoints and use these to debug your code. Once you exit the dialog box you use to attach to the process, you are effectively in debug mode. You can use the Services Control Manager to start, stop, pause and continue your service, thus hitting the breakpoints you've set. You can later remove this dummy service after debugging is successful.  
  
 This article covers debugging a service that's running on the local computer, but you can also debug Windows Services that are running on a remote computer. See [Remote Debugging](/visualstudio/debugger/debug-installed-app-package).  
  
> [!NOTE]
>  Debugging the <xref:System.ServiceProcess.ServiceBase.OnStart%2A> method can be difficult because the Services Control Manager imposes a 30-second limit on all attempts to start a service. For more information, see [Troubleshooting: Debugging Windows Services](../../../docs/framework/windows-services/troubleshooting-debugging-windows-services.md).  
  
> [!WARNING]
>  To get meaningful information for debugging, the Visual Studio debugger needs to find symbol files for the binaries that are being debugged. If you are debugging a service that you built in Visual Studio, the symbol files (.pdb files) are in the same folder as the executable or library, and the debugger loads them automatically. If you are debugging a service that you didn't build, you should first find symbols for the service and make sure they can be found by the debugger. See [Specify Symbol (.pdb) and Source Files](http://msdn.microsoft.com/library/1105e169-5272-4e7c-b3e7-cda1b7798a6b). If you're debugging a system process or want to have symbols for system calls in your services, you should add the Microsoft Symbol Servers. See [Debugging Symbols](http://msdn.microsoft.com/windows/desktop/ee416588.aspx).  
  
### To debug a service  
  
1.  Build your service in the Debug configuration.  
  
2.  Install your service. For more information, see [How to: Install and Uninstall Services](../../../docs/framework/windows-services/how-to-install-and-uninstall-services.md).  
  
3.  Start your service, either from **Services Control Manager**, **Server Explorer**, or from code. For more information, see [How to: Start Services](../../../docs/framework/windows-services/how-to-start-services.md).  
  
4.  Start Visual Studio with administrative credentials so you can attach to system processes.  
  
5.  (Optional) On the Visual Studio menu bar, choose **Tools**, **Options**. In the **Options** dialog box, choose **Debugging**, **Symbols**, select the **Microsoft Symbol Servers** check box, and then choose the **OK** button.  
  
6.  On the menu bar, choose **Attach to Process** from the **Debug** or **Tools** menu. (Keyboard: Ctrl+Alt+P)  
  
     The **Processes** dialog box appears.  
  
7.  Select the **Show processes from all users** check box.  
  
8.  In the **Available Processes** section, choose the process for your service, and then choose **Attach**.  
  
    > [!TIP]
    >  The process will have the same name as the executable file for your service.  
  
     The **Attach to Process** dialog box appears.  
  
9. Choose the appropriate options, and then choose **OK** to close the dialog box.  
  
    > [!NOTE]
    >  You are now in debug mode.  
  
10. Set any breakpoints you want to use in your code.  
  
11. Access the Services Control Manager and manipulate your service, sending stop, pause, and continue commands to hit your breakpoints. For more information about running the Services Control Manager, see [How to: Start Services](../../../docs/framework/windows-services/how-to-start-services.md). Also, see [Troubleshooting: Debugging Windows Services](../../../docs/framework/windows-services/troubleshooting-debugging-windows-services.md).  
  
## Debugging Tips for Windows Services  
 Attaching to the service's process allows you to debug most, but not all, the code for that service. For example, because the service has already been started, you cannot debug the code in the service's <xref:System.ServiceProcess.ServiceBase.OnStart%2A> method or the code in the `Main` method that is used to load the service this way. One way to work around this limitation is to create a temporary second service in your service application that exists only to aid in debugging. You can install both services, and then start this dummy service to load the service process. Once the temporary service has started the process, you can use the **Debug** menu in Visual Studio to attach to the service process.  
  
 Try adding calls to the <xref:System.Threading.Thread.Sleep%2A> method to delay action until you’re able to attach to the process.  
  
 Try changing the program to a regular console application. To do this, rewrite the `Main` method as follows so it can run both as a Windows Service and as a console application, depending on how it's started.  
  
#### How to: Run a Windows Service as a console application  
  
1.  Add a method to your service that runs the <xref:System.ServiceProcess.ServiceBase.OnStart%2A> and <xref:System.ServiceProcess.ServiceBase.OnStop%2A> methods:  
  
    ```  
    internal void TestStartupAndStop(string[] args)  
    {  
        this.OnStart(args);  
        Console.ReadLine();  
        this.OnStop();  
    }  
    ```  
  
2.  Rewrite the `Main` method as follows:  
  
    ```  
    static void Main(string[] args)  
            {  
                if (Environment.UserInteractive)  
                {  
                    MyNewService service1 = new MyNewService(args);  
                    service1.TestStartupAndStop(args);  
                }  
                else  
                {  
                    // Put the body of your old Main method here.  
                }  
    ```  
  
3.  In the **Application** tab of the project's properties, set the **Output type** to **Console Application**.  
  
4.  Choose **Start Debugging** (F5).  
  
5.  To run the program as a Windows Service again, install it and start it as usual for a Windows Service. It's not necessary to reverse these changes.  
  
 In some cases, such as when you want to debug an issue that occurs only on system startup, you have to use the Windows debugger. Install [Debugging Tools for Windows](http://msdn.microsoft.com/windows/hardware/hh852365) and see [How to debug Windows Services](http://support.microsoft.com/kb/824344).  
  
## See Also  
 [Introduction to Windows Service Applications](../../../docs/framework/windows-services/introduction-to-windows-service-applications.md)  
 [How to: Install and Uninstall Services](../../../docs/framework/windows-services/how-to-install-and-uninstall-services.md)  
 [How to: Start Services](../../../docs/framework/windows-services/how-to-start-services.md)  
 [Debugging a Service](http://msdn.microsoft.com/library/windows/desktop/ms682546.aspx)
