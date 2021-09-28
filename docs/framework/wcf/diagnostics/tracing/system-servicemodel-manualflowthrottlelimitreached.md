---
description: "Learn more about: System.ServiceModel.ManualFlowThrottleLimitReached"
title: "System.ServiceModel.ManualFlowThrottleLimitReached"
ms.date: "03/30/2017"
ms.assetid: 9aba851f-1830-493b-8e3e-60f454eb923e
---
# System.ServiceModel.ManualFlowThrottleLimitReached

System.ServiceModel.ManualFlowThrottleLimitReached  
  
## Description  

 The system reached the limit set for the ManualFlowControlLimit throttle. The throttle value can be changed by modifying the ManualFlowControlLimit property on either the ServiceHost or InstanceContext, as applicable.  
  
 This trace is emitted when the manual flow control limit is initially reduced to 0. Subsequent changes to 0 are not traced. Flow control limit on the instance context is traced once for each context.  
  
## See also

- [Tracing](index.md)
- [Using Tracing to Troubleshoot Your Application](using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../index.md)
