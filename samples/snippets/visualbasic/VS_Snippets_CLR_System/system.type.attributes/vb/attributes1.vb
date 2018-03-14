' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Reflection

Friend Structure S
    Public X As Integer
End Structure

Public MustInherit Class Example
    Protected NotInheritable Class NestedClass
    End Class

    Public Interface INested
    End Interface

    Public Shared Sub Main()
        ' Create an array of types.
        Dim types() As Type = { GetType(Example), GetType(NestedClass),
                                GetType(INested), GetType(S) }

        For Each t In types
           Console.WriteLine("Attributes for type {0}:", t.Name)

           Dim attr As TypeAttributes = t.Attributes

           ' Use the visibility mask to test for visibility attributes.
           Dim visibility As TypeAttributes = attr And TypeAttributes.VisibilityMask
           Select Case visibility
               Case TypeAttributes.NotPublic:
                   Console.WriteLine("   ...is not Public")
               Case TypeAttributes.Public:
                   Console.WriteLine("   ...is Public")
               Case TypeAttributes.NestedPublic:
                   Console.WriteLine("   ...is nested and Public")
               Case TypeAttributes.NestedPrivate:
                   Console.WriteLine("   ...is nested and Private")
               Case TypeAttributes.NestedFamANDAssem:
                   Console.WriteLine("   ...is nested, and inheritable only within the assembly" & _
                      vbLf & "         (cannot be declared in Visual Basic)")
               Case TypeAttributes.NestedAssembly:
                   Console.WriteLine("   ...is nested and Friend")
               Case TypeAttributes.NestedFamily:
                   Console.WriteLine("   ...is nested and Protected")
               Case TypeAttributes.NestedFamORAssem:
                   Console.WriteLine("   ...is nested and Protected Friend")
           End Select

           ' Use the layout mask to test for layout attributes.
           Dim layout As TypeAttributes = attr And TypeAttributes.LayoutMask
           Select Case layout
               Case TypeAttributes.AutoLayout:
                   Console.WriteLine("   ...is AutoLayout")
               Case TypeAttributes.SequentialLayout:
                   Console.WriteLine("   ...is SequentialLayout")
               Case TypeAttributes.ExplicitLayout:
                   Console.WriteLine("   ...is ExplicitLayout")
           End Select

           ' Use the class semantics mask to test for class semantics attributes.
           Dim classSemantics As TypeAttributes = attr And TypeAttributes.ClassSemanticsMask
           Select Case classSemantics
               Case TypeAttributes.Class:
                   If t.IsValueType Then
                       Console.WriteLine("   ...is a value type")
                   Else
                       Console.WriteLine("   ...is a class")
                   End If
               Case TypeAttributes.Interface:
                   Console.WriteLine("   ...is an interface")
           End Select

           If 0 <> (attr And TypeAttributes.Abstract) Then _
               Console.WriteLine("   ...is MustInherit")

           If 0 <> (attr And TypeAttributes.Sealed) Then _
               Console.WriteLine("   ...is NotInheritable")
           Console.WriteLine()
       Next
    End Sub
End Class
' The example displays the following output:
'       Attributes for type Example:
'          ...is Public
'          ...is AutoLayout
'          ...is a class
'          ...is MustInherit
'
'       Attributes for type NestedClass:
'          ...is nested and Protected
'          ...is AutoLayout
'          ...is a class
'          ...is NotInheritable
'
'       Attributes for type INested:
'          ...is nested and Public
'          ...is AutoLayout
'          ...is an interface
'          ...is MustInherit
'
'       Attributes for type S:
'          ...is not Public
'          ...is SequentialLayout
'          ...is a value type
'          ...is NotInheritable
' </Snippet1>
