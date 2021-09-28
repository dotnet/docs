---
description: "Learn more about: Generic Field and SetField Methods (LINQ to DataSet)"
title: "Generic Field and SetField Methods (LINQ to DataSet)"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 1883365f-9d6c-4ccb-9187-df309f47706d
---
# Generic Field and SetField Methods (LINQ to DataSet)

LINQ to DataSet provides extension methods to the <xref:System.Data.DataRow> class for accessing column values: the <xref:System.Data.DataRowExtensions.Field%2A> method and the <xref:System.Data.DataRowExtensions.SetField%2A> method. These methods provide easier access to column values for developers, especially regarding null values. The <xref:System.Data.DataSet> uses <xref:System.DBNull.Value?displayProperty=nameWithType> to represent null values, whereas LINQ uses the <xref:System.Nullable> and <xref:System.Nullable%601> types. Using the pre-existing column accessor in <xref:System.Data.DataRow> requires you to cast the return object to the appropriate type. If a particular field in a <xref:System.Data.DataRow> can be null, you must explicitly check for a null value because returning <xref:System.DBNull.Value?displayProperty=nameWithType> and implicitly casting it to another type throws an <xref:System.InvalidCastException>. In the following example, if the <xref:System.Data.DataRow.IsNull%2A?displayProperty=nameWithType> method was not used to check for a null value, an exception would be thrown if the indexer returned <xref:System.DBNull.Value?displayProperty=nameWithType> and tried to cast it to a <xref:System.String>.  
  
 [!code-csharp[DP LINQ to DataSet Examples#WhereIsNull](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/CS/Program.cs#whereisnull)]
 [!code-vb[DP LINQ to DataSet Examples#WhereIsNull](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/VB/Module1.vb#whereisnull)]  
  
 The <xref:System.Data.DataRowExtensions.Field%2A> method provides access to the column values of a <xref:System.Data.DataRow> and the <xref:System.Data.DataRowExtensions.SetField%2A> sets column values in a <xref:System.Data.DataRow>. Both the <xref:System.Data.DataRowExtensions.Field%2A> method and <xref:System.Data.DataRowExtensions.SetField%2A> method handle nullable value types, so you do not have to explicitly check for null values as in the previous example. Both methods are generic methods, also, so you do not have to cast the return type.  
  
 The following example uses the <xref:System.Data.DataRowExtensions.Field%2A> method.  
  
 [!code-csharp[DP LINQ to DataSet Examples#Where3](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/CS/Program.cs#where3)]
 [!code-vb[DP LINQ to DataSet Examples#Where3](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/VB/Module1.vb#where3)]  
  
 Note that the data type specified in the generic parameter `T` of the <xref:System.Data.DataRowExtensions.Field%2A> method and the <xref:System.Data.DataRowExtensions.SetField%2A> method must match the type of the underlying value. Otherwise, an <xref:System.InvalidCastException> exception will be thrown. The specified column name must also match the name of a column in the <xref:System.Data.DataSet>, or an <xref:System.ArgumentException> will be thrown. In both cases, the exception is thrown at run time during the enumeration of the data when the query is executed.  
  
 The <xref:System.Data.DataRowExtensions.SetField%2A> method itself does not perform any type conversions. This does not mean, however, that a type conversion will not occur. The <xref:System.Data.DataRowExtensions.SetField%2A> method exposes the ADO.NET behavior of the <xref:System.Data.DataRow> class. A type conversion could be performed by the <xref:System.Data.DataRow> object and the converted value would then be saved to the <xref:System.Data.DataRow> object.  
  
## See also

- <xref:System.Data.DataRowExtensions>
