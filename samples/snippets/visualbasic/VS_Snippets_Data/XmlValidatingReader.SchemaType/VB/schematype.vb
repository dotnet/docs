'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema

public class Sample

  public shared sub Main()
  
  Dim tr as XmlTextReader = new XmlTextReader("booksSchema.xml")
  Dim vr as XmlValidatingReader = new XmlValidatingReader(tr)
 
  vr.Schemas.Add(nothing, "books.xsd")
  vr.ValidationType = ValidationType.Schema
  AddHandler vr.ValidationEventHandler, AddressOf ValidationCallBack

  while(vr.Read())

    if(vr.NodeType = XmlNodeType.Element)
    
      if (vr.SchemaType.ToString() = "System.Xml.Schema.XmlSchemaComplexType")
        Dim sct as XmlSchemaComplexType = CType(vr.SchemaType,XmlSchemaComplexType)
        Console.WriteLine("{0}({1})", vr.Name, sct.Name)
      else      
        Dim value as object = vr.ReadTypedValue()
        Console.WriteLine("{0}({1}):{2}", vr.Name, value.GetType().Name, value)    
      end if
    end if
  end while
  end sub

  private shared sub ValidationCallBack (sender as object, args as ValidationEventArgs)

   Console.WriteLine("***Validation error")
   Console.WriteLine("Severity:{0}", args.Severity)
   Console.WriteLine("Message  :{0}", args.Message)
  end sub
end class
'</snippet1>