
Imports System
Imports System.Reflection
Imports System.Reflection.Emit

Class CompareGenericTypes
    Public Shared Sub Main()
        Try
            Dim currentDomain As AppDomain = AppDomain.CurrentDomain

            Dim aName As new AssemblyName("TempAssembly")
            Dim ab As AssemblyBuilder = currentDomain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Run)

            Dim mb As ModuleBuilder = ab.DefineDynamicModule(aName.Name)

            Dim tbldr As TypeBuilder = mb.DefineType("MyNewType", TypeAttributes.Public)
            tbldr.DefineGenericParameters("T")
            ' <Snippet1>
            Dim t1 As Type = tbldr.MakeGenericType(GetType(String))
            Dim t2 As Type = tbldr.MakeGenericType(GetType(String))
            Dim result As Boolean = t1.Equals(t2)
            ' </Snippet1>
            Dim matching as String
            If result = True Then
                matching = "Yes"
            Else
                matching = "No"
            End If
            Console.WriteLine("Types t1 and t2 match: {0:s}", matching)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
        End Try
    End Sub
End Class





