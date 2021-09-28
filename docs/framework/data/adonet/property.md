---
description: "Learn more about: property"
title: "property"
ms.date: "03/30/2017"
ms.assetid: a941c53f-fc97-42c2-8832-0fb9f1d55c06
---
# property

*Properties* are the fundamental building blocks of [entity types](entity-type.md) and [complex types](complex-type.md). Properties define the shape and characteristics of data that an entity type instance or complex type instance will contain. Properties in a conceptual model are analogous to properties defined on a class. In the same way that properties on a class define the shape of the class and carry information about objects, properties in a conceptual model define the shape of an entity type and carry information about entity type instances.  
  
> [!NOTE]
> Properties, as described in this topic, are different from navigation properties. For more information, see [navigation properties](navigation-property.md).  
  
 A property definition contains the following information:  
  
- A property name. (Required)  
  
- A property type. (Required)  
  
- A set of [facets](facet.md). (Optional)  
  
 A property can contain primitive data (such as a string, an integer, or a Boolean value), or structured data (such as a complex type). Properties that are of primitive type are also called scalar properties. For more information, see [Entity Data Model: Primitive Data Types](entity-data-model-primitive-data-types.md).  
  
> [!NOTE]
> A complex type can, itself, have properties that are complex types.  
  
## Example  

 The diagram below shows a conceptual model with three entity types: `Book`, `Publisher`, and `Author`. Each entity type has several properties, although type information for each property is not conveyed in the diagram. Properties that are [entity keys](entity-key.md) are denoted with (Key).  
  
 ![Example model with three entity types](./media/property/example-model-three-entity-types.gif)  
  
 The [ADO.NET Entity Framework](./ef/index.md) uses a domain-specific language (DSL) called conceptual schema definition language ([CSDL](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec)) to define conceptual models. The following CSDL defines the `Book` entity type (as shown in the diagram above) and indicates the type and name of each property by using XML attributes. An optional facet, `Nullable`, is also defined by using an XML attribute.  
  
 [!code-xml[EDM_Example_Model#EntityExample](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books.edmx#entityexample)]  
  
 It is possible that one of the properties shown in the diagram is a complex type property. For example, the `Address` property on the `Publisher` entity type could be a complex type property composed of several scalar properties, such as `StreetAddress`, `City`, `StateOrProvince`, `Country`, and `PostalCode`. The CSDL representation of such a complex type would be as follows:  
  
 [!code-xml[EDM_Example_Model#ComplexTypeExample](../../../../samples/snippets/xml/VS_Snippets_Data/edm_example_model/xml/books2.edmx#complextypeexample)]  
  
## See also

- [Entity Data Model Key Concepts](entity-data-model-key-concepts.md)
- [Entity Data Model](entity-data-model.md)
