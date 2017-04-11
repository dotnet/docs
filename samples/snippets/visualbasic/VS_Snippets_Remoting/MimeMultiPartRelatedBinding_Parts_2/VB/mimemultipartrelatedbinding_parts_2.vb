' System.Web.Services.Description.MimeMultipartRelatedBinding
' System.Web.Services.Description.MimeMultipartRelatedBinding.Parts;

' The following program demonstrates the property 'Parts' of class 'MimeMultipartRelatedBinding'.
' It reads 'MimeMultiPartRelatedSample_vb.wsdl'file and instantiates a ServiceDescription object.
' 'MimeMultipartRelatedBinding' object is retrieved from Extension
' points of OutputBinding for one of the Binding object and its property'Parts' has been demonstrated.

' <Snippet1>
Imports System
Imports System.Web.Services.Description

Namespace MimeContentBinding_work
    
   Class MyMimeContentClass
      
      Shared Sub Main()
' <Snippet2>
        Dim myServicDescription As ServiceDescription = _
            ServiceDescription.Read("MimeMultiPartRelatedSample_vb.wsdl")

        ' Get the binding collection.
         Dim myBindingCollection As BindingCollection = _
            myServicDescription.Bindings
         Dim index As Integer = 0
         Dim i As Integer
         For i = 0 To myBindingCollection.Count - 1
            ' Get the collection for MimeServiceHttpPost.
            If myBindingCollection(i).Name = "MimeServiceHttpPost" Then
               Dim myOperationBindingCollection As _
                  OperationBindingCollection = myBindingCollection(i).Operations
               Dim myOutputBinding As OutputBinding = _
                  myOperationBindingCollection(0).Output
               Dim myServiceDescriptionFormatExtensionCollection As _
                  ServiceDescriptionFormatExtensionCollection = _
                  myOutputBinding.Extensions
               Dim myMimeMultipartRelatedBinding As _
                  MimeMultipartRelatedBinding = _ 
                  CType(myServiceDescriptionFormatExtensionCollection.Find( _
                  GetType(MimeMultipartRelatedBinding)), _
                  MimeMultipartRelatedBinding)
               Dim myMimePartCollection As MimePartCollection = _
                  myMimeMultipartRelatedBinding.Parts
               Dim myMimePart As MimePart
               For Each myMimePart In  myMimePartCollection
                  Console.WriteLine("Extension Types added to MimePart: " & _
                     index.ToString()) 
                  Console.WriteLine("----------------------------")
                  index = index + 1
                  Dim myExtension As Object
                  For Each myExtension In myMimePart.Extensions
                     Console.WriteLine(myExtension.GetType())
                  Next myExtension
                  Console.WriteLine()
               Next myMimePart
               Exit For
            End If
         Next i
' </Snippet2>
      End Sub 'Main 
   End Class 'MyMimeContentClass
End Namespace 'MimeContentBinding_work
' </Snippet1>
