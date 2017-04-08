' <snippet9>

Imports System
Imports System.Collections.Generic
Imports System.ServiceModel.Dispatcher
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms

Namespace Microsoft.WCF.Documentation
  ' <snippet8>
  Public Class InteractiveChannelInitializer
	  Implements IInteractiveChannelInitializer
	#Region "IInteractiveChannelInitializer Members"
'    
'      To implement IInteractiveChannelInitializer, perform the following steps 
'      in IInteractiveChannelInitializer.BeginDisplayInitializationUI:
'
'      1. Prompt the user and obtain an appropriate System.Net.NetworkCredential. 
'      2. Add a custom channel parameter object to the collection returned by the 
'          IChannel.GetProperty method on the IClientChannel object with a type 
'          parameter of System.ServiceModel.Channels.ChannelParameterCollection. 
'          This channel parameter object is used by the custom 
'          System.ServiceModel.ClientCredentialsSecurityTokenManager to establish 
'         the security tokens for the channel.
'      3. Return. 
'
'    
	Public Function BeginDisplayInitializationUI(ByVal channel As System.ServiceModel.IClientChannel, ByVal callback As AsyncCallback, ByVal state As Object) As IAsyncResult Implements IInteractiveChannelInitializer.BeginDisplayInitializationUI
	  ' This implementation merely displays a message to the user and performs no behavior.
	  MessageBox.Show("IInteractiveChannelInitializer called. Click OK to continue...")
	  Return New DisplayCompletedAsyncResult(Of String)("The initialization asyncresult.")
	End Function

	Public Sub EndDisplayInitializationUI(ByVal result As IAsyncResult) Implements IInteractiveChannelInitializer.EndDisplayInitializationUI
	  Dim realResult As DisplayCompletedAsyncResult(Of String) = TryCast(result, DisplayCompletedAsyncResult(Of String))
	  Console.WriteLine("EndDisplayInitializationUI called, returning:" & realResult.Data)
	End Sub
	#End Region
  End Class
  ' </snippet8>


  Friend Class DisplayCompletedAsyncResult(Of T)
	  Implements IAsyncResult
	Private data_Renamed As T

	Public Sub New(ByVal data As T)
	  Me.data_Renamed = data
	End Sub

	Public ReadOnly Property Data() As T
	  Get
		  Return data_Renamed
	  End Get
	End Property

	#Region "IAsyncResult Members"

	Public ReadOnly Property AsyncState() As Object Implements IAsyncResult.AsyncState
	  Get
		  Return CObj(data_Renamed)
	  End Get
	End Property

	Public ReadOnly Property AsyncWaitHandle() As WaitHandle Implements IAsyncResult.AsyncWaitHandle
	  Get
		  Throw New Exception("The method or operation is not implemented.")
	  End Get
	End Property

	Public ReadOnly Property CompletedSynchronously() As Boolean Implements IAsyncResult.CompletedSynchronously
	  Get
		  Return True
	  End Get
	End Property

	Public ReadOnly Property IsCompleted() As Boolean Implements IAsyncResult.IsCompleted
	  Get
		  Return True
	  End Get
	End Property

	#End Region
  End Class
End Namespace
' </snippet9>
