'<snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports Microsoft.VisualBasic

public class Sample

  private m_success as Boolean = true

  public sub New ()
      'Validate the document using an external XSD schema.  Validation should fail.
      Validate("notValidXSD.xml") 

      'Validate the document using an inline XSD. Validation should succeed.
      Validate("inlineXSD.xml")
  end sub

  public shared sub Main ()
 
      Dim validation as Sample = new Sample()
  end sub

  private sub Validate(filename as String)

      m_success = true
      Console.WriteLine()
      Console.WriteLine("******")
      Console.WriteLine("Validating XML file " + filename.ToString())
      Dim txtreader as XmlTextReader = new XmlTextReader (filename)
      Dim reader as XmlValidatingReader = new XmlValidatingReader (txtreader)

      ' Set the validation event handler
      AddHandler reader.ValidationEventHandler, AddressOf ValidationCallBack

      ' Read XML data
      while (reader.Read())
      end while
      Console.WriteLine ("Validation finished. Validation {0}", IIf(m_success, "successful!", "failed."))

      'Close the reader.
      reader.Close()
  end sub

  'Display the validation error.
  Private sub ValidationCallBack (sender as object, args as ValidationEventArgs)

     m_success = false
     Console.WriteLine()
     Console.WriteLine("  Validation error: " + args.Message )
  end sub
end class
'</snippet1>