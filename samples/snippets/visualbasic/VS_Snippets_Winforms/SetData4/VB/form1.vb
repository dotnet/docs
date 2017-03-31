Imports System
Imports System.String
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
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Adds any initialization after the InitializeComponent() call

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
        SetData4()
    End Sub
    ' <snippet1>
    Private Sub SetData4()
        ' Creates a new data object.
        Dim myDataObject As New DataObject()

        ' Adds UnicodeText string to the object, and set the autoConvert
        ' parameter to false.
        myDataObject.SetData(DataFormats.UnicodeText, False, "My text string")

        ' Gets the data format(s) in the data object.
        Dim arrayOfFormats As [String]() = myDataObject.GetFormats()

        ' Stores the results in a string.
        Dim theResult As String = "The format(s) associated with the data are:" + _
                ControlChars.Cr
        Dim i As Integer
        For i = 0 To arrayOfFormats.Length - 1
            theResult += arrayOfFormats(i) + ControlChars.Cr
        Next i
        ' Show the results in a message box. 
        MessageBox.Show(theResult)
    End Sub 'SetData4 
    ' </snippet1>
End Class
