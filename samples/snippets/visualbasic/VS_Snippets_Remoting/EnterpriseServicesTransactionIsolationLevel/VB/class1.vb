 ' <snippet0>
Imports System
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

' An instance of this class will inherit its caller's transaction isolation
' level if available. If not, it will use isolation level Serializable.
<Transaction(Isolation := TransactionIsolationLevel.Any)>  _
Public Class TransactionAttribute_IsolationAny
    Inherits ServicedComponent
End Class 'TransactionAttribute_IsolationAny

' An instance of this class will read only committed data, but non-repeatable
' reads and phantom rows are still possible.
<Transaction(Isolation := TransactionIsolationLevel.ReadCommitted)>  _
Public Class TransactionAttribute_IsolationReadCommitted
    Inherits ServicedComponent
End Class 'TransactionAttribute_IsolationReadCommitted

' An instance of this class will read committed and uncommitted data, so dirty
' reads, non-repeatable reads, and phantom rows are possible.
<Transaction(Isolation := TransactionIsolationLevel.ReadUncommitted)>  _
Public Class TransactionAttribute_IsolationReadUncommitted
    Inherits ServicedComponent
End Class 'TransactionAttribute_IsolationReadUncommitted

' An instance of this class will read only committed data and place shared
' locks on the data, preventing other users from modifying it, but other users
' can still insert rows into the data set, so phantom rows are still possible.
<Transaction(Isolation := TransactionIsolationLevel.RepeatableRead)>  _
Public Class TransactionAttribute_IsolationRepeatableRead
    Inherits ServicedComponent
End Class 'TransactionAttribute_IsolationRepeatableRead

' An instance of this class will read only committed data and place a range
' lock on the data set, preventing other users from updating or inserting rows
' into the data set until its transaction is complete.
<Transaction(Isolation := TransactionIsolationLevel.Serializable)>  _
Public Class TransactionAttribute_IsolationSerializable
    Inherits ServicedComponent
End Class 'TransactionAttribute_IsolationSerializable

' </snippet0>

'add Main so code compiles

Public Class Test
    
    Public Shared Sub Main() 
    
    End Sub 'Main
End Class 'Test 