'<Snippet1>
Imports System
Imports System.Resources
Imports System.Collections
Imports Microsoft.VisualBasic

Class ReadResXResources
   
   Public Shared Sub Main()
      
      ' Create a ResXResourceReader for the file items.resx.
      Dim rsxr As ResXResourceReader
      rsxr = New ResXResourceReader("items.resx")

      ' Iterate through the resources and display the contents to the console.
      Dim d As DictionaryEntry
      For Each d In  rsxr
         Console.WriteLine(d.Key.ToString() + ":" + ControlChars.Tab + d.Value.ToString())
      Next d
      
      'Close the reader.
      rsxr.Close()

   End Sub

End Class
'</Snippet1>