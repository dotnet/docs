---
title: "Syndication Extensibility"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4d941175-74a2-4b15-81b3-086e8a95d25f
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Syndication Extensibility
The Syndication API is designed to provide a format-neutral programming model that allows syndicated content to be written to the wire in a variety of formats. The abstract data model consists of the following classes:  
  
-   <xref:System.ServiceModel.Syndication.SyndicationCategory>  
  
-   <xref:System.ServiceModel.Syndication.SyndicationFeed>  
  
-   <xref:System.ServiceModel.Syndication.SyndicationItem>  
  
-   <xref:System.ServiceModel.Syndication.SyndicationLink>  
  
-   <xref:System.ServiceModel.Syndication.SyndicationPerson>  
  
 These classes map closely to the constructs defined in the Atom 1.0 specification, although some of the names are different.  
  
 A key feature of syndication protocols is extensibility. Both Atom 1.0 and RSS 2.0, add attributes and elements to syndication feeds that are not defined in the specifications. The [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] syndication programming model provides the following ways of working with custom attributes and extensions, loosely-typed access and deriving a new class.  
  
## Loosely Typed Access  
 Adding extensions by deriving a new class requires writing additional code. Another option is accessing extensions in a loosely-typed way. All of the types defined in the syndication abstract data model contain properties named `AttributeExtensions` and `ElementExtensions` (with one exception, <xref:System.ServiceModel.Syndication.SyndicationContent> has an `AttributeExtensions` property but no `ElementExtensions` property). These properties are collections of extensions not processed by the `TryParseAttribute` and `TryParseElement` methods respectively. You can access these unprocessed extensions by calling <xref:System.ServiceModel.Syndication.SyndicationElementExtensionCollection.ReadElementExtensions%2A?displayProperty=nameWithType> on the `ElementExtensions` property of <xref:System.ServiceModel.Syndication.SyndicationFeed>, <xref:System.ServiceModel.Syndication.SyndicationItem>, <xref:System.ServiceModel.Syndication.SyndicationLink>, <xref:System.ServiceModel.Syndication.SyndicationPerson>, and <xref:System.ServiceModel.Syndication.SyndicationCategory>. This set of methods finds all extensions with the specified name and namespace, deserializes them individually into instances of `TExtension` and returns them as a collection of `TExtension` objects.  
  
## Deriving a New Class  
 You can derive a new class from any of the existing abstract data model classes. Do this when implementing an application in which most of the feeds you are working with have a particular extension. In this topic, most of the feeds that the program works with contain a `MyExtension` extension. To provide an improved programming experience, do the following steps:  
  
-   Create a class to hold the extension data. In this case, create a class called MyExtension.  
  
-   Derive a class called MyExtensionItem from <xref:System.ServiceModel.Syndication.SyndicationItem> to expose a property of type MyExtension for programmability purposes.  
  
-   Override <xref:System.ServiceModel.Syndication.SyndicationItem.TryParseElement%28System.Xml.XmlReader%2CSystem.String%29> in the MyExtensionItem class to instantiate a new MyExtension instance when a MyExtension is read in.  
  
-   Override <xref:System.ServiceModel.Syndication.SyndicationItem.WriteElementExtensions%28System.Xml.XmlWriter%2CSystem.String%29> in the MyExtensionItem class to write the contents of the MyExtension property to an XML writer.  
  
-   Derive a class called MyExtensionFeed from <xref:System.ServiceModel.Syndication.SyndicationFeed>.  
  
-   Override <xref:System.ServiceModel.Syndication.SyndicationFeed.CreateItem> in the MyExtensionFeed class to instantiate a MyExtensionItem instead of the default <xref:System.ServiceModel.Syndication.SyndicationItem>. A series of methods are defined in <xref:System.ServiceModel.Syndication.SyndicationFeed> and <xref:System.ServiceModel.Syndication.SyndicationItem> that can create <xref:System.ServiceModel.Syndication.SyndicationLink>, <xref:System.ServiceModel.Syndication.SyndicationCategory>, and <xref:System.ServiceModel.Syndication.SyndicationPerson> objects (for example, <xref:System.ServiceModel.Syndication.SyndicationFeed.CreateLink>, <xref:System.ServiceModel.Syndication.SyndicationFeed.CreateCategory>, and <xref:System.ServiceModel.Syndication.SyndicationFeed.CreatePerson>). All of which can be overridden to create a custom derived class.  
  
## See Also  
 [WCF Syndication Overview](../../../../docs/framework/wcf/feature-details/wcf-syndication-overview.md)  
 [Architecture of Syndication](../../../../docs/framework/wcf/feature-details/architecture-of-syndication.md)
