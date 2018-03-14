'<snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Schema
Imports System.IO

public class ValidXSD 

  public shared sub Main() 
    Dim sc as XmlSchemaCollection = new XmlSchemaCollection()
    AddHandler sc.ValidationEventHandler, AddressOf ValidationCallBack
    sc.Add(nothing, "books.xsd")

    if(sc.Count > 0)
      Dim tr as XmlTextReader = new XmlTextReader("notValidXSD.xml")
      Dim rdr as XmlValidatingReader = new XmlValidatingReader(tr)

      rdr.ValidationType = ValidationType.Schema
      rdr.Schemas.Add(sc)
      AddHandler rdr.ValidationEventHandler, AddressOf ValidationCallBack
      while (rdr.Read())
      end while
    end if

  end sub

  private shared sub ValidationCallBack(sender as object, e as ValidationEventArgs) 
    Console.WriteLine("XSD Error: {0}", e.Message)
  end sub

end class
'</snippet1>