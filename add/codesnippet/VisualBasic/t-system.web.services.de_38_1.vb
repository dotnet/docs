Imports System
Imports System.Xml
Imports System.Web.Services.Description

Public Class MyMimePart
   Public Shared Sub Main()
      Dim myServiceDescription As ServiceDescription = _
         ServiceDescription.Read("MimePart_3_Input_vb.wsdl")
      Dim myServiceDescriptionCol As New ServiceDescriptionCollection()
      myServiceDescriptionCol.Add(myServiceDescription)
      Dim myXmlQualifiedName As _
         New XmlQualifiedName("MimeServiceHttpPost", "http://tempuri.org/")

      ' Create the Binding.
      Dim myBinding As Binding = _
         myServiceDescriptionCol.GetBinding(myXmlQualifiedName)
      Dim myOperationBinding As OperationBinding = Nothing
      Dim i As Integer
      For i = 0 To myBinding.Operations.Count - 1
         If myBinding.Operations(i).Name.Equals("AddNumbers") Then
            myOperationBinding = myBinding.Operations(i)
         End If
      Next i
      ' Create the OutputBinding.
      Dim myOutputBinding As OutputBinding = myOperationBinding.Output
      Dim myMimeXmlBinding As New MimeXmlBinding()
      myMimeXmlBinding.Part = "body"

      ' Create the MimePart.
      Dim myMimePart As New MimePart()
      myMimePart.Extensions.Add(myMimeXmlBinding)
      Dim myMimePartRelatedBinding As New MimeMultipartRelatedBinding()

      ' Add the MimePart to the MimePartRelatedBinding.
      myMimePartRelatedBinding.Parts.Add(myMimePart)
      myOutputBinding.Extensions.Add(myMimePartRelatedBinding)
      myServiceDescription.Write("MimePart_3_Output_vb.wsdl")
      Console.WriteLine( _
         "MimePart_3_Output_vb.wsdl has been generated successfully.")
   End Sub 'Main
End Class 'MyMimePart