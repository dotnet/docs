Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Class MySample
   Public Shared Sub Main()
      Console.WriteLine("Import Sample")
      
      Dim myServiceDescription As ServiceDescription = _
         ServiceDescription.Read("StockQuote_vb.wsdl")
      myServiceDescription.Imports.Add( _
         CreateImport("http://localhost/stockquote/schemas", _
         "http://localhost/stockquote/stockquote_vb.xsd"))
      ' Save the ServiceDescripition to an external file.
      myServiceDescription.Write("StockQuote_vb.wsdl")
      Console.WriteLine("Successfully added Import to WSDL document " _
         & "'StockQuote_vb.wsdl'")
      ' Print the import collection to the console.
      PrintImportCollection("StockQuote_vb.wsdl")
        myServiceDescription = _
           ServiceDescription.Read("StockQuoteService_vb.wsdl")
      myServiceDescription.Imports.Insert(0, _
         CreateImport("http://localhost/stockquote/definitions", _
         "http://localhost/stockquote/stockquote_vb.wsdl"))
      ' Save the ServiceDescripition to an external file.
      myServiceDescription.Write("StockQuoteService_vb.wsdl")
      Console.WriteLine("")
      Console.WriteLine("Successfully added Import to " & _
         "WSDL document 'StockQuoteService_vb.wsdl'")
      'Print the import collection to the console.
      PrintImportCollection("StockQuoteService_vb.wsdl")
   End Sub 'Main

   ' Creates an Import object with namespace and location.
   Public Shared Function CreateImport(targetNamespace As String, _
      targetlocation As String) As Import
      Dim myImport As New Import()
      myImport.Location = targetlocation
      myImport.Namespace = targetNamespace
      Return myImport
   End Function 'CreateImport

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
End Class 'MySample