Imports System

Public Class Sample    
    
' <Snippet1>
 Public Overridable Sub RaisePostDataChangedEvent()
     OnTextChanged(EventArgs.Empty)
 End Sub    
    
' </Snippet1>

    Public Sub OnTextChanged(e As EventArgs)
    End Sub
End Class