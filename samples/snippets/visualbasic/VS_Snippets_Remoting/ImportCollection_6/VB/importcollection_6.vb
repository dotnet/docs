' System.Web.Services.Description.ImportCollection
' System.Web.Services.Description.ImportCollection.Item
' System.Web.Services.Description.ImportCollection.CopyTo
' System.Web.Services.Description.ImportCollection.Contains
' System.Web.Services.Description.ImportCollection.IndexOf
' System.Web.Services.Description.ImportCollection.Remove

'  The following program demonstrates the methods 'CopyTo', 'Contains','IndexOf','Remove'
'  and property 'Item' of class 'ImportCollection'.
'  The program reads a 'WSDL' document and gets a 'ServiceDescription' instance
'  An 'ImportCollection' instance is then retrieved from this 'ServiceDescription'
'  instance and it's members have been demonstrated.

' <Snippet1>
Imports System
Imports System.Web.Services.Description
Imports System.Xml
Imports Microsoft.VisualBasic

Class ServiceDescription_ImportCollection
   Public Shared Sub Main()
      Dim myServiceDescription As ServiceDescription = _
                              ServiceDescription.Read("StockQuoteService_vb.wsdl")
      Console.WriteLine(" ImportCollection Sample ")
' <Snippet2>
      ' Get Import Collection.
      Dim myImportCollection As ImportCollection = myServiceDescription.Imports
      Console.WriteLine("Total Imports in the document = " + _
                        myServiceDescription.Imports.Count.ToString())
      ' Print 'Import' properties to console.
      Dim i As Integer
      For i = 0 To myImportCollection.Count - 1
         Console.WriteLine(ControlChars.Tab + _
                           "Import Namespace :{0} Import Location :{1} ", _
                           myImportCollection(i).Namespace, _
                           myImportCollection(i).Location)
      Next i
' </Snippet2>

' <Snippet3>
      Dim myImports(myServiceDescription.Imports.Count - 1) As Import
      ' Copy 'ImportCollection' to an array.
      myServiceDescription.Imports.CopyTo(myImports, 0)
      Console.WriteLine("Imports that are copied to Importarray ...")
      Dim j As Integer
      For j = 0 To myImports.Length - 1
         Console.WriteLine(ControlChars.Tab + _
                           "Import Namespace :{0} Import Location :{1} ", _
                           myImports(j).Namespace, myImports(j).Location)
      Next j
' </Snippet3>

' <Snippet4>
' <Snippet5>
' <Snippet6>
      ' Get Import by Index.
      Dim myImport As Import = _
            myServiceDescription.Imports(myServiceDescription.Imports.Count - 1)
      Console.WriteLine("Import by Index...")
      If myImportCollection.Contains(myImport) Then
         Console.WriteLine("Import Namespace '" + myImport.Namespace + _
                           "' is found in 'ImportCollection'.")
         Console.WriteLine("Index of '" + myImport.Namespace + _
                           "' in 'ImportCollection' = " + _
                           myImportCollection.IndexOf(myImport).ToString())
         Console.WriteLine("Delete Import from 'ImportCollection'...")
         myImportCollection.Remove(myImport)
         If myImportCollection.IndexOf(myImport) = - 1 Then
            Console.WriteLine("Import is successfully removed from Import Collection.")
         End If
' </Snippet6>
' </Snippet5>
' </Snippet4>
      End If
   End Sub 'Main
End Class 'ServiceDescription_ImportCollection 
' </snippet1>