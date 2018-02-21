---
title: "LINQ to ADO.NET (Portal Page)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bbbd7c76-2981-4b91-b8d2-437547181f52
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# LINQ to ADO.NET (Portal Page)
[!INCLUDE[linq_adonet](~/includes/linq-adonet-md.md)] enables you to query over any enumerable object in [!INCLUDE[vstecado](~/includes/vstecado-md.md)] by using the [!INCLUDE[vbteclinqext](~/includes/vbteclinqext-md.md)] programming model.  
  
> [!NOTE]
>  The [!INCLUDE[linq_adonet](~/includes/linq-adonet-md.md)] documentation is located in the ADO.NET section of the .NET Framework SDK: [LINQ and ADO.NET](http://msdn.microsoft.com/library/bf0c8f93-3ff7-49f3-8aed-f2b7ac938dec).  
  
 There are three separate ADO.NET [!INCLUDE[vbteclinqext](~/includes/vbteclinqext-md.md)] technologies: [!INCLUDE[linq_dataset](~/includes/linq-dataset-md.md)], [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)], and [!INCLUDE[linq_entities](~/includes/linq-entities-md.md)]. [!INCLUDE[linq_dataset](~/includes/linq-dataset-md.md)] provides richer, optimized querying over the <xref:System.Data.DataSet>, [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)] enables you to directly query [!INCLUDE[ssNoVersion](~/includes/ssnoversion-md.md)] database schemas, and [!INCLUDE[linq_entities](~/includes/linq-entities-md.md)] allows you to query an [!INCLUDE[adonet_edm](~/includes/adonet-edm-md.md)].  
  
## LINQ to DataSet  
 The <xref:System.Data.DataSet> is one of the most widely used components in [!INCLUDE[vstecado](~/includes/vstecado-md.md)], and is a key element of the disconnected programming model that [!INCLUDE[vstecado](~/includes/vstecado-md.md)] is built on. Despite this prominence, however, the <xref:System.Data.DataSet> has limited query capabilities.  
  
 [!INCLUDE[linq_dataset](~/includes/linq-dataset-md.md)] enables you to build richer query capabilities into <xref:System.Data.DataSet> by using the same query functionality that is available for many other data sources.  
  
 For more information, see [LINQ to DataSet](../../../../framework/data/adonet/linq-to-dataset.md).  
  
## LINQ to SQL  
 [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)] provides a run-time infrastructure for managing relational data as objects. In [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)], the data model of a relational database is mapped to an object model expressed in the programming language of the developer. When you execute the application, [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)] translates language-integrated queries in the object model into SQL and sends them to the database for execution. When the database returns the results, [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)] translates them back into objects that you can manipulate.  
  
 [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)] includes support for stored procedures and user-defined functions in the database, and for inheritance in the object model.  
  
 For more information, see [LINQ to SQL](../../../../framework/data/adonet/sql/linq/index.md).  
  
## LINQ to Entities  
 Through the [!INCLUDE[adonet_edm](~/includes/adonet-edm-md.md)], relational data is exposed as objects in the .NET environment. This makes the object layer an ideal target for [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] support, allowing developers to formulate queries against the database from the language used to build the business logic. This capability is known as [!INCLUDE[linq_entities](~/includes/linq-entities-md.md)]. See [LINQ to Entities](../../../../framework/data/adonet/ef/language-reference/linq-to-entities.md) for more information.  
  
## See Also  
 [LINQ and ADO.NET](http://msdn.microsoft.com/library/bf0c8f93-3ff7-49f3-8aed-f2b7ac938dec)  
 [Language-Integrated Query (LINQ) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/index.md)
