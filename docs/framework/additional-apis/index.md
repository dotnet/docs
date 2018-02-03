---
title: "Additional class libraries and APIs"
ms.custom: ""
ms.date: "01/29/2018"
ms.prod: ".net-framework-oob"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Additional class libraries"
  - "Additional managed libraries"
  - ".NET Framework out-of-band releases"
  - "out-of-band releases"
ms.assetid: cf2d9006-b631-4e5d-81cd-20aab78c60f1
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# Additional class libraries and APIs

The .NET Framework is constantly evolving and in order to improve cross-platform development or to introduce new functionality early to our customers, we release new features out of band (OOB). This topic lists the OOB projects that we provide documentation for.  
  
In addition, some libraries target specific platforms or implementations of the .NET Framework. For example, the <xref:System.Text.CodePagesEncodingProvider> class makes code page encodings available to UWP apps developed using the .NET Framework. This topic lists these libraries as well.  
  
## OOB projects
  
| Project | Description |  
| ------- | ----------- |  
| <xref:System.Collections.Immutable> | Provides collections that are thread safe and guaranteed to never change their contents. |
| <xref:System.Net.Http.WinHttpHandler> | Provides a message handler for <xref:System.Net.Http.HttpClient> based on the WinHTTP interface of Windows. |
| [System.Numerics.Vectors](https://msdn.microsoft.com/library/mt452176.aspx) | Provides a library of vector types that can take advantage of SIMD hardware-based acceleration.| 
| <xref:System.Threading.Tasks.Dataflow> | The TPL Dataflow Library provides dataflow components to help increase the robustness of concurrency-enabled applications. |  

## Platform-specific libraries
  
| Project | Description |  
| ------- | ----------- |  
| <xref:System.Text.CodePagesEncodingProvider> | Extends the <xref:System.Text.EncodingProvider> class to make code page encodings available to apps that target the Universal Windows Platform. |  
  
## Private APIs  

These APIs support the product infrastructure and are not intended/supported to be used directly from your code.  
  
| API Name |
| -------- |
| [System.Net.Connection Class](../../../docs/framework/additional-apis/connection.md) |
| [System.Net.Connection.m\_WriteList Field](../../../docs/framework/additional-apis/m_writelist.md) |
| [System.Net.ConnectionGroup Class](../../../docs/framework/additional-apis/connectiongroup.md) |
| [System.Net.ConnectionGroup.m\_ConnectionList Field](../../../docs/framework/additional-apis/m_connectionlist.md) |
| [System.Net.CoreResponseData Class](../../../docs/framework/additional-apis/coreresponsedata.md) |
| [System.Net.CoreResponseData.m\_ResponseHeaders Field](../../../docs/framework/additional-apis/coreresponsedata_m_responseheaders.md) |
| [System.Net.CoreResponseData.m\_StatusCode Field](../../../docs/framework/additional-apis/coreresponsedata_m_statuscode.md) |
| [System.Net.HttpWebRequest.\_AutoRedirects Field](../../../docs/framework/additional-apis/_autoredirects.md) |
| [System.Net.HttpWebRequest.\_CoreResponse Field](../../../docs/framework/additional-apis/httpwebrequest__coreresponse.md) |
| [System.Net.HttpWebRequest.\_HttpResponse Field](../../../docs/framework/additional-apis/_httpresponse.md) |
| [System.Net.ServicePoint.m\_ConnectionGroupList Field](../../../docs/framework/additional-apis/m_connectiongrouplist.md) |
| [System.Net.ServicePointManager.s\_ServicePointTable Field](../../../docs/framework/additional-apis/s_servicepointtable.md) |
| [System.Windows.Diagnostics.VisualDiagnostics.s\_isDebuggerCheckDisabledForTestPurposes Field](../../../docs/framework/additional-apis/s-isdebuggercheckdisabledfortestpurposes-field.md) |
| [System.Windows.Forms.Design.DataMemberFieldEditor Class](../../../docs/framework/additional-apis/datamemberfieldeditor-class.md) |
| [System.Windows.Forms.Design.DataMemberListEditor Class](../../../docs/framework/additional-apis/datamemberlisteditor-class.md) |
  
## See also

[The .NET Framework and Out-of-Band Releases](../../../docs/framework/get-started/the-net-framework-and-out-of-band-releases.md)
