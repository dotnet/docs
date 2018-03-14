' <Snippet1>
Imports System
Imports System.Reflection

Public Class MyPropertyClass
    Private myPropertyArray(9, 9) As Integer
    ' Declare an indexer.
    Default Public Property Item(ByVal i As Integer, ByVal j As Integer) As Integer
        Get
            Return myPropertyArray(i, j)
        End Get
        Set(ByVal Value As Integer)
            myPropertyArray(i, j) = Value
        End Set
    End Property
End Class 'MyPropertyClass

Public Class MyTypeClass
    Public Shared Sub Main()
        Try
            Dim myType As Type = GetType(MyPropertyClass)
            Dim myTypeArray(1) As Type
            ' Create an instance of a Type array representing the number, order 
            ' and type of the parameters for the property.
            myTypeArray.SetValue(GetType(Integer), 0)
            myTypeArray.SetValue(GetType(Integer), 1)
            ' Search for the indexed property whose parameters match the
            ' specified argument types and modifiers.
            Dim myPropertyInfo As PropertyInfo = myType.GetProperty("Item", _
                  GetType(Integer), myTypeArray, Nothing)
            Console.WriteLine(myType.FullName + "." + myPropertyInfo.Name + _
                  " has a property  type of " + myPropertyInfo.PropertyType.ToString())
        Catch ex As Exception
            Console.WriteLine("An exception occurred " + ex.Message.ToString())
        End Try
    End Sub 'Main
End Class 'MyTypeClass
' </Snippet1>

