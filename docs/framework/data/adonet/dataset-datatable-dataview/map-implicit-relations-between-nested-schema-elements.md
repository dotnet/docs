---
description: "Learn more about: Map Implicit Relations Between Nested Schema Elements"
title: "Map Implicit Relations Between Nested Schema Elements"
ms.date: "03/30/2017"
ms.assetid: 6b25002a-352e-4d9b-bae3-15129458a355
---
# Map Implicit Relations Between Nested Schema Elements

An XML Schema definition language (XSD) schema can have complex types nested inside one another. In this case, the mapping process applies default mapping and creates the following in the <xref:System.Data.DataSet>:  
  
- One table for each of the complex types (parent and child).  
  
- If no unique constraint exists on the parent, one additional primary key column per table definition named *TableName*_Id where *TableName* is the name of the parent table.  
  
- A primary key constraint on the parent table identifying the additional column as the primary key (by setting the **IsPrimaryKey** property to **True**). The constraint is named Constraint\# where \# is 1, 2, 3, and so on. For example, the default name for the first constraint is Constraint1.  
  
- A foreign key constraint on the child table identifying the additional column as the foreign key referring to the primary key of the parent table. The constraint is named *ParentTable_ChildTable* where *ParentTable* is the name of the parent table and *ChildTable* is the name of the child table.  
  
- A data relation between the parent and child tables.  
  
 The following example shows a schema where **OrderDetail** is a child element of **Order**.  
  
```xml  
<xs:schema id="MyDataSet" xmlns=""
            xmlns:xs="http://www.w3.org/2001/XMLSchema"
            xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">  
  
 <xs:element name="MyDataSet" msdata:IsDataSet="true">  
   <xs:complexType>  
     <xs:choice maxOccurs="unbounded">  
       <xs:element name="Order">  
         <xs:complexType>  
          <xs:sequence>  
            <xs:element name="OrderNumber" type="xs:string" />  
            <xs:element name="EmpNumber" type="xs:string" />  
            <xs:element name="OrderDetail">  
              <xs:complexType>  
                <xs:sequence>  
                  <xs:element name="OrderNo" type="xs:string" />  
                  <xs:element name="ItemNo" type="xs:string" />  
                </xs:sequence>  
              </xs:complexType>  
            </xs:element>  
          </xs:sequence>  
         </xs:complexType>  
       </xs:element>  
     </xs:choice>  
   </xs:complexType>  
  </xs:element>  
</xs:schema>  
```  
  
 The XML Schema mapping process creates the following in the **DataSet**:  
  
- An **Order** and an **OrderDetail** table.  
  
    ```text  
    Order(OrderNumber, EmpNumber, Order_Id)  
    OrderDetail(OrderNo, ItemNo, Order_Id)  
    ```  
  
- A unique constraint on the **Order** table. Note that the **IsPrimaryKey** property is set to **True**.  
  
    ```text  
    ConstraintName: Constraint1  
    Type: UniqueConstraint  
    Table: Order  
    Columns: Order_Id
    IsPrimaryKey: True  
    ```  
  
- A foreign key constraint on the **OrderDetail** table.  
  
    ```text  
    ConstraintName: Order_OrderDetail  
    Type: ForeignKeyConstraint  
    Table: OrderDetail  
    Columns: Order_Id
    RelatedTable: Order  
    RelatedColumns: Order_Id
    ```  
  
- A relationship between the **Order** and **OrderDetail** tables. The **Nested** property for this relationship is set to **True** because the **Order** and **OrderDetail** elements are nested in the schema.  
  
    ```text  
    ParentTable: Order  
    ParentColumns: Order_Id
    ChildTable: OrderDetail  
    ChildColumns: Order_Id
    ParentKeyConstraint: Constraint1  
    ChildKeyConstraint: Order_OrderDetail  
    RelationName: Order_OrderDetail  
    Nested: True  
    ```  
  
## See also

- [Generating DataSet Relations from XML Schema (XSD)](generating-dataset-relations-from-xml-schema-xsd.md)
- [Mapping XML Schema (XSD) Constraints to DataSet Constraints](mapping-xml-schema-xsd-constraints-to-dataset-constraints.md)
- [ADO.NET Overview](../ado-net-overview.md)
