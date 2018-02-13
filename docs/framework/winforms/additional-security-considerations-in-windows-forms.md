---
title: "Additional Security Considerations in Windows Forms"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Windows Forms, secure calls to Windows API"
  - "security [Windows Forms]"
  - "security [Windows Forms], calling APIs"
  - "Clipboard [Windows Forms], securing access"
ms.assetid: 15abda8b-0527-47c7-aedb-77ab595f2bf1
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Additional Security Considerations in Windows Forms
[!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] security settings might cause your application to run differently in a partial trust environment than on your local computer. The [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] restricts access to such critical local resources as the file system, network, and unmanaged APIs, among other things. The security settings affect the ability to call the Microsoft Win32 API or other APIs that cannot be verified by the security system. Security also affects other aspects of your application, including file and data access, and printing. For more information about file and data access in a partial trust environment, see [More Secure File and Data Access in Windows Forms](../../../docs/framework/winforms/more-secure-file-and-data-access-in-windows-forms.md). For more information about printing in a partial trust environment, see [More Secure Printing in Windows Forms](../../../docs/framework/winforms/more-secure-printing-in-windows-forms.md).  
  
 The following sections discuss how to work with the Clipboard, perform window manipulation, and call the Win32 API from applications that are running in a partial trust environment.  
  
## Clipboard Access  
 The <xref:System.Security.Permissions.UIPermission> class controls access to the Clipboard, and the associated <xref:System.Security.Permissions.UIPermissionClipboard> enumeration value indicates the level of access. The following table shows the possible permission levels.  
  
|UIPermissionClipboard value|Description|  
|---------------------------------|-----------------|  
|<xref:System.Security.Permissions.UIPermissionClipboard.AllClipboard>|The Clipboard can be used without restriction.|  
|<xref:System.Security.Permissions.UIPermissionClipboard.OwnClipboard>|The Clipboard can be used with some restrictions. The ability to put data on the Clipboard (Copy or Cut command operations) is unrestricted. Intrinsic controls that accept paste, such as a text box, can accept Clipboard data, but user controls cannot programmatically read from the Clipboard.|  
|<xref:System.Security.Permissions.UIPermissionClipboard.NoClipboard>|The Clipboard cannot be used.|  
  
 By default, the Local Intranet zone receives <xref:System.Security.Permissions.UIPermissionClipboard.AllClipboard> access and the Internet zone receives <xref:System.Security.Permissions.UIPermissionClipboard.OwnClipboard> access. This means that the application can copy data to the Clipboard, but the application cannot programmatically paste to or read from the Clipboard. These restrictions prevent programs without full trust from reading content copied to the Clipboard by another application. If your application requires full Clipboard access but you do not have the permissions, you will have to elevate the permissions for your application. For more information about elevating permissions, see [General Security Policy Administration](http://msdn.microsoft.com/library/5121fe35-f0e3-402c-94ab-4f35b0a87b4b).  
  
## Window Manipulation  
 The <xref:System.Security.Permissions.UIPermission> class also controls permission to perform window manipulation and other UI-related actions, and the associated <xref:System.Security.Permissions.UIPermissionWindow> enumeration value indicates the level of access. The following table shows the possible permission levels.  
  
 By default, the Local Intranet zone receives <xref:System.Security.Permissions.UIPermissionWindow.AllWindows> access and the Internet zone receives <xref:System.Security.Permissions.UIPermissionWindow.SafeTopLevelWindows> access. This means that in the Internet zone, the application can perform most windowing and UI actions, but the window's appearance will be modified. The modified window displays a balloon notification when first run, contains modified title bar text, and requires a close button on the title bar. The balloon notification and the title bar identify to the user of the application that the application is running under partial trust.  
  
|UIPermissionWindow value|Description|  
|------------------------------|-----------------|  
|<xref:System.Security.Permissions.UIPermissionWindow.AllWindows>|Users can use all windows and user input events without restriction.|  
|<xref:System.Security.Permissions.UIPermissionWindow.SafeTopLevelWindows>|Users can use only safer top-level windows and safer subwindows for drawing, and can use only user input events for the user interface within those top-level windows and subwindows. These safer windows are clearly labeled and have minimum and maximum size restrictions. The restrictions prevent potentially harmful spoofing attacks, such as imitating system logon screens or the system desktop, and restricts programmatic access to parent windows, focus-related APIs, and use of the <xref:System.Windows.Forms.ToolTip> control,|  
|<xref:System.Security.Permissions.UIPermissionWindow.SafeSubWindows>|Users can use only safer subwindows for drawing, and can use only user input events for the user interface within that subwindow. A control displayed within a browser is an example of a safer subwindow.|  
|<xref:System.Security.Permissions.UIPermissionWindow.NoWindows>|Users cannot use any windows or user interface events. No user interface can be used.|  
  
 Each permission level identified by the <xref:System.Security.Permissions.UIPermissionWindow> enumeration allows fewer actions than the level above it. The following tables indicate the actions that are restricted by the <xref:System.Security.Permissions.UIPermissionWindow.SafeTopLevelWindows> and <xref:System.Security.Permissions.UIPermissionWindow.SafeSubWindows> values. For exact permissions that are required for each member, see the reference for that member in the .NET Framework class library documentation.  
  
 <xref:System.Security.Permissions.UIPermissionWindow.SafeTopLevelWindows> permission restricts the actions listed in the following table.  
  
|Component|Restricted actions|  
|---------------|------------------------|  
|<xref:System.Windows.Forms.Application>|-   Setting the <xref:System.Windows.Forms.Application.SafeTopLevelCaptionFormat%2A> property.|  
|<xref:System.Windows.Forms.Control>|-   Getting the <xref:System.Windows.Forms.Control.Parent%2A> property.<br />-   Setting the `Region` property.<br />-   Calling the <xref:System.Windows.Forms.Control.FindForm%2A> , <xref:System.Windows.Forms.Control.Focus%2A>, <xref:System.Windows.Forms.Control.FromChildHandle%2A> and <xref:System.Windows.Forms.Control.FromHandle%2A>, <xref:System.Windows.Forms.Control.PreProcessMessage%2A>, <xref:System.Windows.Forms.Control.ReflectMessage%2A>, or <xref:System.Windows.Forms.Control.SetTopLevel%2A> method.<br />-   Calling the <xref:System.Windows.Forms.Control.GetChildAtPoint%2A> method if the control returned is not a child of the calling control.<br />-   Modify control focus inside a container control.|  
|<xref:System.Windows.Forms.Cursor>|-   Setting the <xref:System.Windows.Forms.Cursor.Clip%2A> property.<br />-   Calling the <xref:System.Windows.Forms.Control.Hide%2A> method.|  
|<xref:System.Windows.Forms.DataGrid>|-   Calling the <xref:System.Windows.Forms.ContainerControl.ProcessTabKey%2A> method.|  
|<xref:System.Windows.Forms.Form>|-   Getting the <xref:System.Windows.Forms.Form.ActiveForm%2A> or <xref:System.Windows.Forms.Form.MdiParent%2A> property.<br />-   Setting the <xref:System.Windows.Forms.Form.ControlBox%2A>, <xref:System.Windows.Forms.Form.ShowInTaskbar%2A>, or <xref:System.Windows.Forms.Form.TopMost%2A> property.<br />-   Setting the <xref:System.Windows.Forms.Form.Opacity%2A> property below 50%.<br />-   Setting the <xref:System.Windows.Forms.Form.WindowState%2A> property to <xref:System.Windows.Forms.FormWindowState.Minimized> programmatically.<br />-   Calling the <xref:System.Windows.Forms.Form.Activate%2A> method.<br />-   Using the <xref:System.Windows.Forms.FormBorderStyle.None>, <xref:System.Windows.Forms.FormBorderStyle.FixedToolWindow>, and <xref:System.Windows.Forms.FormBorderStyle.SizableToolWindow><xref:System.Windows.Forms.FormBorderStyle> enumeration values.|  
|<xref:System.Windows.Forms.NotifyIcon>|-   Using the <xref:System.Windows.Forms.NotifyIcon> component is completely restricted.|  
  
 The <xref:System.Security.Permissions.UIPermissionWindow.SafeSubWindows> value restricts the actions listed in the following table, in addition to the restrictions placed by the <xref:System.Security.Permissions.UIPermissionWindow.SafeTopLevelWindows> value.  
  
|Component|Restricted actions|  
|---------------|------------------------|  
|<xref:System.Windows.Forms.CommonDialog>|-   Showing a dialog box derived from the <xref:System.Windows.Forms.CommonDialog> class.|  
|<xref:System.Windows.Forms.Control>|-   Calling the <xref:System.Windows.Forms.Control.CreateGraphics%2A> method.<br />-   Setting the <xref:System.Windows.Forms.Control.Cursor%2A> property.|  
|<xref:System.Windows.Forms.Control.Cursor%2A>|-   Setting the <xref:System.Windows.Forms.Cursor.Current%2A> property.|  
|<xref:System.Windows.Forms.MessageBox>|-   Calling the <xref:System.Windows.Forms.Form.Show%2A> method.|  
  
### Hosting Third-Party Controls  
 Another kind of window manipulation can occur if your forms host third-party controls. A third-party control is any custom <xref:System.Windows.Forms.UserControl> that you have not developed and compiled yourself. Although the hosting scenario is hard to exploit, it is theoretically possible for a third-party control to expand its rendering surface to cover the entire area of your form. This control could then mimic a critical dialog box, and request information such as username/password combinations or bank account numbers from your users.  
  
 To limit this potential risk, use third-party controls only from vendors you can trust. If you use third-party controls you have downloaded from an unverifiable source, we recommend that you review the source code for potential exploits. After you've verified that the source is non-malicious, you should compile the assembly yourself to ensure that the source matches the assembly.  
  
## Win32 API Calls  
 If your application design requires calling a function from the Win32 API, you are accessing unmanaged code. In this case the code's actions to the window or operating system cannot be determined when you are working with Win32 API calls or values. The <xref:System.Security.Permissions.SecurityPermission> class and the <xref:System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode> value of the <xref:System.Security.Permissions.SecurityPermissionFlag> enumeration control access to unmanaged code. An application can access unmanaged code only when it is granted the <xref:System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode> permission. By default, only applications that are running locally can call unmanaged code.  
  
 Some Windows Forms members provide unmanaged access that requires the <xref:System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode> permission. The following table lists the members in the <xref:System.Windows.Forms> namespace that require the permission. For more information about the permissions that are required for a member, see the .NET Framework class library documentation.  
  
|Component|Member|  
|---------------|------------|  
|<xref:System.Windows.Forms.Application>|-   <xref:System.Windows.Forms.Application.AddMessageFilter%2A> method<br />-   <xref:System.Windows.Forms.Application.CurrentInputLanguage%2A> property<br />-   `Exit` method<br />-   <xref:System.Windows.Forms.Application.ExitThread%2A> method<br />-   <xref:System.Windows.Forms.Application.ThreadException> event|  
|<xref:System.Windows.Forms.CommonDialog>|-   <xref:System.Windows.Forms.CommonDialog.HookProc%2A> method<br />-   <xref:System.Windows.Forms.CommonDialog.OwnerWndProc%2A>\ method<br />-   <xref:System.Windows.Forms.CommonDialog.Reset%2A> method<br />-   <xref:System.Windows.Forms.CommonDialog.RunDialog%2A> method|  
|<xref:System.Windows.Forms.Control>|-   <xref:System.Windows.Forms.Control.CreateParams%2A> method<br />-   <xref:System.Windows.Forms.Control.DefWndProc%2A> method<br />-   <xref:System.Windows.Forms.Control.DestroyHandle%2A> method<br />-   <xref:System.Windows.Forms.Control.WndProc%2A> method|  
|<xref:System.Windows.Forms.Help>|-   <xref:System.Windows.Forms.Help.ShowHelp%2A> methods<br />-   <xref:System.Windows.Forms.Help.ShowHelpIndex%2A> method|  
|<xref:System.Windows.Forms.NativeWindow>|-   <xref:System.Windows.Forms.NativeWindow> class|  
|<xref:System.Windows.Forms.Screen>|-   <xref:System.Windows.Forms.Screen.FromHandle%2A> method|  
|<xref:System.Windows.Forms.SendKeys>|-   <xref:System.Windows.Forms.SendKeys.Send%2A> method<br />-   <xref:System.Windows.Forms.SendKeys.SendWait%2A> method|  
  
 If your application does not have permission to call unmanaged code, your application must request <xref:System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode> permission, or you must consider alternative ways of implementing features; in many cases, Windows Forms provides a managed alternative to Win32 API functions. If no alternative means exist and the application must access unmanaged code, you will have to elevate the permissions for the application.  
  
 Permission to call unmanaged code allows an application to perform most anything. Therefore, permission to call unmanaged code should only be granted for applications that come from a trusted source. Alternatively, depending on the application, the piece of application functionality that makes the call to unmanaged code could be optional, or enabled in the full trust environment only. For more information about dangerous permissions, see [Dangerous Permissions and Policy Administration](../../../docs/framework/misc/dangerous-permissions-and-policy-administration.md). For more information about elevating permissions, see [NIB: General Security Policy Administration](http://msdn.microsoft.com/library/5121fe35-f0e3-402c-94ab-4f35b0a87b4b).  
  
## See Also  
 [More Secure File and Data Access in Windows Forms](../../../docs/framework/winforms/more-secure-file-and-data-access-in-windows-forms.md)  
 [More Secure Printing in Windows Forms](../../../docs/framework/winforms/more-secure-printing-in-windows-forms.md)  
 [Security in Windows Forms Overview](../../../docs/framework/winforms/security-in-windows-forms-overview.md)  
 [Windows Forms Security](../../../docs/framework/winforms/windows-forms-security.md)  
 [Securing ClickOnce Applications](/visualstudio/deployment/securing-clickonce-applications)
