---
title: "System.ServiceModel.Activation.WebHostServiceCloseFailed"
ms.date: "03/30/2017"
ms.assetid: 3cab9856-a5cf-4f0e-a0cb-89425e368f8e
---
# System.ServiceModel.Activation.WebHostServiceCloseFailed
Occurs when a service cannot be closed gracefully and is aborted.  
  
## Description  
 This error code only appears in the log file. It usually indicates a programming error, for example, when you try to close a service after Abort has already been called.  
  
## Troubleshooting  
 Check the application source code.  
  
## See also
- [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)
- [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
