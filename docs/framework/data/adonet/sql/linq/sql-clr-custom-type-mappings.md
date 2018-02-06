---
title: "SQL-CLR Custom Type Mappings"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d916c7fb-4b56-4214-acbe-5e23365047b2
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# SQL-CLR Custom Type Mappings
Type mapping between SQL Server and the common language runtime (CLR) is automatically specified when you use the SQLMetal command-line tool, Object Relational Designer (O/R Designer).  
  
 When no customized mapping is performed, these tools assign default type mappings as described in [SQL-CLR Type Mapping](../../../../../../docs/framework/data/adonet/sql/linq/sql-clr-type-mapping.md). If you want to type mappings differently from these defaults, you need to do some customization of the type mappings.  
  
 When customizing type mappings, the recommended approach is to make the changes in an intermediary DBML file. Then, your customized DBML file should be used when you create you code and mapping files with SQLMetal or O/R Designer.  
  
 Once you instantiate the <xref:System.Data.Linq.DataContext> object from the code and mapping files, the <xref:System.Data.Linq.DataContext.CreateDatabase%2A?displayProperty=nameWithType> method creates a database based on the type mappings that are specified. If there are no CLR `type` attributes specified in the mappings, the default type mappings will be used.  
  
## Customization with SQLMetal or O/R Designer  
 With SQLMetal and O/R Designer, you can automatically create an object model that includes the type mapping information inside or outside the code file. Because these files are overwritten by SQLMetal or O/R Designer, each time you recreate your mappings, the recommended approach to specifying custom type mappings is to customize a DBML file.  
  
 To customize type mappings with SQLMetal or O/R Designer, first generate a DBML file. Then, before generating the code file or mapping file, modify the DBML file to identify the desired type mappings. With SQLMetal, you have to manually change the `Type` and `DbType` attributes in the DBML file to make your type mapping customizations. With O/R Designer, you can make your changes within the Designer. For more information about using the O/R Designer, see [LINQ to SQL Tools in Visual Studio](/visualstudio/data-tools/linq-to-sql-tools-in-visual-studio2).  
  
> [!NOTE]
>  Some type mappings may result in overflow or data loss exceptions while translating to or from the database. Carefully review the Type Mapping Run-time Behavior Matrix in [SQL-CLR Type Mapping](../../../../../../docs/framework/data/adonet/sql/linq/sql-clr-type-mapping.md) before making any customizations.  
  
 In order for your type mapping customizations to be recognized by SQLMetal or O/R Designer, you need to make sure that these tools are supplied with the path to your custom DBML file when you generate your code file or external mapping file. Although not required for type mapping customization, it is recommended that you always separate your type mapping information from your code file and generate the additional external type mapping file. Doing so will leave some flexibility by not requiring that the code file be recompiled.  
  
## Incorporating Database Changes  
 When your database changes, you will need to update your DBML file to reflect those changes. One way to do this is to automatically create a new DBML file and then re-do your type mapping customizations. Alternatively, you could compare the differences between your new DBML file and your customized DBML file and update your custom DBML file manually to reflect the database change.  
  
## See Also  
 [SQL-CLR Type Mapping](../../../../../../docs/framework/data/adonet/sql/linq/sql-clr-type-mapping.md)  
 [Code Generation in LINQ to SQL](../../../../../../docs/framework/data/adonet/sql/linq/code-generation-in-linq-to-sql.md)
