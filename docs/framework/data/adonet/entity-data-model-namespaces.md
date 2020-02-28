---
title: "Entity Data Model: Namespaces"
ms.date: "03/30/2017"
ms.assetid: 98ab4226-bb9f-44e7-af46-61a9b1a4e47c
---
# Entity Data Model: Namespaces
A namespace in the Entity Data Model (EDM) is an abstract container for [entity types](entity-type.md), [complex types](complex-type.md), and [associations](association-type.md). Namespaces in the EDM are similar to namespaces in a programming language: they provide context for the objects that they contain and they provide a way to disambiguate objects that have the same name (but are contained in different namespaces).  
  
## Example  
 The [ADO.NET Entity Framework](./ef/index.md) uses a domain-specific language (DSL) called conceptual schema definition language ([CSDL](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec)) to define conceptual models. The following CSDL code uses a namespace to identify a type that is defined in a different conceptual model. The example defines an entity type (`Publisher`) that has a complex type property (`Address`) that is imported from the `ExtendedBooksModel` namespace. Note that the `Using` element indicates that a namespace has been imported. Also note that the type of the `Address` property is defined by using its fully qualified name (`ExtendedBooksModel.Address`), indicating that this type is defined in the `ExtendedBooksModel` namespace.  
  
 [!code-xml[EDM_Example_Model#ImportedNamespace](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books6.edmx#importednamespace)]  
  
## See also

- [Entity Data Model Key Concepts](entity-data-model-key-concepts.md)
- [Entity Data Model](entity-data-model.md)
