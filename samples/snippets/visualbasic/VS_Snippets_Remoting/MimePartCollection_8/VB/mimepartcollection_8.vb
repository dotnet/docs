' System.Web.Services.Description.MimePartCollection.MimePartCollection()
' System.Web.Services.Description.MimePartCollection.Item[System.Int32 index]
' System.Web.Services.Description.MimePartCollection.Insert
' System.Web.Services.Description.MimePartCollection.IndexOf
' System.Web.Services.Description.MimePartCollection.Add
' System.Web.Services.Description.MimePartCollection.Contains
' System.Web.Services.Description.MimePartCollection.CopyTo
' System.Web.Services.Description.MimePartCollection.Remove

' This program demostrates constructor, 'Item' property ,'Insert','IndexOf','Add',
' 'Contains','CopyTo',and 'Remove' methods of 'MimePartCollection' class.
' It takes 'MimePartCollection_8_Input_vb.wsdl' as an input file which contains 
' one 'MimePart' object that supports 'HttpPost'. A mimepartcollection object is 
' created and new mimepart objects are added to mimepartcollection using 'Insert' 
' and 'Add' methods. A mimepart object is removed from the mimepartcollection using 
' 'Remove'method.The ServiceDescription is finally written into output wsdl file
' 'MimePartCollection_8_out_vb.wsdl'.

Imports System
Imports System.Collections
Imports System.Xml
Imports System.Web.Services.Description

Public Class MyMimePartCollection
   
   Public Shared Sub Main()
      Dim myServiceDescription As ServiceDescription = ServiceDescription.Read _
                                          ("MimePartCollection_8_Input_vb.wsdl")
      Dim myServiceDescriptionCol As New ServiceDescriptionCollection()
      myServiceDescriptionCol.Add(myServiceDescription)
      Dim myXmlQualifiedName As New XmlQualifiedName("MimeServiceHttpPost", "http://tempuri.org/")
      ' Create a binding object.
      Dim myBinding As Binding = myServiceDescriptionCol.GetBinding(myXmlQualifiedName)
      Dim myOperationBinding As OperationBinding = Nothing
      Dim i As Integer
      For i = 0 To myBinding.Operations.Count - 1
         If myBinding.Operations(i).Name.Equals("AddNumbers") Then
            myOperationBinding = myBinding.Operations(i)
         End If
      Next i
      Dim myOutputBinding As OutputBinding = myOperationBinding.Output
' <Snippet1>
' <Snippet2>
' <Snippet3>
' <Snippet4>
      Dim myMimeMultipartRelatedBinding As MimeMultipartRelatedBinding = Nothing
      Dim myIEnumerator As IEnumerator = myOutputBinding.Extensions.GetEnumerator()
      While myIEnumerator.MoveNext()
         myMimeMultipartRelatedBinding = CType(myIEnumerator.Current, MimeMultipartRelatedBinding)
      End While
      ' Create an instance of 'MimePartCollection'.
      Dim myMimePartCollection As New MimePartCollection()
      myMimePartCollection = myMimeMultipartRelatedBinding.Parts
      Console.WriteLine("Total number of mimepart elements in the collection initially" + _
                                                   " is: " + myMimePartCollection.Count.ToString())
      ' Get the type of first 'Item' in collection.
      Console.WriteLine("The first object in collection is of type: " + _
                                                            myMimePartCollection.Item(0).ToString())
      Dim myMimePart1 As New MimePart()
      ' Create an instance of 'MimeXmlBinding'.
      Dim myMimeXmlBinding1 As New MimeXmlBinding()
      myMimeXmlBinding1.Part = "body"
      myMimePart1.Extensions.Add(myMimeXmlBinding1)
      '  a mimepart at first position.
      myMimePartCollection.Insert(0, myMimePart1)
      Console.WriteLine("Inserting a mimepart object...")
      ' Check whether 'Insert' was successful or not.
      If myMimePartCollection.Contains(myMimePart1) Then
         ' Display the index of inserted 'MimePart'.
         Console.WriteLine("'MimePart' is succesfully inserted at position: " + _
                                            myMimePartCollection.IndexOf(myMimePart1).ToString())
      End If
' </Snippet4>
' </Snippet3>
' </Snippet2>
' </Snippet1>
      Console.WriteLine("Total number of mimepart elements after inserting is: " + _
                                                      myMimePartCollection.Count.ToString())
      
' <Snippet5>
' <Snippet6>
      Dim myMimePart2 As New MimePart()
      Dim myMimeXmlBinding2 As New MimeXmlBinding()
      myMimeXmlBinding2.Part = "body"
      myMimePart2.Extensions.Add(myMimeXmlBinding2)
      ' Add a mimepart to the mimepartcollection.
      myMimePartCollection.Add(myMimePart2)
      Console.WriteLine("Adding a mimepart object...")
      ' Check if collection contains added mimepart object.
      If myMimePartCollection.Contains(myMimePart2) Then
         Console.WriteLine("'MimePart' is succesfully added at position: " + _
                        myMimePartCollection.IndexOf(myMimePart2).ToString())
      End If
' </Snippet6>
' </Snippet5>
      Console.WriteLine("Total number of mimepart elements after adding is: " + _
                                             myMimePartCollection.Count.ToString())
      
' <Snippet7>
      Dim myArray(myMimePartCollection.Count-1) As MimePart
      ' Copy the mimepartcollection to an array.
      myMimePartCollection.CopyTo(myArray, 0)
      Console.WriteLine("Displaying the array copied from mimepartcollection")
      Dim j As Integer
      For j = 0 To myMimePartCollection.Count - 1
         Console.WriteLine("Mimepart object at position : " + j.ToString())
         For i = 0 To (myArray(j).Extensions.Count) - 1
            Dim myMimeXmlBinding3 As MimeXmlBinding = CType(myArray(j).Extensions(i), _
                                                                           MimeXmlBinding)
            Console.WriteLine("Part: " + myMimeXmlBinding3.Part)
         Next i
      Next j
' </Snippet7> 
' <Snippet8>
      Console.WriteLine("Removing a mimepart object...")
      ' Remove the mimepart from the mimepartcollection.
      myMimePartCollection.Remove(myMimePart1)
      ' Check whether the mimepart is removed or not.
      If Not myMimePartCollection.Contains(myMimePart1) Then
         Console.WriteLine("Mimepart is succesfully removed from mimepartcollection")
      End If
' </Snippet8>
      Console.WriteLine("Total number of elements in collection after removing is: " + _
                                                            myMimePartCollection.Count.ToString())
      Dim myArray1(myMimePartCollection.Count-1) As MimePart
      myMimePartCollection.CopyTo(myArray1, 0)
      Console.WriteLine("Dispalying the 'MimePartCollection' after removing")
      For j = 0 To myMimePartCollection.Count - 1
         Console.WriteLine("Mimepart object at position :" + j.ToString())
         For i = 0 To (myArray1(j).Extensions.Count) - 1
            Dim myMimeXmlBinding3 As MimeXmlBinding = CType(myArray1(j).Extensions(i), _
                                                                        MimeXmlBinding)
            Console.WriteLine("part:  " + myMimeXmlBinding3.Part)
         Next i
      Next j
      myServiceDescription.Write("MimePartCollection_8_output.wsdl")
      Console.WriteLine("MimePartCollection_8_output.wsdl has been generated successfully.")
   End Sub 'Main
End Class 'MyMimePartCollection

