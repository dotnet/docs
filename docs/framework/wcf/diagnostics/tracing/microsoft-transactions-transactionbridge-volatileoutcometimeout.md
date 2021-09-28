---
description: "Learn more about: Microsoft.Transactions.TransactionBridge.VolatileOutcomeTimeout"
title: "Microsoft.Transactions.TransactionBridge.VolatileOutcomeTimeout"
ms.date: "03/30/2017"
ms.assetid: 2dbe34c5-57c7-4b64-9257-63021911d03c
---
# Microsoft.Transactions.TransactionBridge.VolatileOutcomeTimeout

The WS-AT protocol service timed out waiting for a response to an outcome message from a volatile participant. The transaction outcome may be in doubt if the participant returns.  
  
## Description  

 Traced when a Volatile participant has decided to Commit or Abort but has not responded to a Commit or Rollback request within a given amount of time.  
  
## Troubleshooting  

 Ensure that all Volatile participants are able to respond within the given amount of time. The default time period is 180 seconds.  If this is insufficient, increase the `VolatileOutcomeDelay` timer policy for WS-AT.  
  
## See also

- [Tracing](index.md)
- [Using Tracing to Troubleshoot Your Application](using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../index.md)
