---
description: "Learn more about: How to: Display LINQ to SQL Commands"
title: "How to: Display LINQ to SQL Commands"
ms.date: "10/19/2026"
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 1decb05e-37ad-4ed6-ab2f-071eb4c4f628
---
# How to: Display LINQ to SQL Commands

> [!IMPORTANT]
> Do not use `System.Data.SqlClient` for new development. Use [Microsoft.Data.SqlClient](/sql/connect/ado-net/introduction-microsoft-data-sqlclient-namespace) for new SQL Server data-access code. These examples retain `System.Data.SqlClient` because .NET Framework's built-in LINQ to SQL provider requires it. Changing the connection type alone doesn't migrate LINQ to SQL.

Use <xref:System.Data.Linq.DataContext.GetCommand*> to display SQL commands and other information.

## Example

 In the following example, the console window displays the output from the query, followed by the SQL commands that are generated, the type of commands, and the type of connection.

 [!code-csharp[DLinqDebuggingSupport#3](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqDebuggingSupport/cs/Program.cs#3)]
 [!code-vb[DLinqDebuggingSupport#3](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqDebuggingSupport/vb/Module1.vb#3)]

 Output appears as follows:

```console
Customers from London:
    Thomas Hardy
    Victoria Ashworth
    Elizabeth Brown
    Ann Devon
    Simon Crowther
    Marie Bertrand
    Hari Kumar
    Dominique Perrier
```

```console
Command Text:
SELECT [t0].[CustomerID], [t0].[CompanyName], [t0].[ContactName], [t0].[ContactT
itle], [t0].[Address], [t0].[City], [t0].[Region], [t0].[PostalCode], [t0].[Coun
try], [t0].[Phone], [t0].[Fax]
FROM [dbo].[Customers] AS [t0]
WHERE [t0].[City] = @p0

Command Type: Text

Connection: System.Data.SqlClient.SqlConnection
```

## See also

- [Debugging Support](debugging-support.md)
