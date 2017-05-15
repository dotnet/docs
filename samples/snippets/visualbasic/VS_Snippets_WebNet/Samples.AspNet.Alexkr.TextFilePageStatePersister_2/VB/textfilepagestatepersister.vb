' <snippet1>
Imports System
Imports System.IO
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI

Namespace Samples.AspNet.VB

    ' The StreamPageStatePersister is an example view state
    ' persistence mechanism that persists view and control
    ' state on the Web server.
    '
    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class StreamPageStatePersister
        Inherits PageStatePersister


        Public Sub New(ByVal page As Page)
            MyBase.New(page)
        End Sub 'New

        ' <snippet2>
        '
        ' Load ViewState and ControlState.
        '
        Public Overrides Sub Load()

            Dim stateStream As Stream
            stateStream = GetSecureStream()
            ' <snippet4>

            ' Read the state string, using the StateFormatter.
            Dim reader As New StreamReader(stateStream)

            Dim serializedStatePair As String
            serializedStatePair = reader.ReadToEnd
            Dim statePair As Pair

            Dim formatter As IStateFormatter
            formatter = Me.StateFormatter

            ' Deserilize returns the Pair object that is serialized in
            ' the Save method.      
            statePair = CType(formatter.Deserialize(serializedStatePair), Pair)

            ViewState = statePair.First
            ControlState = statePair.Second
            ' </snippet4>
            reader.Close()
            stateStream.Close()
        End Sub ' Load

        ' </snippet2>
        ' <snippet3>
        '
        ' Persist any ViewState and ControlState.
        '
        Public Overrides Sub Save()

            If Not (ViewState Is Nothing) OrElse Not (ControlState Is Nothing) Then
                If Not (Page.Session Is Nothing) Then

                    Dim stateStream As Stream
                    stateStream = GetSecureStream()

                    ' Write a state string, using the StateFormatter.
                    Dim writer As New StreamWriter(stateStream)

                    Dim formatter As IStateFormatter
                    formatter = Me.StateFormatter

                    Dim statePair As New Pair(ViewState, ControlState)

                    Dim serializedState As String
                    serializedState = formatter.Serialize(statePair)

                    writer.Write(serializedState)
                    writer.Close()
                    stateStream.Close()
                Else
                    Throw New InvalidOperationException("Session needed for StreamPageStatePersister.")
                End If
            End If
        End Sub 'Save
        ' </snippet3>
        ' Return a secure Stream for your environment.
        Private Function GetSecureStream() As Stream
            ' You must provide the implementation to build
            ' a secure Stream for your environment.
            Return Nothing
        End Function
    End Class
End Namespace
' </snippet1>