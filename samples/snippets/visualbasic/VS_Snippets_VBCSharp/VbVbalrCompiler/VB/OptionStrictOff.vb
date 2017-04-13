' fb4b89d4-4926-4f20-868d-427fa28497b2
    ' /addmodule
Option Explicit On

' <snippet48>
' t2.vb
' Compile with vbc /addmodule:t1.netmodule t2.vb.
Option Strict Off

Namespace NetmoduleTest
    Module Module1
        Sub Main()
            Dim x As TestClass
            x = New TestClass
            x.i = 802
            System.Console.WriteLine(x.i)
        End Sub
    End Module
End Namespace
' </snippet48>

' <snippet47>
' t1.vb
' Compile with vbc /target:module t1.vb.
' Outputs t1.netmodule.

Public Class TestClass
    Public i As Integer
End Class
' </snippet47>


Namespace Classdb7cfa59c315401ca59b0daf355343d6
    ' db7cfa59-c315-401c-a59b-0daf355343d6
    ' /netcf

    Namespace Namespace35
        ' <snippet35>
        Class LateBoundClass
            Sub S1()
            End Sub

            Default Property P1(ByVal s As String) As Integer
                Get
                End Get
                Set(ByVal Value As Integer)
                End Set
            End Property
        End Class

        Module Module1
            Sub Main()
                Dim o1 As Object
                Dim o2 As Object
                Dim o3 As Object
                Dim IntArr(3) As Integer

                o1 = New LateBoundClass
                o2 = 1
                o3 = IntArr

                ' Late-bound calls
                o1.S1()
                o1.P1("member") = 1

                ' Dictionary member access
                o1!member = 1

                ' Late-bound overload resolution
                LateBoundSub(o2)

                ' Late-bound array
                o3(1) = 1
            End Sub

            Sub LateBoundSub(ByVal n As Integer)
            End Sub

            Sub LateBoundSub(ByVal s As String)
            End Sub
        End Module
        ' </snippet35>
    End Namespace

    Namespace namespace36
        ' <snippet36>
        ' compile with: /target:library
        Module Module1
            ' valid with or without /netcf
            Declare Sub DllSub Lib "SomeLib.dll" ()

            ' not valid with /netcf
            Declare Auto Sub DllSub1 Lib "SomeLib.dll" ()
            Declare Ansi Sub DllSub2 Lib "SomeLib.dll" ()
            Declare Unicode Sub DllSub3 Lib "SomeLib.dll" ()
        End Module
        ' </snippet36>
    End Namespace
End Namespace
