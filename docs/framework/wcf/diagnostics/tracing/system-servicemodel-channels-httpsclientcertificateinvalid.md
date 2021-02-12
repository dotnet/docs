---
description: "Learn more about: System.ServiceModel.Channels.HttpsClientCertificateInvalid"
title: "System.ServiceModel.Channels.HttpsClientCertificateInvalid"
ms.date: "03/30/2017"
ms.assetid: 8884dda1-fa0e-4d2a-8079-7042c51b64ef
---
# System.ServiceModel.Channels.HttpsClientCertificateInvalid

Client certificate is invalid.  
  
## Description  

 This trace indicates that the certificate provided by the client was found to be invalid by the HTTPS listener. The HTTPS listener was attempting to validate the authenticity of the client using this certificate. A certificate could be invalid if its Certificate Authority is not recognized by the server hosting the service.  
  
## See also

- [Tracing](index.md)
- [Using Tracing to Troubleshoot Your Application](using-tracing-to-troubleshoot-your-application.md)
- [Administration and Diagnostics](../index.md)
