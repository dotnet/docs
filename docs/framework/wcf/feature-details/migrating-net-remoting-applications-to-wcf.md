---
title: "Migrating .NET Remoting Applications to WCF"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - ",NET remoting [WCF]"
ms.assetid: 24793465-65ae-4308-8c12-dce4fd12a583
---
# Migrating .NET Remoting Applications to WCF
**This topic is specific to a legacy technology that is retained for backward compatibility with existing applications and is not recommended for new development. Distributed applications should now be developed using WCF.**  
  
 There are two ways to take advantage of WCF with existing .NET Remoting applications: integration and migration. Integration allows you to have .Net Remoting 2.0 and WCF running side by side, letting you expose the same business objects over both technologies simultaneously without having to modify your existing .Net Remoting 2.0 code. Integration requires that you are running on [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] 2.0 or greater. If you want to take advantage of WCF features and do not need wire compatibility with Remoting 2.0 systems, you can migrate your entire service to WCF. Migration from .NET Remoting 2.0 to WCF requires changes to the remote object's interface and its configuration settings. Both of these topics are covered in [From Remoting to the Windows Communication Foundation](https://go.microsoft.com/fwlink/?LinkId=74403).  
  
## See also
- [Conceptual Overview](../../../../docs/framework/wcf/conceptual-overview.md)
