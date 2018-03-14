    Public Interface IDemo
        Sub doSomething()
    End Interface
    Public Class implementIDemo
        Implements IDemo
        Private Sub doSomething() Implements IDemo.doSomething
        End Sub
    End Class
    Dim varAsInterface As IDemo = New implementIDemo()
    Dim varAsClass As implementIDemo = New implementIDemo()