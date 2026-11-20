---
title: "Code Examples"
description: "Retrieve data with ADO.NET data providers, including Microsoft.Data.SqlClient for SQL Server, and explore .NET Framework Entity Framework examples."
ms.date: "10/19/2026"
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: c119657a-9ce6-4940-91e4-ac1d5f0d9584
---
# ADO.NET code examples

The code listings on this page demonstrate how to retrieve data from a database by using the following ADO.NET technologies:

- ADO.NET data providers:

  - [SqlClient](#sqlclient) (`Microsoft.Data.SqlClient`)

  - [OleDb](#oledb) (`System.Data.OleDb`)

  - [Odbc](#odbc) (`System.Data.Odbc`)

  - [OracleClient](#oracleclient) (`System.Data.OracleClient`)

- ADO.NET Entity Framework:

  - [LINQ to Entities](#linq-to-entities)

  - [Typed ObjectQuery](#typed-objectquery)

  - [EntityClient](#entityclient) (`System.Data.EntityClient`)

- [LINQ to SQL](#linq-to-sql)

## ADO.NET data provider examples

The following code listings demonstrate how to retrieve data from a database using ADO.NET data providers. The data is returned in a `DataReader`. For more information, see [Retrieving Data Using a DataReader](retrieving-data-using-a-datareader.md).

### SqlClient

To access SQL Server with ADO.NET, use the [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) NuGet package. The following C# and Visual Basic projects target .NET 10 and .NET Framework 4.8.1 and reference this package. Use the .NET 10 SDK to build the projects.

The examples query the `dbo.Products` table in the `Northwind` sample database. The <xref:Microsoft.Data.SqlClient.SqlCommand> selects products with `UnitPrice` greater than 5. The <xref:Microsoft.Data.SqlClient.SqlParameter> specifies the price as <xref:System.Data.SqlDbType.Money>. The <xref:Microsoft.Data.SqlClient.SqlDataReader> reads the product ID, unit price, and product name in descending order of unit price. The `using` blocks (`Using` in Visual Basic) dispose of the reader, command, and <xref:Microsoft.Data.SqlClient.SqlConnection>.

Before you run either project, set the `SQL_CONNECTION_STRING` environment variable in the process that launches the example. For example, on Windows with integrated authentication, use the following PowerShell command. Replace `<server>` with your server name and configure the server with a certificate that the client trusts.

```powershell
$env:SQL_CONNECTION_STRING = 'Server=<server>;Database=Northwind;Integrated Security=true;Encrypt=true;TrustServerCertificate=false'
```

For other authentication options, see [Connection string syntax](/sql/connect/ado-net/connection-string-syntax).

[!INCLUDE [managed-identities](../../../includes/managed-identities.md)]

To use the driver's Microsoft Entra ID authentication modes, including managed identity, also install the `Microsoft.Data.SqlClient.Extensions.Azure` NuGet package. For setup instructions, see [Microsoft Entra ID authentication](/sql/connect/ado-net/sql/azure-active-directory-authentication).

:::code language="csharp" source="./snippets/ado-net-code-examples/csharp/Program.cs" id="SqlClient":::
:::code language="vb" source="./snippets/ado-net-code-examples/vb/Program.vb" id="SqlClient":::

From either snippet project directory, run `dotnet run --framework net10.0`. On Windows with .NET Framework 4.8.1 installed, use `dotnet run --framework net481`.

### OleDb

The code in this example assumes that you can connect to the Microsoft Access Northwind sample database. The code creates a <xref:System.Data.OleDb.OleDbCommand> to select rows from the Products table, adding a <xref:System.Data.OleDb.OleDbParameter> to restrict the results to rows with a UnitPrice greater than the specified parameter value, in this case 5. The <xref:System.Data.OleDb.OleDbConnection> is opened inside of a `using` block, which ensures that resources are closed and disposed when the code exits. The code executes the command by using a <xref:System.Data.OleDb.OleDbDataReader>, and displays the results in the console window.

 [!code-csharp[DataWorks SampleApp.OleDb#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SampleApp.OleDb/CS/source.cs#1)]
 [!code-vb[DataWorks SampleApp.OleDb#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SampleApp.OleDb/VB/source.vb#1)]

### Odbc

The code in this example assumes that you can connect to the Microsoft Access Northwind sample database. The code creates a <xref:System.Data.Odbc.OdbcCommand> to select rows from the Products table, adding a <xref:System.Data.Odbc.OdbcParameter> to restrict the results to rows with a UnitPrice greater than the specified parameter value, in this case 5. The <xref:System.Data.Odbc.OdbcConnection> is opened inside a `using` block, which ensures that resources are closed and disposed when the code exits. The code executes the command by using a <xref:System.Data.Odbc.OdbcDataReader>, and displays the results in the console window.

[!code-csharp[DataWorks SampleApp.Odbc#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SampleApp.Odbc/CS/source.cs#1)]
[!code-vb[DataWorks SampleApp.Odbc#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SampleApp.Odbc/VB/source.vb#1)]

### OracleClient

The code in this example assumes a connection to DEMO.CUSTOMER on an Oracle server. You must also add a reference to the System.Data.OracleClient.dll. The code returns the data in an <xref:System.Data.OracleClient.OracleDataReader>.

[!INCLUDE [managed-identities](../../../includes/managed-identities.md)]

 [!code-csharp[DataWorks SampleApp.Oracle#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SampleApp.Oracle/CS/source.cs#1)]
 [!code-vb[DataWorks SampleApp.Oracle#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SampleApp.Oracle/VB/source.vb#1)]

## Entity Framework examples

The following code listings demonstrate how to retrieve data from a data source by querying entities in an Entity Data Model (EDM). These examples use a model based on the Northwind sample database. For more information about Entity Framework, see [Entity Framework Overview](./ef/overview.md).

### LINQ to Entities

The code in this example uses a LINQ query to return data as Categories objects, which are projected as an anonymous type that contains only the CategoryID and CategoryName properties. For more information, see [LINQ to Entities Overview](./ef/language-reference/linq-to-entities.md).

```csharp
using System;
using System.Linq;
using System.Data.Objects;
using NorthwindModel;

class LinqSample
{
    public static void ExecuteQuery()
    {
        using (NorthwindEntities context = new NorthwindEntities())
        {
            try
            {
                var query = from category in context.Categories
                            select new
                            {
                                categoryID = category.CategoryID,
                                categoryName = category.CategoryName
                            };

                foreach (var categoryInfo in query)
                {
                    Console.WriteLine("\t{0}\t{1}",
                        categoryInfo.categoryID, categoryInfo.categoryName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
```

```vb
Option Explicit On
Option Strict On

Imports System.Linq
Imports System.Data.Objects
Imports NorthwindModel

Class LinqSample
    Public Shared Sub ExecuteQuery()
        Using context As NorthwindEntities = New NorthwindEntities()
            Try
                Dim query = From category In context.Categories _
                            Select New With _
                            { _
                                .categoryID = category.CategoryID, _
                                .categoryName = category.CategoryName _
                            }

                For Each categoryInfo In query
                    Console.WriteLine(vbTab & "{0}" & vbTab & "{1}", _
                        categoryInfo.categoryID, categoryInfo.categoryName)
                Next
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Using
    End Sub
End Class
```

### Typed ObjectQuery

The code in this example uses an <xref:System.Data.Objects.ObjectQuery`1> to return data as Categories objects. For more information, see [Object Queries](/previous-versions/dotnet/netframework-4.0/bb896241(v=vs.100)).

```csharp
using System;
using System.Data.Objects;
using NorthwindModel;

class ObjectQuerySample
{
    public static void ExecuteQuery()
    {
        using (NorthwindEntities context = new NorthwindEntities())
        {
            ObjectQuery<Categories> categoryQuery = context.Categories;

            foreach (Categories category in
                categoryQuery.Execute(MergeOption.AppendOnly))
            {
                Console.WriteLine("\t{0}\t{1}",
                    category.CategoryID, category.CategoryName);
            }
        }
    }
}
```

```vb
Option Explicit On
Option Strict On

Imports System.Data.Objects
Imports NorthwindModel

Class ObjectQuerySample
    Public Shared Sub ExecuteQuery()
        Using context As NorthwindEntities = New NorthwindEntities()
            Dim categoryQuery As ObjectQuery(Of Categories) = context.Categories

            For Each category As Categories In _
                categoryQuery.Execute(MergeOption.AppendOnly)
                Console.WriteLine(vbTab & "{0}" & vbTab & "{1}", _
                    category.CategoryID, category.CategoryName)
            Next
        End Using
    End Sub
End Class
```

### EntityClient

The code in this example uses an <xref:System.Data.EntityClient.EntityCommand> to execute an Entity SQL query. This query returns a list of records that represent instances of the Categories entity type. An <xref:System.Data.EntityClient.EntityDataReader> is used to access data records in the result set. For more information, see [EntityClient Provider for the Entity Framework](./ef/entityclient-provider-for-the-entity-framework.md).

```csharp
using System;
using System.Data;
using System.Data.Common;
using System.Data.EntityClient;
using NorthwindModel;

class EntityClientSample
{
    public static void ExecuteQuery()
    {
        string queryString =
            @"SELECT c.CategoryID, c.CategoryName
                FROM NorthwindEntities.Categories AS c";

        using (EntityConnection conn =
            new EntityConnection("name=NorthwindEntities"))
        {
            try
            {
                conn.Open();
                using (EntityCommand query = new EntityCommand(queryString, conn))
                {
                    using (DbDataReader rdr =
                        query.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("\t{0}\t{1}", rdr[0], rdr[1]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
```

```vb
Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.Common
Imports System.Data.EntityClient
Imports NorthwindModel

Class EntityClientSample
    Public Shared Sub ExecuteQuery()
        Dim queryString As String = _
            "SELECT c.CategoryID, c.CategoryName " & _
                "FROM NorthwindEntities.Categories AS c"

        Using conn As EntityConnection = _
            New EntityConnection("name=NorthwindEntities")

            Try
                conn.Open()
                Using query As EntityCommand = _
                New EntityCommand(queryString, conn)
                    Using rdr As DbDataReader = _
                        query.ExecuteReader(CommandBehavior.SequentialAccess)
                        While rdr.Read()
                            Console.WriteLine(vbTab & "{0}" & vbTab & "{1}", _
                                              rdr(0), rdr(1))
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Using
    End Sub
End Class
```

## LINQ to SQL

The code in this example uses a LINQ query to return data as Categories objects, which are projected as an anonymous type that contains only the CategoryID and CategoryName properties. This example is based on the Northwind data context. For more information, see [Getting Started](./sql/linq/getting-started.md).

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind;

    class LinqSqlSample
    {
        public static void ExecuteQuery()
        {
            using (NorthwindDataContext db = new NorthwindDataContext())
            {
                try
                {
                    var query = from category in db.Categories
                                select new
                                {
                                    categoryID = category.CategoryID,
                                    categoryName = category.CategoryName
                                };

                    foreach (var categoryInfo in query)
                    {
                        Console.WriteLine("vbTab {0} vbTab {1}",
                            categoryInfo.categoryID, categoryInfo.categoryName);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
```

```vb
Option Explicit On
Option Strict On

Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Northwind

Class LinqSqlSample
    Public Shared Sub ExecuteQuery()
        Using db As NorthwindDataContext = New NorthwindDataContext()
            Try
                Dim query = From category In db.Categories _
                                Select New With _
                                { _
                                    .categoryID = category.CategoryID, _
                                    .categoryName = category.CategoryName _
                                }

                For Each categoryInfo In query
                    Console.WriteLine(vbTab & "{0}" & vbTab & "{1}", _
                            categoryInfo.categoryID, categoryInfo.categoryName)
                Next
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            End Using
    End Sub
End Class
```

## See also

- [ADO.NET Overview](ado-net-overview.md)
- [Retrieving and Modifying Data in ADO.NET](retrieving-and-modifying-data.md)
- [Creating Data Applications](/previous-versions/visualstudio/visual-studio-2013/h0y4a0f6(v=vs.120))
- [Querying an Entity Data Model (Entity Framework Tasks)](/previous-versions/bb738455(v=vs.90))
- [How to: Execute a Query that Returns Anonymous Type Objects](/previous-versions/dotnet/netframework-4.0/bb738512(v=vs.100))
