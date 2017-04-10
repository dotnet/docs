' System.Web.Services.Description.ImportCollection.Add;
' System.Web.Services.Description.ImportCollection.Insert;
' System.Web.Services.Description.Import.Import();
' System.Web.Services.Description.Import.Location;
' System.Web.Services.Description.Import.Namespace;
' System.Web.Services.Description.Import.ServiceDescription;
' System.Web.Services.Description.Import;

'  The following example demonstrates the constructor 'Import()' and properties
'  'Namespace','Location','Namespace','ServiceDescription' of Import Class.
'  Methods 'Add' and 'Insert' of Class 'ImportCollection' are also demonstrated.
'  This example uses a sample provided in WSDL specification to explain Import
'  and ImportCollection. It adds import instances to ImportCollection as suggested
'  in the specification sample and enumerates the same to the console.
'  Note: This is an illustrative sample using an example from WSDL specification.
'  The real world web service has been assumed.

' <Snippet7>
Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Class MySample
   Public Shared Sub Main()
      Console.WriteLine("Import Sample")
      
' <Snippet1>
      Dim myServiceDescription As ServiceDescription = _
         ServiceDescription.Read("StockQuote_vb.wsdl")
      myServiceDescription.Imports.Add( _
         CreateImport("http://localhost/stockquote/schemas", _
         "http://localhost/stockquote/stockquote_vb.xsd"))
' </Snippet1>
      ' Save the ServiceDescripition to an external file.
      myServiceDescription.Write("StockQuote_vb.wsdl")
      Console.WriteLine("Successfully added Import to WSDL document " _
         & "'StockQuote_vb.wsdl'")
      ' Print the import collection to the console.
      PrintImportCollection("StockQuote_vb.wsdl")
' <Snippet2>
        myServiceDescription = _
           ServiceDescription.Read("StockQuoteService_vb.wsdl")
      myServiceDescription.Imports.Insert(0, _
         CreateImport("http://localhost/stockquote/definitions", _
         "http://localhost/stockquote/stockquote_vb.wsdl"))
' </Snippet2>
      ' Save the ServiceDescripition to an external file.
      myServiceDescription.Write("StockQuoteService_vb.wsdl")
      Console.WriteLine("")
      Console.WriteLine("Successfully added Import to " & _
         "WSDL document 'StockQuoteService_vb.wsdl'")
      'Print the import collection to the console.
      PrintImportCollection("StockQuoteService_vb.wsdl")
   End Sub 'Main

' <Snippet3>
' <Snippet4>
' <Snippet5>
   ' Creates an Import object with namespace and location.
   Public Shared Function CreateImport(targetNamespace As String, _
      targetlocation As String) As Import
      Dim myImport As New Import()
      myImport.Location = targetlocation
      myImport.Namespace = targetNamespace
      Return myImport
   End Function 'CreateImport
' </Snippet5>
' </Snippet4>
' </Snippet3>

' <Snippet6>
   Public Shared Sub PrintImportCollection(fileName_wsdl As String)

      ' Read import collection properties from generated WSDL file.
      Dim myServiceDescription1 As _
         ServiceDescription = ServiceDescription.Read(fileName_wsdl)
      Dim myImportCollection As ImportCollection = myServiceDescription1.Imports
      Console.WriteLine("Enumerating Import Collection for file '" & _
         fileName_wsdl & "'...")

      ' Print Import properties to the console.
      Dim i As Integer
      For i = 0 To myImportCollection.Count - 1
         Console.WriteLine("Namespace : " & myImportCollection(i).Namespace)
         Console.WriteLine("Location  : " & myImportCollection(i).Location)
         Console.WriteLine("ServiceDescription  : " & _
            myImportCollection(i).ServiceDescription.Name)
      Next i
   End Sub 'PrintImportCollection
' </Snippet6>
End Class 'MySample
' </Snippet7>
