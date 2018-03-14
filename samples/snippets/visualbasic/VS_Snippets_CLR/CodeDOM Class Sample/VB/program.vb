'<Snippet1>
Imports System
Imports System.Reflection
Imports System.IO
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports Microsoft.VisualBasic

' This code example creates a graph using a CodeCompileUnit and  
' generates source code for the graph using the VBCodeProvider.
'<Snippet10>
Class Sample

    ' Define the compile unit to use for code generation. 
    Private targetUnit As CodeCompileUnit

    ' The only class in the compile unit. This class contains 2 fields,
    ' 3 properties, a constructor, an entry point, and 1 simple method. 
    Private targetClass As CodeTypeDeclaration

    ' The name of the file to contain the source code.
    Private Const outputFileName As String = "SampleCode.vb"
    '</Snippet10>

    ' Define the class.
    '<Snippet2>
    Public Sub New()
        targetUnit = New CodeCompileUnit()
        Dim samples As New CodeNamespace("CodeDOMSample")
        samples.Imports.Add(New CodeNamespaceImport("System"))
        targetClass = New CodeTypeDeclaration("CodeDOMCreatedClass")
        targetClass.IsClass = True
        targetClass.TypeAttributes = _
            TypeAttributes.Public Or TypeAttributes.Sealed
        samples.Types.Add(targetClass)
        targetUnit.Namespaces.Add(samples)

    End Sub 'New

    '</Snippet2>
    ' Adds two fields to the class.
    '<snippet3>
    Public Sub AddFields()
        ' Declare the widthValue field.
        Dim widthValueField As New CodeMemberField()
        widthValueField.Attributes = MemberAttributes.Private
        widthValueField.Name = "widthValue"
        widthValueField.Type = _
            New CodeTypeReference(GetType(System.Double))
        widthValueField.Comments.Add(New CodeCommentStatement( _
            "The width of the object."))
        targetClass.Members.Add(widthValueField)

        ' Declare the heightValue field
        Dim heightValueField As New CodeMemberField()
        heightValueField.Attributes = MemberAttributes.Private
        heightValueField.Name = "heightValue"
        heightValueField.Type = _
            New CodeTypeReference(GetType(System.Double))
        heightValueField.Comments.Add(New CodeCommentStatement( _
            "The height of the object."))
        targetClass.Members.Add(heightValueField)

    End Sub 'AddFields
    '</Snippet3>

    ' Add three properties to the class.
    '<Snippet4>
    Public Sub AddProperties()
        ' Declare the read only Width property.
        Dim widthProperty As New CodeMemberProperty()
        widthProperty.Attributes = _
            MemberAttributes.Public Or MemberAttributes.Final
        widthProperty.Name = "Width"
        widthProperty.HasGet = True
        widthProperty.Type = New CodeTypeReference(GetType(System.Double))
        widthProperty.Comments.Add(New CodeCommentStatement( _
            "The width property for the object."))
        widthProperty.GetStatements.Add(New CodeMethodReturnStatement( _
            New CodeFieldReferenceExpression( _
            New CodeThisReferenceExpression(), "widthValue")))
        targetClass.Members.Add(widthProperty)

        ' Declare the read-only Height property.
        Dim heightProperty As New CodeMemberProperty()
        heightProperty.Attributes = _
            MemberAttributes.Public Or MemberAttributes.Final
        heightProperty.Name = "Height"
        heightProperty.HasGet = True
        heightProperty.Type = New CodeTypeReference(GetType(System.Double))
        heightProperty.Comments.Add(New CodeCommentStatement( _
            "The Height property for the object."))
        heightProperty.GetStatements.Add(New CodeMethodReturnStatement( _
            New CodeFieldReferenceExpression( _
            New CodeThisReferenceExpression(), "heightValue")))
        targetClass.Members.Add(heightProperty)

        ' Declare the read only Area property.
        Dim areaProperty As New CodeMemberProperty()
        areaProperty.Attributes = _
            MemberAttributes.Public Or MemberAttributes.Final
        areaProperty.Name = "Area"
        areaProperty.HasGet = True
        areaProperty.Type = New CodeTypeReference(GetType(System.Double))
        areaProperty.Comments.Add(New CodeCommentStatement( _
            "The Area property for the object."))

        ' Create an expression to calculate the area for the get accessor
        ' of the Area property.
        Dim areaExpression As New CodeBinaryOperatorExpression( _
            New CodeFieldReferenceExpression( _
            New CodeThisReferenceExpression(), "widthValue"), _
            CodeBinaryOperatorType.Multiply, _
            New CodeFieldReferenceExpression( _
            New CodeThisReferenceExpression(), "heightValue"))
        areaProperty.GetStatements.Add( _
            New CodeMethodReturnStatement(areaExpression))
        targetClass.Members.Add(areaProperty)

    End Sub 'AddProperties
    '</Snippet4>

    ' Adds a method to the class. This method multiplies values stored 
    ' in both fields.
    '<Snippet5>
    Public Sub AddMethod()
        ' Declaring a ToString method.
        Dim toStringMethod As New CodeMemberMethod()
        toStringMethod.Attributes = _
            MemberAttributes.Public Or MemberAttributes.Override
        toStringMethod.Name = "ToString"
        toStringMethod.ReturnType = _
            New CodeTypeReference(GetType(System.String))

        Dim widthReference As New CodeFieldReferenceExpression( _
            New CodeThisReferenceExpression(), "Width")
        Dim heightReference As New CodeFieldReferenceExpression( _
            New CodeThisReferenceExpression(), "Height")
        Dim areaReference As New CodeFieldReferenceExpression( _
            New CodeThisReferenceExpression(), "Area")

        ' Declaring a return statement for method ToString.
        Dim returnStatement As New CodeMethodReturnStatement()

        ' This statement returns a string representation of the width,
        ' height, and area.
        Dim formattedOutput As String = "The object:" & Environment.NewLine _
            & " width = {0}," & Environment.NewLine & " height = {1}," _
            & Environment.NewLine & " area = {2}"
        returnStatement.Expression = New CodeMethodInvokeExpression( _
            New CodeTypeReferenceExpression("System.String"), "Format", _
            New CodePrimitiveExpression(formattedOutput), widthReference, _
            heightReference, areaReference)
        toStringMethod.Statements.Add(returnStatement)
        targetClass.Members.Add(toStringMethod)

    End Sub 'AddMethod
    '</Snippet5>

    ' Add a constructor to the class.
    '<Snippet6>
    Public Sub AddConstructor()
        ' Declare the constructor
        Dim constructor As New CodeConstructor()
        constructor.Attributes = _
            MemberAttributes.Public Or MemberAttributes.Final

        ' Add parameters.
        constructor.Parameters.Add( _
            New CodeParameterDeclarationExpression( _
            GetType(System.Double), "width"))
        constructor.Parameters.Add( _
            New CodeParameterDeclarationExpression( _
            GetType(System.Double), "height"))

        ' Add field initialization logic
        Dim widthReference As New CodeFieldReferenceExpression( _
            New CodeThisReferenceExpression(), "widthValue")
        constructor.Statements.Add(New CodeAssignStatement( _
            widthReference, New CodeArgumentReferenceExpression("width")))
        Dim heightReference As New CodeFieldReferenceExpression( _
            New CodeThisReferenceExpression(), "heightValue")
        constructor.Statements.Add( _
            New CodeAssignStatement(heightReference, _
            New CodeArgumentReferenceExpression("height")))
        targetClass.Members.Add(constructor)

    End Sub 'AddConstructor
    '</Snippet6>

    ' Add an entry point to the class.
    '<Snippet7>
    Public Sub AddEntryPoint()
        Dim start As New CodeEntryPointMethod()
        Dim objectCreate As New CodeObjectCreateExpression( _
            New CodeTypeReference("CodeDOMCreatedClass"), _
            New CodePrimitiveExpression(5.3), _
            New CodePrimitiveExpression(6.9))

        ' Add the statement:
        ' "CodeDOMCreatedClass testClass = _
        '     new CodeDOMCreatedClass(5.3, 6.9);"
        start.Statements.Add(New CodeVariableDeclarationStatement( _
            New CodeTypeReference("CodeDOMCreatedClass"), _
            "testClass", objectCreate))

        ' Creat the expression:
        ' "testClass.ToString()"
        Dim toStringInvoke As New CodeMethodInvokeExpression( _
            New CodeVariableReferenceExpression("testClass"), "ToString")

        ' Add a System.Console.WriteLine statement with the previous 
        ' expression as a parameter.
        start.Statements.Add(New CodeMethodInvokeExpression( _
            New CodeTypeReferenceExpression("System.Console"), _
            "WriteLine", toStringInvoke))
        targetClass.Members.Add(start)

    End Sub 'AddEntryPoint
    '</Snippet7>

    ' Generate Visual Basic source code from the compile unit.
    '<Snippet8>
    Public Sub GenerateVBCode(ByVal fileName As String)
        Dim provider As CodeDomProvider
        provider = CodeDomProvider.CreateProvider("VisualBasic")
        Dim options As New CodeGeneratorOptions()
        Dim sourceWriter As New StreamWriter(fileName)
        Try
            provider.GenerateCodeFromCompileUnit( _
                targetUnit, sourceWriter, options)
        Finally
            sourceWriter.Dispose()
        End Try

    End Sub 'GenerateVBCode
    '</Snippet8>

    ' Create the CodeDOM graph and generate the code.
    '<Snippet9>
    Shared Sub Main()
        Dim sample As New Sample()
        sample.AddFields()
        sample.AddProperties()
        sample.AddMethod()
        sample.AddConstructor()
        sample.AddEntryPoint()
        sample.GenerateVBCode(outputFileName)

    End Sub 'Main
End Class 'Sample 
'</Snippet9>
'</Snippet1>