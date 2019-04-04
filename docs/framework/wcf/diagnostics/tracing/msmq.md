---
title: "MSMQ"
ms.date: "03/30/2017"
ms.assetid: d9fca29f-fa44-4ec4-bb48-b10800694500
---
# MSMQ
In an MSMQ application, no additional activity is transferred from the queued channel to MSMQ and from MSMQ to the queued channel.  
  
 In addition, MSMQ Message ID and SOAP message ID (along with Activity ID, if one exists) are traced as part of queued channel traces on a Send operation.  
  
 MSMQ Message ID and SOAP message ID (along with activity ID, if one exists) are traced as part of queued channel traces on a Receive operation.  
  
 The required transfers on the Receive operation are executed similarly to any other transport (receive bytes->Process message-> operation).
