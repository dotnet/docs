---
title: "WCF Syndication Overview"
ms.date: "03/30/2017"
ms.assetid: af6d4c39-e5e8-4099-aee6-5261feff9107
---
# WCF Syndication Overview
Windows Communication Foundation (WCF) provides support for exposing syndication feeds from a WCF service. Syndication is a mechanism of application integration in which a server exposes some application data in an interoperable format known as a feed. A feed is a collection of application data that consists of some feed-level metadata (title, author, URL, and other metadata) and a series of feed items. Within the feed, the feed items are usually time-ordered in reverse chronological order. A feed item consists of a standard set of item-level metadata (title, URL, creation date, category, and other item-level metadata) and an arbitrary amount of application specific data. The two most common types of syndication feeds are Really Simple Syndication (RSS) 2.0 and Atom 1.0, both of which are supported by WCF.  
  
## Object Model  
 WCF defines a set of syndication-specific classes that allow you to work with feeds, feed items, and the related metadata in a format-independent way: <xref:System.ServiceModel.Syndication.SyndicationFeed>, <xref:System.ServiceModel.Syndication.SyndicationItem>, <xref:System.ServiceModel.Syndication.SyndicationPerson>, <xref:System.ServiceModel.Syndication.SyndicationLink>, and other syndication-specific classes. WCF also defines infrastructure classes that build on the WCF REST Programming Model to provide syndication support including: <xref:System.ServiceModel.Syndication.Atom10FeedFormatter>, and  <xref:System.ServiceModel.Syndication.Rss20FeedFormatter>. The feed formatter classes support serializing the object model to and from RSS 2.0 and Atom 1.0.  
  
## Scenarios  
 A common use of syndication today is blogging, where the blog author periodically publishes some sort of information. This can be text, images, audio, or other types of information. Many newspapers and magazines also publish news stories or articles using syndication. By subscribing to such a feed, a user can keep up to date with all the new information coming from such sites. Although syndication is most commonly associated with blogs and publishers, it can be used with any application that exposes a collection of information; for example, a bug database you want to expose using a syndication feed. You can create a WCF service that exposes an operation called `CodeDefects`. This operation could take a parameter that specifies the email address of the person whose bugs you want to retrieve. A client can use the following URL to call the operation: `http://someserver/bugDatabase/CodeDefects?user=johndoe`.  
  
## Syndication Formats  
 The WCF syndication platform supports RSS 2.0 and Atom 1.0.  
  
## See also
- [WCF Web HTTP Programming Model](../../../../docs/framework/wcf/feature-details/wcf-web-http-programming-model.md)
