---
description: "Learn more about: Microsoft.Transactions.TransactionBridge.CommitMessageRetry"
title: "Microsoft.Transactions.TransactionBridge.CommitMessageRetry"
ms.date: "03/30/2017"
ms.assetid: 4abe01f0-6398-4fba-b2f3-c054b7f7e971
---
# Microsoft.Transactions.TransactionBridge.CommitMessageRetry

A commit message retry was sent to an unresponsive participant.  
  
## Description  

 Traced if the local Transaction Manager needed to resend a Commit message to a subordinate participant because it did not receive a response in a given amount of time.  
  
## Troubleshooting  

 Investigate potential network or product issues that prevent the response from being delivered on time.  If many of these messages are seen, it can indicate infrastructure problems or abnormally long response times. Both issues will drastically reduce the throughput of transactions within the system.  
  
## See also

- [Tracing](index.md)
- [Using Tracing to Troubleshoot Your Application](using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../index.md)
