---
description: "Learn more about: Calling Asynchronous Methods Using IAsyncResult"
title: "Calling Asynchronous Methods Using IAsyncResult"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "ending asynchronous operations"
  - "waiting for asynchronous operations"
  - "asynchronous method calling"
  - "calling asynchronous methods"
  - "asynchronous programming, calling asynchronous methods"
  - "IAsyncResult interface, calling asynchronous methods"
  - "stopping asynchronous operations"
ms.assetid: 07fba116-045b-473c-a0b7-acdbeb49861f
ms.topic: concept-article
---
# Calling Asynchronous Methods Using IAsyncResult

Types in the .NET libraries and third-party class libraries can provide methods that allow an application to continue executing while performing asynchronous operations in threads other than the main application thread. The following sections describe and provide code examples that demonstrate the different ways you can call asynchronous methods that use the <xref:System.IAsyncResult> design pattern.  
  
- [Blocking Application Execution by Ending an Async Operation](blocking-application-execution-by-ending-an-async-operation.md).  
  
- [Blocking Application Execution Using an AsyncWaitHandle](blocking-application-execution-using-an-asyncwaithandle.md).  
  
- [Polling for the Status of an Asynchronous Operation](polling-for-the-status-of-an-asynchronous-operation.md).  
  
- [Using an AsyncCallback Delegate to End an Asynchronous Operation](using-an-asynccallback-delegate-to-end-an-asynchronous-operation.md).  
  
## See also

- [Event-based Asynchronous Pattern (EAP)](event-based-asynchronous-pattern-eap.md)
- [Event-based Asynchronous Pattern Overview](event-based-asynchronous-pattern-overview.md)
