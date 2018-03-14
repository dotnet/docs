' System.Web.Services.Description.MimeTextMatchCollection
' System.Web.Services.Description.MimeTextMatchCollection()
' System.Web.Services.Description.MimeTextMatchCollection.Contains
' System.Web.Services.Description.MimeTextMatchCollection.Add
' System.Web.Services.Description.MimeTextMatchCollection.CopyTo
' System.Web.Services.Description.MimeTextMatchCollection.Remove
' System.Web.Services.Description.MimeTextMatchCollection.Item
' System.Web.Services.Description.MimeTextMatchCollection.IndexOf
' System.Web.Services.Description.MimeTextMatchCollection.Insert

'   This program demostrates constructor, Contains, Add, Item,
'   IndexOf, Insert and Remove property of 'MimeTextMatchCollection'.
'   This program takes 'MimeText_Match_MatchColl_9_Input_vb.wsdl' as an
'   input file which does not contain 'Binding' object that supports 
'   'HttpPost'. A name, type, Group and Capture properties are set 
'   which are to be searched in a HTTP transmission and 
'   'MimeTextMatchCollection' collection object is created 
'   for input and output of 'HttpPost' and finally writes into 
'   'MimeText_Match_MatchColl_9_Output_vb.wsdl'.

Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Class MyMimeTextMatchCollection
   Public Shared Sub Main()
      Try
         Dim myInt As Integer = 0
         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("MimeText_Match_MatchColl_9_Input_vb.wsdl")
         ' Create the 'Binding' object.
         Dim myBinding As New Binding()
         ' Initialize 'Name' property of 'Binding' class.
         myBinding.Name = "MimeText_Match_MatchCollServiceHttpPost"
         Dim myXmlQualifiedName As _
               New XmlQualifiedName("s0:MimeText_Match_MatchCollServiceHttpPost")
         myBinding.Type = myXmlQualifiedName
         ' Create the 'HttpBinding' object.
         Dim myHttpBinding As New HttpBinding()
         myHttpBinding.Verb = "POST"
         ' Add the 'HttpBinding' to the 'Binding'.
         myBinding.Extensions.Add(myHttpBinding)
         ' Create the 'OperationBinding' object.
         Dim myOperationBinding As New OperationBinding()
         myOperationBinding.Name = "AddNumbers"
         Dim myHttpOperationBinding As New HttpOperationBinding()
         myHttpOperationBinding.Location = "/AddNumbers"
         ' Add the 'HttpOperationBinding' to 'OperationBinding'.
         myOperationBinding.Extensions.Add(myHttpOperationBinding)
' <Snippet1>
         ' Create the 'InputBinding' object.
         Dim myInputBinding As New InputBinding()
         Dim myMimeTextBinding As New MimeTextBinding()
         Dim myMimeTextMatchCollection As MimeTextMatchCollection
' <Snippet5>
' <Snippet4>
' <Snippet3>
         ' Get an array instance of 'MimeTextMatch' class.
         Dim myMimeTextMatch(3) As MimeTextMatch
         myMimeTextMatchCollection = myMimeTextBinding.Matches
         ' Initialize properties of 'MimeTextMatch' class.
         For myInt = 0 To 3
            ' Create the 'MimeTextMatch' instance.
            myMimeTextMatch(myInt) = New MimeTextMatch()
            myMimeTextMatch(myInt).Name = "Title"
            myMimeTextMatch(myInt).Type = "*/*"
            myMimeTextMatch(myInt).IgnoreCase = True

            If True = myMimeTextMatchCollection.Contains(myMimeTextMatch(0)) Then
               myMimeTextMatch(myInt).Name = "Title" + Convert.ToString(myInt)
               myMimeTextMatch(myInt).Capture = 2
               myMimeTextMatch(myInt).Group = 2
               myMimeTextMatchCollection.Add(myMimeTextMatch(myInt))
            Else
               myMimeTextMatchCollection.Add(myMimeTextMatch(myInt))
               myMimeTextMatchCollection(myInt).RepeatsString = "2"
            End If
         Next myInt
         myMimeTextMatchCollection = myMimeTextBinding.Matches
         ' Copy collection to 'MimeTextMatch' array instance.
         myMimeTextMatchCollection.CopyTo(myMimeTextMatch, 0)
' </Snippet3>
' </Snippet4>
' </Snippet5>
         myInputBinding.Extensions.Add(myMimeTextBinding)
         ' Add the 'InputBinding' to 'OperationBinding'.
         myOperationBinding.Input = myInputBinding

         ' Create the 'OutputBinding' instance.
         Dim myOutputBinding As New OutputBinding()
         ' Create the 'MimeTextBinding' instance.
         Dim myMimeTextBinding1 As New MimeTextBinding()
' <Snippet9>
' <Snippet8>
' <Snippet7>
' <Snippet6>
' <Snippet2>
         ' Get an instance of 'MimeTextMatchCollection'.
         Dim myMimeTextMatchCollection1 As New MimeTextMatchCollection()
         Dim myMimeTextMatch1(4) As MimeTextMatch
         myMimeTextMatchCollection1 = myMimeTextBinding1.Matches
         For myInt = 0 To 3
            myMimeTextMatch1(myInt) = New MimeTextMatch()
            myMimeTextMatch1(myInt).Name = "Title" + Convert.ToString(myInt)
            If myInt <> 0 Then
               myMimeTextMatch1(myInt).RepeatsString = "7"
            End If
            myMimeTextMatchCollection1.Add(myMimeTextMatch1(myInt))
         Next myInt
         myMimeTextMatch1(4) = New MimeTextMatch()
         ' Remove 'MimeTextMatch' instance from collection.
         myMimeTextMatchCollection1.Remove(myMimeTextMatch1(1))
         ' Using MimeTextMatchCollection.Item indexer to comapre. 
         If myMimeTextMatch1(2) Is myMimeTextMatchCollection1(1) Then
            ' Check whether 'MimeTextMatch' instance exists. 
            myInt = myMimeTextMatchCollection1.IndexOf(myMimeTextMatch1(2))
            ' Insert 'MimeTextMatch' instance at a desired position.
            myMimeTextMatchCollection1.Insert(1, myMimeTextMatch1(myInt))
            myMimeTextMatchCollection1(1).RepeatsString = "5"
            myMimeTextMatchCollection1.Insert(4, myMimeTextMatch1(myInt))
         End If
' </Snippet2>
' </Snippet6>
' </Snippet7>
' </Snippet8>
' </Snippet9>
' </Snippet1>
         myOutputBinding.Extensions.Add(myMimeTextBinding1)
         ' Add the 'OutPutBinding' to 'OperationBinding'.
         myOperationBinding.Output = myOutputBinding
         ' Add the 'OutPutBinding' to 'OperationBinding'.
         myOperationBinding.Output = myOutputBinding
         ' Add the 'OperationBinding' to 'Binding'.
         myBinding.Operations.Add(myOperationBinding)
         ' Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
         myServiceDescription.Bindings.Add(myBinding)
         ' Write the 'ServiceDescription' as a WSDL file.
         myServiceDescription.Write("MimeText_Match_MatchColl_9_Output_vb.wsdl")
         Console.WriteLine("WSDL file with name " + _
                           "'MimeText_Match_MatchColl_9_Output_vb.wsdl' is" + _
                           " created successfully.")
      Catch e As Exception
         Console.WriteLine("Exception: {0}", e.Message)
      End Try
   End Sub 'Main
End Class 'MyMimeTextMatchCollection