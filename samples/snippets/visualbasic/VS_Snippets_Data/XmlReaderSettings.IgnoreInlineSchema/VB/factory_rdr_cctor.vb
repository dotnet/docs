'<snippet1>
Imports System
Imports System.Xml
Imports System.Xml.Schema
Imports System.IO

public class ValidXSD 

  public shared sub Main() 

    ' Set the validation settings.
    Dim settings as XmlReaderSettings = new XmlReaderSettings()
    settings.ValidationType = ValidationType.Schema
    settings.ValidationFlags = settings.ValidationFlags Or XmlSchemaValidationFlags.ProcessInlineSchema
    settings.ValidationFlags = settings.ValidationFlags Or XmlSchemaValidationFlags.ReportValidationWarnings
      AddHandler settings.ValidationEventHandler, AddressOf ValidationCallBack

    ' Create the XmlReader object.
    Dim reader as XmlReader = XmlReader.Create("inlineSchema.xml", settings)

    ' Parse the file. 
    while (reader.Read())
    end while
  end sub

  ' Display any warnings or errors.
  private shared sub ValidationCallBack (sender as object, args as ValidationEventArgs)
     if (args.Severity=XmlSeverityType.Warning)
       Console.WriteLine("   Warning: Matching schema not found.  No validation occurred." + args.Message)
     else
        Console.WriteLine("   Validation error: " + args.Message)
     end if
  end sub 

end class 
'</snippet1>
