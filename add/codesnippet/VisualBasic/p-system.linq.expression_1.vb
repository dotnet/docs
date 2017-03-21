        ' Add the following directive to your file:
        ' Imports System.Linq.Expressions  

        Dim constExpr As ConstantExpression = Expression.Constant(5)
        Console.WriteLine("NodeType: " & constExpr.NodeType.ToString())
        Console.WriteLine("Type: " & constExpr.Type.ToString())

        Dim binExpr As BinaryExpression = Expression.Add(constExpr, constExpr)
        Console.WriteLine("NodeType: " & binExpr.NodeType.ToString())
        Console.WriteLine("Type: " & binExpr.Type.ToString())

        ' This code example produces the following output:
        '
        ' NodeType: Constant
        ' Type: System.Int32
        ' NodeType: Add
        ' Type: System.Int32