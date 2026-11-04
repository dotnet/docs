---
description: "Learn more about: SQL XML Column Values"
title: "SQL XML Column Values"
ms.date: "10/23/2026"
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: d97ce4da-f09c-4d1e-85b7-a0ccedd7246a
---
# SQL XML Column Values

SQL Server supports the `xml` data type. Use the <xref:Microsoft.Data.SqlClient.SqlCommand> class to retrieve result sets that include this type. You can retrieve `xml` columns through the <xref:Microsoft.Data.SqlClient.SqlDataReader> like other columns. To work with their contents as XML, use the <xref:System.Xml.XmlReader>.

## Example

The following console application selects two rows, each with an `xml` column, from `Sales.Store` in the `AdventureWorks` database. For each row, the code calls <xref:Microsoft.Data.SqlClient.SqlDataReader.GetSqlXml*> and uses <xref:System.Data.SqlTypes.SqlXml.CreateReader> to create the <xref:System.Xml.XmlReader>. To retain the value as <xref:System.Data.SqlTypes.SqlXml> instead, use the value returned by `GetSqlXml` directly. The <xref:System.Data.IDataRecord.GetValue*> method returns the `xml` column value as a string.

> [!NOTE]
> The `AdventureWorks` sample database is not installed by default when you install SQL Server. You can install it by running SQL Server Setup.

 [!code-csharp[DataWorks SqlClient.GetXmlDataReader#1](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SqlClient.GetXmlDataReader/CS/source.cs#1)]
 [!code-vb[DataWorks SqlClient.GetXmlDataReader#1](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SqlClient.GetXmlDataReader/VB/source.vb#1)]

## See also

- <xref:System.Data.SqlTypes.SqlXml>
- [XML Data in SQL Server](xml-data-in-sql-server.md)
- [ADO.NET Overview](../ado-net-overview.md)
