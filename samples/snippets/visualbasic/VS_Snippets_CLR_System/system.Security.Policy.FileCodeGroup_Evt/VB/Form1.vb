' This sample demonstrates how to use each member of the FileCodeGroup class.
'<Snippet1>
Imports System.Security
Imports System.Security.Policy
Imports System.Security.Permissions
Imports System.Reflection
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Event handler for Run button.
    Private Sub Button1_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        tbxOutput.Cursor = Cursors.WaitCursor
        tbxOutput.Text = ""

        Dim fileCodeGroup As FileCodeGroup = constructDefaultGroup()

        ' Create a deep copy of the FileCodeGroup;
        '<Snippet18>
        Dim copyCodeGroup As FileCodeGroup = _
            CType(fileCodeGroup.Copy(), FileCodeGroup)
        '</Snippet18>

        CompareTwoCodeGroups(fileCodeGroup, copyCodeGroup)

        addPolicy(fileCodeGroup)
        addXmlMember(fileCodeGroup)
        updateMembershipCondition(fileCodeGroup)
        addChildCodeGroup(fileCodeGroup)

        WriteLine("Comparing the resolved code group with the initial " + _
            "code group:")
        Dim resolvedCodeGroup As FileCodeGroup
        resolvedCodeGroup = ResolveGroupToEvidence(fileCodeGroup)

        If (CompareTwoCodeGroups(fileCodeGroup, resolvedCodeGroup)) Then
            PrintCodeGroup(resolvedCodeGroup)
        Else
            PrintCodeGroup(fileCodeGroup)
        End If

        ' Reset the cursor and conclude application.
        tbxOutput.AppendText(vbCrLf + "This sample completed " + _
            "successfully; press Exit to continue.")
        tbxOutput.Cursor = Cursors.Default
    End Sub
    ' Construct a new FileCodeGroup with read, write, append and 
    ' discovery access.
    Private Function constructDefaultGroup() As FileCodeGroup
        ' Construct a file code group with read, write, append and 
        ' discovery access.
        '<Snippet2>
        Dim fileCodeGroup As New FileCodeGroup( _
            New AllMembershipCondition, _
            FileIOPermissionAccess.AllAccess)
        '</Snippet2>

        ' Set the name of the file code group.
        '<Snippet3>
        fileCodeGroup.Name = "TempCodeGroup"
        '</Snippet3>

        ' Set the description of the file code group.
        '<Snippet4>
        fileCodeGroup.Description = "Temp folder permissions group"
        '</Snippet4>

        ' Retrieve the string representation of the Policy's attributes.
        ' FileCodeGroup does not use AttributeString, so the value should
        ' be null.
        '<Snippet5>
        If (Not fileCodeGroup.AttributeString Is Nothing) Then
            Throw New NullReferenceException( _
                "AttributeString property is not empty")
        End If
        '</Snippet5>

        Return fileCodeGroup
    End Function

    ' Add file permission to restrict write access to all files on the 
    ' local machine.
    Private Sub addPolicy(ByRef fileCodeGroup As FileCodeGroup)
        ' Set the PolicyStatement property to a policy with
        ' read access to c:\.
        '<Snippet6>
        Dim rootFilePermissions As New FileIOPermission(PermissionState.None)
        rootFilePermissions.AllLocalFiles = FileIOPermissionAccess.Read
        rootFilePermissions.SetPathList(FileIOPermissionAccess.Read, "C:\\")

        Dim namedPermissions As New NamedPermissionSet("RootPermissions")
        namedPermissions.AddPermission(rootFilePermissions)

        fileCodeGroup.PolicyStatement = New PolicyStatement(namedPermissions)
        '</Snippet6>
    End Sub

    ' Set the membership condition of the specified FileCodeGroup to 
    ' Intranet zone.
    Private Sub updateMembershipCondition( _
        ByRef fileCodeGroup As FileCodeGroup)

        ' Set the membership condition to the Intranet zone.
        '<Snippet7>
        Dim zoneCondition As _
            New ZoneMembershipCondition(SecurityZone.Intranet)

        fileCodeGroup.MembershipCondition = zoneCondition
        '</Snippet7>
    End Sub

    ' Add a child group with read-access file permissions to the specified
    ' code group.
    Private Sub addChildCodeGroup(ByRef fileCodeGroup As FileCodeGroup)
        ' Create a file code group with read access.
        '<Snippet8>
        Dim tempFolderCodeGroup As New FileCodeGroup( _
            New AllMembershipCondition, _
            FileIOPermissionAccess.Read)

        ' Set the name of the child code group and add it to the specified 
        ' code group.
        tempFolderCodeGroup.Name = "Read-only group"
        fileCodeGroup.AddChild(tempFolderCodeGroup)
        '</Snippet8>
    End Sub

    ' Compare two specified FileCodeGroups for equality.
    Private Function CompareTwoCodeGroups( _
        ByVal firstCodeGroup As FileCodeGroup, _
        ByVal secondCodeGroup As FileCodeGroup) As Boolean

        ' Compare two FileCodeGroups for equality.
        '<Snippet20>
        If (firstCodeGroup.Equals(secondCodeGroup)) Then
            '</Snippet20>
            WriteLine("The two code groups are equal.")
            Return True
        Else
            WriteLine("The two code groups are not equal.")
            Return False
        End If

    End Function

    ' Retrieve the resolved policy based on the executing evidence found 
    ' in the specified code group.
    Private Function ResolveEvidence( _
        ByVal fileCodeGroup As CodeGroup) As String

        Dim policyString As String = ""

        ' Resolve the policy based on the executing assemlby's evidence.
        '<Snippet19>
        Dim executingAssembly As [Assembly]
        executingAssembly = Me.GetType().Assembly

        Dim executingEvidence As Evidence = executingAssembly.Evidence

        Dim policy As PolicyStatement
        policy = fileCodeGroup.Resolve(executingEvidence)
        '</Snippet19>

        If (Not policy Is Nothing) Then
            policyString = policy.ToString()
        End If

        Return policyString
    End Function

    ' Retrieve the resolved code group based on the executing evidence found
    ' in the specified code group.
    Private Function ResolveGroupToEvidence( _
        ByVal fileCodeGroup As FileCodeGroup) As FileCodeGroup

        ' Resolve matching code groups to the executing assembly.
        '<Snippet9>
        Dim executingAssembly As [Assembly]
        executingAssembly = Me.GetType().Assembly

        Dim evidence As Evidence = executingAssembly.Evidence

        Dim codeGroup As CodeGroup
        codeGroup = fileCodeGroup.ResolveMatchingCodeGroups(evidence)
        '</Snippet9>

        Return CType(codeGroup, FileCodeGroup)
    End Function

    ' If domain attribute is not found in specified FileCodeGroup, 
    ' add a child Xml element identifying a custom membership condition.
    Private Sub addXmlMember(ByRef fileCodeGroup As FileCodeGroup)
        '<Snippet10>
        Dim xmlElement As SecurityElement = fileCodeGroup.ToXml()
        '</Snippet10>

        Dim rootElement As New SecurityElement("CodeGroup")
        If (xmlElement.Attribute("domain") Is Nothing) Then
            '<Snippet11>
            Dim newElement As New SecurityElement("CustomMembershipCondition")
            newElement.AddAttribute("class", "CustomMembershipCondition")
            newElement.AddAttribute("version", "1")
            newElement.AddAttribute("domain", "contoso.com")

            rootElement.AddChild(newElement)

            fileCodeGroup.FromXml(rootElement)
            '</Snippet11>

        End If

        WriteLine("Added a custom membership condition:")
        WriteLine(rootElement.ToString())
    End Sub

    ' Print the properties of the specified code group to the output textbox.
    Private Sub PrintCodeGroup(ByVal codeGroup As CodeGroup)
        ' Compare specified object's type with the FileCodeGroup type.
        '<Snippet12>
        If (Not codeGroup.GetType() Is GetType(FileCodeGroup)) Then
            '</Snippet12>
            Throw New ArgumentException("Excepted FileCodeGroup type")
        End If

        Dim codeGroupName As String = codeGroup.Name
        Dim membershipCondition As String
        membershipCondition = codeGroup.MembershipCondition.ToString()

        '<Snippet13>
        Dim permissionSetName As String = codeGroup.PermissionSetName
        '</Snippet13>

        '<Snippet14>
        Dim hashCode As Integer = codeGroup.GetHashCode()
        '</Snippet14>

        Dim mergeLogic As String = ""
        '<Snippet15>
        If (codeGroup.MergeLogic.Equals("Union")) Then
            '</Snippet15>
            mergeLogic = " with Union merge logic"
        End If

        ' Retrieve the class path for FileCodeGroup.
        '<Snippet16>
        Dim fileGroupClass As String = codeGroup.ToString()
        '</Snippet16>

        ' Write summary to console window.
        WriteLine(vbCrLf + "*** " + fileGroupClass + " summary ***")
        Write("A FileCodeGroup named " + codeGroupName + mergeLogic)
        Write(" has been created with hash code(" + hashCode.ToString())
        Write("). It contains a " + membershipCondition)
        Write(" membership condition with the ")
        Write(permissionSetName + " permission set. ")

        WriteLine("It has the following policy: " + _
            ResolveEvidence(codeGroup))
        Dim childCount As Integer = codeGroup.Children.Count
        If (childCount > 0) Then
            Write("There are " + childCount.ToString())
            WriteLine(" child elements in the code group:")

            ' Iterate through the child code groups to display their names and
            '  remove them from the specified code group.
            For i As Int16 = 0 To childCount - 1 Step 1
                ' Get child code group as type FileCodeGroup.
                '<Snippet21>
                Dim childCodeGroup As FileCodeGroup
                childCodeGroup = CType(codeGroup.Children(i), FileCodeGroup)
                '</Snippet21>

                Write("Removing the " + childCodeGroup.Name + ".")
                ' Remove child codegroup.
                '<Snippet17>
                codeGroup.RemoveChild(childCodeGroup)
                '</Snippet17>
            Next

            WriteLine("")

        Else
            WriteLine("There are no children found in the code group:")

        End If
    End Sub
    ' Write message to the output textbox.
    Private Sub Write(ByVal message As String)
        tbxOutput.AppendText(message)

    End Sub
    ' Write message with carriage return to the output textbox.
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
        Me.Text = "FileCodeGroup"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
End Class
'
' This sample produces the following output:
'
' The two code groups are equal.
' Added a custom membership condition:
' <CodeGroup>
'    <CustomMembershipCondition class="CustomMembershipCondition"
'                               version="1"
'                               domain="contoso.com"/>
' </CodeGroup>
' 
' Comparing the resolved code group with the initial code group:
' The two code groups are not equal.
' 
' *** System.Security.Policy.FileCodeGroup summary ***
' A FileCodeGroup named  with Union merge logic has been created with hash
' code (113152269). It contains a Zone - Intranet membership condition with
' the Same directory FileIO - NoAccess permission set. Has the following
' policy: 
' There are 1 child elements in the code group:
' Removing the Read-only group.
' 
' This sample completed successfully; press Exit to continue.
'</Snippet1>