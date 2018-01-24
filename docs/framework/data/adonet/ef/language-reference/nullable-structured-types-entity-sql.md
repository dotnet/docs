---
title: "Nullable Structured Types (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ae006fa9-997e-45bb-8a04-a7f62026171e
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Nullable Structured Types (Entity SQL)
A `null` instance of a structured type is an instance that does not exist. This is different from an existing instance in which all properties have `null` values.  
  
 This topic describes the nullable structured types, including which types are nullable and which code patterns produce `null` instances of structured nullable types.  
  
## Kinds of Nullable Structured Types  
 There are three kinds of nullable structure types:  
  
-   Row types.  
  
-   Complex types.  
  
-   Entity types.  
  
## Code Patterns that Produce Null Instances of Structured Types  
 The following scenarios produce `null` instances:  
  
-   Shaping `null` as a structured type:  
  
    ```  
    TREAT (NULL AS StructuredType)  
    ```  
  
-   Upcasting of a base type to a derived type:  
  
    ```  
    TREAT (BaseType AS DerivedType)  
    ```  
  
-   Outer join on false condition:  
  
    ```  
    Collection1 LEFT OUTER JOIN Collection2  
    ON FalseCondition  
    ```  
  
     --or  
  
    ```  
    Collection1 RIGHT OUTER JOIN Collection2  
    ON FalseCondition  
    ```  
  
     --or  
  
    ```  
    Collection1 FULL OUTER JOIN Collection2  
    ON FalseCondition  
    ```  
  
-   Dereferencing a `null` reference:  
  
    ```  
    DEREF(NullRef)  
    ```  
  
-   Obtaining ANYELEMENT from an empty collection:  
  
    ```  
    ANYELEMENT(EmptyCollection)  
    ```  
  
-   Checking for `null` instances of structured types:  
  
    ```csharp  
    ...  
    for (int i = 0; i < reader.FieldCount; i++)  
    {  
        if (reader.IsDBNull(i))  
        {  
            Console.WriteLine("[NULL]");  
        }  
        else  
        {  
            Console.WriteLine(reader.GetValue(i).ToString());  
        }  
    }  
    ```  
  
## See Also  
 [Entity SQL Overview](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-overview.md)
