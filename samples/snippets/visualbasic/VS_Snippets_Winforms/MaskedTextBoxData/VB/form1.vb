'<SNIPPET1>
Imports System.Data.SqlClient

Public Class Form1
    Dim WithEvents CurrentBinding, PhoneBinding As Binding
    Dim EmployeesTable As New DataSet()
    Dim sc As SqlConnection
    Dim DataConnect As SqlDataAdapter

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DoMaskedBinding()
    End Sub

    Private Sub DoMaskedBinding()
        Try
            sc = New SqlConnection("Data Source=localhost;Initial Catalog=NORTHWIND;Integrated Security=SSPI")
            sc.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Application.Exit()
        End Try

        DataConnect = New SqlDataAdapter("SELECT * FROM Employees", sc)
        DataConnect.Fill(EmployeesTable, "Employees")

        ' Now bind MaskedTextBox to appropriate field. Note that we must create the Binding objects
        ' before adding them to the control - otherwise, we won't get a Format event on the 
        ' initial load. 
        Try
            CurrentBinding = New Binding("Text", EmployeesTable, "Employees.FirstName")
            firstName.DataBindings.Add(CurrentBinding)
            CurrentBinding = New Binding("Text", EmployeesTable, "Employees.LastName")
            lastName.DataBindings.Add(CurrentBinding)
            PhoneBinding = New Binding("Text", EmployeesTable, "Employees.HomePhone")
            PhoneMask.DataBindings.Add(PhoneBinding)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Application.Exit()
        End Try
    End Sub

    Private Sub PhoneBinding_Format(ByVal sender As Object, ByVal e As ConvertEventArgs) Handles PhoneBinding.Format
        Dim Ext As String

        Dim CurrentRow As DataRowView = CType(Me.BindingContext(EmployeesTable, "Employees").Current, DataRowView)
        If (CurrentRow("Extension") Is Nothing) Then
            Ext = ""
        Else
            Ext = CurrentRow("Extension").ToString()
        End If

        e.Value = e.Value.ToString().Trim() & " x" & Ext
    End Sub

    Private Sub PhoneBinding_Parse(ByVal sender As Object, ByVal e As ConvertEventArgs) Handles PhoneBinding.Parse
        Dim PhoneNumberAndExt As String = e.Value.ToString()

        Dim ExtIndex As Integer = PhoneNumberAndExt.IndexOf("x")
        Dim Ext As String = PhoneNumberAndExt.Substring(ExtIndex).Trim()
        Dim PhoneNumber As String = PhoneNumberAndExt.Substring(0, ExtIndex).Trim()

        ' Get the current binding object, and set the new extension manually. 
        Dim CurrentRow As DataRowView = CType(Me.BindingContext(EmployeesTable, "Employees").Current, DataRowView)
        ' Remove the "x" from the extension.
        CurrentRow("Extension") = CObj(Ext.Substring(1))

        ' Return the phone number.
        e.Value = PhoneNumber
    End Sub

    Private Sub NextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextButton.Click
        Me.BindingContext(EmployeesTable, "Employees").Position = Me.BindingContext(EmployeesTable, "Employees").Position + 1
    End Sub

    Private Sub PreviousButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviousButton.Click
        Me.BindingContext(EmployeesTable, "Employees").Position = Me.BindingContext(EmployeesTable, "Employees").Position - 1
    End Sub
End Class
'</SNIPPET1>