---
title: "System.ServiceModel.TxFailedToNegotiateOleTx"
ms.date: "03/30/2017"
ms.assetid: 3f0f0b4b-a1ad-4704-8329-455daf54892d
---
# System.ServiceModel.TxFailedToNegotiateOleTx
The OleTransactions protocol negotiation failed to complete for the specified coordination context.  
  
## Description  
 Traced when an incoming transaction with OleTx information is unable to use the attached OleTx information, and will fall-back to using WS-AT instead.  
  
## Troubleshooting  
 Indicates a potential problem with MSDTC RPC communication between the machines. If many of these traces appear in the log, a drastic decrease in performance can result.  If OleTx is not desired, set `OleTxUpgradeEnabled` to 0 in the WS-AT registry configuration.  
  
## See also
- [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)
- [Using Tracing to Troubleshoot Your Application](../../../../../docs/framework/wcf/diagnostics/tracing/using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)
