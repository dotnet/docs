---
title: "Oracle REF CURSORs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c6b25b8b-0bdd-41b2-9c7c-661f070c2247
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Oracle REF CURSORs
The .NET Framework Data Provider for Oracle supports the Oracle **REF CURSOR** data type. When using the data provider to work with Oracle REF CURSORs, you should consider the following behaviors.  
  
> [!NOTE]
>  Some behaviors differ from those of the Microsoft OLE DB Provider for Oracle (MSDAORA).  
  
-   For performance reasons, the Data Provider for Oracle does not automatically bind **REF CURSOR** data types, as MSDAORA does, unless you explicitly specify them.  
  
-   The data provider does not support any ODBC escape sequences, including the {resultset} escape used to specify REF CURSOR parameters.  
  
-   To execute a stored procedure that returns REF CURSORs, you must define the parameters in the <xref:System.Data.OracleClient.OracleParameterCollection> with an <xref:System.Data.OracleClient.OracleType> of **Cursor** and a <xref:System.Data.OracleClient.OracleParameter.Direction%2A> of **Output**. The data provider supports binding REF CURSORs as output parameters only. The provider does not support REF CURSORs as input parameters.  
  
-   Obtaining an <xref:System.Data.OracleClient.OracleDataReader> from the parameter value is not supported. The values are of type <xref:System.DBNull> after command execution.  
  
-   The only **CommandBehavior** enumeration value that works with REF CURSORs (for example, when calling <xref:System.Data.OracleClient.OracleCommand.ExecuteReader%2A>) is **CloseConnection**; all others are ignored.  
  
-   The order of REF CURSORs in the **OracleDataReader** depends on the order of the parameters in the **OracleParameterCollection**. The <xref:System.Data.OracleClient.OracleParameter.ParameterName%2A> property is ignored.  
  
-   The PL/SQL **TABLE** data type is not supported. However, REF CURSORs are more efficient. If you must use a **TABLE** data type, use the OLE DB .NET Data Provider with MSDAORA.  
  
## In This Section  
 [REF CURSOR Examples](../../../../docs/framework/data/adonet/ref-cursor-examples.md)  
 Contains three examples that demonstrate using REF CURSORs.  
  
 [REF CURSOR Parameters in an OracleDataReader](../../../../docs/framework/data/adonet/ref-cursor-parameters-in-an-oracledatareader.md)  
 Demonstrates how to execute a PL/SQL stored procedure that returns a REF CURSOR parameter, and reads the value as an **OracleDataReader**.  
  
 [Retrieving Data from Multiple REF CURSORs Using an OracleDataReader](../../../../docs/framework/data/adonet/retrieving-data-from-multiple-ref-cursors.md)  
 Demonstrates how to execute a PL/SQL stored procedure that returns two REF CURSOR parameters, and reads the values using an **OracleDataReader**.  
  
 [Filling a DataSet Using One or More REF CURSORs](../../../../docs/framework/data/adonet/filling-a-dataset-using-one-or-more-ref-cursors.md)  
 Demonstrates how to execute a PL/SQL stored procedure that returns two REF CURSOR parameters, and fills a <xref:System.Data.DataSet> with the rows that are returned.  
  
## See Also  
 [Oracle and ADO.NET](../../../../docs/framework/data/adonet/oracle-and-adonet.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
