---
title: "Deploying WCF Applications with ClickOnce"
ms.date: "03/30/2017"
ms.assetid: 1a11feee-2a47-4d3e-a28a-ad69d5ff93e0
---
# Deploying WCF Applications with ClickOnce
Client applications using Windows Communication Foundation (WCF) may be deployed using ClickOnce technology. This technology allows them to take advantage of the runtime security protections provided by Code Access Security, provided that they are digitally signed with a trusted certificate. The certificate used to sign the ClickOnce application must reside in the Trusted Publisher store, and the local security policy on the client machine must be configured to grant Full Trust permissions to applications signed with the publisher's certificate.  
  
 For information on configuring ClickOnce applications and trusted publishers, see [Configuring ClickOnce Trusted Publishers](https://go.microsoft.com/fwlink/?LinkId=94774).  
  
## See also
- [Trusted Application Deployment Overview](https://go.microsoft.com/fwlink/?LinkId=94775)
- [ClickOnce Deployment for Windows Forms Applications](https://go.microsoft.com/fwlink/?LinkId=94776)
