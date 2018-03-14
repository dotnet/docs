'<snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample 

  public shared sub Main()

    'Create the reader.
    Dim txtreader as XmlTextReader = new XmlTextReader("book4.xml")
    Dim reader as XmlValidatingReader = new XmlValidatingReader(txtreader)

    reader.MoveToContent()

    'Display each of the attribute nodes, including default attributes.
    while (reader.MoveToNextAttribute())
        if (reader.IsDefault)
          Console.Write("(default attribute) ")
        end if
        Console.WriteLine("{0} = {1}", reader.Name, reader.Value)  
    end while           
  
    'Close the reader.
    reader.Close()     
  
  end sub
end class
'</snippet1>


