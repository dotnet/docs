' <Snippet1>

Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

Class Program

    ' Methods to get:
    
    Public Overloads Sub MethodA(ByVal i As Integer, ByVal l As Long)

    End Sub

    Public Overloads Sub MethodA(ByVal i() As Integer)

    End Sub

    Public Overloads Sub MethodA(ByRef r As Integer)

    End Sub

    ' Method that takes an integer and an out parameter. Note that an
    ' Imports reference is needed to System.Runtime.InteropServices
    ' for the <OutAttribute>, which can be shortened to <Out>.
    Public Overloads Sub MethodA(ByVal i As Integer, <Out()> ByRef o As Integer)
        o = 100
    End Sub

    Public Shared Sub Main(ByVal args() As String)
        Dim mInfo As MethodInfo

        ' Get MethodA(ByVal i As Integer, ByVal l As Long)
        mInfo = GetType(Program).GetMethod("MethodA", _
            BindingFlags.Public Or BindingFlags.Instance, _
            Nothing, _
            CallingConventions.Any, _
            New Type() {GetType(System.Int32), _
            GetType(System.Int64)}, _
            Nothing)
        Console.WriteLine("Found method: {0}", mInfo)

        ' Get  MethodA(ByVal i() As Integer)
        mInfo = GetType(Program).GetMethod("MethodA", _
            BindingFlags.Public Or BindingFlags.Instance, _
            Nothing, _
            CallingConventions.Any, _
            New Type() {GetType(System.Int32())}, _
            Nothing)
        Console.WriteLine("Found method: {0}", mInfo)

        ' Get MethodA(ByRef r As Integer)
        mInfo = GetType(Program).GetMethod("MethodA", _
        BindingFlags.Public Or BindingFlags.Instance, _
        Nothing, _
        CallingConventions.Any, _
        New Type() {GetType(System.Int32).MakeByRefType}, _
        Nothing)
        Console.WriteLine("Found method: {0}", mInfo)

        ' Get MethodA(ByVal i As Integer, <Out()> ByRef o As Integer)
        mInfo = GetType(Program).GetMethod("MethodA", _
        BindingFlags.Public Or BindingFlags.Instance, _
        Nothing, _
        CallingConventions.Any, _
        New Type() {GetType(System.Int32), GetType(System.Int32).MakeByRefType}, _
        Nothing)
        Console.WriteLine("Found method: {0}", mInfo)

    End Sub
End Class
' </Snippet1>
