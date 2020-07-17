'<Snippet1>
Imports System.Reflection
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

' The example attribute is applied to the assembly.
<Assembly: Example(ExampleKind.ThirdKind, Note:="This is a note on the assembly.")>

' An enumeration used by the ExampleAttribute class.
Public Enum ExampleKind
    FirstKind
    SecondKind
    ThirdKind
    FourthKind
End Enum

' An example attribute. The attribute can be applied to all
' targets, from assemblies to parameters.
'
<AttributeUsage(AttributeTargets.All)> _
Public Class ExampleAttribute
    Inherits Attribute

    ' Data for properties.
    Private kindValue As ExampleKind
    Private noteValue As String
    Private arrayStrings() As String
    Private arrayNumbers() As Integer

    ' Constructors. The parameterless constructor (.ctor) calls
    ' the constructor that specifies ExampleKind and an array of
    ' strings, and supplies the default values.
    '
    Public Sub New(ByVal initKind As ExampleKind, ByVal initStrings() As String)
        kindValue = initKind
        arrayStrings = initStrings
    End Sub
    Public Sub New(ByVal initKind As ExampleKind)
        Me.New(initKind, Nothing)
    End Sub
    Public Sub New()
        Me.New(ExampleKind.FirstKind, Nothing)
    End Sub

    ' Properties. The Note and Numbers properties must be read/write, so they 
    ' can be used as named parameters.
    '
    Public ReadOnly Property Kind As ExampleKind
        Get
            Return kindValue
        End Get
    End Property
    Public ReadOnly Property Strings As String()
        Get
            Return arrayStrings
        End Get
    End Property
    Public Property Note As String
        Get
            Return noteValue
        End Get
        Set
            noteValue = value
        End Set
    End Property
    Public Property Numbers As Integer()
        Get
            Return arrayNumbers
        End Get
        Set
            arrayNumbers = value
        End Set
    End Property
End Class

' The example attribute is applied to the test class.
'
<Example(ExampleKind.SecondKind, _
         New String() {"String array argument, line 1", _
                        "String array argument, line 2", _
                        "String array argument, line 3"}, _
         Note:="This is a note on the class.", _
         Numbers:=New Integer() {53, 57, 59})> _
Public Class Test
    ' The example attribute is applied to a method, using the
    ' parameterless constructor and supplying a named argument.
    ' The attribute is also applied to the method parameter.
    '
    <Example(Note:="This is a note on a method.")> _
    Public Sub TestMethod(<Example()> ByVal arg As Object)
    End Sub

    ' Sub Main gets objects representing the assembly, the test
    ' type, the test method, and the method parameter. Custom
    ' attribute data is displayed for each of these.
    '
    Public Shared Sub Main()
        Dim asm As [Assembly] = Assembly.ReflectionOnlyLoad("source")
        Dim t As Type = asm.GetType("Test")
        Dim m As MethodInfo = t.GetMethod("TestMethod")
        Dim p() As ParameterInfo = m.GetParameters()

        Console.WriteLine(vbCrLf & "Attributes for assembly: '{0}'", asm)
        ShowAttributeData(CustomAttributeData.GetCustomAttributes(asm))
        Console.WriteLine(vbCrLf & "Attributes for type: '{0}'", t)
        ShowAttributeData(CustomAttributeData.GetCustomAttributes(t))
        Console.WriteLine(vbCrLf & "Attributes for member: '{0}'", m)
        ShowAttributeData(CustomAttributeData.GetCustomAttributes(m))
        Console.WriteLine(vbCrLf & "Attributes for parameter: '{0}'", p)
        ShowAttributeData(CustomAttributeData.GetCustomAttributes(p(0)))
    End Sub

    Private Shared Sub ShowAttributeData( _
        ByVal attributes As IList(Of CustomAttributeData))

        For Each cad As CustomAttributeData _
            In CType(attributes, IEnumerable(Of CustomAttributeData))

            Console.WriteLine("   {0}", cad)
            Console.WriteLine("      Constructor: '{0}'", cad.Constructor)

            Console.WriteLine("      Constructor arguments:")
            For Each cata As CustomAttributeTypedArgument _
                In CType(cad.ConstructorArguments, IEnumerable(Of CustomAttributeTypedArgument))

                ShowValueOrArray(cata)
            Next

            Console.WriteLine("      Named arguments:")
            For Each cana As CustomAttributeNamedArgument _
                In CType(cad.NamedArguments, IEnumerable(Of CustomAttributeNamedArgument))

                Console.WriteLine("         MemberInfo: '{0}'", _
                    cana.MemberInfo)
                ShowValueOrArray(cana.TypedValue)
            Next
        Next
    End Sub

    Private Shared Sub ShowValueOrArray(ByVal cata As CustomAttributeTypedArgument)
        If cata.Value.GetType() Is GetType(ReadOnlyCollection(Of CustomAttributeTypedArgument)) Then
            Console.WriteLine("         Array of '{0}':", cata.ArgumentType)

            For Each cataElement As CustomAttributeTypedArgument In cata.Value
                Console.WriteLine("             Type: '{0}'  Value: '{1}'", _
                    cataElement.ArgumentType, cataElement.Value)
            Next
        Else
            Console.WriteLine("         Type: '{0}'  Value: '{1}'", _
                cata.ArgumentType, cata.Value)
        End If
    End Sub
End Class

' This code example produces output similar to the following:
'
'Attributes for assembly: 'source, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'
'   [System.Runtime.CompilerServices.CompilationRelaxationsAttribute((Int32)8)]
'      Constructor: 'Void .ctor(Int32)'
'      Constructor arguments:
'         Type: 'System.Int32'  Value: '8'
'      Named arguments:
'   [System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows = True)]
'      Constructor: 'Void .ctor()'
'      Constructor arguments:
'      Named arguments:
'         MemberInfo: 'Boolean WrapNonExceptionThrows'
'         Type: 'System.Boolean'  Value: 'True'
'   [ExampleAttribute((ExampleKind)2, Note = "This is a note on the assembly.")]
'      Constructor: 'Void .ctor(ExampleKind)'
'      Constructor arguments:
'         Type: 'ExampleKind'  Value: '2'
'      Named arguments:
'         MemberInfo: 'System.String Note'
'         Type: 'System.String'  Value: 'This is a note on the assembly.'
'
'Attributes for type: 'Test'
'   [ExampleAttribute((ExampleKind)1, new String[3] { "String array argument, line 1", "String array argument, line 2", "String array argument, line 3" }, Note = "This is a note on the class.", Numbers = new Int32[3] { 53, 57, 59 })]
'      Constructor: 'Void .ctor(ExampleKind, System.String[])'
'      Constructor arguments:
'         Type: 'ExampleKind'  Value: '1'
'         Array of 'System.String[]':
'             Type: 'System.String'  Value: 'String array argument, line 1'
'             Type: 'System.String'  Value: 'String array argument, line 2'
'             Type: 'System.String'  Value: 'String array argument, line 3'
'      Named arguments:
'         MemberInfo: 'System.String Note'
'         Type: 'System.String'  Value: 'This is a note on the class.'
'         MemberInfo: 'Int32[] Numbers'
'         Array of 'System.Int32[]':
'             Type: 'System.Int32'  Value: '53'
'             Type: 'System.Int32'  Value: '57'
'             Type: 'System.Int32'  Value: '59'
'
'Attributes for member: 'Void TestMethod(System.Object)'
'   [ExampleAttribute(Note = "This is a note on a method.")]
'      Constructor: 'Void .ctor()'
'      Constructor arguments:
'      Named arguments:
'         MemberInfo: 'System.String Note'
'         Type: 'System.String'  Value: 'This is a note on a method.'
'
'Attributes for parameter: 'System.Object arg'
'   [ExampleAttribute()]
'      Constructor: 'Void .ctor()'
'      Constructor arguments:
'      Named arguments:
'</Snippet1>
