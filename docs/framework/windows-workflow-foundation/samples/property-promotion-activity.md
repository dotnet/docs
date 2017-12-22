---
title: "Property Promotion Activity"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 802196b7-1159-4c05-b41b-d3bfdfcc88d9
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Property Promotion Activity
This sample provides an end-to-end solution that integrates the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> Promotion feature directly into the workflow authoring experience. A collection of configuration elements, workflow activities, and workflow extensions that simplify the use of the Promotion feature are provided. Additionally, the sample contains a simple workflow that demonstrates how to use this collection.  
  
> [!NOTE]
>  Samples are provided for educational purposes only. They are not intended for a production environment, and have not been tested in a production environment. Microsoft does not provide technical support for these samples.  
  
## Prerequisites  
  
-   An initialized <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> database  
  
-   [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)]  
  
## Sample Projects  
  
-   The **PropertyPromotionActivity** project contains files pertaining to the promotion-specific configuration elements, workflow activities, and workflow extensions.  
  
-   The **CounterServiceApplication** project contains a sample workflow that uses the **SqlWorkflowInstanceStorePromotion** project.  
  
-   A SQL script (PropertyPromotionActivitySQLSample.sql) that must be run against the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> database.  
  
-   A solution file that links the two [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] projects (`PropertyPromotionActivity.sln`)  
  
## To set up and run the sample  
  
1.  Initialize a workflow persistence database.  
  
    1.  Navigate to the sample directory (\WF\Basic\Persistence\PropertyPromotionActivity) and run CreateInstanceStore.cmd.  
  
    2.  If Administrator privileges are not available, create a SQL Server login. In SQL Server Management Studio, go to **Security**, **Logins**. Right-click **Logins** and create a new login. Add your ACL user to the SQL role by opening **Databases**, **InstanceStore**, **Security**. Right-click **Users** and select **New user**. Set the **Login name** to the user created above. Add the user to the Database role membership System.Activities.DurableInstancing.InstanceStoreUsers (and others). Note that the user might exist already (for example, user dbo).  
  
2.  Open the PropertyPromotionActivity.sln solution file in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
3.  If you created the instance store in a database other than a local installation of SQL Server Express, then you must update the database connection string. Alter the App.config file under the **CounterServiceApplication** by setting the value of the `connectionString` attribute on the `sqlWorkflowInstanceStorePromotion` node so that it points to the persistence database that was initialized in step 1.  
  
4.  Build and run the solution. This will start the Counter WF service and automatically start a workflow instance.  
  
5.  Quickly select all the rows in the [dbo].[CounterService] view in your persistence database (this view was added by running CreateInstanceStore.cmd in step 1). You will see a result set similar to the following:  
  
    |InstanceId|CounterValue|CounterValueLastUpdated|  
    |----------------|------------------|-----------------------------|  
    |2FA2C302-929E-4C0D-8C25-768A3DA20CE5|12|2010-02-18 22:48:01.740|  
  
     As you keep refreshing the view, you will notice that CounterValue and CounterValueLastUpdated change every two seconds. This is the interval at which the counter updates itself. CounterValue and CounterValueLastUpdated represent promoted properties for this workflow.  
  
## To remove the sample  
  
-   Run RemoveInstanceStore.cmd in the sample directory (\WF\Basic\Persistence\PropertyPromotionActivity).  
  
## Understanding This Sample  
 The sample contains two projects and an SQL file:  
  
-   **CounterServiceApplication** is a console application that hosts a simple Counter WF service. Upon receiving a one-way message through the `Start` endpoint, the workflow counts from 0 to 29, incrementing a counter variable every two seconds. After every counter increment, the workflow persists, and the promoted properties are updated in the [dbo].[CounterService] view. When the console application is run, it hosts the WF service and sends a message to the `Start` endpoint, creating a Counter WF instance.  
  
-   **PropertyPromotionActivity** is a class library that contains the configuration elements, workflow activities, and workflow extensions that the **CounterServiceApplication** uses.  
  
-   **PropertyPromotionActivitySQLSample.sql** creates and adds the view [dbo].[CounterService] to the database.  
  
### CounterServiceApplication  
  
#### Using the SqlWorkflowInstanceStorePromotion Configuration Element  
 The `SqlWorkflowInstanceStorePromotion` configuration element inherits from the `SqlWorkflowInstanceStore` configuration element, but adds an additional configuration element called `promotionSets`. The `promotionSets` element enables the user to specify promoted properties through configuration. This is the configuration file that is used by the sample:  
  
```xml  
<sqlWorkflowInstanceStorePromotion connectionString ="Data Source=.;Initial Catalog=SqlWorkflowInstanceStoreTest;Integrated Security=True;">  
  <promotionSets>  
    <promotionSet name="CounterService">  
      <promotedValue propertyName="Count"/>  
      <promotedValue propertyName="LastIncrementedAt"/>  
    </promotionSet>  
  </promotionSets>  
</sqlWorkflowInstanceStorePromotion>  
```  
  
 Examine the definition for the [dbo].[CounterService] view.  
  
```sql  
create view [dbo].[CounterService] as  
      select [InstanceId],  
 [Value1] as [CounterValue],  
 [Value2] as [CounterValueLastUpdated]  
      from [System.Activities.DurableInstancing].[InstancePromotedProperties]  
      where [PromotionName] = 'CounterService'  
go  
```  
  
 When a workflow instance persists, a row is inserted into the `InstancePromotedProperties` view for each `PromotionSet` defined in the configuration. This row contains all the promoted properties of the `PromotionSet` (one promoted property per column). This `PromotionSet` is keyed by the tuple: `InstanceId, PromotionName`. In this sample, we have one `PromotionSet` defined in configuration whose name attribute is `CounterService`. Note how the `PromotionName` column value is equal to the name attribute of the `PromotionSet` element.  
  
 The order of the `promotedValue` elements correlates with the placement of the promoted properties in the `InstancePromotedProperties` view. `Count` is the first `promotedValue` element. As a result, it is mapped to the `Value1` column in the `InstancePromotedProperties` view. `LastIncrementedAt` is the second `promotedValue` element. As a result, it is mapped to the `Value2` column in the `InstancePromotedProperties` view.  
  
#### Using the PromoteValue Activity  
 Examine the CounterService.xamlx file in the [!INCLUDE[wf2](../../../../includes/wf2-md.md)] Designer. Notice that there are two special activities in the WF definition: `PromoteValue<DateTime>` and `PromoteValue<Int32>`.  
  
 The `PromoteValue<Int32>` activity has its `Name` member defined as `Count`. This matches with the first `promotedValue` element in the configuration, and has its `Value` defined as the `Counter` workflow variable. When the workflow persists, the `Counter` workflow variable is persisted as a promoted property into the `Value1` column of the `InstancePromotedProperties` view.  
  
 The `PromoteValue<DateTime>` activity has its `Name` member defined as `LastIncrementedAt`. This matches with the second `promotedValue` element in the configuration, and has its `Value` defined as the `TimeLastIncremented` workflow variable. This means that when the workflow persists, the value for the `TimeLastIncremented` workflow variable will be persisted as a promoted property into the `Value2` column of the `InstancePromotedProperties` view.  
  
 Note that the `PromotedValue` activity also has a Boolean member called `ClearExistingPromotedData`. When this member is set to `true`, this clears all the promoted property values up to that point in the workflow. For example, if a Sequence activity is defined as follows:  
  
1.  PromoteValue { Name = "Count", Value = 3}  
  
2.  PromoteValue {Name = "LastIncrementedAt", Value = 1-1-2000 }  
  
3.  Persist  
  
4.  PromoteValue {Name = "Count", Value = 4, ClearExistingPromotedData = true}  
  
5.  Persist  
  
 On the second persist, the promoted value for `Count` will be 4. However, the promoted value for `LastIncrementedAt` will be `NULL`. If `ClearExistingPromotedData` was not set to `true` for step 4, then after the second persist, the promoted value for Count would be 4. As a result, the promoted value for `LastIncrementedAt` would still be 1-1-2000.  
  
### PropertyPromotionActivity  
 This class library contains the following public classes to simplify use of the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> Promotion feature.  
  
#### PromoteValue Class  
 This class promotes one property. The name of the promoted property should match a name attribute of a `promotedValue` element in the configuration. This activity can be used in the Workflow Designer. See the CounterServiceApplication for an example usage.  
  
```csharp  
public class PromoteValue<T> : CodeActivity  
{  
    public PromoteValue()  
    {  
    }  
  
    public bool ClearExistingPromotedData { get; set; }  
    public string Name { get; set; }  
    public InArgument<T> Value { get; set; }  
}  
```  
  
 ClearExistingPromotedData (Bool)  
 Clears all values that were promoted before this activity.  
  
 Name (string)  
 The name that represents this property. This should match the name attribute of a \<promotedValue> element in the configuration.  
  
 Value (InArgument\<T>)  
 The variable / value that you want to store in the column.  
  
#### PromoteValues Class  
 Promotes multiple properties. The names of the promoted properties should match all name attributes in the `promotedValue` elements in the configuration. Usage is similar to the `PromoteValue` activity, except for the fact that multiple properties can be promoted at the same time. This activity cannot be used in the Workflow Designer.  
  
```  
public class PromoteValues : CodeActivity  
{  
    public PromoteValues()  
    {  
        this.ValuesToPromote = new Dictionary<string, InArgument>();  
    }  
  
    public bool ClearExistingPromotedData { get; set; }  
    public IDictionary<string, InArgument> ValuesToPromote { get; set; }  
}  
```  
  
#### SqlWorkflowInstanceStorePromotionBehavior  
 Derives from `SqlWorkflowInstanceStoreBehavior`. This derived class adds a custom persistence participant (also a part of this library) as a workflow extension. The implementation of the previous two workflow activities relies on this custom persistence participant.  
  
```  
public class SqlWorkflowInstanceStorePromotionBehavior :  
             SqlWorkflowInstanceStoreBehavior, IServiceBehavior  
{  
        public void Promote(string name, IEnumerable<string> promoteAsSqlVariant,  
                            IEnumerable<string> promoteAsBinary)  
  
}  
```  
  
 This class library also contains the `ConfigurationElement` implementation for the `SqlWorkflowInstanceStorePromotionElement` and a custom persistence participant used by the previous promotion activities.  
  
### PropertyPromotionActivitySQLSample  
 This SQL file creates a `[dbo].[CounterService]` view in addition to the `[InstancePromotedProperties]` view for querying all instances that have a CounterService Promotion set.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing:  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory:  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Persistence\PropertyPromotionActivity`  
  
## See Also  
 [AppFabric Hosting and Persistence Samples](http://go.microsoft.com/fwlink/?LinkId=193961)
