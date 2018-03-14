' <Snippet3>
Imports System
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO
Imports Microsoft.CSharp
Imports Microsoft.VisualBasic
Imports Microsoft.JScript


Namespace CodeDOMSamples
    _
    '/ <summary>
    '/ Provides a wrapper for CodeDOM samples.
    '/ </summary>
    Public Class Form1
        Inherits System.Windows.Forms.Form
        Private cu As System.CodeDom.CodeCompileUnit
        Private textBox1 As System.Windows.Forms.TextBox
        Private WithEvents button1 As System.Windows.Forms.Button
        Private WithEvents button2 As System.Windows.Forms.Button
        Private groupBox1 As System.Windows.Forms.GroupBox
        Private WithEvents radioButton1 As System.Windows.Forms.RadioButton
        Private WithEvents radioButton2 As System.Windows.Forms.RadioButton
        Private WithEvents radioButton3 As System.Windows.Forms.RadioButton
        Private language As Integer = 1 ' 1 = Csharp 2 = VB 3 = JScript
        Private components As System.ComponentModel.Container = Nothing


        Public Sub New()
            InitializeComponent()

            cu = CreateGraph()
        End Sub 'New


        ' <Snippet2>
        Public Function CreateGraph() As CodeCompileUnit
            ' Create a compile unit to contain a CodeDOM graph
            Dim cu As New CodeCompileUnit()

            ' Create a namespace named "TestSpace"
            Dim cn As New CodeNamespace("TestSpace")

            ' Create a new type named "TestClass"	
            Dim cd As New CodeTypeDeclaration("TestClass")

            ' Create a new entry point method
            Dim cm As New CodeEntryPointMethod()

            ' Declare a variable of type Int32 named "i"
            Dim cv1 As New CodeVariableDeclarationStatement("System.Int32", "i")

            ' Add the variable declaration statement to the entry point method
            cm.Statements.Add(cv1)

            ' <Snippet1>	
            ' Assigns the value 10 to the integer variable "i".
            Dim as1 As New CodeAssignStatement(New CodeVariableReferenceExpression("i"), New CodePrimitiveExpression(10))

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            ' i = 10
            ' </Snippet1>

            ' Add the assignment statement to the entry point method
            cm.Statements.Add(as1)

            ' Add the entry point method to the "TestClass" type
            cd.Members.Add(cm)

            ' Add the "TestClass" type to the namespace
            cn.Types.Add(cd)

            ' Add the "TestSpace" namespace to the compile unit
            cu.Namespaces.Add(cn)

            Return cu
        End Function 'CreateGraph

        ' </Snippet2>
        Private Sub OutputGraph()
            ' Create string writer to output to textbox
            Dim sw As New StringWriter()

            ' Create appropriate CodeProvider
            Dim cp As System.CodeDom.Compiler.CodeDomProvider
            Select Case language
                Case 2 ' VB
                    cp = CodeDomProvider.CreateProvider("VisualBasic")
                Case 3 ' JScript
                    cp = CodeDomProvider.CreateProvider("JScript")
                Case Else ' CSharp
                    cp = CodeDomProvider.CreateProvider("CSharp")
            End Select

            ' Create a code generator that will output to the string writer
            Dim cg As ICodeGenerator = cp.CreateGenerator(sw)

            ' Generate code from the compile unit and outputs it to the string writer
            cg.GenerateCodeFromCompileUnit(cu, sw, New CodeGeneratorOptions())

            ' Output the contents of the string writer to the textbox	
            Me.textBox1.Text = sw.ToString()
        End Sub 'OutputGraph


        Protected Overloads Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub 'Dispose


        '/ <summary>
        '/ Required method for Designer support - do not modify
        '/ the contents of this method with the code editor.
        '/ </summary>
        Private Sub InitializeComponent()
            Me.textBox1 = New System.Windows.Forms.TextBox()
            Me.button1 = New System.Windows.Forms.Button()
            Me.button2 = New System.Windows.Forms.Button()
            Me.groupBox1 = New System.Windows.Forms.GroupBox()
            Me.radioButton1 = New System.Windows.Forms.RadioButton()
            Me.radioButton2 = New System.Windows.Forms.RadioButton()
            Me.radioButton3 = New System.Windows.Forms.RadioButton()
            Me.groupBox1.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' textBox1
            ' 
            Me.textBox1.Location = New System.Drawing.Point(16, 112)
            Me.textBox1.Multiline = True
            Me.textBox1.Name = "textBox1"
            Me.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.textBox1.Size = New System.Drawing.Size(664, 248)
            Me.textBox1.TabIndex = 0
            Me.textBox1.Text = ""
            Me.textBox1.WordWrap = False
            ' 
            ' button1
            ' 
            Me.button1.BackColor = System.Drawing.Color.Aquamarine
            Me.button1.Location = New System.Drawing.Point(16, 16)
            Me.button1.Name = "button1"
            Me.button1.TabIndex = 1
            Me.button1.Text = "Generate"
            ' 
            ' button2
            ' 
            Me.button2.BackColor = System.Drawing.Color.MediumTurquoise
            Me.button2.Location = New System.Drawing.Point(112, 16)
            Me.button2.Name = "button2"
            Me.button2.TabIndex = 2
            Me.button2.Text = "Show Code"
            ' 
            ' groupBox1
            ' 
            Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.radioButton3, Me.radioButton2, Me.radioButton1})
            Me.groupBox1.Location = New System.Drawing.Point(16, 48)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(384, 56)
            Me.groupBox1.TabIndex = 3
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = "Language selection"
            ' 
            ' radioButton1
            ' 
            Me.radioButton1.Checked = True
            Me.radioButton1.Location = New System.Drawing.Point(16, 24)
            Me.radioButton1.Name = "radioButton1"
            Me.radioButton1.TabIndex = 0
            Me.radioButton1.TabStop = True
            Me.radioButton1.Text = "CSharp"
            ' 
            ' radioButton2
            ' 
            Me.radioButton2.Location = New System.Drawing.Point(144, 24)
            Me.radioButton2.Name = "radioButton2"
            Me.radioButton2.TabIndex = 1
            Me.radioButton2.Text = "Visual Basic"
            ' 
            ' radioButton3
            ' 
            Me.radioButton3.Location = New System.Drawing.Point(272, 24)
            Me.radioButton3.Name = "radioButton3"
            Me.radioButton3.TabIndex = 2
            Me.radioButton3.Text = "JScript"
            ' 
            ' Form1
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(714, 367)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.groupBox1, Me.button2, Me.button1, Me.textBox1})
            Me.Name = "Form1"
            Me.Text = "CodeDOM Samples Framework"
            Me.groupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub 'InitializeComponent


        Private Sub ShowCode()
            Me.textBox1.Text = ""
        End Sub 'ShowCode


        ' Show code button
        Private Sub button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button2.Click
            ShowCode()
        End Sub 'button2_Click


        ' Generate and show code button
        Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
            OutputGraph()
        End Sub 'button1_Click


        ' Csharp language selection button
        Private Sub radioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioButton1.Click
            radioButton1.Checked = True
            radioButton2.Checked = False
            radioButton3.Checked = False

            language = 1
        End Sub 'radioButton1_CheckedChanged


        ' Visual Basic language selection button
        Private Sub radioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioButton2.Click
            radioButton1.Checked = False
            radioButton2.Checked = True
            radioButton3.Checked = False

            language = 2
        End Sub 'radioButton2_CheckedChanged


        ' JScript language selection button
        Private Sub radioButton3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioButton3.Click
            radioButton1.Checked = False
            radioButton2.Checked = False
            radioButton3.Checked = True

            language = 3
        End Sub 'radioButton3_CheckedChanged
    End Class 'Form1 
End Namespace 'CodeDOMSamples
' </Snippet3>