---
title: "LINQ to SQL Sample"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5f39db9e-0e62-42c9-8c98-bb8b54cec98c
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# LINQ to SQL Sample
This sample demonstrates how to create an activity to use LINQ to SQL query entities from tables in SQL Server databases.  
  
> [!IMPORTANT]
>  The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\Samples\WCFWFCardspace`  
>   
>  If this directory does not exist, click the download sample link at the top of this page. Note that this link downloads and installs all of the [!INCLUDE[wf1](../../../../includes/wf1-md.md)], [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], and [!INCLUDE[infocard](../../../../includes/infocard-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\Samples\WCFWFCardSpace\WF\Scenario\ActivityLibrary\Linq\LinqToSql`  
  
## Activity details for FindInSqlTable  
 This activity allows users to query entities from tables in a database using LINQ to SQL. Users of the activity can also provide a LINQ predicate in the form of a lambda expression to filter the results. If no predicate is provided, the entire table is returned. The following table details the property and return values for the activity.  
  
|Property or Return Value|Description|  
|------------------------------|-----------------|  
|`Collection` property|A required property that specifies the source collection.|  
|`Predicate` property|A required property that specifies the filter for the collection in the form of a lambda expression.|  
|Return Value|The filtered collection.|  
  
## Code Sample that uses the Custom Activity  
 The following code example uses the `FindInSqlTable` custom activity to find all rows in a SQL Server table named `Employee` where the `Role` column is equal to `SDE`.  
  
```csharp  
new FindInSqlTable<Employee>   
{  
    ConnectionString = @"Data Source=.\SQLExpress;Initial Catalog=LinqToSqlSample;Integrated Security=True",                          
    Predicate = new LambdaValue<Func<Employee, bool>>(c => new Func<Employee, bool>(emp => emp.Role.Equals("SDE"))),  
    Result = new OutArgument<IList<Employee>>(employees)  
},  
```  
  
#### To use this sample  
  
1.  Open a command prompt.  
  
2.  Navigate to the folder that contains this sample.  
  
3.  Run the Setup.cmd command file.  
  
    > [!NOTE]
    >  The Setup.cmd script attempts to install the sample database in your local machine SQL Server Express. If you want to install it in other SQL server instance, edit Setup.cmd.  
  
     The Setup.cmd script does the following actions.:  
  
    -   Creates a database called LinqToSqlSample.  
  
    -   Creates a Roles table.  
  
    -   Creates an Employees table.  
  
    -   Inserts 3 records into the Roles table.  
  
    -   Inserts 12 records into the Employees table.  
  
4.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the LinqToSQL.sln solution file.  
  
5.  To build the solution, press CTRL+SHIFT+B.  
  
6.  To run the solution, press F5.  
  
#### To uninstall the LinqToSql sample database  
  
1.  Open a command prompt.  
  
2.  Navigate to the folder that contains this sample.  
  
3.  Run the Cleanup.cmd command file.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\ActivityLibrary\Liiinq\LinqToSql`  
  
## See Also  
 [LINQ to SQL](http://go.microsoft.com/fwlink/?LinkId=150376)  
 [Getting Started (LINQ to SQL)](http://go.microsoft.com/fwlink/?LinkId=150377)
