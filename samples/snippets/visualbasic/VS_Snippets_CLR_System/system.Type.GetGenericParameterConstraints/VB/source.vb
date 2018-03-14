'<Snippet1>
Imports System
Imports System.Reflection

' Define a sample interface to use as an interface constraint.
Public Interface ITest
End Interface 

' Define a base type to use as a base class constraint.
Public Class Base
End Class 

' Define the generic type to examine. The first generic type parameter,
' T, derives from the class Base and implements ITest. This demonstrates
' a base class constraint and an interface constraint. The second generic 
' type parameter, U, must be a reference type (Class) and must have a 
' default constructor (New). This demonstrates special constraints.
'
Public Class Test(Of T As {Base, ITest}, U As {New, Class}) 
End Class

' Define a type that derives from Base and implements ITtest. This type
' satisfies the constraints on T in class Test.
Public Class Derived
    Inherits Base
    Implements ITest
End Class 

Public Class Example
    
    Public Shared Sub Main() 
        ' To get the generic type definition, omit the type
        ' arguments but retain the comma to indicate the number
        ' of type arguments. 
        '
        Dim def As Type = GetType(Test(Of ,))
        Console.WriteLine(vbCrLf & "Examining generic type {0}", def)
        
        ' Get the type parameters of the generic type definition,
        ' and display them.
        '
        Dim defparams() As Type = def.GetGenericArguments()
        For Each tp As Type In defparams

            Console.WriteLine(vbCrLf & "Type parameter: {0}", tp.Name)
            Console.WriteLine(vbTab & ListGenericParameterAttributes(tp))
            
            ' List the base class and interface constraints. The
            ' constraints do not appear in any particular order. An
            ' empty array is returned if there are no constraints.
            '
            Dim tpConstraints As Type() = _
                tp.GetGenericParameterConstraints()
            For Each tpc As Type In  tpConstraints
                Console.WriteLine(vbTab & tpc.ToString())
            Next tpc
        Next tp
    
    End Sub 
    
    ' List the variance and special constraint flags.
    '
    Private Shared Function ListGenericParameterAttributes(ByVal t As Type) As String 
        Dim retval As String
        Dim gpa As GenericParameterAttributes = t.GenericParameterAttributes

        ' Select the variance flags.
        Dim variance As GenericParameterAttributes = _
            gpa And GenericParameterAttributes.VarianceMask
        
        If variance = GenericParameterAttributes.None Then
            retval = "No variance flag;"
        Else
            If (variance And GenericParameterAttributes.Covariant) <> 0 Then
                retval = "Covariant;"
            Else
                retval = "Contravariant;"
            End If
        End If 

        ' Select the constraint flags.
        Dim constraints As GenericParameterAttributes = _
            gpa And GenericParameterAttributes.SpecialConstraintMask
        
        If constraints = GenericParameterAttributes.None Then
            retval &= " no special constraints."
        Else
            If (constraints And GenericParameterAttributes.ReferenceTypeConstraint) <> 0 Then
                retval &= " ReferenceTypeConstraint"
            End If
            If (constraints And GenericParameterAttributes.NotNullableValueTypeConstraint) <> 0 Then
                retval &= " NotNullableValueTypeConstraint"
            End If
            If (constraints And GenericParameterAttributes.DefaultConstructorConstraint) <> 0 Then
                retval &= " DefaultConstructorConstraint"
            End If
        End If 
        Return retval
    
    End Function 
End Class 
' This example produces the following output:
'
'Examining generic type Test`2[T,U]
'
'Type parameter: T
'        No variance flag; no special constraints.
'        Base
'        ITest
'
'Type parameter: U
'        No variance flag; ReferenceTypeConstraint DefaultConstructorConstraint
' 
'</Snippet1>