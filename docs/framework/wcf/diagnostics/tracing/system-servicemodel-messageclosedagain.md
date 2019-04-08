---
title: "System.ServiceModel.MessageClosedAgain"
ms.date: "03/30/2017"
ms.assetid: 24c274d4-65cd-4c91-9869-bc6eb34ef979
---
# System.ServiceModel.MessageClosedAgain
System.ServiceModel.MessageClosedAgain  
  
## Description  
 A message was closed again.  
  
 A message should be closed only once. If this trace is being emitted in user extension code, it indicates that the user extension code is closing a message that has already been closed. If this trace is being emitted through product code, it indicates that the user extension code could potentially be closing a message too early.  
  
## See also

- [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)
- [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
