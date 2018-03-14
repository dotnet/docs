//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

public class Sample{

  public static void Main(){
  
  XmlTextReader tr = new XmlTextReader("booksSchema.xml");
  XmlValidatingReader vr = new XmlValidatingReader(tr);
 
  vr.Schemas.Add(null, "books.xsd");
  vr.ValidationType = ValidationType.Schema;
  vr.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);
 
  while(vr.Read()){
    if(vr.NodeType == XmlNodeType.Element){
      if(vr.SchemaType is XmlSchemaComplexType){
        XmlSchemaComplexType sct = (XmlSchemaComplexType)vr.SchemaType;
        Console.WriteLine("{0}({1})", vr.Name, sct.Name);
      }
      else{
        object value = vr.ReadTypedValue();
        Console.WriteLine("{0}({1}):{2}", vr.Name, value.GetType().Name, value);
      }
    }
  }
 }

  private static void ValidationCallBack (object sender, ValidationEventArgs args){
    Console.WriteLine("***Validation error");
    Console.WriteLine("\tSeverity:{0}", args.Severity);
    Console.WriteLine("\tMessage  :{0}", args.Message);
  }
}
//</snippet1>