---
description: "Learn more about: REF CURSOR Examples"
title: "REF CURSOR Examples"
ms.date: "03/30/2017"
ms.assetid: c257da03-c6c9-4cf8-b591-b7740a962c40
---
# REF CURSOR Examples

The REF CURSOR examples are comprised of the following three Microsoft Visual Basic examples that demonstrate using REF CURSORs.  
  
|Sample|Description|  
|------------|-----------------|  
|[REF CURSOR Parameters in an OracleDataReader](ref-cursor-parameters-in-an-oracledatareader.md)|This example executes a PL/SQL stored procedure that returns a REF CURSOR parameter, and reads the value as an <xref:System.Data.OracleClient.OracleDataReader>.|  
|[Retrieving Data from Multiple REF CURSORs Using an OracleDataReader](retrieving-data-from-multiple-ref-cursors.md)|This example executes a PL/SQL stored procedure that returns two REF CURSOR parameters, and reads the values using an **OracleDataReader**.|  
|[Filling a DataSet Using One or More REF CURSORs](filling-a-dataset-using-one-or-more-ref-cursors.md)|This example executes a PL/SQL stored procedure that returns two REF CURSOR parameters, and fills a <xref:System.Data.DataSet> with the rows that are returned.|  
  
 To use these examples, you may need to create the Oracle tables, and you must create a PL/SQL package and package body.  
  
## Creating the Oracle Tables  

 These examples use tables that are defined in the Oracle Scott/Tiger schema. The Oracle Scott/Tiger schema is included with most Oracle installations. If this schema does not exist, you can use the SQL commands file in {OracleHome}\rdbms\admin\scott.sql to create the tables and indexes used by these examples.  
  
## Creating the Oracle Package and Package Body  

 These examples require the following PL/SQL package and package body on your server. Create the following Oracle package on the Oracle server.  
  
```sql
CREATE OR REPLACE PACKAGE CURSPKG AS
    TYPE T_CURSOR IS REF CURSOR;
    PROCEDURE OPEN_ONE_CURSOR (N_EMPNO IN NUMBER,
                               IO_CURSOR IN OUT T_CURSOR);
    PROCEDURE OPEN_TWO_CURSORS (EMPCURSOR OUT T_CURSOR,
                                DEPTCURSOR OUT T_CURSOR);  
END CURSPKG;  
/
```  
  
 Create the following Oracle package body on the Oracle server.  
  
```sql
CREATE OR REPLACE PACKAGE BODY CURSPKG AS  
    PROCEDURE OPEN_ONE_CURSOR (N_EMPNO IN NUMBER,  
                               IO_CURSOR IN OUT T_CURSOR)  
    IS
        V_CURSOR T_CURSOR;
    BEGIN
        IF N_EMPNO <> 0
        THEN  
             OPEN V_CURSOR FOR
             SELECT EMP.EMPNO, EMP.ENAME, DEPT.DEPTNO, DEPT.DNAME
                  FROM EMP, DEPT
                  WHERE EMP.DEPTNO = DEPT.DEPTNO
                  AND EMP.EMPNO = N_EMPNO;  
  
        ELSE
             OPEN V_CURSOR FOR
             SELECT EMP.EMPNO, EMP.ENAME, DEPT.DEPTNO, DEPT.DNAME
                  FROM EMP, DEPT
                  WHERE EMP.DEPTNO = DEPT.DEPTNO;  
  
        END IF;  
        IO_CURSOR := V_CURSOR;
    END OPEN_ONE_CURSOR;
  
    PROCEDURE OPEN_TWO_CURSORS (EMPCURSOR OUT T_CURSOR,  
                                DEPTCURSOR OUT T_CURSOR)  
    IS
        V_CURSOR1 T_CURSOR;
        V_CURSOR2 T_CURSOR;
    BEGIN
        OPEN V_CURSOR1 FOR SELECT * FROM EMP;  
        OPEN V_CURSOR2 FOR SELECT * FROM DEPT;  
        EMPCURSOR  := V_CURSOR1;
        DEPTCURSOR := V_CURSOR2;
    END OPEN_TWO_CURSORS;
END CURSPKG;  
/  
```  
  
## See also

- [Oracle REF CURSORs](oracle-ref-cursors.md)
- [ADO.NET Overview](ado-net-overview.md)
