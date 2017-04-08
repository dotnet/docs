'<Snippet1>
Imports System.Reflection
Imports System.Collections.Generic

Class Example

    Private Shared _sharedProperty As Integer = 41
    Public Shared Property SharedProperty As Integer
        Get 
            Return _sharedProperty
        End Get
        Set
            _sharedProperty = Value
        End Set
    End Property

    Private _instanceProperty As Integer = 42
    Public Property InstanceProperty As Integer
        Get 
            Return _instanceProperty
        End Get
        Set
            _instanceProperty = Value
        End Set
    End Property

    Private _indexedInstanceProperty As New Dictionary(Of Integer, String)
    Default Public Property IndexedInstanceProperty(ByVal key As Integer) As String
        Get 
            Dim returnValue As String = Nothing
            If _indexedInstanceProperty.TryGetValue(key, returnValue) Then
                Return returnValue
            Else
                Return Nothing
            End If
        End Get
        Set
            If Value Is Nothing Then
                Throw New ApplicationException( _
                    "IndexedInstanceProperty value can be the empty string, but it cannot be Nothing.")
            Else
                If _indexedInstanceProperty.ContainsKey(key) Then
                    _indexedInstanceProperty(key) = Value
                Else
                    _indexedInstanceProperty.Add(key, Value)
                End If
            End If
        End Set
    End Property


    Shared Sub Main()

        Console.WriteLine("Initial value of class-level property: {0}", _
            Example.SharedProperty)

        Dim piShared As PropertyInfo = _
            GetType(Example).GetProperty("SharedProperty")
        piShared.SetValue( _
            Nothing, _
            76, _
            Nothing)
                 
        Console.WriteLine("Final value of class-level property: {0}", _
            Example.SharedProperty)


        Dim exam As New Example

        Console.WriteLine(vbCrLf & _
            "Initial value of instance property: {0}", _
            exam.InstanceProperty)

        Dim piInstance As PropertyInfo = _
            GetType(Example).GetProperty("InstanceProperty")
        piInstance.SetValue( _
            exam, _
            37, _
            Nothing)
                 
        Console.WriteLine("Final value of instance property: {0}", _
            exam.InstanceProperty)


        exam(17) = "String number 17"
        exam(46) = "String number 46"
        ' In Visual Basic, a default indexed property can also be referred
        ' to by name.
        exam.IndexedInstanceProperty(9) = "String number 9"

        Console.WriteLine(vbCrLf & _
            "Initial value of indexed instance property(17): '{0}'", _
            exam(17))

        Dim piIndexedInstance As PropertyInfo = _
            GetType(Example).GetProperty("IndexedInstanceProperty")
        piIndexedInstance.SetValue( _
            exam, _
            "New value for string number 17", _
            New Object() { CType(17, Integer) })
                 
        Console.WriteLine("Final value of indexed instance property(17): '{0}'", _
            exam(17))
        
    End Sub
End Class

' This example produces the following output:
'
'Initial value of class-level property: 41
'Final value of class-level property: 76
'
'Initial value of instance property: 42
'Final value of instance property: 37
'
'Initial value of indexed instance property(17): 'String number 17'
'Final value of indexed instance property(17): 'New value for string number 17'
'</Snippet1>
