' Visual Basic .NET Document
Option Strict On

' The following is CreateResources.*
' <Snippet7>
Imports System.Resources

Module CreateResource1
    Public Sub Main()
        Dim table As New PersonTable("Name", "Employee Number", "Age", 30, 18, 5)
        Dim rr As New ResXResourceWriter(".\UIResources.resx")
        rr.AddResource("TableName", "Employees of Acme Corporation")
        rr.AddResource("Employees", table)
        rr.Generate()
        rr.Close()
    End Sub
End Module
' </Snippet7>


' The following is UIElements.* 
' <Snippet6>
<Serializable> Public Structure PersonTable1
    Public ReadOnly nColumns As Integer
    Public ReadOnly column1 As String
    Public ReadOnly column2 As String
    Public ReadOnly column3 As String
    Public ReadOnly width1 As Integer
    Public ReadOnly width2 As Integer
    Public ReadOnly width3 As Integer

    Public Sub New(column1 As String, column2 As String, column3 As String,
                  width1 As Integer, width2 As Integer, width3 As Integer)
        Me.column1 = column1
        Me.column2 = column2
        Me.column3 = column3
        Me.width1 = width1
        Me.width2 = width2
        Me.width3 = width3
        Me.nColumns = Me.GetType().GetFields().Count \ 2
    End Sub
End Structure
' </Snippet6>

