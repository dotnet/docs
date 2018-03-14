'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema

public class Sample

  public shared sub Main ()
 
    'Create the schema collection.
    Dim xsc as XmlSchemaCollection = new XmlSchemaCollection()

    'Set an event handler to manage invalid schemas.
    AddHandler xsc.ValidationEventHandler, AddressOf ValidationCallBack

    'Add the schema to the collection.  
    xsc.Add(nothing, "invalid.xsd")

  end sub

  'Display the schema error information.
  Private shared sub ValidationCallBack (sender as object, args as ValidationEventArgs) 
     Console.WriteLine("Invalid XSD schema: " + args.Exception.Message)
  end sub

end class
'</snippet1>



