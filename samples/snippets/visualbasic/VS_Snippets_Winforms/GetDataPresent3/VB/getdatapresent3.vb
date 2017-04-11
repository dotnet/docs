Imports System
Imports System.Windows.Forms

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
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 276)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetDataPresent3()
    End Sub
    ' <snippet1>
    Private Sub GetDataPresent3()
        ' Creates a new data object using a string and the Text format.
        Dim myDataObject As New DataObject(DataFormats.Text, "My String")

        ' Checks whether the string can be displayed with autoConvert equal to false.
        If myDataObject.GetDataPresent("System.String", False) Then
            MessageBox.Show(myDataObject.GetData("System.String", False).ToString() + ".", "Message #1")
        Else
            MessageBox.Show("Cannot convert data to the specified format with autoConvert set to false.", "Message #1")
        End If
        ' Displays the string with autoConvert equal to true.
        MessageBox.Show(("Now that autoConvert is true, you can convert " + myDataObject.GetData("System.String", _
             True).ToString() + " to string format."), "Message #2")

    End Sub 'GetDataPresent3
    ' </snippet1>

    Public Shared Sub Main()
       System.Windows.Forms.Application.Run(New Form1())
    End Sub

End Class
