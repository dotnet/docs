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
        GetData2()
    End Sub
    ' <snippet1>
    Private Sub GetData2()
        ' Creates a component.
        Dim myComponent As New System.ComponentModel.Component()

        ' Creates a data object, and assigns it the component.
        Dim myDataObject As New DataObject(myComponent)

        ' Creates a type, myType, to store the type of data.
        Dim myType As Type = myComponent.GetType()

        ' Retrieves the data using myType to represent its type.
        Dim myObject As [Object] = myDataObject.GetData(myType)
        If (myObject IsNot Nothing) Then
            MessageBox.Show("The data type stored in the data object is " + myObject.GetType().Name + ".")
        Else
            MessageBox.Show("Data of the specified type was not stored " + "in the data object.")
        End If
    End Sub 'GetData2
    ' </snippet1>

    Public Shared Sub Main()
       System.Windows.Forms.Application.Run(New Form1())
    End Sub

End Class
