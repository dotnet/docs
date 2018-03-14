---
title: "Interpreting Network Tracing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "TraceMode attribute"
  - "hexidecimal data, network tracing output"
  - "network tracing, analyzing"
  - "protocolonly"
  - "text, network tracing output"
  - "includehex"
ms.assetid: ad22b4b8-00af-4778-9cca-cb609ce1f8ff
caps.latest.revision: 9
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Interpreting Network Tracing
When network tracing is enabled, you can use tracing to capture calls your application makes to various <xref:System.Net> class members. The output from these calls may be similar to the following examples.  
  
```  
[588]   (4357)   Entering Socket#33574638::Send()  
[588]   (4387)   Exiting Socket#33574638::Send()-> 61#61  
```  
  
 In the preceding example, [588] is the current thread's unique identifier. (4357) and (4387) are timestamps denoting the number of milliseconds that have elapsed since the application started. The data following the timestamp shows the application entering and exiting the method **Socket.Send**. The object executing the **Send** method has 33574638 as its unique identifier. The method exit trace includes the return value (61 in the preceding example).  
  
 Network traces can capture network traffic that is sent from or received by your application using application-level protocols such as Hypertext Transfer Protocol (HTTP). This data can be captured as text and, optionally, hexadecimal data. Hexadecimal data is available when you specify **includehex** as the value of the **tracemode** attribute. (For detailed information about this attribute, see [How to: Configure Network Tracing](../../../docs/framework/network-programming/how-to-configure-network-tracing.md).) The following example trace was generated using **includehex**.  
  
 `[1692]   (1142)   00000000 : 47 45 54 20 2F 77 70 61-64 2E 64 61 74 20 48 54 : GET /wpad.dat HT`  
  
 `[1692]   (1142)   00000010 : 54 50 2F 31 2E 31 0D 0A-48 6F 73 74 3A 20 69 74 : TP/1.1..Host: it`  
  
 `[1692]   (1142)   00000020 : 67 70 72 6F 78 79 0D 0A-43 6F 6E 6E 65 63 74 69 : gproxy..Connecti`  
  
 `[1692]   (1142)   00000030 : 6F 6E 3A 20 43 6C 6F 73-65 0D 0A 0D 0A     : on: Close....`  
  
 To omit hexadecimal data, specify **protocolonly** as the value for the **tracemode** attribute. The following example shows the trace when **protocolonly** is specified.  
  
 `[2444]   (594)   Data from ConnectStream#33574638::WriteHeaders<<GET /wpad.dat HTTP/1.1`  
  
 `Host: itgproxy`  
  
 `Connection: Close`  
  
## See Also  
 [Enabling Network Tracing](../../../docs/framework/network-programming/enabling-network-tracing.md)  
 [How to: Configure Network Tracing](../../../docs/framework/network-programming/how-to-configure-network-tracing.md)  
 [Network Tracing in the .NET Framework](../../../docs/framework/network-programming/network-tracing.md)
