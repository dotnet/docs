---
description: "Learn more about: SqlDependency in an ASP.NET Application"
title: "SqlDependency in an ASP.NET Application"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: ff226ce3-f6b5-47a1-8d22-dc78b67e07f5
---
# SqlDependency in an ASP.NET Application

The example in this section shows how to use <xref:System.Data.SqlClient.SqlDependency> indirectly by leveraging the ASP.NET <xref:System.Web.Caching.SqlCacheDependency> object. The <xref:System.Web.Caching.SqlCacheDependency> object uses a <xref:System.Data.SqlClient.SqlDependency> to listen for notifications and correctly update the cache.  
  
> [!NOTE]
> The sample code assumes that you have enabled query notifications by executing the scripts in [Enabling Query Notifications](enabling-query-notifications.md).  
  
## About the Sample Application  

 The sample application uses a single ASP.NET Web page to display product information from the **AdventureWorks** SQL Server database in a <xref:System.Web.UI.WebControls.GridView> control. When the page loads, the code writes the current time to a <xref:System.Web.UI.WebControls.Label> control. It then defines a <xref:System.Web.Caching.SqlCacheDependency> object and sets properties on the <xref:System.Web.Caching.Cache> object to store the cache data for up to three minutes. The code then connects to the database and retrieves the data. When the page is loaded and the application is running ASP.NET will retrieve data from the cache, which you can verify by noting that the time on the page does not change. If the data being monitored changes, ASP.NET invalidates the cache and repopulate the `GridView` control with fresh data, updating the time displayed in the `Label` control.  
  
## Creating the Sample Application  

 Follow these steps to create and run the sample application:  
  
1. Create a new ASP.NET Web site.  
  
2. Add a <xref:System.Web.UI.WebControls.Label> and a <xref:System.Web.UI.WebControls.GridView> control to the Default.aspx page.  
  
3. Open the page's class module and add the following directives:  
  
    ```vb  
    Option Strict On  
    Option Explicit On  
  
    Imports System.Data.SqlClient  
    ```  
  
    ```csharp  
    using System.Data.SqlClient;  
    using System.Web.Caching;  
    ```  
  
4. Add the following code in the page's `Page_Load` event:  
  
     [!code-csharp[DataWorks SqlDependency.AspNet#1](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SqlDependency.AspNet/CS/Default.aspx.cs#1)]
     [!code-vb[DataWorks SqlDependency.AspNet#1](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SqlDependency.AspNet/VB/Default.aspx.vb#1)]  
  
5. Add two helper methods, `GetConnectionString` and `GetSQL`. The connection string defined uses integrated security. You will need to verify that the account you are using has the necessary database permissions and that the sample database, **AdventureWorks**, has notifications enabled.
  
     [!code-csharp[DataWorks SqlDependency.AspNet#2](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SqlDependency.AspNet/CS/Default.aspx.cs#2)]
     [!code-vb[DataWorks SqlDependency.AspNet#2](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SqlDependency.AspNet/VB/Default.aspx.vb#2)]  
  
### Testing the Application  

 The application caches the data displayed on the Web form and refreshes it every three minutes if there is no activity. If a change occurs to the database, the cache is refreshed immediately. Run the application from Visual Studio, which loads the page into the browser. The cache refresh time displayed indicates when the cache was last refreshed. Wait three minutes, and then refresh the page, causing a postback event to occur. Note that the time displayed on the page has changed. If you refresh the page in less than three minutes, the time displayed on the page will remain the same.  
  
 Now update the data in the database, using a Transact-SQL UPDATE command and refresh the page. The time displayed now indicates that the cache was refreshed with the new data from the database. Note that although the cache is updated, the time displayed on the page does not change until a postback event occurs.  

## Distributed cache synchronization using SQL Dependency

Some of the third-party distributed caches such as [NCache](https://www.alachisoft.com/ncache) provide support to synchronize the SQL database and cache using [SQL Dependency](https://www.alachisoft.com/resources/docs/ncache/prog-guide/sql-dependency.html). For more information and an example source code implementation, see [Distributed cache SQL Dependency sample](https://github.com/Alachisoft/NCache-Samples/tree/master/dotnet/Dependencies/SQLDependency).

## See also

- [Query Notifications in SQL Server](query-notifications-in-sql-server.md)
- [ADO.NET Overview](../ado-net-overview.md)
