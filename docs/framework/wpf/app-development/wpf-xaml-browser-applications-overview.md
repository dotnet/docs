---
title: "WPF XAML Browser Applications Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "XBAP [WPF], XAML browser application"
  - "WPF XAML browser applications (XBAP)"
  - "XAML browser applications (XBAP)"
  - "browser-hosted applications [WPF]"
ms.assetid: 3a7a86a8-75d5-4898-96b9-73da151e5e16
caps.latest.revision: 47
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# WPF XAML Browser Applications Overview
<a name="introduction"></a>
[!INCLUDE[TLA#tla_xbap#plural](../../../../includes/tlasharptla-xbapsharpplural-md.md)] combines features of both Web applications and rich-client applications. Like Web applications, XBAPs can be deployed to a Web server and started from Internet Explorer or Firefox. Like rich-client applications, XBAPs can take advantage of the capabilities of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)]. Developing XBAPs is also similar to rich-client development. This topic provides a simple, high-level introduction to XBAP development and describes where XBAP development differs from standard rich-client development.  
  
 This topic contains the following sections:  
  
-   [Creating a New XAML Browser Application (XBAP)](#creating_a_new_xaml_browser_application_xbap)  
  
-   [Deploying an XBAP](#deploying_a_xbap)  
  
-   [Communicating with the Host Web Page](#communicating_with_the_host_web_page)  
  
-   [XBAP Security Considerations](#xbap_security_considerations)  
  
-   [XBAP Start Time Performance Considerations](#xbap_start_time_performance_considerations)  
  
<a name="creating_a_new_xaml_browser_application_xbap"></a>   
## Creating a New XAML Browser Application (XBAP)  
 The simplest way to create a new XBAP project is with [!INCLUDE[vs_dev10_ext](../../../../includes/vs-dev10-ext-md.md)]. When creating a new project, select **WPF Browser Application** from the list of templates. For more information, see [How to: Create a New WPF Browser Application Project](http://msdn.microsoft.com/library/72ef4d90-e163-42a1-8df0-ea7ccfd1901f).  
  
 When you run the XBAP project, it opens in a browser window instead of a stand-alone window. When you debug the XBAP from [!INCLUDE[TLA#tla_visualstu](../../../../includes/tlasharptla-visualstu-md.md)], the application runs with Internet zone permission and will therefore throw security exceptions if those permissions are exceeded. For more information, see [Security](../../../../docs/framework/wpf/security-wpf.md) and [WPF Partial Trust Security](../../../../docs/framework/wpf/wpf-partial-trust-security.md).  
  
> [!NOTE]
>  If you are not developing with [!INCLUDE[TLA#tla_visualstu](../../../../includes/tlasharptla-visualstu-md.md)] or want to learn more about the project files, see [Building a WPF Application](../../../../docs/framework/wpf/app-development/building-a-wpf-application-wpf.md).  
  
<a name="deploying_a_xbap"></a>   
## Deploying an XBAP  
 When you build an XBAP, the output includes the following three files:  
  
|File|Description|  
|----------|-----------------|  
|Executable (.exe)|This contains the compiled code and has an .exe extension.|  
|Application manifest (.manifest)|This contains metadata associated with the application and has a .manifest extension.|  
|Deployment manifest (.xbap)|This file contains the information that [!INCLUDE[TLA#tla_clickonce](../../../../includes/tlasharptla-clickonce-md.md)] uses to deploy the application and has the .xbap extension.|  
  
 You deploy XBAPs to a Web server, for example [!INCLUDE[TLA#tla_iis50](../../../../includes/tlasharptla-iis50-md.md)] or later versions. You do not have to install the [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] on the Web server, but you do have to register the [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] [!INCLUDE[TLA#tla_mime](../../../../includes/tlasharptla-mime-md.md)] types and file name extensions. For more information, see [Configure IIS 5.0 and IIS 6.0 to Deploy WPF Applications](../../../../docs/framework/wpf/app-development/how-to-configure-iis-5-0-and-iis-6-0-to-deploy-wpf-applications.md).  
  
 To prepare your XBAP for deployment, copy the .exe and the associated manifests to the Web server. Create an HTML page that contains a hyperlink to open the deployment manifest, which is the file that has the .xbap extension. When the user clicks the link to the .xbap file, [!INCLUDE[TLA2#tla_clickonce](../../../../includes/tla2sharptla-clickonce-md.md)] automatically handles the mechanics of downloading and starting the application. The following example code shows an HTML page that contains a hyperlink that points to an XBAP.  
  
```html
<html>   
    <head></head>  
    <body>   
        <a href="XbapEx.xbap">Click this link to launch the application</a>  
    </body>   
</html>  
```  
  
 You can also host an XBAP in the frame of a Web page. Create a Web page with one or more frames. Set the source property of a frame to the deployment manifest file. If you want to use the built-in mechanism to communicate between the hosting Web page and the XBAP, you must host the application in a frame. The following example code shows an HTML page with two frames, the source for the second frame is set to an XBAP.  
  
```html
<html>   
    <head>
        <title>A page with frames</title>
    </head>  
    <frameset cols="50%,50%">   
        <frame src="introduction.htm">   
        <frame src="XbapEx.xbap">   
    </frameset>   
</html>  
```  
  
### Clearing Cached XBAPs  
 In some situations after rebuilding and starting your XBAP, you may find that an earlier version of the XBAP is opened. For example, this behavior may occur when your XBAP assembly version number is static and you start the XBAP from the command line. In this case, because the version number between the cached version (the version that was previously started) and the new version remains the same, the new version of the XBAP is not downloaded. Instead, the cached version is loaded.  
  
 In these situations, you can remove the cached version by using the **Mage** command (installed with Visual Studio or the [!INCLUDE[TLA2#tla_lhsdk](../../../../includes/tla2sharptla-lhsdk-md.md)]) at the command prompt. The following command clears the application cache.  
  
 ```console
 Mage.exe -cc
 ```
  
 This command guarantees that the latest version of your XBAP is started. When you debug your application in [!INCLUDE[TLA2#tla_visualstu](../../../../includes/tla2sharptla-visualstu-md.md)], the latest version of your XBAP should be started. In general, you should update your deployment version number with each build. For more information about Mage, see [Mage.exe (Manifest Generation and Editing Tool)](../../../../docs/framework/tools/mage-exe-manifest-generation-and-editing-tool.md).  
  
<a name="communicating_with_the_host_web_page"></a>   
## Communicating with the Host Web Page  
 When the application is hosted in an HTML frame, you can communicate with the Web page that contains the XBAP. You do this by retrieving the <xref:System.Windows.Interop.BrowserInteropHelper.HostScript%2A> property of <xref:System.Windows.Interop.BrowserInteropHelper>. This property returns a script object that represents the HTML window. You can then access the properties, methods, and events on the [window object](http://go.microsoft.com/fwlink/?LinkId=160274) by using regular dot syntax. You can also access script methods and global variables. The following example shows how to retrieve the script object and close the browser.  
  
 [!code-csharp[XbapBrowserInterop#10](../../../../samples/snippets/csharp/VS_Snippets_Wpf/xbapbrowserinterop/cs/page1.xaml.cs#10)]
 [!code-vb[XbapBrowserInterop#10](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/xbapbrowserinterop/vb/page1.xaml.vb#10)]  
  
### Debugging XBAPs that Use HostScript  
 If your XBAP uses the <xref:System.Windows.Interop.BrowserInteropHelper.HostScript%2A> object to communicate with the HTML window, there are two settings that you must specify to run and debug the application in [!INCLUDE[TLA2#tla_visualstu](../../../../includes/tla2sharptla-visualstu-md.md)]. The application must have access to its site of origin and you must start the application with the HTML page that contains the XBAP. The following steps describe how to check these two settings:  
  
1.  In Visual Studio, open the project properties.  
  
2.  On the **Security** tab, click **Advanced**.  
  
     The Advanced Security Settings dialog box appears.  
  
3.  Make sure that the **Grant the application access to its site of origin** check box is checked and then click **OK**.  
  
4.  On the **Debug** tab, select the **Start browser with URL** option and specify the URL for the HTML page that contains the XBAP.  
  
5.  In Internet Explorer, click the **Tools** button and then select **Internet Options**.  
  
     The Internet Options dialog box appears.  
  
6.  Click the **Advanced** tab.  
  
7.  In the **Settings** list under **Security**, check the **Allow active content to run in files on My Computer** check box.  
  
8.  Click **OK**.  
  
     The changes will take effect after you restart Internet Explorer.  
  
> [!CAUTION]
>  Enabling active content in Internet Explorer may put your computer at risk. For more information, see [Security and privacy features in Internet Explorer](http://go.microsoft.com/fwlink/?LinkId=179286). If you do not want to change your Internet Explorer security settings, you can launch the HTML page from a server and attach the [!INCLUDE[TLA2#tla_visualstu](../../../../includes/tla2sharptla-visualstu-md.md)] debugger to the process.  
  
<a name="xbap_security_considerations"></a>   
## XBAP Security Considerations  
 XBAPs typically execute in a partial-trust security sandbox that is restricted to the Internet zone permission set. Consequently, your implementation must support the subset of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] elements that are supported in the Internet zone or you must elevate the permissions of your application. For more information, see [Security](../../../../docs/framework/wpf/security-wpf.md).  
  
 When you use a <xref:System.Windows.Controls.WebBrowser> control in your application, WPF internally instantiates the native WebBrowser ActiveX control. When your application is a partial-trust XBAP running in Internet Explorer, the ActiveX control runs in a dedicated thread of the Internet Explorer process. Therefore, the following limitations apply:  
  
-   The <xref:System.Windows.Controls.WebBrowser> control should provide behavior similar to the host browser, including security restrictions. Some of these security restrictions can be controlled through the Internet Explorer security settings. For more information, see [Security](../../../../docs/framework/wpf/security-wpf.md).  
  
-   An exception is thrown when an XBAP is loaded cross-domain in an HTML page.  
  
-   Input is on a separate thread from the WPF <xref:System.Windows.Controls.WebBrowser>, so keyboard input cannot be intercepted and the IME state is not shared.  
  
-   The timing or order of navigation may be different due to the ActiveX control running on another thread. For example, navigating to a page is not always cancelled by starting another navigation request.  
  
-   A custom ActiveX control may have trouble with communication since the WPF application is running in a separate thread.  
  
-   <xref:System.Windows.Interop.HwndHost.MessageHook> does not get raised because <xref:System.Windows.Interop.HwndHost> cannot subclass a window running in another thread or process.  
  
### Creating a Full-Trust XBAP  
 If your XBAP requires full trust, you can change your project to enable this permission. The following steps describe how to enable full trust:  
  
1.  In Visual Studio, open the project properties.  
  
2.  On the **Security** tab, select the **This is a full trust application** option.  
  
 This setting makes the following changes:  
  
-   In the project file, the `<TargetZone>` element value is changed to `Custom`.  
  
-   In the application manifest (app.manifest), an `Unrestricted="true"` attribute is added to the `PermissionSet` element.  
  
    ```xml
    <PermissionSet class="System.Security.PermissionSet"   
                   version="1"   
                   ID="Custom"   
                   SameSite="site"   
                   Unrestricted="true" />  
    ```  
  
### Deploying a Full-Trust XBAP  
 When you deploy a full-trust XBAP that does not follow the ClickOnce Trusted Deployment model, the behavior when the user runs the application will depend on the security zone. In some cases, the user will receive a warning when they attempt to install it. The user can choose to continue or cancel the installation. The following table describes the behavior of the application for each security zone and what you have to do for the application to receive full trust.  
  
|Security Zone|Behavior|Getting Full Trust|  
|-------------------|--------------|------------------------|  
|Local computer|Automatic full trust|No action is needed.|  
|Intranet and trusted sites|Prompt for full trust|Sign the XBAP with a certificate so that the user sees the source in the prompt.|  
|Internet|Fails with "Trust Not Granted"|Sign the XBAP with a certificate.|  
  
> [!NOTE]
>  The behavior described in the previous table is for full-trust XBAPs that do not follow the ClickOnce Trusted Deployment model.  
  
 It is recommended that you use the ClickOnce Trusted Deployment model for deploying a full-trust XBAP. This model allows your XBAP to be granted full trust automatically, regardless of the security zone, so that the user is not prompted. As part of this model, you must sign your application with a certificate from a trusted publisher. For more information, see [Trusted Application Deployment Overview](/visualstudio/deployment/trusted-application-deployment-overview) and [Introduction to Code Signing](http://go.microsoft.com/fwlink/?LinkId=166327).  
  
<a name="xbap_start_time_performance_considerations"></a>   
## XBAP Start Time Performance Considerations  
 An important aspect of XBAP performance is its start time. If an XBAP is the first WPF application to load, the *cold start* time can be ten seconds or more. This is because the progress page is rendered by WPF, and both the CLR and WPF must be cold-started to display the application.  
  
 Starting in [!INCLUDE[net_v35SP1_short](../../../../includes/net-v35sp1-short-md.md)], XBAP cold-start time is mitigated by displaying an unmanaged progress page early in the deployment cycle. The progress page appears almost immediately after the application is started, because it is displayed by native hosting code and rendered in HTML.  
  
 In addition, improved concurrency of the [!INCLUDE[ndptecclick](../../../../includes/ndptecclick-md.md)] download sequence improves the start time by up to ten percent. After [!INCLUDE[ndptecclick](../../../../includes/ndptecclick-md.md)] downloads and validates manifests, the application download starts, and the progress bar starts to update.  
  
## See Also  
 [Configure Visual Studio to Debug a XAML Browser Application to Call a Web Service](../../../../docs/framework/wpf/app-development/configure-vs-to-debug-a-xaml-browser-to-call-a-web-service.md)  
 [Deploying a WPF Application](../../../../docs/framework/wpf/app-development/deploying-a-wpf-application-wpf.md)
