---
title: "Database Access Activities"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 174a381e-1343-46a8-a62c-7c2ae2c4f0b2
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Database Access Activities
Database access activities allow you to access a database within a workflow. These activities allow accessing databases to retrieve or modify information and use [ADO.NET](http://go.microsoft.com/fwlink/?LinkId=166081) to access the database.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to (download page) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\ActivityLibrary\DbActivities`  
  
## Database Activities  
 The following sections detail the list of activities included in this sample.  
  
## DbUpdate  
 Executes a SQL query that produces a modification in the database (insert, update, delete, and other modifications).  
  
 This class performs its work asynchronously (it derives from <xref:System.Activities.AsyncCodeActivity> and uses its asynchronous capabilities).  
  
 The connection information can be configured by setting a provider invariant name (`ProviderName`) and the connection string (`ConnectionString`) or just using a connection string configuration name (`ConfigFileSectionName`) from the application configuration file.  
  
 The query to be executed is configured in its `Sql` property and the parameters are passed through the `Parameters` collection.  
  
 After `DbUpdate` is executed, the number of affected records is returned in the `AffectedRecords` property.  
  
```  
Public class DbUpdate: AsyncCodeActivity  
{  
    [RequiredArgument]  
    [OverloadGroup("ConnectionString")]  
    [DefaultValue(null)]  
    public InArgument<string> ProviderName { get; set; }  
  
    [RequiredArgument]  
    [OverloadGroup("ConnectionString")]  
    [DependsOn("ProviderName")]  
    [DefaultValue(null)]  
    public InArgument<string> ConnectionString { get; set; }  
  
    [RequiredArgument]  
    [OverloadGroup("ConfigFileSectionName")]  
    [DefaultValue(null)]  
    public InArgument<string> ConfigName { get; set; }  
  
    [DefaultValue(null)]  
    public CommandType CommandType { get; set; }  
  
    [RequiredArgument]  
    public InArgument<string> Sql { get; set; }  
  
    [DependsOn("Sql")]  
    [DefaultValue(null)]  
    public IDictionary<string, Argument> Parameters { get; }  
  
    [DependsOn("Parameters")]  
    public OutArgument<int> AffectedRecords { get; set; }       
}  
```  
  
|Argument|Description|  
|-|-|  
|ProviderName|ADO.NET provider invariant name. If this argument is set, then the `ConnectionString` must also be set.|  
|ConnectionString|Connection string to connect to the database. If this argument is set, then `ProviderName` must also be set.|  
|ConfigName|Name of the configuration file section where the connection information is stored. When this argument is set `ProviderName` and `ConnectionString` are not required.|  
|CommandType|Type of the <xref:System.Data.Common.DbCommand> to be executed.|  
|Sql|The SQL command to be executed.|  
|Parameters|Collection of the parameters of the SQL query.|  
|AffectedRecords|Number of records affected by the last operation.|  
  
## DbQueryScalar  
 Executes a query that retrieves a single value from the database.  
  
 This class performs its work asynchronously (it derives from <xref:System.Activities.AsyncCodeActivity%601> and uses its asynchronous capabilities).  
  
 The connection information can be configured by setting a provider invariant name (`ProviderName`) and the connection string (`ConnectionString`) or just using a connection string configuration name (`ConfigFileSectionName`) from the application configuration file.  
  
 The query to be executed is configured in its `Sql` property and the parameters are passed through the `Parameters` collection.  
  
 After `DbQueryScalar` is executed, the scalar is returned in the `Result``out` argument (of type `TResult`, that is defined in the base class <xref:System.Activities.AsyncCodeActivity%601>).  
  
```  
public class DbQueryScalar<TResult> : AsyncCodeActivity<TResult>  
{  
    // public arguments  
    [RequiredArgument]  
    [OverloadGroup("ConnectionString")]  
    [DefaultValue(null)]  
    public InArgument<string> ProviderName { get; set; }  
  
    [RequiredArgument]  
    [OverloadGroup("ConnectionString")]  
    [DependsOn("ProviderName")]  
    [DefaultValue(null)]  
    public InArgument<string> ConnectionString { get; set; }  
  
    [RequiredArgument]  
    [OverloadGroup("ConfigFileSectionName")]  
    [DefaultValue(null)]  
    public InArgument<string> ConfigName { get; set; }  
  
    [DefaultValue(null)]  
    public CommandType CommandType { get; set; }  
  
    [RequiredArgument]  
    public InArgument<string> Sql { get; set; }  
  
    [DependsOn("Sql")]  
    [DefaultValue(null)]  
    public IDictionary<string, Argument> Parameters { get; }  
}  
```  
  
|Argument|Description|  
|-|-|  
|ProviderName|ADO.NET provider invariant name. If this argument is set, then the `ConnectionString` must also be set.|  
|ConnectionString|Connection string to connect to the database. If this argument is set, then `ProviderName` must also be set.|  
|ConfigName|Name of the configuration file section where the connection information is stored. When this argument is set `ProviderName` and `ConnectionString` are not required.|  
|CommandType|Type of the <xref:System.Data.Common.DbCommand> to be executed.|  
|Sql|The SQL command to be executed.|  
|Parameters|Collection of the parameters of the SQL query.|  
|Result|Scalar that is obtained after the query is executed. This argument is of type `TResult`.|  
  
## DbQuery  
 Executes a query that retrieves a list of objects. After the query is executed, a mapping function is executed (it can be <xref:System.Func%601><`DbDataReader`, `TResult`> or an <xref:System.Activities.ActivityFunc%601><`DbDataReader`, `TResult`>). This mapping function gets a record in a `DbDataReader` and maps it to the object to be returned.  
  
 The connection information can be configured by setting a provider invariant name (`ProviderName`) and the connection string (`ConnectionString`) or just using a connection string configuration name (`ConfigFileSectionName`) from the application configuration file.  
  
 The query to be executed is configured in its `Sql` property and the parameters are passed through the `Parameters` collection.  
  
 The results of the SQL query are retrieved using a `DbDataReader`. The activity iterates through the `DbDataReader` and maps the rows in the `DbDataReader` to an instance of `TResult`. The user of `DbQuery` has to provide the mapping code and this can be done in two ways: using a <xref:System.Func%601><`DbDataReader`, `TResult`> or an <xref:System.Activities.ActivityFunc%601><`DbDataReader`, `TResult`>. In the first case, the map is done in a single pulse of execution. Therefore, it is faster, but this cannot be serialized to XAML. In the last case, the map is performed in multiple pulses. Therefore, it might be slower but can be serialized to XAML and authored declaratively (any existing activity can participate in the mapping).  
  
```  
public class DbQuery<TResult> : AsyncCodeActivity<IList<TResult>> where TResult : class  
{  
    // public arguments  
    [RequiredArgument]  
    [OverloadGroup("ConnectionString")]  
    [DefaultValue(null)]  
    public InArgument<string> ProviderName { get; set; }  
  
    [RequiredArgument]  
    [OverloadGroup("ConnectionString")]  
    [DependsOn("ProviderName")]  
    [DefaultValue(null)]  
    public InArgument<string> ConnectionString { get; set; }  
  
    [RequiredArgument]  
    [OverloadGroup("ConfigFileSectionName")]  
    [DefaultValue(null)]  
    public InArgument<string> ConfigName { get; set; }  
  
    [DefaultValue(null)]  
    public CommandType CommandType { get; set; }  
  
    [RequiredArgument]  
    public InArgument<string> Sql { get; set; }  
  
    [DependsOn("Sql")]  
    [DefaultValue(null)]  
    public IDictionary<string, Argument> Parameters { get; }  
  
    [OverloadGroup("DirectMapping")]  
    [DefaultValue(null)]  
    public Func<DbDataReader, TResult> Mapper { get; set; }  
  
    [OverloadGroup("MultiplePulseMapping")]  
    [DefaultValue(null)]  
    public ActivityFunc<DbDataReader, TResult> MapperFunc { get; set; }  
}  
```  
  
|Argument|Description|  
|-|-|  
|ProviderName|ADO.NET provider invariant name. If this argument is set, then the `ConnectionString` must also be set.|  
|ConnectionString|Connection string to connect to the database. If this argument is set, then `ProviderName` must also be set.|  
|ConfigName|Name of the configuration file section where the connection information is stored. When this argument is set `ProviderName` and `ConnectionString` are not required.|  
|CommandType|Type of the <xref:System.Data.Common.DbCommand> to be executed.|  
|Sql|The SQL command to be executed.|  
|Parameters|Collection of the parameters of the SQL query.|  
|Mapper|Mapping function (<xref:System.Func%601><`DbDataReader`, `TResult`>) that takes a record in the `DataReader` obtained as result of executing the query and returns an instance of an object of type `TResult` to be added to the `Result` collection.<br /><br /> In this case, mapping is done in a single pulse of execution, but it cannot be authored declaratively using the designer.|  
|MapperFunc|Mapping function (<xref:System.Activities.ActivityFunc%601><`DbDataReader`, `TResult`>) that takes a record in the `DataReader` obtained as result of executing the query and returns an instance of an object of type `TResult` to be added to the `Result` collection.<br /><br /> In this case, the mapping is done in multiple pulses of execution. This function can be serialized to XAML and authored declaratively (any existing activity can participate in the mapping).|  
|Result|List of objects obtained as result of executing the query and executing the mapping function for each record in the `DataReader`.|  
  
## DbQueryDataSet  
 Executes a query that returns a <xref:System.Data.DataSet>. This class performs its work asynchronously. It derives from <xref:System.Activities.AsyncCodeActivity><`TResult`> and uses its asynchronous capabilities.  
  
 The connection information can be configured by setting a provider invariant name (`ProviderName`) and the connection string (`ConnectionString`) or just using a connection string configuration name (`ConfigFileSectionName`) from the application configuration file.  
  
 The query to be executed is configured in its `Sql` property and the parameters are passed through the `Parameters` collection.  
  
 After the `DbQueryDataSet` is executed the `DataSet` is returned in the `Result``out` argument (of type `TResult`, that is defined in the base class <xref:System.Activities.AsyncCodeActivity%601>).  
  
```  
public class DbQueryDataSet : AsyncCodeActivity<DataSet>  
{  
    // public arguments  
    [RequiredArgument]  
    [OverloadGroup("ConnectionString")]  
    [DefaultValue(null)]  
    public InArgument<string> ProviderName { get; set; }  
  
    [RequiredArgument]  
    [OverloadGroup("ConnectionString")]  
    [DependsOn("ProviderName")]  
    [DefaultValue(null)]  
    public InArgument<string> ConnectionString { get; set; }  
  
    [RequiredArgument]  
    [OverloadGroup("ConfigFileSectionName")]  
    [DefaultValue(null)]  
    public InArgument<string> ConfigName { get; set; }  
  
    [DefaultValue(null)]  
    public CommandType CommandType { get; set; }  
  
    [RequiredArgument]  
    public InArgument<string> Sql { get; set; }  
  
    [DependsOn("Sql")]  
    [DefaultValue(null)]  
    public IDictionary<string, Argument> Parameters { get; }  
}  
```  
  
|Argument|Description|  
|-|-|  
|ProviderName|ADO.NET provider invariant name. If this argument is set, then the `ConnectionString` must also be set.|  
|ConnectionString|Connection string to connect to the database. If this argument is set, then `ProviderName` must also be set.|  
|ConfigName|Name of the configuration file section where the connection information is stored. When this argument is set `ProviderName` and `ConnectionString` are not required.|  
|CommandType|Type of the <xref:System.Data.Common.DbCommand> to be executed.|  
|Sql|The SQL command to be executed.|  
|Parameters|Collection of the parameters of the SQL query.|  
|Result|<xref:System.Data.DataSet> that is obtained after the query is executed.|  
  
## Configuring Connection Information  
 All DbActivities share the same configuration parameters. They can be configured in two ways:  
  
-   `ConnectionString + InvariantName`: Set the ADO.NET provider invariant name and connection string.  
  
    ```  
    Activity dbSelectCount = new DbQueryScalar<DateTime>()  
    {  
        ProviderName = "System.Data.SqlClient",  
        ConnectionString = @"Data Source=.\SQLExpress;  
                             Initial Catalog=DbActivitiesSample;  
                             Integrated Security=True",  
        Sql = "SELECT GetDate()"  
    };  
    ```  
  
-   `ConfigName`: Set the name of the configuration section that contains the connection information.  
  
    ```xml  
    <connectionStrings>      
        <add name="DbActivitiesSample"  
             providerName="System.Data.SqlClient"  
             connectionString="Data Source=.\SQLExpress;Initial Catalog=DbActivitiesSample;Integrated Security=true"/>  
      </connectionStrings>  
    ```  
  
-   In the activity:  
  
    ```  
    Activity dbSelectCount = new DbQueryScalar<int>()  
    {                  
        ConfigName = "DbActivitiesSample",  
        Sql = "SELECT COUNT(*) FROM Roles"  
    };  
    ```  
  
## Running this sample  
  
### Setup instructions  
 This sample uses a database. A set-up and load script (Setup.cmd) is provided with the sample. You must execute that file using the command prompt.  
  
 The Setup.cmd script invokes the CreateDb.sql script file, which contains SQL commands that do the following:  
  
-   Creates a database called DbActivitiesSample.  
  
-   Creates the Roles table.  
  
-   Creates Employees table.  
  
-   Inserts three records into the Roles table.  
  
-   Inserts twelve records into the Employees table.  
  
##### To run Setup.cmd  
  
1.  Open a command prompt.  
  
2.  Go to the DbActivities sample folder.  
  
3.  Type "setup.cmd" and press ENTER.  
  
    > [!NOTE]
    >  Setup.cmd attempts to install the sample in your local machine SqlExpress instance. If you want to install it in other SQL server instance, edit Setup.cmd with the new instance name.  
  
##### To uninstall the sample database  
  
1.  Run Cleanup.cmd from the sample folder in a command prompt.  
  
##### To run the sample  
  
1.  Open the solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)]  
  
2.  To compile the solution, press CTRL+SHIFT+B.  
  
3.  To run the sample without debugging, press CTRL+F5.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\ActivityLibrary\DbActivities`
