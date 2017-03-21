<Synchronization(SynchronizationOption.Required)>  _
Public Class ContextUtil_ApplicationInstanceId
    Inherits ServicedComponent
    
    Public Sub Example() 
        ' Display the ApplicationInstanceId associated with the current COM+
        ' context.
        MsgBox("Application Instance ID: " & ContextUtil.ApplicationInstanceId.ToString())

    
    End Sub 'Example
End Class 'ContextUtil_ApplicationInstanceId