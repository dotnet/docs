Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Data
Imports System.Configuration.Install
Imports System.Design
Imports System.DirectoryServices
Imports System.EnterpriseServices
Imports System.Management
Imports System.Messaging
Imports System.Runtime.Remoting
Imports System.Runtime.Serialization.Formatters.Soap
Imports System.Security
Imports System.ServiceProcess
Imports System.Web
Imports System.Web.RegularExpressions
Imports System.Web.Services
Imports System.XML

Public NotInheritable Class Form1
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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(288, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "TextBox1"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 276)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData1()
    End Sub
    ' <snippet1>
    Private Sub GetData1()
        ' Creates a new data object using a string and the text format.
        Dim myString As String = "My text string"
        Dim myDataObject As New DataObject(DataFormats.Text, myString)

        ' Displays the string in a text box.
        textBox1.Text = myDataObject.GetData(DataFormats.Text).ToString()
    End Sub 'GetData1
    ' </snippet1>

    Public Shared Sub Main()
       System.Windows.Forms.Application.Run(New Form1())
    End Sub

End Class
