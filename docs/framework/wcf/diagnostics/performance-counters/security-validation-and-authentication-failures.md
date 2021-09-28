---
description: "Learn more about: Security Validation and Authentication Failures"
title: "Security Validation and Authentication Failures"
ms.date: "03/30/2017"
ms.assetid: 0d4e3666-dfc6-421c-baf8-9479c22f7050
---
# Security Validation and Authentication Failures

Counter name: Security Validation and Authentication Failures  
  
## Description  

 This counter is incremented whenever a message is rejected due to a security problem not covered by the "Security Calls Not Authorized" counter. Such problems include:  
  
- Client token cannot be read from the message.  
  
- Client token has failed authentication (for example, bad password).  
  
- Signature verification has failed (for example, the message has been tampered).  
  
- The message is a duplicate from a previous one, which can happen during a replay attack.  
  
- A decryption failure has occurred.  
  
- Some required elements (for example, missing timestamp or encrypted data block) are missing from the message.  
  
- Errors have occurred during TLSNEGO/SPNEGO handshake.
