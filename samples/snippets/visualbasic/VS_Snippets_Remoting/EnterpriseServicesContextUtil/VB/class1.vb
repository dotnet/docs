 ' <snippet0>
Imports System
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

' <snippet1>
<Synchronization(SynchronizationOption.Required)>  _
Public Class ContextUtil_ActivityId
    Inherits ServicedComponent
    
    Public Sub Example() 
        ' Display the ActivityID associated with the current COM+ context.
        MsgBox("Activity ID: " & ContextUtil.ActivityId.ToString())

    End Sub 'Example
End Class 'ContextUtil_ActivityId
' </snippet1>

' <snippet2>
<Synchronization(SynchronizationOption.Required)>  _
Public Class ContextUtil_ApplicationInstanceId
    Inherits ServicedComponent
    
    Public Sub Example() 
        ' Display the ApplicationInstanceId associated with the current COM+
        ' context.
        MsgBox("Application Instance ID: " & ContextUtil.ApplicationInstanceId.ToString())

    
    End Sub 'Example
End Class 'ContextUtil_ApplicationInstanceId
' </snippet2>

' <snippet3>
<Transaction(TransactionOption.Required)>  _
Public Class ContextUtil_DisableCommit
    Inherits ServicedComponent
    
    Public Sub Example() 
        ' Set both the consistent bit and the done bit to false for the
        ' current COM+ context.
        ContextUtil.DisableCommit()
    
    End Sub 'Example
End Class 'ContextUtil_DisableCommit
' </snippet3>

' <snippet4>
<Transaction(TransactionOption.Required)>  _
Public Class ContextUtil_EnableCommit
    Inherits ServicedComponent
    
    Public Sub Example() 
        ' Set the consistent bit to true and the done bit to false for the
        ' current COM+ context.
        ContextUtil.EnableCommit()
    
    End Sub 'Example
End Class 'ContextUtil_EnableCommit
' </snippet4>

' <snippet5>
<Transaction(TransactionOption.Required)>  _
Public Class ContextUtil_IsInTransaction
    Inherits ServicedComponent
    
    Public Sub Example() 
        ' Display whether the current COM+ context is enlisted in a
        ' transaction.
        MsgBox("Current context enlisted in transaction: " & ContextUtil.IsInTransaction)

    End Sub 'Example
End Class 'ContextUtil_IsInTransaction
' </snippet5>

' <snippet6>
<SecurityRole("Role1")>  _
Public Class ContextUtil_IsSecurityEnabled
    Inherits ServicedComponent
    
    Public Sub Example() 
        ' Display whether role-based security is active for the current COM+
        ' context.
        MsgBox("Role-based security active in current context: " & ContextUtil.IsSecurityEnabled)

    End Sub 'Example
End Class 'ContextUtil_IsSecurityEnabled
' </snippet6>

' <snippet7>
<Transaction(TransactionOption.Required)>  _
Public Class ContextUtil_TransactionId
    Inherits ServicedComponent
    
    Public Sub Example() 
        ' Display the ID of the transaction in which the current COM+ context
        ' is enlisted.
        MsgBox("Transaction ID: " & ContextUtil.TransactionId.ToString())

    End Sub 'Example
End Class 'ContextUtil_TransactionId
' </snippet7>

' </snippet0>

'add Main so code compiles
Public Class Test

    Public Shared Sub Main()

    End Sub 'Main
End Class 'Test 


