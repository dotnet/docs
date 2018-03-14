'<Snippet1>
Imports System
Imports System.Reflection
Imports System.IO
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports Microsoft.CSharp


'/ <summary>
'/ This code example creates a graph using a CodeCompileUnit and  
'/ generates source code for the graph using the CSharpCodeProvider.
'/ </summary>

Class Sample
    '/ <summary>
    '/ Define the compile unit to use for code generation. 
    '/ </summary>
    Private targetUnit As CodeCompileUnit
    
    '/ <summary>
    '/ The only class in the compile unit. 
    '/ </summary>
    Private targetClass As CodeTypeDeclaration
    
    '/ <summary>
    '/ The name of the file to contain the source code.
    '/ </summary>
    Private Const outputFileName As String = "SampleCode.vb"
    
    
    '/ <summary>
    '/ Define the class.
    '/ </summary>
    Public Sub New() 
        targetUnit = New CodeCompileUnit()
        Dim samples As New CodeNamespace("CodeDOMSample")
        samples.Imports.Add(New CodeNamespaceImport("System"))
        targetClass = New CodeTypeDeclaration("CodeDOMCreatedClass")
        targetClass.IsClass = True
        targetClass.TypeAttributes = TypeAttributes.Public Or TypeAttributes.Sealed
        samples.Types.Add(targetClass)
        targetUnit.Namespaces.Add(samples)
    
    End Sub 'New
    
    
    '/ <summary>
    '/ Adds a field to the class.
    '/ </summary>
    Public Sub AddField()

        Dim testField As New CodeMemberField()
        testField.Name = "today"
        testField.Type = New CodeTypeReference(GetType(System.DateTime))
        testField.Attributes = MemberAttributes.Private Or MemberAttributes.Static
        testField.InitExpression = New CodeFieldReferenceExpression(New CodeTypeReferenceExpression("System.DateTime"), "Today")

        targetClass.Members.Add(testField)

    End Sub 'AddFields
     
    
    '/ <summary>
    '/ Add a constructor to the class.
    '/ </summary>
    Public Sub AddConstructor() 
        ' Declare the constructor
        Dim constructor As New CodeConstructor()
        constructor.Attributes = MemberAttributes.Public Or MemberAttributes.Final
        
        targetClass.Members.Add(constructor)
    
    End Sub 'AddConstructor
    
    
    '/ <summary>
    '/ Add an entry point to the class.
    '/ </summary>
    Public Sub AddEntryPoint() 
        Dim start As New CodeEntryPointMethod()
        Dim objectCreate As New CodeObjectCreateExpression(New CodeTypeReference("CodeDOMCreatedClass"))
        ' Add the statement:
        ' "CodeDOMCreatedClass testClass = 
        '     new CodeDOMCreatedClass();"
        start.Statements.Add(New CodeVariableDeclarationStatement(New CodeTypeReference("CodeDOMCreatedClass"), "testClass", objectCreate))
        
        ' Creat the expression:
        ' "testClass.ToString()"
        Dim toStringInvoke As New CodeMethodInvokeExpression(New CodeVariableReferenceExpression("today"), "ToString")
        
        ' Add a System.Console.WriteLine statement with the previous 
        ' expression as a parameter.
        start.Statements.Add(New CodeMethodInvokeExpression(New CodeTypeReferenceExpression("System.Console"), "WriteLine", toStringInvoke))
        targetClass.Members.Add(start)
    
    End Sub 'AddEntryPoint
    
    '/ <summary>
    '/ Generate CSharp source code from the compile unit.
    '/ </summary>
    '/ <param name="filename">Output file name</param>
    Public Sub GenerateCSharpCode(ByVal fileName As String) 
        Dim provider As CodeDomProvider = CodeDomProvider.CreateProvider("VB")
        Dim options As New CodeGeneratorOptions()
        Dim sourceWriter As New StreamWriter(fileName)
        Try
            provider.GenerateCodeFromCompileUnit(targetUnit, sourceWriter, options)
        Finally
            sourceWriter.Dispose()
        End Try
    
    End Sub 'GenerateCSharpCode
    
    
    '/ <summary>
    '/ Create the CodeDOM graph and generate the code.
    '/ </summary>
    Shared Sub Main() 
        Dim sample As New Sample()
        sample.AddField()
        sample.AddConstructor()
        sample.AddEntryPoint()
        sample.GenerateCSharpCode(outputFileName)
    
    End Sub 'Main
End Class 'Sample
' A Visual Basic code generator produces the following source code for the preceeding example code:
'Option Strict Off
'Option Explicit On

'Imports System

'Namespace CodeDOMSample

'    Public NotInheritable Class CodeDOMCreatedClass

'        Private Shared today As Date = Date.Today

'        Public Sub New()
'            MyBase.New()
'        End Sub

'        Public Shared Sub Main()
'            Dim testClass As CodeDOMCreatedClass = New CodeDOMCreatedClass
'            System.Console.WriteLine(today.ToString)
'        End Sub
'    End Class
'End Namespace
'</Snippet1>