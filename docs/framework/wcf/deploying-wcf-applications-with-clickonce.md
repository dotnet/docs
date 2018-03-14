---
title: "Deploying WCF Applications with ClickOnce"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1a11feee-2a47-4d3e-a28a-ad69d5ff93e0
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Deploying WCF Applications with ClickOnce
Client applications using [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] may be deployed using ClickOnce technology. This technology allows them to take advantage of the runtime security protections provided by Code Access Security, provided that they are digitally signed with a trusted certificate. The certificate used to sign the ClickOnce application must reside in the Trusted Publisher store, and the local security policy on the client machine must be configured to grant Full Trust permissions to applications signed with the publisher's certificate.  
  
 For information on configuring ClickOnce applications and trusted publishers, see [Configuring ClickOnce Trusted Publishers](http://go.microsoft.com/fwlink/?LinkId=94774).  
  
## See Also  
 [Trusted Application Deployment Overview](http://go.microsoft.com/fwlink/?LinkId=94775)  
 [ClickOnce Deployment for Windows Forms Applications](http://go.microsoft.com/fwlink/?LinkId=94776)
