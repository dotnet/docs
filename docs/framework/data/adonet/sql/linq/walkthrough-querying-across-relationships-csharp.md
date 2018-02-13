---
title: "Walkthrough: Querying Across Relationships (C#)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 552abeb1-18f2-4e93-a9c6-ef7b2db30c32
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Walkthrough: Querying Across Relationships (C#)
This walkthrough demonstrates the use of [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] *associations* to represent foreign-key relationships in the database.  
  
 [!INCLUDE[note_settings_general](../../../../../../includes/note-settings-general-md.md)]  
  
 This walkthrough was written by using Visual C# Development Settings.  
  
## Prerequisites  
 You must have completed [Walkthrough: Simple Object Model and Query (C#)](../../../../../../docs/framework/data/adonet/sql/linq/walkthrough-simple-object-model-and-query-csharp.md). This walkthrough builds on that one, including the presence of the northwnd.mdf file in c:\linqtest5.  
  
## Overview  
 This walkthrough consists of three main tasks:  
  
-   Adding an entity class to represent the Orders table in the sample Northwind database.  
  
-   Supplementing annotations to the `Customer` class to enhance the relationship between the `Customer` and `Order` classes.  
  
-   Creating and running a query to test obtaining `Order` information by using the `Customer` class.  
  
## Mapping Relationships Across Tables  
 After the `Customer` class definition, create the `Order` entity class definition that includes the following code, which indicates that `Order.Customer` relates as a foreign key to `Customer.CustomerID`.  
  
#### To add the Order entity class  
  
-   Type or paste the following code after the `Customer` class:  
  
     [!code-csharp[DLinqWalk2CS#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqWalk2CS/cs/Program.cs#1)]  
  
## Annotating the Customer Class  
 In this step, you annotate the `Customer` class to indicate its relationship to the `Order` class. (This addition is not strictly necessary, because defining the relationship in either direction is sufficient to create the link. But adding this annotation does enable you to easily navigate objects in either direction.)  
  
#### To annotate the Customer class  
  
-   Type or paste the following code into the `Customer` class:  
  
     [!code-csharp[DLinqWalk2CS#2](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqWalk2CS/cs/Program.cs#2)]  
  
## Creating and Running a Query Across the Customer-Order Relationship  
 You can now access `Order` objects directly from the `Customer` objects, or in the opposite order. You do not need an explicit *join* between customers and orders.  
  
#### To access Order objects by using Customer objects  
  
1.  Modify the `Main` method by typing or pasting the following code into the method:  
  
     [!code-csharp[DLinqWalk2CS#3](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqWalk2CS/cs/Program.cs#3)]  
  
2.  Press F5 to debug your application.  
  
    > [!NOTE]
    >  You can eliminate the SQL code in the Console window by commenting out `db.Log = Console.Out;`.  
  
3.  Press Enter in the Console window to stop debugging.  
  
## Creating a Strongly Typed View of Your Database  
 It is much easier to start with a strongly typed view of your database. By strongly typing the <xref:System.Data.Linq.DataContext> object, you do not need calls to <xref:System.Data.Linq.DataContext.GetTable%2A>. You can use strongly typed tables in all your queries when you use the strongly typed <xref:System.Data.Linq.DataContext> object.  
  
 In the following steps, you will create `Customers` as a strongly typed table that maps to the Customers table in the database.  
  
#### To strongly type the DataContext object  
  
1.  Add the following code above the `Customer` class declaration.  
  
     [!code-csharp[DLinqWalk2CS#4](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqWalk2CS/cs/Program.cs#4)]  
  
2.  Modify the `Main` method to use the strongly typed <xref:System.Data.Linq.DataContext> as follows:  
  
     [!code-csharp[DLinqWalk2CS#5](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqWalk2CS/cs/Program.cs#5)]  
  
3.  Press F5 to debug your application.  
  
     The Console window output is:  
  
     `ID=WHITC`  
  
4.  Press Enter in the console window to stop debugging.  
  
## Next Steps  
 The next walkthrough ([Walkthrough: Manipulating Data (C#)](../../../../../../docs/framework/data/adonet/sql/linq/walkthrough-manipulating-data-csharp.md)) demonstrates how to manipulate data. That walkthrough does not require that you save the two walkthroughs in this series that you have already completed.  
  
## See Also  
 [Learning by Walkthroughs](../../../../../../docs/framework/data/adonet/sql/linq/learning-by-walkthroughs.md)
