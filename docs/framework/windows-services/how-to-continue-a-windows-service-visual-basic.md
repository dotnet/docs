---
title: "How to: Continue a Windows Service (Visual Basic)"
description: Read how to use the ServiceController component to continue a Windows service (such as the IIS Admin service) on a local computer with Visual Basic.
ms.date: "03/30/2017"
dev_langs: 
  - "vb"
f1_keywords: 
  - "ServiceController.Continue"
helpviewer_keywords: 
  - "Windows Service applications, pausing"
  - "pausing Windows Service applications"
ms.assetid: e5d13760-4c83-4b0d-abef-39852677cd7a
---
# How to: Continue a Windows Service (Visual Basic)

[!INCLUDE [windows-service-disambiguation](../../core/extensions/includes/windows-service-disambiguation.md)]

This example uses the <xref:System.ServiceProcess.ServiceController> component to continue the IIS Admin service on the local computer.  
  
## Example  

 [!code-vb[VbRadconService#11](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbRadconService/VB/MyNewService.vb#11)]  
[!code-vb[VbRadconService#13](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbRadconService/VB/MyNewService.vb#13)]  
  
 This code example is also available as an IntelliSense code snippet. In the code snippet picker, it is located in **Windows Operating System > Windows Services**. For more information, see [Code Snippets](/visualstudio/ide/code-snippets).  
  
## Compiling the Code  

 This example requires:  
  
- A project reference to System.serviceprocess.dll.  
  
- Access to the members of the <xref:System.ServiceProcess> namespace. Add an `Imports` statement if you are not fully qualifying member names in your code. For more information, see [Imports Statement (.NET Namespace and Type)](../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md).  
  
## Robust Programming  

 The <xref:System.ServiceProcess.ServiceController.MachineName%2A> property of the <xref:System.ServiceProcess.ServiceController> class is the local computer by default. To reference Windows services on another computer, change the <xref:System.ServiceProcess.ServiceController.MachineName%2A> property to the name of that computer.  
  
 You cannot call the <xref:System.ServiceProcess.ServiceController.Continue%2A> method on a service until the service controller status is <xref:System.ServiceProcess.ServiceControllerStatus.Paused>.  
  
 The following conditions may cause an exception:  
  
- The service cannot be resumed. (<xref:System.InvalidOperationException>)  
  
- An error occurred when accessing a system API. (<xref:System.ComponentModel.Win32Exception>)  
  
## .NET Framework Security  

 Control of services on the computer may be restricted by using the <xref:System.ServiceProcess.ServiceControllerPermissionAccess> enumeration to set permissions in the <xref:System.ServiceProcess.ServiceControllerPermission> class.  
  
 Access to service information may be restricted by using the <xref:System.Security.Permissions.PermissionState> enumeration to set permissions in the <xref:System.Security.Permissions.SecurityPermission> class.  
  
## See also

- <xref:System.ServiceProcess.ServiceController>
- <xref:System.ServiceProcess.ServiceControllerStatus>
- [How to: Pause a Windows Service (Visual Basic)](how-to-pause-a-windows-service-visual-basic.md)
