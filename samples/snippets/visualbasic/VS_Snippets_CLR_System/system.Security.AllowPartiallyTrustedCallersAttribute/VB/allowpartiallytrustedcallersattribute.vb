'<Snippet1>
' The following HTML code can be used to call the user control in this sample.
'
'<HTML>
'	<BODY>
'		<OBJECT id="usercontrol" classid="usercontrol.dll#UserControl.UserControl1" width="800"
'		height="300" style="font-size:12;">
'		</OBJECT>
'		<p>
'	</BODY>
'</HTML>
' To run this test control you must create a strong name key, snkey.snk, and 
' a code group that gives full trust to assemblies signed with snkey.snk.
' The user control displays an OpenFileDialog box, then displays a text box containing the name of 
' the file selected and a list box that displays the contents of the file.  The selected file must 
' contain text in order for the control to display the data properly.
' Caution  This sample demonstrates the use of the Assert method.  Calling Assert removes the 
' requirement that all code in the call chain must be granted permission to access the specified 
' resource, it can open up security vulnerabilities if used incorrectly or inappropriately. Therefore, 
' it should be used with great caution.  Assert should always be followed with a RevertAssert 
' command to restore the security settings.

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.IO
Imports System.Security
Imports System.Security.Permissions
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic


' This strong name key is used to create a code group that gives permissions to this assembly.

<Assembly: AssemblyKeyFile("snKey.snk")> 

<Assembly: AssemblyVersion("1.0.0.0")> 
' The AllowPartiallyTrustedCallersAttribute requires the assembly to be signed with a strong name key.
' This attribute is necessary since the control is called by either an intranet or Internet
' Web page that should be running under restricted permissions.

<Assembly: AllowPartiallyTrustedCallers()> 

' The userControl1 displays an OpenFileDialog box, then displays a text box containing the name of 
' the file selected and a list box that displays the contents of the file.  The selected file must 
' contain text in order for the control to display the data properly.

'Demand the zone requirement for the calling application.
<ZoneIdentityPermissionAttribute(SecurityAction.Demand, Zone:=SecurityZone.Intranet)> _
Public Class UserControl1
    Inherits System.Windows.Forms.UserControl
    Private WithEvents textBox1 As System.Windows.Forms.TextBox
    Private listBox1 As System.Windows.Forms.ListBox
    ' Required designer variable.
    Private components As System.ComponentModel.Container = Nothing


    Public Sub New()
        ' This call is required by the Windows.Forms Form Designer.
        InitializeComponent()

        ' The OpenFileDialog box should not require any special permissions.
        Dim fileDialog As New OpenFileDialog
        If fileDialog.ShowDialog() = DialogResult.OK Then
            ' Reading the name of the selected file from the OpenFileDialog box
            ' and reading the file requires FileIOPermission.  The user control should 
            ' have this permission granted through its code group; the Web page that calls the 
            ' control should not have this permission.  The Assert command prevents a stack walk 
            ' that would fail because the caller does not have the required FileIOPermission.  
            ' The use of Assert can open up security vulnerabilities if used incorrectly or 
            ' inappropriately. Therefore, it should be used with great caution.
            ' The Assert command should be followed by a RevertAssert as soon as the file operation 
            ' is completed.
            Dim fileIOPermission As New FileIOPermission(PermissionState.Unrestricted)
            fileIOPermission.Assert()
            textBox1.Text = fileDialog.FileName
            ' Display the contents of the file in the text box.
            Dim fsIn As New FileStream(textBox1.Text, FileMode.Open, FileAccess.Read, FileShare.Read)
            Dim sr As New StreamReader(fsIn)

            ' Process every line in the file
            Dim Line As String
            Line = sr.ReadLine()
            While Not (Line Is Nothing)
                listBox1.Items.Add(Line)
                Line = sr.ReadLine()
            End While
            ' It is very important to call RevertAssert to restore the stack walk for
            ' file operations.
            fileIOPermission.RevertAssert()
        End If
    End Sub 'New


    ' Clean up any resources being used.
    Protected Overloads Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub 'Dispose


    ' Required method for Designer support - do not modify 
    ' the contents of this method with the code editor.
    Private Sub InitializeComponent()
        Me.textBox1 = New System.Windows.Forms.TextBox
        Me.listBox1 = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        ' 
        ' textBox1
        ' 
        Me.textBox1.Location = New System.Drawing.Point(208, 112)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(320, 20)
        Me.textBox1.TabIndex = 0
        Me.textBox1.Text = "textBox1"
        ' 
        ' listBox1
        ' 
        Me.listBox1.Location = New System.Drawing.Point(200, 184)
        Me.listBox1.Name = "listBox1"
        Me.listBox1.Size = New System.Drawing.Size(336, 108)
        Me.listBox1.TabIndex = 1
        ' 
        ' UserControl1
        ' 
        Me.Controls.Add(listBox1)
        Me.Controls.Add(textBox1)
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(592, 400)
        Me.ResumeLayout(False)
    End Sub 'InitializeComponent

    Private Sub UserControl1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub 'UserControl1_Load

    Private Sub textBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles textBox1.TextChanged
    End Sub 'textBox1_TextChanged
End Class 'UserControl1 
'</Snippet1>

