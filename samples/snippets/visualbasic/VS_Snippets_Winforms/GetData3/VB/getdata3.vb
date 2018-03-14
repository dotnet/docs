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
    Private components As System.ComponentModel.Container

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
        GetData3()
    End Sub
    ' <snippet1>
    Private Sub GetData3()
        ' Creates a new data object using a text string.
        Dim myString As String = "Hello World!"
        Dim myDataObject As New DataObject(DataFormats.Text, myString)

        ' Displays the string with autoConvert equal to false.
        If (myDataObject.GetData("System.String", False) IsNot Nothing) Then
            ' Displays the string in a message box.
            MessageBox.Show(myDataObject.GetData("System.String", False).ToString() + ".", "Message #1")
            ' Displays a not found message in a message box.
        Else
            MessageBox.Show("Could not find data of the specified format.", "Message #1")
        End If

        ' Displays the string in a text box with autoConvert equal to true.
        Dim myData As String = "The data is " + myDataObject.GetData("System.String", True).ToString()
        MessageBox.Show(myData, "Message #2")
    End Sub 'GetData3
    ' </snippet1>

    Public Shared Sub Main()
       System.Windows.Forms.Application.Run(New Form1())
    End Sub
    
End Class
