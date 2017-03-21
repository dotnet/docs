    Public Class Keywords
        Public Const Page As EventKeywords = CType(1, EventKeywords)
        Public Const DataBase As EventKeywords = CType(2, EventKeywords)
        Public Const Diagnostic As EventKeywords = CType(4, EventKeywords)
        Public Const Perf As EventKeywords = CType(8, EventKeywords)
    End Class 'Keywords

    Public Class Tasks
        Public Const Page As EventTask = CType(1, EventTask)
        Public Const DBQuery As EventTask = CType(2, EventTask)
    End Class 'Tasks