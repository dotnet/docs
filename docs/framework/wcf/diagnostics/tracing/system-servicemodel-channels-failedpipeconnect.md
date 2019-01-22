---
title: "System.ServiceModel.Channels.FailedPipeConnect"
ms.date: "03/30/2017"
ms.assetid: 9a827e0f-fb91-46bb-bd54-926d4b74d8a6
---
# System.ServiceModel.Channels.FailedPipeConnect
An attempt to connect to the named pipe endpoint failed. Another attempt is made within the specified timeout period.  
  
## Description  
 This informational trace indicates a failure to connect to a named pipe endpoint. This could happen if the named pipe endpoint is not found or is busy. Additional attempts are made, each separated by a short amount of time, until one succeeds or the OpenTimeout expires.  
  
## See also
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
