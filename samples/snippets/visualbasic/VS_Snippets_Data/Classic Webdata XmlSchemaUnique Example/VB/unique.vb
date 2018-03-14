'<Snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples
    Public Shared Sub Main()

        Dim schema As New XmlSchema()

        ' <xs:complexType name="customerOrderType">
        Dim customerOrderType As New XmlSchemaComplexType()
        customerOrderType.Name = "customerOrderType"

        ' <xs:sequence>
        Dim sequence1 As New XmlSchemaSequence()

        ' <xs:element name="item" minOccurs="0" maxOccurs="unbounded">
        Dim item As New XmlSchemaElement()
        item.MinOccurs = 0
        item.MaxOccursString = "unbounded"
        item.Name = "item"

        ' <xs:complexType>
        Dim ct1 As New XmlSchemaComplexType()

        ' <xs:attribute name="itemID" type="xs:string"/>
        Dim itemID As New XmlSchemaAttribute()
        itemID.Name = "itemID"
        itemID.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        ' </xs:complexType>
        ct1.Attributes.Add(itemID)

        ' </xs:element>
        item.SchemaType = ct1

        ' </xs:sequence>
        sequence1.Items.Add(item)
        customerOrderType.Particle = sequence1

        ' <xs:attribute name="CustomerID" type="xs:string"/>
        Dim CustomerID As New XmlSchemaAttribute()
        CustomerID.Name = "CustomerID"
        CustomerID.SchemaTypeName = New XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema")

        customerOrderType.Attributes.Add(CustomerID)

        ' </xs:complexType>
        schema.Items.Add(customerOrderType)

        ' <xs:element name="ordersByCustomer">
        Dim ordersByCustomer As New XmlSchemaElement()
        ordersByCustomer.Name = "ordersByCustomer"

        ' <xs:complexType>
        Dim ct2 As New XmlSchemaComplexType()

        ' <xs:sequence>
        Dim sequence2 As New XmlSchemaSequence()

        ' <xs:element name="customerOrders" type="customerOrderType" minOccurs="0" maxOccurs="unbounded" />
        Dim customerOrders As New XmlSchemaElement()
        customerOrders.MinOccurs = 0
        customerOrders.MaxOccursString = "unbounded"
        customerOrders.Name = "customerOrders"
        customerOrders.SchemaTypeName = New XmlQualifiedName("customerOrderType", "")

        ' </xs:sequence>
        sequence2.Items.Add(customerOrders)

        ' </xs:complexType>
        ct2.Particle = sequence2
        ordersByCustomer.SchemaType = ct2

        ' <xs:unique name="oneCustomerOrdersforEachCustomerID">
        Dim element_unique As New XmlSchemaUnique()
        element_unique.Name = "oneCustomerOrdersforEachCustomerID"

        ' <xs:selector xpath="customerOrders"/>
        element_unique.Selector = New XmlSchemaXPath()
        element_unique.Selector.XPath = "customerOrders"

        ' <xs:field xpath="@customerID"/>
        Dim field As New XmlSchemaXPath()
        field.XPath = "@customerID"

        ' </xs:unique>
        element_unique.Fields.Add(field)
        ordersByCustomer.Constraints.Add(element_unique)

        ' </xs:element>
        schema.Items.Add(ordersByCustomer)

        Dim schemaSet As New XmlSchemaSet()
        AddHandler schemaSet.ValidationEventHandler, AddressOf ValidationCallbackOne

        schemaSet.Add(schema)
        schemaSet.Compile()

        Dim compiledSchema As XmlSchema = Nothing

        For Each schema1 As XmlSchema In schemaSet.Schemas()
            compiledSchema = schema1
        Next

        Dim nsmgr As New XmlNamespaceManager(New NameTable())
        nsmgr.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema")
        compiledSchema.Write(Console.Out, nsmgr)

    End Sub

    Public Shared Sub ValidationCallbackOne(ByVal sender As Object, ByVal args As ValidationEventArgs)
        Console.WriteLine(args.Message)
    End Sub
End Class
'</Snippet1>