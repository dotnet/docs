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
        TestDataObject()
    End Sub
    ' <snippet1>
    Private Sub TestDataObject()
        ' Creates a new data object using a string and the Text format.
        Dim myString As New String("Hello World!")
        Dim myDataObject As New DataObject(DataFormats.Text, myString)

        ' Checks whether the data is present in the Text format and displays the result.
        If (myDataObject.GetDataPresent(DataFormats.Text)) Then
            MessageBox.Show("The stored data is in the Text format.", "Test Result")
        Else
            MessageBox.Show("The stored data is not in the Text format.", "Test Result")
        End If
    End Sub 'TestDataObject
    ' </snippet1>

    Public Shared Sub Main()
       System.Windows.Forms.Application.Run(New Form1())
    End Sub
    
End Class
