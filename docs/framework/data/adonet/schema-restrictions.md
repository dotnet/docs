---
title: "Schema Restrictions"
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
ms.assetid: 73d2980e-e73c-4987-913a-8ddc93d09144
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Schema Restrictions
The second optional parameter of the **GetSchema** method is the restrictions that are used to limit the amount of schema information returned, and it is passed to the **GetSchema** method as an array of strings. The position in the array determines the values that you can pass, and this is equivalent to the restriction number.  
  
 For example, the following table describes the restrictions supported by the "Tables" schema collection using the .NET Framework Data Provider for SQL Server. Additional restrictions for SQL Server schema collections are listed at the end of this topic.  
  
|Restriction Name|Parameter Name|Restriction Default|Restriction Number|  
|----------------------|--------------------|-------------------------|------------------------|  
|Catalog|@Catalog|TABLE_CATALOG|1|  
|Owner|@Owner|TABLE_SCHEMA|2|  
|Table|@Name|TABLE_NAME|3|  
|TableType|@TableType|TABLE_TYPE|4|  
  
## Specifying Restriction Values  
 To use one of the restrictions of the "Tables" schema collection, simply create an array of strings with four elements, then place a value in the element that matches the restriction number. For example, to restrict the tables returned by the **GetSchema** method to only those tables in the "Sales" schema, set the second element of the array to "Sales" before passing it to the **GetSchema** method.  
  
> [!NOTE]
>  The restrictions collections for `SqlClient` and `OracleClient` have an additional `ParameterName` column. The restriction default column is still there for backwards compatibility, but is currently ignored. Parameterized queries rather than string replacement should be used to minimize the risk of an SQL injection attack when specifying restriction values.  
  
> [!NOTE]
>  The number of elements in the array must be less than or equal to the number of restrictions supported for the specified schema collection else an <xref:System.ArgumentException> will be thrown. There can be fewer than the maximum number of restrictions. The missing restrictions are assumed to be null (unrestricted).  
  
 You can query a .NET Framework managed provider to determine the list of supported restrictions by calling the **GetSchema** method with the name of the restrictions schema collection, which is "Restrictions". This will return a <xref:System.Data.DataTable> with a list of the collection names, the restriction names, the default restriction values, and the restriction numbers.  
  
### Example  
 The following examples demonstrate how to use the <xref:System.Data.SqlClient.SqlConnection.GetSchema%2A> method of the .NET Framework Data Provider for the SQL Server <xref:System.Data.SqlClient.SqlConnection> class to retrieve schema information about all of the tables contained in the **AdventureWorks** sample database, and to restrict the information returned to only those tables in the "Sales" schema:  
  
```vb  
Imports System.Data.SqlClient  
  
Module Module1  
Sub Main()  
  Dim connectionString As String = _  
    "Data Source=(local);Database=AdventureWorks;" & _  
       "Integrated Security=true;";  
  
  Dim restrictions(3) As String  
  Using connection As New SqlConnection(connectionString)  
    connection.Open()  
  
    'Specify the restrictions.  
    restrictions(1) = "Sales"  
    Dim table As DataTable = connection.GetSchema("Tables", _  
       restrictions)  
  
    ' Display the contents of the table.  
      For Each row As DataRow In table.Rows  
         For Each col As DataColumn In table.Columns  
            Console.WriteLine("{0} = {1}", col.ColumnName, row(col))  
         Next  
         Console.WriteLine("============================")  
      Next  
    Console.WriteLine("Press any key to continue.")  
    Console.ReadKey()  
  End Using  
End Sub  
End Module  
```  
  
```csharp  
using System;  
using System.Data;  
using System.Data.SqlClient;  
  
class Program  
{  
  static void Main()  
  {  
    string connectionString =   
       "Data Source=(local);Database=AdventureWorks;" +  
       "Integrated Security=true;";  
    using (SqlConnection connection =  
       new SqlConnection(connectionString))  
    {  
        connection.Open();  
  
        // Specify the restrictions.  
        string[] restrictions = new string[4];  
        restrictions[1] = "Sales";  
        System.Data.DataTable table = connection.GetSchema(  
          "Tables", restrictions);  
  
        // Display the contents of the table.  
        foreach (System.Data.DataRow row in table.Rows)  
        {  
            foreach (System.Data.DataColumn col in table.Columns)  
            {  
                Console.WriteLine("{0} = {1}",   
                  col.ColumnName, row[col]);  
            }  
            Console.WriteLine("============================");  
        }  
        Console.WriteLine("Press any key to continue.");  
        Console.ReadKey();  
    }  
  }  
  
  private static string GetConnectionString()  
  {  
     // To avoid storing the connection string in your code,  
     // you can retrieve it from a configuration file.  
     return "Data Source=(local);Database=AdventureWorks;" +  
        "Integrated Security=true;";  
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
  
## SQL Server Schema Restrictions  
 The following tables list the restrictions for SQL Server schema collections.  
  
### Users  
  
|Restriction Name|Parameter Name|Restriction Default|Restriction Number|  
|----------------------|--------------------|-------------------------|------------------------|  
|User_Name|@Name|name|1|  
  
### Databases  
  
|Restriction Name|Parameter Name|Restriction Default|Restriction Number|  
|----------------------|--------------------|-------------------------|------------------------|  
|Name|@Name|Name|1|  
  
### Tables  
  
|Restriction Name|Parameter Name|Restriction Default|Restriction Number|  
|----------------------|--------------------|-------------------------|------------------------|  
|Catalog|@Catalog|TABLE_CATALOG|1|  
|Owner|@Owner|TABLE_SCHEMA|2|  
|Table|@Name|TABLE_NAME|3|  
|TableType|@TableType|TABLE_TYPE|4|  
  
### Columns  
  
|Restriction Name|Parameter Name|Restriction Default|Restriction Number|  
|----------------------|--------------------|-------------------------|------------------------|  
|Catalog|@Catalog|TABLE_CATALOG|1|  
|Owner|@Owner|TABLE_SCHEMA|2|  
|Table|@Table|TABLE_NAME|3|  
|Column|@Column|COLUMN_NAME|4|  
  
### StructuredTypeMembers  
  
|Restriction Name|Parameter Name|Restriction Default|Restriction Number|  
|----------------------|--------------------|-------------------------|------------------------|  
|Catalog|@Catalog|TABLE_CATALOG|1|  
|Owner|@Owner|TABLE_SCHEMA|2|  
|Table|@Table|TABLE_NAME|3|  
|Column|@Column|COLUMN_NAME|4|  
  
### Views  
  
|Restriction Name|Parameter Name|Restriction Default|Restriction Number|  
|----------------------|--------------------|-------------------------|------------------------|  
|Catalog|@Catalog|TABLE_CATALOG|1|  
|Owner|@Owner|TABLE_SCHEMA|2|  
|Table|@Table|TABLE_NAME|3|  
  
### ViewColumns  
  
|Restriction Name|Parameter Name|Restriction Default|Restriction Number|  
|----------------------|--------------------|-------------------------|------------------------|  
|Catalog|@Catalog|VIEW_CATALOG|1|  
|Owner|@Owner|VIEW_SCHEMA|2|  
|Table|@Table|VIEW_NAME|3|  
|Column|@Column|COLUMN_NAME|4|  
  
### ProcedureParameters  
  
|Restriction Name|Parameter Name|Restriction Default|Restriction Number|  
|----------------------|--------------------|-------------------------|------------------------|  
|Catalog|@Catalog|SPECIFIC_CATALOG|1|  
|Owner|@Owner|SPECIFIC_SCHEMA|2|  
|Name|@Name|SPECIFIC_NAME|3|  
|Parameter|@Parameter|PARAMETER_NAME|4|  
  
### Procedures  
  
|Restriction Name|Parameter Name|Restriction Default|Restriction Number|  
|----------------------|--------------------|-------------------------|------------------------|  
|Catalog|@Catalog|SPECIFIC_CATALOG|1|  
|Owner|@Owner|SPECIFIC_SCHEMA|2|  
|Name|@Name|SPECIFIC_NAME|3|  
|Type|@Type|ROUTINE_TYPE|4|  
  
### IndexColumns  
  
|Restriction Name|Parameter Name|Restriction Default|Restriction Number|  
|----------------------|--------------------|-------------------------|------------------------|  
|Catalog|@Catalog|db_name()|1|  
|Owner|@Owner|user_name()|2|  
|Table|@Table|o.name|3|  
|ConstraintName|@ConstraintName|x.name|4|  
|Column|@Column|c.name|5|  
  
### Indexes  
  
|Restriction Name|Parameter Name|Restriction Default|Restriction Number|  
|----------------------|--------------------|-------------------------|------------------------|  
|Catalog|@Catalog|db_name()|1|  
|Owner|@Owner|user_name()|2|  
|Table|@Table|o.name|3|  
  
### UserDefinedTypes  
  
|Restriction Name|Parameter Name|Restriction Default|Restriction Number|  
|----------------------|--------------------|-------------------------|------------------------|  
|assembly_name|@AssemblyName|assemblies.name|1|  
|udt_name|@UDTName|types.assembly_class|2|  
  
### ForeignKeys  
  
|Restriction Name|Parameter Name|Restriction Default|Restriction Number|  
|----------------------|--------------------|-------------------------|------------------------|  
|Catalog|@Catalog|CONSTRAINT_CATALOG|1|  
|Owner|@Owner|CONSTRAINT_SCHEMA|2|  
|Table|@Table|TABLE_NAME|3|  
|Name|@Name|CONSTRAINT_NAME|4|  
  
## SQL Server 2008 Schema Restrictions  
 The following tables list the restrictions for SQL Server 2008 schema collections. These restrictions are valid beginning with version 3.5 SP1 of the .NET Framework and SQL Server 2008. They are not supported in earlier versions of the .NET Framework and SQL Server.  
  
### ColumnSetColumns  
  
|Restriction Name|Parameter Name|Restriction Default|Restriction Number|  
|----------------------|--------------------|-------------------------|------------------------|  
|Catalog|@Catalog|TABLE_CATALOG|1|  
|Owner|@Owner|TABLE_SCHEMA|2|  
|Table|@Table|TABLE_NAME|3|  
  
### AllColumns  
  
|Restriction Name|Parameter Name|Restriction Default|Restriction Number|  
|----------------------|--------------------|-------------------------|------------------------|  
|Catalog|@Catalog|TABLE_CATALOG|1|  
|Owner|@Owner|TABLE_SCHEMA|2|  
|Table|@Table|TABLE_NAME|3|  
|Column|@Column|COLUMN_NAME|4|  
  
## See Also  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
