' <Snippet2>
Imports System.Reflection

Class Example
    Private Shared _sharedProperty As Integer = 41
    Private _instanceProperty As Integer = 42

    ' Declare a public static (shared) property.
    Public Shared Property SharedProperty As Integer
        Get 
            Return _sharedProperty
        End Get
        Set
            _sharedProperty = Value
        End Set
    End Property

    ' Declare a public instance property.
    Public Property InstanceProperty As Integer
        Get 
            Return _instanceProperty
        End Get
        Set
            _instanceProperty = Value
        End Set
    End Property

    Public Shared Sub Main()
        Console.WriteLine("Initial value of shared property: {0}",
                          Example.SharedProperty)

        ' Get a type object that represents the Example type.
        Dim examType As Type = GetType(Example)
        
        ' Change the static (shared) property value.
        Dim piShared As PropertyInfo = examType.GetProperty("SharedProperty")
        piShared.SetValue(Nothing, 76)
                 
        Console.WriteLine("New value of shared property: {0}",
                          Example.SharedProperty)
        Console.WriteLine()

        ' Create an instance of the Example class.
        Dim exam As New Example

        Console.WriteLine("Initial value of instance property: {0}",
                          exam.InstanceProperty)

        ' Change the instance property value.
        Dim piInstance As PropertyInfo = examType.GetProperty("InstanceProperty")
        piInstance.SetValue(exam, 37)
                 
        Console.WriteLine("New value of instance property: {0}", _
                          exam.InstanceProperty)
    End Sub
End Class
' The example displays the following output:
'       Initial value of shared property: 41
'       New value of shared property: 76
'
'       Initial value of instance property: 42
'       New value of instance property: 37
'</Snippet2>
