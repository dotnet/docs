---
title: "WPF Security Strategy - Security Engineering"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "security [WPF], testing techniques"
  - "Security Development Lifecycle (SDL), security analysis [WPF]"
  - "Security Development Lifecycle (SDL), threat modeling"
  - "Security Development Lifecycle (SDL), testing techniques"
  - "Security Development Lifecycle (SDL), source analysis tools"
  - "Security Development Lifecycle (SDL), critical code management"
  - "threat modeling [WPF]"
ms.assetid: 0fc04394-4e47-49ca-b0cf-8cd1161d95b9
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# WPF Security Strategy - Security Engineering
Trustworthy Computing is a Microsoft initiative for ensuring the production of secure code. A key element of the Trustworthy Computing initiative is the [!INCLUDE[TLA#tla_sdl](../../../includes/tlasharptla-sdl-md.md)]. The [!INCLUDE[TLA2#tla_sdl](../../../includes/tla2sharptla-sdl-md.md)] is an engineering practice that is used in conjunction with standard engineering processes to facilitate the delivery of secure code. The [!INCLUDE[TLA2#tla_sdl](../../../includes/tla2sharptla-sdl-md.md)] consists of ten phases that combine best practices with formalization, measurability, and additional structure, including:  
  
-   Security design analysis  
  
-   Tool-based quality checks  
  
-   Penetration testing  
  
-   Final security review  
  
-   Post release product security management  
  
## WPF Specifics  
 The [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] engineering team both applies and extends the [!INCLUDE[TLA2#tla_sdl](../../../includes/tla2sharptla-sdl-md.md)], the combination of which includes the following key aspects:  
  
 [Threat Modeling](#threat_modeling)  
  
 [Security Analysis and Editing Tools](#tools)  
  
 [Testing Techniques](#techniques)  
  
 [Critical Code Management](#critical_code)  
  
<a name="threat_modeling"></a>   
### Threat Modeling  
 Threat modeling is a core component of the [!INCLUDE[TLA2#tla_sdl](../../../includes/tla2sharptla-sdl-md.md)], and is used to profile a system to determine potential security vulnerabilities. Once the vulnerabilities are identified, threat modeling also ensures that appropriate mitigations are in place.  
  
 At a high level, threat modeling involves the following key steps by using a grocery store as an example:  
  
1.  **Identifying Assets**. A grocery store's assets might include employees, a safe, cash registers, and inventory.  
  
2.  **Enumerating Entry Points**. A grocery store's entry points might include the front and back doors, windows, the loading dock, and air conditioning units.  
  
3.  **Investigating Attacks against Assets using Entry Points**. One possible attack could target a grocery store's *safe* asset through the *air conditioning* entry point; the air conditioning unit could be unscrewed to allow the safe to be pulled up through it and out of the store.  
  
 Threat modeling is applied throughout [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] and includes the following:  
  
-   How the [!INCLUDE[TLA2#tla_xaml](../../../includes/tla2sharptla-xaml-md.md)] parser reads files, maps text to corresponding object model classes, and creates the actual code.  
  
-   How a window handle (hWnd) is created, sends messages, and is used for rendering the contents of a window.  
  
-   How data binding obtains resources and interacts with the system.  
  
 These threat models are important for identifying security design requirements and threat mitigations during the development process.  
  
<a name="tools"></a>   
### Source Analysis and Editing Tools  
 In addition to the manual security code review elements of the [!INCLUDE[TLA2#tla_sdl](../../../includes/tla2sharptla-sdl-md.md)], the [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] team uses several tools for source analysis and associated edits to decrease security vulnerabilities. A wide range of source tools are used, and include the following:  
  
-   **FXCop**: Finds common security issues in managed code ranging from inheritance rules to code access security usage to how to safely interoperate with unmanaged code. See [FXCop](http://www.gotdotnet.com/team/fxcop/).  
  
-   **Prefix/Prefast**: Finds security vulnerabilities and common security issues in unmanaged code such as buffer overruns, format string issues, and error checking.  
  
-   **Banned APIs**: Searches source code to identify accidental usage of functions that are well-known for causing security issues, such as `strcpy`. Once identified, these functions are replaced with alternatives that are more security.  
  
<a name="techniques"></a>   
### Testing Techniques  
 [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] uses a variety of security testing techniques that include:  
  
-   **Whitebox Testing**: Testers view source code, and then build exploit tests  
  
-   **Blackbox Testing**: Testers try to find security exploits by examining the API and features, and then try to attack the product.  
  
-   **Regressing Security Issues from other Products**: Where relevant, security issues from related products are tested. For example, appropriate variants of approximately sixty security issues for [!INCLUDE[TLA2#tla_ie](../../../includes/tla2sharptla-ie-md.md)] have been identified and tried for their applicability to [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)].  
  
-   **Tools-Based Penetration Testing through File Fuzzing**: File fuzzing is the exploitation of a file reader's input range through a variety of inputs. One example in [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] where this technique is used is to check for failure in image decoding code.  
  
<a name="critical_code"></a>   
### Critical Code Management  
 For [!INCLUDE[TLA#tla_xbap#plural](../../../includes/tlasharptla-xbapsharpplural-md.md)], [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] builds a security sandbox by using [!INCLUDE[TLA2#tla_winfx](../../../includes/tla2sharptla-winfx-md.md)] support for marking and tracking security-critical code that elevates privileges (see **Security-Critical Methodology** in [WPF Security Strategy - Platform Security](../../../docs/framework/wpf/wpf-security-strategy-platform-security.md)). Given the high security quality requirements on security critical code, such code receives an additional level of source management control and security audit. Approximately 5% to 10% of [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] consists of security-critical code, which is reviewed by a dedicated reviewing team. The source code and check-in process is managed by tracking security critical code and mapping each critical entity (i.e. a method that contains critical code) to its sign off state. The sign off state includes the names of one or more reviewers. Each daily build of [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] compares the critical code to that in previous builds to check for unapproved changes. If an engineer modifies critical code without approval from the reviewing team, it is identified and fixed immediately. This process enables the application and maintenance of an especially high level of scrutiny over [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] sandbox code.  
  
## See Also  
 [Security](../../../docs/framework/wpf/security-wpf.md)  
 [WPF Partial Trust Security](../../../docs/framework/wpf/wpf-partial-trust-security.md)  
 [WPF Security Strategy - Platform Security](../../../docs/framework/wpf/wpf-security-strategy-platform-security.md)  
 [Trustworthy Computing](http://www.microsoft.com/mscorp/twc/default.mspx)  
 [Application Threat Modeling](http://msdn.microsoft.com/security/securecode/threatmodeling/acetm/)  
 [Security Guidelines: .NET Framework 2.0](http://msdn.microsoft.com/library/default.asp?url=/library/dnpag2/html/PAGGuidelines0003.asp)
