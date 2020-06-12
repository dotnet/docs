'<Snippet1>
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.CSharp
Imports Microsoft.JScript

' This example demonstrates building a Hello World program graph 
' using System.CodeDom elements. It calls code generator and
' code compiler methods to build the program using CSharp, VB, or
' JScript.  A Windows Forms interface is included. Note: Code
' must be compiled and linked with the Microsoft.JScript assembly. 
Namespace CodeDOMExample

    Class CodeDomExample
        '<Snippet2>
        ' Build a Hello World program graph using 
        ' System.CodeDom types.
        Public Shared Function BuildHelloWorldGraph() As CodeCompileUnit

            ' Create a new CodeCompileUnit to contain 
            ' the program graph.
            Dim compileUnit As New CodeCompileUnit()

            ' Declare a new namespace called Samples.
            Dim samples As New CodeNamespace("Samples")

            ' Add the new namespace to the compile unit.
            compileUnit.Namespaces.Add(samples)

            ' Add the new namespace import for the System namespace.
            samples.Imports.Add(New CodeNamespaceImport("System"))

            ' Declare a new type called Class1.
            Dim class1 As New CodeTypeDeclaration("Class1")

            ' Add the new type to the namespace type collection.
            samples.Types.Add(class1)

            ' Declare a new code entry point method.
            Dim start As New CodeEntryPointMethod()

            ' Create a type reference for the System.Console class.
            Dim csSystemConsoleType As New CodeTypeReferenceExpression( _
                "System.Console")

            ' Build a Console.WriteLine statement.
            Dim cs1 As New CodeMethodInvokeExpression( _
                csSystemConsoleType, "WriteLine", _
                New CodePrimitiveExpression("Hello World!"))

            ' Add the WriteLine call to the statement collection.
            start.Statements.Add(cs1)

            ' Build another Console.WriteLine statement.
            Dim cs2 As New CodeMethodInvokeExpression( _
                csSystemConsoleType, "WriteLine", _
                New CodePrimitiveExpression("Press the Enter key to continue."))

            ' Add the WriteLine call to the statement collection.
            start.Statements.Add(cs2)

            ' Build a call to System.Console.ReadLine.
            Dim csReadLine As New CodeMethodInvokeExpression( _
                csSystemConsoleType, "ReadLine")

            ' Add the ReadLine statement.
            start.Statements.Add(csReadLine)

            ' Add the code entry point method to
            ' the Members collection of the type.
            class1.Members.Add(start)

            Return compileUnit
        End Function
        '</Snippet2>

        '<Snippet3>
        Public Shared Sub GenerateCode(ByVal provider As CodeDomProvider, ByVal compileunit As CodeCompileUnit)

            ' Build the source file name with the appropriate
            ' language extension.
            Dim sourceFile As String
            If provider.FileExtension.StartsWith(".") Then
                sourceFile = "TestGraph" + provider.FileExtension
            Else
                sourceFile = "TestGraph." + provider.FileExtension
            End If

            ' Create an IndentedTextWriter, constructed with
            ' a StreamWriter to the source file.
            Dim tw As New IndentedTextWriter(New StreamWriter(sourceFile, False), "    ")
            ' Generate source code using the code generator.
            provider.GenerateCodeFromCompileUnit(compileunit, tw, New CodeGeneratorOptions())
            ' Close the output file.
            tw.Close()
        End Sub
        '</Snippet3>

        '<Snippet4>
        Public Shared Function CompileCode(ByVal provider As CodeDomProvider, _
                                           ByVal sourceFile As String, _
                                           ByVal exeFile As String) As CompilerResults

            ' Configure a CompilerParameters that links System.dll
            ' and produces the specified executable file.
            Dim referenceAssemblies As String() = {"System.dll"}
            Dim cp As New CompilerParameters(referenceAssemblies, exeFile, False)

            ' Generate an executable rather than a DLL file.
            cp.GenerateExecutable = True

            ' Invoke compilation.
            Dim cr As CompilerResults = provider.CompileAssemblyFromFile(cp, _
                sourceFile)
            ' Return the results of compilation.
            Return cr
        End Function
        '</Snippet4>
    End Class

    Public Class CodeDomExampleForm
        Inherits System.Windows.Forms.Form
        Private run_button As New System.Windows.Forms.Button()
        Private compile_button As New System.Windows.Forms.Button()
        Private generate_button As New System.Windows.Forms.Button()
        Private textBox1 As New System.Windows.Forms.TextBox()
        Private comboBox1 As New System.Windows.Forms.ComboBox()
        Private label1 As New System.Windows.Forms.Label()

        Private Sub generate_button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim provider As CodeDomProvider = GetCurrentProvider()
            CodeDomExample.GenerateCode(provider, CodeDomExample.BuildHelloWorldGraph())

            ' Build the source file name with the appropriate
            ' language extension.
            Dim sourceFile As String
            If provider.FileExtension.StartsWith(".") Then
                sourceFile = "TestGraph" + provider.FileExtension
            Else
                sourceFile = "TestGraph." + provider.FileExtension
            End If

            ' Read in the generated source file and
            ' display the source text.
            Dim sr As New StreamReader(sourceFile)
            textBox1.Text = sr.ReadToEnd()
            sr.Close()
        End Sub

        Private Sub compile_button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim provider As CodeDomProvider = GetCurrentProvider()

            ' Build the source file name with the appropriate
            ' language extension.
            Dim sourceFile As String
            If provider.FileExtension.StartsWith(".") Then
                sourceFile = "TestGraph" + provider.FileExtension
            Else
                sourceFile = "TestGraph." + provider.FileExtension
            End If

            Dim cr As CompilerResults = CodeDomExample.CompileCode(provider, _
                                                                   sourceFile, _
                                                                   "TestGraph.EXE")

            If cr.Errors.Count > 0 Then
                ' Display compilation errors.
                textBox1.Text = "Errors encountered while building " + _
                                sourceFile + " into " + _
                                cr.PathToAssembly + ": " + ControlChars.CrLf

                Dim ce As System.CodeDom.Compiler.CompilerError
                For Each ce In cr.Errors
                    textBox1.AppendText(ce.ToString() + ControlChars.CrLf)
                Next ce
                run_button.Enabled = False
            Else
                textBox1.Text = "Source " + sourceFile + " built into " + _
                                cr.PathToAssembly + " with no errors."
                run_button.Enabled = True
            End If
        End Sub

        Private Sub run_button_Click(ByVal sender As Object, _
            ByVal e As System.EventArgs)

            Process.Start("TestGraph.EXE")
        End Sub

        Private Function GetCurrentProvider() As CodeDomProvider

            Dim provider As CodeDomProvider
            Select Case CStr(Me.comboBox1.SelectedItem)
                Case "CSharp"
                    provider = CodeDomProvider.CreateProvider("CSharp")
                Case "Visual Basic"
                    provider = CodeDomProvider.CreateProvider("VisualBasic")
                Case "JScript"
                    provider = CodeDomProvider.CreateProvider("JScript")
                Case Else
                    provider = CodeDomProvider.CreateProvider("CSharp")
            End Select
            Return provider
        End Function

        Public Sub New()
            Me.SuspendLayout()
            ' Set properties for label1.
            Me.label1.Location = New System.Drawing.Point(395, 20)
            Me.label1.Size = New Size(180, 22)
            Me.label1.Text = "Select a programming language:"
            ' Set properties for comboBox1.
            Me.comboBox1.Location = New System.Drawing.Point(560, 16)
            Me.comboBox1.Size = New Size(190, 23)
            Me.comboBox1.Name = "comboBox1"
            Me.comboBox1.Items.AddRange(New String() {"CSharp", "Visual Basic", "JScript"})
            Me.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right Or System.Windows.Forms.AnchorStyles.Top
            Me.comboBox1.SelectedIndex = 0
            ' Set properties for generate_button.
            Me.generate_button.Location = New System.Drawing.Point(8, 16)
            Me.generate_button.Name = "generate_button"
            Me.generate_button.Size = New System.Drawing.Size(120, 23)
            Me.generate_button.Text = "Generate Code"
            AddHandler generate_button.Click, AddressOf Me.generate_button_Click
            ' Set properties for compile_button.
            Me.compile_button.Location = New System.Drawing.Point(136, 16)
            Me.compile_button.Name = "compile_button"
            Me.compile_button.Size = New System.Drawing.Size(120, 23)
            Me.compile_button.Text = "Compile"
            AddHandler compile_button.Click, AddressOf Me.compile_button_Click
            ' Set properties for run_button.
            Me.run_button.Enabled = False
            Me.run_button.Location = New System.Drawing.Point(264, 16)
            Me.run_button.Name = "run_button"
            Me.run_button.Size = New System.Drawing.Size(120, 23)
            Me.run_button.Text = "Run"
            AddHandler run_button.Click, AddressOf Me.run_button_Click
            ' Set properties for textBox1.
            Me.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
            Me.textBox1.Location = New System.Drawing.Point(8, 48)
            Me.textBox1.Multiline = True
            Me.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.textBox1.Name = "textBox1"
            Me.textBox1.Size = New System.Drawing.Size(744, 280)
            Me.textBox1.Text = ""
            ' Set properties for the CodeDomExampleForm.
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(768, 340)
            Me.MinimumSize = New System.Drawing.Size(750, 340)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.textBox1, _
                Me.run_button, Me.compile_button, Me.generate_button, _
                Me.comboBox1, Me.label1})
            Me.Name = "CodeDomExampleForm"
            Me.Text = "CodeDom Hello World Example"
            Me.ResumeLayout(False)
        End Sub

        Protected Overloads Sub Dispose(ByVal disposing As Boolean)
            MyBase.Dispose(disposing)
        End Sub

        <STAThread()> _
        Shared Sub Main()
            Application.Run(New CodeDomExampleForm())
        End Sub
    End Class
End Namespace
'</Snippet1>
