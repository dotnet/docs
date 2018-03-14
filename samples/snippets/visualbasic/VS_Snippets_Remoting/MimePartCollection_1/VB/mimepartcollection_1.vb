' System.Web.Services.Description.MimePartCollection

' The following program demostrates 'MimePartCollection' class. It 
' takes 'MimePartCollection_1_Input_vb.wsdl' as input which
' contains one 'MimePart' object that supports 'HttpPost'.
' A mimepartcollection object is created and mimepart is added to the 
' mimepartcollection at the specified location, finally writes 
' into the file'MimePartCollection_1_Output_VB.wsdl'.

' <Snippet1>
Imports System
Imports System.Collections
Imports System.Xml
Imports System.Web.Services.Description

Public Class MyMimePartCollection
   
   Public Shared Sub Main()
      Dim myServiceDescription As ServiceDescription = ServiceDescription.Read _
                                             ("MimePartCollection_1_Input_vb.wsdl")
      Dim myServiceDescriptionCol As New ServiceDescriptionCollection()
      myServiceDescriptionCol.Add(myServiceDescription)
      Dim myXmlQualifiedName As New XmlQualifiedName("MimeServiceHttpPost", "http://tempuri.org/")
      ' Create a 'Binding' object.
      Dim myBinding As Binding = myServiceDescriptionCol.GetBinding(myXmlQualifiedName)
      Dim myOperationBinding As OperationBinding = Nothing
      Dim i As Integer
      For i = 0 To myBinding.Operations.Count - 1
         If myBinding.Operations(i).Name.Equals("AddNumbers") Then
            myOperationBinding = myBinding.Operations(i)
         End If
      Next i
      Dim myOutputBinding As OutputBinding = myOperationBinding.Output
      Dim myMimeMultipartRelatedBinding As MimeMultipartRelatedBinding = Nothing
      Dim myIEnumerator As IEnumerator = myOutputBinding.Extensions.GetEnumerator()
      While myIEnumerator.MoveNext()
         myMimeMultipartRelatedBinding = CType(myIEnumerator.Current, MimeMultipartRelatedBinding)
      End While
      ' Create an instances of 'MimePartCollection'.
      Dim myMimePartCollection As New MimePartCollection()
      myMimePartCollection = myMimeMultipartRelatedBinding.Parts
      
      Console.WriteLine("Total number of mimepart elements initially is: " + _
                                          myMimePartCollection.Count.ToString())
      ' Create an instance of 'MimePart'.
      Dim myMimePart As New MimePart()
      ' Create an instance of 'MimeXmlBinding'.
      Dim myMimeXmlBinding As New MimeXmlBinding()
      myMimeXmlBinding.Part = "body"
      myMimePart.Extensions.Add(myMimeXmlBinding)
      ' Insert a mimepart at first position.
      myMimePartCollection.Insert(0, myMimePart)
      Console.WriteLine("Inserting a mimepart object...")
      If myMimePartCollection.Contains(myMimePart) Then
         Console.WriteLine("'MimePart' is succesffully added at position: " + _
                                             myMimePartCollection.IndexOf(myMimePart).ToString())
         Console.WriteLine("Total number of mimepart elements after inserting is: " + _
                                                myMimePartCollection.Count.ToString())
      End If
      myServiceDescription.Write("MimePartCollection_1_Output_VB.wsdl")
      Console.WriteLine("MimePartCollection_1_Output_VB.wsdl has been generated successfully.")
   End Sub 'Main
End Class 'MyMimePartCollection
' </Snippet1>