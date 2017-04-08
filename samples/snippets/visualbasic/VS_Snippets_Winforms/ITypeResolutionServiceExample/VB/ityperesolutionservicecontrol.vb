 '<Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Reflection
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
Imports Microsoft.VisualBasic

' This control provides an example design-time user interface to 
' the ITypeResolutionService.
<DesignerAttribute(GetType(WindowMessageDesigner), GetType(IDesigner))>  _
Public Class ITypeResolutionServiceControl
   Inherits System.Windows.Forms.UserControl
   ' Reference to a type resolution service interface, or null 
   ' if not obtained.
   Private rs As ITypeResolutionService
   ' Textbox for input of assembly and type names.
   Private entryBox As System.Windows.Forms.TextBox
   ' Textbox for output of assembly, type, and status information.
   Private infoBox As System.Windows.Forms.TextBox
   ' Panel to contain the radiobuttons used to select the 
   ' method to InvokeMethod.
   Private panel1 As System.Windows.Forms.Panel
   Private radioButton1 As System.Windows.Forms.RadioButton
   Private radioButton2 As System.Windows.Forms.RadioButton
   Private radioButton3 As System.Windows.Forms.RadioButton
   Private radioButton4 As System.Windows.Forms.RadioButton
   ' Label to display textbox entry information.
   Private label1 As System.Windows.Forms.Label
   ' Button to InvokeMethod command.
   Private button1 As System.Windows.Forms.Button

    Public Sub New()
        InitializeComponent()
        rs = Nothing
        ' Attaches event handlers for control clicked events.
        AddHandler radioButton1.CheckedChanged, AddressOf Me.GetAssembly
        AddHandler radioButton2.CheckedChanged, AddressOf Me.GetPathToAssembly
        AddHandler radioButton3.CheckedChanged, AddressOf Me.GetInstanceOfType
        AddHandler radioButton4.CheckedChanged, AddressOf Me.ReferenceAssembly
        AddHandler button1.Click, AddressOf Me.InvokeMethod
        AddHandler entryBox.KeyUp, AddressOf Me.InvokeOnEnterKeyHandler
    End Sub

    ' Displays example control name and status information.
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawString("ITypeResolutionService Interface Control", New Font(FontFamily.GenericMonospace, 9), New SolidBrush(Color.Blue), 5, 5)
        If Me.DesignMode Then
            e.Graphics.DrawString("Currently in Design Mode", New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.DarkGreen), 350, 2)
        Else
            e.Graphics.DrawString("Requires Design Mode", New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Red), 350, 2)
        End If
        If (rs IsNot Nothing) Then
            e.Graphics.DrawString("Type Resolution Service Obtained", New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.DarkGreen), 350, 12)
        Else
            e.Graphics.DrawString("Type Resolution Service Not Obtained", New Font(FontFamily.GenericMonospace, 8), New SolidBrush(Color.Red), 350, 12)
        End If
    End Sub

    ' InvokeMethods the currently selected method, if any, when 
    ' the InvokeMethod button is pressed.
    Private Sub InvokeMethod(ByVal sender As Object, ByVal e As EventArgs)
        ' If the GetAssembly or GetPathofAssembly radio button 
        ' is selected.
        If Me.radioButton1.Checked OrElse Me.radioButton2.Checked OrElse Me.radioButton4.Checked Then
            If Me.entryBox.Text.Length = 0 Then
                ' If there is no assembly name specified, display status message.
                Me.infoBox.Text = "You must enter the name of the assembly to retrieve."
            ElseIf (rs IsNot Nothing) Then
                ' Create a System.Reflection.AssemblyName 
                ' for the entered text.
                Dim name As New AssemblyName()
                name.Name = Me.entryBox.Text.Trim()

                ' If the GetAssembly radio button is checked...
                If Me.radioButton1.Checked Then
                    ' Use the ITypeResolutionService to attempt to 
                    ' resolve an assembly reference.
                    Dim a As [Assembly] = rs.GetAssembly(name, False)
                    ' If an assembly matching the specified name was not 
                    ' located in the GAC or local project references, 
                    ' display a message.
                    If a Is Nothing Then
                        Me.infoBox.Text = "The " + Me.entryBox.Text + " assembly could not be located."
                    Else
                        ' An assembly matching the specified name was located.
                        ' Builds a list of types.
                        Dim types As Type() = a.GetTypes()
                        Dim sb As New StringBuilder()
                        Dim i As Integer
                        For i = 0 To types.Length - 1
                            sb.Append((types(i).FullName + ControlChars.Cr + ControlChars.Lf))
                        Next i
                        Dim path As String = rs.GetPathOfAssembly(name)
                        ' Displays assembly information and a list of types contained in the assembly.
                        Me.infoBox.Text = "Assembly located:" + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf + a.FullName + ControlChars.Cr + ControlChars.Lf + "  at: " + path + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf + "Assembly types:" + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf + sb.ToString()
                    End If
                ElseIf Me.radioButton2.Checked Then
                    Dim path As String = rs.GetPathOfAssembly(name)
                    If (path IsNot Nothing) Then
                        Me.infoBox.Text = "Assembly located at:" + ControlChars.Cr + ControlChars.Lf + path
                    Else
                        Me.infoBox.Text = "Assembly was not located."
                    End If
                ElseIf Me.radioButton4.Checked Then
                    Dim a As [Assembly] = Nothing
                    Try
                        ' Add a reference to the assembly to the 
                        ' current project.
                        rs.ReferenceAssembly(name)
                        ' Use the ITypeResolutionService to attempt 
                        ' to resolve an assembly reference.
                        a = rs.GetAssembly(name, False)
                    Catch
                    End Try
                    ' Catch this exception so that the exception 
                    ' does not interrupt control behavior.
                    ' If an assembly matching the specified name was not 
                    ' located in the GAC or local project references, 
                    ' display a message.
                    If a Is Nothing Then
                        Me.infoBox.Text = "The " + Me.entryBox.Text + " assembly could not be located."
                    Else
                        Me.infoBox.Text = "A reference to the " + a.FullName + " assembly has been added to the project's referenced assemblies."
                    End If
                End If
            End If
        Else
            If Me.radioButton3.Checked Then
                If Me.entryBox.Text.Length = 0 Then
                    ' If there is no type name specified, display a 
                    ' status message.
                    Me.infoBox.Text = "You must enter the name of the type to retrieve."
                Else
                    If (rs IsNot Nothing) Then
                        Dim type As Type = Nothing
                        Try
                            type = rs.GetType(Me.entryBox.Text, False, True)
                        Catch  ' Consume exceptions raised during GetType call
                        End Try
                        If (type IsNot Nothing) Then
                            ' Display type information.
                            Me.infoBox.Text = "Type: " + type.FullName + " located." + ControlChars.Cr + ControlChars.Lf + "  Namespace: " + type.Namespace + ControlChars.Cr + ControlChars.Lf + type.AssemblyQualifiedName
                        Else
                            Me.infoBox.Text = "Type not located."
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GetAssembly(ByVal sender As Object, ByVal e As EventArgs)
        If Me.radioButton1.Checked Then
            Me.label1.Text = "Enter the assembly name:"
        End If
    End Sub

    Private Sub GetPathToAssembly(ByVal sender As Object, ByVal e As EventArgs)
        If Me.radioButton2.Checked Then
            Me.label1.Text = "Enter the assembly name:"
        End If
    End Sub

    Private Sub GetInstanceOfType(ByVal sender As Object, ByVal e As EventArgs)
        If Me.radioButton3.Checked Then
            Me.label1.Text = "Enter the type name:"
        End If
    End Sub

    Private Sub ReferenceAssembly(ByVal sender As Object, ByVal e As EventArgs)
        If Me.radioButton4.Checked Then
            Me.label1.Text = "Enter the assembly name:"
        End If
    End Sub

    Private Sub InvokeOnEnterKeyHandler(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Me.InvokeMethod(sender, New EventArgs())
        End If
    End Sub

    Public Overrides Property Site() As System.ComponentModel.ISite
        Get
            Return MyBase.Site
        End Get
        Set(ByVal Value As System.ComponentModel.ISite)
            MyBase.Site = Value

            ' Attempts to obtain ITypeResolutionService interface.
            rs = CType(Me.GetService(GetType(ITypeResolutionService)), ITypeResolutionService)
        End Set
    End Property

    Private Sub InitializeComponent()
        Me.entryBox = New System.Windows.Forms.TextBox()
        Me.infoBox = New System.Windows.Forms.TextBox()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.radioButton1 = New System.Windows.Forms.RadioButton()
        Me.radioButton2 = New System.Windows.Forms.RadioButton()
        Me.radioButton3 = New System.Windows.Forms.RadioButton()
        Me.radioButton4 = New System.Windows.Forms.RadioButton()
        Me.label1 = New System.Windows.Forms.Label()
        Me.button1 = New System.Windows.Forms.Button()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        ' entryBox
        Me.entryBox.Location = New System.Drawing.Point(176, 80)
        Me.entryBox.Name = "entryBox"
        Me.entryBox.Size = New System.Drawing.Size(320, 20)
        Me.entryBox.TabIndex = 0
        Me.entryBox.Text = ""
        ' infoBox
        Me.infoBox.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
        Me.infoBox.Location = New System.Drawing.Point(16, 111)
        Me.infoBox.Multiline = True
        Me.infoBox.Name = "infoBox"
        Me.infoBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.infoBox.Size = New System.Drawing.Size(592, 305)
        Me.infoBox.TabIndex = 1
        Me.infoBox.Text = ""
        ' panel1
        Me.panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.radioButton4, Me.radioButton3, Me.radioButton2, Me.radioButton1})
        Me.panel1.Location = New System.Drawing.Point(16, 32)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(480, 40)
        Me.panel1.TabIndex = 2
        ' radioButton1
        Me.radioButton1.Location = New System.Drawing.Point(8, 8)
        Me.radioButton1.Name = "radioButton1"
        Me.radioButton1.Size = New System.Drawing.Size(96, 24)
        Me.radioButton1.TabIndex = 0
        Me.radioButton1.Text = "GetAssembly"
        ' radioButton2
        Me.radioButton2.Location = New System.Drawing.Point(112, 8)
        Me.radioButton2.Name = "radioButton2"
        Me.radioButton2.Size = New System.Drawing.Size(128, 24)
        Me.radioButton2.TabIndex = 1
        Me.radioButton2.Text = "GetPathToAssembly"
        ' radioButton3
        Me.radioButton3.Location = New System.Drawing.Point(248, 8)
        Me.radioButton3.Name = "radioButton3"
        Me.radioButton3.Size = New System.Drawing.Size(80, 24)
        Me.radioButton3.TabIndex = 2
        Me.radioButton3.Text = "GetType"
        ' radioButton4
        Me.radioButton4.Location = New System.Drawing.Point(344, 8)
        Me.radioButton4.Name = "radioButton4"
        Me.radioButton4.Size = New System.Drawing.Size(128, 24)
        Me.radioButton4.TabIndex = 3
        Me.radioButton4.Text = "ReferenceAssembly"
        ' label1
        Me.label1.Location = New System.Drawing.Point(18, 83)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(150, 16)
        Me.label1.TabIndex = 3
        ' button1
        Me.button1.Location = New System.Drawing.Point(519, 41)
        Me.button1.Name = "button1"
        Me.button1.TabIndex = 4
        Me.button1.Text = "Invoke"
        ' ITypeResolutionServiceControl
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1, Me.label1, Me.panel1, Me.infoBox, Me.entryBox})
        Me.Name = "ITypeResolutionServiceControl"
        Me.Size = New System.Drawing.Size(624, 432)
        Me.panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

End Class

' Since this example provides a control-based user interface 
' in design mode, this designer passes window messages to the 
' controls at design time.   
Public Class WindowMessageDesigner
    Inherits System.Windows.Forms.Design.ControlDesigner

    Public Sub New()
    End Sub

    ' Window procedure override passes events to the control.
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.HWnd.Equals(Me.Control.Handle) Then
            MyBase.WndProc(m)
        Else
            Me.DefWndProc(m)
        End If
    End Sub 'WndProc

    Public Overrides Sub DoDefaultAction()
    End Sub

End Class
'</Snippet1>
