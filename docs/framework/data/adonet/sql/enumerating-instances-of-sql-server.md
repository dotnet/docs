---
description: "Learn more about: Enumerating Instances of SQL Server (ADO.NET)"
title: "Enumerating Instances of SQL Server"
ms.date: "10/23/2026"
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: ddf1c83c-9d40-45e6-b04d-9828c6cbbfdc
---
# Enumerating Instances of SQL Server (ADO.NET)

SQL Server permits applications to find SQL Server instances within the current network. The <xref:Microsoft.Data.Sql.SqlDataSourceEnumerator> class returns the visible servers in the <xref:System.Data.DataTable> object. The table lists the server instances available on the network, like the server list in the **Connection Properties** dialog box. The results aren't always complete.

With Microsoft.Data.SqlClient, <xref:Microsoft.Data.Sql.SqlDataSourceEnumerator.GetDataSources*> requires Windows with native networking. On Linux, macOS, or Windows with managed networking enabled, the method throws <xref:System.NotImplementedException>. In those environments, specify the server address and port directly in your connection string instead of server discovery.

> [!NOTE]
> As with most Windows services, it is best to run the SQL Browser service with the least possible privileges.

## Retrieving an Enumerator Instance

To retrieve information about available SQL Server instances, first retrieve an enumerator with the shared/static <xref:Microsoft.Data.Sql.SqlDataSourceEnumerator.Instance> property:

```vb
Dim instance As Microsoft.Data.Sql.SqlDataSourceEnumerator = _
   Microsoft.Data.Sql.SqlDataSourceEnumerator.Instance
```

```csharp
Microsoft.Data.Sql.SqlDataSourceEnumerator instance =
   Microsoft.Data.Sql.SqlDataSourceEnumerator.Instance;
```

After you retrieve the static instance, call <xref:Microsoft.Data.Sql.SqlDataSourceEnumerator.GetDataSources*> to retrieve information about available servers in the <xref:System.Data.DataTable> object:

```vb
Dim dataTable As System.Data.DataTable = instance.GetDataSources()
```

```csharp
System.Data.DataTable dataTable = instance.GetDataSources();
```

 The table returned from the method call contains the following columns, all of which contain `string` values:

|Column|Description|
|------------|-----------------|
|`ServerName`|Name of the server.|
|`InstanceName`|Name of the server instance. Blank if the server is running as the default instance.|
|`IsClustered`|Indicates whether the server is part of a cluster.|
|`Version`|Version of the server. For example:<br /><br /> -   9.00.x (SQL Server 2005)<br />-   10.0.xx (SQL Server 2008)<br />-   10.50.x (SQL Server 2008 R2)<br />-   11.0.xx (SQL Server 2012)|

## Enumeration Limitations

 All of the available servers may or may not be listed. The list can vary depending on factors such as timeouts and network traffic. This can cause the list to be different on two consecutive calls. Only servers on the same network will be listed. Broadcast packets typically won't traverse routers, which is why you may not see a server listed, but it will be stable across calls.

 Listed servers may or may not have additional information such as `IsClustered` and version. This is dependent on how the list was obtained. Servers listed through the SQL Server browser service will have more details than those found through the Windows infrastructure, which will list only the name.

> [!NOTE]
> Modern .NET doesn't support code access security or partial-trust execution. For server discovery, allow the required SQL Server Browser network traffic.

SQL Server provides information for the <xref:Microsoft.Data.Sql.SqlDataSourceEnumerator> through the external Windows service SQL Browser. This service is enabled by default, but administrators might turn it off or disable it, making the server instance invisible to this class.

## Example

 The following console application retrieves information about visible SQL Server instances and displays the information in the console window. Install the [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) NuGet package.

```vb
Imports Microsoft.Data.Sql
Imports System.Data

Module Module1
  Sub Main()
    ' Retrieve the enumerator instance and then the data.
    Dim instance As SqlDataSourceEnumerator = _
     SqlDataSourceEnumerator.Instance
    Dim table As System.Data.DataTable = instance.GetDataSources()

    ' Display the contents of the table.
    DisplayData(table)

    Console.WriteLine("Press any key to continue.")
    Console.ReadKey()
  End Sub

  Private Sub DisplayData(ByVal table As DataTable)
    For Each row As DataRow In table.Rows
      For Each col As DataColumn In table.Columns
        Console.WriteLine("{0} = {1}", col.ColumnName, row(col))
      Next
      Console.WriteLine("============================")
    Next
  End Sub
End Module
```

```csharp
using Microsoft.Data.Sql;

class Program
{
  static void Main()
  {
    // Retrieve the enumerator instance and then the data.
    SqlDataSourceEnumerator instance =
      SqlDataSourceEnumerator.Instance;
    System.Data.DataTable table = instance.GetDataSources();

    // Display the contents of the table.
    DisplayData(table);

    Console.WriteLine("Press any key to continue.");
    Console.ReadKey();
  }

  private static void DisplayData(System.Data.DataTable table)
  {
    foreach (System.Data.DataRow row in table.Rows)
    {
      foreach (System.Data.DataColumn col in table.Columns)
      {
        Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
      }
      Console.WriteLine("============================");
    }
  }
}
```

## See also

- [SQL Server and ADO.NET](index.md)
- [ADO.NET Overview](../ado-net-overview.md)
