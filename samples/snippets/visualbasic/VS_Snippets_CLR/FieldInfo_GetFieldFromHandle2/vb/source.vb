' Created by REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Reflection

' A generic class with a field whose type is specified by the 
' generic type parameter of the class.
Public Class Test(Of T)
    Public TestField As T 
End Class

Public Class Example

    Public Shared Sub Main()

        ' Get type handles for Test(Of String) and its field.
        Dim rth As RuntimeTypeHandle = _
            GetType(Test(Of String)).TypeHandle
        Dim rfh As RuntimeFieldHandle = _
            GetType(Test(Of String)).GetField("TestField").FieldHandle

        ' When a field belongs to a constructed generic type, 
        ' such as Test(Of String), retrieving the field from the
        ' field handle requires the type handle of the constructed
        ' generic type. An exception is thrown if the type is not
        ' included.
        Try
            Dim f1 As FieldInfo = FieldInfo.GetFieldFromHandle(rfh)
        Catch ex As Exception
            Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message)
        End Try

        ' To get the FieldInfo for a field on a generic type, use the
        ' overload that specifies the type handle.
        Dim fi As FieldInfo = FieldInfo.GetFieldFromHandle(rfh, rth)
        Console.WriteLine(vbCrLf & "The type of {0} is: {1}", _
            fi.Name, fi.FieldType)

        ' All constructions of Test(Of T) for which T is a reference
        ' type share the same implementation, so the same runtime 
        ' field handle can be used to retrieve the FieldInfo for 
        ' TestField on any such construction. Here the runtime field
        ' handle is used with Test(Of Object).
        fi = FieldInfo.GetFieldFromHandle(rfh, _
                               GetType(Test(Of Object)).TypeHandle)
        Console.WriteLine(vbCrLf & "The type of {0} is: {1}", _
            fi.Name, fi.FieldType)

        ' Each construction of Test(Of T) for which T is a value type
        ' has its own unique implementation, and an exception is thrown
        ' if you supply a constructed type other than the one that 
        ' the runtime field handle belongs to.  
        Try
            fi = FieldInfo.GetFieldFromHandle(rfh, _
                               GetType(Test(Of Integer)).TypeHandle)
        Catch ex As Exception
            Console.WriteLine(vbCrLf & "{0}: {1}", ex.GetType().Name, ex.Message)
        End Try

    End Sub
End Class

' This code example produces output similar to the following:
'
'ArgumentException: Cannot resolve field TestField because the declaring type of
'the field handle Test`1[T] is generic. Explicitly provide the declaring type to
'GetFieldFromHandle.
'
'The type of TestField is: System.String
'
'The type of TestField is: System.Object
'
'ArgumentException: Type handle 'Test`1[System.Int32]' and field handle with decl
'aring type 'Test`1[System.__Canon]' are incompatible. Get RuntimeFieldHandle and
' declaring RuntimeTypeHandle off the same FieldInfo.
'</Snippet1>
