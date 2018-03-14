'<snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Schema
Imports System.IO

public class Sample 

  public shared sub Main() 

    ' Set the validation settings.
    Dim settings as XmlReaderSettings = new XmlReaderSettings()
    settings.DtdProcessing = DtdProcessing.Parse
    settings.ValidationType = ValidationType.DTD
    AddHandler settings.ValidationEventHandler, AddressOf ValidationCallBack
 
    ' Create the XmlReader object.
    Dim reader as XmlReader = XmlReader.Create("itemDTD.xml", settings)

    ' Parse the file. 
    while reader.Read()
    end while
    
  end sub

  ' Display any validation errors.
  private shared sub ValidationCallBack(sender as object, e as ValidationEventArgs) 
    Console.WriteLine("Validation Error: {0}", e.Message)
  end sub
end class
'</snippet1>
