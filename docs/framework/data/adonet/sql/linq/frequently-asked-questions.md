---
title: "Frequently Asked Questions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 252ed666-0679-4eea-b71b-2f14117ef443
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Frequently Asked Questions
The following sections answer some common issues that you might encounter when you implement [!INCLUDE[vbteclinq](../../../../../../includes/vbteclinq-md.md)].  
  
 Additional issues are addressed in [Troubleshooting](../../../../../../docs/framework/data/adonet/sql/linq/troubleshooting.md).  
  
## Cannot Connect  
 Q. I cannot connect to my database.  
  
 A. Make sure your connection string is correct and that your [!INCLUDE[ssNoVersion](../../../../../../includes/ssnoversion-md.md)] instance is running. Note also that [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] requires the Named Pipes protocol to be enabled. For more information, see [Learning by Walkthroughs](../../../../../../docs/framework/data/adonet/sql/linq/learning-by-walkthroughs.md).  
  
## Changes to Database Lost  
 Q. I made a change to data in the database, but when I reran my application, the change was no longer there.  
  
 A. Make sure that you call <xref:System.Data.Linq.DataContext.SubmitChanges%2A> to save results to the database.  
  
## Database Connection: Open How Long?  
 Q. How long does my database connection remain open?  
  
 A. A connection typically remains open until you consume the query results. If you expect to take time to process all the results and are not opposed to caching the results, apply <xref:System.Linq.Enumerable.ToList%2A> to the query. In common scenarios where each object is processed only one time, the streaming model is superior in both `DataReader` and [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)].  
  
 The exact details of connection usage depend on the following:  
  
-   Connection status if the <xref:System.Data.Linq.DataContext> is constructed with a connection object.  
  
-   Connection string settings (for example, enabling Multiple Active Result Sets (MARS). For more information, see [Multiple Active Result Sets (MARS)](../../../../../../docs/framework/data/adonet/sql/multiple-active-result-sets-mars.md).  
  
## Updating Without Querying  
 Q. Can I update table data without first querying the database?  
  
 A. Although [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not have set-based update commands, you can use either of the following techniques to update without first querying:  
  
-   Use <xref:System.Data.Linq.DataContext.ExecuteCommand%2A> to send SQL code.  
  
-   Create a new instance of the object and initialize all the current values (fields) that affect the update. Then attach the object to the <xref:System.Data.Linq.DataContext> by using <xref:System.Data.Linq.Table%601.Attach%2A> and modify the field you want to change.  
  
## Unexpected Query Results  
 Q. My query is returning unexpected results. How can I inspect what is occurring?  
  
 A. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] provides several tools for inspecting the SQL code it generates. One of the most important is <xref:System.Data.Linq.DataContext.Log%2A>. For more information, see [Debugging Support](../../../../../../docs/framework/data/adonet/sql/linq/debugging-support.md).  
  
## Unexpected Stored Procedure Results  
 Q. I have a stored procedure whose return value is calculated by `MAX()`. When I drag the stored procedure to the [!INCLUDE[vs_ordesigner_short](../../../../../../includes/vs-ordesigner-short-md.md)] surface, the return value is not correct.  
  
 A. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] provides two ways to return database-generated values by way of stored procedures:  
  
-   By naming the output result.  
  
-   By explicitly specifying an output parameter.  
  
 The following is an example of incorrect output. Because [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] cannot map the results, it always returns 0:  
  
 `create procedure proc2`  
  
 `as`  
  
 `begin`  
  
 `select max(i) from t where name like 'hello'`  
  
 `end`  
  
 The following is an example of correct output by using an output parameter:  
  
 `create procedure proc2`  
  
 `@result int OUTPUT`  
  
 `as`  
  
 `select @result = MAX(i) from t where name like 'hello'`  
  
 `go`  
  
 The following is an example of correct output by naming the output result:  
  
 `create procedure proc2`  
  
 `as`  
  
 `begin`  
  
 `select nax(i) AS MaxResult from t where name like 'hello'`  
  
 `end`  
  
 For more information, see [Customizing Operations By Using Stored Procedures](../../../../../../docs/framework/data/adonet/sql/linq/customizing-operations-by-using-stored-procedures.md).  
  
## Serialization Errors  
 Q. When I try to serialize, I get the following error: "Type 'System.Data.Linq.ChangeTracker+StandardChangeTracker' ... is not marked as serializable."  
  
 A. Code generation in [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] supports <xref:System.Runtime.Serialization.DataContractSerializer> serialization. It does not support <xref:System.Xml.Serialization.XmlSerializer> or <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter>. For more information, see [Serialization](../../../../../../docs/framework/data/adonet/sql/linq/serialization.md).  
  
## Multiple DBML Files  
 Q. When I have multiple DBML files that share some tables in common, I get a compiler error.  
  
 A. Set the **Context Namespace** and **Entity Namespace** properties from the [!INCLUDE[vs_ordesigner_long](../../../../../../includes/vs-ordesigner-long-md.md)] to a distinct value for each DBML file. This approach eliminates the name/namespace collision.  
  
## Avoiding Explicit Setting of Database-Generated Values on Insert or Update  
 Q. I have a database table with a `DateCreated` column that defaults to SQL `Getdate()`. When I try to insert a new record by using [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)], the value gets set to `NULL`. I would expect it to be set to the database default.  
  
 A. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] handles this situation automatically for identity (auto-increment) and rowguidcol (database-generated GUID) and timestamp columns. In other cases, you should manually set <xref:System.Data.Linq.Mapping.ColumnAttribute.IsDbGenerated%2A>=`true` and <xref:System.Data.Linq.Mapping.ColumnAttribute.AutoSync%2A>=<xref:System.Data.Linq.Mapping.AutoSync.Always>/<xref:System.Data.Linq.Mapping.AutoSync.OnInsert>/<xref:System.Data.Linq.Mapping.AutoSync.OnUpdate> properties.  
  
## Multiple DataLoadOptions  
 Q. Can I specify additional load options without overwriting the first?  
  
 A. Yes. The first is not overwritten, as in the following example:  
  
```vb  
Dim dlo As New DataLoadOptions()  
dlo.LoadWith(Of Order)(Function(o As Order) o.Customer)  
dlo.LoadWith(Of Order)(Function(o As Order) o.OrderDetails)  
```  
  
```csharp  
DataLoadOptions dlo = new DataLoadOptions();  
dlo.LoadWith<Order>(o => o.Customer);  
dlo.LoadWith<Order>(o => o.OrderDetails);  
```  
  
## Errors Using SQL Compact 3.5  
 Q. I get an error when I drag tables out of a [!INCLUDE[ssEW](../../../../../../includes/ssew-md.md)] database.  
  
 A. The [!INCLUDE[vs_ordesigner_long](../../../../../../includes/vs-ordesigner-long-md.md)] does not support [!INCLUDE[ssEW](../../../../../../includes/ssew-md.md)], although the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] runtime does. In this situation, you must create your own entity classes and add the appropriate attributes.  
  
## Errors in Inheritance Relationships  
 Q. I used the toolbox inheritance shape in the [!INCLUDE[vs_ordesigner_long](../../../../../../includes/vs-ordesigner-long-md.md)] to connect two entities, but I get errors.  
  
 A. Creating the relationship is not enough. You must provide information such as the discriminator column, base class discriminator value, and derived class discriminator value.  
  
## Provider Model  
 Q. Is a public provider model available?  
  
 A. No public provider model is available. At this time, [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] supports [!INCLUDE[ssNoVersion](../../../../../../includes/ssnoversion-md.md)] and [!INCLUDE[ssEW](../../../../../../includes/ssew-md.md)] only.  
  
## SQL-Injection Attacks  
 Q. How is [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] protected from SQL-injection attacks?  
  
 A. SQL injection has been a significant risk for traditional SQL queries formed by concatenating user input. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] avoids such injection by using <xref:System.Data.SqlClient.SqlParameter> in queries. User input is turned into parameter values. This approach prevents malicious commands from being used from customer input.  
  
## Changing Read-only Flag in DBML Files  
 Q. How do I eliminate setters from some properties when I create an object model from a DBML file?  
  
 A. Take the following steps for this advanced scenario:  
  
1.  In the .dbml file, modify the property by changing the <xref:System.Data.Linq.ITable.IsReadOnly%2A> flag to `True`.  
  
2.  Add a partial class. Create a constructor with parameters for the read-only members.  
  
3.  Review the default <xref:System.Data.Linq.Mapping.UpdateCheck> value (<xref:System.Data.Linq.Mapping.UpdateCheck.Never>) to determine whether that is the correct value for your application.  
  
    > [!CAUTION]
    >  If you are using the [!INCLUDE[vs_ordesigner_long](../../../../../../includes/vs-ordesigner-long-md.md)] in [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)], your changes might be overwritten.  
  
## APTCA  
 Q. Is System.Data.Linq marked for use by partially trusted code?  
  
 A. Yes, the System.Data.Linq.dll assembly is among those [!INCLUDE[dnprdnshort](../../../../../../includes/dnprdnshort-md.md)] assemblies marked with the <xref:System.Security.AllowPartiallyTrustedCallersAttribute> attribute. Without this marking, assemblies in the [!INCLUDE[dnprdnshort](../../../../../../includes/dnprdnshort-md.md)] are intended for use only by fully trusted code.  
  
 The principal scenario in [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] for allowing partially trusted callers is to enable the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] assembly to be accessed from Web applications, where the *trust* configuration is Medium.  
  
## Mapping Data from Multiple Tables  
 Q. The data in my entity comes from multiple tables. How do I map it?  
  
 A. You can create a view in a database and map the entity to the view. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] generates the same SQL for views as it does for tables.  
  
> [!NOTE]
>  The use of views in this scenario has limitations. This approach works most safely when the operations performed on <xref:System.Data.Linq.Table%601> are supported by the underlying view. Only you know which operations are intended. For example, most applications are read-only, and another sizeable number perform `Create`/`Update`/`Delete` operations only by using stored procedures against views.  
  
## Connection Pooling  
 Q. Is there a construct that can help with <xref:System.Data.Linq.DataContext> pooling?  
  
 A. Do not try to reuse instances of <xref:System.Data.Linq.DataContext>. Each <xref:System.Data.Linq.DataContext> maintains state (including an identity cache) for one particular edit/query session. To obtain new instances based on the current state of the database, use a new <xref:System.Data.Linq.DataContext>.  
  
 You can still use underlying [!INCLUDE[vstecado](../../../../../../includes/vstecado-md.md)] connection pooling. For more information, see [SQL Server Connection Pooling (ADO.NET)](../../../../../../docs/framework/data/adonet/sql-server-connection-pooling.md).  
  
## Second DataContext Is Not Updated  
 Q. I used one instance of <xref:System.Data.Linq.DataContext> to store values in the database. However, a second <xref:System.Data.Linq.DataContext> on the same database does not reflect the updated values. The second <xref:System.Data.Linq.DataContext> instance seems to return cached values.  
  
 A. This behavior is by design. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] continues to return the same instances/values that you saw in the first instance. When you make updates, you use optimistic concurrency. The original data is used to check against the current database state to assert that it is in fact still unchanged. If it has changed, a conflict occurs and your application must resolve it. One option of your application is to reset the original state to the current database state and to try the update again. For more information, see [How to: Manage Change Conflicts](../../../../../../docs/framework/data/adonet/sql/linq/how-to-manage-change-conflicts.md).  
  
 You can also set <xref:System.Data.Linq.DataContext.ObjectTrackingEnabled%2A> to false, which turns off caching and change tracking. You can then retrieve the latest values every time that you query.  
  
## Cannot Call SubmitChanges in Read-only Mode  
 Q. When I try to call <xref:System.Data.Linq.DataContext.SubmitChanges%2A> in read-only mode, I get an error.  
  
 A. Read-only mode turns off the ability of the context to track changes.  
  
## See Also  
 [Reference](../../../../../../docs/framework/data/adonet/sql/linq/reference.md)  
 [Troubleshooting](../../../../../../docs/framework/data/adonet/sql/linq/troubleshooting.md)  
 [Security in LINQ to SQL](../../../../../../docs/framework/data/adonet/sql/linq/security-in-linq-to-sql.md)
