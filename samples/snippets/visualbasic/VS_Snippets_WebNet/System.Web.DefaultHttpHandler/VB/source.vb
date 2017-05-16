Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Threading

' <Snippet1>
Public Class defaulthttpexampleVB
    Inherits DefaultHttpHandler

    Private _context As HttpContext

    Public Overrides Function BeginProcessRequest _
        (ByVal context As HttpContext, _
         ByVal callback As AsyncCallback, _
         ByVal state As Object) As IAsyncResult

        Dim ar As New AsyncResultSample(callback, state)
        _context = context

        Return (ar)
    End Function

    Public Overrides Sub EndProcessRequest(ByVal result As IAsyncResult)
        _context.Response.Write("EndProcessRequest called.")
    End Sub

    ' This method should not be called asynchronously.
    Public Overrides Sub ProcessRequest(ByVal context As HttpContext)
        Throw New InvalidOperationException _
          ("Asynchronous processing failed.")
    End Sub

    ' Enables pooling when set to true
    Public Overrides ReadOnly Property IsReusable() As Boolean
        Get
            Return True
        End Get
    End Property
End Class

' Tracks state between the begin and end calls.
Class AsyncResultSample
    Implements IAsyncResult
    Private callback As AsyncCallback = Nothing
    Private _asyncState As Object
    Private _isCompleted As Boolean

    Friend Sub New(ByVal cb As AsyncCallback, ByVal state As Object)
        Me.callback = cb
        _asyncState = state
        _isCompleted = False
    End Sub

    Public ReadOnly Property AsyncState() As Object _
      Implements IAsyncResult.AsyncState
        Get
            Return _asyncState
        End Get
    End Property

    Public ReadOnly Property CompletedSynchronously() _
      As Boolean Implements IAsyncResult.CompletedSynchronously
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property AsyncWaitHandle() _
      As WaitHandle Implements IAsyncResult.AsyncWaitHandle
        Get
            Throw New InvalidOperationException _
              ("ASP.NET should not use this property .")
        End Get
    End Property

    Public ReadOnly Property IsCompleted() _
      As Boolean Implements IAsyncResult.IsCompleted
        Get
            Return IsCompleted
        End Get
    End Property

    Friend Sub SetCompleted()
        _isCompleted = True
        If (callback <> Nothing) Then
            callback(Me)
        End If
    End Sub
End Class
' </Snippet1>
