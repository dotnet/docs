//<snippet1>
using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;

public class ValidXSD {

  public static void Main() {
    XmlSchemaCollection sc = new XmlSchemaCollection();
    sc.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
    sc.Add(null, "books.xsd");

    if(sc.Count > 0)
    {
      XmlTextReader tr = new XmlTextReader("notValidXSD.xml");
      XmlValidatingReader rdr = new XmlValidatingReader(tr);

      rdr.ValidationType = ValidationType.Schema;
      rdr.Schemas.Add(sc);
      rdr.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
      while (rdr.Read());
    }
    
  }

  private static void ValidationCallBack(object sender, ValidationEventArgs e) {
    Console.WriteLine("Validation Error: {0}", e.Message);
  }
}
//</snippet1>