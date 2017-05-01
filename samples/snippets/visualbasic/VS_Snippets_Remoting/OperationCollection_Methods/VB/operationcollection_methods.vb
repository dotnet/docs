' System.Web.Sevices.Description.OperationCollection
' System.Web.Sevices.Description.OperationCollection.Add
' System.Web.Sevices.Description.OperationCollection.Contains
' System.Web.Sevices.Description.OperationCollection.IndexOf
' System.Web.Sevices.Description.OperationCollection.Remove
' System.Web.Sevices.Description.OperationCollection.Insert
' System.Web.Sevices.Description.OperationCollection.Item
' System.Web.Sevices.Description.OperationCollection.CopyTo

' The following example demonstrates the usage of the
' 'OperationCollection' class , its property 'Item' and its methods
' 'Add', 'Contains', 'CopyTo', 'IndexOf', 'Insert' and 'Remove'.
' The input to the program is a WSDL file 'MathService_input_vb.wsdl'with
' information related to the 'Add' operation for the SOAP protocol,
' removed from it. It creates a new file 'MathService_new_vb.wsdl' with
' the added information about the 'Add' method.

' <Snippet1>
Option Strict On
Imports System
Imports System.Web.Services
Imports System.Xml
Imports System.Web.Services.Description

Class MyOperationCollectionSample
   Public Shared Sub Main()
      Try
         ' Read the 'MathService_Input_vb.wsdl' file.
         Dim myDescription As ServiceDescription = _
                        ServiceDescription.Read("MathService_Input_vb.wsdl")
         Dim myPortTypeCollection As PortTypeCollection = _
                                                   myDescription.PortTypes
         ' Get the 'OperationCollection' for 'SOAP' protocol.
' <Snippet2>
         Dim myOperationCollection As OperationCollection = _
                                         myPortTypeCollection(0).Operations
         Dim myOperation As New Operation()
         myOperation.Name = "Add"
         Dim myOperationMessageInput As OperationMessage = _
                              CType(New OperationInput(), OperationMessage)
         myOperationMessageInput.Message = New XmlQualifiedName _
                              ("AddSoapIn", myDescription.TargetNamespace)
         Dim myOperationMessageOutput As OperationMessage = _
                              CType(New OperationOutput(), OperationMessage)
         myOperationMessageOutput.Message = New XmlQualifiedName _
                              ("AddSoapOut", myDescription.TargetNamespace)
         myOperation.Messages.Add(myOperationMessageInput)
         myOperation.Messages.Add(myOperationMessageOutput)
         myOperationCollection.Add(myOperation)
' </Snippet2>

' <Snippet3>
' <Snippet4>
         If myOperationCollection.Contains(myOperation) = True Then
            Console.WriteLine("The index of the added 'myOperation' " + _
                     "operation is : " + _
                     myOperationCollection.IndexOf(myOperation).ToString)
         End If
' </Snippet4>
' </Snippet3>

' <Snippet5>
' <Snippet6>
' <Snippet7>
         myOperationCollection.Remove(myOperation)
         ' Insert the 'myOpearation' operation at the index '0'.
         myOperationCollection.Insert(0, myOperation)
         Console.WriteLine("The operation at index '0' is : " + _
                           myOperationCollection.Item(0).Name)
' </Snippet7>
' </Snippet6>
' </Snippet5>

' <Snippet8>
         Dim myOperationArray(myOperationCollection.Count) As Operation
         myOperationCollection.CopyTo(myOperationArray, 0)
         Console.WriteLine("The operation(s) in the collection are :")
         Dim i As Integer
         For i = 0 To myOperationCollection.Count - 1
            Console.WriteLine(" " + myOperationArray(i).Name)
         Next i
' </Snippet8>

         myDescription.Write("MathService_New_vb.wsdl")
      Catch e As Exception
         Console.WriteLine("Exception caught!!!")
         Console.WriteLine("Source : " + e.Source)
         Console.WriteLine("Message : " + e.Message)
      End Try
   End Sub
End Class
' </Snippet1>
