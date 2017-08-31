'************************************************
'<Snippet1>
Namespace projNamespace
    Module projModule
        Public Enum basicEnum As Integer
            one = 1
            two = 2
        End Enum
        Public Class innerClass
            Shared Sub numberSub(ByVal firstArg As Integer)
            End Sub
        End Class
    End Module
End Namespace
'</Snippet1>

'<Snippet3>
Namespace thisNamespace
    Public Enum abc
        first = 1
        second
    End Enum
    Module thisModule
        Public Class abc
            Public Sub abcSub()
            End Sub
        End Class
        Public Class xyz
            Public Sub xyzSub()
            End Sub
        End Class
    End Module
End Namespace
'</Snippet3>

'<Snippet4>
Namespace sampleNamespace
    Partial Public Class sampleClass
        Public Sub sub1()
        End Sub
    End Class
    Module sampleModule
        Partial Public Class sampleClass
            Public Sub sub2()
            End Sub
        End Class
    End Module
End Namespace
'</Snippet4>

Module module1
    Sub Main()
        usePromotion()

    End Sub
    '<Snippet2>
    Sub usePromotion()
        projNamespace.projModule.innerClass.numberSub(projNamespace.projModule.basicEnum.one)
        projNamespace.innerClass.numberSub(projNamespace.basicEnum.two)
    End Sub
    '</Snippet2>
End Module
