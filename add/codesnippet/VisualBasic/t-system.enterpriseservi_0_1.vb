' A CRM Compensator

Public Class AccountCompensator
    Inherits Compensator
    
    Private receivedPrepareRecord As Boolean = False
    
    
    Public Overrides Sub BeginPrepare() 
    
    End Sub 'BeginPrepare
    
    ' nothing to do
    Public Overrides Function PrepareRecord(ByVal log As LogRecord) As Boolean 
        
        ' Check the validity of the record.
        If log Is Nothing Then
            Return True
        End If
        Dim record As [Object]() = log.Record
        
        If record Is Nothing Then
            Return True
        End If
        If record.Length <> 2 Then
            Return True
        End If 
        ' The record is valid.
        receivedPrepareRecord = True
        Return False
    
    End Function 'PrepareRecord
    
    Public Overrides Function EndPrepare() As Boolean 
        ' Allow the transaction to proceed onlyif we have received a prepare record.
        If receivedPrepareRecord Then
            Return True
        Else
            Return False
        End If
    
    End Function 'EndPrepare
    
    Public Overrides Sub BeginCommit(ByVal commit As Boolean) 
    
    End Sub 'BeginCommit
    
    ' nothing to do
    Public Overrides Function CommitRecord(ByVal log As LogRecord) As Boolean 
        ' nothing to do
        Return False
    
    End Function 'CommitRecord
    
    Public Overrides Sub EndCommit() 
    
    End Sub 'EndCommit
    
    ' nothing to do
    Public Overrides Sub BeginAbort(ByVal abort As Boolean) 
    
    End Sub 'BeginAbort
    
    ' nothing to do
    Public Overrides Function AbortRecord(ByVal log As LogRecord) As Boolean 
        
        ' Check the validity of the record.
        If log Is Nothing Then
            Return True
        End If
        Dim record As [Object]() = log.Record
        
        If record Is Nothing Then
            Return True
        End If
        If record.Length <> 2 Then
            Return True
        End If 
        ' Extract old account data from the record.
        Dim filename As String = CStr(record(0))
        Dim balance As Integer = Fix(record(1))
        
        ' Restore the old state of the account.
        AccountManager.WriteAccountBalance(filename, balance)
        
        Return False
    
    End Function 'AbortRecord
    
    Public Overrides Sub EndAbort() 
    
    End Sub 'EndAbort
End Class 'AccountCompensator ' nothing to do