        Dim grades As New List(Of Integer)(New Integer() {78, 92, 100, 37, 81})

        ' Convert the List to an IQueryable<int>.
        Dim iqueryable As IQueryable(Of Integer) = grades.AsQueryable()

        ' Get the Expression property of the IQueryable object.
        Dim expressionTree As System.Linq.Expressions.Expression = _
            iqueryable.Expression

        MsgBox("The NodeType of the expression tree is: " _
            & expressionTree.NodeType.ToString())
        MsgBox("The Type of the expression tree is: " _
            & expressionTree.Type.Name)

        ' This code produces the following output:
        '
        ' The NodeType of the expression tree is: Constant
        ' The Type of the expression tree is: EnumerableQuery`1
