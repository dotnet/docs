---
title: "Architecture of Syndication"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ed4ca86e-e3d8-4acb-87aa-1921fbc353be
caps.latest.revision: 25
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Architecture of Syndication
The Syndication API is designed to provide a format-neutral programming model that allows syndicated content to be written on to the wire in a variety of formats. The abstract data model consists of the following classes:  
  
-   <xref:System.ServiceModel.Syndication.SyndicationCategory>  
  
-   <xref:System.ServiceModel.Syndication.SyndicationFeed>  
  
-   <xref:System.ServiceModel.Syndication.SyndicationItem>  
  
-   <xref:System.ServiceModel.Syndication.SyndicationLink>  
  
-   <xref:System.ServiceModel.Syndication.SyndicationPerson>  
  
 These classes map closely to the constructs defined in the Atom 1.0 specification, although some of the names are different.  
  
 In [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)], syndication feeds are modeled as another type of service operation, one where the return type is one of the derived classes of <xref:System.ServiceModel.Syndication.SyndicationFeedFormatter>. The retrieval of a feed is modeled as a request-response message exchange. A client sends a request to the service and the service responds. The request message is set over an infrastructure protocol (for example, raw HTTP) and the response message contains a payload that consists of a commonly understood syndication format (RSS 2.0 or Atom 1.0). Services that implement these message exchanges are referred to as syndication services.  
  
 The contract for a syndication service consists of a set of operations that returns an instance of the <xref:System.ServiceModel.Syndication.SyndicationFeedFormatter> class. The following example demonstrates an interface declaration for a syndication service.  
  
 [!code-csharp[S_UE_SyndicationBoth#0](../../../../samples/snippets/csharp/VS_Snippets_CFX/s_ue_syndicationboth/cs/service.cs#0)]  
  
 Syndication support is built on top of the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] REST Programming Model that defines the <xref:System.ServiceModel.WebHttpBinding> binding, which is used in conjunction with <xref:System.ServiceModel.Description.WebHttpBehavior> to make feeds available as services. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] REST Programming Model, see [WCF Web HTTP Programming Model Overview](../../../../docs/framework/wcf/feature-details/wcf-web-http-programming-model-overview.md).  
  
> [!NOTE]
>  The Atom 1.0 specification allows for fractional seconds to be specified in any of its date constructs. When serializing and deserializing the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] implementation ignores the fractional seconds.  
  
## Object Model  
 The object model for syndication consists of the groups of classes in the following tables.  
  
 Formatting Classes:  
  
|Class|Description|  
|-----------|-----------------|  
|<xref:System.ServiceModel.Syndication.Atom10FeedFormatter>|A class that serializes a <xref:System.ServiceModel.Syndication.SyndicationFeed> instance to Atom 1.0 format.|  
|<xref:System.ServiceModel.Syndication.Atom10FeedFormatter%601>|A class that serializes <xref:System.ServiceModel.Syndication.SyndicationFeed> derived classes to Atom 1.0 format.|  
|<xref:System.ServiceModel.Syndication.Atom10ItemFormatter>|A class that serializes a <xref:System.ServiceModel.Syndication.SyndicationItem> instance to Atom 1.0 format.|  
|<xref:System.ServiceModel.Syndication.Atom10ItemFormatter%601>|A class that serializes <xref:System.ServiceModel.Syndication.SyndicationItem> derived classes to Atom 1.0 format.|  
|<xref:System.ServiceModel.Syndication.Rss20FeedFormatter>|A class that serializes a <xref:System.ServiceModel.Syndication.SyndicationFeed> instance to RSS 2.0 format.|  
|<xref:System.ServiceModel.Syndication.Rss20FeedFormatter%601>|A class that serializes <xref:System.ServiceModel.Syndication.SyndicationFeed> derived classes to RSS 2.0 format.|  
|<xref:System.ServiceModel.Syndication.Rss20ItemFormatter>|A class that serializes a <xref:System.ServiceModel.Syndication.SyndicationItem> instance to RSS 2.0 format.|  
|<xref:System.ServiceModel.Syndication.Rss20ItemFormatter%601>|A class that serializes <xref:System.ServiceModel.Syndication.SyndicationItem> derived classes to RSS 2.0 format.|  
  
 Object Model Classes:  
  
|Class|Description|  
|-----------|-----------------|  
|<xref:System.ServiceModel.Syndication.SyndicationCategory>|A class that represents the category of a syndication feed.|  
|<xref:System.ServiceModel.Syndication.SyndicationContent>|A base class that represents syndication content.|  
|<xref:System.ServiceModel.Syndication.SyndicationElementExtension>|A class that represents a syndication element extension.|  
|<xref:System.ServiceModel.Syndication.SyndicationElementExtensionCollection>|A collection of <xref:System.ServiceModel.Syndication.SyndicationElementExtension> objects.|  
|<xref:System.ServiceModel.Syndication.SyndicationFeed>|A class that represents a top-level feed object.|  
|<xref:System.ServiceModel.Syndication.SyndicationItem>|A class that represents a feed item.|  
|<xref:System.ServiceModel.Syndication.SyndicationLink>|A class that represents a link within a syndication feed or item.|  
|<xref:System.ServiceModel.Syndication.SyndicationPerson>|A class that represents an Atom Person construct.|  
|<xref:System.ServiceModel.Syndication.SyndicationVersions>|A class that represents the supported syndication protocol versions.|  
|<xref:System.ServiceModel.Syndication.TextSyndicationContent>|A class that represents any <xref:System.ServiceModel.Syndication.SyndicationItem> content to be displayed to an end user.|  
|<xref:System.ServiceModel.Syndication.TextSyndicationContentKind>|An enumeration that represents the different types of text syndication content supported.|  
|<xref:System.ServiceModel.Syndication.UrlSyndicationContent>|A class that represents syndication content that consists of a URL to another resource.|  
|<xref:System.ServiceModel.Syndication.XmlSyndicationContent>|A class that represents syndication content that is not to be displayed in a browser.|  
  
 The core data abstractions in the object model are Feed and Item, which correspond to the <xref:System.ServiceModel.Syndication.SyndicationFeed> and <xref:System.ServiceModel.Syndication.SyndicationItem> classes. A Feed exposes some feed-level metadata (for example, Title, Description, and Author), a location to store unknown extensions, and a set of items that make up the rest of the feed's information content. An Item makes available some item-level metadata (for example, Title, Summary, and PublicationDate), a location to store unknown extensions, and a content element that contains the rest of the item's information content. The core abstractions of Feed and Item are supported by additional classes that represent common data constructs referenced in the Atom 1.0 and RSS specifications.  
  
 The information carried in a Feed instance can be converted to a variety of XML formats. The process of converting to and from XML is managed by the <xref:System.ServiceModel.Syndication.SyndicationFeedFormatter> class. This class is abstract; concrete implementations are provided for Atom 1.0 and RSS 2.0, <xref:System.ServiceModel.Syndication.Atom10FeedFormatter> and <xref:System.ServiceModel.Syndication.Rss20FeedFormatter>. To use derived Feed classes, use either <xref:System.ServiceModel.Syndication.Atom10FeedFormatter%601> or <xref:System.ServiceModel.Syndication.Rss20FeedFormatter%601> as they allow you to specify a derived Feed class. To use derived item classes use either <xref:System.ServiceModel.Syndication.Atom10ItemFormatter%601> or <xref:System.ServiceModel.Syndication.Rss20ItemFormatter%601> as they allow you to specify a derived item class Third parties can derive their own implementation of <xref:System.ServiceModel.Syndication.SyndicationFeedFormatter> to support different syndication formats.  
  
## Extensibility  
  
-   A key feature of syndication protocols is extensibility. Both Atom 1.0 and RSS 2.0 allow you to add attributes and elements to syndication feeds that are not defined in the specifications. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] syndication programming model provides two ways of working with custom attributes and extensions: deriving a new class and loosely-typed access. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Syndication Extensibility](../../../../docs/framework/wcf/feature-details/syndication-extensibility.md).  
  
## See Also  
 [WCF Syndication Overview](../../../../docs/framework/wcf/feature-details/wcf-syndication-overview.md)  
 [How the WCF Syndication Object Model Maps to Atom and RSS](../../../../docs/framework/wcf/feature-details/how-the-wcf-syndication-object-model-maps-to-atom-and-rss.md)  
 [WCF Web HTTP Programming Model](../../../../docs/framework/wcf/feature-details/wcf-web-http-programming-model.md)
