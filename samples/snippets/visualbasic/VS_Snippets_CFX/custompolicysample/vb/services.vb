Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.Text

Namespace Microsoft.WCF.Documentation
  <ServiceContract(Namespace:="http://microsoft.wcf.documentation", SessionMode:=SessionMode.Required)> _
  Public Interface IStatefulService
	<OperationContract> _
	Function GetSessionID() As String
  End Interface


  <ServiceBehavior(InstanceContextMode := InstanceContextMode.PerSession)> _
  Public Class StatefulService
	  Implements IStatefulService

	Private objectID As String = Nothing

	Private Sub New()
	  Me.objectID = Guid.NewGuid().ToString()
	  Console.WriteLine("Object {0} created.", Me.objectID)
	  Console.WriteLine("Session: {0}:", OperationContext.Current.SessionId)
	End Sub

Protected Overrides Sub Finalize()
	Console.WriteLine("Object {0} destroyed.", Me.objectID)
End Sub

	#Region "IStatefulService Members"

	Public Function GetSessionID() As String Implements IStatefulService.GetSessionID
            Return String.Format("{0}" & Constants.vbCrLf & "{1}" & Constants.vbCrLf, OperationContext.Current.SessionId, "objectID: " & Me.objectID)
	End Function

	#End Region
  End Class
End Namespace
