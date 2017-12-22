---
title: "WPF Security Strategy - Platform Security"
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
  - "platform security model [WPF]"
  - "Common Language Runtime (CLR) security features"
  - "operating system security model [WPF]"
  - "Internet Explorer security features [WPF]"
  - "Security-Critical method"
  - "CLR security features [WPF]"
  - "security model [WPF]"
  - "security model [WPF], platform"
  - "WPF [WPF], about security model"
  - "Windows Presentation Foundation [WPF], about security model"
  - "security model [WPF], operating system"
ms.assetid: 2a39a054-3e2a-4659-bcb7-8bcea490ba31
caps.latest.revision: 30
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# WPF Security Strategy - Platform Security
While [!INCLUDE[TLA#tla_wpf](../../../includes/tlasharptla-wpf-md.md)] provides a variety of security services, it also leverages the security features of the underlying platform, which includes the operating system, the [!INCLUDE[TLA2#tla_clr](../../../includes/tla2sharptla-clr-md.md)], and [!INCLUDE[TLA2#tla_ie](../../../includes/tla2sharptla-ie-md.md)]. These layers combine to provide [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] a strong, defense-in-depth security model that attempts to avoid any single point of failure, as shown in the following figure:  
  
 ![WPF security illustration](../../../docs/framework/wpf/media/windowplatformsecurity.PNG "windowplatformsecurity")  
  
 The remainder of this topic discusses the features in each of these layers that pertain to [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] specifically.  
  

  
<a name="Operating_System_Security"></a>   
## Operating System Security  
 The minimum level of operating system that is required by [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] is [!INCLUDE[TLA2#tla_winxpsp2](../../../includes/tla2sharptla-winxpsp2-md.md)]. The core of [!INCLUDE[TLA2#tla_winxpsp2](../../../includes/tla2sharptla-winxpsp2-md.md)] provides several security features that form the security foundation for all [!INCLUDE[TLA2#tla_win](../../../includes/tla2sharptla-win-md.md)] applications, including those built with [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)]. [!INCLUDE[TLA#tla_longhorn](../../../includes/tlasharptla-longhorn-md.md)] incorporates the security features of [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] and extends them further. This topic discusses the breadth of these security features that are important to [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)], as well as how [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] integrates with them to provide further defense-in-depth.  
  
<a name="Microsoft_Windows_XP_Service_Pack_2__SP2_"></a>   
### Microsoft Windows XP Service Pack 2 (SP2)  
 In addition to a general review and strengthening of [!INCLUDE[TLA2#tla_win](../../../includes/tla2sharptla-win-md.md)], there are three key features from [!INCLUDE[TLA2#tla_winxpsp2](../../../includes/tla2sharptla-winxpsp2-md.md)] that we will discuss in this topic:  
  
-   /GS compilation  
  
-   [!INCLUDE[TLA#tla_win_update](../../../includes/tlasharptla-win-update-md.md)].  
  
#### /GS Compilation  
 [!INCLUDE[TLA2#tla_winxpsp2](../../../includes/tla2sharptla-winxpsp2-md.md)] provides protection by recompiling many core system libraries, including all of the [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] dependencies such as the [!INCLUDE[TLA2#tla_clr](../../../includes/tla2sharptla-clr-md.md)], to help mitigate buffer overruns. This is achieved by using the /GS parameter with the C/C++ command-line compiler. Although buffer overruns should be explicitly avoided, /GS compilation provides an example of a defense-in-depth against potential vulnerabilities that are inadvertently or maliciously created by them.  
  
 Historically, buffer overruns have been the cause of many high-impact security exploits. A buffer overrun occurs when an attacker takes advantage of a code vulnerability that allows the injection of malicious code that writes past the boundaries of a buffer. This then allows an attacker to hijack the process in which the code is executing by overwriting the return address of a function to cause the execution of the attacker's code. The result is malicious code that executes arbitrary code with the same privileges as the hijacked process.  
  
 At a high level, the /GS compiler flag protects against some potential buffer overruns by injecting a special security cookie to protect the return address of a function that has local string buffers. After a function returns, the security cookie is compared with its previous value. If the value has changed, a buffer overrun may have occurred and the process is stopped with an error condition. Stopping the process prevents the execution of potentially malicious code. See [/GS (Buffer Security Check)](http://msdn.microsoft.com/library/8dbf701c.aspx) for more details.  
  
 [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] is compiled with the /GS flag to add yet another layer of defense to [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] applications.  
  
#### Microsoft Windows Update Enhancements  
 [!INCLUDE[TLA#tla_win_update](../../../includes/tlasharptla-win-update-md.md)] was also improved in [!INCLUDE[TLA2#tla_winxpsp2](../../../includes/tla2sharptla-winxpsp2-md.md)] to simplify the process for downloading and installing updates. These changes significantly enhance security for [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] customers by helping to ensure that their systems are up-to-date, particularly with respect to security updates.  
  
<a name="Windows_Vista"></a>   
### Windows Vista  
 [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] users on [!INCLUDE[TLA#tla_longhorn](../../../includes/tlasharptla-longhorn-md.md)] will benefit from the operating system's additional security enhancements, including "Least-Privilege User Access", code integrity checks, and privilege isolation.  
  
#### User Account Control (UAC)  
 Today, [!INCLUDE[TLA2#tla_win](../../../includes/tla2sharptla-win-md.md)] users tend to run with administrator privileges because many applications require them for either installation or execution, or both. Being able to write default application settings to the Registry is one example.  
  
 Running with administrator privileges really means that applications execute from processes that are granted administrator privileges. The security impact of this is that any malicious code that hijacks a process running with administrator privileges will automatically inherit those privileges, including access to critical system resources.  
  
 One way to protect against this security threat is to run applications with the least amount of privileges that are required. This is known as the principle of least privilege, and is a core feature of the [!INCLUDE[TLA#tla_longhorn](../../../includes/tlasharptla-longhorn-md.md)] operating system. This feature is called User Account Control (UAC), and is used by [!INCLUDE[TLA#tla_longhorn](../../../includes/tlasharptla-longhorn-md.md)] UAC in two key ways:  
  
-   To run most applications with UAC privileges by default, even if the user is an administrator; only applications that need administrator privileges will run with administrator privileges. To run with administrative privileges, applications must be explicitly marked in either their application manifest or as an entry in security policy.  
  
-   To provide compatibility solutions like virtualization. For example, many applications try to write to restricted locations like C:\Program Files. For applications executing under UAC, an alternative per-user location exists that does not require administrator privileges to write to. For applications running under UAC, UAC virtualizes C:\Program Files so that applications who think they are writing to it are actually writing to the alternative, per-user location. This kind of compatibility work enables the operating system to run many applications that couldn't previously run in UAC.  
  
#### Code Integrity Checks  
 [!INCLUDE[TLA#tla_longhorn](../../../includes/tlasharptla-longhorn-md.md)] incorporates deeper code integrity checks to help prevent malicious code from being injected into system files or into the kernel at load/run time. This goes beyond system file protection.  
  
<a name="Limited_Rights_Process_for_Browser_Hosted_Applications"></a>   
### Limited Rights Process for Browser-Hosted Applications  
 Browser-hosted [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] applications execute within the Internet zone sandbox. [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] integration with [!INCLUDE[TLA#tla_ie](../../../includes/tlasharptla-ie-md.md)] extends this protection with additional support.  
  
#### Internet Explorer 6 Service Pack 2 and Internet Explorer 7 for XP  
 [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] leverages operating system security by limiting process privileges for [!INCLUDE[TLA#tla_winfxwebapp#plural](../../../includes/tlasharptla-winfxwebappsharpplural-md.md)] for further protection. Before a browser-hosted [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] application is launched, the operating system creates a host process that removes unnecessary privileges from the process token. Some examples of privileges that are removed include the ability to shut down the user's machine, load drivers, and read access to all files on the machine.  
  
#### Internet Explorer 7 for Vista  
 In [!INCLUDE[TLA#tla_ie7](../../../includes/tlasharptla-ie7-md.md)], [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] applications run in protected mode. Specifically, [!INCLUDE[TLA#tla_xbap#plural](../../../includes/tlasharptla-xbapsharpplural-md.md)] run with medium-level integrity.  
  
#### Defense-In-Depth Layer  
 Since [!INCLUDE[TLA#tla_winfxwebapp#plural](../../../includes/tlasharptla-winfxwebappsharpplural-md.md)] are generally sandboxed by the Internet zone permission set, removing these privileges does not harm [!INCLUDE[TLA#tla_winfxwebapp#plural](../../../includes/tlasharptla-winfxwebappsharpplural-md.md)] from a compatibility perspective. Instead, an additional defense-in-depth layer is created; if a sandboxed application is able to exploit other layers and hijack the process, the process will still only have limited privileges.  
  
 See [Using a Least-Privileged User Account](http://technet.microsoft.com/library/cc700846.aspx).  
  
<a name="Common_Language_Runtime_Security"></a>   
## Common Language Runtime Security  
 The [!INCLUDE[TLA#tla_clr](../../../includes/tlasharptla-clr-md.md)] offers a number of key security benefits that include validation and verification, [!INCLUDE[TLA#tla_cas](../../../includes/tlasharptla-cas-md.md)], and the Security Critical Methodology.  
  
<a name="Validation_and_Verification"></a>   
### Validation and Verification  
 To provide assembly isolation and integrity, the [!INCLUDE[TLA2#tla_clr](../../../includes/tla2sharptla-clr-md.md)] uses a process of validation. [!INCLUDE[TLA2#tla_clr](../../../includes/tla2sharptla-clr-md.md)] validation ensures that assemblies are isolated by validating their Portable Executable (PE) file format for addresses that point outside the assembly. [!INCLUDE[TLA2#tla_clr](../../../includes/tla2sharptla-clr-md.md)] validation also validates the integrity of the metadata that is embedded within an assembly.  
  
 To ensure type safety, help prevent common security issues (e.g. buffer overruns), and enable sandboxing through sub-process isolation, [!INCLUDE[TLA2#tla_clr](../../../includes/tla2sharptla-clr-md.md)] security uses the concept of verification.  
  
 Managed applications are compiled into Microsoft Intermediate Language (MSIL). When methods in a managed application are executed, its MSIL is compiled into native code through Just-In-Time (JIT) compilation. JIT compilation includes a verification process that applies many safety and robustness rules that ensure code does not:  
  
-   Violate type contracts  
  
-   Introduce buffer overruns  
  
-   Wildly access memory.  
  
 Managed code that does not conform to verification rules is not allowed to execute, unless it is considered trusted code.  
  
 The advantage of verifiable code is a key reason why [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] builds on the [!INCLUDE[TLA2#tla_winfx](../../../includes/tla2sharptla-winfx-md.md)]. To the extent that verifiable code is used, the possibility of exploiting possible vulnerabilities is greatly lowered.  
  
<a name="Code_Access_Security"></a>   
### Code Access Security  
 A client machine exposes a wide variety of resources that a managed application can have access to, including the file system, the Registry, printing services, the user interface, reflection, and environment variables. Before a managed application can access any of the resources on a client machine, it must have [!INCLUDE[TLA2#tla_winfx](../../../includes/tla2sharptla-winfx-md.md)][!INCLUDE[TLA#tla_cas](../../../includes/tlasharptla-cas-md.md)] permission to do so. A permission in [!INCLUDE[TLA2#tla_cas](../../../includes/tla2sharptla-cas-md.md)] is a subclass of the <xref:System.Security.CodeAccessPermission>; [!INCLUDE[TLA2#tla_cas](../../../includes/tla2sharptla-cas-md.md)] implements one subclass for each resource that managed applications can access.  
  
 The set of permissions that a managed application is granted by [!INCLUDE[TLA2#tla_cas](../../../includes/tla2sharptla-cas-md.md)] when it starts executing is known as a permission set and is determined by evidence provided by the application. For [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] applications, the evidence that is provided is the location, or zone, from which the applications are launched. [!INCLUDE[TLA2#tla_cas](../../../includes/tla2sharptla-cas-md.md)] identifies the following zones:  
  
-   **My Computer**. Applications launched from the client machine (Fully Trusted).  
  
-   **Local Intranet**. Applications launched from the intranet. (Somewhat Trusted).  
  
-   **Internet**. Applications launched from the Internet. (Least Trusted).  
  
-   **Trusted Sites**. Applications identified by a user as being trusted. (Least Trusted).  
  
-   **Untrusted Sites**. Applications identified by a user as being untrusted. (Untrusted).  
  
 For each of these zones, [!INCLUDE[TLA2#tla_cas](../../../includes/tla2sharptla-cas-md.md)] provides a predefined permission set that includes the permissions which matches the level of trust associated with each. These include:  
  
-   **FullTrust**. For applications launched from the **My Computer** zone. All possible permissions are granted.  
  
-   **LocalIntranet**. For applications launched from the **Local Intranet** zone. A subset of permissions are granted to provide moderate access to a client machine’s resources, including isolated storage, unrestricted UI access, unrestricted file dialogs, limited reflection, limited access to environment variables. Permissions for critical resources like the Registry are not provided.  
  
-   **Internet**. For applications launched from the **Internet** or **Trusted Sites** zone. A subset of permissions are granted to provided limited access to a client machine’s resources, including isolated storage, file open only, and limited UI. Essentially, this permission sets isolates applications from the client machine.  
  
 Applications identified as being from the **Untrusted Sites** zone are granted no permissions by [!INCLUDE[TLA2#tla_cas](../../../includes/tla2sharptla-cas-md.md)] at all. Consequently, a predefined permission set does not exist for them.  
  
 The following figure illustrates the relationship between zones, permission sets, permissions, and resources.  
  
 ![CAS permission sets](../../../docs/framework/wpf/media/caspermissionsets.png "CASPermissionSets")  
  
 The restrictions of the Internet zone security sandbox apply equally to any code that a [!INCLUDE[TLA2#tla_winfxwebapp](../../../includes/tla2sharptla-winfxwebapp-md.md)] imports from a system library, including [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)]. This ensures that every bit of the code is locked down, even [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)]. Unfortunately, to be able to execute, a [!INCLUDE[TLA2#tla_winfxwebapp](../../../includes/tla2sharptla-winfxwebapp-md.md)] needs to execute functionality that requires more permissions than those enabled by the Internet zone security sandbox.  
  
 Consider a [!INCLUDE[TLA2#tla_winfxwebapp](../../../includes/tla2sharptla-winfxwebapp-md.md)] application that includes the following page:  
  
 [!code-csharp[WPFPlatformSecuritySnippets#Permission](../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFPlatformSecuritySnippets/CSharp/Page1.xaml.cs#permission)]
 [!code-vb[WPFPlatformSecuritySnippets#Permission](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFPlatformSecuritySnippets/VisualBasic/Page1.xaml.vb#permission)]  
  
 To execute this [!INCLUDE[TLA2#tla_winfxwebapp](../../../includes/tla2sharptla-winfxwebapp-md.md)], the underlying [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] code must execute more functionality than is available to the calling [!INCLUDE[TLA2#tla_winfxwebapp](../../../includes/tla2sharptla-winfxwebapp-md.md)], including:  
  
-   Creating a window handle (hWnd) for rendering  
  
-   Dispatching messages  
  
-   Loading the Tahoma font  
  
 From a security point of view, allowing direct access to any of these operations from the sandboxed application would be catastrophic.  
  
 Fortunately, [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] caters to this situation by allowing these operations to execute with elevated privileges on behalf of the sandboxed application. While all [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] operations are checked against the limited Internet zone security permissions of the application domain of the [!INCLUDE[TLA2#tla_winfxwebapp](../../../includes/tla2sharptla-winfxwebapp-md.md)], [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] (as with other system libraries) is granted a permission set that includes all possible permissions  
  
 This requires that [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] receives elevated privileges while preventing those privileges from being governed by the Internet zone permission set of the host application domain.  
  
 [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] does this by using the **Assert** method of a permission. The following code shows how this happens.  
  
 [!code-csharp[WPFPlatformSecuritySnippets#Permission](../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFPlatformSecuritySnippets/CSharp/Page1.xaml.cs#permission)]
 [!code-vb[WPFPlatformSecuritySnippets#Permission](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFPlatformSecuritySnippets/VisualBasic/Page1.xaml.vb#permission)]  
  
 The **Assert** essentially prevents the unlimited permissions required by [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] from being restricted by the Internet zone permissions of the [!INCLUDE[TLA2#tla_winfxwebapp](../../../includes/tla2sharptla-winfxwebapp-md.md)].  
  
 From a platform perspective, [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] is responsible for using **Assert** correctly; an incorrect use of **Assert** could enable malicious code to elevate privileges. Consequently, it is important then to only call **Assert** when needed, and to ensure that sandbox restrictions remain intact. For example, sandboxed code is not allowed to open random files, but it is allowed to use fonts. [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] enables sandboxed applications to use font functionality by calling **Assert**, and for [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] to read files known to contain those fonts on behalf of the sandboxed application.  
  
<a name="ClickOnce_Deployment"></a>   
### ClickOnce Deployment  
 [!INCLUDE[TLA#tla_clickonce](../../../includes/tlasharptla-clickonce-md.md)] is a comprehensive deployment technology that is included with [!INCLUDE[TLA2#tla_winfx](../../../includes/tla2sharptla-winfx-md.md)], and integrates with [!INCLUDE[TLA#tla_visualstu](../../../includes/tlasharptla-visualstu-md.md)] (see [ClickOnce Deployment Overview](http://msdn.microsoft.com/library/142dbbz4.aspx) for detailed information). Standalone [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] applications can be deployed using [!INCLUDE[TLA#tla_clickonce](../../../includes/tlasharptla-clickonce-md.md)], while browser-hosted applications must be deployed with [!INCLUDE[TLA2#tla_clickonce](../../../includes/tla2sharptla-clickonce-md.md)].  
  
 Applications deployed using [!INCLUDE[TLA2#tla_clickonce](../../../includes/tla2sharptla-clickonce-md.md)] are given an additional security layer over [!INCLUDE[TLA#tla_cas](../../../includes/tlasharptla-cas-md.md)]; essentially, [!INCLUDE[TLA#tla_clickonce](../../../includes/tlasharptla-clickonce-md.md)] deployed applications request the permissions that they need. They are granted only those permissions if they do not exceed the set of permissions for the zone from which the application is deployed. By reducing the set of permissions to only those that are needed, even if they are less than those provided by the launch zone's permission set, the number of resources that the application has access to is reduce to a bare minimum. Consequently, if the application is hijacked, the potential for damage to the client machine is reduced.  
  
<a name="Security_Critical_Methodology"></a>   
### Security-Critical Methodology  
 The [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] code that uses permissions to enable the Internet zone sandbox for [!INCLUDE[TLA2#tla_winfxwebapp](../../../includes/tla2sharptla-winfxwebapp-md.md)] applications must be held to highest possible degree of security audit and control. To facilitate this requirement, [!INCLUDE[TLA2#tla_winfx](../../../includes/tla2sharptla-winfx-md.md)] provides new support for managing code that elevates privilege. Specifically, the [!INCLUDE[TLA2#tla_clr](../../../includes/tla2sharptla-clr-md.md)] enables you to identify code that elevates privilege and mark it with the <xref:System.Security.SecurityCriticalAttribute>; any code not marked with <xref:System.Security.SecurityCriticalAttribute> becomes *transparent* using this methodology. Conversely, managed code that is not marked with <xref:System.Security.SecurityCriticalAttribute> is prevented from elevating privilege.  
  
 The Security-Critical Methodology allows the organization of [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] code that elevates privilege into *security-critical kernel*, with the remainder being transparent. Isolating the security-critical code enables the [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] engineering team focus an additional security analysis and source control on the security-critical kernel above and beyond standard security practices (see [WPF Security Strategy - Security Engineering](../../../docs/framework/wpf/wpf-security-strategy-security-engineering.md)).  
  
 Note that [!INCLUDE[TLA2#tla_winfx](../../../includes/tla2sharptla-winfx-md.md)] permits trusted code to extend the [!INCLUDE[TLA2#tla_winfxwebapp](../../../includes/tla2sharptla-winfxwebapp-md.md)] Internet zone sandbox by allowing developers to write managed assemblies that are marked with <xref:System.Security.AllowPartiallyTrustedCallersAttribute> (APTCA) and deployed to the user's Global Assembly Cache (GAC). Marking an assembly with APTCA is a highly sensitive security operation as it allows any code to call that assembly, including malicious code from the Internet. Extreme caution and best practices must be used when doing this and users must choose to trust that software in order for it to be installed.  
  
<a name="Microsoft_Internet_Explorer_Security"></a>   
## Microsoft Internet Explorer Security  
 Beyond reducing security issues and simplifying security configuration, [!INCLUDE[TLA#tla_ie6sp2](../../../includes/tlasharptla-ie6sp2-md.md)] contains several features that security improvements that enhance security for users of [!INCLUDE[TLA#tla_winfxwebapp#plural](../../../includes/tlasharptla-winfxwebappsharpplural-md.md)]. The thrust of these features attempts to allow users greater control over their browsing experience.  
  
 Prior to [!INCLUDE[TLA2#tla_ie6sp2](../../../includes/tla2sharptla-ie6sp2-md.md)], users could be subject to any of the following:  
  
-   Random popup windows.  
  
-   Confusing script redirection.  
  
-   Numerous security dialogs on some Web sites.  
  
 In some cases, untrustworthy Web sites would try to trick users by spoofing installation [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)] or repeatedly showing a [!INCLUDE[TLA#tla_actx](../../../includes/tlasharptla-actx-md.md)] installation dialog box, even though the user may have canceled it. Using these techniques, it is possible that a significant number of users have been tricked into making poor decisions that resulted with the installation of spyware applications.  
  
 [!INCLUDE[TLA2#tla_ie6sp2](../../../includes/tla2sharptla-ie6sp2-md.md)] includes several features to mitigate these types of issues, which revolve around the concept of user initiation. [!INCLUDE[TLA2#tla_ie6sp2](../../../includes/tla2sharptla-ie6sp2-md.md)] detects when a user has clicked on a link or page element prior to an action, which is known as *user initiation*, and treats it differently than when a similar action is instead triggered by the script on a page. As an example, [!INCLUDE[TLA2#tla_ie6sp2](../../../includes/tla2sharptla-ie6sp2-md.md)] incorporates a **Pop-Up Blocker** that detects when a user clicks a button prior to the page creating a pop-up. This enables [!INCLUDE[TLA2#tla_ie6sp2](../../../includes/tla2sharptla-ie6sp2-md.md)] to allow most innocuous pop-ups while preventing pop-ups that users neither ask for nor want. Blocked pop-ups are trapped under the new **Information Bar**, which allows the user to manually override the block and view the pop-up.  
  
 The same user-initiation logic is also applied to **Open**/**Save** security prompts. [!INCLUDE[TLA2#tla_actx](../../../includes/tla2sharptla-actx-md.md)] installation dialog boxes are always trapped under the Information Bar unless they represent an upgrade from a previously installed control. These measures combine to give users a safer, more controlled user experience since they are protected against sites which harass them to install either unwanted or malicious software.  
  
 These features also protect customers who use [!INCLUDE[TLA2#tla_ie6sp2](../../../includes/tla2sharptla-ie6sp2-md.md)] to browse to web sites that allow them to download and install [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] applications. In particular, this is because [!INCLUDE[TLA2#tla_ie6sp2](../../../includes/tla2sharptla-ie6sp2-md.md)] offers a better user experience that reduces the chance for users to install malicious or devious applications irrespective of what technology was used to build it, including [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)]. [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] adds to these protections by using [!INCLUDE[TLA#tla_clickonce](../../../includes/tlasharptla-clickonce-md.md)] to facilitate downloading of its applications over the Internet. Since [!INCLUDE[TLA#tla_winfxwebapp#plural](../../../includes/tlasharptla-winfxwebappsharpplural-md.md)] execute within an Internet zone security sandbox, they can be seamlessly launched. On the other hand, standalone [!INCLUDE[TLA2#tla_wpf](../../../includes/tla2sharptla-wpf-md.md)] applications require full trust to execute. For these applications, [!INCLUDE[TLA#tla_clickonce](../../../includes/tlasharptla-clickonce-md.md)] will display a security dialog box during the launch process to notify the use of the application's additional security requirements. However, this must be user-initiated, will also be governed by user initiated logic, and can be canceled.  
  
 [!INCLUDE[TLA2#tla_ie7](../../../includes/tla2sharptla-ie7-md.md)] incorporates and extends the security capabilities of [!INCLUDE[TLA2#tla_ie6sp2](../../../includes/tla2sharptla-ie6sp2-md.md)] as part of an ongoing commitment to security.  
  
## See Also  
 [Understanding Security in Microsoft Internet Explorer 6 in Windows XP SP2](http://www.microsoft.com/downloads/details.aspx?FamilyId=E550F940-37A0-4541-B5E2-704AB386C3ED&displaylang=en)  
 [Understanding and Working in Protected Mode Internet Explorer](http://msdn.microsoft.com/library/bb250462.aspx)  
 [Windows XP Service Pack 3](http://www.microsoft.com/windows/products/windowsxp/sp3/default.mspx)  
 [Windows Vista Security Guide](http://www.microsoft.com/downloads/details.aspx?familyid=a3d1bbed-7f35-4e72-bfb5-b84a526c1565&displaylang=en)  
 [Code Access Security](../../../docs/framework/misc/code-access-security.md)  
 [Security](../../../docs/framework/wpf/security-wpf.md)  
 [WPF Partial Trust Security](../../../docs/framework/wpf/wpf-partial-trust-security.md)  
 [WPF Security Strategy - Security Engineering](../../../docs/framework/wpf/wpf-security-strategy-security-engineering.md)
