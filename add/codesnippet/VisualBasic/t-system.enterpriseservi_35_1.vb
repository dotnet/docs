' A CRM Worker
<Transaction()>  _
Public Class Account
    Inherits ServicedComponent
    
    ' A data member for the account file name.
    Private filename As String
    
    
    Public Property Filenam() As String
        Get
            Return Filename
        End Get
        Set(ByVal value As String)
            filename = Value
        End Set
    End Property
    
    
    ' A boolean data member that determines whether to commit or abort the transaction.
    Private commit As Boolean
    
    
    Public Property AllowCommit() As Boolean 
        Get
            Return commit
        End Get
        Set
            commit = value
        End Set
    End Property
    
    
    
    
    ' Debit the account, 
    Public Sub DebitAccount(ByVal ammount As Integer) 
        
        ' Create a new clerk using the AccountCompensator class.
        Dim clerk As New Clerk(GetType(AccountCompensator), "An account transaction compensator", CompensatorOptions.AllPhases)
        ' Create a record of previous account status, and deliver it to the clerk.
        Dim balance As Integer = AccountManager.ReadAccountBalance(Filenam)
        
        Dim record(1) As [Object]
        record(0) = filename
        record(1) = balance
        
        clerk.WriteLogRecord(record)
        clerk.ForceLog()
        ' Perform the transaction
        balance -= ammount
        AccountManager.WriteAccountBalance(filename, balance)
        
        ' Commit or abort the transaction 
        If commit Then
            ContextUtil.SetComplete()
        Else
            ContextUtil.SetAbort()
        End If
    End Sub 'DebitAccount ' 
    
End Class 'Account
