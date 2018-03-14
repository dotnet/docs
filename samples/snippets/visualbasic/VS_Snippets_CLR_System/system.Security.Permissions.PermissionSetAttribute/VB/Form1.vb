'<Snippet1>
' The #Const BuildFile = True statement must be active the first time this
' sample is run. This causes the sample to create a file named
' 'LocalIntranet.xml' in the c:\temp folder. After creating the
' LocalInternet.xml file, comment out the #Const BUILDFILE = True statement,
' uncomment the #Const BUILDFILE = False statement, and rerun the sample to
' demonstrate the use of the permission set attribute.
Imports System
Imports System.Security
Imports System.Security.Permissions
Imports System.Security.Policy
Imports System.Collections
Imports System.IO

#Const BUILDFILE = True
'#Const BUILDFILE = False

Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Event handler for Run button.
    <STAThread()> _
        Private Sub Button1_Click( _
            ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles Button1.Click

        tbxOutput.Cursor = Cursors.WaitCursor
        tbxOutput.Text = ""

        Dim xmlFilePath As String
        xmlFilePath = "c:\temp\LocalIntranet.xml"

        ' Run this sample with the BuildFile symbol defined to create the
        ' required file, then comment out the /define statement to demonstrate
        ' the use of the attribute.
#If (BUILDFILE) Then
        Dim sw As New StreamWriter(xmlFilePath)
        Try
            sw.WriteLine(GetNamedPermissionSet("LocalIntranet"))
            WriteLine("File created at " + xmlFilePath)
            WriteLine("Uncomment the BuildFile=false line and " + _
                "run the sample again.")
        Finally
            sw.Close()
        End Try
#End If

#If (Not BUILDFILE) Then
        ReadFile1()
        ReadFile2()
        ReadFile3()
#End If
        ' Align interface and conclude application.
        WriteLine(vbCrLf + "This sample completed successfully;" + _
            " press Exit to continue.")

        ' Reset the cursor.
        tbxOutput.Cursor = Cursors.Default
    End Sub

#If (Not BUILDFILE) Then
    ' Read the LocalIntranet.xml file.
    Private Sub ReadFile1()
        Try
            WriteLine("Attempting to read a file using the FullTrust " + _
                "permission set.")
            Dim sr As New StreamReader("c:\temp\LocalIntranet.xml")
            Try
                Dim permissionSet As String = sr.ReadToEnd()
            Finally
                sr.Close()
            End Try
            WriteLine("The file was successfully read.")
        Catch e As Exception
            WriteLine(e.Message)
        End Try
    End Sub 'ReadFile1

    '<Snippet2>
    <System.Security.Permissions.PermissionSetAttribute( _
        SecurityAction.PermitOnly, _
        File:="c:\temp\LocalIntranet.xml")> _
    Private Sub ReadFile2()
        '</Snippet2>
        ' Read the file with the specified security action on the file path.
        Try
            WriteLine("Attempting to read a file using the LocalIntranet " + _
                "permission set.")
            Dim sr As New StreamReader("c:\temp\LocalIntranet.xml")
            Try
                Dim permissionSet As String = sr.ReadToEnd()
            Finally
                sr.Close()
            End Try
            WriteLine("The file was successfully read.")
        Catch e As Exception
            WriteLine(e.Message)
        End Try
    End Sub 'ReadFile2

    '<Snippet3>
    <System.Security.Permissions.PermissionSetAttribute( _
        SecurityAction.PermitOnly, _
        Name:="LocalIntranet")> _
    Private Sub ReadFile3()
        '</Snippet3>
        ' Read the file with the specified security action on the
        ' permission set.
        Try
            WriteLine("Second attempt to read a file using the " + _
                "LocalIntranet permission set.")
            Dim sr As New StreamReader("c:\temp\LocalIntranet.xml")
            Try
                Dim permissionSet As String = sr.ReadToEnd()
            Finally
                sr.Close()
            End Try
            WriteLine("The file was successfully read.")
        Catch e As Exception
            WriteLine(e.Message)
        End Try
    End Sub 'ReadFile3
#End If

    ' Locate the named permission set at the Machine level and return it as
    ' a string value.
    Private Shared Function GetNamedPermissionSet( _
        ByVal name As String) As String

        Dim policyEnumerator As IEnumerator
        policyEnumerator = SecurityManager.PolicyHierarchy()

        ' Move through the policy levels to the Machine Level.
        While policyEnumerator.MoveNext()
            Dim currentLevel As PolicyLevel
            currentLevel = CType(policyEnumerator.Current, PolicyLevel)
            If currentLevel.Label = "Machine" Then
                ' Iterate through the permission sets at the Machine level.
                Dim namedPermissions As IList
                namedPermissions = currentLevel.NamedPermissionSets

                Dim namedPermission As IEnumerator
                namedPermission = namedPermissions.GetEnumerator()

                Dim currentPermission As NamedPermissionSet
                ' Locate the named permission set.
                While namedPermission.MoveNext()
                    currentPermission = CType( _
                        namedPermission.Current, _
                        NamedPermissionSet)

                    If currentPermission.Name.Equals(name) Then
                        Return currentPermission.ToString()
                    End If
                End While
            End If
        End While
        Return Nothing
    End Function

    ' Write specified message and carriage return to the output textbox.
    Private Sub WriteLine(ByVal message As String)
        tbxOutput.AppendText(message + vbCrLf)

    End Sub

    ' Event handler for Exit button.
    Private Sub Button2_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button2.Click

        Application.Exit()
    End Sub
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
            If Not (components Is Nothing) Then
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
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tbxOutput As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.tbxOutput = New System.Windows.Forms.RichTextBox
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.DockPadding.All = 20
        Me.Panel2.Location = New System.Drawing.Point(0, 320)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(616, 64)
        Me.Panel2.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Font = New System.Drawing.Font( _
            "Microsoft Sans Serif", _
            9.0!, _
            System.Drawing.FontStyle.Regular, _
            System.Drawing.GraphicsUnit.Point, _
            CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(446, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 24)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "&Run"
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.Font = New System.Drawing.Font( _
            "Microsoft Sans Serif", _
            9.0!, _
            System.Drawing.FontStyle.Regular, _
            System.Drawing.GraphicsUnit.Point, _
            CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(521, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 24)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "E&xit"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tbxOutput)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.DockPadding.All = 20
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(616, 320)
        Me.Panel1.TabIndex = 2
        '
        'tbxOutput
        '
        Me.tbxOutput.AccessibleDescription = _
            "Displays output from application."
        Me.tbxOutput.AccessibleName = "Output textbox."
        Me.tbxOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbxOutput.Location = New System.Drawing.Point(20, 20)
        Me.tbxOutput.Name = "tbxOutput"
        Me.tbxOutput.Size = New System.Drawing.Size(576, 280)
        Me.tbxOutput.TabIndex = 1
        Me.tbxOutput.Text = "Click the Run button to run the application."
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(616, 384)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "Form1"
        Me.Text = "PermisstionSetAttribute"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
End Class
'
' This sample produces the following output:
'
' File created at c:\temp\LocalIntranet.xml
' Uncomment the BuildFile=false line and run the sample again.
'
' This sample completed successfully; press Exit to continue.
'
'
' The second time the sample is ran (without DEBUG flag):
'
' Attempting to read a file using the FullTrust permission set.
' The file was successfully read.
' Attempting to read a file using the LocalIntranet permission set.
' Request for the permission of type
' System.Security.Permissions.FileIOPermission, mscorlib, Version=1.0.5000.0,
' Culture=neutral, PublicKeyToken=b77a5c561934e089 failed.
'
' Second attempt to read a file using the LocalIntranet permission set.
' Request for the permission of type System.Security.Permissions.FileIOPermission,
' mscorlib, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
' failed.
' This sample completed successfully; press Exit to continue.
'</Snippet1>