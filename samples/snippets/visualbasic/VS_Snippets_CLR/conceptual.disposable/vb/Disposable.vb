Public Class Disposable : Implements IDisposable

    Dim disposed As Boolean
    ' <SnippetDispose>
    Public Sub Dispose() _
        Implements IDisposable.Dispose
        ' Dispose of unmanaged resources.
        Dispose(True)
        ' Suppress finalization.
        GC.SuppressFinalize(Me)
    End Sub
    ' </SnippetDispose>

    ' <SnippetDisposeBool>
   Protected Overridable Sub Dispose(disposing As Boolean)
		If disposed Then Exit Sub	

		' A block that frees unmanaged resources.
		
		If disposing Then
			' Deterministic call…
    		' A conditional block that frees managed resources.    	
		End If
		
		disposed = True
   End Sub
    ' </SnippetDisposeBool>

End Class
