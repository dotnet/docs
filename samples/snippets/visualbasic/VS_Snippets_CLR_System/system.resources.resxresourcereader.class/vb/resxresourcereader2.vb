' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections
Imports System.ComponentModel.Design
Imports System.Resources

Module Example
   Private Const resxFilename As String = ".\CountryHeaders.resx"
     
   Public Sub Main()
      ' Create a resource file to read.
      CreateResourceFile()
      
      ' Enumerate the resources in the file.
      Dim rr As New ResXResourceReader(resxFilename)
      rr.UseResXDataNodes = True
      Dim dict As IDictionaryEnumerator = rr.GetEnumerator()
      Do While dict.MoveNext()
         Dim node As ResXDataNode = DirectCast(dict.Value, ResXDataNode)
         Console.WriteLine("{0,-20} {1,-20} {2}", 
                           node.Name + ":", 
                           node.GetValue(CType(Nothing, ITypeResolutionService)), 
                           If(Not String.IsNullOrEmpty(node.Comment), "// " + node.Comment, ""))
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
'    Title:               Country Information
'    nColumns:            5
'    Country:             Country Name         // The localized country name
'    Population:          Population (2010}
'    Area:                Area                 // The area in square miles
'    Capital:             Capital
'    LCity:               Largest City         // The largest city based on 2010 data
' </Snippet2>
