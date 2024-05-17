---
description: "Learn more about: How to: Call Model-Defined Functions in Queries"
title: "How to: Call Model-Defined Functions in Queries"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 6c804e4d-f348-4afd-9f63-d3f0f24bc6a9
---
# How to: Call model-defined functions in queries

This topic describes how to call functions that are defined in the conceptual model from within LINQ to Entities queries.

 The procedure below provides a high-level outline for calling a model-defined function from within a LINQ to Entities query. The example that follows provides more detail about the steps in the procedure. The procedure assumes that you have defined a function in the conceptual model. For more information, see [How to: Define Custom Functions in the Conceptual Model](/previous-versions/dotnet/netframework-4.0/dd456812(v=vs.100)).

## To call a function defined in the conceptual model

1. Add a common language runtime (CLR) method to your application that maps to the function defined in the conceptual model. To map the method, you must apply an <xref:System.Data.Objects.DataClasses.EdmFunctionAttribute> to the method. Note that the <xref:System.Data.Objects.DataClasses.EdmFunctionAttribute.NamespaceName%2A> and <xref:System.Data.Objects.DataClasses.EdmFunctionAttribute.FunctionName%2A> parameters of the attribute are the namespace name of the conceptual model and the function name in the conceptual model respectively. Function name resolution for LINQ is case sensitive.

2. Call the function in a LINQ to Entities query.

## Example 1

 The following example demonstrates how to call a function that is defined in the conceptual model from within a LINQ to Entities query. The example uses the School model. For information about the School model, see [Creating the School Sample Database](/previous-versions/dotnet/netframework-4.0/bb399731(v=vs.100)) and [Generating the School .edmx File](/previous-versions/dotnet/netframework-4.0/bb399739(v=vs.100)).

 The following conceptual model function returns the number of years since an instructor was hired. For information about adding the function to a conceptual model, see [How to: Define Custom Functions in the Conceptual Model](/previous-versions/dotnet/netframework-4.0/dd456812(v=vs.100)).

```xml
<Function Name="YearsSince" ReturnType="Edm.Int32">
  <Parameter Name="date" Type="Edm.DateTime" />
  <DefiningExpression>
    Year(CurrentDateTime()) - Year(date)
  </DefiningExpression>
</Function>
```

## Example 2

 Next, add the following method to your application and use an <xref:System.Data.Objects.DataClasses.EdmFunctionAttribute> to map it to the conceptual model function:

 [!code-csharp[DP ConceptualModelFunctions#2](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp conceptualmodelfunctions/cs/program.cs#2)]
 [!code-vb[DP ConceptualModelFunctions#2](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/dp conceptualmodelfunctions/vb/module1.vb#2)]

## Example 3

 Now you can call the conceptual model function from within a LINQ to Entities query. The following code calls the method to display all instructors that were hired more than ten years ago:

 [!code-csharp[DP ConceptualModelFunctions#3](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp conceptualmodelfunctions/cs/program.cs#3)]
 [!code-vb[DP ConceptualModelFunctions#3](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/dp conceptualmodelfunctions/vb/module1.vb#3)]

## See also

- [.edmx File Overview](/previous-versions/dotnet/netframework-4.0/cc982042(v=vs.100))
- [Queries in LINQ to Entities](queries-in-linq-to-entities.md)
- [Calling Functions in LINQ to Entities Queries](calling-functions-in-linq-to-entities-queries.md)
- [How to: Call Model-Defined Functions as Object Methods](how-to-call-model-defined-functions-as-object-methods.md)
