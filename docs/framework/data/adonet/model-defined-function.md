---
description: "Learn more about: model-defined function"
title: "model-defined function"
ms.date: "03/30/2017"
ms.assetid: 8bb2edc8-e8e7-44c2-adc7-f44e11bda4f0
---
# model-defined function

A *model-defined function* is a function that is defined in a conceptual model. The body of a model-defined function is expressed in [Entity SQL](./ef/language-reference/entity-sql-language.md), which allows for the function to be expressed independently of rules or languages supported in the data source.  
  
 A definition for a model-defined function contains the following information:  
  
- A function name. (Required)  
  
- The type of the return value. (Optional)  
  
    > [!NOTE]
    > If no return type is specified, the return value is void.  
  
- Parameter information. (Optional)  
  
- An [Entity SQL](./ef/language-reference/entity-sql-language.md) expression that defines the body of the function.  
  
 Note that model-defined functions do not support output parameters. This restriction is in place so that model-defined functions can be composed.  
  
## Example  

 The diagram below shows a conceptual model with three entity types: `Book`, `Publisher`, and `Author`.  
  
 ![Screenshot that shows a model with published date.](./media/model-defined-function/model-published-date-three-entity-types.gif)  
  
 The [ADO.NET Entity Framework](./ef/index.md) uses a domain-specific language (DSL) called conceptual schema definition language ([CSDL](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec)) to define conceptual models. The following CSDL defines a function in the conceptual model that returns the numbers of years since an instance of a `Book` (in the diagram above) was published.  
  
 [!code-xml[EDM_Example_Model#ModelDefinedFunction](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books4.edmx#modeldefinedfunction)]  
  
## See also

- [Entity Data Model Key Concepts](entity-data-model-key-concepts.md)
- [Entity Data Model](entity-data-model.md)
- [Entity Data Model: Primitive Data Types](entity-data-model-primitive-data-types.md)
