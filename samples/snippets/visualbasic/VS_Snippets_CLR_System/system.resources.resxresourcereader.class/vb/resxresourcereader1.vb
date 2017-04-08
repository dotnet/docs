' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections
Imports System.Resources

Module Example
   Private Const resxFilename As String = ".\CountryHeaders.resx"
     
   Public Sub Main()
      ' Create a resource file to read.
      CreateResourceFile()
      
      ' Enumerate the resources in the file.
      Dim rr As New ResXResourceReader(resxFilename)
      Dim dict As IDictionaryEnumerator = rr.GetEnumerator()
      Do While dict.MoveNext()
         Console.WriteLine("{0}: {1}", dict.Key, dict.Value)   
      Loop
   End Sub
   
   Private Sub CreateResourceFile()
      Dim rw As New ResxResourceWriter(resxFilename)
      Dim resNames() As String = {"Country", "Population", "Area", 
                                  "Capital", "LCity" }
      Dim columnHeaders() As String = { "Country Name", "Population (2010}", 
                                        "Area", "Capital", "Largest City" }
      Dim comments() As String = { "The localized country name", "", 
                                   "The area in square miles", "", 
                                   "The largest city based on 2010 data" }
      rw.AddResource("Title", "Country Information")
      rw.AddResource("nColumns", resNames.Length)
      For ctr As Integer = 0 To resNames.Length - 1
         Dim node As New ResXDataNode(resNames(ctr), columnHeaders(ctr))
         node.Comment = comments(ctr)
         rw.AddResource(node)
      Next
      rw.Generate()
      rw.Close()
   End Sub
End Module
' The example displays the following output:
'       Title: Country Information
'       nColumns: 5
'       Country: Country Name
'       Population: Population (2010}
'       Area: Area
'       Capital: Capital
'       LCity: Largest City
' </Snippet1>
