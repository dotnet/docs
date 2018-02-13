---
title: "Downloading the Validating Issuer Name Registry Package"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ff8b0014-c5d4-4614-90f0-13fcc0ba777a
caps.latest.revision: 3
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Downloading the Validating Issuer Name Registry Package
This topic discusses how to download and use the Validating Issuer Name Registry (VINR) in your project.  
  
## Downloading the Validating Issuer Name Registry  
 The VINR is available as a NuGet package, which adds the necessary assemblies and references to your project. If you do not already have NuGet installed, go to [nuget.org](http://nuget.org) to install it. You can see the versioning history for the extension by visiting its page on NuGet: [Microsoft Validating Issuer Name Registry on NuGet](https://nuget.org/packages/System.IdentityModel.Tokens.ValidatingIssuerNameRegistry/)  
  
#### Downloading the Validating Issuer Name Registry by using the Package Manager GUI  
  
1.  In Visual Studio, right-click your project in **Solution Explorer**, and then select **Manage NuGet Packages**.  
  
2.  In the **Manage NuGet Packages** window, click the search box and enter `ValidatingIssuerNameRegistry` and press **Enter**.  
  
3.  From the results pane, click the **Install** button for the first result.  
  
4.  The package will begin downloading. Before it is added to your project, the License Acceptance dialog will appear. If you agree to the license terms, click **I Accept**.  
  
5.  The latest VINR assemblies will be downloaded and added to your project.  
  
#### Downloading the Validating Issuer Name Registry by using the Package Manager Console  
  
1.  In Visual Studio, click **Tools**, **Library Package Manager**, and then **Package Manager Console**.  
  
2.  The **Package Manager Console** appears. Enter the following text and press **Enter**:  
  
    ```powershell  
    Install-Package System.IdentityModel.Tokens.ValidatingIssuerNameRegistry  
    ```  
  
3.  The latest VINR assemblies will be downloaded and added to your project.
