Imports System.Activities

'<snippet1>
Public NotInheritable Class ReadInt
    Inherits NativeActivity(Of Integer)

    <RequiredArgument()>
    Property BookmarkName() As InArgument(Of String)

    Protected Overrides Sub Execute(ByVal context As NativeActivityContext)
        Dim name As String
        name = BookmarkName.Get(context)

        If name = String.Empty Then
            Throw New Exception("BookmarkName cannot be an Empty string.")
        End If

        context.CreateBookmark(name, New BookmarkCallback(AddressOf OnReadComplete))
    End Sub

    ' NativeActivity derived activities that do asynchronous operations by calling 
    ' one of the CreateBookmark overloads defined on System.Activities.NativeActivityContext 
    ' must override the CanInduceIdle property and return True.
    Protected Overrides ReadOnly Property CanInduceIdle As Boolean
        Get
            Return True
        End Get
    End Property

    Sub OnReadComplete(ByVal context As NativeActivityContext, ByVal bookmark As Bookmark, ByVal state As Object)
        Result.Set(context, Convert.ToInt32(state))
    End Sub

End Class
'</snippet1>
