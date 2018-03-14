 ' <snippet0>
Imports System
Imports System.EnterpriseServices
Imports System.EnterpriseServices.CompensatingResourceManager
Imports System.IO


' <snippet1>

<Assembly: ApplicationActivation(ActivationOption.Server)> 
' </snippet1>
' <snippet2>

<Assembly: ApplicationAccessControl(False)> 
' </snippet2>
' <snippet3>

<Assembly: ApplicationCrmEnabled()>  
' </snippet3>
' <snippet4>

<Assembly: Description("A system for ensuring that the correct account balance is stored after a transaction.")> 
' </snippet4>
' Subroutines to read and write account files.

Class AccountManager


    Public Shared Sub WriteAccountBalance(ByVal filename As String, ByVal balance As Integer)
        Dim writer As New StreamWriter(filename)
        writer.WriteLine(balance)
        writer.Close()

    End Sub 'WriteAccountBalance


    Public Shared Function ReadAccountBalance(ByVal filename As String) As Integer
        Dim balance As Integer = 0
        If File.Exists(filename) Then
            Dim reader As New StreamReader(filename)
            Dim line As String = reader.ReadLine()
            balance = Int32.Parse(line)
            reader.Close()
        End If
        Return balance

    End Function 'ReadAccountBalance
End Class 'AccountManager 

' <snippet10>
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
        
        ' <snippet11>
        ' Create a new clerk using the AccountCompensator class.
        Dim clerk As New Clerk(GetType(AccountCompensator), "An account transaction compensator", CompensatorOptions.AllPhases)
        ' </snippet11>
        ' <snippet12>
        ' Create a record of previous account status, and deliver it to the clerk.
        Dim balance As Integer = AccountManager.ReadAccountBalance(Filenam)
        
        Dim record(1) As [Object]
        record(0) = filename
        record(1) = balance
        
        clerk.WriteLogRecord(record)
        clerk.ForceLog()
        ' </snippet12>
        ' Perform the transaction
        balance -= ammount
        AccountManager.WriteAccountBalance(filename, balance)
        
        ' <snippet13>
        ' Commit or abort the transaction 
        If commit Then
            ContextUtil.SetComplete()
        Else
            ContextUtil.SetAbort()
        End If
        '</snippet13>
    End Sub 'DebitAccount ' 
    
End Class 'Account

' </snippet10>

' <snippet20>
' A CRM Compensator

Public Class AccountCompensator
    Inherits Compensator
    
    Private receivedPrepareRecord As Boolean = False
    
    
    ' <snippet21>
    Public Overrides Sub BeginPrepare() 
    
    End Sub 'BeginPrepare
    
    ' nothing to do
    ' </snippet21>
    ' <snippet22>
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
    
    ' </snippet22>
    ' <snippet23>
    Public Overrides Function EndPrepare() As Boolean 
        ' Allow the transaction to proceed onlyif we have received a prepare record.
        If receivedPrepareRecord Then
            Return True
        Else
            Return False
        End If
    
    End Function 'EndPrepare
    
    ' </snippet23>
    ' <snippet24>
    Public Overrides Sub BeginCommit(ByVal commit As Boolean) 
    
    End Sub 'BeginCommit
    
    ' nothing to do
    ' </snippet24>
    ' <snippet25>
    Public Overrides Function CommitRecord(ByVal log As LogRecord) As Boolean 
        ' nothing to do
        Return False
    
    End Function 'CommitRecord
    
    ' </snippet25>
    ' <snippet26>
    Public Overrides Sub EndCommit() 
    
    End Sub 'EndCommit
    
    ' nothing to do
    ' </snippet26>
    ' <snippet27>
    Public Overrides Sub BeginAbort(ByVal abort As Boolean) 
    
    End Sub 'BeginAbort
    
    ' nothing to do
    ' </snippet27>
    ' <snippet28>
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
    
    ' </snippet28>
    ' <snippet29>
    Public Overrides Sub EndAbort() 
    
    End Sub 'EndAbort
End Class 'AccountCompensator ' nothing to do
' </snippet29>
' </snippet20>
' </snippet0>