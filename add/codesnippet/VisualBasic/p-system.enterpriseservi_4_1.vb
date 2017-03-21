<Synchronization(SynchronizationOption.Required)>  _
Public Class ContextUtil_ActivityId
    Inherits ServicedComponent
    
    Public Sub Example() 
        ' Display the ActivityID associated with the current COM+ context.
        MsgBox("Activity ID: " & ContextUtil.ActivityId.ToString())

    End Sub 'Example
End Class 'ContextUtil_ActivityId