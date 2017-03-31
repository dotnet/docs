// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;

class XMLSchemaExamples
{
    public static void Main()
    {

        XmlSchema schema = new XmlSchema();

        // <xs:simpleType name="LotteryNumber">
        XmlSchemaSimpleType LotteryNumberType = new XmlSchemaSimpleType();
        LotteryNumberType.Name = "LotteryNumber";

        // <xs:restriction base="xs:int">
        XmlSchemaSimpleTypeRestriction LotteryNumberRestriction = new XmlSchemaSimpleTypeRestriction();
        LotteryNumberRestriction.BaseTypeName = new XmlQualifiedName("int", "http://www.w3.org/2001/XMLSchema");

        // <xs:minInclusive value="1"/>
        XmlSchemaMinInclusiveFacet minInclusive = new XmlSchemaMinInclusiveFacet();
        minInclusive.Value = "1";
        LotteryNumberRestriction.Facets.Add(minInclusive);

        // <xs:maxInclusive value="99"/>
        XmlSchemaMaxInclusiveFacet maxInclusive = new XmlSchemaMaxInclusiveFacet();
        maxInclusive.Value = "99";
        LotteryNumberRestriction.Facets.Add(maxInclusive);

        LotteryNumberType.Content = LotteryNumberRestriction;
        schema.Items.Add(LotteryNumberType);

        // <xs:simpleType name="LotteryNumberList">
        XmlSchemaSimpleType LotteryNumberListType = new XmlSchemaSimpleType();
        LotteryNumberListType.Name = "LotteryNumberList";

        // <xs:list itemType="LotteryNumber"/>
        XmlSchemaSimpleTypeList list = new XmlSchemaSimpleTypeList();
        list.ItemTypeName = new XmlQualifiedName("LotteryNumber", "");
        LotteryNumberListType.Content = list;

        schema.Items.Add(LotteryNumberListType);

        // <xs:simpleType name="LotteryNumbers">
        XmlSchemaSimpleType LotteryNumbersType = new XmlSchemaSimpleType();
        LotteryNumbersType.Name = "LotteryNumbers";

        // <xs:restriction base="LotteryNumberList">
        XmlSchemaSimpleTypeRestriction LotteryNumbersRestriction = new XmlSchemaSimpleTypeRestriction();
        LotteryNumbersRestriction.BaseTypeName = new XmlQualifiedName("LotteryNumberList", "");

        // <xs:length value="5"/>
        XmlSchemaLengthFacet length = new XmlSchemaLengthFacet();
        length.Value = "5";
        LotteryNumbersRestriction.Facets.Add(length);

        LotteryNumbersType.Content = LotteryNumbersRestriction;

        schema.Items.Add(LotteryNumbersType);

        // <xs:element name="TodaysLottery" type="LotteryNumbers">
        XmlSchemaElement TodaysLottery = new XmlSchemaElement();
        TodaysLottery.Name = "TodaysLottery";
        TodaysLottery.SchemaTypeName = new XmlQualifiedName("LotteryNumbers", "");

        schema.Items.Add(TodaysLottery);

        XmlSchemaSet schemaSet = new XmlSchemaSet();
        schemaSet.ValidationEventHandler += new ValidationEventHandler(ValidationCallbackOne);
        schemaSet.Add(schema);
        schemaSet.Compile();

        XmlSchema compiledSchema = null;

        foreach (XmlSchema schema1 in schemaSet.Schemas())
        {
            compiledSchema = schema1;
        }

        XmlNamespaceManager nsmgr = new XmlNamespaceManager(new NameTable());
        nsmgr.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
        compiledSchema.Write(Console.Out, nsmgr);
    }

    public static void ValidationCallbackOne(object sender, ValidationEventArgs args)
    {

        Console.WriteLine(args.Message);
    }
}
// </Snippet1>

