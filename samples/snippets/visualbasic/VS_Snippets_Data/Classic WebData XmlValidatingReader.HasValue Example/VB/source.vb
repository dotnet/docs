' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

public class Sample

  public shared sub  Main()
  
    'Create the validating reader.
    Dim txtreader as XmlTextReader = new XmlTextReader("book1.xml")
    txtreader.WhitespaceHandling = WhitespaceHandling.None
    Dim reader as XmlValidatingReader = new XmlValidatingReader(txtreader)
    reader.ValidationType = ValidationType.None

    'Parse the file and each node and its value.
    while (reader.Read())    
      if (reader.HasValue) then
        Console.WriteLine("({0})  {1}={2}", reader.NodeType, reader.Name, reader.Value)
      else
        Console.WriteLine("({0}) {1}", reader.NodeType, reader.Name)
      end if
    end while

    'Close the reader.
    reader.Close()
    
  end sub
end class 
' </Snippet1>
