' <Snippet1>                    
Imports System.Reflection

Module Module3
    Class MyClass3
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
    End Class

    Public Class MyTypeClass3
        Public Shared Sub Run()
            Try
                ' Get the Type Object.
                Dim myType As Type = GetType(MyClass3)
                Dim myTypeArr(1) As Type
                ' Create an instance of a Type array.
                myTypeArr.SetValue(GetType(Integer), 0)
                myTypeArr.SetValue(GetType(Integer), 1)
                ' Get the PropertyInfo object for the indexed property Item, which has two integer parameters. 
                Dim myPropInfo As PropertyInfo = myType.GetProperty("Item", myTypeArr)
                ' Display the property.
                Console.WriteLine("The {0} property exists in MyClass3.", myPropInfo.ToString())
            Catch e As NullReferenceException
                Console.WriteLine("An exception occurred.")
                Console.WriteLine("Source : {0}", e.Source.ToString())
                Console.WriteLine("Message : {0}", e.Message.ToString())
            End Try
        End Sub
    End Class
End Module 'Module3
' </Snippet1>
