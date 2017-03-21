    Private initBy As Integer = 0
    Public Sub New(ByVal initializedBy As Integer)
        initBy = initializedBy
        Console.WriteLine("LargeObject was created on thread id {0}.", initBy)
    End Sub