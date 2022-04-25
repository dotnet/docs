' Example code for How to: Discover and Manipulate Generic Types
'<Snippet1>
Imports System.Reflection
Imports System.Collections.Generic

' Define an example interface.
Public Interface ITestArgument
End Interface

' Define an example base class.
Public Class TestBase
End Class

' Define a generic class with one parameter. The parameter
' has three constraints: It must inherit TestBase, it must
' implement ITestArgument, and it must have a parameterless
' constructor.
Public Class Test(Of T As {TestBase, ITestArgument, New})
End Class

' Define a class that meets the constraints on the type
' parameter of class Test.
Public Class TestArgument
    Inherits TestBase
    Implements ITestArgument
    Public Sub New()
    End Sub
End Class

Public Class Example
    ' The following method displays information about a generic
    ' type.
    Private Shared Sub DisplayGenericType(ByVal t As Type)
        Console.WriteLine(vbCrLf & t.ToString())
        '<Snippet3>
        Console.WriteLine("   Is this a generic type? " _
            & t.IsGenericType)
        Console.WriteLine("   Is this a generic type definition? " _
            & t.IsGenericTypeDefinition)
        '</Snippet3>

        ' Get the generic type parameters or type arguments.
        '<Snippet4>
        Dim typeParameters() As Type = t.GetGenericArguments()
        '</Snippet4>

        '<Snippet5>
        Console.WriteLine("   List {0} type arguments:", _
            typeParameters.Length)
        For Each tParam As Type In typeParameters
            If tParam.IsGenericParameter Then
                DisplayGenericParameter(tParam)
            Else
                Console.WriteLine("      Type argument: {0}", _
                    tParam)
            End If
        Next
        '</Snippet5>
    End Sub

    ' The following method displays information about a generic
    ' type parameter. Generic type parameters are represented by
    ' instances of System.Type, just like ordinary types.
    '<Snippet6>
    Private Shared Sub DisplayGenericParameter(ByVal tp As Type)
        Console.WriteLine("      Type parameter: {0} position {1}", _
            tp.Name, tp.GenericParameterPosition)
        '</Snippet6>

        '<Snippet7>
        Dim classConstraint As Type = Nothing

        For Each iConstraint As Type In tp.GetGenericParameterConstraints()
            If iConstraint.IsInterface Then
                Console.WriteLine("         Interface constraint: {0}", _
                    iConstraint)
            End If
        Next

        If classConstraint IsNot Nothing Then
            Console.WriteLine("         Base type constraint: {0}", _
                tp.BaseType)
        Else
            Console.WriteLine("         Base type constraint: None")
        End If
        '</Snippet7>

        '<Snippet8>
        Dim sConstraints As GenericParameterAttributes = _
            tp.GenericParameterAttributes And _
            GenericParameterAttributes.SpecialConstraintMask
        '</Snippet8>
        '<Snippet9>
        If sConstraints = GenericParameterAttributes.None Then
            Console.WriteLine("         No special constraints.")
        Else
            If GenericParameterAttributes.None <> (sConstraints And _
                GenericParameterAttributes.DefaultConstructorConstraint) Then
                Console.WriteLine("         Must have a parameterless constructor.")
            End If
            If GenericParameterAttributes.None <> (sConstraints And _
                GenericParameterAttributes.ReferenceTypeConstraint) Then
                Console.WriteLine("         Must be a reference type.")
            End If
            If GenericParameterAttributes.None <> (sConstraints And _
                GenericParameterAttributes.NotNullableValueTypeConstraint) Then
                Console.WriteLine("         Must be a non-nullable value type.")
            End If
        End If
        '</Snippet9>
    End Sub

    Public Shared Sub Main()
        ' Two ways to get a Type object that represents the generic
        ' type definition of the Dictionary class. 
        '
        '<Snippet10>
        ' Use the GetType operator to create the generic type 
        ' definition directly. To specify the generic type definition,
        ' omit the type arguments but retain the comma that separates
        ' them.
        '<Snippet2>
        Dim d1 As Type = GetType(Dictionary(Of ,))
        '</Snippet2>

        ' You can also obtain the generic type definition from a
        ' constructed class. In this case, the constructed class
        ' is a dictionary of Example objects, with String keys.
        Dim d2 As New Dictionary(Of String, Example)
        ' Get a Type object that represents the constructed type,
        ' and from that get the generic type definition. The 
        ' variables d1 and d4 contain the same type.
        Dim d3 As Type = d2.GetType()
        Dim d4 As Type = d3.GetGenericTypeDefinition()
        '</Snippet10>

        ' Display information for the generic type definition, and
        ' for the constructed type Dictionary(Of String, Example).
        DisplayGenericType(d1)
        DisplayGenericType(d2.GetType())

        ' Construct an array of type arguments to substitute for 
        ' the type parameters of the generic Dictionary class.
        ' The array must contain the correct number of types, in 
        ' the same order that they appear in the type parameter 
        ' list of Dictionary. The key (first type parameter)
        ' is of type string, and the type to be contained in the
        ' dictionary is Example.
        '<Snippet11>
        Dim typeArgs() As Type = _
            {GetType(String), GetType(Example)}
        '</Snippet11>

        ' Construct the type Dictionary(Of String, Example).
        '<Snippet12>
        Dim constructed As Type = _
            d1.MakeGenericType(typeArgs)
        '</Snippet12>

        DisplayGenericType(constructed)

        '<Snippet13>
        Dim o As Object = Activator.CreateInstance(constructed)
        '</Snippet13>

        Console.WriteLine(vbCrLf & _
            "Compare types obtained by different methods:")
        Console.WriteLine("   Are the constructed types equal? " _
            & (d2.GetType() Is constructed))
        Console.WriteLine("   Are the generic definitions equal? " _
            & (d1 Is constructed.GetGenericTypeDefinition()))

        ' Demonstrate the DisplayGenericType and 
        ' DisplayGenericParameter methods with the Test class 
        ' defined above. This shows base, interface, and special
        ' constraints.
        DisplayGenericType(GetType(Test(Of )))
    End Sub
End Class
'</Snippet1>
