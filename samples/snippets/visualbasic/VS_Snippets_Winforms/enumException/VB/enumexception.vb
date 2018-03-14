imports System
imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<snippet1>
        Try
            ' Attempts to pass an invalid enum value (MessageBoxButtons) to the Show method
            Dim myButton As MessageBoxButtons
            myButton = CType(123, MessageBoxButtons)
            MessageBox.Show("This is a message", "This is the Caption", myButton)
        Catch invE As System.ComponentModel.InvalidEnumArgumentException
            Console.WriteLine(invE.Message)
            Console.WriteLine(invE.ParamName)
            Console.WriteLine(invE.StackTrace)
            Console.WriteLine(invE.Source)
        End Try
        '</snippet1>
    End Sub
End Class
