' System.Web.Services.Description.MimeTextMatch
' System.Web.Services.Description.MimeTextMatch.Capture
' System.Web.Services.Description.MimeTextMatch.Group
' System.Web.Services.Description.MimeTextMatch.Repeats
' System.Web.Services.Description.MimeTextMatch.RepeatsString

' The following program demostrates constructor, 'Capture', 'Group', 
' 'Repeats' and 'RepeatsString' properties of 'MimeTextMatch'class.
' It takes 'MimeTextMatch_5_Input_VB.wsdl' as input which does not
' contain 'Binding' object supporting 'HttpPost'. A text pattern 
' ''TITLE&gt;(.*?)&lt;' with text name as 'Title' and type
' name set which is to be searched in a HTTP transmission is added to the ServiceDescription.
' The modified ServiceDescription is written into 'MimeTextMatch_5_Output_VB.wsdl'.  

' <Snippet1>
Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml

Class MyMimeTextMatchClass
   
   Public Shared Sub Main()
      Try
         Dim myInt As Integer = 0
         Dim myServiceDescription As ServiceDescription = ServiceDescription.Read _
                                                      ("MimeTextMatch_5_Input_VB.wsdl")
         ' Create the 'Binding' object.
         Dim myBinding As New Binding()
         ' Initialize 'Name' property of 'Binding' class.
         myBinding.Name = "MimeTextMatchServiceHttpPost"
         Dim myXmlQualifiedName As New XmlQualifiedName("s0:MimeTextMatchServiceHttpPost")
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
         ' Add the 'HttpOperationBinding' object to 'OperationBinding'.
         myOperationBinding.Extensions.Add(myHttpOperationBinding)
' <Snippet5>
' <Snippet4>
' <Snippet3>  
' <Snippet2>
         ' Create an InputBinding.
         Dim myInputBinding As New InputBinding()
         Dim myMimeTextBinding As New MimeTextBinding()
         Dim myMimeTextMatchCollection1 As New MimeTextMatchCollection()
         Dim myMimeTextMatch(2) As MimeTextMatch
         myMimeTextMatchCollection1 = myMimeTextBinding.Matches

         ' Intialize the MimeTextMatch. 
         For myInt = 0 To 2

            ' Get a new MimeTextMatch.
            myMimeTextMatch(myInt) = New MimeTextMatch()

            ' Assign values to properties of the MimeTextMatch.
            myMimeTextMatch(myInt).Name = "Title" + Convert.ToString(myInt)
            myMimeTextMatch(myInt).Type = "*/*"
            myMimeTextMatch(myInt).Pattern = "TITLE&gt;(.*?)&lt;"
            myMimeTextMatch(myInt).IgnoreCase = True
            myMimeTextMatch(myInt).Capture = 2
            myMimeTextMatch(myInt).Group = 2
            If myInt <> 0 Then

               ' Assign the Repeats property if the index is not 0.
               myMimeTextMatch(myInt).Repeats = 2
            Else

               ' Assign the RepeatsString property if the index is 0.
               myMimeTextMatch(myInt).RepeatsString = "4"
            End If

            ' Add 'MimeTextMatch' instance to collection.
            myMimeTextMatchCollection1.Add(myMimeTextMatch(myInt))
         Next myInt
' </Snippet2>
' </Snippet3>
' </Snippet4>
' </Snippet5>
         myInputBinding.Extensions.Add(myMimeTextBinding)
         ' Add the 'InputBinding' to 'OperationBinding'.
         myOperationBinding.Input = myInputBinding
         ' Create the 'OutputBinding' instance.
         Dim myOutput As New OutputBinding()
         Dim postMimeXmlbinding As New MimeXmlBinding()
         ' Initialize 'Part' property of 'MimeXmlBinding' class. 
         postMimeXmlbinding.Part = "Body"
         ' Add 'MimeXmlBinding' instance to 'OutputBinding' instance.
         myOutput.Extensions.Add(postMimeXmlbinding)
         ' Add the 'OutPutBinding' to 'OperationBinding'.
         myOperationBinding.Output = myOutput
         ' Add the 'OutPutBinding' to 'OperationBinding'.
         myOperationBinding.Output = myOutput
         ' Add the 'OperationBinding' to 'Binding'.
         myBinding.Operations.Add(myOperationBinding)
         ' Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
         myServiceDescription.Bindings.Add(myBinding)
         ' Write the 'ServiceDescription' as a WSDL file.
         myServiceDescription.Write("MimeTextMatch_5_Output_VB.wsdl")
         Console.WriteLine("WSDL file with name 'MimeTextMatch_5_Output_VB.wsdl' is" + _
                                                " created successfully.")
      Catch e As Exception
         Console.WriteLine("Exception: {0}", e.Message)
      End Try
   End Sub 'Main
End Class 'MyMimeTextMatchClass
' </Snippet1>
