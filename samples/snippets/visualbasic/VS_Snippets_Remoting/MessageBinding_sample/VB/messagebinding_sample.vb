' System.Web.Services.Description.MessageBinding
' System.Web.Services.Description.MessageBinding.MessageBinding();
' System.Web.Services.Description.MessageBinding.Extensions;
' System.Web.Services.Description.MessageBinding.Name;

' The following program demonstrates the abstract class 'MessageBinding', it's constructor
' MessageBinding()and properties 'Extensions' and 'Name'.'MessageBinding' is an abstract class
' from which 'InputBinding' , 'OutputBinding' are derived.The program contains a utility function
' which could be used to create either an InputBinding or OutputBinding.This generic nature is
' achieved by returning an instance of 'MessageBinding'.
' <Snippet1>
Imports System
Imports System.Web.Services.Description

Class MyClass1

   Public Shared Sub Main()
      Dim addOperationBinding As OperationBinding = _
         CreateOperationBinding("Add", "http://tempuri.org/")
   End Sub 'Main

   Public Shared Function CreateInputOutputBinding(myBindName As String, _
      isInputBinding As Boolean) As MessageBinding
' <Snippet2>
      ' Value isInputBinding = true ---> return type = InputBinding.
      ' Value isInputBinding = false --> return type = OutputBinding.
' <Snippet3>
' <Snippet4>
      Dim myMessageBinding As MessageBinding = Nothing
      Select Case isInputBinding
         Case True
            myMessageBinding = New InputBinding()
            Console.WriteLine("Added an InputBinding")
         Case False
            myMessageBinding = New OutputBinding()
            Console.WriteLine("Added an OutputBinding")
      End Select
' </Snippet2>
      myMessageBinding.Name = myBindName
      Dim mySoapBodyBinding As New SoapBodyBinding()
      mySoapBodyBinding.Use = SoapBindingUse.Literal
      myMessageBinding.Extensions.Add(mySoapBodyBinding)
      Console.WriteLine("Added extensibility element of type: " & _
         mySoapBodyBinding.GetType().ToString())
' </Snippet3>
' </Snippet4>
      Return myMessageBinding
   End Function 'CreateInputOutputBinding

   ' Used to create OperationBinding instances within Binding.
   Public Shared Function CreateOperationBinding(myOperation As String, _
      targetNamespace As String) As OperationBinding

      ' Create OperationBinding for operation.
      Dim myOperationBinding As New OperationBinding()
      myOperationBinding.Name = myOperation

      ' Create InputBinding for operation.
      Dim myInputBinding As InputBinding = _
         CType(CreateInputOutputBinding(Nothing, True), InputBinding)
      ' Create OutputBinding for operation.
      Dim myOutputBinding As OutputBinding = _
         CType(CreateInputOutputBinding(Nothing, False), OutputBinding)

      ' Add InputBinding and OutputBinding to OperationBinding.
      myOperationBinding.Input = myInputBinding
      myOperationBinding.Output = myOutputBinding

      ' Create an extensibility element for SoapOperationBinding.
      Dim mySoapOperationBinding As New SoapOperationBinding()
      mySoapOperationBinding.Style = SoapBindingStyle.Document
      mySoapOperationBinding.SoapAction = targetNamespace + myOperation

      ' Add the extensibility element SoapOperationBinding to OperationBinding.
      myOperationBinding.Extensions.Add(mySoapOperationBinding)
      Return myOperationBinding
   End Function 'CreateOperationBinding
End Class 'MyClass1
' </Snippet1>
