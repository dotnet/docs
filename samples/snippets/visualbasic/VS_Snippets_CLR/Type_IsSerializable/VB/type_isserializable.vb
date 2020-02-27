' <Snippet1>   
Namespace SystemType
    Public Class [MyClass]
        ' Declare a public class with the [Serializable] attribute.
        <Serializable()> Public Class MyTestClass
        End Class
        Public Overloads Shared Sub Main()
            Try
                Dim myBool As Boolean = False
                Dim myTestClassInstance As New MyTestClass()
                ' Get the type of myTestClassInstance.
                Dim myType As Type = myTestClassInstance.GetType()
                ' Get the IsSerializable property of myTestClassInstance.
                myBool = myType.IsSerializable
                Console.WriteLine(ControlChars.Cr + "Is {0} serializable? {1}.", myType.FullName, myBool.ToString())
            Catch e As Exception
                Console.WriteLine(ControlChars.Cr + "An exception occurred: {0}", e.Message.ToString())
            End Try
        End Sub
    End Class
End Namespace 'SystemType
' </Snippet1>
