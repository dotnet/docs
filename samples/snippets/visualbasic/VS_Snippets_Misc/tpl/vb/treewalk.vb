' <Snippet16>
Imports System.Threading.Tasks

Public Class TreeWalk

    Shared Sub Main()

        Dim tree As Tree(Of Person) = New Tree(Of Person)()

        ' ...populate tree (left as an exercise)

        ' Define the Action to perform on each node.
        Dim myAction As Action(Of Person) = New Action(Of Person)(Sub(x)
                                                                      Console.WriteLine("{0}  : {1} ", x.Name, x.Number)
                                                                  End Sub)

        ' Traverse the tree with parallel tasks.
        DoTree(tree, myAction)
    End Sub

    Public Class Person
        Public Name As String
        Public Number As Integer
    End Class

    Public Class Tree(Of T)
        Public Left As Tree(Of T)
        Public Right As Tree(Of T)
        Public Data As T
    End Class

    ' By using tasks explicitly.
    Public Shared Sub DoTree(Of T)(ByVal myTree As Tree(Of T), ByVal a As Action(Of T))
        If myTree Is Nothing Then
            Return
        End If
        Dim left = Task.Factory.StartNew(Sub() DoTree(myTree.Left, a))
        Dim right = Task.Factory.StartNew(Sub() DoTree(myTree.Right, a))
        a(myTree.Data)

        Try
            Task.WaitAll(left, right)
        Catch ae As AggregateException
            'handle exceptions here
        End Try
    End Sub

    ' By using Parallel.Invoke
    Public Shared Sub DoTree2(Of T)(ByVal myTree As Tree(Of T), ByVal myAct As Action(Of T))
        If myTree Is Nothing Then
            Return
        End If
        Parallel.Invoke(
            Sub() DoTree2(myTree.Left, myAct),
            Sub() DoTree2(myTree.Right, myAct),
            Sub() myAct(myTree.Data)
        )
    End Sub
End Class
' </Snippet16>
