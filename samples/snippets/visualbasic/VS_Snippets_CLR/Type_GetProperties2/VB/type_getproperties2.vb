' <Snippet1>
Imports System.Reflection

' Create a class having six properties.
Public Class PropertyClass
    Public ReadOnly Property Property1() As String
        Get
            Return "hello"
        End Get
    End Property

    Public ReadOnly Property Property2() As String
        Get
            Return "hello"
        End Get
    End Property

    Protected ReadOnly Property Property3() As String
        Get
            Return "hello"
        End Get
    End Property

    Private ReadOnly Property Property4 As Integer
        Get
           Return 32
        End Get
    End Property

    Friend ReadOnly Property Property5 As String
       Get
          Return "value"
       End Get
    End Property

    Protected Friend ReadOnly Property Property6 As String
       Get
          Return "value"
       End Get
    End Property
End Class

Public Module Example
    Public Sub Main()
        Dim t As Type = GetType(PropertyClass)
        ' Get the public properties.
        Dim propInfos As PropertyInfo() = t.GetProperties(BindingFlags.Public Or BindingFlags.Instance)
        Console.WriteLine("The number of public properties: {0}",
                          propInfos.Length)
        Console.WriteLine()
        ' Display the public properties.
        DisplayPropertyInfo(propInfos)

        ' Get the non-public properties.
        Dim propInfos1 As PropertyInfo() = t.GetProperties(BindingFlags.NonPublic Or BindingFlags.Instance)
        Console.WriteLine("The number of non-public properties: {0}",
                          propInfos1.Length)
        Console.WriteLine()
        ' Display all the non-public properties.
        DisplayPropertyInfo(propInfos1)
    End Sub

    Public Sub DisplayPropertyInfo(ByVal propInfos() As PropertyInfo)
        ' Display information for all properties.
        For Each propInfo In propInfos
            Dim readable As Boolean = propInfo.CanRead
            Dim writable As Boolean = propInfo.CanWrite
            
            Console.WriteLine("   Property name: {0}", propInfo.Name)
            Console.WriteLine("   Property type: {0}", propInfo.PropertyType)
            Console.WriteLine("   Read-Write:    {0}", readable And writable)
            If readable Then
               Dim getAccessor As MethodInfo = propInfo.GetMethod
               Console.WriteLine("   Visibility:    {0}",
                                 GetVisibility(getAccessor))
            End If
            If writable Then
               Dim setAccessor As MethodInfo = propInfo.SetMethod
               Console.WriteLine("   Visibility:    {0}",
                                 GetVisibility(setAccessor))
            End If
            Console.WriteLine()
        Next
    End Sub
    
    Public Function GetVisibility(accessor As MethodInfo) As String
       If accessor.IsPublic Then
          Return "Public"
       ElseIf accessor.IsPrivate Then
          Return "Private"
       Else If accessor.IsFamily Then
          Return "Protected"
       Else If accessor.IsAssembly Then
          Return "Internal/Friend"
       Else
          Return "Protected Internal/Friend"
       End If
    End Function
End Module
' The example displays the following output:
'       The number of public properties: 2
'
'          Property name: Property1
'          Property type: System.String
'          Read-Write:    False
'          Visibility:    Public
'
'          Property name: Property2
'          Property type: System.String
'          Read-Write:    False
'          Visibility:    Public
'
'       The number of non-public properties: 4
'
'          Property name: Property3
'          Property type: System.String
'          Read-Write:    False
'          Visibility:    Protected
'
'          Property name: Property4
'          Property type: System.Int32
'          Read-Write:    False
'          Visibility:    Private
'
'          Property name: Property5
'          Property type: System.String
'          Read-Write:    False
'          Visibility:    Internal/Friend
'
'          Property name: Property6
'          Property type: System.String
'          Read-Write:    False
'          Visibility:    Protected Internal/Friend
' </Snippet1>