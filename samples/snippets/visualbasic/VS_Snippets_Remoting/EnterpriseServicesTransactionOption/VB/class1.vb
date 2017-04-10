 ' <snippet0>
Imports System
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

' An instance of this class will not participate in transactions, but can
' share its caller's context even if its caller is configured as
' NotSupported, Supported, Required, or RequiresNew.
<Transaction(TransactionOption.Disabled)>  _
Public Class TransactionAttribute_TransactionDisabled
    Inherits ServicedComponent
End Class 'TransactionAttribute_TransactionDisabled

' An instance of this class will not participate in transactions, and will
' share its caller's context only if its caller is also configured as
' NotSupported.
<Transaction(TransactionOption.NotSupported)>  _
Public Class TransactionAttribute_TransactionNotSupported
    Inherits ServicedComponent
End Class 'TransactionAttribute_TransactionNotSupported

' An instance of this class will participate in its caller's transaction
' if one exists.
<Transaction(TransactionOption.Supported)>  _
Public Class TransactionAttribute_TransactionSupported
    Inherits ServicedComponent
End Class 'TransactionAttribute_TransactionSupported

' An instance of this class will participate in its caller's transaction
' if one exists. If not, a new transaction will be created for it.
<Transaction(TransactionOption.Required)>  _
Public Class TransactionAttribute_TransactionRequired
    Inherits ServicedComponent
End Class 'TransactionAttribute_TransactionRequired

' A new transaction will always be created for an instance of this class.
<Transaction(TransactionOption.RequiresNew)>  _
Public Class TransactionAttribute_TransactionRequiresNew
    Inherits ServicedComponent
End Class 'TransactionAttribute_TransactionRequiresNew
' </snippet0>

'add Main so code compiles

Public Class Test
    
    Public Shared Sub Main() 
    
    End Sub 'Main
End Class 'Test 