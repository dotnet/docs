' <snippet3>

Imports System
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.Text

Namespace Microsoft.WCF.Documentation
  <ServiceContract(Namespace:="http://microsoft.wcf.documentation")> _
  Public Interface ISampleService
	<OperationContract> _
	Function SampleMethod(ByVal msg As String) As String
  End Interface

  <SingletonBehavior> _
  Public Class SampleService
	  Implements ISampleService
  #Region "ISampleService Members"
	Private message As String

	Public Sub New(ByVal msg As String)
	  Me.message = msg
	End Sub

  Public Function SampleMethod(ByVal msg As String) As String Implements ISampleService.SampleMethod
	Console.WriteLine("The caller said: " & msg)
	   Return Me.message
  End Function

  #End Region
  End Class
End Namespace
' </snippet3>
