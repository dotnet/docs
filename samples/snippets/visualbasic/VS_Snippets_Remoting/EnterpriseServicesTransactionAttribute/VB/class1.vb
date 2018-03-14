' <snippet0>
Imports System
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

' <snippet1>
<Transaction()>  _
Public Class TransactionAttribute_Ctor
    Inherits ServicedComponent
End Class 'TransactionAttribute_Ctor
' </snippet1>

' <snippet2>
<Transaction(TransactionOption.Supported)>  _
Public Class TransactionAttribute_Ctor_TransactionOption
    Inherits ServicedComponent
End Class 'TransactionAttribute_Ctor_TransactionOption

<Transaction(TransactionOption.Supported, Isolation := TransactionIsolationLevel.Serializable)>  _
Public Class TransactionAttribute_Ctor_TransactionOption_Isolation
    Inherits ServicedComponent
End Class 'TransactionAttribute_Ctor_TransactionOption_Isolation

<Transaction(TransactionOption.Supported, Isolation := TransactionIsolationLevel.Serializable, Timeout := 30)>  _
Public Class TransactionAttribute_Ctor_TransactionOption_Isolation_Timeout
    Inherits ServicedComponent
End Class 'TransactionAttribute_Ctor_TransactionOption_Isolation_Timeout
' </snippet2>

' <snippet3>
<Transaction(Isolation := TransactionIsolationLevel.Serializable)>  _
Public Class TransactionAttribute_Isolation
    Inherits ServicedComponent
    
    Public Sub IsolationExample() 
        ' Get the TransactionAttribute applied to the class.
        Dim attribute As TransactionAttribute = CType(Attribute.GetCustomAttribute(Me.GetType(), GetType(TransactionAttribute), False), TransactionAttribute)
        
        ' Display the current value of the attribute's Isolation property.
        MsgBox("TransactionAttribute.Isolation: " & attribute.Isolation)
        
        ' Set the Isolation property value of the attribute.
        attribute.Isolation = TransactionIsolationLevel.RepeatableRead
        
        ' Display the new value of the attribute's Isolation property.
        MsgBox("TransactionAttribute.Isolation: " & attribute.Isolation)
    
    End Sub 'IsolationExample
End Class 'TransactionAttribute_Isolation
' </snippet3>

' <snippet4>
<Transaction(Timeout := 30)>  _
Public Class TransactionAttribute_Timeout
    Inherits ServicedComponent
    
    Public Sub TimeoutExample() 
        ' Get the TransactionAttribute applied to the class.
        Dim attribute As TransactionAttribute = CType(Attribute.GetCustomAttribute(Me.GetType(), GetType(TransactionAttribute), False), TransactionAttribute)
        
        ' Display the current value of the attribute's Timeout property.
        MsgBox("TransactionAttribute.Timeout: " & attribute.Timeout)
        
        ' Set the Timeout property value of the attribute to sixty
        ' seconds.
        attribute.Timeout = 60
        
        ' Display the new value of the attribute's Timeout property.
        MsgBox("TransactionAttribute.Timeout: " & attribute.Timeout)
    
    End Sub 'TimeoutExample
End Class 'TransactionAttribute_Timeout
' </snippet4>

' <snippet5>
<Transaction(TransactionOption.RequiresNew)>  _
Public Class TransactionAttribute_Value
    Inherits ServicedComponent
    
    Public Sub ValueExample() 
        ' Get the TransactionAttribute applied to the class.
        Dim attribute As TransactionAttribute = CType(Attribute.GetCustomAttribute(Me.GetType(), GetType(TransactionAttribute), False), TransactionAttribute)
        
        ' Display the value of the attribute's Value property.
        MsgBox("TransactionAttribute.Value: " & attribute.Value)
    
    End Sub 'ValueExample
End Class 'TransactionAttribute_Value
' </snippet5>

' </snippet0>

' Test client.
Public Class TransactionAttribute_Example
    
    Public Shared Sub Main() 
        ' Create a new instance of each example class.
        'Dim isolationExample As New TransactionAttribute_Isolation()
        'Dim timeoutExample As New TransactionAttribute_Timeout()
        'Dim valueExample As New TransactionAttribute_Value()
        
        ' Demonstrate the TransactionAttribute properties.
        'isolationExample.IsolationExample()
        'timeoutExample.TimeoutExample()
        'valueExample.ValueExample()
    
    End Sub 'Main
End Class 'TransactionAttribute_Example