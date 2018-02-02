---
title: "Security (LINQ to DataSet)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6116b2b8-75f4-4d8b-aea6-c13e55cda50b
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Security (LINQ to DataSet)
This topic discusses security issues in [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)].  
  
## Passing a Query to an Untrusted Component  
 A [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query can be formulated in one point of a program and executed in a different one. At the point where the query is formulated, the query can reference any element that is visible at that point, such as private members of the class that the calling method belongs to, or symbols representing local variables/arguments. At execution time, the query will effectively be able to access those members that were referenced by the query at formulation, even if the calling code does not have visibility into them. The code that executes the query does not have arbitrary added visibility, in that it cannot choose what to access. It will be able to access strictly what the query accesses, and only through the query itself.  
  
 This implies that by passing a reference to a query to another piece of code the component receiving the query is being trusted with access to all public and private members that the query refers to. In general, [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] queries should not be passed to untrusted components, unless the query has been carefully constructed so that it does not expose information that should be kept private.  
  
## External Input  
 Applications often take external input (from a user or another external agent) and perform actions based on that input.  In the case of [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)], the application might construct a query in a certain way, based on external input or use external input in the query. [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] queries accept parameters everywhere that literals are accepted. Application developers should use parameterized queries, rather than injecting literals from an external agent directly into the query.  
  
 Any input directly or indirectly derived from the user or an external agent might have content that leverages the syntax of the target language in order to perform unauthorized actions. This is known as a SQL injection attack, named after an attack pattern where the target language is Transact-SQL. User input injected directly into the query is used to drop a database table, cause a denial of service, or otherwise change the nature of the operation being performed. Although query composition is possible in [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)], it is performed through the object model API. [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] queries are not composed by using string manipulation or concatenation, as they are in Transact-SQL, and are not susceptible to SQL injection attacks in the traditional sense.  
  
## See Also  
 [Programming Guide](../../../../docs/framework/data/adonet/programming-guide-linq-to-dataset.md)
