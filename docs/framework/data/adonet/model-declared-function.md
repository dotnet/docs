---
title: "model-declared function"
ms.date: "03/30/2017"
ms.assetid: aba87f13-5685-4f6b-ad14-918e8a7d5c2a
---
# model-declared function
A *model-declared function* is a function that is declared in a conceptual model, but is not defined in that conceptual model. The function might be defined in the hosting or storage environment. For example, a model-declared function might be mapped to a function that is defined in a database, thus exposing server-side functionality in the conceptual model.  
  
 The declaration of a model-declared function contains the following information:  
  
-   The name of the function. (Required)  
  
-   The type of the return value. (Optional)  
  
    > [!NOTE]
    >  If no return value is specified, the return type is void.  
  
-   Parameter information, including parameter name and type. (Optional)  
  
## Example  
 The [ADO.NET Entity Framework](../../../../docs/framework/data/adonet/ef/index.md) uses a domain-specific language (DSL) called conceptual schema definition language ([CSDL](../../../../docs/framework/data/adonet/ef/language-reference/csdl-specification.md)) to define conceptual models. In CSDL, one implementation of a model-declared function is a [function import](https://msdn.microsoft.com/library/125704ae-56c7-4233-80b7-389a10f3a65d). The following CSDL defines an entity container with a function import definition. Note that the return type for the function is void since no return type is specified.  
  
 [!code-xml[EDM_Example_Model#FunctionImport](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books4.edmx#functionimport)]  
  
## See also
 [Entity Data Model Key Concepts](../../../../docs/framework/data/adonet/entity-data-model-key-concepts.md)  
 [Entity Data Model](../../../../docs/framework/data/adonet/entity-data-model.md)
