---
description: "Learn more about: System.ServiceModel.Channels.HttpChannelMessageReceiveFailed"
title: "System.ServiceModel.Channels.HttpChannelMessageReceiveFailed"
ms.date: "03/30/2017"
ms.assetid: 9eb311da-fdcc-4dd3-9d85-05b3280dfdda
---
# System.ServiceModel.Channels.HttpChannelMessageReceiveFailed

Failed to receive a message over an HTTP channel.  
  
## Description  

 This trace can be emitted as a warning or an error. In both cases, the trace is emitted when a compatible listener is not found for an incoming HTTP request and the HTTP request is discarded. This could happen because the request’s HTTP verb was not recognized by any HTTP listener, or because no listener was listening on the address the request was targeted for. The trace is emitted as a warning in the self-hosted case, and as an error when the service is hosted in IIS.  
  
## See also

- [Tracing](index.md)
- [Using Tracing to Troubleshoot Your Application](using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../index.md)
