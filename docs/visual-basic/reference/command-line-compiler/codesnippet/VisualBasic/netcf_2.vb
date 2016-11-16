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