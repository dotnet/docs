Module Module1
    '<Snippet1>
    Sub Main()
        Try
            FutureFeature()
        Catch NotImp As NotImplementedException
            Console.WriteLine(NotImp.Message)
        End Try


    End Sub

    Sub FutureFeature()
        ' not developed yet.
        Throw New NotImplementedException()
    End Sub
    '</Snippet1>
End Module