' This sample demonstrates how to use each member of the FirstMatchCodeGroup
' class.
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

        ' Create a new FirstMatchCodeGroup.
        Dim codeGroup As FirstMatchCodeGroup = constructDefaultGroup()

        ' Create a deep copy of the FirstMatchCodeGroup.
        '<Snippet18>
        Dim copyCodeGroup As FirstMatchCodeGroup
        copyCodeGroup = CType(codeGroup.Copy(), FirstMatchCodeGroup)
        '</Snippet18>

        ' Compare the original code group with the copy.
        CompareTwoCodeGroups(codeGroup, copyCodeGroup)

        addPolicy(codeGroup)
        addXmlMember(codeGroup)
        updateMembershipCondition(codeGroup)
        addChildCodeGroup(codeGroup)

        Write("Comparing the resolved code group ")
        WriteLine("with the initial code group.")

        Dim resolvedCodeGroup As FirstMatchCodeGroup
        resolvedCodeGroup = ResolveGroupToEvidence(codeGroup)
        If (CompareTwoCodeGroups(codeGroup, resolvedCodeGroup)) Then
            PrintCodeGroup(resolvedCodeGroup)
        Else
            PrintCodeGroup(codeGroup)
        End If

        ' Reset the cursor and conclude application.
        tbxOutput.AppendText(vbCrLf + "This sample completed " + _
            "successfully; press Exit to continue.")
        tbxOutput.Cursor = Cursors.Default
    End Sub
    ' Create a FirstMatchCodeGroup with an exclusive policy and membership
    ' condition.
    Private Function constructDefaultGroup() As FirstMatchCodeGroup
        ' Construct a new FirstMatchCodeGroup with Read, Write, Append 
        ' and PathDiscovery access.
        ' Create read access permission to the root directory on drive C.
        '<Snippet2>
        Dim rootFilePermissions As New FileIOPermission(PermissionState.None)
        rootFilePermissions.AllLocalFiles = FileIOPermissionAccess.Read
        rootFilePermissions.SetPathList(FileIOPermissionAccess.Read, "C:\\")

        ' Add a permission to a named permission set.
        Dim namedPermissions As New NamedPermissionSet("RootPermissions")
        namedPermissions.AddPermission(rootFilePermissions)

        ' Create a PolicyStatement with exclusive rights to the policy.
        Dim policy As New PolicyStatement( _
            namedPermissions, _
            PolicyStatementAttribute.Exclusive)

        ' Create a FirstMatchCodeGroup with a membership condition that 
        ' matches all code, and an exclusive policy.
        Dim codeGroup As New FirstMatchCodeGroup( _
            New AllMembershipCondition, _
            policy)
        '</Snippet2>

        ' Set the name of the first match code group.
        '<Snippet3>
        codeGroup.Name = "TempCodeGroup"
        '</Snippet3>

        ' Set the description of the first match code group.
        '<Snippet4>
        codeGroup.Description = "Temp folder permissions group"
        '</Snippet4>

        Return codeGroup
    End Function

    ' Add file permission to restrict write access to all files 
    ' on the local machine.
    Private Sub addPolicy(ByRef codeGroup As FirstMatchCodeGroup)
        ' Set the PolicyStatement property to a policy with read access to the
        ' root directory on drive C.
        '<Snippet6>
        Dim rootFilePermissions As New FileIOPermission(PermissionState.None)
        rootFilePermissions.AllLocalFiles = FileIOPermissionAccess.Read
        rootFilePermissions.SetPathList(FileIOPermissionAccess.Read, "C:\\")

        Dim namedPermissions As New NamedPermissionSet("RootPermissions")
        namedPermissions.AddPermission(rootFilePermissions)

        ' Create a PolicyStatement with exclusive rights to the policy.
        Dim policy As New PolicyStatement( _
            namedPermissions, _
            PolicyStatementAttribute.Exclusive)

        codeGroup.PolicyStatement = policy
        '</Snippet6>
    End Sub

    ' Set the membership condition of the code group.
    Private Sub updateMembershipCondition( _
        ByRef codeGroup As FirstMatchCodeGroup)

        ' Set the membership condition of the specified FirstMatchCodeGroup 
        ' to the Intranet zone.
        '<Snippet7>
        Dim zoneCondition As _
            New ZoneMembershipCondition(SecurityZone.Intranet)
        codeGroup.MembershipCondition = zoneCondition
        '</Snippet7>
    End Sub

    ' Create a child code group with read-access file permissions and add it
    ' to the specified code group.
    Private Sub addChildCodeGroup(ByRef codegroup As FirstMatchCodeGroup)
        ' Create a first match code group with read access.
        '<Snippet8>
        Dim rootFilePermissions As New FileIOPermission(PermissionState.None)
        rootFilePermissions.AllLocalFiles = FileIOPermissionAccess.Read
        rootFilePermissions.SetPathList(FileIOPermissionAccess.Read, "C:\\")

        Dim permissions As New PermissionSet(PermissionState.Unrestricted)
        permissions.AddPermission(rootFilePermissions)

        Dim tempFolderCodeGroup = New FirstMatchCodeGroup( _
            New AllMembershipCondition, _
            New PolicyStatement(permissions))

        ' Set the name of the child code group and add it to the specified
        ' code group.
        tempFolderCodeGroup.Name = "Read-only code group"
        codegroup.AddChild(tempFolderCodeGroup)
        '</Snippet8>
    End Sub

    ' Compare the two FirstMatchCodeGroups.
    Private Function CompareTwoCodeGroups( _
        ByVal firstCodeGroup As FirstMatchCodeGroup, _
        ByVal secondCodeGroup As FirstMatchCodeGroup) As Boolean

        ' Compare the two specified FirstMatchCodeGroups for equality.
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

    ' Retrieve the resolved policy based on executing evidence found 
    ' in the specified code group.
    Private Function ResolveEvidence(ByVal codeGroup As CodeGroup) As String
        Dim policyString As String = "None"

        ' Resolve the policy based on the executing assembly's evidence.
        '<Snippet19>
        Dim executingAssembly As [Assembly] = Me.GetType().Assembly
        Dim executingEvidence As Evidence
        executingEvidence = executingAssembly.Evidence

        Dim policy As PolicyStatement = codeGroup.Resolve(executingEvidence)
        '</Snippet19>

        If (Not policy Is Nothing) Then
            policyString = policy.ToString()
        End If

        Return policyString
    End Function

    ' Retrieve the resolved code group based on the evidence from the 
    ' specified code group.
    Private Function ResolveGroupToEvidence( _
        ByVal codegroup As FirstMatchCodeGroup) _
        As FirstMatchCodeGroup

        ' Resolve matching code groups to the executing assembly.
        '<Snippet9>
        Dim executingAssembly As [Assembly] = Me.GetType().Assembly
        Dim evidence As Evidence = executingAssembly.Evidence
        Dim resolvedCodeGroup As CodeGroup
        resolvedCodeGroup = codegroup.ResolveMatchingCodeGroups(Evidence)
        '</Snippet9>

        Return CType(resolvedCodeGroup, FirstMatchCodeGroup)
    End Function

    ' If a domain attribute is not found in the specified FirstMatchCodeGroup,
    ' add a child XML element identifying a custom membership condition.
    Private Sub addXmlMember(ByRef codeGroup As FirstMatchCodeGroup)
        '<Snippet10>
        Dim xmlElement As SecurityElement = codeGroup.ToXml()
        '</Snippet10>

        Dim rootElement As New SecurityElement("CodeGroup")

        If (xmlElement.Attribute("domain") Is Nothing) Then
            '<Snippet11>
            Dim newElement As New SecurityElement("CustomMembershipCondition")
            newElement.AddAttribute("class", "CustomMembershipCondition")
            newElement.AddAttribute("version", "1")
            newElement.AddAttribute("domain", "contoso.com")

            rootElement.AddChild(newElement)

            codeGroup.FromXml(rootElement)
            '</Snippet11>
        End If

        WriteLine("Added a custom membership condition:")
        WriteLine(rootElement.ToString())
    End Sub

    ' Print the properties of the specified code group to the console.
    Private Sub PrintCodeGroup(ByVal codeGroup As CodeGroup)
        ' Compare the type of the specified object with the
        ' FirstMatchCodeGroup type.
        '<Snippet12>
        If (Not codeGroup.GetType() Is GetType(FirstMatchCodeGroup)) Then
            '</Snippet12>
            Throw New ArgumentException( _
                "Expected the FirstMatchCodeGroup type.")

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
        If (codeGroup.MergeLogic.Equals("First Match")) Then
            '</Snippet15>
            mergeLogic = "with first-match merge logic"
        End If

        ' Retrieve the class path for the FirstMatchCodeGroup.
        '<Snippet16>
        Dim firstMatchGroupClass As String = codeGroup.ToString()
        '</Snippet16>

        Dim attributeString As String = ""
        ' Retrieve the string representation of the FirstMatchCodeGroup's
        ' attributes.
        '<Snippet5>
        If (Not codeGroup.AttributeString Is Nothing) Then
            attributeString = codeGroup.AttributeString
        End If
        '</Snippet5>

        ' Write a summary to the console window.
        WriteLine(vbCrLf + "* " + firstMatchGroupClass + " summary *")
        Write("A FirstMatchCodeGroup named ")
        Write(codeGroupName + mergeLogic)
        Write(" has been created with hash code ")
        WriteLine(hashCode.ToString() + ". ")

        Write("This code group contains a " + membershipCondition)
        Write(" membership condition with the ")
        Write(permissionSetName + " permission set. ")

        Write("The code group contains the following policy: ")
        Write(ResolveEvidence(codeGroup) + ". ")
        Write("It also contains the following attributes: ")
        WriteLine(attributeString)

        Dim childCount As Integer = codeGroup.Children.Count
        If (childCount > 0) Then
            Write("There are " + childCount.ToString())
            WriteLine(" child elements in the code group.")

            ' Iterate through the child code groups to display their names
            ' and then remove them from the specified code group.
            For i As Int16 = 0 To childCount - 1 Step 1
                ' Retrieve each child explicitly casted as a 
                ' FirstMatchCodeGroup type.
                '<Snippet21>
                Dim childCodeGroup As FirstMatchCodeGroup
                childCodeGroup = _
                    CType(codeGroup.Children(i), FirstMatchCodeGroup)
                '</Snippet21>

                Write("Removing the " + childCodeGroup.Name + ".")
                ' Remove the child code group.
                '<Snippet17>
                codeGroup.RemoveChild(childCodeGroup)
                '</Snippet17>
            Next

            WriteLine("")
        Else
            WriteLine("No child code groups were found in this code group.")
        End If
    End Sub

    Private Sub WriteLine(ByVal message As String)
        tbxOutput.AppendText(message + vbCrLf)

    End Sub

    Private Sub Write(ByVal message As String)
        tbxOutput.AppendText(message)

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
        Me.Text = "FirstMatchCodeGroup"
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
' Comparing the resolved code group with the initial code group.
' The two code groups are not equal.
' 
' * System.Security.Policy.FirstMatchCodeGroup summary *
' A FirstMatchCodeGroup named with first-match merge logic has been created
' with hash code 113155593. This code group contains a Zone - Intranet 
' membership condition with the  permission set. The code group contains the
' following policy: None. It also contains the following attributes: 
' There are 1 child elements in the code group.
' Removing the Read-only code group.
' 
' This sample completed successfully; press Exit to continue.
'</Snippet1>