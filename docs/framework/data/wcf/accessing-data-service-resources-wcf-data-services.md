---
title: "Accessing Data Service Resources (WCF Data Services)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-oob"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WCF Data Services, querying"
  - "getting started, WCF Data Services"
  - "querying the data service [WCF Data Service]"
  - "WCF Data Services, getting started"
  - "WCF Data Services, accessing data"
ms.assetid: 9665ff5b-3e3a-495d-bf83-d531d5d060ed
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Accessing Data Service Resources (WCF Data Services)
[!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] supports the [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)] to expose your data as a feed with resources that are addressable by URIs. These resources are represented according to the entity-relationship conventions of the [Entity Data Model](../../../../docs/framework/data/adonet/entity-data-model.md). In this model, entities represent operational units of data that are data types in an application domain, such as customers, orders, items, and products. Entity data is accessed and changed by using the semantics of representational state transfer (REST), specifically the standard HTTP verbs of GET, PUT, POST, and DELETE.  
  
## Addressing Resources  
 In [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)], you address any data exposed by the data model by using a URI. For example, the following URI returns a feed that is the Customers entity set, which contains entries for all instances of the Customer entity type:  
  
```  
http://services.odata.org/Northwind/Northwind.svc/Customers  
```  
  
 Entities have special properties called entity keys. An entity key is used to uniquely identify a single entity in an entity set. This enables you to address a specific instance of an entity type in the entity set. For example, the following URI returns an entry for a specific instance of the Customer entity type that has a key value of `ALFKI`:  
  
```  
http://services.odata.org/Northwind/Northwind.svc/Customers('ALFKI')  
```  
  
 Primitive and complex properties of an entity instance can also be individually addressed. For example, the following URI returns an XML element that contains the `ContactName` property value for a specific Customer:  
  
```  
http://services.odata.org/Northwind/Northwind.svc/Customers('ALFKI')/ContactName  
```  
  
 When you include the `$value` endpoint in the previous URI, only the value of the primitive property is returned in the response message. The following example returns only the string "Maria Anders" without the XML element:  
  
```  
http://services.odata.org/Northwind/Northwind.svc/Customers('ALFKI')/ContactName/$value  
```  
  
 Relationships between entities are defined in the data model by associations. These associations enable you to address related entities by using navigation properties of an entity instance. A navigation property can return either a single related entity, in the case of a many-to-one relationship, or a set of related entities, in the case of a one-to-many relationship. For example, the following URI returns a feed that is the set of all the Orders that are related to a specific Customer:  
  
```  
http://services.odata.org/Northwind/Northwind.svc/Customers('ALFKI')/Orders  
```  
  
 Relationships, which are usually bi-directional, are represented by a pair of navigation properties. As the reverse of the relationship shown in the previous example, the following URI returns a reference to the Customer entity to which a specific Order entity belongs:  
  
```  
http://services.odata.org/Northwind/Northwind.svc/Orders(10643)/Customer  
```  
  
 [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] also enables you to address resources based on the results of query expressions. This makes it possible to filter sets of resources based on an evaluated expression. For example, the following URI filters the resources to return only the Orders for the specified Customer that have shipped since September 22, 1997:  
  
```  
http://services.odata.org/Northwind/Northwind.svc/Customers('ALFKI')/Orders?$filter=ShippedDate gt datetime'1997-09-22T00:00:00'  
```  
  
 For more information, see [OData: URI Conventions](http://go.microsoft.com/fwlink/?LinkId=185564).  
  
## System Query Options  
 [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] defines a set of system query options that you can use to perform traditional query operations against resources, such as filtering, sorting, and paging. For example, the following URI returns the set of all the `Order` entities, along with related `Order_Detail` entities, the postal codes of which do not end in `100`:  
  
```  
http://services.odata.org/Northwind/Northwind.svc/Orders?$filter=not endswith(ShipPostalCode,'100')&$expand=Order_Details&$orderby=ShipCity  
```  
  
 The entries in the returned feed are also ordered by the value of the ShipCity property of the orders.  
  
 [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] supports the following [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] system query options:  
  
|Query Option|Description|  
|------------------|-----------------|  
|`$orderby`|Defines a default sort order for entities in the returned feed. The following query orders the returned customers feed by county and city:<br /><br /> `http://services.odata.org/Northwind/Northwind.svc/Customers?$orderby=Country,City`<br /><br /> For more information, see [OData: OrderBy System Query Option ($orderby)](http://go.microsoft.com/fwlink/?LinkId=186968).|  
|`$top`|Specifies the number of entities to include in the returned feed. The following example skips the first 10 customers and then returns the next 10:<br /><br /> `http://services.odata.org/Northwind/Northwind.svc/Customers?$skip=10&$top=10`<br /><br /> For more information, see [OData: Top System Query Option ($top)](http://go.microsoft.com/fwlink/?LinkId=186969).|  
|`$skip`|Specifies the number of entities to skip before starting to return entities in the feed. The following example skips the first 10 customers and then returns the next 10:<br /><br /> `http://services.odata.org/Northwind/Northwind.svc/Customers?$skip=10&$top=10`<br /><br /> For more information, see [OData: Skip System Query Option ($skip)](http://go.microsoft.com/fwlink/?LinkId=186971).|  
|`$filter`|Defines an expression that filters the entities returned in the feed based on specific criteria. This query option supports a set of logical comparison operators, arithmetic operators, and predefined query functions that are used to evaluate the filter expression. The following example returns all orders the postal codes of which do not end in 100:<br /><br /> `http://services.odata.org/Northwind/Northwind.svc/Orders?$filter=not endswith(ShipPostalCode,'100')`<br /><br /> For more information, see [OData: Filter System Query Option ($filter)](http://go.microsoft.com/fwlink/?LinkId=186972).|  
|`$expand`|Specifies which related entities are returned by the query. Related entities are included as either a feed or an entry inline with the entity returned by the query. The following example returns the order for the customer 'ALFKI' along with the item details for each order:<br /><br /> `http://services.odata.org/Northwind/Northwind.svc/Customers('ALFKI')/Orders?$expand=Order_Details`<br /><br /> For more information, see [OData: Expand System Query Option ($expand)](http://go.microsoft.com/fwlink/?LinkId=186973).|  
|`$select`|Specifies a projection that defines the properties of the entity are returned in the projection. By default, all properties of an entity are returned in a feed. The following query returns only three properties of the `Customer` entity:<br /><br /> `http://services.odata.org/Northwind/Northwind.svc/Customers?$select=CustomerID,CompanyName,City`<br /><br /> For more information, see [OData: Select System Query Option ($select)](http://go.microsoft.com/fwlink/?LinkID=186076).|  
|`$inlinecount`|Requests that a count of the number of entities returned in the feed be included with the feed. For more information, see [OData: Inlinecount System Query Option ($inlinecount)](http://go.microsoft.com/fwlink/?LinkId=186975).|  
  
## Addressing Relationships  
 In addition to addressing entity sets and entity instances, [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] also enables you to address the associations that represent relationships between entities. This functionality is required to be able to create or change a relationship between two entity instances, such as the shipper that is related to a given order in the Northwind sample database. [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] supports a `$link` operator to specifically address the associations between entities. For example, the following URI is specified in an HTTP PUT request message to change the shipper for the specified order to a new shipper.  
  
```  
http://services.odata.org/Northwind/Northwind.svc/Orders(10643)/$links/Shipper  
```  
  
 For more information, see [OData: Addressing Links between Entries](http://go.microsoft.com/fwlink/?LinkId=187351).  
  
## Consuming the Returned Feed  
 The URI of an [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] resource enables you to address entity data exposed by the service. When you enter a URI into the address field of a Web browser, a [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feed representation of the requested resource is returned. For more information, see the [WCF Data Services Quickstart](../../../../docs/framework/data/wcf/quickstart-wcf-data-services.md). Although a Web browser may be useful for testing that a data service resource returns the expected data, production data services that can also create, update, and delete data are generally accessed by application code or scripting languages in a Web page. For more information, see [Using a Data Service in a Client Application](../../../../docs/framework/data/wcf/using-a-data-service-in-a-client-application-wcf-data-services.md).  
  
## See Also  
 [Open Data Protocol Web site](http://go.microsoft.com/fwlink/?LinkID=182204)
