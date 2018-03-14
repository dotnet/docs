---
title: "Service: Security Validation and Authentication Failures Per Second"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4af18009-e778-490b-9ba6-e76485285830
caps.latest.revision: 9
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Service: Security Validation and Authentication Failures Per Second
Counter name: Security Validation and Authentication Failures Per Second.  
  
## Description  
 This counter is incremented whenever a message is rejected due to a security problem not covered by the "Security Calls Not Authorized" counter. Such problems include:  
  
-   Client token cannot be read from the message.  
  
-   Client token has failed authentication (for example, bad password).  
  
-   Signature verification has failed (for example, the message has been tampered).  
  
-   The message is a duplicate from a previous one, which can happen during a replay attack.  
  
-   A decryption failure has occurred.  
  
-   Some required elements (for example, missing timestamp or encrypted data block) are missing from the message.  
  
-   Errors have occurred during TLSNEGO/SPNEGO handshake.  
  
 This counter is of performance counter type [PERF_COUNTER_COUNTER](http://go.microsoft.com/fwlink/?LinkID=94649), whose value is calculated using the following formula,  
  
 (N 1 - N 0 ) / ( (D 1 -D 0 ) / F)
