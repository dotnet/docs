' This sample demonstrates how to call each member of the PolicyStatement
' class.
'<Snippet1>
Imports System
Imports System.Security
Imports System.Security.Policy
Imports System.Security.Principal
Imports System.Security.Permissions

Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Event handler for Run button.
    Private Sub Button1_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        tbxOutput.Cursor = Cursors.WaitCursor
        tbxOutput.Text = ""

        Dim policyStatement As PolicyStatement = firstConstructorTest()
        Dim policyStatement2 As PolicyStatement = secondConstructorTest()

        ' Add attributes to policy statement.
        '<Snippet4>
        policyStatement.Attributes = PolicyStatementAttribute.All
        '</Snippet4>

        Dim policyStatementCopy As PolicyStatement
        policyStatementCopy = createCopy(policyStatement)
        addXmlMember(policyStatementCopy)

        summarizePolicyStatment(policyStatement)

        ' Align interface and conclude application.
        tbxOutput.AppendText(vbCrLf + "This sample completed " + _
            "successfully; press Exit to continue.")

        tbxOutput.Cursor = Cursors.Default
    End Sub
    ' Construct a PolicyStatement with an Unrestricted permission set.
    Private Function firstConstructorTest() As PolicyStatement
        ' Construct policy statement based on newly created permission set.
        ' Assemble permission set.
        '<Snippet2>
        Dim permissions As New PermissionSet(PermissionState.Unrestricted)

        permissions.AddPermission( _
            New SecurityPermission(SecurityPermissionFlag.Execution))
        permissions.AddPermission( _
            New ZoneIdentityPermission(SecurityZone.MyComputer))

        ' Instantiate a new policy statement with specified permission set.
        Dim policyStatement As New PolicyStatement(permissions)
        '</Snippet2>

        Return PolicyStatement
    End Function

    ' Construct a PolicyStatement with an Unrestricted permission set with
    ' the LevelFinal attribute.
    Private Function secondConstructorTest() As PolicyStatement
        ' Construct policy statement based on newly created permission set.
        ' Assemble permission set.
        '<Snippet3>
        Dim permissions As New PermissionSet(PermissionState.Unrestricted)
        permissions.AddPermission( _
            New SecurityPermission(SecurityPermissionFlag.Execution))
        permissions.AddPermission( _
            New ZoneIdentityPermission(SecurityZone.MyComputer))

        Dim levelFinalAttribute As PolicyStatementAttribute
        levelFinalAttribute = PolicyStatementAttribute.LevelFinal

        ' Instantiate a new policy statement with specified permission set
        ' and the LevelFinal attibute set allowing lower policy levels to be
        ' avoided in a resolve.
        Dim policyStatement As _
            New PolicyStatement(permissions, levelFinalAttribute)
        '</Snippet3>

        Return policyStatement
    End Function

    ' Add named permission set to specified PolicyStatement.
    Private Sub AddPermissions(ByRef policyStatement As PolicyStatement)
        ' Set up a NamedPermissionSet with all permissions.
        '<Snippet5>
        Dim allPerms As New NamedPermissionSet("allPerms")
        allPerms.AddPermission( _
            New SecurityPermission(SecurityPermissionFlag.Execution))
        allPerms.AddPermission( _
            New ZoneIdentityPermission(SecurityZone.MyComputer))
        allPerms.AddPermission( _
            New SiteIdentityPermission("www.contoso.com"))

        policyStatement.PermissionSet = allPerms
        '</Snippet5>
    End Sub

    ' If the class attribute is not found in specified PolicyStatement,
    ' add a child XML element with an added class attribute.
    Private Sub addXmlMember(ByRef policyStatement As PolicyStatement)
        '<Snippet6>
        Dim xmlElement As SecurityElement = policyStatement.ToXml()
        '</Snippet6>

        If (xmlElement.Attribute("class") Is Nothing) Then
            '<Snippet7>
            Dim newElement As New SecurityElement("PolicyStatement")
            newElement.AddAttribute("class", policyStatement.ToString())
            newElement.AddAttribute("version", "1.1")

            newElement.AddChild(New SecurityElement("PermissionSet"))

            policyStatement.FromXml(newElement)
            '</Snippet7>

            tbxOutput.AppendText("Added the class attribute and modified the")
            tbxOutput.AppendText(" version number." + vbCrLf)
            tbxOutput.AppendText(newElement.ToString() + vbCrLf)
        End If
    End Sub

    ' Verify specified object is a PolicyStatement type. Retrieve a copy
    ' using the private getCopy method.
    Private Function createCopy( _
        ByVal sourceObject As Object) As PolicyStatement

        Dim returnedStatement = New PolicyStatement(Nothing)

        ' Compare specified object's type with the PolicyStatement type.
        '<Snippet8>
        If (sourceObject.GetType() Is GetType(PolicyStatement)) Then
            '</Snippet8>
            returnedStatement = getCopy(CType(sourceObject, PolicyStatement))
        Else
            Throw New ArgumentException("Excepted PolicyStatement type.")
        End If

        Return returnedStatement
    End Function

    ' Return a copy of the specified PolicyStatement if the result of the
    ' Copy command results in an equivalent object. Otherwise, return the
    ' original object.
    Private Function getCopy( _
        ByVal policyStatement As PolicyStatement) As PolicyStatement

        ' Create an equivalent copy of the policy statement.
        '<Snippet9>
        Dim policyStatementCopy As PolicyStatement = policyStatement.Copy()
        '</Snippet9>

        ' Compare the specified objects for equality.
        '<Snippet10>
        If (Not policyStatementCopy.Equals(policyStatement)) Then
            '</Snippet10>
            Return policyStatementCopy
        Else
            Return policyStatement
        End If
    End Function

    ' Summarize the specified PolicyStatement to the console window.
    Private Sub summarizePolicyStatment( _
        ByVal policyStatement As PolicyStatement)

        ' Retrieve the class path for policyStatement.
        '<Snippet11>
        Dim policyStatementClass As String = policyStatement.ToString()
        '</Snippet11>

        '<Snippet12>
        Dim hashCode As Integer = policyStatement.GetHashCode()
        '</Snippet12>

        Dim attributeString As String = ""
        ' Retrieve the string representation of the Policy's attributes.
        '<Snippet13>
        If (Not policyStatement.AttributeString Is Nothing) Then
            attributeString = policyStatement.AttributeString
        End If
        '</Snippet13>

        ' Write summary to console window.
        tbxOutput.AppendText("*** " + policyStatementClass + " summary ***")
        tbxOutput.AppendText(vbCrLf)
        tbxOutput.AppendText("PolicyStatement has been created with hash ")
        tbxOutput.AppendText("code(" + hashCode.ToString() + ") ")

        tbxOutput.AppendText("containing the following attributes: ")
        tbxOutput.AppendText(attributeString + vbCrLf)
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
        Me.Text = "PolicyStatement"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
End Class
'
' This sample produces the following output:
'
' Added the class attribute and modified the version number.
' <PolicyStatement class="System.Security.Policy.PolicyStatement"
'                  version="1.1">
'    <PermissionSet/>
' </PolicyStatement>
' 
' *** System.Security.Policy.PolicyStatement summary ***
' PolicyStatement has been created with hash code(20) containing the following
' attributes: Exclusive LevelFinal
' 
' This sample completed successfully; press Exit to continue
'</Snippet1>