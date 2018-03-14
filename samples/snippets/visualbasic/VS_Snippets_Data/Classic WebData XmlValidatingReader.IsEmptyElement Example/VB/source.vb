' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
   
   Public Shared Sub Main()
      Dim txtreader As XmlTextReader = Nothing
      Dim reader As XmlValidatingReader = Nothing
      
      Try
         'Implement the readers.
         txtreader = New XmlTextReader("elems.xml")
         reader = New XmlValidatingReader(txtreader)
         
         'Parse the XML and display the text content of each of the elements.
         While reader.Read()
            If reader.IsStartElement() Then
               If reader.IsEmptyElement Then
                  Console.WriteLine("<{0}/>", reader.Name)
               Else
                  Console.Write("<{0}> ", reader.Name)
                  reader.Read() 'Read the start tag.
                  If (reader.IsStartElement())  'Handle nested elements.
                    Console.WriteLine()
                    Console.Write("<{0}>", reader.Name)
                  End If
                  Console.WriteLine(reader.ReadString()) 'Read the text content of the element.
               End If
            End If
         End While      
      
      Finally
         If Not (reader Is Nothing) Then
            reader.Close()
         End If
      End Try
   End Sub 'Main 
End Class 'Sample
' </Snippet1>