Imports System.Diagnostics

'<Snippet50>
Imports System.Runtime.InteropServices
'</Snippet50>

' <snippet30>
Imports System.Reflection
<Assembly: AssemblyTitleAttribute("Production assembly 4"), 
Module: CLSCompliant(True)> 
' </snippet30>


Module Module1
    Sub Main()

    End Sub

End Module

Module WrapAttributes
    '<Snippet1>
    <System.Serializable()> Public Class SampleClass
        ' Objects of this type can be serialized.
    End Class
    '</Snippet1>
End Module

Module WrapCustomAttributes
    '<Snippet2>
    <System.AttributeUsage(System.AttributeTargets.Class Or 
                           System.AttributeTargets.Struct)> 
    Public Class Author
        Inherits System.Attribute
        Private name As String
        Public version As Double
        Sub New(ByVal authorName As String)
            name = authorName
            version = 1.0
        End Sub
    End Class
    '</Snippet2>  

    '<Snippet3>
    '<Snippet9>
    <Author("P. Ackerman", Version:=1.1)> 
    Class SampleClass
        ' P. Ackerman's code goes here...
    End Class
    ' </Snippet9>
    ' </Snippet3>

    Sub Test()
        '<Snippet10>
        Dim anonymousAuthorObject As Author = New Author("P. Ackerman")
        anonymousAuthorObject.version = 1.1
        '</Snippet10>
    End Sub

End Module

Module WrapCustomAttributes2
    '<Snippet4>
    ' multiuse attribute
    <System.AttributeUsage(System.AttributeTargets.Class Or 
                           System.AttributeTargets.Struct, 
                           AllowMultiple:=True)> 
    Public Class Author
        Inherits System.Attribute
        '</Snippet4>
        Private name As String
        Public version As Double
        Sub New(ByVal authorName As String)
            name = authorName
            version = 1.0
        End Sub
    End Class
    '<Snippet5>
    <Author("P. Ackerman", Version:=1.1), 
    Author("R. Koch", Version:=1.2)> 
    Class SampleClass
        ' P. Ackerman's code goes here...
        ' R. Koch's code goes here...
    End Class
    '</Snippet5>
End Module

Module UsingReflection
    '<Snippet11>
    ' Multiuse attribute
    <System.AttributeUsage(System.AttributeTargets.Class Or 
                           System.AttributeTargets.Struct, 
                           AllowMultiple:=True)> 
    Public Class Author
        Inherits System.Attribute
        Private name As String
        Public version As Double
        Sub New(ByVal authorName As String)
            name = authorName

            ' Default value
            version = 1.0
        End Sub

        Function GetName() As String
            Return name
        End Function        
    End Class

    ' Class with the Author attribute
    <Author("P. Ackerman")> 
    Public Class FirstClass
    End Class

    ' Class without the Author attribute
    Public Class SecondClass
    End Class

    ' Class with multiple Author attributes.
    <Author("P. Ackerman"), Author("R. Koch", Version:=2.0)> 
    Public Class ThirdClass
    End Class

    Class TestAuthorAttribute
        Sub Main()
            PrintAuthorInfo(GetType(FirstClass))
            PrintAuthorInfo(GetType(SecondClass))
            PrintAuthorInfo(GetType(ThirdClass))
        End Sub

        Private Shared Sub PrintAuthorInfo(ByVal t As System.Type)
            System.Console.WriteLine("Author information for {0}", t)

            ' Using reflection
            Dim attrs() As System.Attribute = System.Attribute.GetCustomAttributes(t)

            ' Displaying output
            For Each attr In attrs
                Dim a As Author = CType(attr, Author)
                System.Console.WriteLine("   {0}, version {1:f}", a.GetName(), a.version)
            Next            
        End Sub

        ' Output:
        '   Author information for FirstClass
        '     P. Ackerman, version 1.00
        ' Author information for SecondClass
        ' Author information for ThirdClass
        '  R. Koch, version 2.00
        '  P. Ackerman, version 1.00

    End Class
    '</Snippet11>
End Module

Module WrapUnion
    ' <Snippet12>
    ' Add an Imports statement for System.Runtime.InteropServices.

    <System.Runtime.InteropServices.StructLayout( 
          System.Runtime.InteropServices.LayoutKind.Explicit)> 
    Structure TestUnion
        <System.Runtime.InteropServices.FieldOffset(0)> 
        Public i As Integer

        <System.Runtime.InteropServices.FieldOffset(0)> 
        Public d As Double

        <System.Runtime.InteropServices.FieldOffset(0)> 
        Public c As Char

        <System.Runtime.InteropServices.FieldOffset(0)> 
        Public b As Byte
    End Structure
    '</Snippet12>

    '<Snippet13>
    ' Add an Imports statement for System.Runtime.InteropServices.

    <System.Runtime.InteropServices.StructLayout( 
         System.Runtime.InteropServices.LayoutKind.Explicit)> 
   Structure TestExplicit
        <System.Runtime.InteropServices.FieldOffset(0)> 
        Public lg As Long

        <System.Runtime.InteropServices.FieldOffset(0)> 
        Public i1 As Integer

        <System.Runtime.InteropServices.FieldOffset(4)> 
        Public i2 As Integer

        <System.Runtime.InteropServices.FieldOffset(8)> 
        Public d As Double

        <System.Runtime.InteropServices.FieldOffset(12)> 
        Public c As Char

        <System.Runtime.InteropServices.FieldOffset(14)> 
        Public b As Byte
    End Structure       
    '</Snippet13>
End Module

Module WrapConditional
    Class TestConditional
        '<Snippet15>
        <Conditional("A"), Conditional("B")> 
        Shared Sub DoIfAorB()

        End Sub
        '</Snippet15>

        '<Snippet16>
        <Conditional("A")> 
        Shared Sub DoIfA()
            DoIfAandB()
        End Sub

        <Conditional("B")> 
        Shared Sub DoIfAandB()
            ' Code to execute when both A and B are defined...
        End Sub
        '</Snippet16>

        '<Snippet17>
        <Conditional("DEBUG")> 
        Public Class Documentation
            Inherits System.Attribute
            Private text As String
            Sub New(ByVal doc_text As String)
                text = doc_text
            End Sub
        End Class

        Class SampleClass
            ' This attribute will only be included if DEBUG is defined.
            <Documentation("This method displays an integer.")> 
            Shared Sub DoWork(ByVal i As Integer)
                System.Console.WriteLine(i)
            End Sub
        End Class
        '</Snippet17>

    End Class

End Module

Module TestObsoleteAttribute
    '<Snippet34>
    <System.Obsolete("use class B")> 
    Class A
        Sub Method()
        End Sub
    End Class

    Class B
        <System.Obsolete("use NewMethod", True)> 
        Sub OldMethod()
        End Sub

        Sub NewMethod()
        End Sub
    End Class

    '</Snippet34>

    Class Test
        Sub New()
            '<Snippet35>
            ' Generates 2 warnings:
            ' Dim a As New A
            ' Generate no errors or warnings:

            Dim b As New B
            b.NewMethod()

            ' Generates an error, terminating compilation:
            ' b.OldMethod()
            '</Snippet35>
        End Sub
    End Class

End Module
Module WrapUsingAttributes
    '<Snippet23>
    <System.Runtime.InteropServices.DllImport("user32.dll")> 
    Sub SampleMethod()
    End Sub
    '</Snippet23>

    '<Snippet24>
    Sub MethodA(<[In](), Out()> ByVal x As Double)
    End Sub
    Sub MethodB(<Out(), [In]()> ByVal x As Double)
    End Sub
    '</Snippet24>

    '<Snippet25>
    <Conditional("DEBUG"), Conditional("TEST1")> 
    Sub TraceMethod()
    End Sub
    '</Snippet25>    

End Module
   