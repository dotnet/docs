---
title: "Walkthrough: Using BatchBlock and BatchedJoinBlock to Improve Efficiency"
ms.date: "03/30/2017"
ms.prod: ".net"
ms.technology: dotnet-standard
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Task Parallel Library, dataflows"
  - "TPL dataflow library, improving efficiency"
ms.assetid: 5beb4983-80c2-4f60-8c51-a07f9fd94cb3
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Walkthrough: Using BatchBlock and BatchedJoinBlock to Improve Efficiency
The TPL Dataflow Library provides the <xref:System.Threading.Tasks.Dataflow.BatchBlock%601?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602?displayProperty=nameWithType> classes so that you can receive and buffer data from one or more sources and then propagate out that buffered data as one collection. This batching mechanism is useful when you collect data from one or more sources and then process multiple data elements as a batch. For example, consider an application that uses dataflow to insert records into a database. This operation can be more efficient if multiple items are inserted at the same time instead of one at a time sequentially. This document describes how to use the <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> class to improve the efficiency of such database insert operations. It also describes how to use the <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602> class to capture both the results and any exceptions that occur when the program reads from a database.

[!INCLUDE [tpl-install-instructions](../../../includes/tpl-install-instructions.md)]

## Prerequisites  
  
1.  Read the Join Blocks section in the [Dataflow](../../../docs/standard/parallel-programming/dataflow-task-parallel-library.md) document before you start this walkthrough.  
  
2.  Ensure that you have a copy of the Northwind database, Northwind.sdf, available on your computer. This file is typically located in the folder %Program Files%\Microsoft SQL Server Compact Edition\v3.5\Samples\\.  
  
    > [!IMPORTANT]
    >  In some versions of Windows, you cannot connect to Northwind.sdf if [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] is running in a non-administrator mode. To connect to Northwind.sdf, start [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] or a [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] command prompt in the **Run as administrator** mode.  
  
 This walkthrough contains the following sections:  
  
-   [Creating the Console Application](#creating)  
  
-   [Defining the Employee Class](#employeeClass)  
  
-   [Defining Employee Database Operations](#operations)  
  
-   [Adding Employee Data to the Database without Using Buffering](#nonBuffering)  
  
-   [Using Buffering to Add Employee Data to the Database](#buffering)  
  
-   [Using Buffered Join to Read Employee Data from the Database](#bufferedJoin)  
  
-   [The Complete Example](#complete)  
  
<a name="creating"></a>   
## Creating the Console Application  
  
<a name="consoleApp"></a>   
1.  In [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], create a Visual C# or Visual Basic **Console Application** project. In this document, the project is named `DataflowBatchDatabase`.  
  
2.  In your project, add a reference to System.Data.SqlServerCe.dll and a reference to System.Threading.Tasks.Dataflow.dll.  
  
3.  Ensure that Form1.cs (Form1.vb for [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)]) contains the following `using` (`Imports` in [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)]) statements.  
  
     [!code-csharp[TPLDataflow_BatchDatabase#1](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_batchdatabase/cs/dataflowbatchdatabase.cs#1)]
     [!code-vb[TPLDataflow_BatchDatabase#1](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_batchdatabase/vb/dataflowbatchdatabase.vb#1)]  
  
4.  Add the following data members to the `Program` class.  
  
     [!code-csharp[TPLDataflow_BatchDatabase#2](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_batchdatabase/cs/dataflowbatchdatabase.cs#2)]
     [!code-vb[TPLDataflow_BatchDatabase#2](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_batchdatabase/vb/dataflowbatchdatabase.vb#2)]  
  
<a name="employeeClass"></a>   
## Defining the Employee Class  
 Add to the `Program` class the `Employee` class.  
  
 [!code-csharp[TPLDataflow_BatchDatabase#3](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_batchdatabase/cs/dataflowbatchdatabase.cs#3)]
 [!code-vb[TPLDataflow_BatchDatabase#3](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_batchdatabase/vb/dataflowbatchdatabase.vb#3)]  
  
 The `Employee` class contains three properties, `EmployeeID`, `LastName`, and `FirstName`. These properties correspond to the `Employee ID`, `Last Name`, and `First Name` columns in the `Employees` table in the Northwind database. For this demonstration, the `Employee` class also defines the `Random` method, which creates an `Employee` object that has random values for its properties.  
  
<a name="operations"></a>   
## Defining Employee Database Operations  
 Add to the `Program` class the `InsertEmployees`, `GetEmployeeCount`, and `GetEmployeeID` methods.  
  
 [!code-csharp[TPLDataflow_BatchDatabase#4](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_batchdatabase/cs/dataflowbatchdatabase.cs#4)]
 [!code-vb[TPLDataflow_BatchDatabase#4](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_batchdatabase/vb/dataflowbatchdatabase.vb#4)]  
  
 The `InsertEmployees` method adds new employee records to the database. The `GetEmployeeCount` method retrieves the number of entries in the `Employees` table. The `GetEmployeeID` method retrieves the identifier of the first employee that has the provided name. Each of these methods takes a connection string to the Northwind database and uses functionality in the `System.Data.SqlServerCe` namespace to communicate with the database.  
  
<a name="nonBuffering"></a>   
## Adding Employee Data to the Database Without Using Buffering  
 Add to the `Program` class the `AddEmployees` and `PostRandomEmployees` methods.  
  
 [!code-csharp[TPLDataflow_BatchDatabase#5](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_batchdatabase/cs/dataflowbatchdatabase.cs#5)]
 [!code-vb[TPLDataflow_BatchDatabase#5](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_batchdatabase/vb/dataflowbatchdatabase.vb#5)]  
  
 The `AddEmployees` method adds random employee data to the database by using dataflow. It creates an <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> object that calls the `InsertEmployees` method to add an employee entry to the database. The `AddEmployees` method then calls the `PostRandomEmployees` method to post multiple `Employee` objects to the <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> object. The `AddEmployees` method then waits for all insert operations to finish.  
  
<a name="buffering"></a>   
## Using Buffering to Add Employee Data to the Database  
 Add to the `Program` class the `AddEmployeesBatched` method.  
  
 [!code-csharp[TPLDataflow_BatchDatabase#6](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_batchdatabase/cs/dataflowbatchdatabase.cs#6)]
 [!code-vb[TPLDataflow_BatchDatabase#6](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_batchdatabase/vb/dataflowbatchdatabase.vb#6)]  
  
 This method resembles `AddEmployees`, except that it also uses the <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> class to buffer multiple `Employee` objects before it sends those objects to the <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> object. Because the <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> class propagates out multiple elements as a collection, the <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> object is modified to act on an array of `Employee` objects. As in the `AddEmployees` method, `AddEmployeesBatched` calls the `PostRandomEmployees` method to post multiple `Employee` objects; however, `AddEmployeesBatched` posts these objects to the <xref:System.Threading.Tasks.Dataflow.BatchBlock%601> object. The `AddEmployeesBatched`  method also waits for all insert operations to finish.  
  
<a name="bufferedJoin"></a>   
## Using Buffered Join to Read Employee Data from the Database  
 Add to the `Program` class the `GetRandomEmployees` method.  
  
 [!code-csharp[TPLDataflow_BatchDatabase#7](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_batchdatabase/cs/dataflowbatchdatabase.cs#7)]
 [!code-vb[TPLDataflow_BatchDatabase#7](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_batchdatabase/vb/dataflowbatchdatabase.vb#7)]  
  
 This method prints information about random employees to the console. It creates several random `Employee` objects and calls the `GetEmployeeID` method to retrieve the unique identifier for each object. Because the `GetEmployeeID` method throws an exception if there is no matching employee with the given first and last names, the `GetRandomEmployees` method uses the <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602> class to store `Employee` objects for successful calls to `GetEmployeeID` and <xref:System.Exception?displayProperty=nameWithType> objects for calls that fail. The <xref:System.Threading.Tasks.Dataflow.ActionBlock%601> object in this example acts on a <xref:System.Tuple%602> object that holds a list of `Employee` objects and a list of <xref:System.Exception> objects. The <xref:System.Threading.Tasks.Dataflow.BatchedJoinBlock%602> object propagates out this data when the sum of the received `Employee` and <xref:System.Exception> object counts equals the batch size.  
  
<a name="complete"></a>   
## The Complete Example  
 The following example shows the complete code. The `Main` method compares the time that is required to perform batched database insertions versus the time to perform non-batched database insertions. It also demonstrates the use of buffered join to read employee data from the database and also report errors.  
  
 [!code-csharp[TPLDataflow_BatchDatabase#100](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_batchdatabase/cs/dataflowbatchdatabase.cs#100)]
 [!code-vb[TPLDataflow_BatchDatabase#100](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_batchdatabase/vb/dataflowbatchdatabase.vb#100)]  
  
## See Also  
 [Dataflow](../../../docs/standard/parallel-programming/dataflow-task-parallel-library.md)
