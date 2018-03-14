' <Snippet1>
Option Strict On
Option Explicit On

Imports System
Imports System.Xml
Imports System.Xml.Schema

Class XMLSchemaExamples

    Public Shared Sub Main()

        Dim schema As New XmlSchema()

        ' <xs:simpleType name="LotteryNumber">
        Dim LotteryNumberType As New XmlSchemaSimpleType()
        LotteryNumberType.Name = "LotteryNumber"

        ' <xs:restriction base="xs:int">
        Dim LotteryNumberRestriction As New XmlSchemaSimpleTypeRestriction()
        LotteryNumberRestriction.BaseTypeName = New XmlQualifiedName("int", "http://www.w3.org/2001/XMLSchema")

        ' <xs:minInclusive value="1"/>
        Dim minInclusive As New XmlSchemaMinInclusiveFacet()
        minInclusive.Value = "1"
        LotteryNumberRestriction.Facets.Add(minInclusive)

        ' <xs:maxInclusive value="99"/>
        Dim maxInclusive As New XmlSchemaMaxInclusiveFacet()
        maxInclusive.Value = "99"
        LotteryNumberRestriction.Facets.Add(maxInclusive)

        LotteryNumberType.Content = LotteryNumberRestriction
        schema.Items.Add(LotteryNumberType)

        ' <xs:simpleType name="LotteryNumberList">
        Dim LotteryNumberListType As New XmlSchemaSimpleType()
        LotteryNumberListType.Name = "LotteryNumberList"

        ' <xs:list itemType="LotteryNumber"/>
        Dim list As New XmlSchemaSimpleTypeList()
        list.ItemTypeName = New XmlQualifiedName("LotteryNumber", "")
        LotteryNumberListType.Content = list

        schema.Items.Add(LotteryNumberListType)

        ' <xs:simpleType name="LotteryNumbers">
        Dim LotteryNumbersType As New XmlSchemaSimpleType()
        LotteryNumbersType.Name = "LotteryNumbers"

        ' <xs:restriction base="LotteryNumberList">
        Dim LotteryNumbersRestriction As New XmlSchemaSimpleTypeRestriction()
        LotteryNumbersRestriction.BaseTypeName = New XmlQualifiedName("LotteryNumberList", "")

        ' <xs:length value="5"/>
        Dim length As New XmlSchemaLengthFacet()
        length.Value = "5"
        LotteryNumbersRestriction.Facets.Add(length)

        LotteryNumbersType.Content = LotteryNumbersRestriction

        schema.Items.Add(LotteryNumbersType)

        ' <xs:element name="TodaysLottery" type="LotteryNumbers">
        Dim TodaysLottery As New XmlSchemaElement()
        TodaysLottery.Name = "TodaysLottery"
        TodaysLottery.SchemaTypeName = New XmlQualifiedName("LotteryNumbers", "")

        schema.Items.Add(TodaysLottery)

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
    End Sub 'Main


    Public Shared Sub ValidationCallbackOne(ByVal sender As Object, ByVal args As ValidationEventArgs)

        Console.WriteLine(args.Message)
    End Sub 'ValidationCallbackOne
End Class 'XMLSchemaExamples
' </Snippet1>