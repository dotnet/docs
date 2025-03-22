using System;
using System.Text;
using System.IO;
using System.Xml;

class Read_Typed_Element {

   static void Main() {

              ReadElementContentAsString_1();
 	ReadElementContentAsString_2();
	ReadElementContentAsLong_1();
	ReadElementContentAsDateTime_1();
	ReadElementContentAs_1() ;
	ReadElementContentAsObject();
             ReadElementContentAsDouble_1();
   }

public static void ReadElementContentAsString_1() {
//<snippet1>	
  using (XmlReader reader = XmlReader.Create("dataFile.xml")) {
       reader.ReadToFollowing("stringValue");
       Console.WriteLine(reader.ReadElementContentAsString());			
  }
//</snippet1>
}

public static void ReadElementContentAsString_2() {
//<snippet2>
  using (XmlReader reader = XmlReader.Create("dataFile.xml")) {
       reader.ReadToFollowing("stringValue");
       Console.WriteLine(reader.ReadElementContentAsString("stringValue", ""));
  }
//</snippet2>
}

public static void ReadElementContentAsLong_1() {
//<snippet3>	
  using (XmlReader reader = XmlReader.Create("dataFile.xml")) {
       reader.ReadToFollowing("longValue");
       long number = reader.ReadElementContentAsLong();
       // Do some processing with the number object.
  }
//</snippet3>
}

public static void ReadElementContentAsDateTime_1() {
//<snippet4>	
  using (XmlReader reader = XmlReader.Create("dataFile.xml")) {
       reader.ReadToFollowing("date");
       DateTime date = reader.ReadElementContentAsDateTime();
	
       // If the current culture is "en-US",
       // this writes "Wednesday, January 8, 2003".
       Console.WriteLine(date.ToLongDateString());
  }
//</snippet4>
}

public static void ReadElementContentAs_1() {
//<snippet5>	
  using (XmlReader reader = XmlReader.Create("dataFile.xml")) {
       reader.ReadToFollowing("date");
       DateTime date = (DateTime) reader.ReadElementContentAs(typeof(System.DateTime), null);
	
       // If the current culture is "en-US",
       // this writes "Wednesday, January 8, 2003".
       Console.WriteLine(date.ToLongDateString());	
  }
//</snippet5>
}

public static void ReadElementContentAsObject() {
//<snippet6>
  // Create a validating reader.
  XmlReaderSettings settings = new XmlReaderSettings();
  settings.ValidationType = ValidationType.Schema;
  settings.Schemas.Add("urn:items", "item.xsd");	
   XmlReader reader = XmlReader.Create("item.xml", settings);

  // Get the CLR type of the price element.
  reader.ReadToFollowing("price");
  Console.WriteLine(reader.ValueType);

  // Return the value of the price element as Decimal object.
  Decimal price = (Decimal) reader.ReadElementContentAsObject();

  // Add 2.50 to the price.
  price = Decimal.Add(price, 2.50m);

//</snippet6>
}

public static void ReadElementContentAsDouble_1() {
//<snippet7>	
  using (XmlReader reader = XmlReader.Create("dataFile.xml")) {
       reader.ReadToFollowing("double");
       Double number = reader.ReadElementContentAsDouble();
       // Do some processing with the number object.	
  }
//</snippet7>
}

public static void ReadTypedData1() {
//<snippet13>
// Create a validating XmlReader object. The schema
// provides the necessary type information.
XmlReaderSettings settings = new XmlReaderSettings();
settings.ValidationType = ValidationType.Schema;
settings.Schemas.Add("urn:empl-hire", "hireDate.xsd");
using (XmlReader reader = XmlReader.Create("hireDate.xml", settings)) {

  // Move to the hire-date element.
  reader.MoveToContent();
  reader.ReadToDescendant("hire-date");

  // Return the hire-date as a DateTime object.
  DateTime hireDate = reader.ReadElementContentAsDateTime();
  Console.WriteLine($"Six Month Review Date: {hireDate.AddMonths(6)}");
}
//</snippet13>
}

public static void ReadTypedData2() {
//<snippet14>
// Create an XmlReader object.
using (XmlReader reader = XmlReader.Create("hireDate_1.xml")) {
  // Move to the hire-date element.
  reader.MoveToContent();
  reader.ReadToDescendant("hire-date");

  // Return the hire-date as a DateTime object.
  DateTime hireDate = reader.ReadElementContentAsDateTime();
  Console.WriteLine($"Six Month Review Date: {hireDate.AddMonths(6)}");
}
//</snippet14>
}
} // end class.