' <Snippet1>                    
Imports System
Imports System.Reflection

Module Module1
    Class MyClass1
        Private myArray As Integer(,) = {{1, 2}, {3, 4}}
        ' Declare an indexer.
        Default Public Property Item(ByVal i As Integer, ByVal j As Integer) As Integer
            Get
                Return myArray(i, j)
            End Get
            Set(ByVal Value As Integer)

                myArray(i, j) = Value
            End Set
        End Property
    End Class 'MyClass1

    Public Class MyTypeClass
        Public Shared Sub Main()
            Try
                ' Get the Type Object.
                Dim myType As Type = GetType(MyClass1)
                Dim myTypeArr(1) As Type
                ' Create an instance of a Type array.
                myTypeArr.SetValue(GetType(Integer), 0)
                myTypeArr.SetValue(GetType(Integer), 1)
                ' Get the PropertyInfo object for the indexed property Item, which has two integer parameters. 
                Dim myPropInfo As PropertyInfo = myType.GetProperty("Item", myTypeArr)
                ' Display the property.
                Console.WriteLine("The {0} property exists in MyClass1.", myPropInfo.ToString())
            Catch e As NullReferenceException
                Console.WriteLine("An exception occurred.")
                Console.WriteLine("Source : {0}", e.Source.ToString())
                Console.WriteLine("Message : {0}", e.Message.ToString())
            End Try
        End Sub 'Main
    End Class 'MyTypeClass
End Module 'Module1
' </Snippet1>