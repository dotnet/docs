' <snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Class Form1
    Inherits Form
    Private bSource As New BindingSource()
    Private WithEvents button1 As Button
    Private dgv As New DataGridView()

    Public Sub New()
        Me.button1 = New System.Windows.Forms.Button()
        Me.button1.Location = New System.Drawing.Point(140, 326)
        Me.button1.Name = "button1"
        Me.button1.AutoSize = True
        Me.button1.Text = "Add Customer"
        Me.ClientSize = New System.Drawing.Size(362, 370)
        Me.Controls.Add(Me.button1)

        ' Bind the BindingSource to the DemoCustomer type.
        bSource.DataSource = GetType(DemoCustomer)

        ' Set up the DataGridView control.
        dgv.Dock = DockStyle.Top
        Me.Controls.Add(dgv)

        ' Bind the DataGridView control to the BindingSource.
        dgv.DataSource = bSource

    End Sub

    Public Shared Sub Main()
        Application.Run(New Form1())

    End Sub

    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles button1.Click
        bSource.Add(New DemoCustomer(DateTime.Today))

    End Sub
End Class

' This simple class is used to demonstrate binding to a type.
Public Class DemoCustomer

    Public Sub New()
        idValue = Guid.NewGuid()
    End Sub

    Public Sub New(ByVal FirstOrderDate As DateTime)
        FirstOrder = FirstOrderDate
        idValue = Guid.NewGuid()
    End Sub

    ' These fields hold the data that backs the public properties.
    Private firstOrderDateValue As DateTime
    Private idValue As Guid
    Private custNameValue As String

    Public Property CustomerName() As String
        Get
            Return custNameValue
        End Get
        Set(ByVal value As String)
            custNameValue = value
        End Set
    End Property

    ' This is a property that represents the first order date.
    Public Property FirstOrder() As DateTime
        Get
            Return Me.firstOrderDateValue
        End Get
        Set(ByVal value As DateTime)
            If value <> Me.firstOrderDateValue Then
                Me.firstOrderDateValue = value
            End If
        End Set
    End Property

    ' This is a property that represents a customer ID.
    Public ReadOnly Property ID() As Guid
        Get
            Return Me.idValue
        End Get
    End Property
End Class
' </snippet1>