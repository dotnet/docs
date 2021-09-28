---
description: "Learn more about: Security Validation and Authentication Failures Per Second"
title: "Security Validation and Authentication Failures Per Second"
ms.date: "03/30/2017"
ms.assetid: 266c3bd3-2ffc-4471-94b7-3675443be1ac
---
# Security Validation and Authentication Failures Per Second

Counter name: Security Validation and Authentication Failures Per Second.  
  
## Description  

 This counter is incremented whenever a message is rejected due to a security problem not covered by the "Security Calls Not Authorized" counter. Such problems include:  
  
- Client token cannot be read from the message.  
  
- Client token has failed authentication (for example, bad password).  
  
- Signature verification has failed (for example, the message has been tampered).  
  
- The message is a duplicate from a previous one, which can happen during a replay attack.  
  
- A decryption failure has occurred.  
  
- Some required elements (for example, missing timestamp or encrypted data block) are missing from the message.  
  
- Errors have occurred during TLSNEGO/SPNEGO handshake.  
  
 This counter is of performance counter type [PERF_COUNTER_COUNTER](/previous-versions/windows/it-pro/windows-server-2003/cc740048(v=ws.10)), whose value is calculated using the following formula:  
  
 (N1-N0)/((D1-D0)/F)
