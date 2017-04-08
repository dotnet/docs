' System.Web.Services.Description.MimeContentBinding.Type
' System.Web.Services.Description.MimeContentBinding.Part
' System.Web.Services.Description.MimeContentBinding.NameSpace
' System.Web.Services.Description.MimeContentBinding

' The following program demonstrates properties 'Type','Part'
' and field 'NameSpace'of class 'MimeContentBinding'.It reads 'MimeContentSample_vb.wsdl'file
' and instantiates a ServiceDescription object.'MimeContentBinding' objects  are retrieved from Extension
' points of OutputBinding for one of the Binding object and its properties 'Type','Part'are displayed.
' It also displays 'NameSpace' of the 'MimeContentBinding' object.

' <Snippet4>
Imports System
Imports System.Web.Services.Description

Namespace MimeContentBinding_work

   Class MyMimeContentClass
      
      Shared Sub Main()
' <Snippet1>
' <Snippet2>
' <Snippet3>
         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read ("MimeContentSample_vb.wsdl")

         ' Get the Binding.
         Dim myBinding As Binding = myServiceDescription.Bindings("b1")

         ' Get the first OperationBinding.
         Dim myOperationBinding As OperationBinding = myBinding.Operations(0)
         Dim myOutputBinding As OutputBinding = myOperationBinding.Output
         Dim myServiceDescriptionFormatExtensionCollection As _
            ServiceDescriptionFormatExtensionCollection = _
            myOutputBinding.Extensions

         ' Find all MimeContentBinding objects in extensions.
         Dim myMimeContentBindings As MimeContentBinding() = _
            CType(myServiceDescriptionFormatExtensionCollection.FindAll( _
            GetType(MimeContentBinding)), MimeContentBinding())

         ' Enumerate the array and display MimeContentBinding properties.
         Dim myMimeContentBinding As MimeContentBinding
         For Each myMimeContentBinding In  myMimeContentBindings
            Console.WriteLine("Type: " & myMimeContentBinding.Type)
            Console.WriteLine("Part: " & myMimeContentBinding.Part)
         Next myMimeContentBinding
' </Snippet1>
' </Snippet2>
         Console.WriteLine("Namespace: " & MimeContentBinding.Namespace)
' </Snippet3>
      End Sub 'Main 
   End Class 'MyMimeContentClass
End Namespace 'MimeContentBinding_work
' </Snippet4>
